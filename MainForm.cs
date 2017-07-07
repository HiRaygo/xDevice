/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 20:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

using xDevice.Common;
using xDevice.Forms;

namespace xDevice
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		//bool publicRunning;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			//publicRunning = false;
		}
		
		//窗口加载		
		void MainFormLoad(object sender, EventArgs e)
		{
			//加载默认配置
			LoadConfig();
			//打开日志记录
			MsgLogger.SetLogOnOff(true);
			Thread thd = new Thread(new ThreadStart(UpdateLogListView));
			thd.IsBackground = true;
			thd.Start();
		}
		
		//窗口在最上方
		void TopMostToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(this.TopMost)
			{
				this.TopMost = false;
				topMostToolStripMenuItem.Checked = false;
			}
			else
			{
				this.TopMost = true;
				topMostToolStripMenuItem.Checked = true;
			}
		}
		
		//日志刷新
		void UpdateLogListView()
		{
			LogMsg msg;
			ListViewItem lvi;
			while(true)
			{
				if(MsgLogger.GetMsgNum() >0)
				{
					msg = MsgLogger.PullMsg();
					lvi =new ListViewItem();
					lvi.Text = msg.Time;				
					lvi.SubItems.Add(msg.Device);
					lvi.SubItems.Add(msg.Action);
					lvi.SubItems.Add(msg.Data);
					this.Invoke(new Action(delegate{
						listViewLog.Items.Add(lvi);
						lvi.EnsureVisible();
					    }
					));
					Thread.Sleep(100);
				}
				else
				{
					Thread.Sleep(500);
				}
			}
		}
			
		//添加设备
		void MenuItemAddDeviceClick(object sender, EventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if(node != null)
			{
				//根节点
				if(node.Parent == null)
				{
					string devicename = treeViewDevice.SelectedNode.Text;
					//串口设备
					if(node.Name == "RootCom")
					{	
						AddComDeviceForm acdform = new AddComDeviceForm(this.TopMost);
						if(acdform.ShowDialog() == DialogResult.OK)
						{
							ComDevice cd = new ComDevice(acdform.DeviceName, acdform.CommPara);
							if(ComDeviceManager.AddDevice(cd))
							{
								treeViewDevice.SelectedNode.Nodes.Add(cd.Name);
								treeViewDevice.ExpandAll();
							}
						}
					}
					//网络设备
					else if(node.Name == "RootNet")
					{
						AddNetDeviceForm andform = new AddNetDeviceForm(this.TopMost);
						if(andform.ShowDialog() == DialogResult.OK)
						{
							NetDevice nd = new NetDevice(andform.DeviceName, andform.CommPara);
							if(NetDeviceManager.AddDevice(nd))
							{
								treeViewDevice.SelectedNode.Nodes.Add(nd.Name);
								treeViewDevice.ExpandAll();
							}
						}
					}
					//Modbus
					else if(node.Name == "RootModbus")
					{
						AddModbusForm amform = new AddModbusForm(this.TopMost);
						if(amform.ShowDialog() == DialogResult.OK)
						{
							Modbus mb = new Modbus(amform.BusName, amform.ComParas);
							if(ModbusManager.AddModbus(mb))
							{
								treeViewDevice.SelectedNode.Nodes.Add("Modbus", mb.Name);
								treeViewDevice.ExpandAll();
							}
						}
					}
					//Canbus
					else if(node.Name == "RootCanbus")
					{
						AddCanbusForm acform = new AddCanbusForm(this.TopMost);
						if(acform.ShowDialog() == DialogResult.OK)
						{
							Canbus cb = new Canbus(acform.BusName, acform.ComParas);
							if(CanbusManager.AddCanbus(cb))
							{
								treeViewDevice.SelectedNode.Nodes.Add("Canbus", cb.Name);
								treeViewDevice.ExpandAll();
							}
						}
					}
				}
				//非根节点，总线类
				else
				{
					if(node.Name == "Modbus")
					{
						AddModbusDeviceForm amdform = new AddModbusDeviceForm(this.TopMost);
						if(amdform.ShowDialog() == DialogResult.OK)
						{							
							Modbus bus;
							if(ModbusManager.GetModbusByName(node.Text, out bus))
							{
								ModbusDevice device = new ModbusDevice(amdform.DeviceName, amdform.DeviceAddr);
								if(bus.AddDevice(device))
								{
									treeViewDevice.SelectedNode.Nodes.Add("BusDevice",device.Name);
									treeViewDevice.ExpandAll();
								}
							}							
						}
					}
					else if(node.Name == "Canbus")
					{
						AddCanbusDeviceForm acdform = new AddCanbusDeviceForm(this.TopMost);
						if(acdform.ShowDialog() == DialogResult.OK)
						{							
							Canbus bus;
							if(CanbusManager.GetCanbusByName(node.Text, out bus))
							{
								CanbusDevice device = new CanbusDevice(acdform.DeviceName, acdform.DeviceAddr);
								if(bus.AddDevice(device))
								{
									treeViewDevice.SelectedNode.Nodes.Add("CanDevice",device.Name);
									treeViewDevice.ExpandAll();
								}
							}							
						}
					}
				}
			}
		}
		
	
		//设备列表快捷菜单选择
		void TreeView1MouseDown(object sender, MouseEventArgs e)
		{
			int px = e.Location.X;
			int py = e.Location.Y;
			
			TreeNode node = treeViewDevice.GetNodeAt(px, py);			
			if(node != null)
			{
				treeViewDevice.SelectedNode = node;
				if(node.Parent == null)
				{
					treeViewDevice.ContextMenuStrip = contextMenuCommon;
				}
				else
				{
					if((node.Name == "Modbus") || (node.Name == "Canbus"))
						treeViewDevice.ContextMenuStrip = contextMenuBus;
					else if(node.Name == "BusDevice")
						treeViewDevice.ContextMenuStrip = contextMenuBusDevice;
					else
						treeViewDevice.ContextMenuStrip = contextMenuCommonDevice;
				}
			}
			else
			{
				treeViewDevice.ContextMenuStrip = null;
			}
		}
		
		//刷新，展开所有
		void MenuItemUpdateClick(object sender, EventArgs e)
		{
			treeViewDevice.ExpandAll();
		}
		
		//清除日志列表
		void MenuItemCleanLogClick(object sender, EventArgs e)
		{
			listViewLog.Items.Clear();
			MsgLogger.Clear();
		}
		
		//导出日志到文件
		void MenuItemExportLogClick(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "文本文件(*.txt)|*.txt";
			if(sfd.ShowDialog() == DialogResult.OK)
			{
				using(FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate))
				{
					using(StreamWriter sw = new StreamWriter(fs))
					{
						foreach(ListViewItem item in listViewLog.Items)
						{
							sw.WriteLine(item.SubItems[0].Text +"  "+ item.SubItems[1].Text +"\t"+ item.SubItems[2].Text +"\t"+ item.SubItems[3].Text);
						}
						sw.Flush();
					}
				}
			}
		}
		
		//复制日志数据到剪切板
		void ToolStripMenuItem2Click(object sender, EventArgs e)
		{
			if(listViewLog.SelectedItems !=null)
			{
				Clipboard.SetText(listViewLog.SelectedItems[0].SubItems[3].Text);
			}
		}
		
		//设置日志开关
		void MenuItemLogOnOffClick(object sender, EventArgs e)
		{
			if(MsgLogger.IsLogOn())
			{
				MsgLogger.SetLogOnOff(false);
				MenuItemLogOnOff.Checked = false;
			}
			else
			{
				MsgLogger.SetLogOnOff(true);
				MenuItemLogOnOff.Checked = true;
			}
		}
		
		//日志16进制模式记录
		void HexModeToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(MsgLogger.IsHexMode())
			{
				MsgLogger.SetHexMode(false);
				MenuItemHexMode.Checked = false;
			}
			else
			{
				MsgLogger.SetHexMode(true);
				MenuItemHexMode.Checked = true;
			}
		}
		
		//启动设备
		void MenuItemStartDeviceClick(object sender, EventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				string devicename = treeViewDevice.SelectedNode.Text;
				//串口设备
				if(node.Parent.Name == "RootCom")
				{					
					ComDevice device;
					if(ComDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.Start();
					}
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDevice device;
					if(NetDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.Start();
					}
				}
				//Modbus设备
				else if(node.Parent.Name == "Modbus")
				{
					Modbus bus;
					if(ModbusManager.GetModbusByName(node.Parent.Text, out bus))
					{
						ModbusDevice device;
						if(bus.GetDeviceByName(devicename, out device))
						{	device.Start();}
					}
				}
			}			
		}
		
		//停止设备
		void MenuItemStopDeviceClick(object sender, EventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				string devicename = treeViewDevice.SelectedNode.Text;
				//串口设备
				if(node.Parent.Name == "RootCom")
				{					
					ComDevice device;
					if(ComDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.Stop();
					}
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDevice device;
					if(NetDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.Stop();
					}
				}
				//Modbus设备
				else if(node.Parent.Name == "Modbus")
				{
					Modbus bus;
					if(ModbusManager.GetModbusByName(node.Parent.Text, out bus))
					{
						ModbusDevice device;
						if(bus.GetDeviceByName(devicename, out device))
						{	device.Stop();}
					}
				}
			}			
		}
		
		//删除设备
		void MenuItemDeleteDeviceClick(object sender, EventArgs e)
		{
			//弹框确认
			if(MessageBox.Show("确认删除？","删除",MessageBoxButtons.YesNo) == DialogResult.No)
				return;
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				string devicename = node.Text;
				//串口设备
				if(node.Parent.Name == "RootCom")
				{					
					ComDeviceManager.DeleteDevice(devicename);
					treeViewDevice.SelectedNode.Remove();
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDeviceManager.DeleteDevice(devicename);
					treeViewDevice.SelectedNode.Remove();
				}
				//Modbus总线
				else if(node.Parent.Name == "RootModbus")
				{
					ModbusManager.DeleteModbus(devicename);
					treeViewDevice.SelectedNode.Remove();
				}
				//Canbus总线
				else if(node.Parent.Name == "RootCanbus")
				{
					CanbusManager.DeleteCanbus(devicename);
					treeViewDevice.SelectedNode.Remove();
				}
				//Modbus设备
				else if(node.Parent.Name == "Modbus")
				{
					Modbus bus;
					ModbusManager.GetModbusByName(node.Parent.Text, out bus);
					bus.DeleteDevice(devicename);
					treeViewDevice.SelectedNode.Remove();
				}
				//Canbus设备
				else if(node.Parent.Name == "Canbus")
				{
					Canbus bus;
					CanbusManager.GetCanbusByName(node.Parent.Text, out bus);
					bus.DeleteDevice(devicename);
					treeViewDevice.SelectedNode.Remove();
				}
			}
		}
		
		//添加规则
		void MenuItemAddRuleClick(object sender, EventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				//添加规则对话框
				MatchRule rule;
				AddRuleForm arf = new AddRuleForm(this.TopMost);
				if(arf.ShowDialog() == DialogResult.OK)
				{
					rule = new MatchRule(arf.RuleName, arf.InString, arf.OutString, arf.Enable, 
					                               arf.HexMode, arf.MatchHead, arf.MatchOnce, arf.MatchNext, arf.Delay);
				}
				else{
					return;
				}
				string devicename = treeViewDevice.SelectedNode.Text;
				//串口设备
				if(node.Parent.Name == "RootCom")
				{
					ComDevice device;
					if(ComDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.AddRule(rule);
						List<MatchRule> rules = device.GetRules();
						UpdateListViewRule(rules);
					}
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDevice device;
					if(NetDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.AddRule(rule);
						List<MatchRule> rules = device.GetRules();
						UpdateListViewRule(rules);
					}
				}
			}
		}
				
		//从文件导入规则
		void MenuItemImportRulesClick(object sender, EventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				//打开文件对话框
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.RestoreDirectory = true;
				ofd.Filter = "XML文件(*.xml)|*.xml";
				string filename;
				if(ofd.ShowDialog() == DialogResult.OK)
				{
					filename = ofd.FileName;
				}
				else
					return;
			
				string devicename = treeViewDevice.SelectedNode.Text;
				//串口设备
				if(node.Parent.Name == "RootCom")
				{
					ComDevice device;
					if(ComDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.ImportRulesFromXml(filename);
						List<MatchRule> rules = device.GetRules();
						UpdateListViewRule(rules);
					}
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDevice device;
					if(NetDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.ImportRulesFromXml(filename);
						List<MatchRule> rules = device.GetRules();
						UpdateListViewRule(rules);
					}
				}
			}
		}
		
		//导出规则到文件
		void MenuItemExportRuleClick(object sender, EventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				//保存文件对话框
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.RestoreDirectory = true;
				sfd.Filter = "XML文件(*.xml)|*.xml";
				string filename;
				if(sfd.ShowDialog() == DialogResult.OK)
				{
					filename = sfd.FileName;
				}
				else
					return;
			
				string devicename = treeViewDevice.SelectedNode.Text;
				//串口设备
				if(node.Parent.Name == "RootCom")
				{
					ComDevice device;
					if(ComDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.ExportRulesToXml(filename);
					}
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDevice device;
					if(NetDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.ExportRulesToXml(filename);
					}
				}
			}
		}
			
		
		//选择设备后刷新对应的规则列表
		void TreeViewDeviceAfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if(node != null)
			{
				//根节点
				string devicename = node.Text;
				if(node.Parent == null)
				{
					//状态栏
					StatusLabelDevice.Text = devicename;
					StatusLabelPara.Text = "";
					StatusLabelRunning.Text = "";
					//
					string[][] info;
					//串口设备
					if(node.Name == "RootCom")
					{
						info = ComDeviceManager.GetDeviceInfo();
					}
					//网络设备
					else if(node.Name == "RootNet")
					{
						info = NetDeviceManager.GetDeviceInfo();
					}
					//Modbus总线
					else if(node.Name == "RootModbus")
					{
						info = ModbusManager.GetDeviceInfo();
					}
					else
						info = null;
					UpdateListViewDevice(info);
					return;
				}
				//非根节点
				//串口设备
				if(node.Parent.Name == "RootCom")
				{
					ComDevice device;
					if(ComDeviceManager.GetDeviceByName(devicename, out device))
					{
						UpdateListViewRule(device.GetRules());
						//状态栏
						StatusLabelDevice.Text = devicename;
						StatusLabelPara.Text = device.Para;
						StatusLabelRunning.Text = (device.Running ? "Running" : "Stop");						
					}
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDevice device;
					if(NetDeviceManager.GetDeviceByName(devicename, out device))
					{
						//List<MatchRule> rules = device.GetRules();
						UpdateListViewRule(device.GetRules());
						//状态栏
						StatusLabelDevice.Text = devicename;
						StatusLabelPara.Text = device.Para;
						StatusLabelRunning.Text = (device.Running ? "Running" : "Stop");
					}
				}
				//Modbus总线
				else if(node.Parent.Name == "RootModbus")
				{
					Modbus bus;
					if(ModbusManager.GetModbusByName(devicename, out bus))
					{
						//状态栏
						StatusLabelDevice.Text = devicename;
						StatusLabelPara.Text = bus.CommParas;
						StatusLabelRunning.Text = (bus.Running ? "Running" : "Stop");
						UpdateListViewDevice(bus.GetDeviceInfo());
					}
				}
				//Modbus设备
				else if(node.Parent.Name == "Modbus")
				{
					Modbus bus;
					if(ModbusManager.GetModbusByName(node.Parent.Text, out bus))
					{
						ModbusDevice device;
						if(bus.GetDeviceByName(devicename, out device))
						{
							//状态栏
							StatusLabelDevice.Text = devicename;
							StatusLabelPara.Text = "Address: "+ device.Address.ToString();
							StatusLabelRunning.Text = (device.Running ? "Running" : "Stop");	
							UpdateListViewReg(device.GetRegs());
						}						
					}
				}
			}
		}
		
		//更新设备列表
		void UpdateListViewDevice(string[][] info)
		{
			if(info ==null) return;
			//列表栏显示
			listViewDevice.Visible = true;
			listViewRule.Visible = false;
			listViewReg.Visible = false;
			//列表栏内容刷新			
			listViewDevice.BeginUpdate();
			listViewDevice.Items.Clear();			
			int count = info[0].Length;
			for(int i=0; i<count;i++)
			{
				ListViewItem lvi = new ListViewItem(info[0][i]);
				lvi.SubItems.Add(info[1][i]);
				listViewDevice.Items.Add(lvi);
			}				
			listViewDevice.EndUpdate();
		}
		
		//更新设备规则列表
		void UpdateListViewRule(List<MatchRule> rules)
		{
			//列表栏显示
			listViewDevice.Visible = false;
			listViewRule.Visible = true;
			listViewReg.Visible = false;
			//刷新内容
			listViewRule.BeginUpdate();
			listViewRule.Items.Clear();
			foreach(MatchRule rule in rules)
			{
				ListViewItem lvi = new ListViewItem(rule.Name);
				lvi.SubItems.Add(rule.Enable.ToString());
				lvi.SubItems.Add(rule.MatchHead.ToString());
				lvi.SubItems.Add(rule.MatchOnce.ToString());
				lvi.SubItems.Add(rule.MatchNext.ToString());
				lvi.SubItems.Add(rule.Delayms.ToString());
				lvi.SubItems.Add(rule.HexMode.ToString());
				lvi.SubItems.Add(rule.InString);
				lvi.SubItems.Add(rule.OutString);
				listViewRule.Items.Add(lvi);				
			}
			listViewRule.EndUpdate();
		}
		
		//更新寄存器列表
		void UpdateListViewReg(List<ModbusData> regs)
		{
			//列表栏显示
			listViewDevice.Visible = false;
			listViewRule.Visible = false;
			listViewReg.Visible = true;
			//刷新寄存器列表
			listViewReg.BeginUpdate();
			listViewReg.Items.Clear();
			foreach(ModbusData reg in regs)
			{
				ListViewItem lvi = new ListViewItem(reg.Name);
				lvi.SubItems.Add(reg.Addr.ToString());
				lvi.SubItems.Add(reg.Value.ToString());
				lvi.SubItems.Add(reg.Umode.ToString());
				lvi.SubItems.Add(reg.LLimit.ToString());
				lvi.SubItems.Add(reg.HLimit.ToString());
				lvi.SubItems.Add(reg.Step.ToString());
				listViewReg.Items.Add(lvi);				
			}
			listViewReg.EndUpdate();
		}
		
		
		//编辑规则
		void EditRule()
		{
			var items = listViewRule.SelectedItems;
			if(items == null || items.Count ==0) return;
			ListViewItem lvi = items[0];
			if(lvi == null) return;
			
			EditRuleForm edf = new EditRuleForm(this.TopMost);
			edf.RuleName = lvi.SubItems[0].Text;
			edf.Enable = ((lvi.SubItems[1].Text == "True") ? true : false);
			edf.MatchHead = ((lvi.SubItems[2].Text == "True") ? true : false);
			edf.MatchOnce = ((lvi.SubItems[3].Text == "True") ? true : false);
			edf.MatchNext = ((lvi.SubItems[4].Text == "True") ? true : false);
			edf.Delay = int.Parse(lvi.SubItems[5].Text);
			edf.HexMode = ((lvi.SubItems[6].Text == "True") ? true : false);
			edf.InString = lvi.SubItems[7].Text;
			edf.OutString = lvi.SubItems[8].Text;
			
			MatchRule rule;
			if(edf.ShowDialog() == DialogResult.OK)
			{
				rule = new MatchRule(edf.RuleName, edf.InString, edf.OutString, edf.Enable, 
					                               edf.HexMode, edf.MatchHead, edf.MatchOnce, edf.MatchNext, edf.Delay);
			}
			else{
				return;
			}
			
			//刷新列表
			int index = listViewRule.SelectedItems[0].Index;
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				string devicename = treeViewDevice.SelectedNode.Text;
				//串口设备
				if(node.Parent.Name == "RootCom")
				{
					ComDevice device;
					if(ComDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.ReplaceRule(index, rule);
						List<MatchRule> rules = device.GetRules();
						UpdateListViewRule(rules);
					}
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDevice device;
					if(NetDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.ReplaceRule(index, rule);
						List<MatchRule> rules = device.GetRules();
						UpdateListViewRule(rules);
					}
				}
			}
		}
		//编辑规则-双击
		void ListViewRuleMouseDoubleClick(object sender, MouseEventArgs e)
		{
			EditRule();
		}
		
		void EditRuleToolStripMenuItemClick(object sender, EventArgs e)
		{
			EditRule();
		}
		//删除规则
		void DeleteRuleToolStripMenuItemClick(object sender, EventArgs e)
		{
			var items = listViewRule.SelectedItems;
			if(items == null || items.Count ==0) return;
			int index = listViewRule.SelectedItems[0].Index;
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				string devicename = treeViewDevice.SelectedNode.Text;
				//串口设备
				if(node.Parent.Name == "RootCom")
				{
					ComDevice device;
					if(ComDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.DeleteRule(index);
						listViewRule.Items.RemoveAt(index);
					}
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDevice device;
					if(NetDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.DeleteRule(index);
						listViewRule.Items.RemoveAt(index);
					}
				}				
			}
		}
		
		//上移规则
		void UpRuleToolStripMenuItemClick(object sender, EventArgs e)
		{
			var items = listViewRule.SelectedItems;
			if(items == null || items.Count ==0) return;
			int index = listViewRule.SelectedItems[0].Index;
			if(index < 1) return;
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				string devicename = treeViewDevice.SelectedNode.Text;
				//串口设备
				if(node.Parent.Name == "RootCom")
				{
					ComDevice device;
					if(ComDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.UpRule(index);
						ListViewItem lvi = listViewRule.Items[index];
						listViewRule.Items.RemoveAt(index);
						listViewRule.Items.Insert(index-1, lvi);
					}
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDevice device;
					if(NetDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.UpRule(index);
						ListViewItem lvi = listViewRule.Items[index];
						listViewRule.Items.RemoveAt(index);
						listViewRule.Items.Insert(index-1, lvi);
					}
				}				
			}
		}
		
		//下移规则
		void DownRuleToolStripMenuItemClick(object sender, EventArgs e)
		{
			var items = listViewRule.SelectedItems;
			if(items == null || items.Count ==0) return;
			int index = listViewRule.SelectedItems[0].Index;
			if(index >= listViewRule.Items.Count-1) return;
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				string devicename = treeViewDevice.SelectedNode.Text;
				//串口设备
				if(node.Parent.Name == "RootCom")
				{
					ComDevice device;
					if(ComDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.DownRule(index);
						ListViewItem lvi = listViewRule.Items[index];
						listViewRule.Items.RemoveAt(index);
						listViewRule.Items.Insert(index+1, lvi);
					}
				}
				//网络设备
				else if(node.Parent.Name == "RootNet")
				{
					NetDevice device;
					if(NetDeviceManager.GetDeviceByName(devicename, out device))
					{
						device.DownRule(index);
						ListViewItem lvi = listViewRule.Items[index];
						listViewRule.Items.RemoveAt(index);
						listViewRule.Items.Insert(index+1, lvi);
					}
				}				
			}
		}
		
		//虚拟串口管理
		void VirtualPortToolStripMenuItemClick(object sender, EventArgs e)
		{
			VirtualPortForm vpf = new VirtualPortForm(this.TopMost);
			vpf.ShowDialog();
		}
		
		//关于
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			AboutForm af = new AboutForm(this.TopMost);
			af.ShowDialog();
		}
		
		
		//启动总线
		void StartBusToolStripMenuItemClick(object sender, EventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if(node != null)
			{
				string busname = node.Text;
				//CANBus设备
				if(node.Name == "Canbus")
				{					
					Canbus bus;
					if(CanbusManager.GetCanbusByName(busname, out bus))
					{
						bus.Start();
					}
				}
				//Modbus设备
				else if(node.Name == "Modbus")
				{
					Modbus bus;
					if(ModbusManager.GetModbusByName(busname, out bus))
					{
						bus.Start();
					}
				}
			}
		}
		
		//停止总线
		void StopBusToolStripMenuItemClick(object sender, EventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if(node != null)
			{
				string busname = node.Text;
				//CANBus设备
				if(node.Name == "Canbus")
				{	
					Canbus bus;
					if(CanbusManager.GetCanbusByName(busname, out bus))
					{
						bus.Stop();
					}					
				}
				//Modbus设备
				else if(node.Name == "Modbus")
				{
					Modbus bus;
					if(ModbusManager.GetModbusByName(busname, out bus))
					{
						bus.Stop();
					}
				}
			}
		}
		
		//添加寄存器
		void AddRegsMenuItemClick(object sender, EventArgs e)
		{
			Addreg();	
		}
		
		//添加寄存器
		void Addreg()
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				//添加规则对话框
				ModbusData reg;
				AddRegForm arf = new AddRegForm(this.TopMost);
				if(arf.ShowDialog() == DialogResult.Cancel)
					return;
				reg = new ModbusData(arf.RegName, arf.RegAddr, arf.Umode, arf.RegValue, 
					                               arf.RegLLimit, arf.RegHLimit, arf.RegStep);				
				//
				string devicename = node.Text;
				Modbus bus;
				if(!ModbusManager.GetModbusByName(node.Parent.Text, out bus))
					return;
				
				ModbusDevice device;
				if(bus.GetDeviceByName(devicename, out device))
				{
					device.AddReg(reg.Addr, reg);
					UpdateListViewReg(device.GetRegs());
				}
			}
		}
		
		//导出寄存器配置到文件
		void ExportRegsMenuItemClick(object sender, EventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				//保存文件对话框
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.RestoreDirectory = true;
				sfd.Filter = "XML文件(*.xml)|*.xml";
				string filename;
				if(sfd.ShowDialog() == DialogResult.OK)
				{
					filename = sfd.FileName;
				}
				else
					return;
			
				string devicename = node.Text;
				Modbus bus;
				if(!ModbusManager.GetModbusByName(node.Parent.Text, out bus))
					return;
				
				ModbusDevice device;
				if(bus.GetDeviceByName(devicename, out device))
				{
					device.ExportToXml(filename);
				}
			}
		}
		
		//从文件导入寄存器配置
		void ImportRegsMenuItemClick(object sender, EventArgs e)
		{
			TreeNode node = treeViewDevice.SelectedNode;
			if((node != null) && (node.Parent != null))
			{
				//打开文件对话框
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.RestoreDirectory = true;
				ofd.Filter = "XML文件(*.xml)|*.xml";
				string filename;
				if(ofd.ShowDialog() == DialogResult.OK)
				{
					filename = ofd.FileName;
				}
				else
					return;
			
				string devicename = node.Text;
				Modbus bus;
				if(!ModbusManager.GetModbusByName(node.Parent.Text, out bus))
					return;
				
				ModbusDevice device;
				if(bus.GetDeviceByName(devicename, out device))
				{
					device.ImportFromXml(filename);
					UpdateListViewReg(device.GetRegs());
				}
			}
		}
		
		//新配置，删除所有子节点
		void NewConfigToolStripMenuItemClick(object sender, EventArgs e)
		{
			//treeview
			foreach(TreeNode rootnode in treeViewDevice.Nodes)
			{
				rootnode.Nodes.Clear();
			}
			//设备管理
			ComDeviceManager.DeleteALLDevice();
			NetDeviceManager.DeleteALLDevice();
			ModbusManager.DeleteALLModbus();
		}
		
		//加载配置
		void ImportConfigToolStripMenuItemClick(object sender, EventArgs e)
		{
			LoadConfig();
		}
		
		void LoadConfig()
		{
			XmlNodeList comlist, netlist, modlist;
			try{
				XmlDocument xmlDoc=new XmlDocument(); 
				string runpath = Application.StartupPath;
				xmlDoc.Load(runpath + "/Config/default.xml");
				XmlNode root = xmlDoc.SelectSingleNode("Root");
				comlist = root.SelectSingleNode("ComDevices").ChildNodes;
				netlist = root.SelectSingleNode("NetDevices").ChildNodes;
				modlist = root.SelectSingleNode("Modbuses").ChildNodes;
			}
			catch(Exception ex){
				MsgLogger.PushMsg("ComDevice","LoadConfig",ex.Message);
				return;
			}
			//comdevice
			string name, para;
			try{
				foreach(XmlNode xn in comlist)
				{
					XmlElement xe = (XmlElement)xn;					
					name = xe.GetAttribute("Name");
					para = xe.GetAttribute("Para");
					if(ComDeviceManager.AddDevice(new ComDevice(name,para)))
						treeViewDevice.Nodes[0].Nodes.Add(name);
				}
			}
			catch(Exception ex){
				MsgLogger.PushMsg("ComDevice","LoadConfig",ex.Message);
				return;
			}
			//netdevice
			try{
				foreach(XmlNode xn in netlist)
				{
					XmlElement xe = (XmlElement)xn;					
					name = xe.GetAttribute("Name");
					para = xe.GetAttribute("Para");
					if(NetDeviceManager.AddDevice(new NetDevice(name,para)))
						treeViewDevice.Nodes[1].Nodes.Add(name);
				}
			}
			catch(Exception ex){
				MsgLogger.PushMsg("NetDevice","LoadConfig",ex.Message);
				return;
			}
			//modbus
			try{
				int n=0;
				foreach(XmlNode xn in modlist)
				{
					XmlElement xe = (XmlElement)xn;					
					name = xe.GetAttribute("Name");
					para = xe.GetAttribute("Para");
					Modbus bus = new Modbus(name,para);
					if(ModbusManager.AddModbus(bus))
						treeViewDevice.Nodes[2].Nodes.Add("Modbus",name);
					else
						continue;
					//总线设备
					XmlNodeList devlist = xn.ChildNodes;
					foreach(XmlNode xxn in devlist)
					{
						XmlElement xxe = (XmlElement)xxn;
						string devname = xxe.GetAttribute("Name");
						byte addr = byte.Parse(xxe.GetAttribute("Para"));
						if(bus.AddDevice(new ModbusDevice(devname, addr)))
						{
							treeViewDevice.Nodes[2].Nodes[n].Nodes.Add("BusDevice",devname);
						}
					}
					n++;
				}
			}
			catch(Exception ex){
				MsgLogger.PushMsg("Modbus","LoadConfig",ex.Message);
				return;
			}
			treeViewDevice.ExpandAll();
		}
		
		void SaveConfigtoolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveConfig();
		}
		
		void SaveConfig()
		{
			string cfgpath = Application.StartupPath + "/Config/default.xml";
			XmlTextWriter xmlWriter;
			xmlWriter = new XmlTextWriter(cfgpath, Encoding.Default);
			xmlWriter.Formatting = Formatting.Indented;
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("Root");
			//comdevice
			string[][] comdevs = ComDeviceManager.GetDeviceInfo();
			if(comdevs != null)
			{
				xmlWriter.WriteStartElement("ComDevices");
				for(int i=0; i<comdevs[0].Length; i++)
				{
					xmlWriter.WriteStartElement("Device");
					xmlWriter.WriteAttributeString("Name", comdevs[0][i]);
					xmlWriter.WriteAttributeString("Para", comdevs[1][i]);
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteEndElement();
			}
			//netdevice
			string[][] netdevs = NetDeviceManager.GetDeviceInfo();
			if(netdevs != null)
			{
				xmlWriter.WriteStartElement("NetDevices");
				for(int i=0; i<netdevs[0].Length; i++)
				{
					xmlWriter.WriteStartElement("Device");
					xmlWriter.WriteAttributeString("Name", netdevs[0][i]);
					xmlWriter.WriteAttributeString("Para", netdevs[1][i]);
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteEndElement();
			}
			//modbus
			string[][] mbuses = ModbusManager.GetDeviceInfo();
			if(mbuses != null)
			{
				xmlWriter.WriteStartElement("Modbuses");
				for(int i=0; i<mbuses[0].Length; i++)
				{
					xmlWriter.WriteStartElement("Bus");
					xmlWriter.WriteAttributeString("Name", mbuses[0][i]);
					xmlWriter.WriteAttributeString("Para", mbuses[1][i]);
					Modbus bus;
					if(ModbusManager.GetModbusByName(mbuses[0][i], out bus))
					{
						string[][] mbdevs = bus.GetDeviceInfo();
						if(mbdevs != null)
						{
							for(int ii=0; ii<mbdevs[0].Length; ii++)
							{
								xmlWriter.WriteStartElement("Device");
								xmlWriter.WriteAttributeString("Name", mbdevs[0][ii]);
								xmlWriter.WriteAttributeString("Para", mbdevs[1][ii]);
								xmlWriter.WriteEndElement();
							}
						}
					}					
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
			xmlWriter.Close();
		}
		
		//双击编辑寄存器或添加寄存器
		void ListViewRegMouseDoubleClick(object sender, MouseEventArgs e)
		{
			var items = listViewReg.SelectedItems;
			if(items == null || items.Count ==0)
			{
				Addreg();
			}
			else
			{
				EditReg();
			}
		}
		
		//编辑寄存器
		void EditReg()
		{
			var items = listViewReg.SelectedItems;
			if(items == null || items.Count ==0) return;
			ListViewItem lvi = items[0];
			if(lvi == null) return;
			
			EditRegForm erf = new EditRegForm(this.TopMost);
			erf.RegName = lvi.SubItems[0].Text;
			erf.RegAddr = UInt16.Parse(lvi.SubItems[1].Text);
			erf.RegValue = Int16.Parse(lvi.SubItems[2].Text);
			if(lvi.SubItems[3].Text == "Const")
			{
				erf.Umode = UpdateMode.Const;
			}
			else if(lvi.SubItems[3].Text == "Random")
			{
				erf.Umode = UpdateMode.Random;
			}
			else if(lvi.SubItems[3].Text == "StepAdd")
			{
				erf.Umode = UpdateMode.StepAdd;
			}
			else if(lvi.SubItems[3].Text == "StepDec")
			{
				erf.Umode = UpdateMode.StepDec;
			}
			else if(lvi.SubItems[3].Text == "RollD")
			{
				erf.Umode = UpdateMode.RollD;
			}
			else if(lvi.SubItems[3].Text == "RollA")
			{
				erf.Umode = UpdateMode.RollA;
			}else{
				erf.Umode = UpdateMode.Const;
			}
			erf.RegLLimit = Int16.Parse(lvi.SubItems[4].Text);
			erf.RegHLimit = Int16.Parse(lvi.SubItems[5].Text);
			erf.RegStep = Int16.Parse(lvi.SubItems[6].Text);
			
			ModbusData reg;
			if(erf.ShowDialog() == DialogResult.OK)
			{
				reg = new ModbusData(erf.RegName, erf.RegAddr, erf.Umode, erf.RegValue, erf.RegLLimit, erf.RegHLimit,erf.RegStep);
			}
			else{
				return;
			}
			
			//刷新列表
			TreeNode node = treeViewDevice.SelectedNode;
			if(node == null) return;
			string devicename = node.Text;
			Modbus bus;
			if(!ModbusManager.GetModbusByName(node.Parent.Text, out bus))
				return;
			
			ModbusDevice device;
			if(bus.GetDeviceByName(devicename, out device))
			{
				device.ReplaceReg(erf.RegAddr, reg);
				UpdateListViewReg(device.GetRegs());
			}
		}
		
		void EditToolStripMenuItemClick(object sender, EventArgs e)
		{
			EditReg();
		}
		
		void DeleteToolStripMenuItemClick(object sender, EventArgs e)
		{
			DeleteReg();
		}
		
		//删除寄存器
		void DeleteReg()
		{
			var items = listViewReg.SelectedItems;
			if(items == null || items.Count ==0) return;
			ListViewItem lvi = items[0];
			if(lvi == null) return;			
			UInt16 regAddr = UInt16.Parse(lvi.SubItems[1].Text);
			
			//刷新列表
			TreeNode node = treeViewDevice.SelectedNode;
			if(node == null) return;
			string devicename = node.Text;
			Modbus bus;
			if(!ModbusManager.GetModbusByName(node.Parent.Text, out bus))
				return;
			
			ModbusDevice device;
			if(bus.GetDeviceByName(devicename, out device))
			{
				device.DeleteReg(regAddr);
				UpdateListViewReg(device.GetRegs());
			}
		}
		
		void ToolStripMenuItem4Click(object sender, EventArgs e)
		{
			this.Opacity = 1.0;
			toolStripMenuItem100.Checked = true;
			toolStripMenuItem75.Checked = false;
			toolStripMenuItem50.Checked = false;
		}
		
		void ToolStripMenuItem75Click(object sender, EventArgs e)
		{
			this.Opacity = 0.75;
			toolStripMenuItem100.Checked = false;
			toolStripMenuItem75.Checked = true;
			toolStripMenuItem50.Checked = false;
		}
		
		void ToolStripMenuItem50Click(object sender, EventArgs e)
		{
			this.Opacity = 0.5;
			toolStripMenuItem100.Checked = false;
			toolStripMenuItem75.Checked = false;
			toolStripMenuItem50.Checked = true;
		}
		
		void SetInterfereToolStripMenuItemClick(object sender, EventArgs e)
		{
			AddInterfereForm aiform = new AddInterfereForm();
			if(aiform.ShowDialog() == DialogResult.OK)
			{
				
			}
		}
	}
}

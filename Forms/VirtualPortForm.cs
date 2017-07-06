/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/22
 * 时间: 22:10
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

using xDevice.Common;

namespace xDevice.Forms
{
	/// <summary>
	/// Description of VirtualPortForm.
	/// </summary>
	public partial class VirtualPortForm : Form
	{
		public VirtualPortForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public VirtualPortForm(bool tm)
		{
			InitializeComponent();
			this.TopMost = tm;
		}
		
		void BtnCreatePairClick(object sender, EventArgs e)
		{
			if(!CheckDll())	return;
			
			string com1 = textBox1.Text;
			string com2 = textBox2.Text;
			if(com1.StartsWith("COM"))
			{
				if(VSPD.CreatePair(com1, com2))
				{
					UpdatePortList();
				}
				else
				{
					MessageBox.Show("创建失败");
				}
			}
			else
			{
				MessageBox.Show("端口必须命名为 COM# 的格式");
			}
		}
		
		void BtnDeletePairClick(object sender, EventArgs e)
		{
			if(!CheckDll())	return;
			
			var comx = treeView1.SelectedNode;
			if(comx != null)
			{
				string comxt = comx.Text;
				if(comxt.StartsWith("COM"))
				{
					if(VSPD.DeletePair(comxt))
					{
						UpdatePortList();
					}
					else
					{
						MessageBox.Show("删除失败");
					}
				}
			}		
		}
		
		
	
		void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{
			if(e.Action == TreeViewAction.ByMouse)
			{
				if(e.Node.Text.StartsWith("COM"))
				{
					textBox3.Text = e.Node.Text;
					textBox4.Text = e.Node.Text +"A";
				}
			}
		}
		
		void ButtonDeleteAllClick(object sender, EventArgs e)
		{
			if(!CheckDll())	return;

			if(VSPD.DeleteAll())
			{				
				UpdatePortList();
			}
			else
				MessageBox.Show("删除失败");
		}
		
		///Update the port treeview list		
		void UpdatePortList()
		{
			Thread.Sleep(1000);
			treeView1.Nodes.Clear();
			TreeNode rootnode = new TreeNode("Serial Ports");
			foreach(string portname in SerialPort.GetPortNames())
			{
				rootnode.Nodes.Add(portname);
			}
			treeView1.Nodes.Add(rootnode);
			treeView1.ExpandAll();
		}
		
		void ButtonInstallDriverClick(object sender, EventArgs e)
		{
			string exepath;
			string runpath = Application.StartupPath;
			if(Environment.Is64BitOperatingSystem)
				exepath = runpath + @"\Drivers\x64\vsbsetup.exe";
			else
				exepath = runpath + @"\Drivers\x86\vsbsetup.exe";
			if(System.IO.File.Exists(exepath))
				InstallDriver(exepath);
			else
				MessageBox.Show("驱动不存在");
		}
		
		private void InstallDriver(string exepath)
		{
			System.Diagnostics.Process exp = new System.Diagnostics.Process();
			exp.StartInfo.CreateNoWindow = true;
			exp.StartInfo.FileName = exepath;
			exp.StartInfo.UseShellExecute = false;
			exp.StartInfo.WorkingDirectory = exepath.Replace("vsbsetup.exe", "");
			exp.Start();
			exp.WaitForExit();
			MessageBox.Show("驱动安装成功");
		}
		
		private bool CheckDll()
		{
			string dllpath = Application.StartupPath + @"\Libs\vspdctl.dll";
			if(System.IO.File.Exists(dllpath))
				return true;
			else
			{
				MessageBox.Show("缺少vspdctl.dll");
				return false;
			}				
		}
		
		void VirtualPortFormLoad(object sender, EventArgs e)
		{
			UpdatePortList();
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			textBox2.Text = textBox1.Text +"A";
		}
	}
}

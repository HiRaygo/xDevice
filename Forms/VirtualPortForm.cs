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
			if((com1.StartsWith("COM"))&&(com2.StartsWith("COM")))
			{
				if(VSPD.CreatePair(com1, com2))
				{
					UpdatePortList();
				}
				else
				{
					MessageBox.Show("Create port failed.");
				}
			}
			else
			{
				MessageBox.Show("Port must be named like COM#");
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
						MessageBox.Show("Delete port failed.");
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
				MessageBox.Show("Delete ports failed.");
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
				exepath = runpath + @"\Driver\x64\vsbsetup.exe";
			else
				exepath = runpath + @"\Driver\x86\vsbsetup.exe";
			if(System.IO.File.Exists(exepath))
				InstallDriver(exepath);
			else
				MessageBox.Show("Driver not exists.");
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
			MessageBox.Show("Install driver success.");
		}
		
		private bool CheckDll()
		{
			string dllpath = Application.StartupPath + @"\Libs\vspdctl.dll";
			if(System.IO.File.Exists(dllpath))
				return true;
			else
			{
				MessageBox.Show("Dll lost");
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

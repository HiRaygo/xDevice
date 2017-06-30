/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/21
 * 时间: 18:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace xDevice.Forms
{
	/// <summary>
	/// Description of AddNetDeviceForm.
	/// </summary>
	public partial class AddNetDeviceForm : Form
	{
		public string DeviceName;
		public string DeviceIP;
		public int DevicePort;
		public int Timeout;
		
		public AddNetDeviceForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public AddNetDeviceForm(bool tm)
		{
			InitializeComponent();
			this.TopMost = tm;
		}
		
		void ButtonConformClick(object sender, EventArgs e)
		{
			labeltips.Text = "";
			
			DeviceName = textBoxName.Text.Trim();
			DeviceIP = textBoxIP.Text.Trim();
			string Port = textBoxPort.Text.Trim();;
			if(string.IsNullOrEmpty(DeviceName) || string.IsNullOrEmpty(DeviceIP)|| string.IsNullOrEmpty(Port))
			{
			   	labeltips.Text = "设备名、IP、端口不能为空!";
			   	return;
			}
			if(!int.TryParse(Port, out DevicePort))
				Timeout = 65432;
			
			if(!int.TryParse(textBoxTimeout.Text, out Timeout))
				Timeout = 3000;
			
			DialogResult = DialogResult.OK;
		}
		
		void ButtonCancleClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}

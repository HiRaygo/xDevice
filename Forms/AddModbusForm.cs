/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 22:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using xDevice.Common;

namespace xDevice.Forms
{
	/// <summary>
	/// Description of AddDeviceForm.
	/// </summary>
	public partial class AddModbusForm : Form
	{
		public string BusName;
		public string ComParas;
		
		public AddModbusForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			comboBoxPort.SelectedIndex = 0;
			comboBoxProtocol.SelectedIndex = 0;
		}
		
		public AddModbusForm(bool tm)
		{
			InitializeComponent();
			
			comboBoxPort.SelectedIndex = 0;
			comboBoxProtocol.SelectedIndex = 0;
			this.TopMost = tm;
		}
		
		void ButtonConformClick(object sender, EventArgs e)
		{
			labeltips.Text = "";
			if(string.IsNullOrEmpty(textBoxName.Text.Trim()))
			{
			   	labeltips.Text = "总线名不能为空!";
			   	return;
			}
			BusName = textBoxName.Text.Trim();
			if(comboBoxProtocol.SelectedIndex == 0)
			{
				int timeout = 1000;
				int delay = 10;
				int.TryParse(textBoxTimeout.Text, out timeout);
				int.TryParse(textBoxDelay.Text, out delay);
				ComParas = comboBoxPort.Text +","+ timeout.ToString() +","+ delay.ToString()+","+"RTU";
			}
			else
			{
				string ip = textBoxIP.Text;				
				if(string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(textBoxPort.Text))
				{
				   	labeltips.Text = "IP和Port不能为空!";
				   	return;
				}
				int port = 65432;
				int timeout = 1000;
				int delay = 10;
				int.TryParse(textBoxPort.Text,out port);
				int.TryParse(textBoxTimeout.Text, out timeout);
				int.TryParse(textBoxDelay.Text, out delay);
				ComParas = ip +":"+ port.ToString() +","+ timeout.ToString() +","+ delay.ToString()+","+"TCP";
			}
			
			DialogResult = DialogResult.OK;
		}
		
		void ButtonCancleClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
		
		void ComboBoxProtocolSelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBoxProtocol.SelectedIndex ==0)
			{
				label2.Text = "串口：";
				label3.Text = "*必须选择虚拟串口";
				comboBoxPort.Visible = true;
				textBoxIP.Visible = false;
				textBoxPort.Visible = false;
			}
			else
			{
				label2.Text = "IP：";
				label3.Text = "Port：";
				comboBoxPort.Visible = false;
				textBoxIP.Visible = true;
				textBoxPort.Visible = true;
			}
		}
	}
}

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
	public partial class AddCanbusForm : Form
	{
		public string BusName;
		public string ComParas;
		
		public AddCanbusForm()
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
		
		public AddCanbusForm(bool tm)
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
			int timeout = 1000;
			int delay = 10;
			int.TryParse(textBoxTimeout.Text, out timeout);
			int.TryParse(textBoxDelay.Text, out delay);
			ComParas = comboBoxPort.Text +","+ timeout.ToString() +","+ delay.ToString()+","+comboBoxProtocol.SelectedIndex.ToString();
						
			DialogResult = DialogResult.OK;
		}
		
		void ButtonCancleClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
		
	}
}

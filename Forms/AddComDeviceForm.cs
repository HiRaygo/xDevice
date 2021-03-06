﻿/*
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

namespace xDevice.Forms
{
	/// <summary>
	/// Description of AddDeviceForm.
	/// </summary>
	public partial class AddComDeviceForm : Form
	{
		public string DeviceName;
		public string CommPara;		
		
		public AddComDeviceForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			comboBoxPort.SelectedIndex = 0;
		}
		
		public AddComDeviceForm(bool tm)
		{
			InitializeComponent();
			
			comboBoxPort.SelectedIndex = 0;
			this.TopMost = tm;
		}
		
		void ButtonConformClick(object sender, EventArgs e)
		{
			labeltips.Text = "";
			if(string.IsNullOrEmpty(textBoxName.Text.Trim()))
			{
			   	labeltips.Text = "设备名不能为空!";
			   	return;
			}
			DeviceName = textBoxName.Text.Trim();
			int CommTimeout = 1000;
			int.TryParse(textBoxDelayms.Text, out CommTimeout);
			CommPara = comboBoxPort.Text +","+ CommTimeout.ToString();
			
			DialogResult = DialogResult.OK;
		}
		
		void ButtonCancleClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}

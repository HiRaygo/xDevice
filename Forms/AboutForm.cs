/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/22
 * 时间: 22:41
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace xDevice.Forms
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public AboutForm(bool tm)
		{
			InitializeComponent();
			this.TopMost = tm;
		}		
	}
}

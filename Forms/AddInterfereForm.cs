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
	public partial class AddInterfereForm : Form
	{
		public int TrigerType;
		public int TrigerTime;		
		public byte[] Data1, Data2;
		
		public AddInterfereForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public AddInterfereForm(bool tm)
		{
			InitializeComponent();
			
			this.TopMost = tm;
		}
		
		void ButtonConformClick(object sender, EventArgs e)
		{
			labeltips.Text = "";
			if(radioButtonSTriger.Checked)
				TrigerType = 1;
			else
				TrigerType = 2;
			
			TrigerTime = 5000;
			if(radioButtonRandom.Checked)
				TrigerTime = -1;
			else
				int.TryParse(textBoxInterval1.Text, out TrigerTime);
			
			Data1 = HexString.HexString2Bytes(textBoxData1.Text);
			Data2 = HexString.HexString2Bytes(textBoxData2.Text);
			if(Data1 == null) 
			{
				labeltips.Text = "Hex数据有误，请检查。";
				return;
			}
			DialogResult = DialogResult.OK;
		}
		
		void ButtonCancleClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}

/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 22:17
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
	/// Description of AddRuleForm.
	/// </summary>
	public partial class EditRuleForm : Form
	{
		public string RuleName, InString, OutString;
		public bool Enable, HexMode, MatchHead, MatchOnce, MatchNext;
		public int Delay;
		
		public EditRuleForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public EditRuleForm(bool tm)
		{
			InitializeComponent();
			this.TopMost = tm;
		}
		
		void EditRuleFormLoad(object sender, EventArgs e)
		{
			textBoxRuleName.Text = RuleName;
			textBoxIndata.Text = InString;
			textBoxOutData.Text = OutString;
			textBoxDelay.Text = Delay.ToString();

			checkBoxEnable.Checked = Enable;
			checkBoxHex.Checked = HexMode;
			checkBoxHead.Checked = MatchHead;
			checkBoxOnce.Checked = MatchOnce;
			checkBoxNext.Checked = MatchNext;			
		}
			
		void ButtonConformClick(object sender, EventArgs e)
		{
			RuleName = textBoxRuleName.Text.Trim();
			InString = textBoxIndata.Text.Trim();
			OutString = textBoxOutData.Text.Trim();
			if(string.IsNullOrEmpty(RuleName) || string.IsNullOrEmpty(InString) || string.IsNullOrEmpty(OutString))
			{
				MessageBox.Show("名称、输入、输出不能为空！");
				return;
			}
			Enable = checkBoxEnable.Checked;
			HexMode = checkBoxHex.Checked;
			MatchHead = checkBoxHead.Checked;
			MatchOnce = checkBoxOnce.Checked;
			MatchNext = checkBoxNext.Checked;			
			if(!int.TryParse(textBoxDelay.Text, out Delay))
				Delay = 100;
			if(HexMode)
			{
				try{
					HexString.HexString2Bytes(InString);
					HexString.HexString2Bytes(OutString);
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
			}
			DialogResult = DialogResult.OK;
		}
		
		void ButtonCancleClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
		
	}
}

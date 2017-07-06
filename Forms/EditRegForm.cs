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
	public partial class EditRegForm : Form
	{
		public UInt16 RegAddr;
		public string RegName;
		public Int16 RegValue;
		public Int16 RegHLimit;
		public Int16 RegLLimit;
		public Int16 RegStep;
		public UpdateMode Umode;
		
		RadioButton[] rbs;
		
		public EditRegForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		}
		
		public EditRegForm(bool tm)
		{
			InitializeComponent();
			
			this.TopMost = tm;
		}
		
		void ButtonConformClick(object sender, EventArgs e)
		{	
			RegName = textBoxName.Text;
			if(string.IsNullOrEmpty(RegName)) return;
			
			if(radioButtonConst.Checked)
			{
				Umode = UpdateMode.Const;
				Int16.TryParse(textBoxValueC.Text, out RegValue);
			}
			else if(radioButtonRandom.Checked)
			{
				Umode = UpdateMode.Random;
				Int16.TryParse(textBoxLLimitR.Text, out RegLLimit);
				Int16.TryParse(textBoxHLimitR.Text, out RegHLimit);
				RegValue = RegLLimit;
			}
			else if(radioButtonAdd.Checked)
			{
				Umode = UpdateMode.StepAdd;
				Int16.TryParse(textBoxLLimitA.Text, out RegLLimit);
				Int16.TryParse(textBoxHLimitA.Text, out RegHLimit);
				Int16.TryParse(textBoxStepA.Text, out RegStep);
				RegValue = RegLLimit;
			}
			else if(radioButtonDec.Checked)
			{
				Umode = UpdateMode.StepDec;
				Int16.TryParse(textBoxLLimitD.Text, out RegLLimit);
				Int16.TryParse(textBoxHLimitD.Text, out RegHLimit);
				Int16.TryParse(textBoxStepD.Text, out RegStep);
				RegValue = RegLLimit;
			}
			else if(radioButtonExD.Checked)
			{
				Umode = UpdateMode.RollD;
				Int16.TryParse(textBoxValueExD.Text, out RegValue);
			}
			else if(radioButtonExA.Checked)
			{
				Umode = UpdateMode.RollA;
				Int16.TryParse(textBoxLLimitExA.Text, out RegLLimit);
				Int16.TryParse(textBoxHLimitExA.Text, out RegHLimit);
				RegValue = RegLLimit;
			}

			DialogResult = DialogResult.OK;
		}
		
		void ButtonCancleClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
		
		void RadioButtonCheckedChanged(object sender, EventArgs e)
		{
			foreach(RadioButton rb in rbs)
			{
				rb.CheckedChanged -= RadioButtonCheckedChanged;
				rb.Checked = (rb == (RadioButton)sender);
				rb.CheckedChanged += RadioButtonCheckedChanged;
			}
		}
		
		void AddRegFormLoad(object sender, EventArgs e)
		{
			rbs = new RadioButton[6];
			rbs[0] = radioButtonConst;
			rbs[1] = radioButtonRandom;
			rbs[2] = radioButtonAdd;
			rbs[3] = radioButtonDec;
			rbs[4] = radioButtonExD;
			rbs[5] = radioButtonExA;
			
			//
			textBoxName.Text = RegName;
			textBoxAddr.Text = RegAddr.ToString();;
			switch(Umode)
			{
				case UpdateMode.Const:
					radioButtonConst.Checked = true;
					textBoxValueC.Text = RegValue.ToString();
					break;
				case UpdateMode.Random:
					radioButtonRandom.Checked = true;
					textBoxLLimitR.Text = RegLLimit.ToString();
					textBoxHLimitR.Text = RegHLimit.ToString();
					break;
				case UpdateMode.StepAdd:
					radioButtonAdd.Checked = true;
					textBoxLLimitA.Text = RegLLimit.ToString();
					textBoxHLimitA.Text = RegHLimit.ToString();
					textBoxStepA.Text = RegStep.ToString();
					break;
				case UpdateMode.StepDec:
					radioButtonDec.Checked = true;
					textBoxLLimitD.Text = RegLLimit.ToString();
					textBoxHLimitD.Text = RegHLimit.ToString();
					textBoxStepD.Text = RegStep.ToString();
					break;
				case UpdateMode.RollA:
					radioButtonExD.Checked = true;
					textBoxValueExD.Text = RegValue.ToString();
					break;
				case UpdateMode.RollD:
					radioButtonExA.Checked = true;
					textBoxLLimitExA.Text = RegLLimit.ToString();
					textBoxHLimitExA.Text = RegHLimit.ToString();
					break;
				default:
					break;
			}
		}
	}
}

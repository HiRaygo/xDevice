/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 22:17
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace xDevice.Forms
{
	partial class AddRuleForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonConform = new System.Windows.Forms.Button();
			this.buttonCancle = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxRuleName = new System.Windows.Forms.TextBox();
			this.checkBoxEnable = new System.Windows.Forms.CheckBox();
			this.checkBoxHex = new System.Windows.Forms.CheckBox();
			this.checkBoxHead = new System.Windows.Forms.CheckBox();
			this.checkBoxOnce = new System.Windows.Forms.CheckBox();
			this.checkBoxNext = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxDelay = new System.Windows.Forms.TextBox();
			this.textBoxIndata = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxOutData = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonConform
			// 
			this.buttonConform.Location = new System.Drawing.Point(72, 230);
			this.buttonConform.Name = "buttonConform";
			this.buttonConform.Size = new System.Drawing.Size(75, 23);
			this.buttonConform.TabIndex = 0;
			this.buttonConform.Text = "确定";
			this.buttonConform.UseVisualStyleBackColor = true;
			this.buttonConform.Click += new System.EventHandler(this.ButtonConformClick);
			// 
			// buttonCancle
			// 
			this.buttonCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancle.Location = new System.Drawing.Point(253, 230);
			this.buttonCancle.Name = "buttonCancle";
			this.buttonCancle.Size = new System.Drawing.Size(75, 23);
			this.buttonCancle.TabIndex = 1;
			this.buttonCancle.Text = "取消";
			this.buttonCancle.UseVisualStyleBackColor = true;
			this.buttonCancle.Click += new System.EventHandler(this.ButtonCancleClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(44, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "名称：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRuleName
			// 
			this.textBoxRuleName.Location = new System.Drawing.Point(85, 23);
			this.textBoxRuleName.MaxLength = 32;
			this.textBoxRuleName.Name = "textBoxRuleName";
			this.textBoxRuleName.Size = new System.Drawing.Size(267, 21);
			this.textBoxRuleName.TabIndex = 3;
			// 
			// checkBoxEnable
			// 
			this.checkBoxEnable.Checked = true;
			this.checkBoxEnable.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxEnable.Location = new System.Drawing.Point(43, 50);
			this.checkBoxEnable.Name = "checkBoxEnable";
			this.checkBoxEnable.Size = new System.Drawing.Size(84, 24);
			this.checkBoxEnable.TabIndex = 4;
			this.checkBoxEnable.Text = "启用规则";
			this.checkBoxEnable.UseVisualStyleBackColor = true;
			// 
			// checkBoxHex
			// 
			this.checkBoxHex.Location = new System.Drawing.Point(153, 50);
			this.checkBoxHex.Name = "checkBoxHex";
			this.checkBoxHex.Size = new System.Drawing.Size(82, 24);
			this.checkBoxHex.TabIndex = 5;
			this.checkBoxHex.Text = "16进制";
			this.checkBoxHex.UseVisualStyleBackColor = true;
			// 
			// checkBoxHead
			// 
			this.checkBoxHead.Checked = true;
			this.checkBoxHead.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxHead.Location = new System.Drawing.Point(252, 50);
			this.checkBoxHead.Name = "checkBoxHead";
			this.checkBoxHead.Size = new System.Drawing.Size(75, 24);
			this.checkBoxHead.TabIndex = 6;
			this.checkBoxHead.Text = "匹配开头";
			this.checkBoxHead.UseVisualStyleBackColor = true;
			// 
			// checkBoxOnce
			// 
			this.checkBoxOnce.Location = new System.Drawing.Point(43, 71);
			this.checkBoxOnce.Name = "checkBoxOnce";
			this.checkBoxOnce.Size = new System.Drawing.Size(84, 24);
			this.checkBoxOnce.TabIndex = 7;
			this.checkBoxOnce.Text = "仅匹配一次";
			this.checkBoxOnce.UseVisualStyleBackColor = true;
			// 
			// checkBoxNext
			// 
			this.checkBoxNext.Location = new System.Drawing.Point(153, 71);
			this.checkBoxNext.Name = "checkBoxNext";
			this.checkBoxNext.Size = new System.Drawing.Size(72, 24);
			this.checkBoxNext.TabIndex = 8;
			this.checkBoxNext.Text = "继续匹配";
			this.checkBoxNext.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(308, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "ms延时";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDelay
			// 
			this.textBoxDelay.Location = new System.Drawing.Point(252, 73);
			this.textBoxDelay.MaxLength = 5;
			this.textBoxDelay.Name = "textBoxDelay";
			this.textBoxDelay.Size = new System.Drawing.Size(51, 21);
			this.textBoxDelay.TabIndex = 10;
			this.textBoxDelay.Text = "100";
			// 
			// textBoxIndata
			// 
			this.textBoxIndata.Location = new System.Drawing.Point(85, 101);
			this.textBoxIndata.MaxLength = 256;
			this.textBoxIndata.Multiline = true;
			this.textBoxIndata.Name = "textBoxIndata";
			this.textBoxIndata.Size = new System.Drawing.Size(267, 50);
			this.textBoxIndata.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(43, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 23);
			this.label3.TabIndex = 12;
			this.label3.Text = "输入：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(44, 158);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 23);
			this.label4.TabIndex = 13;
			this.label4.Text = "输出：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxOutData
			// 
			this.textBoxOutData.Location = new System.Drawing.Point(85, 158);
			this.textBoxOutData.MaxLength = 256;
			this.textBoxOutData.Multiline = true;
			this.textBoxOutData.Name = "textBoxOutData";
			this.textBoxOutData.Size = new System.Drawing.Size(267, 50);
			this.textBoxOutData.TabIndex = 14;
			// 
			// AddRuleForm
			// 
			this.AcceptButton = this.buttonConform;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancle;
			this.ClientSize = new System.Drawing.Size(394, 272);
			this.ControlBox = false;
			this.Controls.Add(this.textBoxOutData);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxIndata);
			this.Controls.Add(this.textBoxDelay);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.checkBoxNext);
			this.Controls.Add(this.checkBoxOnce);
			this.Controls.Add(this.checkBoxHead);
			this.Controls.Add(this.checkBoxHex);
			this.Controls.Add(this.checkBoxEnable);
			this.Controls.Add(this.textBoxRuleName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCancle);
			this.Controls.Add(this.buttonConform);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AddRuleForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "添加匹配规则";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox textBoxOutData;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxIndata;
		private System.Windows.Forms.TextBox textBoxDelay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBoxNext;
		private System.Windows.Forms.CheckBox checkBoxOnce;
		private System.Windows.Forms.CheckBox checkBoxHead;
		private System.Windows.Forms.CheckBox checkBoxHex;
		private System.Windows.Forms.CheckBox checkBoxEnable;
		private System.Windows.Forms.TextBox textBoxRuleName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancle;
		private System.Windows.Forms.Button buttonConform;
	}
}

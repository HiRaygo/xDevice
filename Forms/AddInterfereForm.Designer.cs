/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 22:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace xDevice.Forms
{
	partial class AddInterfereForm
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
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxData1 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.labeltips = new System.Windows.Forms.Label();
			this.textBoxData2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxInterval1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButtonRTruger = new System.Windows.Forms.RadioButton();
			this.radioButtonSTriger = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButtonConst = new System.Windows.Forms.RadioButton();
			this.radioButtonRandom = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonConform
			// 
			this.buttonConform.Location = new System.Drawing.Point(90, 224);
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
			this.buttonCancle.Location = new System.Drawing.Point(240, 224);
			this.buttonCancle.Name = "buttonCancle";
			this.buttonCancle.Size = new System.Drawing.Size(75, 23);
			this.buttonCancle.TabIndex = 1;
			this.buttonCancle.Text = "取消";
			this.buttonCancle.UseVisualStyleBackColor = true;
			this.buttonCancle.Click += new System.EventHandler(this.ButtonCancleClick);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 100);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 23);
			this.label7.TabIndex = 14;
			this.label7.Text = "Hex数据1：";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxData1
			// 
			this.textBoxData1.Location = new System.Drawing.Point(99, 100);
			this.textBoxData1.MaxLength = 64;
			this.textBoxData1.Multiline = true;
			this.textBoxData1.Name = "textBoxData1";
			this.textBoxData1.Size = new System.Drawing.Size(262, 32);
			this.textBoxData1.TabIndex = 15;
			this.textBoxData1.Text = "0102030A0B0C";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(32, 175);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 23);
			this.label9.TabIndex = 17;
			this.label9.Text = "提示：";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labeltips
			// 
			this.labeltips.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.labeltips.Location = new System.Drawing.Point(90, 176);
			this.labeltips.Name = "labeltips";
			this.labeltips.Size = new System.Drawing.Size(271, 23);
			this.labeltips.TabIndex = 18;
			this.labeltips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxData2
			// 
			this.textBoxData2.Location = new System.Drawing.Point(99, 138);
			this.textBoxData2.MaxLength = 64;
			this.textBoxData2.Multiline = true;
			this.textBoxData2.Name = "textBoxData2";
			this.textBoxData2.Size = new System.Drawing.Size(262, 32);
			this.textBoxData2.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 23);
			this.label1.TabIndex = 23;
			this.label1.Text = "Hex数据2：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxInterval1
			// 
			this.textBoxInterval1.Location = new System.Drawing.Point(265, 12);
			this.textBoxInterval1.MaxLength = 6;
			this.textBoxInterval1.Name = "textBoxInterval1";
			this.textBoxInterval1.Size = new System.Drawing.Size(68, 21);
			this.textBoxInterval1.TabIndex = 25;
			this.textBoxInterval1.Text = "5000";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(311, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(26, 18);
			this.label4.TabIndex = 29;
			this.label4.Text = "ms";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonRTruger);
			this.groupBox1.Controls.Add(this.radioButtonSTriger);
			this.groupBox1.Location = new System.Drawing.Point(23, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(338, 36);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			// 
			// radioButtonRTruger
			// 
			this.radioButtonRTruger.Location = new System.Drawing.Point(162, 10);
			this.radioButtonRTruger.Name = "radioButtonRTruger";
			this.radioButtonRTruger.Size = new System.Drawing.Size(129, 24);
			this.radioButtonRTruger.TabIndex = 1;
			this.radioButtonRTruger.Text = "接收到数据后触发";
			this.radioButtonRTruger.UseVisualStyleBackColor = true;
			// 
			// radioButtonSTriger
			// 
			this.radioButtonSTriger.Checked = true;
			this.radioButtonSTriger.Location = new System.Drawing.Point(9, 10);
			this.radioButtonSTriger.Name = "radioButtonSTriger";
			this.radioButtonSTriger.Size = new System.Drawing.Size(121, 24);
			this.radioButtonSTriger.TabIndex = 0;
			this.radioButtonSTriger.TabStop = true;
			this.radioButtonSTriger.Text = "设备启动后触发";
			this.radioButtonSTriger.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButtonConst);
			this.groupBox2.Controls.Add(this.radioButtonRandom);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.textBoxInterval1);
			this.groupBox2.Location = new System.Drawing.Point(23, 50);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(338, 39);
			this.groupBox2.TabIndex = 31;
			this.groupBox2.TabStop = false;
			// 
			// radioButtonConst
			// 
			this.radioButtonConst.Location = new System.Drawing.Point(162, 9);
			this.radioButtonConst.Name = "radioButtonConst";
			this.radioButtonConst.Size = new System.Drawing.Size(101, 24);
			this.radioButtonConst.TabIndex = 1;
			this.radioButtonConst.Text = "触发时间固定";
			this.radioButtonConst.UseVisualStyleBackColor = true;
			// 
			// radioButtonRandom
			// 
			this.radioButtonRandom.Checked = true;
			this.radioButtonRandom.Location = new System.Drawing.Point(9, 7);
			this.radioButtonRandom.Name = "radioButtonRandom";
			this.radioButtonRandom.Size = new System.Drawing.Size(104, 24);
			this.radioButtonRandom.TabIndex = 0;
			this.radioButtonRandom.TabStop = true;
			this.radioButtonRandom.Text = "触发时间随机";
			this.radioButtonRandom.UseVisualStyleBackColor = true;
			// 
			// AddInterfereForm
			// 
			this.AcceptButton = this.buttonConform;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancle;
			this.ClientSize = new System.Drawing.Size(394, 272);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBoxData2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labeltips);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBoxData1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.buttonCancle);
			this.Controls.Add(this.buttonConform);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddInterfereForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "设置干扰信号";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RadioButton radioButtonRandom;
		private System.Windows.Forms.RadioButton radioButtonConst;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButtonSTriger;
		private System.Windows.Forms.RadioButton radioButtonRTruger;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxInterval1;
		private System.Windows.Forms.TextBox textBoxData2;
		private System.Windows.Forms.Label labeltips;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBoxData1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancle;
		private System.Windows.Forms.Button buttonConform;
	}
}

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
	partial class EditRegForm
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
			this.textBoxAddr = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxValueC = new System.Windows.Forms.TextBox();
			this.radioButtonConst = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxLLimitR = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxHLimitR = new System.Windows.Forms.TextBox();
			this.radioButtonRandom = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxStepA = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxLLimitA = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxHLimitA = new System.Windows.Forms.TextBox();
			this.radioButtonAdd = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxStepD = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxLLimitD = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxHLimitD = new System.Windows.Forms.TextBox();
			this.radioButtonDec = new System.Windows.Forms.RadioButton();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBoxValueExD = new System.Windows.Forms.TextBox();
			this.radioButtonExD = new System.Windows.Forms.RadioButton();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBoxLLimitExA = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBoxHLimitExA = new System.Windows.Forms.TextBox();
			this.radioButtonExA = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonConform
			// 
			this.buttonConform.Location = new System.Drawing.Point(57, 410);
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
			this.buttonCancle.Location = new System.Drawing.Point(283, 410);
			this.buttonCancle.Name = "buttonCancle";
			this.buttonCancle.Size = new System.Drawing.Size(75, 23);
			this.buttonCancle.TabIndex = 1;
			this.buttonCancle.Text = "取消";
			this.buttonCancle.UseVisualStyleBackColor = true;
			this.buttonCancle.Click += new System.EventHandler(this.ButtonCancleClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(29, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "地址：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxAddr
			// 
			this.textBoxAddr.Location = new System.Drawing.Point(70, 23);
			this.textBoxAddr.MaxLength = 5;
			this.textBoxAddr.Name = "textBoxAddr";
			this.textBoxAddr.ReadOnly = true;
			this.textBoxAddr.Size = new System.Drawing.Size(62, 21);
			this.textBoxAddr.TabIndex = 3;
			this.textBoxAddr.Text = "1000";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(181, 23);
			this.textBoxName.MaxLength = 32;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(203, 21);
			this.textBoxName.TabIndex = 16;
			this.textBoxName.Text = "Address1";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(145, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 23);
			this.label5.TabIndex = 15;
			this.label5.Text = "名称：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBoxValueC);
			this.groupBox1.Controls.Add(this.radioButtonConst);
			this.groupBox1.Location = new System.Drawing.Point(29, 47);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(361, 52);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(147, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 23);
			this.label2.TabIndex = 13;
			this.label2.Text = "值";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxValueC
			// 
			this.textBoxValueC.Location = new System.Drawing.Point(182, 21);
			this.textBoxValueC.MaxLength = 6;
			this.textBoxValueC.Name = "textBoxValueC";
			this.textBoxValueC.Size = new System.Drawing.Size(66, 21);
			this.textBoxValueC.TabIndex = 1;
			this.textBoxValueC.Text = "0";
			// 
			// radioButtonConst
			// 
			this.radioButtonConst.Checked = true;
			this.radioButtonConst.Location = new System.Drawing.Point(15, 18);
			this.radioButtonConst.Name = "radioButtonConst";
			this.radioButtonConst.Size = new System.Drawing.Size(62, 24);
			this.radioButtonConst.TabIndex = 0;
			this.radioButtonConst.TabStop = true;
			this.radioButtonConst.Text = "固定值";
			this.radioButtonConst.UseVisualStyleBackColor = true;
			this.radioButtonConst.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.textBoxLLimitR);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.textBoxHLimitR);
			this.groupBox2.Controls.Add(this.radioButtonRandom);
			this.groupBox2.Location = new System.Drawing.Point(29, 95);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(361, 52);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(147, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 23);
			this.label4.TabIndex = 15;
			this.label4.Text = "下限";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxLLimitR
			// 
			this.textBoxLLimitR.Location = new System.Drawing.Point(182, 21);
			this.textBoxLLimitR.MaxLength = 6;
			this.textBoxLLimitR.Name = "textBoxLLimitR";
			this.textBoxLLimitR.Size = new System.Drawing.Size(66, 21);
			this.textBoxLLimitR.TabIndex = 14;
			this.textBoxLLimitR.Text = "0";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(254, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 23);
			this.label3.TabIndex = 13;
			this.label3.Text = "上限";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxHLimitR
			// 
			this.textBoxHLimitR.Location = new System.Drawing.Point(289, 21);
			this.textBoxHLimitR.MaxLength = 6;
			this.textBoxHLimitR.Name = "textBoxHLimitR";
			this.textBoxHLimitR.Size = new System.Drawing.Size(66, 21);
			this.textBoxHLimitR.TabIndex = 1;
			this.textBoxHLimitR.Text = "100";
			// 
			// radioButtonRandom
			// 
			this.radioButtonRandom.Location = new System.Drawing.Point(15, 18);
			this.radioButtonRandom.Name = "radioButtonRandom";
			this.radioButtonRandom.Size = new System.Drawing.Size(62, 24);
			this.radioButtonRandom.TabIndex = 0;
			this.radioButtonRandom.TabStop = true;
			this.radioButtonRandom.Text = "随机值";
			this.radioButtonRandom.UseVisualStyleBackColor = true;
			this.radioButtonRandom.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.textBoxStepA);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.textBoxLLimitA);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.textBoxHLimitA);
			this.groupBox3.Controls.Add(this.radioButtonAdd);
			this.groupBox3.Location = new System.Drawing.Point(29, 143);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(361, 79);
			this.groupBox3.TabIndex = 19;
			this.groupBox3.TabStop = false;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(147, 47);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(30, 23);
			this.label8.TabIndex = 17;
			this.label8.Text = "步进";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxStepA
			// 
			this.textBoxStepA.Location = new System.Drawing.Point(182, 47);
			this.textBoxStepA.MaxLength = 6;
			this.textBoxStepA.Name = "textBoxStepA";
			this.textBoxStepA.Size = new System.Drawing.Size(66, 21);
			this.textBoxStepA.TabIndex = 16;
			this.textBoxStepA.Text = "1";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(147, 18);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(30, 23);
			this.label6.TabIndex = 15;
			this.label6.Text = "下限";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxLLimitA
			// 
			this.textBoxLLimitA.Location = new System.Drawing.Point(182, 18);
			this.textBoxLLimitA.MaxLength = 6;
			this.textBoxLLimitA.Name = "textBoxLLimitA";
			this.textBoxLLimitA.Size = new System.Drawing.Size(66, 21);
			this.textBoxLLimitA.TabIndex = 14;
			this.textBoxLLimitA.Text = "0";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(254, 18);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 23);
			this.label7.TabIndex = 13;
			this.label7.Text = "上限";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxHLimitA
			// 
			this.textBoxHLimitA.Location = new System.Drawing.Point(289, 18);
			this.textBoxHLimitA.MaxLength = 6;
			this.textBoxHLimitA.Name = "textBoxHLimitA";
			this.textBoxHLimitA.Size = new System.Drawing.Size(66, 21);
			this.textBoxHLimitA.TabIndex = 1;
			this.textBoxHLimitA.Text = "100";
			// 
			// radioButtonAdd
			// 
			this.radioButtonAdd.Location = new System.Drawing.Point(15, 18);
			this.radioButtonAdd.Name = "radioButtonAdd";
			this.radioButtonAdd.Size = new System.Drawing.Size(62, 24);
			this.radioButtonAdd.TabIndex = 0;
			this.radioButtonAdd.TabStop = true;
			this.radioButtonAdd.Text = "递增值";
			this.radioButtonAdd.UseVisualStyleBackColor = true;
			this.radioButtonAdd.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.textBoxStepD);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.textBoxLLimitD);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.textBoxHLimitD);
			this.groupBox4.Controls.Add(this.radioButtonDec);
			this.groupBox4.Location = new System.Drawing.Point(29, 216);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(361, 79);
			this.groupBox4.TabIndex = 20;
			this.groupBox4.TabStop = false;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(147, 47);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(30, 23);
			this.label9.TabIndex = 17;
			this.label9.Text = "步进";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxStepD
			// 
			this.textBoxStepD.Location = new System.Drawing.Point(182, 47);
			this.textBoxStepD.MaxLength = 6;
			this.textBoxStepD.Name = "textBoxStepD";
			this.textBoxStepD.Size = new System.Drawing.Size(66, 21);
			this.textBoxStepD.TabIndex = 16;
			this.textBoxStepD.Text = "1";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(147, 18);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(30, 23);
			this.label10.TabIndex = 15;
			this.label10.Text = "下限";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxLLimitD
			// 
			this.textBoxLLimitD.Location = new System.Drawing.Point(182, 18);
			this.textBoxLLimitD.MaxLength = 6;
			this.textBoxLLimitD.Name = "textBoxLLimitD";
			this.textBoxLLimitD.Size = new System.Drawing.Size(66, 21);
			this.textBoxLLimitD.TabIndex = 14;
			this.textBoxLLimitD.Text = "0";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(254, 18);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(30, 23);
			this.label11.TabIndex = 13;
			this.label11.Text = "上限";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxHLimitD
			// 
			this.textBoxHLimitD.Location = new System.Drawing.Point(289, 18);
			this.textBoxHLimitD.MaxLength = 6;
			this.textBoxHLimitD.Name = "textBoxHLimitD";
			this.textBoxHLimitD.Size = new System.Drawing.Size(66, 21);
			this.textBoxHLimitD.TabIndex = 1;
			this.textBoxHLimitD.Text = "100";
			// 
			// radioButtonDec
			// 
			this.radioButtonDec.Location = new System.Drawing.Point(15, 18);
			this.radioButtonDec.Name = "radioButtonDec";
			this.radioButtonDec.Size = new System.Drawing.Size(62, 24);
			this.radioButtonDec.TabIndex = 0;
			this.radioButtonDec.TabStop = true;
			this.radioButtonDec.Text = "递减值";
			this.radioButtonDec.UseVisualStyleBackColor = true;
			this.radioButtonDec.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.textBoxValueExD);
			this.groupBox5.Controls.Add(this.radioButtonExD);
			this.groupBox5.Location = new System.Drawing.Point(29, 289);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(361, 52);
			this.groupBox5.TabIndex = 21;
			this.groupBox5.TabStop = false;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(254, 19);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(35, 23);
			this.label12.TabIndex = 13;
			this.label12.Text = "初值";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxValueExD
			// 
			this.textBoxValueExD.Location = new System.Drawing.Point(289, 20);
			this.textBoxValueExD.MaxLength = 6;
			this.textBoxValueExD.Name = "textBoxValueExD";
			this.textBoxValueExD.Size = new System.Drawing.Size(66, 21);
			this.textBoxValueExD.TabIndex = 1;
			this.textBoxValueExD.Text = "0";
			// 
			// radioButtonExD
			// 
			this.radioButtonExD.Location = new System.Drawing.Point(15, 18);
			this.radioButtonExD.Name = "radioButtonExD";
			this.radioButtonExD.Size = new System.Drawing.Size(119, 24);
			this.radioButtonExD.TabIndex = 0;
			this.radioButtonExD.TabStop = true;
			this.radioButtonExD.Text = "跳变值（数字量）";
			this.radioButtonExD.UseVisualStyleBackColor = true;
			this.radioButtonExD.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Controls.Add(this.textBoxLLimitExA);
			this.groupBox6.Controls.Add(this.label13);
			this.groupBox6.Controls.Add(this.textBoxHLimitExA);
			this.groupBox6.Controls.Add(this.radioButtonExA);
			this.groupBox6.Location = new System.Drawing.Point(29, 337);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(361, 52);
			this.groupBox6.TabIndex = 22;
			this.groupBox6.TabStop = false;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(147, 21);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(30, 23);
			this.label14.TabIndex = 19;
			this.label14.Text = "值1";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxLLimitExA
			// 
			this.textBoxLLimitExA.Location = new System.Drawing.Point(182, 21);
			this.textBoxLLimitExA.MaxLength = 6;
			this.textBoxLLimitExA.Name = "textBoxLLimitExA";
			this.textBoxLLimitExA.Size = new System.Drawing.Size(66, 21);
			this.textBoxLLimitExA.TabIndex = 18;
			this.textBoxLLimitExA.Text = "0";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(254, 20);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(35, 23);
			this.label13.TabIndex = 13;
			this.label13.Text = "值2";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxHLimitExA
			// 
			this.textBoxHLimitExA.Location = new System.Drawing.Point(289, 21);
			this.textBoxHLimitExA.MaxLength = 6;
			this.textBoxHLimitExA.Name = "textBoxHLimitExA";
			this.textBoxHLimitExA.Size = new System.Drawing.Size(66, 21);
			this.textBoxHLimitExA.TabIndex = 1;
			this.textBoxHLimitExA.Text = "100";
			// 
			// radioButtonExA
			// 
			this.radioButtonExA.Location = new System.Drawing.Point(15, 18);
			this.radioButtonExA.Name = "radioButtonExA";
			this.radioButtonExA.Size = new System.Drawing.Size(119, 24);
			this.radioButtonExA.TabIndex = 0;
			this.radioButtonExA.TabStop = true;
			this.radioButtonExA.Text = "跳变值（模拟量）";
			this.radioButtonExA.UseVisualStyleBackColor = true;
			this.radioButtonExA.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
			// 
			// EditRegForm
			// 
			this.AcceptButton = this.buttonConform;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancle;
			this.ClientSize = new System.Drawing.Size(414, 452);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxAddr);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCancle);
			this.Controls.Add(this.buttonConform);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "EditRegForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "编辑寄存器";
			this.Load += new System.EventHandler(this.AddRegFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RadioButton radioButtonExA;
		private System.Windows.Forms.TextBox textBoxHLimitExA;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBoxLLimitExA;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.RadioButton radioButtonExD;
		private System.Windows.Forms.TextBox textBoxValueExD;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.RadioButton radioButtonDec;
		private System.Windows.Forms.TextBox textBoxHLimitD;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBoxLLimitD;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBoxStepD;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton radioButtonAdd;
		private System.Windows.Forms.TextBox textBoxHLimitA;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxLLimitA;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxStepA;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton radioButtonRandom;
		private System.Windows.Forms.TextBox textBoxHLimitR;
		private System.Windows.Forms.TextBox textBoxLLimitR;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButtonConst;
		private System.Windows.Forms.TextBox textBoxValueC;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxAddr;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancle;
		private System.Windows.Forms.Button buttonConform;
	}
}

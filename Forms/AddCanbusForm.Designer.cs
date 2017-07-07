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
	partial class AddCanbusForm
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
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxPort = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxTimeout = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.labeltips = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBoxProtocol = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxDelay = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
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
			this.buttonCancle.Location = new System.Drawing.Point(246, 224);
			this.buttonCancle.Name = "buttonCancle";
			this.buttonCancle.Size = new System.Drawing.Size(75, 23);
			this.buttonCancle.TabIndex = 1;
			this.buttonCancle.Text = "取消";
			this.buttonCancle.UseVisualStyleBackColor = true;
			this.buttonCancle.Click += new System.EventHandler(this.ButtonCancleClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "总线名：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(88, 32);
			this.textBoxName.MaxLength = 20;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(93, 21);
			this.textBoxName.TabIndex = 3;
			this.textBoxName.Text = "BUS1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "串口：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxPort
			// 
			this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxPort.FormattingEnabled = true;
			this.comboBoxPort.Items.AddRange(new object[] {
									"COM1",
									"COM2",
									"COM3",
									"COM4",
									"COM5",
									"COM6",
									"COM7",
									"COM8",
									"COM9",
									"COM10",
									"COM11",
									"COM12",
									"COM13",
									"COM14",
									"COM15",
									"COM16",
									"COM17",
									"COM18",
									"COM19",
									"COM20"});
			this.comboBoxPort.Location = new System.Drawing.Point(88, 80);
			this.comboBoxPort.Name = "comboBoxPort";
			this.comboBoxPort.Size = new System.Drawing.Size(93, 20);
			this.comboBoxPort.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 23);
			this.label7.TabIndex = 14;
			this.label7.Text = "超时：";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxTimeout
			// 
			this.textBoxTimeout.Location = new System.Drawing.Point(88, 128);
			this.textBoxTimeout.MaxLength = 6;
			this.textBoxTimeout.Name = "textBoxTimeout";
			this.textBoxTimeout.Size = new System.Drawing.Size(93, 21);
			this.textBoxTimeout.TabIndex = 15;
			this.textBoxTimeout.Text = "1000";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(157, 133);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "ms";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(32, 176);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 23);
			this.label9.TabIndex = 17;
			this.label9.Text = "提示：";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labeltips
			// 
			this.labeltips.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.labeltips.Location = new System.Drawing.Point(88, 176);
			this.labeltips.Name = "labeltips";
			this.labeltips.Size = new System.Drawing.Size(271, 23);
			this.labeltips.TabIndex = 18;
			this.labeltips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.Location = new System.Drawing.Point(199, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(146, 23);
			this.label3.TabIndex = 19;
			this.label3.Text = "*必须选择虚拟串口";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(199, 30);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 23);
			this.label5.TabIndex = 21;
			this.label5.Text = "协议：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxProtocol
			// 
			this.comboBoxProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxProtocol.FormattingEnabled = true;
			this.comboBoxProtocol.Items.AddRange(new object[] {
									"整流模块CAN协议（一次电源）",
									"整流模块CAN协议（二次电源）"});
			this.comboBoxProtocol.Location = new System.Drawing.Point(246, 32);
			this.comboBoxProtocol.Name = "comboBoxProtocol";
			this.comboBoxProtocol.Size = new System.Drawing.Size(104, 20);
			this.comboBoxProtocol.TabIndex = 22;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(326, 135);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(24, 13);
			this.label6.TabIndex = 25;
			this.label6.Text = "ms";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDelay
			// 
			this.textBoxDelay.Location = new System.Drawing.Point(246, 130);
			this.textBoxDelay.MaxLength = 6;
			this.textBoxDelay.Name = "textBoxDelay";
			this.textBoxDelay.Size = new System.Drawing.Size(104, 21);
			this.textBoxDelay.TabIndex = 24;
			this.textBoxDelay.Text = "10";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(199, 130);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 23);
			this.label10.TabIndex = 23;
			this.label10.Text = "延时：";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AddCanbusForm
			// 
			this.AcceptButton = this.buttonConform;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancle;
			this.ClientSize = new System.Drawing.Size(394, 272);
			this.ControlBox = false;
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxDelay);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.comboBoxProtocol);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labeltips);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBoxTimeout);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.comboBoxPort);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCancle);
			this.Controls.Add(this.buttonConform);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddCanbusForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "添加Canbus";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBoxDelay;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBoxProtocol;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labeltips;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxTimeout;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox comboBoxPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancle;
		private System.Windows.Forms.Button buttonConform;
	}
}

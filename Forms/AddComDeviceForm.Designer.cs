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
	partial class AddComDeviceForm
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
			this.textBoxDelayms = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.labeltips = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
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
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "设备名：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(90, 32);
			this.textBoxName.MaxLength = 20;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(260, 21);
			this.textBoxName.TabIndex = 3;
			this.textBoxName.Text = "Device1";
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
			this.comboBoxPort.Location = new System.Drawing.Point(90, 80);
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
			// textBoxDelayms
			// 
			this.textBoxDelayms.Location = new System.Drawing.Point(90, 128);
			this.textBoxDelayms.MaxLength = 6;
			this.textBoxDelayms.Name = "textBoxDelayms";
			this.textBoxDelayms.Size = new System.Drawing.Size(93, 21);
			this.textBoxDelayms.TabIndex = 15;
			this.textBoxDelayms.Text = "1000";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(159, 133);
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
			this.labeltips.Location = new System.Drawing.Point(90, 176);
			this.labeltips.Name = "labeltips";
			this.labeltips.Size = new System.Drawing.Size(271, 23);
			this.labeltips.TabIndex = 18;
			this.labeltips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.Location = new System.Drawing.Point(204, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(146, 23);
			this.label3.TabIndex = 19;
			this.label3.Text = "*必须选择虚拟串口";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label4.Location = new System.Drawing.Point(204, 126);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(146, 23);
			this.label4.TabIndex = 20;
			this.label4.Text = "*通讯超时时间";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AddComDeviceForm
			// 
			this.AcceptButton = this.buttonConform;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancle;
			this.ClientSize = new System.Drawing.Size(394, 272);
			this.ControlBox = false;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labeltips);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBoxDelayms);
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
			this.Name = "AddComDeviceForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "添加串口设备";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labeltips;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxDelayms;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox comboBoxPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancle;
		private System.Windows.Forms.Button buttonConform;
	}
}

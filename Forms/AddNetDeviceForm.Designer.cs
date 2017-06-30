/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/21
 * 时间: 18:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace xDevice.Forms
{
	partial class AddNetDeviceForm
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
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxTimeout = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxIP = new System.Windows.Forms.TextBox();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.buttonCancle = new System.Windows.Forms.Button();
			this.buttonConform = new System.Windows.Forms.Button();
			this.labeltips = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(165, 133);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 13);
			this.label8.TabIndex = 31;
			this.label8.Text = "ms";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxTimeout
			// 
			this.textBoxTimeout.Location = new System.Drawing.Point(90, 128);
			this.textBoxTimeout.MaxLength = 6;
			this.textBoxTimeout.Name = "textBoxTimeout";
			this.textBoxTimeout.Size = new System.Drawing.Size(99, 21);
			this.textBoxTimeout.TabIndex = 30;
			this.textBoxTimeout.Text = "3000";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 23);
			this.label7.TabIndex = 29;
			this.label7.Text = "超时：";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(209, 79);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 23);
			this.label6.TabIndex = 27;
			this.label6.Text = "端口：";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 23);
			this.label2.TabIndex = 19;
			this.label2.Text = "IP：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(90, 32);
			this.textBoxName.MaxLength = 20;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(262, 21);
			this.textBoxName.TabIndex = 18;
			this.textBoxName.Text = "Device1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 23);
			this.label1.TabIndex = 17;
			this.label1.Text = "设备名：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxIP
			// 
			this.textBoxIP.Location = new System.Drawing.Point(90, 80);
			this.textBoxIP.MaxLength = 15;
			this.textBoxIP.Name = "textBoxIP";
			this.textBoxIP.Size = new System.Drawing.Size(99, 21);
			this.textBoxIP.TabIndex = 32;
			this.textBoxIP.Text = "127.0.0.1";
			// 
			// textBoxPort
			// 
			this.textBoxPort.Location = new System.Drawing.Point(259, 79);
			this.textBoxPort.MaxLength = 5;
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(93, 21);
			this.textBoxPort.TabIndex = 33;
			this.textBoxPort.Text = "65432";
			// 
			// buttonCancle
			// 
			this.buttonCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancle.Location = new System.Drawing.Point(240, 224);
			this.buttonCancle.Name = "buttonCancle";
			this.buttonCancle.Size = new System.Drawing.Size(75, 23);
			this.buttonCancle.TabIndex = 35;
			this.buttonCancle.Text = "取消";
			this.buttonCancle.UseVisualStyleBackColor = true;
			this.buttonCancle.Click += new System.EventHandler(this.ButtonCancleClick);
			// 
			// buttonConform
			// 
			this.buttonConform.Location = new System.Drawing.Point(90, 224);
			this.buttonConform.Name = "buttonConform";
			this.buttonConform.Size = new System.Drawing.Size(75, 23);
			this.buttonConform.TabIndex = 34;
			this.buttonConform.Text = "确定";
			this.buttonConform.UseVisualStyleBackColor = true;
			this.buttonConform.Click += new System.EventHandler(this.ButtonConformClick);
			// 
			// labeltips
			// 
			this.labeltips.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.labeltips.Location = new System.Drawing.Point(90, 176);
			this.labeltips.Name = "labeltips";
			this.labeltips.Size = new System.Drawing.Size(275, 23);
			this.labeltips.TabIndex = 37;
			this.labeltips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(32, 176);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 23);
			this.label9.TabIndex = 36;
			this.label9.Text = "提示：";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AddNetDeviceForm
			// 
			this.AcceptButton = this.buttonConform;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancle;
			this.ClientSize = new System.Drawing.Size(394, 272);
			this.ControlBox = false;
			this.Controls.Add(this.labeltips);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.buttonCancle);
			this.Controls.Add(this.buttonConform);
			this.Controls.Add(this.textBoxPort);
			this.Controls.Add(this.textBoxIP);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBoxTimeout);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddNetDeviceForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "添加网络设备";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label labeltips;
		private System.Windows.Forms.Button buttonConform;
		private System.Windows.Forms.Button buttonCancle;
		private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.TextBox textBoxIP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxTimeout;
		private System.Windows.Forms.Label label8;
	}
}

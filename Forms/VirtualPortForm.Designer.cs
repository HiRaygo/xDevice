/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/22
 * 时间: 22:10
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace xDevice.Forms
{
	partial class VirtualPortForm
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Serial Ports");
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonInstallDriver = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.buttonDeleteAll = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnDeletePair = new System.Windows.Forms.Button();
			this.btnCreatePair = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pictureBox2);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.buttonInstallDriver);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.buttonDeleteAll);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.btnDeletePair);
			this.groupBox1.Controls.Add(this.btnCreatePair);
			this.groupBox1.Location = new System.Drawing.Point(171, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(327, 310);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Port Manage";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(177, 173);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(57, 53);
			this.pictureBox2.TabIndex = 19;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(177, 97);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(57, 53);
			this.pictureBox1.TabIndex = 18;
			this.pictureBox1.TabStop = false;
			// 
			// buttonInstallDriver
			// 
			this.buttonInstallDriver.Location = new System.Drawing.Point(240, 21);
			this.buttonInstallDriver.Name = "buttonInstallDriver";
			this.buttonInstallDriver.Size = new System.Drawing.Size(73, 37);
			this.buttonInstallDriver.TabIndex = 17;
			this.buttonInstallDriver.Text = "*";
			this.buttonInstallDriver.UseVisualStyleBackColor = true;
			this.buttonInstallDriver.Click += new System.EventHandler(this.ButtonInstallDriverClick);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 75);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(307, 23);
			this.label10.TabIndex = 16;
			this.label10.Text = ".................................................";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label8.Location = new System.Drawing.Point(17, 21);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(216, 55);
			this.label8.TabIndex = 15;
			this.label8.Text = "Please click the right button to install virtual port driver when you run the app" +
			" in the first time, it will spend about 30s.";
			// 
			// buttonDeleteAll
			// 
			this.buttonDeleteAll.Location = new System.Drawing.Point(240, 246);
			this.buttonDeleteAll.Name = "buttonDeleteAll";
			this.buttonDeleteAll.Size = new System.Drawing.Size(73, 49);
			this.buttonDeleteAll.TabIndex = 14;
			this.buttonDeleteAll.Text = "Delete All";
			this.buttonDeleteAll.UseVisualStyleBackColor = true;
			this.buttonDeleteAll.Click += new System.EventHandler(this.ButtonDeleteAllClick);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label7.Location = new System.Drawing.Point(17, 247);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(217, 49);
			this.label7.TabIndex = 13;
			this.label7.Text = "All virtual port will be removed. Make sure all ports are closed.";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(17, 202);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 23);
			this.label3.TabIndex = 9;
			this.label3.Text = "Second port:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 173);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 23);
			this.label4.TabIndex = 10;
			this.label4.Text = "First port:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox3
			// 
			this.textBox3.AllowDrop = true;
			this.textBox3.Location = new System.Drawing.Point(100, 175);
			this.textBox3.MaxLength = 6;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(71, 21);
			this.textBox3.TabIndex = 7;
			this.textBox3.TabStop = false;
			// 
			// textBox4
			// 
			this.textBox4.AllowDrop = true;
			this.textBox4.Location = new System.Drawing.Point(100, 203);
			this.textBox4.MaxLength = 6;
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(71, 21);
			this.textBox4.TabIndex = 8;
			this.textBox4.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(17, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Second port:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 98);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "First port:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.AllowDrop = true;
			this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox1.Location = new System.Drawing.Point(100, 100);
			this.textBox1.MaxLength = 6;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(71, 21);
			this.textBox1.TabIndex = 3;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "COM10";
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.AllowDrop = true;
			this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox2.Location = new System.Drawing.Point(100, 128);
			this.textBox2.MaxLength = 6;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(71, 21);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "COM10A";
			// 
			// btnDeletePair
			// 
			this.btnDeletePair.Location = new System.Drawing.Point(240, 172);
			this.btnDeletePair.Name = "btnDeletePair";
			this.btnDeletePair.Size = new System.Drawing.Size(73, 49);
			this.btnDeletePair.TabIndex = 1;
			this.btnDeletePair.Text = "Delete Pair";
			this.btnDeletePair.UseVisualStyleBackColor = true;
			this.btnDeletePair.Click += new System.EventHandler(this.BtnDeletePairClick);
			// 
			// btnCreatePair
			// 
			this.btnCreatePair.Location = new System.Drawing.Point(240, 97);
			this.btnCreatePair.Name = "btnCreatePair";
			this.btnCreatePair.Size = new System.Drawing.Size(73, 49);
			this.btnCreatePair.TabIndex = 0;
			this.btnCreatePair.Text = "Add Pair";
			this.btnCreatePair.UseVisualStyleBackColor = true;
			this.btnCreatePair.Click += new System.EventHandler(this.BtnCreatePairClick);
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(12, 12);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "Node0";
			treeNode1.Text = "Serial Ports";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode1});
			this.treeView1.Size = new System.Drawing.Size(140, 310);
			this.treeView1.TabIndex = 6;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1AfterSelect);
			// 
			// VirtualPortForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 340);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.treeView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VirtualPortForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "虚拟串口";
			this.Load += new System.EventHandler(this.VirtualPortFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button btnCreatePair;
		private System.Windows.Forms.Button btnDeletePair;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonDeleteAll;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button buttonInstallDriver;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}

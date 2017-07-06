/*
 * 由SharpDevelop创建。
 * 用户： XiaoSanYa
 * 日期: 2017/5/12
 * 时间: 20:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace xDevice
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("通用串口设备");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("通用网络设备");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Modbus设备");
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StatusLabelDevice = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusLabelPara = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusLabelRunning = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuToolBar = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ImportConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveConfigtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.virtualPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cRCCalcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.treeViewDevice = new System.Windows.Forms.TreeView();
			this.listViewDevice = new System.Windows.Forms.ListView();
			this.cHDeviceName = new System.Windows.Forms.ColumnHeader();
			this.cHDeviceParas = new System.Windows.Forms.ColumnHeader();
			this.listViewReg = new System.Windows.Forms.ListView();
			this.cHRegName = new System.Windows.Forms.ColumnHeader();
			this.cHRegAddr = new System.Windows.Forms.ColumnHeader();
			this.cHRegValue = new System.Windows.Forms.ColumnHeader();
			this.cHRegMode = new System.Windows.Forms.ColumnHeader();
			this.cHRegLLimit = new System.Windows.Forms.ColumnHeader();
			this.cHRegHLimit = new System.Windows.Forms.ColumnHeader();
			this.cHRegStep = new System.Windows.Forms.ColumnHeader();
			this.listViewRule = new System.Windows.Forms.ListView();
			this.chRuleName = new System.Windows.Forms.ColumnHeader();
			this.chEnable = new System.Windows.Forms.ColumnHeader();
			this.chMatchHead = new System.Windows.Forms.ColumnHeader();
			this.chMatchOnce = new System.Windows.Forms.ColumnHeader();
			this.chMatchNext = new System.Windows.Forms.ColumnHeader();
			this.chDelay = new System.Windows.Forms.ColumnHeader();
			this.chHex = new System.Windows.Forms.ColumnHeader();
			this.chInString = new System.Windows.Forms.ColumnHeader();
			this.chOutString = new System.Windows.Forms.ColumnHeader();
			this.contextMenuRule = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.upRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.downRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listViewLog = new System.Windows.Forms.ListView();
			this.chTime = new System.Windows.Forms.ColumnHeader();
			this.chDevice = new System.Windows.Forms.ColumnHeader();
			this.chAction = new System.Windows.Forms.ColumnHeader();
			this.chResult = new System.Windows.Forms.ColumnHeader();
			this.contextMenuLog = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MenuItemCleanLog = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemExportLog = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemLogOnOff = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemHexMode = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MenuItemAddDevice = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuCommonDevice = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MenuItemAddRule = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemImportRules = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemExportRule = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemStartDevice = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemStopDevice = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemDeleteDevice = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuBus = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addBusDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.startBusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopBusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteBusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuBusDevice = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.AddRegsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ImportRegsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExportRegsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.startBusDeviceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopBusDeviceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteBusDeviceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuReg = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1.SuspendLayout();
			this.menuToolBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.contextMenuRule.SuspendLayout();
			this.contextMenuLog.SuspendLayout();
			this.contextMenuCommon.SuspendLayout();
			this.contextMenuCommonDevice.SuspendLayout();
			this.contextMenuBus.SuspendLayout();
			this.contextMenuBusDevice.SuspendLayout();
			this.contextMenuReg.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.StatusLabelDevice,
									this.StatusLabelPara,
									this.StatusLabelRunning});
			this.statusStrip1.Location = new System.Drawing.Point(0, 587);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip1.Size = new System.Drawing.Size(915, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// StatusLabelDevice
			// 
			this.StatusLabelDevice.AutoSize = false;
			this.StatusLabelDevice.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.StatusLabelDevice.Name = "StatusLabelDevice";
			this.StatusLabelDevice.Size = new System.Drawing.Size(100, 17);
			// 
			// StatusLabelPara
			// 
			this.StatusLabelPara.AutoSize = false;
			this.StatusLabelPara.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.StatusLabelPara.Name = "StatusLabelPara";
			this.StatusLabelPara.Size = new System.Drawing.Size(200, 17);
			// 
			// StatusLabelRunning
			// 
			this.StatusLabelRunning.AutoSize = false;
			this.StatusLabelRunning.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.StatusLabelRunning.Name = "StatusLabelRunning";
			this.StatusLabelRunning.Size = new System.Drawing.Size(100, 17);
			// 
			// menuToolBar
			// 
			this.menuToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.FileToolStripMenuItem,
									this.ToolsToolStripMenuItem,
									this.toolStripMenuItem1,
									this.HelpToolStripMenuItem});
			this.menuToolBar.Location = new System.Drawing.Point(0, 0);
			this.menuToolBar.Name = "menuToolBar";
			this.menuToolBar.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.menuToolBar.Size = new System.Drawing.Size(915, 25);
			this.menuToolBar.TabIndex = 1;
			this.menuToolBar.Text = "menuStrip1";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.NewConfigToolStripMenuItem,
									this.ImportConfigToolStripMenuItem,
									this.SaveConfigtoolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
			this.FileToolStripMenuItem.Text = "文件(&F)";
			// 
			// NewConfigToolStripMenuItem
			// 
			this.NewConfigToolStripMenuItem.Name = "NewConfigToolStripMenuItem";
			this.NewConfigToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.NewConfigToolStripMenuItem.Text = "新建配置(&N)";
			this.NewConfigToolStripMenuItem.Click += new System.EventHandler(this.NewConfigToolStripMenuItemClick);
			// 
			// ImportConfigToolStripMenuItem
			// 
			this.ImportConfigToolStripMenuItem.Name = "ImportConfigToolStripMenuItem";
			this.ImportConfigToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.ImportConfigToolStripMenuItem.Text = "加载配置(&L)";
			this.ImportConfigToolStripMenuItem.Click += new System.EventHandler(this.ImportConfigToolStripMenuItemClick);
			// 
			// SaveConfigtoolStripMenuItem
			// 
			this.SaveConfigtoolStripMenuItem.Name = "SaveConfigtoolStripMenuItem";
			this.SaveConfigtoolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.SaveConfigtoolStripMenuItem.Text = "保存配置(&S)";
			this.SaveConfigtoolStripMenuItem.Click += new System.EventHandler(this.SaveConfigtoolStripMenuItemClick);
			// 
			// ToolsToolStripMenuItem
			// 
			this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.virtualPortToolStripMenuItem,
									this.cRCCalcToolStripMenuItem});
			this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
			this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
			this.ToolsToolStripMenuItem.Text = "工具(&T)";
			// 
			// virtualPortToolStripMenuItem
			// 
			this.virtualPortToolStripMenuItem.Name = "virtualPortToolStripMenuItem";
			this.virtualPortToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.virtualPortToolStripMenuItem.Text = "虚拟串口(&V)";
			this.virtualPortToolStripMenuItem.Click += new System.EventHandler(this.VirtualPortToolStripMenuItemClick);
			// 
			// cRCCalcToolStripMenuItem
			// 
			this.cRCCalcToolStripMenuItem.Name = "cRCCalcToolStripMenuItem";
			this.cRCCalcToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.cRCCalcToolStripMenuItem.Text = "CRC计算(&C)";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.topMostToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(59, 21);
			this.toolStripMenuItem1.Text = "选项(&S)";
			// 
			// topMostToolStripMenuItem
			// 
			this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
			this.topMostToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.topMostToolStripMenuItem.Text = "窗口在最上方(&T)";
			this.topMostToolStripMenuItem.Click += new System.EventHandler(this.TopMostToolStripMenuItemClick);
			// 
			// HelpToolStripMenuItem
			// 
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.AboutToolStripMenuItem});
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
			this.HelpToolStripMenuItem.Text = "帮助(&H)";
			// 
			// AboutToolStripMenuItem
			// 
			this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
			this.AboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.AboutToolStripMenuItem.Text = "关于(&A)";
			this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel1MinSize = 100;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listViewLog);
			this.splitContainer1.Panel2MinSize = 50;
			this.splitContainer1.Size = new System.Drawing.Size(915, 562);
			this.splitContainer1.SplitterDistance = 400;
			this.splitContainer1.TabIndex = 2;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.treeViewDevice);
			this.splitContainer2.Panel1MinSize = 120;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.listViewDevice);
			this.splitContainer2.Panel2.Controls.Add(this.listViewReg);
			this.splitContainer2.Panel2.Controls.Add(this.listViewRule);
			this.splitContainer2.Panel2MinSize = 550;
			this.splitContainer2.Size = new System.Drawing.Size(915, 400);
			this.splitContainer2.SplitterDistance = 140;
			this.splitContainer2.SplitterWidth = 5;
			this.splitContainer2.TabIndex = 0;
			// 
			// treeViewDevice
			// 
			this.treeViewDevice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewDevice.Location = new System.Drawing.Point(0, 0);
			this.treeViewDevice.Name = "treeViewDevice";
			treeNode1.Name = "RootCom";
			treeNode1.Text = "通用串口设备";
			treeNode2.Name = "RootNet";
			treeNode2.Text = "通用网络设备";
			treeNode3.Name = "RootModbus";
			treeNode3.Text = "Modbus设备";
			this.treeViewDevice.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode1,
									treeNode2,
									treeNode3});
			this.treeViewDevice.Size = new System.Drawing.Size(140, 400);
			this.treeViewDevice.TabIndex = 0;
			this.treeViewDevice.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewDeviceAfterSelect);
			this.treeViewDevice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeView1MouseDown);
			// 
			// listViewDevice
			// 
			this.listViewDevice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.cHDeviceName,
									this.cHDeviceParas});
			this.listViewDevice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewDevice.FullRowSelect = true;
			this.listViewDevice.Location = new System.Drawing.Point(0, 0);
			this.listViewDevice.MultiSelect = false;
			this.listViewDevice.Name = "listViewDevice";
			this.listViewDevice.Size = new System.Drawing.Size(770, 400);
			this.listViewDevice.TabIndex = 2;
			this.listViewDevice.UseCompatibleStateImageBehavior = false;
			this.listViewDevice.View = System.Windows.Forms.View.Details;
			this.listViewDevice.Visible = false;
			// 
			// cHDeviceName
			// 
			this.cHDeviceName.Text = "名称";
			this.cHDeviceName.Width = 120;
			// 
			// cHDeviceParas
			// 
			this.cHDeviceParas.Text = "参数";
			this.cHDeviceParas.Width = 230;
			// 
			// listViewReg
			// 
			this.listViewReg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.cHRegName,
									this.cHRegAddr,
									this.cHRegValue,
									this.cHRegMode,
									this.cHRegLLimit,
									this.cHRegHLimit,
									this.cHRegStep});
			this.listViewReg.ContextMenuStrip = this.contextMenuReg;
			this.listViewReg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewReg.FullRowSelect = true;
			this.listViewReg.Location = new System.Drawing.Point(0, 0);
			this.listViewReg.Name = "listViewReg";
			this.listViewReg.Size = new System.Drawing.Size(770, 400);
			this.listViewReg.TabIndex = 1;
			this.listViewReg.UseCompatibleStateImageBehavior = false;
			this.listViewReg.View = System.Windows.Forms.View.Details;
			this.listViewReg.Visible = false;
			this.listViewReg.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewRegMouseDoubleClick);
			// 
			// cHRegName
			// 
			this.cHRegName.Text = "名称";
			this.cHRegName.Width = 120;
			// 
			// cHRegAddr
			// 
			this.cHRegAddr.Text = "地址";
			// 
			// cHRegValue
			// 
			this.cHRegValue.Text = "值";
			// 
			// cHRegMode
			// 
			this.cHRegMode.Text = "值类型";
			this.cHRegMode.Width = 80;
			// 
			// cHRegLLimit
			// 
			this.cHRegLLimit.Text = "下限";
			// 
			// cHRegHLimit
			// 
			this.cHRegHLimit.Text = "上限";
			// 
			// cHRegStep
			// 
			this.cHRegStep.Text = "步进";
			// 
			// listViewRule
			// 
			this.listViewRule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chRuleName,
									this.chEnable,
									this.chMatchHead,
									this.chMatchOnce,
									this.chMatchNext,
									this.chDelay,
									this.chHex,
									this.chInString,
									this.chOutString});
			this.listViewRule.ContextMenuStrip = this.contextMenuRule;
			this.listViewRule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewRule.FullRowSelect = true;
			this.listViewRule.GridLines = true;
			this.listViewRule.HideSelection = false;
			this.listViewRule.Location = new System.Drawing.Point(0, 0);
			this.listViewRule.MultiSelect = false;
			this.listViewRule.Name = "listViewRule";
			this.listViewRule.Size = new System.Drawing.Size(770, 400);
			this.listViewRule.TabIndex = 0;
			this.listViewRule.UseCompatibleStateImageBehavior = false;
			this.listViewRule.View = System.Windows.Forms.View.Details;
			this.listViewRule.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewRuleMouseDoubleClick);
			// 
			// chRuleName
			// 
			this.chRuleName.Text = "名称";
			this.chRuleName.Width = 80;
			// 
			// chEnable
			// 
			this.chEnable.Text = "使能";
			this.chEnable.Width = 50;
			// 
			// chMatchHead
			// 
			this.chMatchHead.Text = "仅前段";
			// 
			// chMatchOnce
			// 
			this.chMatchOnce.Text = "仅一次";
			// 
			// chMatchNext
			// 
			this.chMatchNext.Text = "继续匹配";
			this.chMatchNext.Width = 80;
			// 
			// chDelay
			// 
			this.chDelay.Text = "延时";
			this.chDelay.Width = 50;
			// 
			// chHex
			// 
			this.chHex.Text = "HEX";
			this.chHex.Width = 50;
			// 
			// chInString
			// 
			this.chInString.Text = "输入";
			this.chInString.Width = 110;
			// 
			// chOutString
			// 
			this.chOutString.Text = "输出";
			this.chOutString.Width = 110;
			// 
			// contextMenuRule
			// 
			this.contextMenuRule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.editRuleToolStripMenuItem,
									this.toolStripSeparator4,
									this.addToolStripMenuItem,
									this.deleteRuleToolStripMenuItem,
									this.toolStripSeparator5,
									this.upRuleToolStripMenuItem,
									this.downRuleToolStripMenuItem});
			this.contextMenuRule.Name = "contextMenuRule";
			this.contextMenuRule.Size = new System.Drawing.Size(101, 126);
			// 
			// editRuleToolStripMenuItem
			// 
			this.editRuleToolStripMenuItem.Name = "editRuleToolStripMenuItem";
			this.editRuleToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.editRuleToolStripMenuItem.Text = "编辑";
			this.editRuleToolStripMenuItem.Click += new System.EventHandler(this.EditRuleToolStripMenuItemClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(97, 6);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.addToolStripMenuItem.Text = "添加";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.MenuItemAddRuleClick);
			// 
			// deleteRuleToolStripMenuItem
			// 
			this.deleteRuleToolStripMenuItem.Name = "deleteRuleToolStripMenuItem";
			this.deleteRuleToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.deleteRuleToolStripMenuItem.Text = "删除";
			this.deleteRuleToolStripMenuItem.Click += new System.EventHandler(this.DeleteRuleToolStripMenuItemClick);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(97, 6);
			// 
			// upRuleToolStripMenuItem
			// 
			this.upRuleToolStripMenuItem.Name = "upRuleToolStripMenuItem";
			this.upRuleToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.upRuleToolStripMenuItem.Text = "上移";
			this.upRuleToolStripMenuItem.Click += new System.EventHandler(this.UpRuleToolStripMenuItemClick);
			// 
			// downRuleToolStripMenuItem
			// 
			this.downRuleToolStripMenuItem.Name = "downRuleToolStripMenuItem";
			this.downRuleToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.downRuleToolStripMenuItem.Text = "下移";
			this.downRuleToolStripMenuItem.Click += new System.EventHandler(this.DownRuleToolStripMenuItemClick);
			// 
			// listViewLog
			// 
			this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chTime,
									this.chDevice,
									this.chAction,
									this.chResult});
			this.listViewLog.ContextMenuStrip = this.contextMenuLog;
			this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewLog.FullRowSelect = true;
			this.listViewLog.GridLines = true;
			this.listViewLog.Location = new System.Drawing.Point(0, 0);
			this.listViewLog.Name = "listViewLog";
			this.listViewLog.Size = new System.Drawing.Size(915, 158);
			this.listViewLog.TabIndex = 0;
			this.listViewLog.UseCompatibleStateImageBehavior = false;
			this.listViewLog.View = System.Windows.Forms.View.Details;
			// 
			// chTime
			// 
			this.chTime.Text = "时间";
			this.chTime.Width = 120;
			// 
			// chDevice
			// 
			this.chDevice.Text = "设备";
			this.chDevice.Width = 80;
			// 
			// chAction
			// 
			this.chAction.Text = "动作";
			this.chAction.Width = 80;
			// 
			// chResult
			// 
			this.chResult.Text = "数据";
			this.chResult.Width = 450;
			// 
			// contextMenuLog
			// 
			this.contextMenuLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.MenuItemCleanLog,
									this.toolStripMenuItem2,
									this.MenuItemExportLog,
									this.toolStripSeparator6,
									this.MenuItemLogOnOff,
									this.MenuItemHexMode});
			this.contextMenuLog.Name = "contextMenuStripLog";
			this.contextMenuLog.Size = new System.Drawing.Size(161, 120);
			// 
			// MenuItemCleanLog
			// 
			this.MenuItemCleanLog.Name = "MenuItemCleanLog";
			this.MenuItemCleanLog.Size = new System.Drawing.Size(160, 22);
			this.MenuItemCleanLog.Text = "清除";
			this.MenuItemCleanLog.Click += new System.EventHandler(this.MenuItemCleanLogClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem2.Text = "复制到剪贴板";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2Click);
			// 
			// MenuItemExportLog
			// 
			this.MenuItemExportLog.Name = "MenuItemExportLog";
			this.MenuItemExportLog.Size = new System.Drawing.Size(160, 22);
			this.MenuItemExportLog.Text = "导出日志到文件";
			this.MenuItemExportLog.Click += new System.EventHandler(this.MenuItemExportLogClick);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(157, 6);
			// 
			// MenuItemLogOnOff
			// 
			this.MenuItemLogOnOff.Checked = true;
			this.MenuItemLogOnOff.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MenuItemLogOnOff.Name = "MenuItemLogOnOff";
			this.MenuItemLogOnOff.Size = new System.Drawing.Size(160, 22);
			this.MenuItemLogOnOff.Text = "记录开关";
			this.MenuItemLogOnOff.Click += new System.EventHandler(this.MenuItemLogOnOffClick);
			// 
			// MenuItemHexMode
			// 
			this.MenuItemHexMode.Checked = true;
			this.MenuItemHexMode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MenuItemHexMode.Name = "MenuItemHexMode";
			this.MenuItemHexMode.Size = new System.Drawing.Size(160, 22);
			this.MenuItemHexMode.Text = "16进制模式";
			this.MenuItemHexMode.Click += new System.EventHandler(this.HexModeToolStripMenuItemClick);
			// 
			// contextMenuCommon
			// 
			this.contextMenuCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.MenuItemAddDevice});
			this.contextMenuCommon.Name = "contextMenuStrip1";
			this.contextMenuCommon.Size = new System.Drawing.Size(125, 26);
			// 
			// MenuItemAddDevice
			// 
			this.MenuItemAddDevice.Name = "MenuItemAddDevice";
			this.MenuItemAddDevice.Size = new System.Drawing.Size(124, 22);
			this.MenuItemAddDevice.Text = "添加设备";
			this.MenuItemAddDevice.Click += new System.EventHandler(this.MenuItemAddDeviceClick);
			// 
			// contextMenuCommonDevice
			// 
			this.contextMenuCommonDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.MenuItemAddRule,
									this.MenuItemImportRules,
									this.MenuItemExportRule,
									this.toolStripSeparator2,
									this.MenuItemStartDevice,
									this.MenuItemStopDevice,
									this.MenuItemDeleteDevice});
			this.contextMenuCommonDevice.Name = "contextMenuStrip2";
			this.contextMenuCommonDevice.Size = new System.Drawing.Size(185, 142);
			// 
			// MenuItemAddRule
			// 
			this.MenuItemAddRule.Name = "MenuItemAddRule";
			this.MenuItemAddRule.Size = new System.Drawing.Size(184, 22);
			this.MenuItemAddRule.Text = "添加匹配规则";
			this.MenuItemAddRule.Click += new System.EventHandler(this.MenuItemAddRuleClick);
			// 
			// MenuItemImportRules
			// 
			this.MenuItemImportRules.Name = "MenuItemImportRules";
			this.MenuItemImportRules.Size = new System.Drawing.Size(184, 22);
			this.MenuItemImportRules.Text = "从文件导入匹配规则";
			this.MenuItemImportRules.Click += new System.EventHandler(this.MenuItemImportRulesClick);
			// 
			// MenuItemExportRule
			// 
			this.MenuItemExportRule.Name = "MenuItemExportRule";
			this.MenuItemExportRule.Size = new System.Drawing.Size(184, 22);
			this.MenuItemExportRule.Text = "导出匹配规则到文件";
			this.MenuItemExportRule.Click += new System.EventHandler(this.MenuItemExportRuleClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
			// 
			// MenuItemStartDevice
			// 
			this.MenuItemStartDevice.Name = "MenuItemStartDevice";
			this.MenuItemStartDevice.Size = new System.Drawing.Size(184, 22);
			this.MenuItemStartDevice.Text = "启动设备";
			this.MenuItemStartDevice.Click += new System.EventHandler(this.MenuItemStartDeviceClick);
			// 
			// MenuItemStopDevice
			// 
			this.MenuItemStopDevice.Name = "MenuItemStopDevice";
			this.MenuItemStopDevice.Size = new System.Drawing.Size(184, 22);
			this.MenuItemStopDevice.Text = "停止设备";
			this.MenuItemStopDevice.Click += new System.EventHandler(this.MenuItemStopDeviceClick);
			// 
			// MenuItemDeleteDevice
			// 
			this.MenuItemDeleteDevice.Name = "MenuItemDeleteDevice";
			this.MenuItemDeleteDevice.Size = new System.Drawing.Size(184, 22);
			this.MenuItemDeleteDevice.Text = "删除设备";
			this.MenuItemDeleteDevice.Click += new System.EventHandler(this.MenuItemDeleteDeviceClick);
			// 
			// contextMenuBus
			// 
			this.contextMenuBus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.addBusDeviceToolStripMenuItem,
									this.toolStripSeparator7,
									this.startBusToolStripMenuItem,
									this.stopBusToolStripMenuItem,
									this.toolStripSeparator8,
									this.deleteBusToolStripMenuItem});
			this.contextMenuBus.Name = "contextMenuBusDevice";
			this.contextMenuBus.Size = new System.Drawing.Size(149, 104);
			// 
			// addBusDeviceToolStripMenuItem
			// 
			this.addBusDeviceToolStripMenuItem.Name = "addBusDeviceToolStripMenuItem";
			this.addBusDeviceToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.addBusDeviceToolStripMenuItem.Text = "添加总线设备";
			this.addBusDeviceToolStripMenuItem.Click += new System.EventHandler(this.MenuItemAddDeviceClick);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(145, 6);
			// 
			// startBusToolStripMenuItem
			// 
			this.startBusToolStripMenuItem.Name = "startBusToolStripMenuItem";
			this.startBusToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.startBusToolStripMenuItem.Text = "启动总线";
			this.startBusToolStripMenuItem.Click += new System.EventHandler(this.StartBusToolStripMenuItemClick);
			// 
			// stopBusToolStripMenuItem
			// 
			this.stopBusToolStripMenuItem.Name = "stopBusToolStripMenuItem";
			this.stopBusToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.stopBusToolStripMenuItem.Text = "停止总线";
			this.stopBusToolStripMenuItem.Click += new System.EventHandler(this.StopBusToolStripMenuItemClick);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(145, 6);
			// 
			// deleteBusToolStripMenuItem
			// 
			this.deleteBusToolStripMenuItem.Name = "deleteBusToolStripMenuItem";
			this.deleteBusToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.deleteBusToolStripMenuItem.Text = "删除总线";
			this.deleteBusToolStripMenuItem.Click += new System.EventHandler(this.MenuItemDeleteDeviceClick);
			// 
			// contextMenuBusDevice
			// 
			this.contextMenuBusDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.AddRegsMenuItem,
									this.ImportRegsMenuItem,
									this.ExportRegsMenuItem,
									this.toolStripSeparator10,
									this.startBusDeviceMenuItem,
									this.stopBusDeviceMenuItem,
									this.deleteBusDeviceMenuItem});
			this.contextMenuBusDevice.Name = "contextMenuBusDevice";
			this.contextMenuBusDevice.Size = new System.Drawing.Size(161, 142);
			// 
			// AddRegsMenuItem
			// 
			this.AddRegsMenuItem.Name = "AddRegsMenuItem";
			this.AddRegsMenuItem.Size = new System.Drawing.Size(160, 22);
			this.AddRegsMenuItem.Text = "添加寄存器";
			this.AddRegsMenuItem.Click += new System.EventHandler(this.AddRegsMenuItemClick);
			// 
			// ImportRegsMenuItem
			// 
			this.ImportRegsMenuItem.Name = "ImportRegsMenuItem";
			this.ImportRegsMenuItem.Size = new System.Drawing.Size(160, 22);
			this.ImportRegsMenuItem.Text = "从文件导入配置";
			this.ImportRegsMenuItem.Click += new System.EventHandler(this.ImportRegsMenuItemClick);
			// 
			// ExportRegsMenuItem
			// 
			this.ExportRegsMenuItem.Name = "ExportRegsMenuItem";
			this.ExportRegsMenuItem.Size = new System.Drawing.Size(160, 22);
			this.ExportRegsMenuItem.Text = "导出配置到文件";
			this.ExportRegsMenuItem.Click += new System.EventHandler(this.ExportRegsMenuItemClick);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(157, 6);
			// 
			// startBusDeviceMenuItem
			// 
			this.startBusDeviceMenuItem.Name = "startBusDeviceMenuItem";
			this.startBusDeviceMenuItem.Size = new System.Drawing.Size(160, 22);
			this.startBusDeviceMenuItem.Text = "启动设备";
			this.startBusDeviceMenuItem.Click += new System.EventHandler(this.MenuItemStartDeviceClick);
			// 
			// stopBusDeviceMenuItem
			// 
			this.stopBusDeviceMenuItem.Name = "stopBusDeviceMenuItem";
			this.stopBusDeviceMenuItem.Size = new System.Drawing.Size(160, 22);
			this.stopBusDeviceMenuItem.Text = "停止设备";
			this.stopBusDeviceMenuItem.Click += new System.EventHandler(this.MenuItemStopDeviceClick);
			// 
			// deleteBusDeviceMenuItem
			// 
			this.deleteBusDeviceMenuItem.Name = "deleteBusDeviceMenuItem";
			this.deleteBusDeviceMenuItem.Size = new System.Drawing.Size(160, 22);
			this.deleteBusDeviceMenuItem.Text = "删除设备";
			this.deleteBusDeviceMenuItem.Click += new System.EventHandler(this.MenuItemDeleteDeviceClick);
			// 
			// contextMenuReg
			// 
			this.contextMenuReg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.editToolStripMenuItem,
									this.deleteToolStripMenuItem});
			this.contextMenuReg.Name = "contextMenuReg";
			this.contextMenuReg.Size = new System.Drawing.Size(101, 48);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.editToolStripMenuItem.Text = "编辑";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItemClick);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.deleteToolStripMenuItem.Text = "删除";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(915, 609);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuToolBar);
			this.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MainMenuStrip = this.menuToolBar;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "xDevice";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuToolBar.ResumeLayout(false);
			this.menuToolBar.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.contextMenuRule.ResumeLayout(false);
			this.contextMenuLog.ResumeLayout(false);
			this.contextMenuCommon.ResumeLayout(false);
			this.contextMenuCommonDevice.ResumeLayout(false);
			this.contextMenuBus.ResumeLayout(false);
			this.contextMenuBusDevice.ResumeLayout(false);
			this.contextMenuReg.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuReg;
		private System.Windows.Forms.ToolStripMenuItem SaveConfigtoolStripMenuItem;
		private System.Windows.Forms.ColumnHeader cHRegStep;
		private System.Windows.Forms.ColumnHeader cHRegHLimit;
		private System.Windows.Forms.ColumnHeader cHRegLLimit;
		private System.Windows.Forms.ColumnHeader cHRegMode;
		private System.Windows.Forms.ColumnHeader cHRegValue;
		private System.Windows.Forms.ColumnHeader cHRegAddr;
		private System.Windows.Forms.ColumnHeader cHRegName;
		private System.Windows.Forms.ColumnHeader cHDeviceParas;
		private System.Windows.Forms.ColumnHeader cHDeviceName;
		private System.Windows.Forms.ListView listViewDevice;
		private System.Windows.Forms.ListView listViewReg;
		private System.Windows.Forms.ToolStripMenuItem deleteBusDeviceMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem ExportRegsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ImportRegsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AddRegsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopBusDeviceMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startBusDeviceMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuBusDevice;
		private System.Windows.Forms.ToolStripMenuItem deleteBusToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem stopBusToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startBusToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addBusDeviceToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuBus;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem cRCCalcToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem MenuItemHexMode;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem virtualPortToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabelRunning;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabelPara;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabelDevice;
		private System.Windows.Forms.ToolStripMenuItem downRuleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem upRuleToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem deleteRuleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem editRuleToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuRule;
		private System.Windows.Forms.ToolStripMenuItem ImportConfigToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NewConfigToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader chDelay;
		private System.Windows.Forms.ColumnHeader chOutString;
		private System.Windows.Forms.ColumnHeader chInString;
		private System.Windows.Forms.ColumnHeader chHex;
		private System.Windows.Forms.ColumnHeader chMatchNext;
		private System.Windows.Forms.ColumnHeader chMatchOnce;
		private System.Windows.Forms.ColumnHeader chMatchHead;
		private System.Windows.Forms.ToolStripMenuItem MenuItemLogOnOff;
		private System.Windows.Forms.ToolStripMenuItem MenuItemExportLog;
		private System.Windows.Forms.ToolStripMenuItem MenuItemCleanLog;
		private System.Windows.Forms.ContextMenuStrip contextMenuLog;
		private System.Windows.Forms.ToolStripMenuItem MenuItemDeleteDevice;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem MenuItemExportRule;
		private System.Windows.Forms.ToolStripMenuItem MenuItemImportRules;
		private System.Windows.Forms.ToolStripMenuItem MenuItemAddRule;
		private System.Windows.Forms.ToolStripMenuItem MenuItemStopDevice;
		private System.Windows.Forms.ToolStripMenuItem MenuItemStartDevice;
		private System.Windows.Forms.ContextMenuStrip contextMenuCommonDevice;
		private System.Windows.Forms.ToolStripMenuItem MenuItemAddDevice;
		private System.Windows.Forms.ContextMenuStrip contextMenuCommon;
		private System.Windows.Forms.ColumnHeader chResult;
		private System.Windows.Forms.ColumnHeader chAction;
		private System.Windows.Forms.ColumnHeader chDevice;
		private System.Windows.Forms.ColumnHeader chTime;
		private System.Windows.Forms.ListView listViewLog;
		private System.Windows.Forms.ColumnHeader chEnable;
		private System.Windows.Forms.ColumnHeader chRuleName;
		private System.Windows.Forms.ListView listViewRule;
		private System.Windows.Forms.TreeView treeViewDevice;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuToolBar;
		private System.Windows.Forms.StatusStrip statusStrip1;		
		
	}
}

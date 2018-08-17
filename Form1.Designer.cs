namespace TarEmu3
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.table_panel = new System.Windows.Forms.TableLayoutPanel();
            this.main_menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistinginiFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertOldTarEmuiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oldTarEmuiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exeDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savedFilesDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniFilesDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sentPacketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRCErrors0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save_setup_bt = new System.Windows.Forms.ToolStripMenuItem();
            this.load_setup_bt = new System.Windows.Forms.ToolStripMenuItem();
            this.receivedDataFileNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aaaaaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_tool_strip = new System.Windows.Forms.ToolStrip();
            this.open_file_bt = new System.Windows.Forms.ToolStripButton();
            this.save_file_bt = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripSeparator();
            this.run_bt = new System.Windows.Forms.ToolStripButton();
            this.stop_bt = new System.Windows.Forms.ToolStripButton();
            this.step_bt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.wrtie_data_bt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.help_bt = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.trm_run_bt = new System.Windows.Forms.ToolStripButton();
            this.serial_port = new System.IO.Ports.SerialPort(this.components);
            this.open_file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.save_file_dialog = new System.Windows.Forms.SaveFileDialog();
            this.dir_searcher = new System.DirectoryServices.DirectorySearcher();
            this.dir_entry = new System.DirectoryServices.DirectoryEntry();
            this.rec_data_grid = new System.Windows.Forms.DataGridView();
            this.trm_data_grid = new System.Windows.Forms.DataGridView();
            this.port_check_timer = new System.Windows.Forms.Timer(this.components);
            this.editing_timer = new System.Windows.Forms.Timer(this.components);
            this.stat_timer = new System.Windows.Forms.Timer(this.components);
            this.autoTextWriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bintxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu.SuspendLayout();
            this.main_tool_strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rec_data_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trm_data_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // table_panel
            // 
            this.table_panel.AutoSize = true;
            this.table_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table_panel.BackColor = System.Drawing.SystemColors.Control;
            this.table_panel.ColumnCount = 2;
            this.table_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_panel.Location = new System.Drawing.Point(0, 52);
            this.table_panel.Name = "table_panel";
            this.table_panel.RowCount = 2;
            this.table_panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.table_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_panel.Size = new System.Drawing.Size(0, 0);
            this.table_panel.TabIndex = 0;
            // 
            // main_menu
            // 
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.runToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.main_menu.Location = new System.Drawing.Point(0, 0);
            this.main_menu.Name = "main_menu";
            this.main_menu.Size = new System.Drawing.Size(609, 24);
            this.main_menu.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.recentToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.recentToolStripMenuItem.Text = "&Recent";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentConfigToolStripMenuItem,
            this.editExistinginiFileToolStripMenuItem,
            this.convertOldTarEmuiniToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // currentConfigToolStripMenuItem
            // 
            this.currentConfigToolStripMenuItem.Name = "currentConfigToolStripMenuItem";
            this.currentConfigToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.currentConfigToolStripMenuItem.Text = "&Current .ini file";
            this.currentConfigToolStripMenuItem.Click += new System.EventHandler(this.CurrentConfigToolStripMenuItem_Click);
            // 
            // editExistinginiFileToolStripMenuItem
            // 
            this.editExistinginiFileToolStripMenuItem.Name = "editExistinginiFileToolStripMenuItem";
            this.editExistinginiFileToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.editExistinginiFileToolStripMenuItem.Text = "&Edit existing .ini file";
            this.editExistinginiFileToolStripMenuItem.Click += new System.EventHandler(this.EditExistinginiFileToolStripMenuItem_Click);
            // 
            // convertOldTarEmuiniToolStripMenuItem
            // 
            this.convertOldTarEmuiniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oldTarEmuiniToolStripMenuItem,
            this.bintxtToolStripMenuItem});
            this.convertOldTarEmuiniToolStripMenuItem.Name = "convertOldTarEmuiniToolStripMenuItem";
            this.convertOldTarEmuiniToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.convertOldTarEmuiniToolStripMenuItem.Text = "Conver&t";
            // 
            // oldTarEmuiniToolStripMenuItem
            // 
            this.oldTarEmuiniToolStripMenuItem.Name = "oldTarEmuiniToolStripMenuItem";
            this.oldTarEmuiniToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.oldTarEmuiniToolStripMenuItem.Text = "&Old TarEmu .ini";
            this.oldTarEmuiniToolStripMenuItem.Click += new System.EventHandler(this.OldTarEmuiniToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exeDirectoryToolStripMenuItem,
            this.savedFilesDirectoryToolStripMenuItem,
            this.iniFilesDirectoryToolStripMenuItem,
            this.viewStatisticsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // exeDirectoryToolStripMenuItem
            // 
            this.exeDirectoryToolStripMenuItem.Name = "exeDirectoryToolStripMenuItem";
            this.exeDirectoryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exeDirectoryToolStripMenuItem.Text = "&Program directory";
            this.exeDirectoryToolStripMenuItem.Click += new System.EventHandler(this.ExeDirectoryToolStripMenuItem_Click);
            // 
            // savedFilesDirectoryToolStripMenuItem
            // 
            this.savedFilesDirectoryToolStripMenuItem.Name = "savedFilesDirectoryToolStripMenuItem";
            this.savedFilesDirectoryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.savedFilesDirectoryToolStripMenuItem.Text = "&Saved files directory";
            this.savedFilesDirectoryToolStripMenuItem.Click += new System.EventHandler(this.SavedFilesDirectoryToolStripMenuItem_Click);
            // 
            // iniFilesDirectoryToolStripMenuItem
            // 
            this.iniFilesDirectoryToolStripMenuItem.Name = "iniFilesDirectoryToolStripMenuItem";
            this.iniFilesDirectoryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.iniFilesDirectoryToolStripMenuItem.Text = ".&Ini files directory";
            this.iniFilesDirectoryToolStripMenuItem.Click += new System.EventHandler(this.IniFilesDirectoryToolStripMenuItem_Click);
            // 
            // viewStatisticsToolStripMenuItem
            // 
            this.viewStatisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reToolStripMenuItem,
            this.sentPacketsToolStripMenuItem,
            this.cRCErrors0ToolStripMenuItem});
            this.viewStatisticsToolStripMenuItem.Name = "viewStatisticsToolStripMenuItem";
            this.viewStatisticsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.viewStatisticsToolStripMenuItem.Text = "S&tatistics";
            // 
            // reToolStripMenuItem
            // 
            this.reToolStripMenuItem.Name = "reToolStripMenuItem";
            this.reToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.reToolStripMenuItem.Text = "Received packets: 0";
            // 
            // sentPacketsToolStripMenuItem
            // 
            this.sentPacketsToolStripMenuItem.Name = "sentPacketsToolStripMenuItem";
            this.sentPacketsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.sentPacketsToolStripMenuItem.Text = "Sent packets: 0";
            // 
            // cRCErrors0ToolStripMenuItem
            // 
            this.cRCErrors0ToolStripMenuItem.Name = "cRCErrors0ToolStripMenuItem";
            this.cRCErrors0ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.cRCErrors0ToolStripMenuItem.Text = "CRC errors: 0";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem1,
            this.stepToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "&Run";
            // 
            // runToolStripMenuItem1
            // 
            this.runToolStripMenuItem1.Name = "runToolStripMenuItem1";
            this.runToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.runToolStripMenuItem1.Text = "&Run";
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stepToolStripMenuItem.Text = "&Step";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "S&top";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionOptionsToolStripMenuItem,
            this.setupDataFileToolStripMenuItem,
            this.receivedDataFileNameToolStripMenuItem,
            this.autoTextWriteToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // connectionOptionsToolStripMenuItem
            // 
            this.connectionOptionsToolStripMenuItem.Name = "connectionOptionsToolStripMenuItem";
            this.connectionOptionsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.connectionOptionsToolStripMenuItem.Text = "&Connection options";
            this.connectionOptionsToolStripMenuItem.Click += new System.EventHandler(this.ConnectionOptionsToolStripMenuItem_Click);
            // 
            // setupDataFileToolStripMenuItem
            // 
            this.setupDataFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save_setup_bt,
            this.load_setup_bt});
            this.setupDataFileToolStripMenuItem.Name = "setupDataFileToolStripMenuItem";
            this.setupDataFileToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.setupDataFileToolStripMenuItem.Text = "&Setup paths";
            // 
            // save_setup_bt
            // 
            this.save_setup_bt.Name = "save_setup_bt";
            this.save_setup_bt.Size = new System.Drawing.Size(100, 22);
            this.save_setup_bt.Text = "&Save";
            this.save_setup_bt.Click += new System.EventHandler(this.SaveToolStripMenuItem1_Click);
            // 
            // load_setup_bt
            // 
            this.load_setup_bt.Name = "load_setup_bt";
            this.load_setup_bt.Size = new System.Drawing.Size(100, 22);
            this.load_setup_bt.Text = "&Load";
            this.load_setup_bt.Click += new System.EventHandler(this.Load_setup_bt_Click);
            // 
            // receivedDataFileNameToolStripMenuItem
            // 
            this.receivedDataFileNameToolStripMenuItem.Name = "receivedDataFileNameToolStripMenuItem";
            this.receivedDataFileNameToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.receivedDataFileNameToolStripMenuItem.Text = "&Received data file name";
            this.receivedDataFileNameToolStripMenuItem.Click += new System.EventHandler(this.ReceivedDataFileNameToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pauseToolStripMenuItem.Text = "&Pause";
            // 
            // aaaaaaToolStripMenuItem
            // 
            this.aaaaaaToolStripMenuItem.Name = "aaaaaaToolStripMenuItem";
            this.aaaaaaToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // main_tool_strip
            // 
            this.main_tool_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_file_bt,
            this.save_file_bt,
            this.toolStripButton8,
            this.run_bt,
            this.stop_bt,
            this.step_bt,
            this.toolStripSeparator1,
            this.wrtie_data_bt,
            this.toolStripSeparator2,
            this.help_bt,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripLabel1,
            this.trm_run_bt});
            this.main_tool_strip.Location = new System.Drawing.Point(0, 24);
            this.main_tool_strip.Name = "main_tool_strip";
            this.main_tool_strip.Size = new System.Drawing.Size(609, 25);
            this.main_tool_strip.TabIndex = 2;
            // 
            // open_file_bt
            // 
            this.open_file_bt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.open_file_bt.Image = ((System.Drawing.Image)(resources.GetObject("open_file_bt.Image")));
            this.open_file_bt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open_file_bt.Name = "open_file_bt";
            this.open_file_bt.Size = new System.Drawing.Size(23, 22);
            this.open_file_bt.Text = "toolStripButton1";
            this.open_file_bt.ToolTipText = "Open .ini file";
            this.open_file_bt.Click += new System.EventHandler(this.Open_file_bt_Click);
            // 
            // save_file_bt
            // 
            this.save_file_bt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save_file_bt.Image = ((System.Drawing.Image)(resources.GetObject("save_file_bt.Image")));
            this.save_file_bt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_file_bt.Name = "save_file_bt";
            this.save_file_bt.Size = new System.Drawing.Size(23, 22);
            this.save_file_bt.Text = "toolStripButton2";
            this.save_file_bt.ToolTipText = "save";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(6, 25);
            // 
            // run_bt
            // 
            this.run_bt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.run_bt.Image = ((System.Drawing.Image)(resources.GetObject("run_bt.Image")));
            this.run_bt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.run_bt.Name = "run_bt";
            this.run_bt.Size = new System.Drawing.Size(23, 22);
            this.run_bt.Text = "toolStripButton3";
            this.run_bt.ToolTipText = "Run";
            this.run_bt.Click += new System.EventHandler(this.Run_bt_Click);
            // 
            // stop_bt
            // 
            this.stop_bt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stop_bt.Enabled = false;
            this.stop_bt.Image = ((System.Drawing.Image)(resources.GetObject("stop_bt.Image")));
            this.stop_bt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stop_bt.Name = "stop_bt";
            this.stop_bt.Size = new System.Drawing.Size(23, 22);
            this.stop_bt.Text = "toolStripButton4";
            this.stop_bt.ToolTipText = "Stop";
            this.stop_bt.Click += new System.EventHandler(this.Stop_bt_Click);
            // 
            // step_bt
            // 
            this.step_bt.CheckOnClick = true;
            this.step_bt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.step_bt.Enabled = false;
            this.step_bt.Image = ((System.Drawing.Image)(resources.GetObject("step_bt.Image")));
            this.step_bt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.step_bt.Name = "step_bt";
            this.step_bt.Size = new System.Drawing.Size(23, 22);
            this.step_bt.Text = "toolStripButton5";
            this.step_bt.ToolTipText = "Pause/continue";
            this.step_bt.Click += new System.EventHandler(this.Step_bt_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // wrtie_data_bt
            // 
            this.wrtie_data_bt.CheckOnClick = true;
            this.wrtie_data_bt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wrtie_data_bt.Image = ((System.Drawing.Image)(resources.GetObject("wrtie_data_bt.Image")));
            this.wrtie_data_bt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wrtie_data_bt.Name = "wrtie_data_bt";
            this.wrtie_data_bt.Size = new System.Drawing.Size(23, 22);
            this.wrtie_data_bt.Text = "toolStripButton6";
            this.wrtie_data_bt.ToolTipText = "Write data";
            this.wrtie_data_bt.Click += new System.EventHandler(this.Wrtie_data_bt_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // help_bt
            // 
            this.help_bt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.help_bt.Image = ((System.Drawing.Image)(resources.GetObject("help_bt.Image")));
            this.help_bt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.help_bt.Name = "help_bt";
            this.help_bt.Size = new System.Drawing.Size(23, 22);
            this.help_bt.Text = "toolStripButton7";
            this.help_bt.ToolTipText = "Help";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(97, 22);
            this.toolStripLabel1.Text = "Transmit buttons";
            // 
            // trm_run_bt
            // 
            this.trm_run_bt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.trm_run_bt.Image = ((System.Drawing.Image)(resources.GetObject("trm_run_bt.Image")));
            this.trm_run_bt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.trm_run_bt.Name = "trm_run_bt";
            this.trm_run_bt.Size = new System.Drawing.Size(23, 22);
            this.trm_run_bt.Text = "toolStripButton1";
            this.trm_run_bt.ToolTipText = "Send pack";
            this.trm_run_bt.Click += new System.EventHandler(this.Trm_run_bt_Click);
            // 
            // serial_port
            // 
            this.serial_port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Serial_port_DataReceived);
            // 
            // open_file_dialog
            // 
            this.open_file_dialog.FileName = "*.ini";
            // 
            // dir_searcher
            // 
            this.dir_searcher.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.dir_searcher.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.dir_searcher.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // rec_data_grid
            // 
            this.rec_data_grid.AllowUserToAddRows = false;
            this.rec_data_grid.AllowUserToDeleteRows = false;
            this.rec_data_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.rec_data_grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.rec_data_grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.rec_data_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rec_data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rec_data_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.rec_data_grid.Location = new System.Drawing.Point(0, 52);
            this.rec_data_grid.Name = "rec_data_grid";
            this.rec_data_grid.ReadOnly = true;
            this.rec_data_grid.Size = new System.Drawing.Size(249, 188);
            this.rec_data_grid.TabIndex = 3;
            // 
            // trm_data_grid
            // 
            this.trm_data_grid.AllowUserToAddRows = false;
            this.trm_data_grid.AllowUserToDeleteRows = false;
            this.trm_data_grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.trm_data_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trm_data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trm_data_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.trm_data_grid.Location = new System.Drawing.Point(255, 52);
            this.trm_data_grid.Name = "trm_data_grid";
            this.trm_data_grid.Size = new System.Drawing.Size(251, 188);
            this.trm_data_grid.TabIndex = 4;
            this.trm_data_grid.CurrentCellDirtyStateChanged += new System.EventHandler(this.Trm_data_grid_CurrentCellDirtyStateChanged);
            // 
            // port_check_timer
            // 
            this.port_check_timer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // editing_timer
            // 
            this.editing_timer.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // stat_timer
            // 
            this.stat_timer.Enabled = true;
            this.stat_timer.Interval = 500;
            this.stat_timer.Tick += new System.EventHandler(this.Stat_timer_Tick);
            // 
            // autoTextWriteToolStripMenuItem
            // 
            this.autoTextWriteToolStripMenuItem.CheckOnClick = true;
            this.autoTextWriteToolStripMenuItem.Name = "autoTextWriteToolStripMenuItem";
            this.autoTextWriteToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.autoTextWriteToolStripMenuItem.Text = "&Auto text write";
            // 
            // bintxtToolStripMenuItem
            // 
            this.bintxtToolStripMenuItem.Enabled = false;
            this.bintxtToolStripMenuItem.Name = "bintxtToolStripMenuItem";
            this.bintxtToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.bintxtToolStripMenuItem.Text = ".bin -> .txt";
            this.bintxtToolStripMenuItem.Click += new System.EventHandler(this.BintxtToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 523);
            this.Controls.Add(this.trm_data_grid);
            this.Controls.Add(this.rec_data_grid);
            this.Controls.Add(this.main_tool_strip);
            this.Controls.Add(this.table_panel);
            this.Controls.Add(this.main_menu);
            this.MainMenuStrip = this.main_menu;
            this.Name = "MainForm";
            this.Text = "Target Emulator";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.main_menu.ResumeLayout(false);
            this.main_menu.PerformLayout();
            this.main_tool_strip.ResumeLayout(false);
            this.main_tool_strip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rec_data_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trm_data_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table_panel;
        private System.Windows.Forms.MenuStrip main_menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aaaaaaToolStripMenuItem;
        private System.Windows.Forms.ToolStrip main_tool_strip;
        private System.Windows.Forms.ToolStripButton open_file_bt;
        private System.Windows.Forms.ToolStripButton save_file_bt;
        private System.Windows.Forms.ToolStripButton run_bt;
        private System.Windows.Forms.ToolStripButton stop_bt;
        private System.Windows.Forms.ToolStripButton step_bt;
        private System.Windows.Forms.ToolStripButton wrtie_data_bt;
        private System.Windows.Forms.ToolStripButton help_bt;
        private System.Windows.Forms.ToolStripSeparator toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.IO.Ports.SerialPort serial_port;
        private System.Windows.Forms.OpenFileDialog open_file_dialog;
        private System.Windows.Forms.ToolStripMenuItem setupDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save_setup_bt;
        private System.Windows.Forms.ToolStripMenuItem load_setup_bt;
        private System.Windows.Forms.SaveFileDialog save_file_dialog;
        private System.DirectoryServices.DirectorySearcher dir_searcher;
        private System.DirectoryServices.DirectoryEntry dir_entry;
        private System.Windows.Forms.ToolStripMenuItem exeDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savedFilesDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniFilesDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receivedDataFileNameToolStripMenuItem;
        private System.Windows.Forms.DataGridView rec_data_grid;
        private System.Windows.Forms.DataGridView trm_data_grid;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton trm_run_bt;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripButton2;
        private System.Windows.Forms.Timer port_check_timer;
        private System.Windows.Forms.ToolStripMenuItem viewStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistinginiFileToolStripMenuItem;
        private System.Windows.Forms.Timer editing_timer;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertOldTarEmuiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oldTarEmuiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sentPacketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cRCErrors0ToolStripMenuItem;
        private System.Windows.Forms.Timer stat_timer;
        private System.Windows.Forms.ToolStripMenuItem autoTextWriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bintxtToolStripMenuItem;
    }
}


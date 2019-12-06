namespace XM_Tek_Studio_Pro
{
    partial class Main_Form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.ms_sysmenu = new System.Windows.Forms.MenuStrip();
            this.FilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_DisplayScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tssr_displayScript = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_AutoSetFpga = new System.Windows.Forms.ToolStripMenuItem();
            this.tssr_autosetfpga = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_ManualSetFpag = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBFlashEditToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.uSBToEPPCommandEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oscilloscopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patternGenV12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sDCardControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileCompareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temperatureChamberToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceMeasureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PWMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GammaToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mIPILpSlewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_sysinfo = new System.Windows.Forms.ToolStrip();
            this.tsplbl_usb = new System.Windows.Forms.ToolStripLabel();
            this.txt_usb = new System.Windows.Forms.ToolStripTextBox();
            this.tsp_usb = new System.Windows.Forms.ToolStripSeparator();
            this.prgb_rate = new System.Windows.Forms.ToolStripProgressBar();
            this.tsp_modemsg = new System.Windows.Forms.ToolStripSeparator();
            this.tsplbl_fileinfo = new System.Windows.Forms.ToolStripLabel();
            this.tsplbl_sptname = new System.Windows.Forms.ToolStripLabel();
            this.tsp_rate = new System.Windows.Forms.ToolStripSeparator();
            this.tsplbl_modemsg = new System.Windows.Forms.ToolStripLabel();
            this.ts_syspage = new System.Windows.Forms.ToolStrip();
            this.TsBtn_Home = new System.Windows.Forms.ToolStripButton();
            this.TsBtn_ScriptPage = new System.Windows.Forms.ToolStripButton();
            this.TsBtn_AutoSetting = new System.Windows.Forms.ToolStripButton();
            this.TsBtn_CA210 = new System.Windows.Forms.ToolStripButton();
            this.TsBtn_RS232 = new System.Windows.Forms.ToolStripButton();
            this.treeView_SysInfo = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Pnl_Image = new System.Windows.Forms.Panel();
            this.TrvImages = new System.Windows.Forms.TreeView();
            this.Pnl_Bridge = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ms_sysmenu.SuspendLayout();
            this.ts_sysinfo.SuspendLayout();
            this.ts_syspage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Pnl_Image.SuspendLayout();
            this.Pnl_Bridge.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_sysmenu
            // 
            this.ms_sysmenu.Font = new System.Drawing.Font("Arial", 9F);
            this.ms_sysmenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ms_sysmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilesToolStripMenuItem,
            this.ProjectToolStripMenuItem,
            this.ToolToolStripMenuItem,
            this.ItemToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.ms_sysmenu.Location = new System.Drawing.Point(0, 0);
            this.ms_sysmenu.Name = "ms_sysmenu";
            this.ms_sysmenu.Size = new System.Drawing.Size(1262, 24);
            this.ms_sysmenu.TabIndex = 0;
            this.ms_sysmenu.Text = "menuStrip1";
            // 
            // FilesToolStripMenuItem
            // 
            this.FilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitEToolStripMenuItem});
            this.FilesToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F);
            this.FilesToolStripMenuItem.Name = "FilesToolStripMenuItem";
            this.FilesToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.FilesToolStripMenuItem.Text = "File";
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.about_us;
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.SaveAsToolStripMenuItem.Text = "About";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(102, 6);
            // 
            // exitEToolStripMenuItem
            // 
            this.exitEToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.exit_64x64;
            this.exitEToolStripMenuItem.Name = "exitEToolStripMenuItem";
            this.exitEToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.exitEToolStripMenuItem.Text = "Exit";
            this.exitEToolStripMenuItem.Click += new System.EventHandler(this.ExitEToolStripMenuItem_Click);
            // 
            // ProjectToolStripMenuItem
            // 
            this.ProjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_DisplayScript,
            this.tssr_displayScript,
            this.tsmi_AutoSetFpga,
            this.tssr_autosetfpga,
            this.tsmi_ManualSetFpag});
            this.ProjectToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F);
            this.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem";
            this.ProjectToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.ProjectToolStripMenuItem.Text = "Project";
            // 
            // tsmi_DisplayScript
            // 
            this.tsmi_DisplayScript.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Start;
            this.tsmi_DisplayScript.Name = "tsmi_DisplayScript";
            this.tsmi_DisplayScript.Size = new System.Drawing.Size(167, 22);
            this.tsmi_DisplayScript.Text = "Verification Page";
            this.tsmi_DisplayScript.Click += new System.EventHandler(this.Tsmi_DisplayScript_Click);
            // 
            // tssr_displayScript
            // 
            this.tssr_displayScript.Name = "tssr_displayScript";
            this.tssr_displayScript.Size = new System.Drawing.Size(164, 6);
            // 
            // tsmi_AutoSetFpga
            // 
            this.tsmi_AutoSetFpga.Image = global::XM_Tek_Studio_Pro.Properties.Resources.IfSet;
            this.tsmi_AutoSetFpga.Name = "tsmi_AutoSetFpga";
            this.tsmi_AutoSetFpga.Size = new System.Drawing.Size(167, 22);
            this.tsmi_AutoSetFpga.Text = "AutoSet Page";
            this.tsmi_AutoSetFpga.Click += new System.EventHandler(this.Tsmi_AutoSetFpga_Click);
            // 
            // tssr_autosetfpga
            // 
            this.tssr_autosetfpga.Name = "tssr_autosetfpga";
            this.tssr_autosetfpga.Size = new System.Drawing.Size(164, 6);
            // 
            // tsmi_ManualSetFpag
            // 
            this.tsmi_ManualSetFpag.Image = global::XM_Tek_Studio_Pro.Properties.Resources.settings;
            this.tsmi_ManualSetFpag.Name = "tsmi_ManualSetFpag";
            this.tsmi_ManualSetFpag.Size = new System.Drawing.Size(167, 22);
            this.tsmi_ManualSetFpag.Text = "Manual Set Page";
            this.tsmi_ManualSetFpag.Click += new System.EventHandler(this.Tsmi_ManualSetFpag_Click);
            // 
            // ToolToolStripMenuItem
            // 
            this.ToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSBFlashEditToolToolStripMenuItem,
            this.toolStripSeparator2,
            this.uSBToEPPCommandEditToolStripMenuItem,
            this.oscilloscopeToolStripMenuItem,
            this.patternGenV12ToolStripMenuItem,
            this.sDCardControlToolStripMenuItem,
            this.FileCompareToolStripMenuItem});
            this.ToolToolStripMenuItem.Name = "ToolToolStripMenuItem";
            this.ToolToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.ToolToolStripMenuItem.Text = "Tool";
            // 
            // uSBFlashEditToolToolStripMenuItem
            // 
            this.uSBFlashEditToolToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.flash;
            this.uSBFlashEditToolToolStripMenuItem.Name = "uSBFlashEditToolToolStripMenuItem";
            this.uSBFlashEditToolToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.uSBFlashEditToolToolStripMenuItem.Text = "USB Flash Edit Tool";
            this.uSBFlashEditToolToolStripMenuItem.Click += new System.EventHandler(this.USBFlashEditToolToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(226, 6);
            // 
            // uSBToEPPCommandEditToolStripMenuItem
            // 
            this.uSBToEPPCommandEditToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.USB_Icon;
            this.uSBToEPPCommandEditToolStripMenuItem.Name = "uSBToEPPCommandEditToolStripMenuItem";
            this.uSBToEPPCommandEditToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.uSBToEPPCommandEditToolStripMenuItem.Text = "USB to EPP Command Edit";
            this.uSBToEPPCommandEditToolStripMenuItem.Click += new System.EventHandler(this.USBToEPPCommandEditToolStripMenuItem_Click);
            // 
            // oscilloscopeToolStripMenuItem
            // 
            this.oscilloscopeToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.oscilloscope1;
            this.oscilloscopeToolStripMenuItem.Name = "oscilloscopeToolStripMenuItem";
            this.oscilloscopeToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.oscilloscopeToolStripMenuItem.Text = "Oscilloscope";
            this.oscilloscopeToolStripMenuItem.Click += new System.EventHandler(this.OscilloscopeToolStripMenuItem_Click);
            // 
            // patternGenV12ToolStripMenuItem
            // 
            this.patternGenV12ToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Pattern;
            this.patternGenV12ToolStripMenuItem.Name = "patternGenV12ToolStripMenuItem";
            this.patternGenV12ToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.patternGenV12ToolStripMenuItem.Text = "Pattern_Gen_V13";
            this.patternGenV12ToolStripMenuItem.Click += new System.EventHandler(this.PatternGenV12ToolStripMenuItem_Click);
            // 
            // sDCardControlToolStripMenuItem
            // 
            this.sDCardControlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sDCardControlToolStripMenuItem.Image")));
            this.sDCardControlToolStripMenuItem.Name = "sDCardControlToolStripMenuItem";
            this.sDCardControlToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.sDCardControlToolStripMenuItem.Text = "SD Card Control";
            this.sDCardControlToolStripMenuItem.Click += new System.EventHandler(this.SDCardControlToolStripMenuItem_Click);
            // 
            // FileCompareToolStripMenuItem
            // 
            this.FileCompareToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Save_48x48;
            this.FileCompareToolStripMenuItem.Name = "FileCompareToolStripMenuItem";
            this.FileCompareToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.FileCompareToolStripMenuItem.Text = "File Compare";
            this.FileCompareToolStripMenuItem.Click += new System.EventHandler(this.FileCompareToolStripMenuItem_Click);
            // 
            // ItemToolStripMenuItem
            // 
            this.ItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temperatureChamberToolStripMenuItem1,
            this.sourceMeasureToolStripMenuItem,
            this.PWMToolStripMenuItem,
            this.GammaToolToolStripMenuItem,
            this.mIPILpSlewToolStripMenuItem});
            this.ItemToolStripMenuItem.Name = "ItemToolStripMenuItem";
            this.ItemToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.ItemToolStripMenuItem.Text = "Item";
            // 
            // temperatureChamberToolStripMenuItem1
            // 
            this.temperatureChamberToolStripMenuItem1.Image = global::XM_Tek_Studio_Pro.Properties.Resources.temp;
            this.temperatureChamberToolStripMenuItem1.Name = "temperatureChamberToolStripMenuItem1";
            this.temperatureChamberToolStripMenuItem1.Size = new System.Drawing.Size(203, 26);
            this.temperatureChamberToolStripMenuItem1.Text = "Temperature Chamber";
            this.temperatureChamberToolStripMenuItem1.Click += new System.EventHandler(this.TemperatureChamberToolStripMenuItem1_Click);
            // 
            // sourceMeasureToolStripMenuItem
            // 
            this.sourceMeasureToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.source;
            this.sourceMeasureToolStripMenuItem.Name = "sourceMeasureToolStripMenuItem";
            this.sourceMeasureToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.sourceMeasureToolStripMenuItem.Text = "Source Measure";
            this.sourceMeasureToolStripMenuItem.Click += new System.EventHandler(this.SourceMeasureToolStripMenuItem_Click);
            // 
            // PWMToolStripMenuItem
            // 
            this.PWMToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.PWM_Icon;
            this.PWMToolStripMenuItem.Name = "PWMToolStripMenuItem";
            this.PWMToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.PWMToolStripMenuItem.Text = "PWM Measure";
            this.PWMToolStripMenuItem.Click += new System.EventHandler(this.PWMToolStripMenuItem_Click);
            // 
            // GammaToolToolStripMenuItem
            // 
            this.GammaToolToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.ciexyz;
            this.GammaToolToolStripMenuItem.Name = "GammaToolToolStripMenuItem";
            this.GammaToolToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.GammaToolToolStripMenuItem.Text = "Gamma Tool";
            this.GammaToolToolStripMenuItem.Click += new System.EventHandler(this.GammaToolToolStripMenuItem_Click_1);
            // 
            // mIPILpSlewToolStripMenuItem
            // 
            this.mIPILpSlewToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.slew_icon;
            this.mIPILpSlewToolStripMenuItem.Name = "mIPILpSlewToolStripMenuItem";
            this.mIPILpSlewToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.mIPILpSlewToolStripMenuItem.Text = "MIPI LP SR Test";
            this.mIPILpSlewToolStripMenuItem.Click += new System.EventHandler(this.MIPILpSlewToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptCommandToolStripMenuItem,
            this.commandToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // scriptCommandToolStripMenuItem
            // 
            this.scriptCommandToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Question;
            this.scriptCommandToolStripMenuItem.Name = "scriptCommandToolStripMenuItem";
            this.scriptCommandToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.scriptCommandToolStripMenuItem.Text = "Script Command";
            this.scriptCommandToolStripMenuItem.Click += new System.EventHandler(this.ScriptCommandToolStripMenuItem_Click);
            // 
            // commandToolStripMenuItem
            // 
            this.commandToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Question;
            this.commandToolStripMenuItem.Name = "commandToolStripMenuItem";
            this.commandToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.commandToolStripMenuItem.Text = "INRUSH_CURRENT_RIPPLE_RELAY_BOARD";
            this.commandToolStripMenuItem.Click += new System.EventHandler(this.CommandToolStripMenuItem_Click);
            // 
            // ts_sysinfo
            // 
            this.ts_sysinfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_sysinfo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_sysinfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts_sysinfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsplbl_usb,
            this.txt_usb,
            this.tsp_usb,
            this.prgb_rate,
            this.tsp_modemsg,
            this.tsplbl_fileinfo,
            this.tsplbl_sptname,
            this.tsp_rate,
            this.tsplbl_modemsg});
            this.ts_sysinfo.Location = new System.Drawing.Point(0, 619);
            this.ts_sysinfo.Name = "ts_sysinfo";
            this.ts_sysinfo.Size = new System.Drawing.Size(1262, 25);
            this.ts_sysinfo.TabIndex = 1;
            this.ts_sysinfo.Text = "toolStrip1";
            // 
            // tsplbl_usb
            // 
            this.tsplbl_usb.Name = "tsplbl_usb";
            this.tsplbl_usb.Size = new System.Drawing.Size(74, 22);
            this.tsplbl_usb.Text = "USB Status : ";
            // 
            // txt_usb
            // 
            this.txt_usb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_usb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_usb.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_usb.Name = "txt_usb";
            this.txt_usb.Size = new System.Drawing.Size(200, 25);
            // 
            // tsp_usb
            // 
            this.tsp_usb.Name = "tsp_usb";
            this.tsp_usb.Size = new System.Drawing.Size(6, 25);
            // 
            // prgb_rate
            // 
            this.prgb_rate.Name = "prgb_rate";
            this.prgb_rate.Size = new System.Drawing.Size(300, 22);
            // 
            // tsp_modemsg
            // 
            this.tsp_modemsg.Name = "tsp_modemsg";
            this.tsp_modemsg.Size = new System.Drawing.Size(6, 25);
            // 
            // tsplbl_fileinfo
            // 
            this.tsplbl_fileinfo.Name = "tsplbl_fileinfo";
            this.tsplbl_fileinfo.Size = new System.Drawing.Size(0, 22);
            // 
            // tsplbl_sptname
            // 
            this.tsplbl_sptname.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsplbl_sptname.Name = "tsplbl_sptname";
            this.tsplbl_sptname.Size = new System.Drawing.Size(0, 22);
            // 
            // tsp_rate
            // 
            this.tsp_rate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsp_rate.Name = "tsp_rate";
            this.tsp_rate.Size = new System.Drawing.Size(6, 25);
            // 
            // tsplbl_modemsg
            // 
            this.tsplbl_modemsg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsplbl_modemsg.Name = "tsplbl_modemsg";
            this.tsplbl_modemsg.Size = new System.Drawing.Size(0, 22);
            // 
            // ts_syspage
            // 
            this.ts_syspage.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_syspage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts_syspage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsBtn_Home,
            this.TsBtn_ScriptPage,
            this.TsBtn_AutoSetting,
            this.TsBtn_CA210,
            this.TsBtn_RS232});
            this.ts_syspage.Location = new System.Drawing.Point(0, 24);
            this.ts_syspage.Name = "ts_syspage";
            this.ts_syspage.Size = new System.Drawing.Size(1262, 27);
            this.ts_syspage.TabIndex = 2;
            this.ts_syspage.Text = "toolStrip2";
            // 
            // TsBtn_Home
            // 
            this.TsBtn_Home.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsBtn_Home.Image = global::XM_Tek_Studio_Pro.Properties.Resources.home;
            this.TsBtn_Home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtn_Home.Name = "TsBtn_Home";
            this.TsBtn_Home.Size = new System.Drawing.Size(24, 24);
            this.TsBtn_Home.Text = "Home";
            this.TsBtn_Home.Click += new System.EventHandler(this.ToolStripBtn_Home_Click);
            // 
            // TsBtn_ScriptPage
            // 
            this.TsBtn_ScriptPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsBtn_ScriptPage.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Start;
            this.TsBtn_ScriptPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtn_ScriptPage.Name = "TsBtn_ScriptPage";
            this.TsBtn_ScriptPage.Size = new System.Drawing.Size(24, 24);
            this.TsBtn_ScriptPage.Text = "toolStripBtn_ScriptPage";
            this.TsBtn_ScriptPage.ToolTipText = "Script Setting";
            this.TsBtn_ScriptPage.Click += new System.EventHandler(this.TsBtn_ScriptPage_Click);
            // 
            // TsBtn_AutoSetting
            // 
            this.TsBtn_AutoSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsBtn_AutoSetting.Image = global::XM_Tek_Studio_Pro.Properties.Resources.IfSet;
            this.TsBtn_AutoSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtn_AutoSetting.Name = "TsBtn_AutoSetting";
            this.TsBtn_AutoSetting.Size = new System.Drawing.Size(24, 24);
            this.TsBtn_AutoSetting.Text = "toolStripBtn_AutoSetting";
            this.TsBtn_AutoSetting.ToolTipText = "FPAG Auto Setting";
            this.TsBtn_AutoSetting.Click += new System.EventHandler(this.ToolStripBtn_DisplaySet_Click);
            // 
            // TsBtn_CA210
            // 
            this.TsBtn_CA210.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TsBtn_CA210.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsBtn_CA210.Image = ((System.Drawing.Image)(resources.GetObject("TsBtn_CA210.Image")));
            this.TsBtn_CA210.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TsBtn_CA210.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtn_CA210.Name = "TsBtn_CA210";
            this.TsBtn_CA210.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TsBtn_CA210.Size = new System.Drawing.Size(24, 24);
            this.TsBtn_CA210.Text = "Connect  CA210";
            this.TsBtn_CA210.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TsBtn_CA210.Click += new System.EventHandler(this.TsBtn_CA210_Click);
            // 
            // TsBtn_RS232
            // 
            this.TsBtn_RS232.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TsBtn_RS232.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsBtn_RS232.Image = global::XM_Tek_Studio_Pro.Properties.Resources.RS232;
            this.TsBtn_RS232.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsBtn_RS232.Name = "TsBtn_RS232";
            this.TsBtn_RS232.Size = new System.Drawing.Size(24, 24);
            this.TsBtn_RS232.Text = "Connect Comm Device";
            this.TsBtn_RS232.Click += new System.EventHandler(this.TsBtn_RS232_Click);
            // 
            // treeView_SysInfo
            // 
            this.treeView_SysInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView_SysInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_SysInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView_SysInfo.Location = new System.Drawing.Point(0, 0);
            this.treeView_SysInfo.Name = "treeView_SysInfo";
            this.treeView_SysInfo.Size = new System.Drawing.Size(217, 148);
            this.treeView_SysInfo.TabIndex = 3;
            this.treeView_SysInfo.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_SysInfo_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Pnl_Image);
            this.panel1.Controls.Add(this.Pnl_Bridge);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 568);
            this.panel1.TabIndex = 5;
            // 
            // Pnl_Image
            // 
            this.Pnl_Image.BackColor = System.Drawing.Color.White;
            this.Pnl_Image.Controls.Add(this.TrvImages);
            this.Pnl_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_Image.ForeColor = System.Drawing.Color.White;
            this.Pnl_Image.Location = new System.Drawing.Point(0, 148);
            this.Pnl_Image.Name = "Pnl_Image";
            this.Pnl_Image.Size = new System.Drawing.Size(217, 420);
            this.Pnl_Image.TabIndex = 5;
            // 
            // TrvImages
            // 
            this.TrvImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrvImages.Location = new System.Drawing.Point(0, 0);
            this.TrvImages.Name = "TrvImages";
            this.TrvImages.Size = new System.Drawing.Size(217, 420);
            this.TrvImages.TabIndex = 0;
            this.TrvImages.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.TrvImages_NodeMouseHover);
            this.TrvImages.DoubleClick += new System.EventHandler(this.Trv_Images_DoubleClick);
            this.TrvImages.MouseLeave += new System.EventHandler(this.TrvImages_MouseLeave);
            // 
            // Pnl_Bridge
            // 
            this.Pnl_Bridge.BackColor = System.Drawing.Color.White;
            this.Pnl_Bridge.Controls.Add(this.treeView_SysInfo);
            this.Pnl_Bridge.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Bridge.ForeColor = System.Drawing.Color.White;
            this.Pnl_Bridge.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Bridge.Name = "Pnl_Bridge";
            this.Pnl_Bridge.Size = new System.Drawing.Size(217, 148);
            this.Pnl_Bridge.TabIndex = 4;
            // 
            // toolTip1
            // 
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 644);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ts_syspage);
            this.Controls.Add(this.ts_sysinfo);
            this.Controls.Add(this.ms_sysmenu);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ms_sysmenu;
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XM-Plus Display Studio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_Form_FormClosed);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.ms_sysmenu.ResumeLayout(false);
            this.ms_sysmenu.PerformLayout();
            this.ts_sysinfo.ResumeLayout(false);
            this.ts_sysinfo.PerformLayout();
            this.ts_syspage.ResumeLayout(false);
            this.ts_syspage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Pnl_Image.ResumeLayout(false);
            this.Pnl_Bridge.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms_sysmenu;
        private System.Windows.Forms.ToolStripMenuItem FilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitEToolStripMenuItem;
        private System.Windows.Forms.ToolStrip ts_sysinfo;
        private System.Windows.Forms.ToolStripLabel tsplbl_usb;
        private System.Windows.Forms.ToolStripTextBox txt_usb;
        private System.Windows.Forms.ToolStripMenuItem uSBFlashEditToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem uSBToEPPCommandEditToolStripMenuItem;
        private System.Windows.Forms.ToolStrip ts_syspage;
        private System.Windows.Forms.TreeView treeView_SysInfo;
        private System.Windows.Forms.ToolStripButton TsBtn_ScriptPage;
        private System.Windows.Forms.ToolStripButton TsBtn_AutoSetting;
        private System.Windows.Forms.ToolStripButton TsBtn_Home;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DisplayScript;
        private System.Windows.Forms.ToolStripSeparator tssr_displayScript;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AutoSetFpga;
        private System.Windows.Forms.ToolStripSeparator tssr_autosetfpga;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ManualSetFpag;
        private System.Windows.Forms.ToolStripSeparator tsp_usb;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patternGenV12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oscilloscopeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temperatureChamberToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sourceMeasureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PWMToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel tsplbl_sptname;
        private System.Windows.Forms.ToolStripSeparator tsp_rate;
        private System.Windows.Forms.ToolStripProgressBar prgb_rate;
        private System.Windows.Forms.ToolStripLabel tsplbl_modemsg;
        private System.Windows.Forms.ToolStripSeparator tsp_modemsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Pnl_Image;
        private System.Windows.Forms.Panel Pnl_Bridge;
        private System.Windows.Forms.TreeView TrvImages;
        private System.Windows.Forms.ToolStripButton TsBtn_CA210;
        private System.Windows.Forms.ToolStripButton TsBtn_RS232;
        private System.Windows.Forms.ToolStripMenuItem commandToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel tsplbl_fileinfo;
        private System.Windows.Forms.ToolStripMenuItem GammaToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sDCardControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mIPILpSlewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileCompareToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


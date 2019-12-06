namespace SC_Tek_Studio_Pro
{
    partial class DisplaySetting_Form
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1.Interface");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2.CPU");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("3.1 RGB Timing");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("3.2 RGB Interface");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("3.RGB", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("4.MIPI");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("5.SPI");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("6.I2C");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Interface", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplaySetting_Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabCtrlConfig = new System.Windows.Forms.TabControl();
            this.tabPg_Interface = new System.Windows.Forms.TabPage();
            this.gbx_InitConfig = new System.Windows.Forms.GroupBox();
            this.btn_setDefault = new System.Windows.Forms.Button();
            this.btn_loadConfig = new System.Windows.Forms.Button();
            this.lbl_defaultConfig = new System.Windows.Forms.Label();
            this.lbl_loadConfig = new System.Windows.Forms.Label();
            this.gbx_FpgaSetting = new System.Windows.Forms.GroupBox();
            this.lbl_FpgaSysClk = new System.Windows.Forms.Label();
            this.txt_sysClk = new System.Windows.Forms.TextBox();
            this.lbl_sysClk = new System.Windows.Forms.Label();
            this.cbo_fpgaInterface = new System.Windows.Forms.ComboBox();
            this.lbl_interface = new System.Windows.Forms.Label();
            this.tabPg_CPU = new System.Windows.Forms.TabPage();
            this.gbx_busDef = new System.Windows.Forms.GroupBox();
            this.pic_DataBusDef = new System.Windows.Forms.PictureBox();
            this.rbtn_18bitD17D0 = new System.Windows.Forms.RadioButton();
            this.rbtn_18bitD23D0 = new System.Windows.Forms.RadioButton();
            this.rbtn_9bitD17D9 = new System.Windows.Forms.RadioButton();
            this.rbtn_16bitD15D0 = new System.Windows.Forms.RadioButton();
            this.rbtn_17bitD17D10 = new System.Windows.Forms.RadioButton();
            this.rbtn_9bitD8D0 = new System.Windows.Forms.RadioButton();
            this.rbtn_8bitD17D10 = new System.Windows.Forms.RadioButton();
            this.rbtn_8BitD7D0 = new System.Windows.Forms.RadioButton();
            this.gbx_CpuModeSel = new System.Windows.Forms.GroupBox();
            this.rbtn_m68 = new System.Windows.Forms.RadioButton();
            this.rbtn_I80 = new System.Windows.Forms.RadioButton();
            this.tabPg_RgbTiming = new System.Windows.Forms.TabPage();
            this.gbx_ShwTimeSet = new System.Windows.Forms.GroupBox();
            this.lbl_HfpVal = new System.Windows.Forms.Label();
            this.lbl_HactiveVal = new System.Windows.Forms.Label();
            this.lbl_HbpVal = new System.Windows.Forms.Label();
            this.lbl_HsyncVal = new System.Windows.Forms.Label();
            this.lbl_VfpVal = new System.Windows.Forms.Label();
            this.lbl_VactiveVal = new System.Windows.Forms.Label();
            this.lbl_VbpVal = new System.Windows.Forms.Label();
            this.lbl_VsyncVal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_PixelClkVal = new System.Windows.Forms.Label();
            this.lbl_ScanRateVal = new System.Windows.Forms.Label();
            this.lbl_fpRateVal = new System.Windows.Forms.Label();
            this.gbx_polarity = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pic_De = new System.Windows.Forms.PictureBox();
            this.pic_Vsync = new System.Windows.Forms.PictureBox();
            this.pic_Hsync = new System.Windows.Forms.PictureBox();
            this.pic_Pclk = new System.Windows.Forms.PictureBox();
            this.gbx_timeset = new System.Windows.Forms.GroupBox();
            this.lbl_pixelCkMhz = new System.Windows.Forms.Label();
            this.txt_PixelClk = new System.Windows.Forms.TextBox();
            this.lbl_PixelClk = new System.Windows.Forms.Label();
            this.lbl_extClk = new System.Windows.Forms.Label();
            this.txt_Vtotal = new System.Windows.Forms.TextBox();
            this.txt_Vfp = new System.Windows.Forms.TextBox();
            this.txt_Vactive = new System.Windows.Forms.TextBox();
            this.txt_Vbp = new System.Windows.Forms.TextBox();
            this.txt_Vsync = new System.Windows.Forms.TextBox();
            this.lbl_vtotalPixel = new System.Windows.Forms.Label();
            this.lbl_vfpPixel = new System.Windows.Forms.Label();
            this.lbl_vactivePixel = new System.Windows.Forms.Label();
            this.lbl_vbpPixel = new System.Windows.Forms.Label();
            this.lbl_vsyncPixel = new System.Windows.Forms.Label();
            this.lbl_shwVtotal = new System.Windows.Forms.Label();
            this.lbl_shwVfp = new System.Windows.Forms.Label();
            this.lbl_shwVactive = new System.Windows.Forms.Label();
            this.lbl_shwVbp = new System.Windows.Forms.Label();
            this.lbl_showVsync = new System.Windows.Forms.Label();
            this.lbl_verTiming = new System.Windows.Forms.Label();
            this.txt_Htotal = new System.Windows.Forms.TextBox();
            this.txt_Hfp = new System.Windows.Forms.TextBox();
            this.txt_Hactive = new System.Windows.Forms.TextBox();
            this.txt_Hbp = new System.Windows.Forms.TextBox();
            this.txt_Hsync = new System.Windows.Forms.TextBox();
            this.lbl_htotalPixel = new System.Windows.Forms.Label();
            this.lbl_hfpPixel = new System.Windows.Forms.Label();
            this.lbl_hactivePixel = new System.Windows.Forms.Label();
            this.lbl_hbpPixel = new System.Windows.Forms.Label();
            this.lbl_hsyncPixel = new System.Windows.Forms.Label();
            this.lbl_shwHtotal = new System.Windows.Forms.Label();
            this.lbl_shwHfp = new System.Windows.Forms.Label();
            this.lbl_shwHactive = new System.Windows.Forms.Label();
            this.lbl_shwHbp = new System.Windows.Forms.Label();
            this.lbl_shwHsycn = new System.Windows.Forms.Label();
            this.lbl_hortiming = new System.Windows.Forms.Label();
            this.tabPg_RgbInterface = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.pic_showDataBus = new System.Windows.Forms.PictureBox();
            this.gbx_dataBusType = new System.Windows.Forms.GroupBox();
            this.rbtn_24bitD23 = new System.Windows.Forms.RadioButton();
            this.rbtn_18bitD21 = new System.Windows.Forms.RadioButton();
            this.rbtn_18bitD17 = new System.Windows.Forms.RadioButton();
            this.rbtn_16bitD21 = new System.Windows.Forms.RadioButton();
            this.rbtn_16bitD17 = new System.Windows.Forms.RadioButton();
            this.rbtn_16bitD15 = new System.Windows.Forms.RadioButton();
            this.rbtn_8bit = new System.Windows.Forms.RadioButton();
            this.rbtn_6bit = new System.Windows.Forms.RadioButton();
            this.gbx_rgbInterface = new System.Windows.Forms.GroupBox();
            this.rbtn_DeMod = new System.Windows.Forms.RadioButton();
            this.rbtn_HsVsMod = new System.Windows.Forms.RadioButton();
            this.rbtn_HsVsDeMod = new System.Windows.Forms.RadioButton();
            this.tabPg_Mipi = new System.Windows.Forms.TabPage();
            this.tabPg_SPI = new System.Windows.Forms.TabPage();
            this.gbx_SpiRdFunc = new System.Windows.Forms.GroupBox();
            this.rbtn_SpiRdW = new System.Windows.Forms.RadioButton();
            this.rbtn_SpiRdWandO = new System.Windows.Forms.RadioButton();
            this.pic_showSpi = new System.Windows.Forms.PictureBox();
            this.gbx_SpiSpeed = new System.Windows.Forms.GroupBox();
            this.lbl_shwSckH = new System.Windows.Forms.Label();
            this.lbl_shwSckL = new System.Windows.Forms.Label();
            this.lbl_SckMhz = new System.Windows.Forms.Label();
            this.lbl_SckFreqVal = new System.Windows.Forms.Label();
            this.lbl_shwSckFreq = new System.Windows.Forms.Label();
            this.lbl_shwSck = new System.Windows.Forms.Label();
            this.lbl_shwSysClk = new System.Windows.Forms.Label();
            this.lbl_shwSysClkMhz = new System.Windows.Forms.Label();
            this.lbl_shwSpiSysClk = new System.Windows.Forms.Label();
            this.lbl_spiSysClk = new System.Windows.Forms.Label();
            this.txt_SpiSysClk = new System.Windows.Forms.TextBox();
            this.txt_SpiSckH = new System.Windows.Forms.TextBox();
            this.txt_SpiSckL = new System.Windows.Forms.TextBox();
            this.lbl_shwSysClkVal = new System.Windows.Forms.Label();
            this.lbl_shwSckHVal = new System.Windows.Forms.Label();
            this.lbl_shwScklVal = new System.Windows.Forms.Label();
            this.pic_setSpiSpeed = new System.Windows.Forms.PictureBox();
            this.gbx_SpiType = new System.Windows.Forms.GroupBox();
            this.pic_showSpiType = new System.Windows.Forms.PictureBox();
            this.rbtn_spi3wire = new System.Windows.Forms.RadioButton();
            this.rbtn_spi4wire = new System.Windows.Forms.RadioButton();
            this.tabPg_I2C = new System.Windows.Forms.TabPage();
            this.gbx_setI2CTiming = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pic_i2cSetGraph = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_i2csckL = new System.Windows.Forms.Label();
            this.lbl_i2csckH = new System.Windows.Forms.Label();
            this.lbl_seti2Mhz = new System.Windows.Forms.Label();
            this.lbl_shwI2cFreqVal = new System.Windows.Forms.Label();
            this.lbl_shwi2cSckFreq = new System.Windows.Forms.Label();
            this.lbl_shwI2CSck = new System.Windows.Forms.Label();
            this.lbl_shwi2cSysClk = new System.Windows.Forms.Label();
            this.pic_setI2cTiming = new System.Windows.Forms.PictureBox();
            this.lbl_shwi2cMhz = new System.Windows.Forms.Label();
            this.lbl_shwdivideClk = new System.Windows.Forms.Label();
            this.lbl_i2cTimeSysClk = new System.Windows.Forms.Label();
            this.txt_i2cSysClk = new System.Windows.Forms.TextBox();
            this.txt_i2cSckH = new System.Windows.Forms.TextBox();
            this.txt_i2cSckL = new System.Windows.Forms.TextBox();
            this.lbl_i2cshowSysClk = new System.Windows.Forms.Label();
            this.lbl_shwi2cSckH = new System.Windows.Forms.Label();
            this.lbl_shwi2cSckL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.tvw_SysConfig = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.tabCtrlConfig.SuspendLayout();
            this.tabPg_Interface.SuspendLayout();
            this.gbx_InitConfig.SuspendLayout();
            this.gbx_FpgaSetting.SuspendLayout();
            this.tabPg_CPU.SuspendLayout();
            this.gbx_busDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DataBusDef)).BeginInit();
            this.gbx_CpuModeSel.SuspendLayout();
            this.tabPg_RgbTiming.SuspendLayout();
            this.gbx_ShwTimeSet.SuspendLayout();
            this.gbx_polarity.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_De)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Vsync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Hsync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Pclk)).BeginInit();
            this.gbx_timeset.SuspendLayout();
            this.tabPg_RgbInterface.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_showDataBus)).BeginInit();
            this.gbx_dataBusType.SuspendLayout();
            this.gbx_rgbInterface.SuspendLayout();
            this.tabPg_SPI.SuspendLayout();
            this.gbx_SpiRdFunc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_showSpi)).BeginInit();
            this.gbx_SpiSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_setSpiSpeed)).BeginInit();
            this.gbx_SpiType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_showSpiType)).BeginInit();
            this.tabPg_I2C.SuspendLayout();
            this.gbx_setI2CTiming.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_i2cSetGraph)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_setI2cTiming)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabCtrlConfig);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.tvw_SysConfig);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(945, 632);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // tabCtrlConfig
            // 
            this.tabCtrlConfig.Controls.Add(this.tabPg_Interface);
            this.tabCtrlConfig.Controls.Add(this.tabPg_CPU);
            this.tabCtrlConfig.Controls.Add(this.tabPg_RgbTiming);
            this.tabCtrlConfig.Controls.Add(this.tabPg_RgbInterface);
            this.tabCtrlConfig.Controls.Add(this.tabPg_Mipi);
            this.tabCtrlConfig.Controls.Add(this.tabPg_SPI);
            this.tabCtrlConfig.Controls.Add(this.tabPg_I2C);
            this.tabCtrlConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlConfig.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlConfig.Location = new System.Drawing.Point(227, 20);
            this.tabCtrlConfig.Name = "tabCtrlConfig";
            this.tabCtrlConfig.SelectedIndex = 0;
            this.tabCtrlConfig.Size = new System.Drawing.Size(715, 542);
            this.tabCtrlConfig.TabIndex = 2;
            this.tabCtrlConfig.SelectedIndexChanged += new System.EventHandler(this.tabCtrlConfig_SelectedIndexChanged);
            // 
            // tabPg_Interface
            // 
            this.tabPg_Interface.Controls.Add(this.gbx_InitConfig);
            this.tabPg_Interface.Controls.Add(this.gbx_FpgaSetting);
            this.tabPg_Interface.Location = new System.Drawing.Point(4, 23);
            this.tabPg_Interface.Name = "tabPg_Interface";
            this.tabPg_Interface.Padding = new System.Windows.Forms.Padding(3);
            this.tabPg_Interface.Size = new System.Drawing.Size(707, 515);
            this.tabPg_Interface.TabIndex = 0;
            this.tabPg_Interface.Text = "Interface";
            this.tabPg_Interface.UseVisualStyleBackColor = true;
            // 
            // gbx_InitConfig
            // 
            this.gbx_InitConfig.Controls.Add(this.btn_setDefault);
            this.gbx_InitConfig.Controls.Add(this.btn_loadConfig);
            this.gbx_InitConfig.Controls.Add(this.lbl_defaultConfig);
            this.gbx_InitConfig.Controls.Add(this.lbl_loadConfig);
            this.gbx_InitConfig.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_InitConfig.Location = new System.Drawing.Point(35, 32);
            this.gbx_InitConfig.Name = "gbx_InitConfig";
            this.gbx_InitConfig.Size = new System.Drawing.Size(547, 108);
            this.gbx_InitConfig.TabIndex = 0;
            this.gbx_InitConfig.TabStop = false;
            this.gbx_InitConfig.Text = "Init Config";
            // 
            // btn_setDefault
            // 
            this.btn_setDefault.Location = new System.Drawing.Point(247, 67);
            this.btn_setDefault.Name = "btn_setDefault";
            this.btn_setDefault.Size = new System.Drawing.Size(108, 30);
            this.btn_setDefault.TabIndex = 3;
            this.btn_setDefault.Text = "Default";
            this.btn_setDefault.UseVisualStyleBackColor = true;
            // 
            // btn_loadConfig
            // 
            this.btn_loadConfig.Location = new System.Drawing.Point(247, 27);
            this.btn_loadConfig.Name = "btn_loadConfig";
            this.btn_loadConfig.Size = new System.Drawing.Size(108, 29);
            this.btn_loadConfig.TabIndex = 1;
            this.btn_loadConfig.Text = "Load";
            this.btn_loadConfig.UseVisualStyleBackColor = true;
            // 
            // lbl_defaultConfig
            // 
            this.lbl_defaultConfig.AutoSize = true;
            this.lbl_defaultConfig.Location = new System.Drawing.Point(28, 72);
            this.lbl_defaultConfig.Name = "lbl_defaultConfig";
            this.lbl_defaultConfig.Size = new System.Drawing.Size(150, 17);
            this.lbl_defaultConfig.TabIndex = 2;
            this.lbl_defaultConfig.Text = "Set Default Configuration";
            // 
            // lbl_loadConfig
            // 
            this.lbl_loadConfig.AutoSize = true;
            this.lbl_loadConfig.Location = new System.Drawing.Point(28, 35);
            this.lbl_loadConfig.Name = "lbl_loadConfig";
            this.lbl_loadConfig.Size = new System.Drawing.Size(114, 17);
            this.lbl_loadConfig.TabIndex = 0;
            this.lbl_loadConfig.Text = "Load Configuration";
            // 
            // gbx_FpgaSetting
            // 
            this.gbx_FpgaSetting.Controls.Add(this.lbl_FpgaSysClk);
            this.gbx_FpgaSetting.Controls.Add(this.txt_sysClk);
            this.gbx_FpgaSetting.Controls.Add(this.lbl_sysClk);
            this.gbx_FpgaSetting.Controls.Add(this.cbo_fpgaInterface);
            this.gbx_FpgaSetting.Controls.Add(this.lbl_interface);
            this.gbx_FpgaSetting.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_FpgaSetting.Location = new System.Drawing.Point(35, 161);
            this.gbx_FpgaSetting.Name = "gbx_FpgaSetting";
            this.gbx_FpgaSetting.Size = new System.Drawing.Size(547, 108);
            this.gbx_FpgaSetting.TabIndex = 1;
            this.gbx_FpgaSetting.TabStop = false;
            this.gbx_FpgaSetting.Text = "Fpag Setting";
            // 
            // lbl_FpgaSysClk
            // 
            this.lbl_FpgaSysClk.AutoSize = true;
            this.lbl_FpgaSysClk.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FpgaSysClk.Location = new System.Drawing.Point(374, 65);
            this.lbl_FpgaSysClk.Name = "lbl_FpgaSysClk";
            this.lbl_FpgaSysClk.Size = new System.Drawing.Size(35, 17);
            this.lbl_FpgaSysClk.TabIndex = 4;
            this.lbl_FpgaSysClk.Text = "MHz";
            // 
            // txt_sysClk
            // 
            this.txt_sysClk.Location = new System.Drawing.Point(247, 62);
            this.txt_sysClk.Name = "txt_sysClk";
            this.txt_sysClk.Size = new System.Drawing.Size(121, 24);
            this.txt_sysClk.TabIndex = 3;
            this.txt_sysClk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_sysClk.Leave += new System.EventHandler(this.txt_sysClk_Leave);
            // 
            // lbl_sysClk
            // 
            this.lbl_sysClk.AutoSize = true;
            this.lbl_sysClk.Location = new System.Drawing.Point(33, 70);
            this.lbl_sysClk.Name = "lbl_sysClk";
            this.lbl_sysClk.Size = new System.Drawing.Size(87, 17);
            this.lbl_sysClk.TabIndex = 2;
            this.lbl_sysClk.Text = "System CLock:";
            // 
            // cbo_fpgaInterface
            // 
            this.cbo_fpgaInterface.FormattingEnabled = true;
            this.cbo_fpgaInterface.Items.AddRange(new object[] {
            "CPU",
            "RGB + SPI",
            "RGB + I2C",
            "MIPI"});
            this.cbo_fpgaInterface.Location = new System.Drawing.Point(247, 24);
            this.cbo_fpgaInterface.Name = "cbo_fpgaInterface";
            this.cbo_fpgaInterface.Size = new System.Drawing.Size(121, 25);
            this.cbo_fpgaInterface.TabIndex = 1;
            // 
            // lbl_interface
            // 
            this.lbl_interface.AutoSize = true;
            this.lbl_interface.Location = new System.Drawing.Point(33, 32);
            this.lbl_interface.Name = "lbl_interface";
            this.lbl_interface.Size = new System.Drawing.Size(64, 17);
            this.lbl_interface.TabIndex = 0;
            this.lbl_interface.Text = "Interface:";
            // 
            // tabPg_CPU
            // 
            this.tabPg_CPU.Controls.Add(this.gbx_busDef);
            this.tabPg_CPU.Controls.Add(this.gbx_CpuModeSel);
            this.tabPg_CPU.Location = new System.Drawing.Point(4, 23);
            this.tabPg_CPU.Name = "tabPg_CPU";
            this.tabPg_CPU.Size = new System.Drawing.Size(707, 515);
            this.tabPg_CPU.TabIndex = 1;
            this.tabPg_CPU.Text = "CPU";
            this.tabPg_CPU.UseVisualStyleBackColor = true;
            // 
            // gbx_busDef
            // 
            this.gbx_busDef.Controls.Add(this.pic_DataBusDef);
            this.gbx_busDef.Controls.Add(this.rbtn_18bitD17D0);
            this.gbx_busDef.Controls.Add(this.rbtn_18bitD23D0);
            this.gbx_busDef.Controls.Add(this.rbtn_9bitD17D9);
            this.gbx_busDef.Controls.Add(this.rbtn_16bitD15D0);
            this.gbx_busDef.Controls.Add(this.rbtn_17bitD17D10);
            this.gbx_busDef.Controls.Add(this.rbtn_9bitD8D0);
            this.gbx_busDef.Controls.Add(this.rbtn_8bitD17D10);
            this.gbx_busDef.Controls.Add(this.rbtn_8BitD7D0);
            this.gbx_busDef.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_busDef.Location = new System.Drawing.Point(45, 93);
            this.gbx_busDef.Name = "gbx_busDef";
            this.gbx_busDef.Size = new System.Drawing.Size(547, 307);
            this.gbx_busDef.TabIndex = 6;
            this.gbx_busDef.TabStop = false;
            this.gbx_busDef.Text = "Data Bus Definition";
            // 
            // pic_DataBusDef
            // 
            this.pic_DataBusDef.Image = global::SC_Tek_Studio_Pro.Properties.Resources.cpu_data_bus;
            this.pic_DataBusDef.Location = new System.Drawing.Point(23, 194);
            this.pic_DataBusDef.Name = "pic_DataBusDef";
            this.pic_DataBusDef.Size = new System.Drawing.Size(504, 84);
            this.pic_DataBusDef.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_DataBusDef.TabIndex = 8;
            this.pic_DataBusDef.TabStop = false;
            // 
            // rbtn_18bitD17D0
            // 
            this.rbtn_18bitD17D0.AutoSize = true;
            this.rbtn_18bitD17D0.Location = new System.Drawing.Point(88, 150);
            this.rbtn_18bitD17D0.Name = "rbtn_18bitD17D0";
            this.rbtn_18bitD17D0.Size = new System.Drawing.Size(109, 21);
            this.rbtn_18bitD17D0.TabIndex = 7;
            this.rbtn_18bitD17D0.Text = "18 bit[D17:D0]";
            this.rbtn_18bitD17D0.UseVisualStyleBackColor = true;
            this.rbtn_18bitD17D0.CheckedChanged += new System.EventHandler(this.rbtn_8BitD7D0_CheckedChanged);
            // 
            // rbtn_18bitD23D0
            // 
            this.rbtn_18bitD23D0.AutoSize = true;
            this.rbtn_18bitD23D0.Location = new System.Drawing.Point(290, 150);
            this.rbtn_18bitD23D0.Name = "rbtn_18bitD23D0";
            this.rbtn_18bitD23D0.Size = new System.Drawing.Size(109, 21);
            this.rbtn_18bitD23D0.TabIndex = 6;
            this.rbtn_18bitD23D0.Text = "18 bit[D23:D0]";
            this.rbtn_18bitD23D0.UseVisualStyleBackColor = true;
            this.rbtn_18bitD23D0.CheckedChanged += new System.EventHandler(this.rbtn_8BitD7D0_CheckedChanged);
            // 
            // rbtn_9bitD17D9
            // 
            this.rbtn_9bitD17D9.AutoSize = true;
            this.rbtn_9bitD17D9.Location = new System.Drawing.Point(290, 74);
            this.rbtn_9bitD17D9.Name = "rbtn_9bitD17D9";
            this.rbtn_9bitD17D9.Size = new System.Drawing.Size(102, 21);
            this.rbtn_9bitD17D9.TabIndex = 5;
            this.rbtn_9bitD17D9.Text = "9 bit[D17:D9]";
            this.rbtn_9bitD17D9.UseVisualStyleBackColor = true;
            this.rbtn_9bitD17D9.CheckedChanged += new System.EventHandler(this.rbtn_8BitD7D0_CheckedChanged);
            // 
            // rbtn_16bitD15D0
            // 
            this.rbtn_16bitD15D0.AutoSize = true;
            this.rbtn_16bitD15D0.Location = new System.Drawing.Point(88, 111);
            this.rbtn_16bitD15D0.Name = "rbtn_16bitD15D0";
            this.rbtn_16bitD15D0.Size = new System.Drawing.Size(109, 21);
            this.rbtn_16bitD15D0.TabIndex = 4;
            this.rbtn_16bitD15D0.Text = "16 bit[D15:D0]";
            this.rbtn_16bitD15D0.UseVisualStyleBackColor = true;
            this.rbtn_16bitD15D0.CheckedChanged += new System.EventHandler(this.rbtn_8BitD7D0_CheckedChanged);
            // 
            // rbtn_17bitD17D10
            // 
            this.rbtn_17bitD17D10.AutoSize = true;
            this.rbtn_17bitD17D10.Location = new System.Drawing.Point(290, 111);
            this.rbtn_17bitD17D10.Name = "rbtn_17bitD17D10";
            this.rbtn_17bitD17D10.Size = new System.Drawing.Size(156, 21);
            this.rbtn_17bitD17D10.TabIndex = 3;
            this.rbtn_17bitD17D10.Text = "16 bit[D17:D10,D8:D1]";
            this.rbtn_17bitD17D10.UseVisualStyleBackColor = true;
            this.rbtn_17bitD17D10.CheckedChanged += new System.EventHandler(this.rbtn_8BitD7D0_CheckedChanged);
            // 
            // rbtn_9bitD8D0
            // 
            this.rbtn_9bitD8D0.AutoSize = true;
            this.rbtn_9bitD8D0.Location = new System.Drawing.Point(88, 74);
            this.rbtn_9bitD8D0.Name = "rbtn_9bitD8D0";
            this.rbtn_9bitD8D0.Size = new System.Drawing.Size(95, 21);
            this.rbtn_9bitD8D0.TabIndex = 2;
            this.rbtn_9bitD8D0.Text = "9 bit[D8:D0]";
            this.rbtn_9bitD8D0.UseVisualStyleBackColor = true;
            this.rbtn_9bitD8D0.CheckedChanged += new System.EventHandler(this.rbtn_8BitD7D0_CheckedChanged);
            // 
            // rbtn_8bitD17D10
            // 
            this.rbtn_8bitD17D10.AutoSize = true;
            this.rbtn_8bitD17D10.Location = new System.Drawing.Point(290, 40);
            this.rbtn_8bitD17D10.Name = "rbtn_8bitD17D10";
            this.rbtn_8bitD17D10.Size = new System.Drawing.Size(109, 21);
            this.rbtn_8bitD17D10.TabIndex = 1;
            this.rbtn_8bitD17D10.Text = "8 bit[D17:D10]";
            this.rbtn_8bitD17D10.UseVisualStyleBackColor = true;
            this.rbtn_8bitD17D10.CheckedChanged += new System.EventHandler(this.rbtn_8BitD7D0_CheckedChanged);
            // 
            // rbtn_8BitD7D0
            // 
            this.rbtn_8BitD7D0.AutoSize = true;
            this.rbtn_8BitD7D0.Checked = true;
            this.rbtn_8BitD7D0.Location = new System.Drawing.Point(88, 40);
            this.rbtn_8BitD7D0.Name = "rbtn_8BitD7D0";
            this.rbtn_8BitD7D0.Size = new System.Drawing.Size(95, 21);
            this.rbtn_8BitD7D0.TabIndex = 0;
            this.rbtn_8BitD7D0.TabStop = true;
            this.rbtn_8BitD7D0.Text = "8 bit[D7:D0]";
            this.rbtn_8BitD7D0.UseVisualStyleBackColor = true;
            this.rbtn_8BitD7D0.CheckedChanged += new System.EventHandler(this.rbtn_8BitD7D0_CheckedChanged);
            // 
            // gbx_CpuModeSel
            // 
            this.gbx_CpuModeSel.Controls.Add(this.rbtn_m68);
            this.gbx_CpuModeSel.Controls.Add(this.rbtn_I80);
            this.gbx_CpuModeSel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_CpuModeSel.Location = new System.Drawing.Point(45, 20);
            this.gbx_CpuModeSel.Name = "gbx_CpuModeSel";
            this.gbx_CpuModeSel.Size = new System.Drawing.Size(547, 67);
            this.gbx_CpuModeSel.TabIndex = 5;
            this.gbx_CpuModeSel.TabStop = false;
            this.gbx_CpuModeSel.Text = "CPU Mode Select";
            // 
            // rbtn_m68
            // 
            this.rbtn_m68.AutoSize = true;
            this.rbtn_m68.Location = new System.Drawing.Point(290, 25);
            this.rbtn_m68.Name = "rbtn_m68";
            this.rbtn_m68.Size = new System.Drawing.Size(52, 21);
            this.rbtn_m68.TabIndex = 1;
            this.rbtn_m68.TabStop = true;
            this.rbtn_m68.Text = "M68";
            this.rbtn_m68.UseVisualStyleBackColor = true;
            // 
            // rbtn_I80
            // 
            this.rbtn_I80.AutoSize = true;
            this.rbtn_I80.Location = new System.Drawing.Point(88, 25);
            this.rbtn_I80.Name = "rbtn_I80";
            this.rbtn_I80.Size = new System.Drawing.Size(44, 21);
            this.rbtn_I80.TabIndex = 0;
            this.rbtn_I80.TabStop = true;
            this.rbtn_I80.Text = "I80";
            this.rbtn_I80.UseVisualStyleBackColor = true;
            // 
            // tabPg_RgbTiming
            // 
            this.tabPg_RgbTiming.Controls.Add(this.gbx_ShwTimeSet);
            this.tabPg_RgbTiming.Controls.Add(this.gbx_polarity);
            this.tabPg_RgbTiming.Controls.Add(this.gbx_timeset);
            this.tabPg_RgbTiming.Location = new System.Drawing.Point(4, 23);
            this.tabPg_RgbTiming.Name = "tabPg_RgbTiming";
            this.tabPg_RgbTiming.Size = new System.Drawing.Size(707, 515);
            this.tabPg_RgbTiming.TabIndex = 2;
            this.tabPg_RgbTiming.Text = "RGB Timing";
            this.tabPg_RgbTiming.UseVisualStyleBackColor = true;
            // 
            // gbx_ShwTimeSet
            // 
            this.gbx_ShwTimeSet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbx_ShwTimeSet.BackColor = System.Drawing.Color.Gainsboro;
            this.gbx_ShwTimeSet.BackgroundImage = global::SC_Tek_Studio_Pro.Properties.Resources.RGB_chart;
            this.gbx_ShwTimeSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_HfpVal);
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_HactiveVal);
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_HbpVal);
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_HsyncVal);
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_VfpVal);
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_VactiveVal);
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_VbpVal);
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_VsyncVal);
            this.gbx_ShwTimeSet.Controls.Add(this.label3);
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_PixelClkVal);
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_ScanRateVal);
            this.gbx_ShwTimeSet.Controls.Add(this.lbl_fpRateVal);
            this.gbx_ShwTimeSet.Location = new System.Drawing.Point(0, 2);
            this.gbx_ShwTimeSet.Name = "gbx_ShwTimeSet";
            this.gbx_ShwTimeSet.Size = new System.Drawing.Size(466, 330);
            this.gbx_ShwTimeSet.TabIndex = 2;
            this.gbx_ShwTimeSet.TabStop = false;
            this.gbx_ShwTimeSet.Text = "Timing Setting";
            // 
            // lbl_HfpVal
            // 
            this.lbl_HfpVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_HfpVal.AutoSize = true;
            this.lbl_HfpVal.Location = new System.Drawing.Point(321, 290);
            this.lbl_HfpVal.Name = "lbl_HfpVal";
            this.lbl_HfpVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_HfpVal.TabIndex = 44;
            this.lbl_HfpVal.Text = "0";
            // 
            // lbl_HactiveVal
            // 
            this.lbl_HactiveVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_HactiveVal.AutoSize = true;
            this.lbl_HactiveVal.Location = new System.Drawing.Point(233, 290);
            this.lbl_HactiveVal.Name = "lbl_HactiveVal";
            this.lbl_HactiveVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_HactiveVal.TabIndex = 43;
            this.lbl_HactiveVal.Text = "0";
            // 
            // lbl_HbpVal
            // 
            this.lbl_HbpVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_HbpVal.AutoSize = true;
            this.lbl_HbpVal.Location = new System.Drawing.Point(166, 290);
            this.lbl_HbpVal.Name = "lbl_HbpVal";
            this.lbl_HbpVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_HbpVal.TabIndex = 42;
            this.lbl_HbpVal.Text = "0";
            // 
            // lbl_HsyncVal
            // 
            this.lbl_HsyncVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_HsyncVal.AutoSize = true;
            this.lbl_HsyncVal.Location = new System.Drawing.Point(132, 290);
            this.lbl_HsyncVal.Name = "lbl_HsyncVal";
            this.lbl_HsyncVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_HsyncVal.TabIndex = 41;
            this.lbl_HsyncVal.Text = "0";
            // 
            // lbl_VfpVal
            // 
            this.lbl_VfpVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_VfpVal.AutoSize = true;
            this.lbl_VfpVal.Location = new System.Drawing.Point(51, 207);
            this.lbl_VfpVal.Name = "lbl_VfpVal";
            this.lbl_VfpVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_VfpVal.TabIndex = 40;
            this.lbl_VfpVal.Text = "0";
            // 
            // lbl_VactiveVal
            // 
            this.lbl_VactiveVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_VactiveVal.AutoSize = true;
            this.lbl_VactiveVal.Location = new System.Drawing.Point(51, 131);
            this.lbl_VactiveVal.Name = "lbl_VactiveVal";
            this.lbl_VactiveVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_VactiveVal.TabIndex = 39;
            this.lbl_VactiveVal.Text = "0";
            // 
            // lbl_VbpVal
            // 
            this.lbl_VbpVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_VbpVal.AutoSize = true;
            this.lbl_VbpVal.Location = new System.Drawing.Point(51, 79);
            this.lbl_VbpVal.Name = "lbl_VbpVal";
            this.lbl_VbpVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_VbpVal.TabIndex = 38;
            this.lbl_VbpVal.Text = "0";
            // 
            // lbl_VsyncVal
            // 
            this.lbl_VsyncVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_VsyncVal.AutoSize = true;
            this.lbl_VsyncVal.Location = new System.Drawing.Point(51, 43);
            this.lbl_VsyncVal.Name = "lbl_VsyncVal";
            this.lbl_VsyncVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_VsyncVal.TabIndex = 37;
            this.lbl_VsyncVal.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(381, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 14);
            this.label3.TabIndex = 36;
            this.label3.Text = "Mhz";
            // 
            // lbl_PixelClkVal
            // 
            this.lbl_PixelClkVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_PixelClkVal.AutoSize = true;
            this.lbl_PixelClkVal.Location = new System.Drawing.Point(360, 79);
            this.lbl_PixelClkVal.Name = "lbl_PixelClkVal";
            this.lbl_PixelClkVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_PixelClkVal.TabIndex = 2;
            this.lbl_PixelClkVal.Text = "0";
            // 
            // lbl_ScanRateVal
            // 
            this.lbl_ScanRateVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_ScanRateVal.AutoSize = true;
            this.lbl_ScanRateVal.Location = new System.Drawing.Point(360, 239);
            this.lbl_ScanRateVal.Name = "lbl_ScanRateVal";
            this.lbl_ScanRateVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_ScanRateVal.TabIndex = 1;
            this.lbl_ScanRateVal.Text = "0";
            // 
            // lbl_fpRateVal
            // 
            this.lbl_fpRateVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_fpRateVal.AutoSize = true;
            this.lbl_fpRateVal.Location = new System.Drawing.Point(360, 157);
            this.lbl_fpRateVal.Name = "lbl_fpRateVal";
            this.lbl_fpRateVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_fpRateVal.TabIndex = 0;
            this.lbl_fpRateVal.Text = "0";
            // 
            // gbx_polarity
            // 
            this.gbx_polarity.Controls.Add(this.tableLayoutPanel1);
            this.gbx_polarity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbx_polarity.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_polarity.Location = new System.Drawing.Point(0, 355);
            this.gbx_polarity.Name = "gbx_polarity";
            this.gbx_polarity.Size = new System.Drawing.Size(466, 160);
            this.gbx_polarity.TabIndex = 1;
            this.gbx_polarity.TabStop = false;
            this.gbx_polarity.Text = "Polarity";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pic_De, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pic_Vsync, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pic_Hsync, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pic_Pclk, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 137);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pic_De
            // 
            this.pic_De.BackColor = System.Drawing.Color.LightGray;
            this.pic_De.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_De.Image = global::SC_Tek_Studio_Pro.Properties.Resources.de_p0;
            this.pic_De.Location = new System.Drawing.Point(233, 71);
            this.pic_De.Name = "pic_De";
            this.pic_De.Size = new System.Drawing.Size(224, 63);
            this.pic_De.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_De.TabIndex = 3;
            this.pic_De.TabStop = false;
            this.pic_De.Click += new System.EventHandler(this.pic_De_Click);
            // 
            // pic_Vsync
            // 
            this.pic_Vsync.BackColor = System.Drawing.Color.Gainsboro;
            this.pic_Vsync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_Vsync.Image = global::SC_Tek_Studio_Pro.Properties.Resources.vs_p0;
            this.pic_Vsync.Location = new System.Drawing.Point(3, 71);
            this.pic_Vsync.Name = "pic_Vsync";
            this.pic_Vsync.Size = new System.Drawing.Size(224, 63);
            this.pic_Vsync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Vsync.TabIndex = 2;
            this.pic_Vsync.TabStop = false;
            this.pic_Vsync.Click += new System.EventHandler(this.pic_Vsync_Click);
            // 
            // pic_Hsync
            // 
            this.pic_Hsync.BackColor = System.Drawing.Color.Gainsboro;
            this.pic_Hsync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_Hsync.Image = global::SC_Tek_Studio_Pro.Properties.Resources.hs_p0;
            this.pic_Hsync.Location = new System.Drawing.Point(233, 3);
            this.pic_Hsync.Name = "pic_Hsync";
            this.pic_Hsync.Size = new System.Drawing.Size(224, 62);
            this.pic_Hsync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Hsync.TabIndex = 1;
            this.pic_Hsync.TabStop = false;
            this.pic_Hsync.Click += new System.EventHandler(this.pic_Hsync_Click);
            // 
            // pic_Pclk
            // 
            this.pic_Pclk.BackColor = System.Drawing.Color.Gainsboro;
            this.pic_Pclk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_Pclk.Image = global::SC_Tek_Studio_Pro.Properties.Resources.pclk_p0;
            this.pic_Pclk.InitialImage = global::SC_Tek_Studio_Pro.Properties.Resources.pclk_p0;
            this.pic_Pclk.Location = new System.Drawing.Point(3, 3);
            this.pic_Pclk.Name = "pic_Pclk";
            this.pic_Pclk.Size = new System.Drawing.Size(224, 62);
            this.pic_Pclk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Pclk.TabIndex = 0;
            this.pic_Pclk.TabStop = false;
            this.pic_Pclk.Click += new System.EventHandler(this.pic_Pclk_Click);
            // 
            // gbx_timeset
            // 
            this.gbx_timeset.Controls.Add(this.lbl_pixelCkMhz);
            this.gbx_timeset.Controls.Add(this.txt_PixelClk);
            this.gbx_timeset.Controls.Add(this.lbl_PixelClk);
            this.gbx_timeset.Controls.Add(this.lbl_extClk);
            this.gbx_timeset.Controls.Add(this.txt_Vtotal);
            this.gbx_timeset.Controls.Add(this.txt_Vfp);
            this.gbx_timeset.Controls.Add(this.txt_Vactive);
            this.gbx_timeset.Controls.Add(this.txt_Vbp);
            this.gbx_timeset.Controls.Add(this.txt_Vsync);
            this.gbx_timeset.Controls.Add(this.lbl_vtotalPixel);
            this.gbx_timeset.Controls.Add(this.lbl_vfpPixel);
            this.gbx_timeset.Controls.Add(this.lbl_vactivePixel);
            this.gbx_timeset.Controls.Add(this.lbl_vbpPixel);
            this.gbx_timeset.Controls.Add(this.lbl_vsyncPixel);
            this.gbx_timeset.Controls.Add(this.lbl_shwVtotal);
            this.gbx_timeset.Controls.Add(this.lbl_shwVfp);
            this.gbx_timeset.Controls.Add(this.lbl_shwVactive);
            this.gbx_timeset.Controls.Add(this.lbl_shwVbp);
            this.gbx_timeset.Controls.Add(this.lbl_showVsync);
            this.gbx_timeset.Controls.Add(this.lbl_verTiming);
            this.gbx_timeset.Controls.Add(this.txt_Htotal);
            this.gbx_timeset.Controls.Add(this.txt_Hfp);
            this.gbx_timeset.Controls.Add(this.txt_Hactive);
            this.gbx_timeset.Controls.Add(this.txt_Hbp);
            this.gbx_timeset.Controls.Add(this.txt_Hsync);
            this.gbx_timeset.Controls.Add(this.lbl_htotalPixel);
            this.gbx_timeset.Controls.Add(this.lbl_hfpPixel);
            this.gbx_timeset.Controls.Add(this.lbl_hactivePixel);
            this.gbx_timeset.Controls.Add(this.lbl_hbpPixel);
            this.gbx_timeset.Controls.Add(this.lbl_hsyncPixel);
            this.gbx_timeset.Controls.Add(this.lbl_shwHtotal);
            this.gbx_timeset.Controls.Add(this.lbl_shwHfp);
            this.gbx_timeset.Controls.Add(this.lbl_shwHactive);
            this.gbx_timeset.Controls.Add(this.lbl_shwHbp);
            this.gbx_timeset.Controls.Add(this.lbl_shwHsycn);
            this.gbx_timeset.Controls.Add(this.lbl_hortiming);
            this.gbx_timeset.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbx_timeset.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_timeset.Location = new System.Drawing.Point(466, 0);
            this.gbx_timeset.Name = "gbx_timeset";
            this.gbx_timeset.Size = new System.Drawing.Size(241, 515);
            this.gbx_timeset.TabIndex = 0;
            this.gbx_timeset.TabStop = false;
            this.gbx_timeset.Text = "Setting";
            // 
            // lbl_pixelCkMhz
            // 
            this.lbl_pixelCkMhz.AutoSize = true;
            this.lbl_pixelCkMhz.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pixelCkMhz.Location = new System.Drawing.Point(194, 454);
            this.lbl_pixelCkMhz.Name = "lbl_pixelCkMhz";
            this.lbl_pixelCkMhz.Size = new System.Drawing.Size(33, 17);
            this.lbl_pixelCkMhz.TabIndex = 35;
            this.lbl_pixelCkMhz.Text = "Mhz";
            // 
            // txt_PixelClk
            // 
            this.txt_PixelClk.Location = new System.Drawing.Point(83, 451);
            this.txt_PixelClk.Name = "txt_PixelClk";
            this.txt_PixelClk.Size = new System.Drawing.Size(100, 24);
            this.txt_PixelClk.TabIndex = 34;
            this.txt_PixelClk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_PixelClk.Leave += new System.EventHandler(this.txt_Hsync_Leave);
            // 
            // lbl_PixelClk
            // 
            this.lbl_PixelClk.AutoSize = true;
            this.lbl_PixelClk.Location = new System.Drawing.Point(9, 454);
            this.lbl_PixelClk.Name = "lbl_PixelClk";
            this.lbl_PixelClk.Size = new System.Drawing.Size(54, 17);
            this.lbl_PixelClk.TabIndex = 33;
            this.lbl_PixelClk.Text = "Pixel Ck:";
            // 
            // lbl_extClk
            // 
            this.lbl_extClk.AutoSize = true;
            this.lbl_extClk.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_extClk.Location = new System.Drawing.Point(0, 413);
            this.lbl_extClk.Name = "lbl_extClk";
            this.lbl_extClk.Size = new System.Drawing.Size(91, 17);
            this.lbl_extClk.TabIndex = 32;
            this.lbl_extClk.Text = "External Clock:";
            // 
            // txt_Vtotal
            // 
            this.txt_Vtotal.Location = new System.Drawing.Point(62, 376);
            this.txt_Vtotal.Name = "txt_Vtotal";
            this.txt_Vtotal.Size = new System.Drawing.Size(100, 24);
            this.txt_Vtotal.TabIndex = 31;
            this.txt_Vtotal.Text = "0";
            this.txt_Vtotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            // 
            // txt_Vfp
            // 
            this.txt_Vfp.Location = new System.Drawing.Point(62, 344);
            this.txt_Vfp.Name = "txt_Vfp";
            this.txt_Vfp.Size = new System.Drawing.Size(100, 24);
            this.txt_Vfp.TabIndex = 30;
            this.txt_Vfp.Text = "0";
            this.txt_Vfp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_Vfp.Leave += new System.EventHandler(this.txt_Hsync_Leave);
            // 
            // txt_Vactive
            // 
            this.txt_Vactive.Location = new System.Drawing.Point(62, 312);
            this.txt_Vactive.Name = "txt_Vactive";
            this.txt_Vactive.Size = new System.Drawing.Size(100, 24);
            this.txt_Vactive.TabIndex = 29;
            this.txt_Vactive.Text = "0";
            this.txt_Vactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_Vactive.Leave += new System.EventHandler(this.txt_Hsync_Leave);
            // 
            // txt_Vbp
            // 
            this.txt_Vbp.Location = new System.Drawing.Point(62, 280);
            this.txt_Vbp.Name = "txt_Vbp";
            this.txt_Vbp.Size = new System.Drawing.Size(100, 24);
            this.txt_Vbp.TabIndex = 28;
            this.txt_Vbp.Text = "0";
            this.txt_Vbp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_Vbp.Leave += new System.EventHandler(this.txt_Hsync_Leave);
            // 
            // txt_Vsync
            // 
            this.txt_Vsync.Location = new System.Drawing.Point(62, 249);
            this.txt_Vsync.Name = "txt_Vsync";
            this.txt_Vsync.Size = new System.Drawing.Size(100, 24);
            this.txt_Vsync.TabIndex = 27;
            this.txt_Vsync.Text = "0";
            this.txt_Vsync.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_Vsync.Leave += new System.EventHandler(this.txt_Hsync_Leave);
            // 
            // lbl_vtotalPixel
            // 
            this.lbl_vtotalPixel.AutoSize = true;
            this.lbl_vtotalPixel.Location = new System.Drawing.Point(188, 379);
            this.lbl_vtotalPixel.Name = "lbl_vtotalPixel";
            this.lbl_vtotalPixel.Size = new System.Drawing.Size(39, 17);
            this.lbl_vtotalPixel.TabIndex = 26;
            this.lbl_vtotalPixel.Text = "Pixels";
            // 
            // lbl_vfpPixel
            // 
            this.lbl_vfpPixel.AutoSize = true;
            this.lbl_vfpPixel.Location = new System.Drawing.Point(188, 347);
            this.lbl_vfpPixel.Name = "lbl_vfpPixel";
            this.lbl_vfpPixel.Size = new System.Drawing.Size(39, 17);
            this.lbl_vfpPixel.TabIndex = 25;
            this.lbl_vfpPixel.Text = "Pixels";
            // 
            // lbl_vactivePixel
            // 
            this.lbl_vactivePixel.AutoSize = true;
            this.lbl_vactivePixel.Location = new System.Drawing.Point(188, 315);
            this.lbl_vactivePixel.Name = "lbl_vactivePixel";
            this.lbl_vactivePixel.Size = new System.Drawing.Size(39, 17);
            this.lbl_vactivePixel.TabIndex = 24;
            this.lbl_vactivePixel.Text = "Pixels";
            // 
            // lbl_vbpPixel
            // 
            this.lbl_vbpPixel.AutoSize = true;
            this.lbl_vbpPixel.Location = new System.Drawing.Point(188, 283);
            this.lbl_vbpPixel.Name = "lbl_vbpPixel";
            this.lbl_vbpPixel.Size = new System.Drawing.Size(39, 17);
            this.lbl_vbpPixel.TabIndex = 23;
            this.lbl_vbpPixel.Text = "Pixels";
            // 
            // lbl_vsyncPixel
            // 
            this.lbl_vsyncPixel.AutoSize = true;
            this.lbl_vsyncPixel.Location = new System.Drawing.Point(188, 252);
            this.lbl_vsyncPixel.Name = "lbl_vsyncPixel";
            this.lbl_vsyncPixel.Size = new System.Drawing.Size(39, 17);
            this.lbl_vsyncPixel.TabIndex = 22;
            this.lbl_vsyncPixel.Text = "Pixels";
            // 
            // lbl_shwVtotal
            // 
            this.lbl_shwVtotal.AutoSize = true;
            this.lbl_shwVtotal.Location = new System.Drawing.Point(9, 379);
            this.lbl_shwVtotal.Name = "lbl_shwVtotal";
            this.lbl_shwVtotal.Size = new System.Drawing.Size(40, 17);
            this.lbl_shwVtotal.TabIndex = 21;
            this.lbl_shwVtotal.Text = "Total:";
            // 
            // lbl_shwVfp
            // 
            this.lbl_shwVfp.AutoSize = true;
            this.lbl_shwVfp.Location = new System.Drawing.Point(16, 347);
            this.lbl_shwVfp.Name = "lbl_shwVfp";
            this.lbl_shwVfp.Size = new System.Drawing.Size(25, 17);
            this.lbl_shwVfp.TabIndex = 20;
            this.lbl_shwVfp.Text = "FP:";
            // 
            // lbl_shwVactive
            // 
            this.lbl_shwVactive.AutoSize = true;
            this.lbl_shwVactive.Location = new System.Drawing.Point(6, 315);
            this.lbl_shwVactive.Name = "lbl_shwVactive";
            this.lbl_shwVactive.Size = new System.Drawing.Size(47, 17);
            this.lbl_shwVactive.TabIndex = 19;
            this.lbl_shwVactive.Text = "Active:";
            // 
            // lbl_shwVbp
            // 
            this.lbl_shwVbp.AutoSize = true;
            this.lbl_shwVbp.Location = new System.Drawing.Point(19, 283);
            this.lbl_shwVbp.Name = "lbl_shwVbp";
            this.lbl_shwVbp.Size = new System.Drawing.Size(27, 17);
            this.lbl_shwVbp.TabIndex = 18;
            this.lbl_shwVbp.Text = "BP:";
            // 
            // lbl_showVsync
            // 
            this.lbl_showVsync.AutoSize = true;
            this.lbl_showVsync.Location = new System.Drawing.Point(6, 252);
            this.lbl_showVsync.Name = "lbl_showVsync";
            this.lbl_showVsync.Size = new System.Drawing.Size(37, 17);
            this.lbl_showVsync.TabIndex = 17;
            this.lbl_showVsync.Text = "Sync:";
            // 
            // lbl_verTiming
            // 
            this.lbl_verTiming.AutoSize = true;
            this.lbl_verTiming.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_verTiming.Location = new System.Drawing.Point(9, 225);
            this.lbl_verTiming.Name = "lbl_verTiming";
            this.lbl_verTiming.Size = new System.Drawing.Size(92, 17);
            this.lbl_verTiming.TabIndex = 16;
            this.lbl_verTiming.Text = "Vertical Timing";
            // 
            // txt_Htotal
            // 
            this.txt_Htotal.Location = new System.Drawing.Point(62, 184);
            this.txt_Htotal.Name = "txt_Htotal";
            this.txt_Htotal.Size = new System.Drawing.Size(100, 24);
            this.txt_Htotal.TabIndex = 15;
            this.txt_Htotal.Text = "0";
            this.txt_Htotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            // 
            // txt_Hfp
            // 
            this.txt_Hfp.Location = new System.Drawing.Point(62, 152);
            this.txt_Hfp.Name = "txt_Hfp";
            this.txt_Hfp.Size = new System.Drawing.Size(100, 24);
            this.txt_Hfp.TabIndex = 14;
            this.txt_Hfp.Text = "0";
            this.txt_Hfp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_Hfp.Leave += new System.EventHandler(this.txt_Hsync_Leave);
            // 
            // txt_Hactive
            // 
            this.txt_Hactive.Location = new System.Drawing.Point(62, 120);
            this.txt_Hactive.Name = "txt_Hactive";
            this.txt_Hactive.Size = new System.Drawing.Size(100, 24);
            this.txt_Hactive.TabIndex = 13;
            this.txt_Hactive.Text = "0";
            this.txt_Hactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_Hactive.Leave += new System.EventHandler(this.txt_Hsync_Leave);
            // 
            // txt_Hbp
            // 
            this.txt_Hbp.Location = new System.Drawing.Point(62, 88);
            this.txt_Hbp.Name = "txt_Hbp";
            this.txt_Hbp.Size = new System.Drawing.Size(100, 24);
            this.txt_Hbp.TabIndex = 12;
            this.txt_Hbp.Text = "0";
            this.txt_Hbp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_Hbp.Leave += new System.EventHandler(this.txt_Hsync_Leave);
            // 
            // txt_Hsync
            // 
            this.txt_Hsync.Location = new System.Drawing.Point(62, 57);
            this.txt_Hsync.Name = "txt_Hsync";
            this.txt_Hsync.Size = new System.Drawing.Size(100, 24);
            this.txt_Hsync.TabIndex = 11;
            this.txt_Hsync.Text = "0";
            this.txt_Hsync.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_Hsync.Leave += new System.EventHandler(this.txt_Hsync_Leave);
            // 
            // lbl_htotalPixel
            // 
            this.lbl_htotalPixel.AutoSize = true;
            this.lbl_htotalPixel.Location = new System.Drawing.Point(188, 187);
            this.lbl_htotalPixel.Name = "lbl_htotalPixel";
            this.lbl_htotalPixel.Size = new System.Drawing.Size(39, 17);
            this.lbl_htotalPixel.TabIndex = 10;
            this.lbl_htotalPixel.Text = "Pixels";
            // 
            // lbl_hfpPixel
            // 
            this.lbl_hfpPixel.AutoSize = true;
            this.lbl_hfpPixel.Location = new System.Drawing.Point(188, 155);
            this.lbl_hfpPixel.Name = "lbl_hfpPixel";
            this.lbl_hfpPixel.Size = new System.Drawing.Size(39, 17);
            this.lbl_hfpPixel.TabIndex = 9;
            this.lbl_hfpPixel.Text = "Pixels";
            // 
            // lbl_hactivePixel
            // 
            this.lbl_hactivePixel.AutoSize = true;
            this.lbl_hactivePixel.Location = new System.Drawing.Point(188, 123);
            this.lbl_hactivePixel.Name = "lbl_hactivePixel";
            this.lbl_hactivePixel.Size = new System.Drawing.Size(39, 17);
            this.lbl_hactivePixel.TabIndex = 8;
            this.lbl_hactivePixel.Text = "Pixels";
            // 
            // lbl_hbpPixel
            // 
            this.lbl_hbpPixel.AutoSize = true;
            this.lbl_hbpPixel.Location = new System.Drawing.Point(188, 91);
            this.lbl_hbpPixel.Name = "lbl_hbpPixel";
            this.lbl_hbpPixel.Size = new System.Drawing.Size(39, 17);
            this.lbl_hbpPixel.TabIndex = 7;
            this.lbl_hbpPixel.Text = "Pixels";
            // 
            // lbl_hsyncPixel
            // 
            this.lbl_hsyncPixel.AutoSize = true;
            this.lbl_hsyncPixel.Location = new System.Drawing.Point(188, 60);
            this.lbl_hsyncPixel.Name = "lbl_hsyncPixel";
            this.lbl_hsyncPixel.Size = new System.Drawing.Size(39, 17);
            this.lbl_hsyncPixel.TabIndex = 6;
            this.lbl_hsyncPixel.Text = "Pixels";
            // 
            // lbl_shwHtotal
            // 
            this.lbl_shwHtotal.AutoSize = true;
            this.lbl_shwHtotal.Location = new System.Drawing.Point(9, 187);
            this.lbl_shwHtotal.Name = "lbl_shwHtotal";
            this.lbl_shwHtotal.Size = new System.Drawing.Size(40, 17);
            this.lbl_shwHtotal.TabIndex = 5;
            this.lbl_shwHtotal.Text = "Total:";
            // 
            // lbl_shwHfp
            // 
            this.lbl_shwHfp.AutoSize = true;
            this.lbl_shwHfp.Location = new System.Drawing.Point(20, 155);
            this.lbl_shwHfp.Name = "lbl_shwHfp";
            this.lbl_shwHfp.Size = new System.Drawing.Size(25, 17);
            this.lbl_shwHfp.TabIndex = 4;
            this.lbl_shwHfp.Text = "FP:";
            // 
            // lbl_shwHactive
            // 
            this.lbl_shwHactive.AutoSize = true;
            this.lbl_shwHactive.Location = new System.Drawing.Point(-1, 128);
            this.lbl_shwHactive.Name = "lbl_shwHactive";
            this.lbl_shwHactive.Size = new System.Drawing.Size(47, 17);
            this.lbl_shwHactive.TabIndex = 3;
            this.lbl_shwHactive.Text = "Active:";
            // 
            // lbl_shwHbp
            // 
            this.lbl_shwHbp.AutoSize = true;
            this.lbl_shwHbp.Location = new System.Drawing.Point(19, 95);
            this.lbl_shwHbp.Name = "lbl_shwHbp";
            this.lbl_shwHbp.Size = new System.Drawing.Size(27, 17);
            this.lbl_shwHbp.TabIndex = 2;
            this.lbl_shwHbp.Text = "BP:";
            // 
            // lbl_shwHsycn
            // 
            this.lbl_shwHsycn.AutoSize = true;
            this.lbl_shwHsycn.Location = new System.Drawing.Point(9, 60);
            this.lbl_shwHsycn.Name = "lbl_shwHsycn";
            this.lbl_shwHsycn.Size = new System.Drawing.Size(37, 17);
            this.lbl_shwHsycn.TabIndex = 1;
            this.lbl_shwHsycn.Text = "Sync:";
            // 
            // lbl_hortiming
            // 
            this.lbl_hortiming.AutoSize = true;
            this.lbl_hortiming.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hortiming.Location = new System.Drawing.Point(9, 24);
            this.lbl_hortiming.Name = "lbl_hortiming";
            this.lbl_hortiming.Size = new System.Drawing.Size(108, 17);
            this.lbl_hortiming.TabIndex = 0;
            this.lbl_hortiming.Text = "Horizontal Timing";
            // 
            // tabPg_RgbInterface
            // 
            this.tabPg_RgbInterface.Controls.Add(this.groupBox12);
            this.tabPg_RgbInterface.Controls.Add(this.gbx_dataBusType);
            this.tabPg_RgbInterface.Controls.Add(this.gbx_rgbInterface);
            this.tabPg_RgbInterface.Location = new System.Drawing.Point(4, 23);
            this.tabPg_RgbInterface.Name = "tabPg_RgbInterface";
            this.tabPg_RgbInterface.Size = new System.Drawing.Size(707, 515);
            this.tabPg_RgbInterface.TabIndex = 6;
            this.tabPg_RgbInterface.Text = "RGB Interface";
            this.tabPg_RgbInterface.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.pic_showDataBus);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox12.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(193, 84);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(514, 431);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Show Type";
            // 
            // pic_showDataBus
            // 
            this.pic_showDataBus.BackColor = System.Drawing.Color.Gainsboro;
            this.pic_showDataBus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_showDataBus.Image = global::SC_Tek_Studio_Pro.Properties.Resources.RGB_DATA_BUS;
            this.pic_showDataBus.InitialImage = global::SC_Tek_Studio_Pro.Properties.Resources.RGB_DATA_BUS;
            this.pic_showDataBus.Location = new System.Drawing.Point(3, 20);
            this.pic_showDataBus.Name = "pic_showDataBus";
            this.pic_showDataBus.Size = new System.Drawing.Size(508, 408);
            this.pic_showDataBus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_showDataBus.TabIndex = 0;
            this.pic_showDataBus.TabStop = false;
            // 
            // gbx_dataBusType
            // 
            this.gbx_dataBusType.Controls.Add(this.rbtn_24bitD23);
            this.gbx_dataBusType.Controls.Add(this.rbtn_18bitD21);
            this.gbx_dataBusType.Controls.Add(this.rbtn_18bitD17);
            this.gbx_dataBusType.Controls.Add(this.rbtn_16bitD21);
            this.gbx_dataBusType.Controls.Add(this.rbtn_16bitD17);
            this.gbx_dataBusType.Controls.Add(this.rbtn_16bitD15);
            this.gbx_dataBusType.Controls.Add(this.rbtn_8bit);
            this.gbx_dataBusType.Controls.Add(this.rbtn_6bit);
            this.gbx_dataBusType.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbx_dataBusType.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_dataBusType.Location = new System.Drawing.Point(0, 84);
            this.gbx_dataBusType.Name = "gbx_dataBusType";
            this.gbx_dataBusType.Size = new System.Drawing.Size(193, 431);
            this.gbx_dataBusType.TabIndex = 1;
            this.gbx_dataBusType.TabStop = false;
            this.gbx_dataBusType.Text = "Data Bus Type";
            // 
            // rbtn_24bitD23
            // 
            this.rbtn_24bitD23.AutoSize = true;
            this.rbtn_24bitD23.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_24bitD23.Location = new System.Drawing.Point(23, 305);
            this.rbtn_24bitD23.Name = "rbtn_24bitD23";
            this.rbtn_24bitD23.Size = new System.Drawing.Size(116, 21);
            this.rbtn_24bitD23.TabIndex = 8;
            this.rbtn_24bitD23.Text = "24 bit_[D23:D0]";
            this.rbtn_24bitD23.UseVisualStyleBackColor = true;
            this.rbtn_24bitD23.CheckedChanged += new System.EventHandler(this.rbtn_6bit_CheckedChanged);
            // 
            // rbtn_18bitD21
            // 
            this.rbtn_18bitD21.AutoSize = true;
            this.rbtn_18bitD21.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_18bitD21.Location = new System.Drawing.Point(23, 265);
            this.rbtn_18bitD21.Name = "rbtn_18bitD21";
            this.rbtn_18bitD21.Size = new System.Drawing.Size(120, 21);
            this.rbtn_18bitD21.TabIndex = 7;
            this.rbtn_18bitD21.Text = "18bit_[D21:D16]";
            this.rbtn_18bitD21.UseVisualStyleBackColor = true;
            this.rbtn_18bitD21.CheckedChanged += new System.EventHandler(this.rbtn_6bit_CheckedChanged);
            // 
            // rbtn_18bitD17
            // 
            this.rbtn_18bitD17.AutoSize = true;
            this.rbtn_18bitD17.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_18bitD17.Location = new System.Drawing.Point(23, 237);
            this.rbtn_18bitD17.Name = "rbtn_18bitD17";
            this.rbtn_18bitD17.Size = new System.Drawing.Size(116, 21);
            this.rbtn_18bitD17.TabIndex = 6;
            this.rbtn_18bitD17.Text = "18 bit_[D17:D0]";
            this.rbtn_18bitD17.UseVisualStyleBackColor = true;
            this.rbtn_18bitD17.CheckedChanged += new System.EventHandler(this.rbtn_6bit_CheckedChanged);
            // 
            // rbtn_16bitD21
            // 
            this.rbtn_16bitD21.AutoSize = true;
            this.rbtn_16bitD21.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_16bitD21.Location = new System.Drawing.Point(23, 194);
            this.rbtn_16bitD21.Name = "rbtn_16bitD21";
            this.rbtn_16bitD21.Size = new System.Drawing.Size(58, 21);
            this.rbtn_16bitD21.TabIndex = 5;
            this.rbtn_16bitD21.Text = "16 bit";
            this.rbtn_16bitD21.UseVisualStyleBackColor = true;
            this.rbtn_16bitD21.CheckedChanged += new System.EventHandler(this.rbtn_6bit_CheckedChanged);
            // 
            // rbtn_16bitD17
            // 
            this.rbtn_16bitD17.AutoSize = true;
            this.rbtn_16bitD17.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_16bitD17.Location = new System.Drawing.Point(23, 163);
            this.rbtn_16bitD17.Name = "rbtn_16bitD17";
            this.rbtn_16bitD17.Size = new System.Drawing.Size(58, 21);
            this.rbtn_16bitD17.TabIndex = 4;
            this.rbtn_16bitD17.Text = "16 bit";
            this.rbtn_16bitD17.UseVisualStyleBackColor = true;
            this.rbtn_16bitD17.CheckedChanged += new System.EventHandler(this.rbtn_6bit_CheckedChanged);
            // 
            // rbtn_16bitD15
            // 
            this.rbtn_16bitD15.AutoSize = true;
            this.rbtn_16bitD15.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_16bitD15.Location = new System.Drawing.Point(23, 132);
            this.rbtn_16bitD15.Name = "rbtn_16bitD15";
            this.rbtn_16bitD15.Size = new System.Drawing.Size(116, 21);
            this.rbtn_16bitD15.TabIndex = 3;
            this.rbtn_16bitD15.Text = "16 bit_[D15:D0]";
            this.rbtn_16bitD15.UseVisualStyleBackColor = true;
            this.rbtn_16bitD15.CheckedChanged += new System.EventHandler(this.rbtn_6bit_CheckedChanged);
            // 
            // rbtn_8bit
            // 
            this.rbtn_8bit.AutoSize = true;
            this.rbtn_8bit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_8bit.Location = new System.Drawing.Point(23, 73);
            this.rbtn_8bit.Name = "rbtn_8bit";
            this.rbtn_8bit.Size = new System.Drawing.Size(102, 21);
            this.rbtn_8bit.TabIndex = 2;
            this.rbtn_8bit.Text = "8 bit_[D7:D0]";
            this.rbtn_8bit.UseVisualStyleBackColor = true;
            this.rbtn_8bit.CheckedChanged += new System.EventHandler(this.rbtn_6bit_CheckedChanged);
            // 
            // rbtn_6bit
            // 
            this.rbtn_6bit.AutoSize = true;
            this.rbtn_6bit.Checked = true;
            this.rbtn_6bit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_6bit.Location = new System.Drawing.Point(23, 45);
            this.rbtn_6bit.Name = "rbtn_6bit";
            this.rbtn_6bit.Size = new System.Drawing.Size(116, 21);
            this.rbtn_6bit.TabIndex = 1;
            this.rbtn_6bit.TabStop = true;
            this.rbtn_6bit.Text = "6 bit_[D17:D12]";
            this.rbtn_6bit.UseVisualStyleBackColor = true;
            this.rbtn_6bit.CheckedChanged += new System.EventHandler(this.rbtn_6bit_CheckedChanged);
            // 
            // gbx_rgbInterface
            // 
            this.gbx_rgbInterface.Controls.Add(this.rbtn_DeMod);
            this.gbx_rgbInterface.Controls.Add(this.rbtn_HsVsMod);
            this.gbx_rgbInterface.Controls.Add(this.rbtn_HsVsDeMod);
            this.gbx_rgbInterface.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbx_rgbInterface.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_rgbInterface.Location = new System.Drawing.Point(0, 0);
            this.gbx_rgbInterface.Name = "gbx_rgbInterface";
            this.gbx_rgbInterface.Size = new System.Drawing.Size(707, 84);
            this.gbx_rgbInterface.TabIndex = 0;
            this.gbx_rgbInterface.TabStop = false;
            this.gbx_rgbInterface.Text = "RGB Interface Type";
            // 
            // rbtn_DeMod
            // 
            this.rbtn_DeMod.AutoSize = true;
            this.rbtn_DeMod.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_DeMod.Location = new System.Drawing.Point(443, 36);
            this.rbtn_DeMod.Name = "rbtn_DeMod";
            this.rbtn_DeMod.Size = new System.Drawing.Size(78, 21);
            this.rbtn_DeMod.TabIndex = 2;
            this.rbtn_DeMod.Text = "DE Mode";
            this.rbtn_DeMod.UseVisualStyleBackColor = true;
            // 
            // rbtn_HsVsMod
            // 
            this.rbtn_HsVsMod.AutoSize = true;
            this.rbtn_HsVsMod.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_HsVsMod.Location = new System.Drawing.Point(268, 36);
            this.rbtn_HsVsMod.Name = "rbtn_HsVsMod";
            this.rbtn_HsVsMod.Size = new System.Drawing.Size(60, 21);
            this.rbtn_HsVsMod.TabIndex = 1;
            this.rbtn_HsVsMod.Text = "HS/VS";
            this.rbtn_HsVsMod.UseVisualStyleBackColor = true;
            // 
            // rbtn_HsVsDeMod
            // 
            this.rbtn_HsVsDeMod.AutoSize = true;
            this.rbtn_HsVsDeMod.Checked = true;
            this.rbtn_HsVsDeMod.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_HsVsDeMod.Location = new System.Drawing.Point(69, 36);
            this.rbtn_HsVsDeMod.Name = "rbtn_HsVsDeMod";
            this.rbtn_HsVsDeMod.Size = new System.Drawing.Size(83, 21);
            this.rbtn_HsVsDeMod.TabIndex = 0;
            this.rbtn_HsVsDeMod.TabStop = true;
            this.rbtn_HsVsDeMod.Text = "HS/VS+DE";
            this.rbtn_HsVsDeMod.UseVisualStyleBackColor = true;
            // 
            // tabPg_Mipi
            // 
            this.tabPg_Mipi.Location = new System.Drawing.Point(4, 23);
            this.tabPg_Mipi.Name = "tabPg_Mipi";
            this.tabPg_Mipi.Size = new System.Drawing.Size(707, 515);
            this.tabPg_Mipi.TabIndex = 5;
            this.tabPg_Mipi.Text = "MIPI";
            this.tabPg_Mipi.UseVisualStyleBackColor = true;
            // 
            // tabPg_SPI
            // 
            this.tabPg_SPI.Controls.Add(this.gbx_SpiRdFunc);
            this.tabPg_SPI.Controls.Add(this.gbx_SpiSpeed);
            this.tabPg_SPI.Controls.Add(this.gbx_SpiType);
            this.tabPg_SPI.Location = new System.Drawing.Point(4, 23);
            this.tabPg_SPI.Name = "tabPg_SPI";
            this.tabPg_SPI.Size = new System.Drawing.Size(707, 515);
            this.tabPg_SPI.TabIndex = 3;
            this.tabPg_SPI.Text = "SPI";
            this.tabPg_SPI.UseVisualStyleBackColor = true;
            // 
            // gbx_SpiRdFunc
            // 
            this.gbx_SpiRdFunc.Controls.Add(this.rbtn_SpiRdW);
            this.gbx_SpiRdFunc.Controls.Add(this.rbtn_SpiRdWandO);
            this.gbx_SpiRdFunc.Controls.Add(this.pic_showSpi);
            this.gbx_SpiRdFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_SpiRdFunc.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_SpiRdFunc.Location = new System.Drawing.Point(0, 161);
            this.gbx_SpiRdFunc.Name = "gbx_SpiRdFunc";
            this.gbx_SpiRdFunc.Size = new System.Drawing.Size(707, 188);
            this.gbx_SpiRdFunc.TabIndex = 6;
            this.gbx_SpiRdFunc.TabStop = false;
            this.gbx_SpiRdFunc.Text = "SPI Read Function";
            // 
            // rbtn_SpiRdW
            // 
            this.rbtn_SpiRdW.AutoSize = true;
            this.rbtn_SpiRdW.Location = new System.Drawing.Point(367, 25);
            this.rbtn_SpiRdW.Name = "rbtn_SpiRdW";
            this.rbtn_SpiRdW.Size = new System.Drawing.Size(136, 21);
            this.rbtn_SpiRdW.TabIndex = 2;
            this.rbtn_SpiRdW.Text = "Read w/ dummy clk";
            this.rbtn_SpiRdW.UseVisualStyleBackColor = true;
            this.rbtn_SpiRdW.CheckedChanged += new System.EventHandler(this.rbtn_SpiRdWandO_CheckedChanged);
            // 
            // rbtn_SpiRdWandO
            // 
            this.rbtn_SpiRdWandO.AutoSize = true;
            this.rbtn_SpiRdWandO.Checked = true;
            this.rbtn_SpiRdWandO.Location = new System.Drawing.Point(127, 25);
            this.rbtn_SpiRdWandO.Name = "rbtn_SpiRdWandO";
            this.rbtn_SpiRdWandO.Size = new System.Drawing.Size(143, 21);
            this.rbtn_SpiRdWandO.TabIndex = 1;
            this.rbtn_SpiRdWandO.TabStop = true;
            this.rbtn_SpiRdWandO.Text = "Read w/o dummy clk";
            this.rbtn_SpiRdWandO.UseVisualStyleBackColor = true;
            this.rbtn_SpiRdWandO.CheckedChanged += new System.EventHandler(this.rbtn_SpiRdWandO_CheckedChanged);
            // 
            // pic_showSpi
            // 
            this.pic_showSpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_showSpi.Image = global::SC_Tek_Studio_Pro.Properties.Resources.spi_rd_wdmy;
            this.pic_showSpi.Location = new System.Drawing.Point(3, 20);
            this.pic_showSpi.Name = "pic_showSpi";
            this.pic_showSpi.Size = new System.Drawing.Size(701, 165);
            this.pic_showSpi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_showSpi.TabIndex = 0;
            this.pic_showSpi.TabStop = false;
            // 
            // gbx_SpiSpeed
            // 
            this.gbx_SpiSpeed.Controls.Add(this.lbl_shwSckH);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_shwSckL);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_SckMhz);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_SckFreqVal);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_shwSckFreq);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_shwSck);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_shwSysClk);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_shwSysClkMhz);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_shwSpiSysClk);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_spiSysClk);
            this.gbx_SpiSpeed.Controls.Add(this.txt_SpiSysClk);
            this.gbx_SpiSpeed.Controls.Add(this.txt_SpiSckH);
            this.gbx_SpiSpeed.Controls.Add(this.txt_SpiSckL);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_shwSysClkVal);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_shwSckHVal);
            this.gbx_SpiSpeed.Controls.Add(this.lbl_shwScklVal);
            this.gbx_SpiSpeed.Controls.Add(this.pic_setSpiSpeed);
            this.gbx_SpiSpeed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbx_SpiSpeed.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_SpiSpeed.Location = new System.Drawing.Point(0, 349);
            this.gbx_SpiSpeed.Name = "gbx_SpiSpeed";
            this.gbx_SpiSpeed.Size = new System.Drawing.Size(707, 166);
            this.gbx_SpiSpeed.TabIndex = 5;
            this.gbx_SpiSpeed.TabStop = false;
            this.gbx_SpiSpeed.Text = "SPI SCK Speed Setting";
            // 
            // lbl_shwSckH
            // 
            this.lbl_shwSckH.AutoSize = true;
            this.lbl_shwSckH.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_shwSckH.Location = new System.Drawing.Point(281, 77);
            this.lbl_shwSckH.Name = "lbl_shwSckH";
            this.lbl_shwSckH.Size = new System.Drawing.Size(31, 19);
            this.lbl_shwSckH.TabIndex = 22;
            this.lbl_shwSckH.Text = "\"H\"";
            // 
            // lbl_shwSckL
            // 
            this.lbl_shwSckL.AutoSize = true;
            this.lbl_shwSckL.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_shwSckL.Location = new System.Drawing.Point(160, 74);
            this.lbl_shwSckL.Name = "lbl_shwSckL";
            this.lbl_shwSckL.Size = new System.Drawing.Size(28, 19);
            this.lbl_shwSckL.TabIndex = 21;
            this.lbl_shwSckL.Text = "\"L\"";
            // 
            // lbl_SckMhz
            // 
            this.lbl_SckMhz.AutoSize = true;
            this.lbl_SckMhz.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SckMhz.Location = new System.Drawing.Point(344, 117);
            this.lbl_SckMhz.Name = "lbl_SckMhz";
            this.lbl_SckMhz.Size = new System.Drawing.Size(33, 17);
            this.lbl_SckMhz.TabIndex = 14;
            this.lbl_SckMhz.Text = "Mhz";
            // 
            // lbl_SckFreqVal
            // 
            this.lbl_SckFreqVal.AutoSize = true;
            this.lbl_SckFreqVal.Location = new System.Drawing.Point(123, 117);
            this.lbl_SckFreqVal.Name = "lbl_SckFreqVal";
            this.lbl_SckFreqVal.Size = new System.Drawing.Size(29, 17);
            this.lbl_SckFreqVal.TabIndex = 13;
            this.lbl_SckFreqVal.Text = "XXX";
            // 
            // lbl_shwSckFreq
            // 
            this.lbl_shwSckFreq.AutoSize = true;
            this.lbl_shwSckFreq.Location = new System.Drawing.Point(20, 117);
            this.lbl_shwSckFreq.Name = "lbl_shwSckFreq";
            this.lbl_shwSckFreq.Size = new System.Drawing.Size(60, 17);
            this.lbl_shwSckFreq.TabIndex = 12;
            this.lbl_shwSckFreq.Text = "SCK Freq:";
            // 
            // lbl_shwSck
            // 
            this.lbl_shwSck.AutoSize = true;
            this.lbl_shwSck.Location = new System.Drawing.Point(25, 77);
            this.lbl_shwSck.Name = "lbl_shwSck";
            this.lbl_shwSck.Size = new System.Drawing.Size(32, 17);
            this.lbl_shwSck.TabIndex = 11;
            this.lbl_shwSck.Text = "SCK:";
            // 
            // lbl_shwSysClk
            // 
            this.lbl_shwSysClk.AutoSize = true;
            this.lbl_shwSysClk.Location = new System.Drawing.Point(25, 42);
            this.lbl_shwSysClk.Name = "lbl_shwSysClk";
            this.lbl_shwSysClk.Size = new System.Drawing.Size(55, 17);
            this.lbl_shwSysClk.TabIndex = 10;
            this.lbl_shwSysClk.Text = "Sys.Clk : ";
            // 
            // lbl_shwSysClkMhz
            // 
            this.lbl_shwSysClkMhz.AutoSize = true;
            this.lbl_shwSysClkMhz.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_shwSysClkMhz.Location = new System.Drawing.Point(640, 117);
            this.lbl_shwSysClkMhz.Name = "lbl_shwSysClkMhz";
            this.lbl_shwSysClkMhz.Size = new System.Drawing.Size(33, 17);
            this.lbl_shwSysClkMhz.TabIndex = 9;
            this.lbl_shwSysClkMhz.Text = "Mhz";
            // 
            // lbl_shwSpiSysClk
            // 
            this.lbl_shwSpiSysClk.AutoSize = true;
            this.lbl_shwSpiSysClk.Location = new System.Drawing.Point(640, 77);
            this.lbl_shwSpiSysClk.Name = "lbl_shwSpiSysClk";
            this.lbl_shwSpiSysClk.Size = new System.Drawing.Size(53, 17);
            this.lbl_shwSpiSysClk.TabIndex = 8;
            this.lbl_shwSpiSysClk.Text = "/ Sys.Clk";
            // 
            // lbl_spiSysClk
            // 
            this.lbl_spiSysClk.AutoSize = true;
            this.lbl_spiSysClk.Location = new System.Drawing.Point(638, 38);
            this.lbl_spiSysClk.Name = "lbl_spiSysClk";
            this.lbl_spiSysClk.Size = new System.Drawing.Size(53, 17);
            this.lbl_spiSysClk.TabIndex = 7;
            this.lbl_spiSysClk.Text = "/ Sys.Clk";
            // 
            // txt_SpiSysClk
            // 
            this.txt_SpiSysClk.Location = new System.Drawing.Point(534, 114);
            this.txt_SpiSysClk.Name = "txt_SpiSysClk";
            this.txt_SpiSysClk.Size = new System.Drawing.Size(100, 24);
            this.txt_SpiSysClk.TabIndex = 6;
            this.txt_SpiSysClk.Text = "0";
            this.txt_SpiSysClk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            // 
            // txt_SpiSckH
            // 
            this.txt_SpiSckH.Location = new System.Drawing.Point(534, 77);
            this.txt_SpiSckH.Name = "txt_SpiSckH";
            this.txt_SpiSckH.Size = new System.Drawing.Size(100, 24);
            this.txt_SpiSckH.TabIndex = 5;
            this.txt_SpiSckH.Text = "0";
            this.txt_SpiSckH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_SpiSckH.Leave += new System.EventHandler(this.txt_SpiSckL_Leave);
            // 
            // txt_SpiSckL
            // 
            this.txt_SpiSckL.Location = new System.Drawing.Point(534, 35);
            this.txt_SpiSckL.Name = "txt_SpiSckL";
            this.txt_SpiSckL.Size = new System.Drawing.Size(100, 24);
            this.txt_SpiSckL.TabIndex = 4;
            this.txt_SpiSckL.Text = "0";
            this.txt_SpiSckL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_SpiSckL.Leave += new System.EventHandler(this.txt_SpiSckL_Leave);
            // 
            // lbl_shwSysClkVal
            // 
            this.lbl_shwSysClkVal.AutoSize = true;
            this.lbl_shwSysClkVal.Location = new System.Drawing.Point(431, 117);
            this.lbl_shwSysClkVal.Name = "lbl_shwSysClkVal";
            this.lbl_shwSysClkVal.Size = new System.Drawing.Size(71, 17);
            this.lbl_shwSysClkVal.TabIndex = 3;
            this.lbl_shwSysClkVal.Text = "Sys.Clock = ";
            // 
            // lbl_shwSckHVal
            // 
            this.lbl_shwSckHVal.AutoSize = true;
            this.lbl_shwSckHVal.Location = new System.Drawing.Point(435, 77);
            this.lbl_shwSckHVal.Name = "lbl_shwSckHVal";
            this.lbl_shwSckHVal.Size = new System.Drawing.Size(65, 17);
            this.lbl_shwSckHVal.TabIndex = 2;
            this.lbl_shwSckHVal.Text = "SCK \"H\" = ";
            // 
            // lbl_shwScklVal
            // 
            this.lbl_shwScklVal.AutoSize = true;
            this.lbl_shwScklVal.Location = new System.Drawing.Point(435, 38);
            this.lbl_shwScklVal.Name = "lbl_shwScklVal";
            this.lbl_shwScklVal.Size = new System.Drawing.Size(62, 17);
            this.lbl_shwScklVal.TabIndex = 1;
            this.lbl_shwScklVal.Text = "SCK \"L\" = ";
            // 
            // pic_setSpiSpeed
            // 
            this.pic_setSpiSpeed.Image = global::SC_Tek_Studio_Pro.Properties.Resources.spi_sck_speed;
            this.pic_setSpiSpeed.Location = new System.Drawing.Point(18, 24);
            this.pic_setSpiSpeed.Name = "pic_setSpiSpeed";
            this.pic_setSpiSpeed.Size = new System.Drawing.Size(407, 129);
            this.pic_setSpiSpeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_setSpiSpeed.TabIndex = 0;
            this.pic_setSpiSpeed.TabStop = false;
            // 
            // gbx_SpiType
            // 
            this.gbx_SpiType.Controls.Add(this.pic_showSpiType);
            this.gbx_SpiType.Controls.Add(this.rbtn_spi3wire);
            this.gbx_SpiType.Controls.Add(this.rbtn_spi4wire);
            this.gbx_SpiType.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbx_SpiType.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_SpiType.Location = new System.Drawing.Point(0, 0);
            this.gbx_SpiType.Name = "gbx_SpiType";
            this.gbx_SpiType.Size = new System.Drawing.Size(707, 161);
            this.gbx_SpiType.TabIndex = 4;
            this.gbx_SpiType.TabStop = false;
            this.gbx_SpiType.Text = "SPI Interface Type";
            // 
            // pic_showSpiType
            // 
            this.pic_showSpiType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pic_showSpiType.Image = global::SC_Tek_Studio_Pro.Properties.Resources.spi_4w8b;
            this.pic_showSpiType.Location = new System.Drawing.Point(3, 59);
            this.pic_showSpiType.Name = "pic_showSpiType";
            this.pic_showSpiType.Size = new System.Drawing.Size(701, 99);
            this.pic_showSpiType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_showSpiType.TabIndex = 2;
            this.pic_showSpiType.TabStop = false;
            // 
            // rbtn_spi3wire
            // 
            this.rbtn_spi3wire.AutoSize = true;
            this.rbtn_spi3wire.Location = new System.Drawing.Point(367, 28);
            this.rbtn_spi3wire.Name = "rbtn_spi3wire";
            this.rbtn_spi3wire.Size = new System.Drawing.Size(179, 21);
            this.rbtn_spi3wire.TabIndex = 1;
            this.rbtn_spi3wire.Text = "3 wire, write 9bit/read 8bit";
            this.rbtn_spi3wire.UseVisualStyleBackColor = true;
            this.rbtn_spi3wire.CheckedChanged += new System.EventHandler(this.rbtn_spi4wire_CheckedChanged);
            // 
            // rbtn_spi4wire
            // 
            this.rbtn_spi4wire.AutoSize = true;
            this.rbtn_spi4wire.Checked = true;
            this.rbtn_spi4wire.Location = new System.Drawing.Point(127, 28);
            this.rbtn_spi4wire.Name = "rbtn_spi4wire";
            this.rbtn_spi4wire.Size = new System.Drawing.Size(157, 21);
            this.rbtn_spi4wire.TabIndex = 0;
            this.rbtn_spi4wire.TabStop = true;
            this.rbtn_spi4wire.Text = "4 wire , write/read 8bit";
            this.rbtn_spi4wire.UseVisualStyleBackColor = true;
            this.rbtn_spi4wire.CheckedChanged += new System.EventHandler(this.rbtn_spi4wire_CheckedChanged);
            // 
            // tabPg_I2C
            // 
            this.tabPg_I2C.Controls.Add(this.gbx_setI2CTiming);
            this.tabPg_I2C.Location = new System.Drawing.Point(4, 23);
            this.tabPg_I2C.Name = "tabPg_I2C";
            this.tabPg_I2C.Size = new System.Drawing.Size(707, 511);
            this.tabPg_I2C.TabIndex = 4;
            this.tabPg_I2C.Text = "I2C";
            this.tabPg_I2C.UseVisualStyleBackColor = true;
            // 
            // gbx_setI2CTiming
            // 
            this.gbx_setI2CTiming.Controls.Add(this.panel3);
            this.gbx_setI2CTiming.Controls.Add(this.panel2);
            this.gbx_setI2CTiming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_setI2CTiming.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_setI2CTiming.Location = new System.Drawing.Point(0, 0);
            this.gbx_setI2CTiming.Name = "gbx_setI2CTiming";
            this.gbx_setI2CTiming.Size = new System.Drawing.Size(707, 511);
            this.gbx_setI2CTiming.TabIndex = 0;
            this.gbx_setI2CTiming.TabStop = false;
            this.gbx_setI2CTiming.Text = "I2C Timing Setting";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pic_i2cSetGraph);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(701, 318);
            this.panel3.TabIndex = 1;
            // 
            // pic_i2cSetGraph
            // 
            this.pic_i2cSetGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_i2cSetGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_i2cSetGraph.Image = global::SC_Tek_Studio_Pro.Properties.Resources.i2c_timing;
            this.pic_i2cSetGraph.Location = new System.Drawing.Point(0, 0);
            this.pic_i2cSetGraph.Name = "pic_i2cSetGraph";
            this.pic_i2cSetGraph.Size = new System.Drawing.Size(701, 318);
            this.pic_i2cSetGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_i2cSetGraph.TabIndex = 0;
            this.pic_i2cSetGraph.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbl_i2csckL);
            this.panel2.Controls.Add(this.lbl_i2csckH);
            this.panel2.Controls.Add(this.lbl_seti2Mhz);
            this.panel2.Controls.Add(this.lbl_shwI2cFreqVal);
            this.panel2.Controls.Add(this.lbl_shwi2cSckFreq);
            this.panel2.Controls.Add(this.lbl_shwI2CSck);
            this.panel2.Controls.Add(this.lbl_shwi2cSysClk);
            this.panel2.Controls.Add(this.pic_setI2cTiming);
            this.panel2.Controls.Add(this.lbl_shwi2cMhz);
            this.panel2.Controls.Add(this.lbl_shwdivideClk);
            this.panel2.Controls.Add(this.lbl_i2cTimeSysClk);
            this.panel2.Controls.Add(this.txt_i2cSysClk);
            this.panel2.Controls.Add(this.txt_i2cSckH);
            this.panel2.Controls.Add(this.txt_i2cSckL);
            this.panel2.Controls.Add(this.lbl_i2cshowSysClk);
            this.panel2.Controls.Add(this.lbl_shwi2cSckH);
            this.panel2.Controls.Add(this.lbl_shwi2cSckL);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(701, 170);
            this.panel2.TabIndex = 0;
            // 
            // lbl_i2csckL
            // 
            this.lbl_i2csckL.AutoSize = true;
            this.lbl_i2csckL.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_i2csckL.Location = new System.Drawing.Point(278, 71);
            this.lbl_i2csckL.Name = "lbl_i2csckL";
            this.lbl_i2csckL.Size = new System.Drawing.Size(31, 19);
            this.lbl_i2csckL.TabIndex = 29;
            this.lbl_i2csckL.Text = "\"H\"";
            // 
            // lbl_i2csckH
            // 
            this.lbl_i2csckH.AutoSize = true;
            this.lbl_i2csckH.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_i2csckH.Location = new System.Drawing.Point(156, 64);
            this.lbl_i2csckH.Name = "lbl_i2csckH";
            this.lbl_i2csckH.Size = new System.Drawing.Size(28, 19);
            this.lbl_i2csckH.TabIndex = 28;
            this.lbl_i2csckH.Text = "\"L\"";
            // 
            // lbl_seti2Mhz
            // 
            this.lbl_seti2Mhz.AutoSize = true;
            this.lbl_seti2Mhz.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_seti2Mhz.Location = new System.Drawing.Point(332, 110);
            this.lbl_seti2Mhz.Name = "lbl_seti2Mhz";
            this.lbl_seti2Mhz.Size = new System.Drawing.Size(33, 17);
            this.lbl_seti2Mhz.TabIndex = 27;
            this.lbl_seti2Mhz.Text = "Mhz";
            // 
            // lbl_shwI2cFreqVal
            // 
            this.lbl_shwI2cFreqVal.AutoSize = true;
            this.lbl_shwI2cFreqVal.Location = new System.Drawing.Point(144, 110);
            this.lbl_shwI2cFreqVal.Name = "lbl_shwI2cFreqVal";
            this.lbl_shwI2cFreqVal.Size = new System.Drawing.Size(29, 17);
            this.lbl_shwI2cFreqVal.TabIndex = 26;
            this.lbl_shwI2cFreqVal.Text = "XXX";
            // 
            // lbl_shwi2cSckFreq
            // 
            this.lbl_shwi2cSckFreq.AutoSize = true;
            this.lbl_shwi2cSckFreq.Location = new System.Drawing.Point(19, 107);
            this.lbl_shwi2cSckFreq.Name = "lbl_shwi2cSckFreq";
            this.lbl_shwi2cSckFreq.Size = new System.Drawing.Size(60, 17);
            this.lbl_shwi2cSckFreq.TabIndex = 25;
            this.lbl_shwi2cSckFreq.Text = "SCK Freq:";
            // 
            // lbl_shwI2CSck
            // 
            this.lbl_shwI2CSck.AutoSize = true;
            this.lbl_shwI2CSck.Location = new System.Drawing.Point(19, 67);
            this.lbl_shwI2CSck.Name = "lbl_shwI2CSck";
            this.lbl_shwI2CSck.Size = new System.Drawing.Size(32, 17);
            this.lbl_shwI2CSck.TabIndex = 24;
            this.lbl_shwI2CSck.Text = "SCK:";
            // 
            // lbl_shwi2cSysClk
            // 
            this.lbl_shwi2cSysClk.AutoSize = true;
            this.lbl_shwi2cSysClk.Location = new System.Drawing.Point(19, 32);
            this.lbl_shwi2cSysClk.Name = "lbl_shwi2cSysClk";
            this.lbl_shwi2cSysClk.Size = new System.Drawing.Size(55, 17);
            this.lbl_shwi2cSysClk.TabIndex = 23;
            this.lbl_shwi2cSysClk.Text = "Sys.Clk : ";
            // 
            // pic_setI2cTiming
            // 
            this.pic_setI2cTiming.Image = global::SC_Tek_Studio_Pro.Properties.Resources.spi_sck_speed;
            this.pic_setI2cTiming.Location = new System.Drawing.Point(18, 13);
            this.pic_setI2cTiming.Name = "pic_setI2cTiming";
            this.pic_setI2cTiming.Size = new System.Drawing.Size(400, 139);
            this.pic_setI2cTiming.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_setI2cTiming.TabIndex = 22;
            this.pic_setI2cTiming.TabStop = false;
            // 
            // lbl_shwi2cMhz
            // 
            this.lbl_shwi2cMhz.AutoSize = true;
            this.lbl_shwi2cMhz.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_shwi2cMhz.Location = new System.Drawing.Point(626, 107);
            this.lbl_shwi2cMhz.Name = "lbl_shwi2cMhz";
            this.lbl_shwi2cMhz.Size = new System.Drawing.Size(33, 17);
            this.lbl_shwi2cMhz.TabIndex = 18;
            this.lbl_shwi2cMhz.Text = "Mhz";
            // 
            // lbl_shwdivideClk
            // 
            this.lbl_shwdivideClk.AutoSize = true;
            this.lbl_shwdivideClk.Location = new System.Drawing.Point(626, 70);
            this.lbl_shwdivideClk.Name = "lbl_shwdivideClk";
            this.lbl_shwdivideClk.Size = new System.Drawing.Size(53, 17);
            this.lbl_shwdivideClk.TabIndex = 17;
            this.lbl_shwdivideClk.Text = "/ Sys.Clk";
            // 
            // lbl_i2cTimeSysClk
            // 
            this.lbl_i2cTimeSysClk.AutoSize = true;
            this.lbl_i2cTimeSysClk.Location = new System.Drawing.Point(626, 28);
            this.lbl_i2cTimeSysClk.Name = "lbl_i2cTimeSysClk";
            this.lbl_i2cTimeSysClk.Size = new System.Drawing.Size(53, 17);
            this.lbl_i2cTimeSysClk.TabIndex = 16;
            this.lbl_i2cTimeSysClk.Text = "/ Sys.Clk";
            // 
            // txt_i2cSysClk
            // 
            this.txt_i2cSysClk.Location = new System.Drawing.Point(520, 104);
            this.txt_i2cSysClk.Name = "txt_i2cSysClk";
            this.txt_i2cSysClk.Size = new System.Drawing.Size(100, 24);
            this.txt_i2cSysClk.TabIndex = 15;
            this.txt_i2cSysClk.Text = "0";
            // 
            // txt_i2cSckH
            // 
            this.txt_i2cSckH.Location = new System.Drawing.Point(520, 64);
            this.txt_i2cSckH.Name = "txt_i2cSckH";
            this.txt_i2cSckH.Size = new System.Drawing.Size(100, 24);
            this.txt_i2cSckH.TabIndex = 14;
            this.txt_i2cSckH.Text = "0";
            this.txt_i2cSckH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_i2cSckH.Leave += new System.EventHandler(this.txt_SpiSckL_Leave);
            // 
            // txt_i2cSckL
            // 
            this.txt_i2cSckL.Location = new System.Drawing.Point(520, 25);
            this.txt_i2cSckL.Name = "txt_i2cSckL";
            this.txt_i2cSckL.Size = new System.Drawing.Size(100, 24);
            this.txt_i2cSckL.TabIndex = 13;
            this.txt_i2cSckL.Text = "0";
            this.txt_i2cSckL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Hsync_KeyDown);
            this.txt_i2cSckL.Leave += new System.EventHandler(this.txt_SpiSckL_Leave);
            // 
            // lbl_i2cshowSysClk
            // 
            this.lbl_i2cshowSysClk.AutoSize = true;
            this.lbl_i2cshowSysClk.Location = new System.Drawing.Point(424, 107);
            this.lbl_i2cshowSysClk.Name = "lbl_i2cshowSysClk";
            this.lbl_i2cshowSysClk.Size = new System.Drawing.Size(71, 17);
            this.lbl_i2cshowSysClk.TabIndex = 12;
            this.lbl_i2cshowSysClk.Text = "Sys.Clock = ";
            // 
            // lbl_shwi2cSckH
            // 
            this.lbl_shwi2cSckH.AutoSize = true;
            this.lbl_shwi2cSckH.Location = new System.Drawing.Point(433, 67);
            this.lbl_shwi2cSckH.Name = "lbl_shwi2cSckH";
            this.lbl_shwi2cSckH.Size = new System.Drawing.Size(65, 17);
            this.lbl_shwi2cSckH.TabIndex = 11;
            this.lbl_shwi2cSckH.Text = "SCK \"H\" = ";
            // 
            // lbl_shwi2cSckL
            // 
            this.lbl_shwi2cSckL.AutoSize = true;
            this.lbl_shwi2cSckL.Location = new System.Drawing.Point(437, 25);
            this.lbl_shwi2cSckL.Name = "lbl_shwi2cSckL";
            this.lbl_shwi2cSckL.Size = new System.Drawing.Size(62, 17);
            this.lbl_shwi2cSckL.TabIndex = 10;
            this.lbl_shwi2cSckL.Text = "SCK \"L\" = ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(227, 562);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 67);
            this.panel1.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(571, 17);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(95, 32);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(463, 17);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(92, 32);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // tvw_SysConfig
            // 
            this.tvw_SysConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvw_SysConfig.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvw_SysConfig.Location = new System.Drawing.Point(3, 20);
            this.tvw_SysConfig.Name = "tvw_SysConfig";
            treeNode1.Name = "Node0";
            treeNode1.Text = "1.Interface";
            treeNode2.Name = "Node1";
            treeNode2.Text = "2.CPU";
            treeNode3.Name = "Node3";
            treeNode3.Text = "3.1 RGB Timing";
            treeNode4.Name = "Node4";
            treeNode4.Text = "3.2 RGB Interface";
            treeNode5.Name = "Node2";
            treeNode5.Text = "3.RGB";
            treeNode6.Name = "Node5";
            treeNode6.Text = "4.MIPI";
            treeNode7.Name = "Node6";
            treeNode7.Text = "5.SPI";
            treeNode8.Name = "Node7";
            treeNode8.Text = "6.I2C";
            treeNode9.Name = "Node0";
            treeNode9.Text = "Interface";
            this.tvw_SysConfig.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.tvw_SysConfig.Size = new System.Drawing.Size(224, 609);
            this.tvw_SysConfig.TabIndex = 0;
            this.tvw_SysConfig.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // DisplaySetting_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(945, 632);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DisplaySetting_Form";
            this.Text = "DisplaySetting_Form";
            this.groupBox1.ResumeLayout(false);
            this.tabCtrlConfig.ResumeLayout(false);
            this.tabPg_Interface.ResumeLayout(false);
            this.gbx_InitConfig.ResumeLayout(false);
            this.gbx_InitConfig.PerformLayout();
            this.gbx_FpgaSetting.ResumeLayout(false);
            this.gbx_FpgaSetting.PerformLayout();
            this.tabPg_CPU.ResumeLayout(false);
            this.gbx_busDef.ResumeLayout(false);
            this.gbx_busDef.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DataBusDef)).EndInit();
            this.gbx_CpuModeSel.ResumeLayout(false);
            this.gbx_CpuModeSel.PerformLayout();
            this.tabPg_RgbTiming.ResumeLayout(false);
            this.gbx_ShwTimeSet.ResumeLayout(false);
            this.gbx_ShwTimeSet.PerformLayout();
            this.gbx_polarity.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_De)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Vsync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Hsync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Pclk)).EndInit();
            this.gbx_timeset.ResumeLayout(false);
            this.gbx_timeset.PerformLayout();
            this.tabPg_RgbInterface.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_showDataBus)).EndInit();
            this.gbx_dataBusType.ResumeLayout(false);
            this.gbx_dataBusType.PerformLayout();
            this.gbx_rgbInterface.ResumeLayout(false);
            this.gbx_rgbInterface.PerformLayout();
            this.tabPg_SPI.ResumeLayout(false);
            this.gbx_SpiRdFunc.ResumeLayout(false);
            this.gbx_SpiRdFunc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_showSpi)).EndInit();
            this.gbx_SpiSpeed.ResumeLayout(false);
            this.gbx_SpiSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_setSpiSpeed)).EndInit();
            this.gbx_SpiType.ResumeLayout(false);
            this.gbx_SpiType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_showSpiType)).EndInit();
            this.tabPg_I2C.ResumeLayout(false);
            this.gbx_setI2CTiming.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_i2cSetGraph)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_setI2cTiming)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvw_SysConfig;
        private System.Windows.Forms.TabControl tabCtrlConfig;
        private System.Windows.Forms.TabPage tabPg_Interface;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbx_FpgaSetting;
        private System.Windows.Forms.Label lbl_sysClk;
        private System.Windows.Forms.ComboBox cbo_fpgaInterface;
        private System.Windows.Forms.Label lbl_interface;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TabPage tabPg_CPU;
        private System.Windows.Forms.TabPage tabPg_RgbTiming;
        private System.Windows.Forms.TabPage tabPg_SPI;
        private System.Windows.Forms.TabPage tabPg_I2C;
        private System.Windows.Forms.TabPage tabPg_Mipi;
        private System.Windows.Forms.TabPage tabPg_RgbInterface;
        private System.Windows.Forms.GroupBox gbx_InitConfig;
        private System.Windows.Forms.Label lbl_defaultConfig;
        private System.Windows.Forms.Label lbl_loadConfig;
        private System.Windows.Forms.Button btn_setDefault;
        private System.Windows.Forms.Button btn_loadConfig;
        private System.Windows.Forms.TextBox txt_sysClk;
        private System.Windows.Forms.GroupBox gbx_busDef;
        private System.Windows.Forms.PictureBox pic_DataBusDef;
        private System.Windows.Forms.RadioButton rbtn_18bitD17D0;
        private System.Windows.Forms.RadioButton rbtn_18bitD23D0;
        private System.Windows.Forms.RadioButton rbtn_9bitD17D9;
        private System.Windows.Forms.RadioButton rbtn_16bitD15D0;
        private System.Windows.Forms.RadioButton rbtn_17bitD17D10;
        private System.Windows.Forms.RadioButton rbtn_9bitD8D0;
        private System.Windows.Forms.RadioButton rbtn_8bitD17D10;
        private System.Windows.Forms.RadioButton rbtn_8BitD7D0;
        private System.Windows.Forms.GroupBox gbx_CpuModeSel;
        private System.Windows.Forms.RadioButton rbtn_m68;
        private System.Windows.Forms.RadioButton rbtn_I80;
        private System.Windows.Forms.GroupBox gbx_polarity;
        private System.Windows.Forms.GroupBox gbx_timeset;
        private System.Windows.Forms.TextBox txt_Vtotal;
        private System.Windows.Forms.TextBox txt_Vfp;
        private System.Windows.Forms.TextBox txt_Vactive;
        private System.Windows.Forms.TextBox txt_Vbp;
        private System.Windows.Forms.TextBox txt_Vsync;
        private System.Windows.Forms.Label lbl_vtotalPixel;
        private System.Windows.Forms.Label lbl_vfpPixel;
        private System.Windows.Forms.Label lbl_vactivePixel;
        private System.Windows.Forms.Label lbl_vbpPixel;
        private System.Windows.Forms.Label lbl_vsyncPixel;
        private System.Windows.Forms.Label lbl_shwVtotal;
        private System.Windows.Forms.Label lbl_shwVfp;
        private System.Windows.Forms.Label lbl_shwVactive;
        private System.Windows.Forms.Label lbl_shwVbp;
        private System.Windows.Forms.Label lbl_showVsync;
        private System.Windows.Forms.Label lbl_verTiming;
        private System.Windows.Forms.TextBox txt_Htotal;
        private System.Windows.Forms.TextBox txt_Hfp;
        private System.Windows.Forms.TextBox txt_Hactive;
        private System.Windows.Forms.TextBox txt_Hbp;
        private System.Windows.Forms.TextBox txt_Hsync;
        private System.Windows.Forms.Label lbl_htotalPixel;
        private System.Windows.Forms.Label lbl_hfpPixel;
        private System.Windows.Forms.Label lbl_hactivePixel;
        private System.Windows.Forms.Label lbl_hbpPixel;
        private System.Windows.Forms.Label lbl_hsyncPixel;
        private System.Windows.Forms.Label lbl_shwHtotal;
        private System.Windows.Forms.Label lbl_shwHfp;
        private System.Windows.Forms.Label lbl_shwHactive;
        private System.Windows.Forms.Label lbl_shwHbp;
        private System.Windows.Forms.Label lbl_shwHsycn;
        private System.Windows.Forms.Label lbl_hortiming;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txt_PixelClk;
        private System.Windows.Forms.Label lbl_PixelClk;
        private System.Windows.Forms.Label lbl_extClk;
        private System.Windows.Forms.GroupBox gbx_ShwTimeSet;
        private System.Windows.Forms.Label lbl_fpRateVal;
        private System.Windows.Forms.PictureBox pic_De;
        private System.Windows.Forms.PictureBox pic_Vsync;
        private System.Windows.Forms.PictureBox pic_Hsync;
        private System.Windows.Forms.PictureBox pic_Pclk;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox gbx_dataBusType;
        private System.Windows.Forms.RadioButton rbtn_24bitD23;
        private System.Windows.Forms.RadioButton rbtn_18bitD21;
        private System.Windows.Forms.RadioButton rbtn_18bitD17;
        private System.Windows.Forms.RadioButton rbtn_16bitD21;
        private System.Windows.Forms.RadioButton rbtn_16bitD17;
        private System.Windows.Forms.RadioButton rbtn_16bitD15;
        private System.Windows.Forms.RadioButton rbtn_8bit;
        private System.Windows.Forms.RadioButton rbtn_6bit;
        private System.Windows.Forms.GroupBox gbx_rgbInterface;
        private System.Windows.Forms.RadioButton rbtn_DeMod;
        private System.Windows.Forms.RadioButton rbtn_HsVsMod;
        private System.Windows.Forms.RadioButton rbtn_HsVsDeMod;
        private System.Windows.Forms.PictureBox pic_showDataBus;
        private System.Windows.Forms.GroupBox gbx_SpiRdFunc;
        private System.Windows.Forms.RadioButton rbtn_SpiRdW;
        private System.Windows.Forms.RadioButton rbtn_SpiRdWandO;
        private System.Windows.Forms.PictureBox pic_showSpi;
        private System.Windows.Forms.GroupBox gbx_SpiSpeed;
        private System.Windows.Forms.Label lbl_SckMhz;
        private System.Windows.Forms.Label lbl_SckFreqVal;
        private System.Windows.Forms.Label lbl_shwSckFreq;
        private System.Windows.Forms.Label lbl_shwSck;
        private System.Windows.Forms.Label lbl_shwSysClk;
        private System.Windows.Forms.Label lbl_shwSysClkMhz;
        private System.Windows.Forms.Label lbl_shwSpiSysClk;
        private System.Windows.Forms.Label lbl_spiSysClk;
        private System.Windows.Forms.TextBox txt_SpiSysClk;
        private System.Windows.Forms.TextBox txt_SpiSckH;
        private System.Windows.Forms.TextBox txt_SpiSckL;
        private System.Windows.Forms.Label lbl_shwSysClkVal;
        private System.Windows.Forms.Label lbl_shwSckHVal;
        private System.Windows.Forms.Label lbl_shwScklVal;
        private System.Windows.Forms.PictureBox pic_setSpiSpeed;
        private System.Windows.Forms.GroupBox gbx_SpiType;
        private System.Windows.Forms.PictureBox pic_showSpiType;
        private System.Windows.Forms.RadioButton rbtn_spi3wire;
        private System.Windows.Forms.RadioButton rbtn_spi4wire;
        private System.Windows.Forms.GroupBox gbx_setI2CTiming;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_shwSckL;
        private System.Windows.Forms.Label lbl_shwi2cMhz;
        private System.Windows.Forms.Label lbl_shwdivideClk;
        private System.Windows.Forms.Label lbl_i2cTimeSysClk;
        private System.Windows.Forms.TextBox txt_i2cSysClk;
        private System.Windows.Forms.TextBox txt_i2cSckH;
        private System.Windows.Forms.TextBox txt_i2cSckL;
        private System.Windows.Forms.Label lbl_i2cshowSysClk;
        private System.Windows.Forms.Label lbl_shwi2cSckH;
        private System.Windows.Forms.Label lbl_shwi2cSckL;
        private System.Windows.Forms.Label lbl_shwSckH;
        private System.Windows.Forms.PictureBox pic_i2cSetGraph;
        private System.Windows.Forms.Label lbl_i2csckL;
        private System.Windows.Forms.Label lbl_i2csckH;
        private System.Windows.Forms.Label lbl_seti2Mhz;
        private System.Windows.Forms.Label lbl_shwI2cFreqVal;
        private System.Windows.Forms.Label lbl_shwi2cSckFreq;
        private System.Windows.Forms.Label lbl_shwI2CSck;
        private System.Windows.Forms.Label lbl_shwi2cSysClk;
        private System.Windows.Forms.PictureBox pic_setI2cTiming;
        private System.Windows.Forms.Label lbl_HfpVal;
        private System.Windows.Forms.Label lbl_HactiveVal;
        private System.Windows.Forms.Label lbl_HbpVal;
        private System.Windows.Forms.Label lbl_HsyncVal;
        private System.Windows.Forms.Label lbl_VfpVal;
        private System.Windows.Forms.Label lbl_VactiveVal;
        private System.Windows.Forms.Label lbl_VbpVal;
        private System.Windows.Forms.Label lbl_VsyncVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_PixelClkVal;
        private System.Windows.Forms.Label lbl_ScanRateVal;
        private System.Windows.Forms.Label lbl_pixelCkMhz;
        private System.Windows.Forms.Label lbl_FpgaSysClk;
    }
}
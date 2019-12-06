namespace XM_Tek_Studio_Pro
{
    partial class InterfaceSetting_Form
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1.Interface");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2.CPU");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("3.RGB Timing");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("4.RGB Interface");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("5.SPI_1");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("6.SPI_2");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("6.I2C");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("7.Finish");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterfaceSetting_Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TabCtrlf = new System.Windows.Forms.TabControl();
            this.TabPg_Interface = new System.Windows.Forms.TabPage();
            this.gbx_InitConfig = new System.Windows.Forms.GroupBox();
            this.LblFileName = new System.Windows.Forms.Label();
            this.BtnSetDefault = new System.Windows.Forms.Button();
            this.BtnLoadConfig = new System.Windows.Forms.Button();
            this.lbl_defaultConfig = new System.Windows.Forms.Label();
            this.lbl_loadConfig = new System.Windows.Forms.Label();
            this.gbx_FpgaSetting = new System.Windows.Forms.GroupBox();
            this.lbl_FpgaSysClk = new System.Windows.Forms.Label();
            this.TxtSysClk = new System.Windows.Forms.TextBox();
            this.lbl_sysClk = new System.Windows.Forms.Label();
            this.CboFpgaIf = new System.Windows.Forms.ComboBox();
            this.lbl_interface = new System.Windows.Forms.Label();
            this.TabPg_CPU = new System.Windows.Forms.TabPage();
            this.gbx_busDef = new System.Windows.Forms.GroupBox();
            this.pic_DataBusDef = new System.Windows.Forms.PictureBox();
            this.Rbtn_18bitD17D0 = new System.Windows.Forms.RadioButton();
            this.Rbtn_18bitD23D0 = new System.Windows.Forms.RadioButton();
            this.Rbtn_9bitD17D9 = new System.Windows.Forms.RadioButton();
            this.Rbtn_16bitD15D0 = new System.Windows.Forms.RadioButton();
            this.Rbtn_16bitD17D10D8D1 = new System.Windows.Forms.RadioButton();
            this.Rbtn_9bitD8D0 = new System.Windows.Forms.RadioButton();
            this.Rbtn_8bitD17D10 = new System.Windows.Forms.RadioButton();
            this.Rbtn_8BitD7D0 = new System.Windows.Forms.RadioButton();
            this.gbx_CpuModeSel = new System.Windows.Forms.GroupBox();
            this.RbtnM68 = new System.Windows.Forms.RadioButton();
            this.RbtnI80 = new System.Windows.Forms.RadioButton();
            this.TabPg_RgbTiming = new System.Windows.Forms.TabPage();
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
            this.TxtPixelClk = new System.Windows.Forms.TextBox();
            this.lbl_PixelClk = new System.Windows.Forms.Label();
            this.lbl_extClk = new System.Windows.Forms.Label();
            this.TxtVSyncSum = new System.Windows.Forms.TextBox();
            this.TxtVfp = new System.Windows.Forms.TextBox();
            this.TxtVactive = new System.Windows.Forms.TextBox();
            this.TxtVbp = new System.Windows.Forms.TextBox();
            this.TxtVsync = new System.Windows.Forms.TextBox();
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
            this.TxtHSyncSum = new System.Windows.Forms.TextBox();
            this.TxtHfp = new System.Windows.Forms.TextBox();
            this.TxtHactive = new System.Windows.Forms.TextBox();
            this.TxtHbp = new System.Windows.Forms.TextBox();
            this.TxtHsync = new System.Windows.Forms.TextBox();
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
            this.TabPg_RgbInterface = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.pic_showDataBus = new System.Windows.Forms.PictureBox();
            this.gbx_dataBusType = new System.Windows.Forms.GroupBox();
            this.Rbtn_24bitD23 = new System.Windows.Forms.RadioButton();
            this.Rbtn_18bitD21 = new System.Windows.Forms.RadioButton();
            this.Rbtn_18bitD17 = new System.Windows.Forms.RadioButton();
            this.Rbtn_16bitD21 = new System.Windows.Forms.RadioButton();
            this.Rbtn_16bitD17 = new System.Windows.Forms.RadioButton();
            this.Rbtn_16bitD15 = new System.Windows.Forms.RadioButton();
            this.Rbtn_8bit = new System.Windows.Forms.RadioButton();
            this.Rbtn_6bit = new System.Windows.Forms.RadioButton();
            this.gbx_rgbInterface = new System.Windows.Forms.GroupBox();
            this.Rbtn_DeMod = new System.Windows.Forms.RadioButton();
            this.Rbtn_HsVsMod = new System.Windows.Forms.RadioButton();
            this.Rbtn_HsVsDeMod = new System.Windows.Forms.RadioButton();
            this.TabPg_SPI_1 = new System.Windows.Forms.TabPage();
            this.Gbx_SpiRdSck = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_SckRdFreqVal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtSpiRdSysClk = new System.Windows.Forms.TextBox();
            this.TxtSpiRdSckH = new System.Windows.Forms.TextBox();
            this.TxtSpiRdSckL = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.PicSpiRdClk = new System.Windows.Forms.PictureBox();
            this.Gbx_SpiWrSck = new System.Windows.Forms.GroupBox();
            this.lbl_shwSckH = new System.Windows.Forms.Label();
            this.lbl_shwSckL = new System.Windows.Forms.Label();
            this.lbl_SckMhz = new System.Windows.Forms.Label();
            this.lbl_SckWrFreqVal = new System.Windows.Forms.Label();
            this.lbl_shwSckFreq = new System.Windows.Forms.Label();
            this.lbl_shwSck = new System.Windows.Forms.Label();
            this.lbl_shwSysClk = new System.Windows.Forms.Label();
            this.lbl_shwSysClkMhz = new System.Windows.Forms.Label();
            this.lbl_shwSpiSysClk = new System.Windows.Forms.Label();
            this.lbl_spiSysClk = new System.Windows.Forms.Label();
            this.TxtSpiWrSysClk = new System.Windows.Forms.TextBox();
            this.TxtSpiWrSckH = new System.Windows.Forms.TextBox();
            this.TxtSpiWrSckL = new System.Windows.Forms.TextBox();
            this.lbl_shwSysClkVal = new System.Windows.Forms.Label();
            this.lbl_shwSckHVal = new System.Windows.Forms.Label();
            this.lbl_shwScklVal = new System.Windows.Forms.Label();
            this.PicSpiWrClk = new System.Windows.Forms.PictureBox();
            this.Gbx_SpiType = new System.Windows.Forms.GroupBox();
            this.PicSpiInterfaceType = new System.Windows.Forms.PictureBox();
            this.Rbtn_spi3wire = new System.Windows.Forms.RadioButton();
            this.Rbtn_spi4wire = new System.Windows.Forms.RadioButton();
            this.TabPg_SPI_2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.PicCsSelCtrl = new System.Windows.Forms.PictureBox();
            this.Rbtn_SpiCsIntSel = new System.Windows.Forms.RadioButton();
            this.Rbtn_SpiCsByUser = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PicSpiRdMode = new System.Windows.Forms.PictureBox();
            this.Rbtn_RdWithDummyClk = new System.Windows.Forms.RadioButton();
            this.Rbtn_RdWithNoDummy = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PicSpiLatchMode = new System.Windows.Forms.PictureBox();
            this.Rbtn_SpiRisingLatch = new System.Windows.Forms.RadioButton();
            this.Rbtn_SpiFallingLatch = new System.Windows.Forms.RadioButton();
            this.TabPg_I2C = new System.Windows.Forms.TabPage();
            this.gbx_setI2CTiming = new System.Windows.Forms.GroupBox();
            this.PnlMsg = new System.Windows.Forms.Panel();
            this.Pnl_I2CImage = new System.Windows.Forms.Panel();
            this.PicBoxI2C = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_i2csckL = new System.Windows.Forms.Label();
            this.lbl_i2csckH = new System.Windows.Forms.Label();
            this.lbl_seti2Mhz = new System.Windows.Forms.Label();
            this.LblI2cFreqVal = new System.Windows.Forms.Label();
            this.lbl_shwi2cSckFreq = new System.Windows.Forms.Label();
            this.lbl_shwI2CSck = new System.Windows.Forms.Label();
            this.lbl_shwi2cSysClk = new System.Windows.Forms.Label();
            this.PicI2cTiming = new System.Windows.Forms.PictureBox();
            this.lbl_shwi2cMhz = new System.Windows.Forms.Label();
            this.lbl_shwdivideClk = new System.Windows.Forms.Label();
            this.lbl_i2cTimeSysClk = new System.Windows.Forms.Label();
            this.TxtI2CSysClk = new System.Windows.Forms.TextBox();
            this.TxtI2CSckH = new System.Windows.Forms.TextBox();
            this.TxtI2CSckL = new System.Windows.Forms.TextBox();
            this.lbl_i2cshowSysClk = new System.Windows.Forms.Label();
            this.lbl_shwi2cSckH = new System.Windows.Forms.Label();
            this.lbl_shwi2cSckL = new System.Windows.Forms.Label();
            this.TabPg_Finish = new System.Windows.Forms.TabPage();
            this.Gpx_IfCmd = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.TrvInterface = new System.Windows.Forms.TreeView();
            this.CmsGeneralSet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyToClipBoradToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.TabCtrlf.SuspendLayout();
            this.TabPg_Interface.SuspendLayout();
            this.gbx_InitConfig.SuspendLayout();
            this.gbx_FpgaSetting.SuspendLayout();
            this.TabPg_CPU.SuspendLayout();
            this.gbx_busDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DataBusDef)).BeginInit();
            this.gbx_CpuModeSel.SuspendLayout();
            this.TabPg_RgbTiming.SuspendLayout();
            this.gbx_ShwTimeSet.SuspendLayout();
            this.gbx_polarity.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_De)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Vsync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Hsync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Pclk)).BeginInit();
            this.gbx_timeset.SuspendLayout();
            this.TabPg_RgbInterface.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_showDataBus)).BeginInit();
            this.gbx_dataBusType.SuspendLayout();
            this.gbx_rgbInterface.SuspendLayout();
            this.TabPg_SPI_1.SuspendLayout();
            this.Gbx_SpiRdSck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSpiRdClk)).BeginInit();
            this.Gbx_SpiWrSck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSpiWrClk)).BeginInit();
            this.Gbx_SpiType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSpiInterfaceType)).BeginInit();
            this.TabPg_SPI_2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCsSelCtrl)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSpiRdMode)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSpiLatchMode)).BeginInit();
            this.TabPg_I2C.SuspendLayout();
            this.gbx_setI2CTiming.SuspendLayout();
            this.Pnl_I2CImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxI2C)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicI2cTiming)).BeginInit();
            this.TabPg_Finish.SuspendLayout();
            this.panel1.SuspendLayout();
            this.CmsGeneralSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TabCtrlf);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.TrvInterface);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(945, 632);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Standard Bus Setting";
            // 
            // TabCtrlf
            // 
            this.TabCtrlf.Controls.Add(this.TabPg_Interface);
            this.TabCtrlf.Controls.Add(this.TabPg_CPU);
            this.TabCtrlf.Controls.Add(this.TabPg_RgbTiming);
            this.TabCtrlf.Controls.Add(this.TabPg_RgbInterface);
            this.TabCtrlf.Controls.Add(this.TabPg_SPI_1);
            this.TabCtrlf.Controls.Add(this.TabPg_SPI_2);
            this.TabCtrlf.Controls.Add(this.TabPg_I2C);
            this.TabCtrlf.Controls.Add(this.TabPg_Finish);
            this.TabCtrlf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCtrlf.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabCtrlf.Location = new System.Drawing.Point(227, 22);
            this.TabCtrlf.Name = "TabCtrlf";
            this.TabCtrlf.SelectedIndex = 0;
            this.TabCtrlf.Size = new System.Drawing.Size(715, 546);
            this.TabCtrlf.TabIndex = 2;
            this.TabCtrlf.SelectedIndexChanged += new System.EventHandler(this.TabCtrlf_SelectedIndexChanged);
            // 
            // TabPg_Interface
            // 
            this.TabPg_Interface.Controls.Add(this.gbx_InitConfig);
            this.TabPg_Interface.Controls.Add(this.gbx_FpgaSetting);
            this.TabPg_Interface.Location = new System.Drawing.Point(4, 23);
            this.TabPg_Interface.Name = "TabPg_Interface";
            this.TabPg_Interface.Padding = new System.Windows.Forms.Padding(3);
            this.TabPg_Interface.Size = new System.Drawing.Size(707, 519);
            this.TabPg_Interface.TabIndex = 0;
            this.TabPg_Interface.Text = "Interface";
            this.TabPg_Interface.UseVisualStyleBackColor = true;
            // 
            // gbx_InitConfig
            // 
            this.gbx_InitConfig.Controls.Add(this.LblFileName);
            this.gbx_InitConfig.Controls.Add(this.BtnSetDefault);
            this.gbx_InitConfig.Controls.Add(this.BtnLoadConfig);
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
            // LblFileName
            // 
            this.LblFileName.AutoSize = true;
            this.LblFileName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFileName.Location = new System.Drawing.Point(301, 29);
            this.LblFileName.Name = "LblFileName";
            this.LblFileName.Size = new System.Drawing.Size(0, 15);
            this.LblFileName.TabIndex = 4;
            // 
            // BtnSetDefault
            // 
            this.BtnSetDefault.Location = new System.Drawing.Point(187, 65);
            this.BtnSetDefault.Name = "BtnSetDefault";
            this.BtnSetDefault.Size = new System.Drawing.Size(108, 30);
            this.BtnSetDefault.TabIndex = 3;
            this.BtnSetDefault.Text = "Default";
            this.BtnSetDefault.UseVisualStyleBackColor = true;
            // 
            // BtnLoadConfig
            // 
            this.BtnLoadConfig.Location = new System.Drawing.Point(187, 23);
            this.BtnLoadConfig.Name = "BtnLoadConfig";
            this.BtnLoadConfig.Size = new System.Drawing.Size(108, 29);
            this.BtnLoadConfig.TabIndex = 1;
            this.BtnLoadConfig.Text = "Load";
            this.BtnLoadConfig.UseVisualStyleBackColor = true;
            this.BtnLoadConfig.Click += new System.EventHandler(this.BtnLoadConfig_Click);
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
            this.gbx_FpgaSetting.Controls.Add(this.TxtSysClk);
            this.gbx_FpgaSetting.Controls.Add(this.lbl_sysClk);
            this.gbx_FpgaSetting.Controls.Add(this.CboFpgaIf);
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
            // TxtSysClk
            // 
            this.TxtSysClk.Location = new System.Drawing.Point(247, 62);
            this.TxtSysClk.Name = "TxtSysClk";
            this.TxtSysClk.Size = new System.Drawing.Size(121, 24);
            this.TxtSysClk.TabIndex = 3;
            this.TxtSysClk.Text = "60";
            this.TxtSysClk.TextChanged += new System.EventHandler(this.TxtSysClk_TextChanged);
            this.TxtSysClk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtSysClk.Leave += new System.EventHandler(this.Txt_sysClk_Leave);
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
            // CboFpgaIf
            // 
            this.CboFpgaIf.FormattingEnabled = true;
            this.CboFpgaIf.Items.AddRange(new object[] {
            "CPU",
            "SPI",
            "I2C",
            "RGB + SPI",
            "RGB + I2C"});
            this.CboFpgaIf.Location = new System.Drawing.Point(247, 24);
            this.CboFpgaIf.Name = "CboFpgaIf";
            this.CboFpgaIf.Size = new System.Drawing.Size(121, 25);
            this.CboFpgaIf.TabIndex = 1;
            this.CboFpgaIf.SelectedIndexChanged += new System.EventHandler(this.CboFpgaIf_SelectedIndexChanged);
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
            // TabPg_CPU
            // 
            this.TabPg_CPU.Controls.Add(this.gbx_busDef);
            this.TabPg_CPU.Controls.Add(this.gbx_CpuModeSel);
            this.TabPg_CPU.Location = new System.Drawing.Point(4, 23);
            this.TabPg_CPU.Name = "TabPg_CPU";
            this.TabPg_CPU.Size = new System.Drawing.Size(707, 519);
            this.TabPg_CPU.TabIndex = 1;
            this.TabPg_CPU.Text = "CPU";
            this.TabPg_CPU.UseVisualStyleBackColor = true;
            // 
            // gbx_busDef
            // 
            this.gbx_busDef.Controls.Add(this.pic_DataBusDef);
            this.gbx_busDef.Controls.Add(this.Rbtn_18bitD17D0);
            this.gbx_busDef.Controls.Add(this.Rbtn_18bitD23D0);
            this.gbx_busDef.Controls.Add(this.Rbtn_9bitD17D9);
            this.gbx_busDef.Controls.Add(this.Rbtn_16bitD15D0);
            this.gbx_busDef.Controls.Add(this.Rbtn_16bitD17D10D8D1);
            this.gbx_busDef.Controls.Add(this.Rbtn_9bitD8D0);
            this.gbx_busDef.Controls.Add(this.Rbtn_8bitD17D10);
            this.gbx_busDef.Controls.Add(this.Rbtn_8BitD7D0);
            this.gbx_busDef.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_busDef.Location = new System.Drawing.Point(45, 93);
            this.gbx_busDef.Name = "gbx_busDef";
            this.gbx_busDef.Size = new System.Drawing.Size(547, 299);
            this.gbx_busDef.TabIndex = 6;
            this.gbx_busDef.TabStop = false;
            this.gbx_busDef.Text = "Data Bus Definition";
            // 
            // pic_DataBusDef
            // 
            this.pic_DataBusDef.Image = global::XM_Tek_Studio_Pro.Properties.Resources.cpu_data_bus;
            this.pic_DataBusDef.Location = new System.Drawing.Point(23, 194);
            this.pic_DataBusDef.Name = "pic_DataBusDef";
            this.pic_DataBusDef.Size = new System.Drawing.Size(504, 84);
            this.pic_DataBusDef.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_DataBusDef.TabIndex = 8;
            this.pic_DataBusDef.TabStop = false;
            // 
            // Rbtn_18bitD17D0
            // 
            this.Rbtn_18bitD17D0.AutoSize = true;
            this.Rbtn_18bitD17D0.Location = new System.Drawing.Point(88, 150);
            this.Rbtn_18bitD17D0.Name = "Rbtn_18bitD17D0";
            this.Rbtn_18bitD17D0.Size = new System.Drawing.Size(109, 21);
            this.Rbtn_18bitD17D0.TabIndex = 7;
            this.Rbtn_18bitD17D0.Text = "18 bit[D17:D0]";
            this.Rbtn_18bitD17D0.UseVisualStyleBackColor = true;
            this.Rbtn_18bitD17D0.CheckedChanged += new System.EventHandler(this.Rbtn_8BitD7D0_CheckedChanged);
            // 
            // Rbtn_18bitD23D0
            // 
            this.Rbtn_18bitD23D0.AutoSize = true;
            this.Rbtn_18bitD23D0.Location = new System.Drawing.Point(290, 150);
            this.Rbtn_18bitD23D0.Name = "Rbtn_18bitD23D0";
            this.Rbtn_18bitD23D0.Size = new System.Drawing.Size(109, 21);
            this.Rbtn_18bitD23D0.TabIndex = 6;
            this.Rbtn_18bitD23D0.Text = "24 bit[D23:D0]";
            this.Rbtn_18bitD23D0.UseVisualStyleBackColor = true;
            this.Rbtn_18bitD23D0.CheckedChanged += new System.EventHandler(this.Rbtn_8BitD7D0_CheckedChanged);
            // 
            // Rbtn_9bitD17D9
            // 
            this.Rbtn_9bitD17D9.AutoSize = true;
            this.Rbtn_9bitD17D9.Location = new System.Drawing.Point(290, 74);
            this.Rbtn_9bitD17D9.Name = "Rbtn_9bitD17D9";
            this.Rbtn_9bitD17D9.Size = new System.Drawing.Size(102, 21);
            this.Rbtn_9bitD17D9.TabIndex = 5;
            this.Rbtn_9bitD17D9.Text = "9 bit[D17:D9]";
            this.Rbtn_9bitD17D9.UseVisualStyleBackColor = true;
            this.Rbtn_9bitD17D9.CheckedChanged += new System.EventHandler(this.Rbtn_8BitD7D0_CheckedChanged);
            // 
            // Rbtn_16bitD15D0
            // 
            this.Rbtn_16bitD15D0.AutoSize = true;
            this.Rbtn_16bitD15D0.Location = new System.Drawing.Point(88, 111);
            this.Rbtn_16bitD15D0.Name = "Rbtn_16bitD15D0";
            this.Rbtn_16bitD15D0.Size = new System.Drawing.Size(109, 21);
            this.Rbtn_16bitD15D0.TabIndex = 4;
            this.Rbtn_16bitD15D0.Text = "16 bit[D15:D0]";
            this.Rbtn_16bitD15D0.UseVisualStyleBackColor = true;
            this.Rbtn_16bitD15D0.CheckedChanged += new System.EventHandler(this.Rbtn_8BitD7D0_CheckedChanged);
            // 
            // Rbtn_16bitD17D10D8D1
            // 
            this.Rbtn_16bitD17D10D8D1.AutoSize = true;
            this.Rbtn_16bitD17D10D8D1.Location = new System.Drawing.Point(290, 111);
            this.Rbtn_16bitD17D10D8D1.Name = "Rbtn_16bitD17D10D8D1";
            this.Rbtn_16bitD17D10D8D1.Size = new System.Drawing.Size(156, 21);
            this.Rbtn_16bitD17D10D8D1.TabIndex = 3;
            this.Rbtn_16bitD17D10D8D1.Text = "16 bit[D17:D10,D8:D1]";
            this.Rbtn_16bitD17D10D8D1.UseVisualStyleBackColor = true;
            this.Rbtn_16bitD17D10D8D1.CheckedChanged += new System.EventHandler(this.Rbtn_8BitD7D0_CheckedChanged);
            // 
            // Rbtn_9bitD8D0
            // 
            this.Rbtn_9bitD8D0.AutoSize = true;
            this.Rbtn_9bitD8D0.Location = new System.Drawing.Point(88, 74);
            this.Rbtn_9bitD8D0.Name = "Rbtn_9bitD8D0";
            this.Rbtn_9bitD8D0.Size = new System.Drawing.Size(95, 21);
            this.Rbtn_9bitD8D0.TabIndex = 2;
            this.Rbtn_9bitD8D0.Text = "9 bit[D8:D0]";
            this.Rbtn_9bitD8D0.UseVisualStyleBackColor = true;
            this.Rbtn_9bitD8D0.CheckedChanged += new System.EventHandler(this.Rbtn_8BitD7D0_CheckedChanged);
            // 
            // Rbtn_8bitD17D10
            // 
            this.Rbtn_8bitD17D10.AutoSize = true;
            this.Rbtn_8bitD17D10.Location = new System.Drawing.Point(290, 40);
            this.Rbtn_8bitD17D10.Name = "Rbtn_8bitD17D10";
            this.Rbtn_8bitD17D10.Size = new System.Drawing.Size(109, 21);
            this.Rbtn_8bitD17D10.TabIndex = 1;
            this.Rbtn_8bitD17D10.Text = "8 bit[D17:D10]";
            this.Rbtn_8bitD17D10.UseVisualStyleBackColor = true;
            this.Rbtn_8bitD17D10.CheckedChanged += new System.EventHandler(this.Rbtn_8BitD7D0_CheckedChanged);
            // 
            // Rbtn_8BitD7D0
            // 
            this.Rbtn_8BitD7D0.AutoSize = true;
            this.Rbtn_8BitD7D0.Checked = true;
            this.Rbtn_8BitD7D0.Location = new System.Drawing.Point(88, 40);
            this.Rbtn_8BitD7D0.Name = "Rbtn_8BitD7D0";
            this.Rbtn_8BitD7D0.Size = new System.Drawing.Size(95, 21);
            this.Rbtn_8BitD7D0.TabIndex = 0;
            this.Rbtn_8BitD7D0.TabStop = true;
            this.Rbtn_8BitD7D0.Text = "8 bit[D7:D0]";
            this.Rbtn_8BitD7D0.UseVisualStyleBackColor = true;
            this.Rbtn_8BitD7D0.CheckedChanged += new System.EventHandler(this.Rbtn_8BitD7D0_CheckedChanged);
            // 
            // gbx_CpuModeSel
            // 
            this.gbx_CpuModeSel.Controls.Add(this.RbtnM68);
            this.gbx_CpuModeSel.Controls.Add(this.RbtnI80);
            this.gbx_CpuModeSel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_CpuModeSel.Location = new System.Drawing.Point(45, 20);
            this.gbx_CpuModeSel.Name = "gbx_CpuModeSel";
            this.gbx_CpuModeSel.Size = new System.Drawing.Size(547, 67);
            this.gbx_CpuModeSel.TabIndex = 5;
            this.gbx_CpuModeSel.TabStop = false;
            this.gbx_CpuModeSel.Text = "CPU Mode Select";
            // 
            // RbtnM68
            // 
            this.RbtnM68.AutoSize = true;
            this.RbtnM68.Location = new System.Drawing.Point(290, 23);
            this.RbtnM68.Name = "RbtnM68";
            this.RbtnM68.Size = new System.Drawing.Size(52, 21);
            this.RbtnM68.TabIndex = 1;
            this.RbtnM68.Text = "M68";
            this.RbtnM68.UseVisualStyleBackColor = true;
            this.RbtnM68.CheckedChanged += new System.EventHandler(this.RtBtn_CpuIf_CheckedChanged);
            // 
            // RbtnI80
            // 
            this.RbtnI80.AutoSize = true;
            this.RbtnI80.Checked = true;
            this.RbtnI80.Location = new System.Drawing.Point(88, 23);
            this.RbtnI80.Name = "RbtnI80";
            this.RbtnI80.Size = new System.Drawing.Size(44, 21);
            this.RbtnI80.TabIndex = 0;
            this.RbtnI80.TabStop = true;
            this.RbtnI80.Text = "I80";
            this.RbtnI80.UseVisualStyleBackColor = true;
            this.RbtnI80.CheckedChanged += new System.EventHandler(this.RtBtn_CpuIf_CheckedChanged);
            // 
            // TabPg_RgbTiming
            // 
            this.TabPg_RgbTiming.Controls.Add(this.gbx_ShwTimeSet);
            this.TabPg_RgbTiming.Controls.Add(this.gbx_polarity);
            this.TabPg_RgbTiming.Controls.Add(this.gbx_timeset);
            this.TabPg_RgbTiming.Location = new System.Drawing.Point(4, 23);
            this.TabPg_RgbTiming.Name = "TabPg_RgbTiming";
            this.TabPg_RgbTiming.Size = new System.Drawing.Size(707, 519);
            this.TabPg_RgbTiming.TabIndex = 2;
            this.TabPg_RgbTiming.Text = "RGB Timing";
            this.TabPg_RgbTiming.UseVisualStyleBackColor = true;
            // 
            // gbx_ShwTimeSet
            // 
            this.gbx_ShwTimeSet.BackColor = System.Drawing.Color.White;
            this.gbx_ShwTimeSet.BackgroundImage = global::XM_Tek_Studio_Pro.Properties.Resources.RGB_chart;
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
            this.gbx_ShwTimeSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_ShwTimeSet.Location = new System.Drawing.Point(0, 0);
            this.gbx_ShwTimeSet.Name = "gbx_ShwTimeSet";
            this.gbx_ShwTimeSet.Size = new System.Drawing.Size(466, 359);
            this.gbx_ShwTimeSet.TabIndex = 2;
            this.gbx_ShwTimeSet.TabStop = false;
            this.gbx_ShwTimeSet.Text = "Timing Setting";
            // 
            // lbl_HfpVal
            // 
            this.lbl_HfpVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_HfpVal.AutoSize = true;
            this.lbl_HfpVal.Location = new System.Drawing.Point(321, 305);
            this.lbl_HfpVal.Name = "lbl_HfpVal";
            this.lbl_HfpVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_HfpVal.TabIndex = 44;
            this.lbl_HfpVal.Text = "0";
            // 
            // lbl_HactiveVal
            // 
            this.lbl_HactiveVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_HactiveVal.AutoSize = true;
            this.lbl_HactiveVal.Location = new System.Drawing.Point(233, 305);
            this.lbl_HactiveVal.Name = "lbl_HactiveVal";
            this.lbl_HactiveVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_HactiveVal.TabIndex = 43;
            this.lbl_HactiveVal.Text = "0";
            // 
            // lbl_HbpVal
            // 
            this.lbl_HbpVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_HbpVal.AutoSize = true;
            this.lbl_HbpVal.Location = new System.Drawing.Point(166, 305);
            this.lbl_HbpVal.Name = "lbl_HbpVal";
            this.lbl_HbpVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_HbpVal.TabIndex = 42;
            this.lbl_HbpVal.Text = "0";
            // 
            // lbl_HsyncVal
            // 
            this.lbl_HsyncVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_HsyncVal.AutoSize = true;
            this.lbl_HsyncVal.Location = new System.Drawing.Point(132, 305);
            this.lbl_HsyncVal.Name = "lbl_HsyncVal";
            this.lbl_HsyncVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_HsyncVal.TabIndex = 41;
            this.lbl_HsyncVal.Text = "0";
            // 
            // lbl_VfpVal
            // 
            this.lbl_VfpVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_VfpVal.AutoSize = true;
            this.lbl_VfpVal.Location = new System.Drawing.Point(51, 222);
            this.lbl_VfpVal.Name = "lbl_VfpVal";
            this.lbl_VfpVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_VfpVal.TabIndex = 40;
            this.lbl_VfpVal.Text = "0";
            // 
            // lbl_VactiveVal
            // 
            this.lbl_VactiveVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_VactiveVal.AutoSize = true;
            this.lbl_VactiveVal.Location = new System.Drawing.Point(51, 146);
            this.lbl_VactiveVal.Name = "lbl_VactiveVal";
            this.lbl_VactiveVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_VactiveVal.TabIndex = 39;
            this.lbl_VactiveVal.Text = "0";
            // 
            // lbl_VbpVal
            // 
            this.lbl_VbpVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_VbpVal.AutoSize = true;
            this.lbl_VbpVal.Location = new System.Drawing.Point(51, 94);
            this.lbl_VbpVal.Name = "lbl_VbpVal";
            this.lbl_VbpVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_VbpVal.TabIndex = 38;
            this.lbl_VbpVal.Text = "0";
            // 
            // lbl_VsyncVal
            // 
            this.lbl_VsyncVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_VsyncVal.AutoSize = true;
            this.lbl_VsyncVal.Location = new System.Drawing.Point(51, 58);
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
            this.lbl_PixelClkVal.Location = new System.Drawing.Point(360, 94);
            this.lbl_PixelClkVal.Name = "lbl_PixelClkVal";
            this.lbl_PixelClkVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_PixelClkVal.TabIndex = 2;
            this.lbl_PixelClkVal.Text = "0";
            // 
            // lbl_ScanRateVal
            // 
            this.lbl_ScanRateVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_ScanRateVal.AutoSize = true;
            this.lbl_ScanRateVal.Location = new System.Drawing.Point(360, 254);
            this.lbl_ScanRateVal.Name = "lbl_ScanRateVal";
            this.lbl_ScanRateVal.Size = new System.Drawing.Size(13, 14);
            this.lbl_ScanRateVal.TabIndex = 1;
            this.lbl_ScanRateVal.Text = "0";
            // 
            // lbl_fpRateVal
            // 
            this.lbl_fpRateVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_fpRateVal.AutoSize = true;
            this.lbl_fpRateVal.Location = new System.Drawing.Point(360, 172);
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
            this.gbx_polarity.Location = new System.Drawing.Point(0, 359);
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
            this.pic_De.BackColor = System.Drawing.Color.Transparent;
            this.pic_De.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_De.Image = global::XM_Tek_Studio_Pro.Properties.Resources.de_p0;
            this.pic_De.Location = new System.Drawing.Point(233, 71);
            this.pic_De.Name = "pic_De";
            this.pic_De.Size = new System.Drawing.Size(224, 63);
            this.pic_De.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_De.TabIndex = 3;
            this.pic_De.TabStop = false;
            this.pic_De.Click += new System.EventHandler(this.Pic_De_Click);
            // 
            // pic_Vsync
            // 
            this.pic_Vsync.BackColor = System.Drawing.Color.Transparent;
            this.pic_Vsync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_Vsync.Image = global::XM_Tek_Studio_Pro.Properties.Resources.vs_p0;
            this.pic_Vsync.Location = new System.Drawing.Point(3, 71);
            this.pic_Vsync.Name = "pic_Vsync";
            this.pic_Vsync.Size = new System.Drawing.Size(224, 63);
            this.pic_Vsync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Vsync.TabIndex = 2;
            this.pic_Vsync.TabStop = false;
            this.pic_Vsync.Click += new System.EventHandler(this.Pic_Vsync_Click);
            // 
            // pic_Hsync
            // 
            this.pic_Hsync.BackColor = System.Drawing.Color.Transparent;
            this.pic_Hsync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_Hsync.Image = global::XM_Tek_Studio_Pro.Properties.Resources.hs_p0;
            this.pic_Hsync.Location = new System.Drawing.Point(233, 3);
            this.pic_Hsync.Name = "pic_Hsync";
            this.pic_Hsync.Size = new System.Drawing.Size(224, 62);
            this.pic_Hsync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Hsync.TabIndex = 1;
            this.pic_Hsync.TabStop = false;
            this.pic_Hsync.Click += new System.EventHandler(this.Pic_Hsync_Click);
            // 
            // pic_Pclk
            // 
            this.pic_Pclk.BackColor = System.Drawing.Color.Transparent;
            this.pic_Pclk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_Pclk.Image = global::XM_Tek_Studio_Pro.Properties.Resources.pclk_p0;
            this.pic_Pclk.InitialImage = global::XM_Tek_Studio_Pro.Properties.Resources.pclk_p0;
            this.pic_Pclk.Location = new System.Drawing.Point(3, 3);
            this.pic_Pclk.Name = "pic_Pclk";
            this.pic_Pclk.Size = new System.Drawing.Size(224, 62);
            this.pic_Pclk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Pclk.TabIndex = 0;
            this.pic_Pclk.TabStop = false;
            this.pic_Pclk.Click += new System.EventHandler(this.Pic_Pclk_Click);
            // 
            // gbx_timeset
            // 
            this.gbx_timeset.Controls.Add(this.lbl_pixelCkMhz);
            this.gbx_timeset.Controls.Add(this.TxtPixelClk);
            this.gbx_timeset.Controls.Add(this.lbl_PixelClk);
            this.gbx_timeset.Controls.Add(this.lbl_extClk);
            this.gbx_timeset.Controls.Add(this.TxtVSyncSum);
            this.gbx_timeset.Controls.Add(this.TxtVfp);
            this.gbx_timeset.Controls.Add(this.TxtVactive);
            this.gbx_timeset.Controls.Add(this.TxtVbp);
            this.gbx_timeset.Controls.Add(this.TxtVsync);
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
            this.gbx_timeset.Controls.Add(this.TxtHSyncSum);
            this.gbx_timeset.Controls.Add(this.TxtHfp);
            this.gbx_timeset.Controls.Add(this.TxtHactive);
            this.gbx_timeset.Controls.Add(this.TxtHbp);
            this.gbx_timeset.Controls.Add(this.TxtHsync);
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
            this.gbx_timeset.Size = new System.Drawing.Size(241, 519);
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
            // TxtPixelClk
            // 
            this.TxtPixelClk.Location = new System.Drawing.Point(83, 451);
            this.TxtPixelClk.Name = "TxtPixelClk";
            this.TxtPixelClk.Size = new System.Drawing.Size(100, 24);
            this.TxtPixelClk.TabIndex = 34;
            this.TxtPixelClk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtPixelClk.Leave += new System.EventHandler(this.Txt_Hsync_Leave);
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
            // TxtVSyncSum
            // 
            this.TxtVSyncSum.Location = new System.Drawing.Point(62, 376);
            this.TxtVSyncSum.Name = "TxtVSyncSum";
            this.TxtVSyncSum.Size = new System.Drawing.Size(100, 24);
            this.TxtVSyncSum.TabIndex = 31;
            this.TxtVSyncSum.Text = "0";
            this.TxtVSyncSum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            // 
            // TxtVfp
            // 
            this.TxtVfp.Location = new System.Drawing.Point(62, 344);
            this.TxtVfp.Name = "TxtVfp";
            this.TxtVfp.Size = new System.Drawing.Size(100, 24);
            this.TxtVfp.TabIndex = 30;
            this.TxtVfp.Text = "0";
            this.TxtVfp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtVfp.Leave += new System.EventHandler(this.Txt_Hsync_Leave);
            // 
            // TxtVactive
            // 
            this.TxtVactive.Location = new System.Drawing.Point(62, 312);
            this.TxtVactive.Name = "TxtVactive";
            this.TxtVactive.Size = new System.Drawing.Size(100, 24);
            this.TxtVactive.TabIndex = 29;
            this.TxtVactive.Text = "0";
            this.TxtVactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtVactive.Leave += new System.EventHandler(this.Txt_Hsync_Leave);
            // 
            // TxtVbp
            // 
            this.TxtVbp.Location = new System.Drawing.Point(62, 280);
            this.TxtVbp.Name = "TxtVbp";
            this.TxtVbp.Size = new System.Drawing.Size(100, 24);
            this.TxtVbp.TabIndex = 28;
            this.TxtVbp.Text = "0";
            this.TxtVbp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtVbp.Leave += new System.EventHandler(this.Txt_Hsync_Leave);
            // 
            // TxtVsync
            // 
            this.TxtVsync.Location = new System.Drawing.Point(62, 249);
            this.TxtVsync.Name = "TxtVsync";
            this.TxtVsync.Size = new System.Drawing.Size(100, 24);
            this.TxtVsync.TabIndex = 27;
            this.TxtVsync.Text = "0";
            this.TxtVsync.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtVsync.Leave += new System.EventHandler(this.Txt_Hsync_Leave);
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
            // TxtHSyncSum
            // 
            this.TxtHSyncSum.Location = new System.Drawing.Point(62, 184);
            this.TxtHSyncSum.Name = "TxtHSyncSum";
            this.TxtHSyncSum.Size = new System.Drawing.Size(100, 24);
            this.TxtHSyncSum.TabIndex = 15;
            this.TxtHSyncSum.Text = "0";
            this.TxtHSyncSum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            // 
            // TxtHfp
            // 
            this.TxtHfp.Location = new System.Drawing.Point(62, 152);
            this.TxtHfp.Name = "TxtHfp";
            this.TxtHfp.Size = new System.Drawing.Size(100, 24);
            this.TxtHfp.TabIndex = 14;
            this.TxtHfp.Text = "0";
            this.TxtHfp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtHfp.Leave += new System.EventHandler(this.Txt_Hsync_Leave);
            // 
            // TxtHactive
            // 
            this.TxtHactive.Location = new System.Drawing.Point(62, 120);
            this.TxtHactive.Name = "TxtHactive";
            this.TxtHactive.Size = new System.Drawing.Size(100, 24);
            this.TxtHactive.TabIndex = 13;
            this.TxtHactive.Text = "0";
            this.TxtHactive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtHactive.Leave += new System.EventHandler(this.Txt_Hsync_Leave);
            // 
            // TxtHbp
            // 
            this.TxtHbp.Location = new System.Drawing.Point(62, 88);
            this.TxtHbp.Name = "TxtHbp";
            this.TxtHbp.Size = new System.Drawing.Size(100, 24);
            this.TxtHbp.TabIndex = 12;
            this.TxtHbp.Text = "0";
            this.TxtHbp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtHbp.Leave += new System.EventHandler(this.Txt_Hsync_Leave);
            // 
            // TxtHsync
            // 
            this.TxtHsync.Location = new System.Drawing.Point(62, 57);
            this.TxtHsync.Name = "TxtHsync";
            this.TxtHsync.Size = new System.Drawing.Size(100, 24);
            this.TxtHsync.TabIndex = 11;
            this.TxtHsync.Text = "0";
            this.TxtHsync.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtHsync.Leave += new System.EventHandler(this.Txt_Hsync_Leave);
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
            // TabPg_RgbInterface
            // 
            this.TabPg_RgbInterface.Controls.Add(this.groupBox12);
            this.TabPg_RgbInterface.Controls.Add(this.gbx_dataBusType);
            this.TabPg_RgbInterface.Controls.Add(this.gbx_rgbInterface);
            this.TabPg_RgbInterface.Location = new System.Drawing.Point(4, 23);
            this.TabPg_RgbInterface.Name = "TabPg_RgbInterface";
            this.TabPg_RgbInterface.Size = new System.Drawing.Size(707, 519);
            this.TabPg_RgbInterface.TabIndex = 6;
            this.TabPg_RgbInterface.Text = "RGB Interface";
            this.TabPg_RgbInterface.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.pic_showDataBus);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox12.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(193, 84);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(514, 435);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Show Type";
            // 
            // pic_showDataBus
            // 
            this.pic_showDataBus.BackColor = System.Drawing.Color.Gainsboro;
            this.pic_showDataBus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_showDataBus.Image = global::XM_Tek_Studio_Pro.Properties.Resources.RGB_DATA_BUS;
            this.pic_showDataBus.InitialImage = global::XM_Tek_Studio_Pro.Properties.Resources.RGB_DATA_BUS;
            this.pic_showDataBus.Location = new System.Drawing.Point(3, 20);
            this.pic_showDataBus.Name = "pic_showDataBus";
            this.pic_showDataBus.Size = new System.Drawing.Size(508, 412);
            this.pic_showDataBus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_showDataBus.TabIndex = 0;
            this.pic_showDataBus.TabStop = false;
            // 
            // gbx_dataBusType
            // 
            this.gbx_dataBusType.Controls.Add(this.Rbtn_24bitD23);
            this.gbx_dataBusType.Controls.Add(this.Rbtn_18bitD21);
            this.gbx_dataBusType.Controls.Add(this.Rbtn_18bitD17);
            this.gbx_dataBusType.Controls.Add(this.Rbtn_16bitD21);
            this.gbx_dataBusType.Controls.Add(this.Rbtn_16bitD17);
            this.gbx_dataBusType.Controls.Add(this.Rbtn_16bitD15);
            this.gbx_dataBusType.Controls.Add(this.Rbtn_8bit);
            this.gbx_dataBusType.Controls.Add(this.Rbtn_6bit);
            this.gbx_dataBusType.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbx_dataBusType.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_dataBusType.Location = new System.Drawing.Point(0, 84);
            this.gbx_dataBusType.Name = "gbx_dataBusType";
            this.gbx_dataBusType.Size = new System.Drawing.Size(193, 435);
            this.gbx_dataBusType.TabIndex = 1;
            this.gbx_dataBusType.TabStop = false;
            this.gbx_dataBusType.Text = "Data Bus Type";
            // 
            // Rbtn_24bitD23
            // 
            this.Rbtn_24bitD23.AutoSize = true;
            this.Rbtn_24bitD23.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_24bitD23.Location = new System.Drawing.Point(23, 305);
            this.Rbtn_24bitD23.Name = "Rbtn_24bitD23";
            this.Rbtn_24bitD23.Size = new System.Drawing.Size(116, 21);
            this.Rbtn_24bitD23.TabIndex = 8;
            this.Rbtn_24bitD23.Text = "24 bit_[D23:D0]";
            this.Rbtn_24bitD23.UseVisualStyleBackColor = true;
            this.Rbtn_24bitD23.CheckedChanged += new System.EventHandler(this.Rbtn_6bit_CheckedChanged);
            // 
            // Rbtn_18bitD21
            // 
            this.Rbtn_18bitD21.AutoSize = true;
            this.Rbtn_18bitD21.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_18bitD21.Location = new System.Drawing.Point(23, 265);
            this.Rbtn_18bitD21.Name = "Rbtn_18bitD21";
            this.Rbtn_18bitD21.Size = new System.Drawing.Size(120, 21);
            this.Rbtn_18bitD21.TabIndex = 7;
            this.Rbtn_18bitD21.Text = "18bit_[D21:D16]";
            this.Rbtn_18bitD21.UseVisualStyleBackColor = true;
            this.Rbtn_18bitD21.CheckedChanged += new System.EventHandler(this.Rbtn_6bit_CheckedChanged);
            // 
            // Rbtn_18bitD17
            // 
            this.Rbtn_18bitD17.AutoSize = true;
            this.Rbtn_18bitD17.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_18bitD17.Location = new System.Drawing.Point(23, 237);
            this.Rbtn_18bitD17.Name = "Rbtn_18bitD17";
            this.Rbtn_18bitD17.Size = new System.Drawing.Size(116, 21);
            this.Rbtn_18bitD17.TabIndex = 6;
            this.Rbtn_18bitD17.Text = "18 bit_[D17:D0]";
            this.Rbtn_18bitD17.UseVisualStyleBackColor = true;
            this.Rbtn_18bitD17.CheckedChanged += new System.EventHandler(this.Rbtn_6bit_CheckedChanged);
            // 
            // Rbtn_16bitD21
            // 
            this.Rbtn_16bitD21.AutoSize = true;
            this.Rbtn_16bitD21.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_16bitD21.Location = new System.Drawing.Point(23, 194);
            this.Rbtn_16bitD21.Name = "Rbtn_16bitD21";
            this.Rbtn_16bitD21.Size = new System.Drawing.Size(58, 21);
            this.Rbtn_16bitD21.TabIndex = 5;
            this.Rbtn_16bitD21.Text = "16 bit";
            this.Rbtn_16bitD21.UseVisualStyleBackColor = true;
            this.Rbtn_16bitD21.CheckedChanged += new System.EventHandler(this.Rbtn_6bit_CheckedChanged);
            // 
            // Rbtn_16bitD17
            // 
            this.Rbtn_16bitD17.AutoSize = true;
            this.Rbtn_16bitD17.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_16bitD17.Location = new System.Drawing.Point(23, 163);
            this.Rbtn_16bitD17.Name = "Rbtn_16bitD17";
            this.Rbtn_16bitD17.Size = new System.Drawing.Size(58, 21);
            this.Rbtn_16bitD17.TabIndex = 4;
            this.Rbtn_16bitD17.Text = "16 bit";
            this.Rbtn_16bitD17.UseVisualStyleBackColor = true;
            this.Rbtn_16bitD17.CheckedChanged += new System.EventHandler(this.Rbtn_6bit_CheckedChanged);
            // 
            // Rbtn_16bitD15
            // 
            this.Rbtn_16bitD15.AutoSize = true;
            this.Rbtn_16bitD15.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_16bitD15.Location = new System.Drawing.Point(23, 132);
            this.Rbtn_16bitD15.Name = "Rbtn_16bitD15";
            this.Rbtn_16bitD15.Size = new System.Drawing.Size(116, 21);
            this.Rbtn_16bitD15.TabIndex = 3;
            this.Rbtn_16bitD15.Text = "16 bit_[D15:D0]";
            this.Rbtn_16bitD15.UseVisualStyleBackColor = true;
            this.Rbtn_16bitD15.CheckedChanged += new System.EventHandler(this.Rbtn_6bit_CheckedChanged);
            // 
            // Rbtn_8bit
            // 
            this.Rbtn_8bit.AutoSize = true;
            this.Rbtn_8bit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_8bit.Location = new System.Drawing.Point(23, 73);
            this.Rbtn_8bit.Name = "Rbtn_8bit";
            this.Rbtn_8bit.Size = new System.Drawing.Size(102, 21);
            this.Rbtn_8bit.TabIndex = 2;
            this.Rbtn_8bit.Text = "8 bit_[D7:D0]";
            this.Rbtn_8bit.UseVisualStyleBackColor = true;
            this.Rbtn_8bit.CheckedChanged += new System.EventHandler(this.Rbtn_6bit_CheckedChanged);
            // 
            // Rbtn_6bit
            // 
            this.Rbtn_6bit.AutoSize = true;
            this.Rbtn_6bit.Checked = true;
            this.Rbtn_6bit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_6bit.Location = new System.Drawing.Point(23, 45);
            this.Rbtn_6bit.Name = "Rbtn_6bit";
            this.Rbtn_6bit.Size = new System.Drawing.Size(116, 21);
            this.Rbtn_6bit.TabIndex = 1;
            this.Rbtn_6bit.TabStop = true;
            this.Rbtn_6bit.Text = "6 bit_[D17:D12]";
            this.Rbtn_6bit.UseVisualStyleBackColor = true;
            this.Rbtn_6bit.CheckedChanged += new System.EventHandler(this.Rbtn_6bit_CheckedChanged);
            // 
            // gbx_rgbInterface
            // 
            this.gbx_rgbInterface.Controls.Add(this.Rbtn_DeMod);
            this.gbx_rgbInterface.Controls.Add(this.Rbtn_HsVsMod);
            this.gbx_rgbInterface.Controls.Add(this.Rbtn_HsVsDeMod);
            this.gbx_rgbInterface.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbx_rgbInterface.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_rgbInterface.Location = new System.Drawing.Point(0, 0);
            this.gbx_rgbInterface.Name = "gbx_rgbInterface";
            this.gbx_rgbInterface.Size = new System.Drawing.Size(707, 84);
            this.gbx_rgbInterface.TabIndex = 0;
            this.gbx_rgbInterface.TabStop = false;
            this.gbx_rgbInterface.Text = "RGB Interface Type";
            // 
            // Rbtn_DeMod
            // 
            this.Rbtn_DeMod.AutoSize = true;
            this.Rbtn_DeMod.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_DeMod.Location = new System.Drawing.Point(443, 36);
            this.Rbtn_DeMod.Name = "Rbtn_DeMod";
            this.Rbtn_DeMod.Size = new System.Drawing.Size(78, 21);
            this.Rbtn_DeMod.TabIndex = 2;
            this.Rbtn_DeMod.Text = "DE Mode";
            this.Rbtn_DeMod.UseVisualStyleBackColor = true;
            // 
            // Rbtn_HsVsMod
            // 
            this.Rbtn_HsVsMod.AutoSize = true;
            this.Rbtn_HsVsMod.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_HsVsMod.Location = new System.Drawing.Point(268, 36);
            this.Rbtn_HsVsMod.Name = "Rbtn_HsVsMod";
            this.Rbtn_HsVsMod.Size = new System.Drawing.Size(60, 21);
            this.Rbtn_HsVsMod.TabIndex = 1;
            this.Rbtn_HsVsMod.Text = "HS/VS";
            this.Rbtn_HsVsMod.UseVisualStyleBackColor = true;
            // 
            // Rbtn_HsVsDeMod
            // 
            this.Rbtn_HsVsDeMod.AutoSize = true;
            this.Rbtn_HsVsDeMod.Checked = true;
            this.Rbtn_HsVsDeMod.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_HsVsDeMod.Location = new System.Drawing.Point(69, 36);
            this.Rbtn_HsVsDeMod.Name = "Rbtn_HsVsDeMod";
            this.Rbtn_HsVsDeMod.Size = new System.Drawing.Size(83, 21);
            this.Rbtn_HsVsDeMod.TabIndex = 0;
            this.Rbtn_HsVsDeMod.TabStop = true;
            this.Rbtn_HsVsDeMod.Text = "HS/VS+DE";
            this.Rbtn_HsVsDeMod.UseVisualStyleBackColor = true;
            // 
            // TabPg_SPI_1
            // 
            this.TabPg_SPI_1.Controls.Add(this.Gbx_SpiRdSck);
            this.TabPg_SPI_1.Controls.Add(this.Gbx_SpiWrSck);
            this.TabPg_SPI_1.Controls.Add(this.Gbx_SpiType);
            this.TabPg_SPI_1.Location = new System.Drawing.Point(4, 23);
            this.TabPg_SPI_1.Name = "TabPg_SPI_1";
            this.TabPg_SPI_1.Size = new System.Drawing.Size(707, 519);
            this.TabPg_SPI_1.TabIndex = 3;
            this.TabPg_SPI_1.Text = "SPI_1";
            this.TabPg_SPI_1.UseVisualStyleBackColor = true;
            // 
            // Gbx_SpiRdSck
            // 
            this.Gbx_SpiRdSck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gbx_SpiRdSck.Controls.Add(this.label1);
            this.Gbx_SpiRdSck.Controls.Add(this.label2);
            this.Gbx_SpiRdSck.Controls.Add(this.label4);
            this.Gbx_SpiRdSck.Controls.Add(this.lbl_SckRdFreqVal);
            this.Gbx_SpiRdSck.Controls.Add(this.label6);
            this.Gbx_SpiRdSck.Controls.Add(this.label7);
            this.Gbx_SpiRdSck.Controls.Add(this.label8);
            this.Gbx_SpiRdSck.Controls.Add(this.label9);
            this.Gbx_SpiRdSck.Controls.Add(this.label10);
            this.Gbx_SpiRdSck.Controls.Add(this.label11);
            this.Gbx_SpiRdSck.Controls.Add(this.TxtSpiRdSysClk);
            this.Gbx_SpiRdSck.Controls.Add(this.TxtSpiRdSckH);
            this.Gbx_SpiRdSck.Controls.Add(this.TxtSpiRdSckL);
            this.Gbx_SpiRdSck.Controls.Add(this.label12);
            this.Gbx_SpiRdSck.Controls.Add(this.label13);
            this.Gbx_SpiRdSck.Controls.Add(this.label14);
            this.Gbx_SpiRdSck.Controls.Add(this.PicSpiRdClk);
            this.Gbx_SpiRdSck.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gbx_SpiRdSck.Location = new System.Drawing.Point(7, 296);
            this.Gbx_SpiRdSck.Name = "Gbx_SpiRdSck";
            this.Gbx_SpiRdSck.Size = new System.Drawing.Size(692, 151);
            this.Gbx_SpiRdSck.TabIndex = 6;
            this.Gbx_SpiRdSck.TabStop = false;
            this.Gbx_SpiRdSck.Text = "SPI Read SCK Speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "\"H\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "\"L\"";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(344, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mhz";
            // 
            // lbl_SckRdFreqVal
            // 
            this.lbl_SckRdFreqVal.AutoSize = true;
            this.lbl_SckRdFreqVal.Location = new System.Drawing.Point(123, 117);
            this.lbl_SckRdFreqVal.Name = "lbl_SckRdFreqVal";
            this.lbl_SckRdFreqVal.Size = new System.Drawing.Size(29, 17);
            this.lbl_SckRdFreqVal.TabIndex = 13;
            this.lbl_SckRdFreqVal.Text = "XXX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "SCK Freq:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "SCK:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Sys.Clk : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(609, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Mhz";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(609, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "/ Sys.Clk";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(609, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "/ Sys.Clk";
            // 
            // TxtSpiRdSysClk
            // 
            this.TxtSpiRdSysClk.Enabled = false;
            this.TxtSpiRdSysClk.Location = new System.Drawing.Point(503, 114);
            this.TxtSpiRdSysClk.Name = "TxtSpiRdSysClk";
            this.TxtSpiRdSysClk.Size = new System.Drawing.Size(100, 24);
            this.TxtSpiRdSysClk.TabIndex = 6;
            this.TxtSpiRdSysClk.Text = "60";
            this.TxtSpiRdSysClk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            // 
            // TxtSpiRdSckH
            // 
            this.TxtSpiRdSckH.Location = new System.Drawing.Point(503, 35);
            this.TxtSpiRdSckH.Name = "TxtSpiRdSckH";
            this.TxtSpiRdSckH.Size = new System.Drawing.Size(100, 24);
            this.TxtSpiRdSckH.TabIndex = 4;
            this.TxtSpiRdSckH.Text = "0";
            this.TxtSpiRdSckH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtSpiRdSckH.Leave += new System.EventHandler(this.Txt_SpiWrAndRdClk_Leave);
            // 
            // TxtSpiRdSckL
            // 
            this.TxtSpiRdSckL.Location = new System.Drawing.Point(503, 73);
            this.TxtSpiRdSckL.Name = "TxtSpiRdSckL";
            this.TxtSpiRdSckL.Size = new System.Drawing.Size(100, 24);
            this.TxtSpiRdSckL.TabIndex = 5;
            this.TxtSpiRdSckL.Text = "0";
            this.TxtSpiRdSckL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtSpiRdSckL.Leave += new System.EventHandler(this.Txt_SpiWrAndRdClk_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(431, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = "Sys.Clock = ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(432, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "SCK \"H\" = ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(435, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 17);
            this.label14.TabIndex = 1;
            this.label14.Text = "SCK \"L\" = ";
            // 
            // PicSpiRdClk
            // 
            this.PicSpiRdClk.Image = global::XM_Tek_Studio_Pro.Properties.Resources.spi_sck_speed;
            this.PicSpiRdClk.Location = new System.Drawing.Point(18, 35);
            this.PicSpiRdClk.Name = "PicSpiRdClk";
            this.PicSpiRdClk.Size = new System.Drawing.Size(407, 103);
            this.PicSpiRdClk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicSpiRdClk.TabIndex = 0;
            this.PicSpiRdClk.TabStop = false;
            // 
            // Gbx_SpiWrSck
            // 
            this.Gbx_SpiWrSck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_shwSckH);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_shwSckL);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_SckMhz);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_SckWrFreqVal);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_shwSckFreq);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_shwSck);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_shwSysClk);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_shwSysClkMhz);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_shwSpiSysClk);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_spiSysClk);
            this.Gbx_SpiWrSck.Controls.Add(this.TxtSpiWrSysClk);
            this.Gbx_SpiWrSck.Controls.Add(this.TxtSpiWrSckH);
            this.Gbx_SpiWrSck.Controls.Add(this.TxtSpiWrSckL);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_shwSysClkVal);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_shwSckHVal);
            this.Gbx_SpiWrSck.Controls.Add(this.lbl_shwScklVal);
            this.Gbx_SpiWrSck.Controls.Add(this.PicSpiWrClk);
            this.Gbx_SpiWrSck.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gbx_SpiWrSck.Location = new System.Drawing.Point(7, 139);
            this.Gbx_SpiWrSck.Name = "Gbx_SpiWrSck";
            this.Gbx_SpiWrSck.Size = new System.Drawing.Size(692, 151);
            this.Gbx_SpiWrSck.TabIndex = 5;
            this.Gbx_SpiWrSck.TabStop = false;
            this.Gbx_SpiWrSck.Text = "SPI  Write SCK Speed";
            // 
            // lbl_shwSckH
            // 
            this.lbl_shwSckH.AutoSize = true;
            this.lbl_shwSckH.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_shwSckH.Location = new System.Drawing.Point(284, 75);
            this.lbl_shwSckH.Name = "lbl_shwSckH";
            this.lbl_shwSckH.Size = new System.Drawing.Size(31, 19);
            this.lbl_shwSckH.TabIndex = 22;
            this.lbl_shwSckH.Text = "\"H\"";
            // 
            // lbl_shwSckL
            // 
            this.lbl_shwSckL.AutoSize = true;
            this.lbl_shwSckL.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_shwSckL.Location = new System.Drawing.Point(160, 75);
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
            // lbl_SckWrFreqVal
            // 
            this.lbl_SckWrFreqVal.AutoSize = true;
            this.lbl_SckWrFreqVal.Location = new System.Drawing.Point(123, 117);
            this.lbl_SckWrFreqVal.Name = "lbl_SckWrFreqVal";
            this.lbl_SckWrFreqVal.Size = new System.Drawing.Size(29, 17);
            this.lbl_SckWrFreqVal.TabIndex = 13;
            this.lbl_SckWrFreqVal.Text = "XXX";
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
            this.lbl_shwSysClkMhz.Location = new System.Drawing.Point(609, 117);
            this.lbl_shwSysClkMhz.Name = "lbl_shwSysClkMhz";
            this.lbl_shwSysClkMhz.Size = new System.Drawing.Size(33, 17);
            this.lbl_shwSysClkMhz.TabIndex = 9;
            this.lbl_shwSysClkMhz.Text = "Mhz";
            // 
            // lbl_shwSpiSysClk
            // 
            this.lbl_shwSpiSysClk.AutoSize = true;
            this.lbl_shwSpiSysClk.Location = new System.Drawing.Point(597, 80);
            this.lbl_shwSpiSysClk.Name = "lbl_shwSpiSysClk";
            this.lbl_shwSpiSysClk.Size = new System.Drawing.Size(89, 17);
            this.lbl_shwSpiSysClk.TabIndex = 8;
            this.lbl_shwSpiSysClk.Text = "(1~15)/ Sys.Clk";
            // 
            // lbl_spiSysClk
            // 
            this.lbl_spiSysClk.AutoSize = true;
            this.lbl_spiSysClk.Location = new System.Drawing.Point(597, 38);
            this.lbl_spiSysClk.Name = "lbl_spiSysClk";
            this.lbl_spiSysClk.Size = new System.Drawing.Size(89, 17);
            this.lbl_spiSysClk.TabIndex = 7;
            this.lbl_spiSysClk.Text = "(1~15)/ Sys.Clk";
            // 
            // TxtSpiWrSysClk
            // 
            this.TxtSpiWrSysClk.Enabled = false;
            this.TxtSpiWrSysClk.Location = new System.Drawing.Point(494, 114);
            this.TxtSpiWrSysClk.Name = "TxtSpiWrSysClk";
            this.TxtSpiWrSysClk.Size = new System.Drawing.Size(100, 24);
            this.TxtSpiWrSysClk.TabIndex = 6;
            this.TxtSpiWrSysClk.Text = "60";
            this.TxtSpiWrSysClk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            // 
            // TxtSpiWrSckH
            // 
            this.TxtSpiWrSckH.Location = new System.Drawing.Point(494, 35);
            this.TxtSpiWrSckH.Name = "TxtSpiWrSckH";
            this.TxtSpiWrSckH.Size = new System.Drawing.Size(100, 24);
            this.TxtSpiWrSckH.TabIndex = 4;
            this.TxtSpiWrSckH.Text = "0";
            this.TxtSpiWrSckH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtSpiWrSckH.Leave += new System.EventHandler(this.Txt_SpiWrAndRdClk_Leave);
            // 
            // TxtSpiWrSckL
            // 
            this.TxtSpiWrSckL.Location = new System.Drawing.Point(494, 77);
            this.TxtSpiWrSckL.Name = "TxtSpiWrSckL";
            this.TxtSpiWrSckL.Size = new System.Drawing.Size(100, 24);
            this.TxtSpiWrSckL.TabIndex = 5;
            this.TxtSpiWrSckL.Text = "0";
            this.TxtSpiWrSckL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtSpiWrSckL.Leave += new System.EventHandler(this.Txt_SpiWrAndRdClk_Leave);
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
            this.lbl_shwSckHVal.Location = new System.Drawing.Point(431, 38);
            this.lbl_shwSckHVal.Name = "lbl_shwSckHVal";
            this.lbl_shwSckHVal.Size = new System.Drawing.Size(65, 17);
            this.lbl_shwSckHVal.TabIndex = 2;
            this.lbl_shwSckHVal.Text = "SCK \"H\" = ";
            // 
            // lbl_shwScklVal
            // 
            this.lbl_shwScklVal.AutoSize = true;
            this.lbl_shwScklVal.Location = new System.Drawing.Point(431, 80);
            this.lbl_shwScklVal.Name = "lbl_shwScklVal";
            this.lbl_shwScklVal.Size = new System.Drawing.Size(62, 17);
            this.lbl_shwScklVal.TabIndex = 1;
            this.lbl_shwScklVal.Text = "SCK \"L\" = ";
            // 
            // PicSpiWrClk
            // 
            this.PicSpiWrClk.Image = global::XM_Tek_Studio_Pro.Properties.Resources.spi_sck_speed;
            this.PicSpiWrClk.Location = new System.Drawing.Point(18, 35);
            this.PicSpiWrClk.Name = "PicSpiWrClk";
            this.PicSpiWrClk.Size = new System.Drawing.Size(407, 103);
            this.PicSpiWrClk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicSpiWrClk.TabIndex = 0;
            this.PicSpiWrClk.TabStop = false;
            // 
            // Gbx_SpiType
            // 
            this.Gbx_SpiType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gbx_SpiType.Controls.Add(this.PicSpiInterfaceType);
            this.Gbx_SpiType.Controls.Add(this.Rbtn_spi3wire);
            this.Gbx_SpiType.Controls.Add(this.Rbtn_spi4wire);
            this.Gbx_SpiType.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gbx_SpiType.Location = new System.Drawing.Point(7, 3);
            this.Gbx_SpiType.Name = "Gbx_SpiType";
            this.Gbx_SpiType.Size = new System.Drawing.Size(692, 130);
            this.Gbx_SpiType.TabIndex = 4;
            this.Gbx_SpiType.TabStop = false;
            this.Gbx_SpiType.Text = "SPI Interface Type";
            // 
            // PicSpiInterfaceType
            // 
            this.PicSpiInterfaceType.Image = global::XM_Tek_Studio_Pro.Properties.Resources.spi_4w8b;
            this.PicSpiInterfaceType.Location = new System.Drawing.Point(3, 41);
            this.PicSpiInterfaceType.Name = "PicSpiInterfaceType";
            this.PicSpiInterfaceType.Size = new System.Drawing.Size(681, 83);
            this.PicSpiInterfaceType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicSpiInterfaceType.TabIndex = 2;
            this.PicSpiInterfaceType.TabStop = false;
            // 
            // Rbtn_spi3wire
            // 
            this.Rbtn_spi3wire.AutoSize = true;
            this.Rbtn_spi3wire.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_spi3wire.Location = new System.Drawing.Point(372, 14);
            this.Rbtn_spi3wire.Name = "Rbtn_spi3wire";
            this.Rbtn_spi3wire.Size = new System.Drawing.Size(201, 23);
            this.Rbtn_spi3wire.TabIndex = 1;
            this.Rbtn_spi3wire.Text = "3 wire, write 9bit/read 8bit";
            this.Rbtn_spi3wire.UseVisualStyleBackColor = true;
            this.Rbtn_spi3wire.CheckedChanged += new System.EventHandler(this.Rbtn_SpiIf_CheckedChanged);
            // 
            // Rbtn_spi4wire
            // 
            this.Rbtn_spi4wire.AutoSize = true;
            this.Rbtn_spi4wire.Checked = true;
            this.Rbtn_spi4wire.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_spi4wire.Location = new System.Drawing.Point(127, 14);
            this.Rbtn_spi4wire.Name = "Rbtn_spi4wire";
            this.Rbtn_spi4wire.Size = new System.Drawing.Size(176, 23);
            this.Rbtn_spi4wire.TabIndex = 0;
            this.Rbtn_spi4wire.TabStop = true;
            this.Rbtn_spi4wire.Text = "4 wire , write/read 8bit";
            this.Rbtn_spi4wire.UseVisualStyleBackColor = true;
            this.Rbtn_spi4wire.CheckedChanged += new System.EventHandler(this.Rbtn_SpiIf_CheckedChanged);
            // 
            // TabPg_SPI_2
            // 
            this.TabPg_SPI_2.Controls.Add(this.groupBox5);
            this.TabPg_SPI_2.Controls.Add(this.groupBox4);
            this.TabPg_SPI_2.Controls.Add(this.groupBox2);
            this.TabPg_SPI_2.Location = new System.Drawing.Point(4, 23);
            this.TabPg_SPI_2.Name = "TabPg_SPI_2";
            this.TabPg_SPI_2.Size = new System.Drawing.Size(707, 519);
            this.TabPg_SPI_2.TabIndex = 8;
            this.TabPg_SPI_2.Text = "SPI_2";
            this.TabPg_SPI_2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.PicCsSelCtrl);
            this.groupBox5.Controls.Add(this.Rbtn_SpiCsIntSel);
            this.groupBox5.Controls.Add(this.Rbtn_SpiCsByUser);
            this.groupBox5.Location = new System.Drawing.Point(5, 297);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(689, 141);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SPI CS Ctrl";
            // 
            // PicCsSelCtrl
            // 
            this.PicCsSelCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicCsSelCtrl.Image = global::XM_Tek_Studio_Pro.Properties.Resources.spi_csbyuser;
            this.PicCsSelCtrl.Location = new System.Drawing.Point(12, 45);
            this.PicCsSelCtrl.Name = "PicCsSelCtrl";
            this.PicCsSelCtrl.Size = new System.Drawing.Size(669, 84);
            this.PicCsSelCtrl.TabIndex = 0;
            this.PicCsSelCtrl.TabStop = false;
            // 
            // Rbtn_SpiCsIntSel
            // 
            this.Rbtn_SpiCsIntSel.AutoSize = true;
            this.Rbtn_SpiCsIntSel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_SpiCsIntSel.Location = new System.Drawing.Point(346, 16);
            this.Rbtn_SpiCsIntSel.Name = "Rbtn_SpiCsIntSel";
            this.Rbtn_SpiCsIntSel.Size = new System.Drawing.Size(169, 23);
            this.Rbtn_SpiCsIntSel.TabIndex = 2;
            this.Rbtn_SpiCsIntSel.Text = "Internal Module Cycle";
            this.Rbtn_SpiCsIntSel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rbtn_SpiCsIntSel.UseVisualStyleBackColor = true;
            this.Rbtn_SpiCsIntSel.CheckedChanged += new System.EventHandler(this.Rbtn_SpiCsSel_CheckedChanged);
            // 
            // Rbtn_SpiCsByUser
            // 
            this.Rbtn_SpiCsByUser.AutoSize = true;
            this.Rbtn_SpiCsByUser.Checked = true;
            this.Rbtn_SpiCsByUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_SpiCsByUser.Location = new System.Drawing.Point(124, 16);
            this.Rbtn_SpiCsByUser.Name = "Rbtn_SpiCsByUser";
            this.Rbtn_SpiCsByUser.Size = new System.Drawing.Size(175, 23);
            this.Rbtn_SpiCsByUser.TabIndex = 1;
            this.Rbtn_SpiCsByUser.TabStop = true;
            this.Rbtn_SpiCsByUser.Text = "Control CS Pin by User ";
            this.Rbtn_SpiCsByUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rbtn_SpiCsByUser.UseVisualStyleBackColor = true;
            this.Rbtn_SpiCsByUser.CheckedChanged += new System.EventHandler(this.Rbtn_SpiCsSel_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.PicSpiRdMode);
            this.groupBox4.Controls.Add(this.Rbtn_RdWithDummyClk);
            this.groupBox4.Controls.Add(this.Rbtn_RdWithNoDummy);
            this.groupBox4.Location = new System.Drawing.Point(5, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(689, 141);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SPI Read Dummy Clk";
            // 
            // PicSpiRdMode
            // 
            this.PicSpiRdMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicSpiRdMode.Image = global::XM_Tek_Studio_Pro.Properties.Resources.spi_rd_wdmy;
            this.PicSpiRdMode.Location = new System.Drawing.Point(12, 45);
            this.PicSpiRdMode.Name = "PicSpiRdMode";
            this.PicSpiRdMode.Size = new System.Drawing.Size(669, 84);
            this.PicSpiRdMode.TabIndex = 0;
            this.PicSpiRdMode.TabStop = false;
            // 
            // Rbtn_RdWithDummyClk
            // 
            this.Rbtn_RdWithDummyClk.AutoSize = true;
            this.Rbtn_RdWithDummyClk.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_RdWithDummyClk.Location = new System.Drawing.Point(346, 21);
            this.Rbtn_RdWithDummyClk.Name = "Rbtn_RdWithDummyClk";
            this.Rbtn_RdWithDummyClk.Size = new System.Drawing.Size(165, 23);
            this.Rbtn_RdWithDummyClk.TabIndex = 2;
            this.Rbtn_RdWithDummyClk.Text = "Read with dummy clk";
            this.Rbtn_RdWithDummyClk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rbtn_RdWithDummyClk.UseVisualStyleBackColor = true;
            this.Rbtn_RdWithDummyClk.CheckedChanged += new System.EventHandler(this.Rbtn_RdWithNoDummy_CheckedChanged);
            // 
            // Rbtn_RdWithNoDummy
            // 
            this.Rbtn_RdWithNoDummy.AutoSize = true;
            this.Rbtn_RdWithNoDummy.Checked = true;
            this.Rbtn_RdWithNoDummy.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_RdWithNoDummy.Location = new System.Drawing.Point(124, 16);
            this.Rbtn_RdWithNoDummy.Name = "Rbtn_RdWithNoDummy";
            this.Rbtn_RdWithNoDummy.Size = new System.Drawing.Size(186, 23);
            this.Rbtn_RdWithNoDummy.TabIndex = 1;
            this.Rbtn_RdWithNoDummy.TabStop = true;
            this.Rbtn_RdWithNoDummy.Text = "Read without dummy clk";
            this.Rbtn_RdWithNoDummy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rbtn_RdWithNoDummy.UseVisualStyleBackColor = true;
            this.Rbtn_RdWithNoDummy.CheckedChanged += new System.EventHandler(this.Rbtn_RdWithNoDummy_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.PicSpiLatchMode);
            this.groupBox2.Controls.Add(this.Rbtn_SpiRisingLatch);
            this.groupBox2.Controls.Add(this.Rbtn_SpiFallingLatch);
            this.groupBox2.Location = new System.Drawing.Point(5, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(689, 141);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SPI Sck Inv";
            // 
            // PicSpiLatchMode
            // 
            this.PicSpiLatchMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicSpiLatchMode.Image = global::XM_Tek_Studio_Pro.Properties.Resources.spi_ret;
            this.PicSpiLatchMode.Location = new System.Drawing.Point(8, 45);
            this.PicSpiLatchMode.Name = "PicSpiLatchMode";
            this.PicSpiLatchMode.Size = new System.Drawing.Size(675, 96);
            this.PicSpiLatchMode.TabIndex = 0;
            this.PicSpiLatchMode.TabStop = false;
            // 
            // Rbtn_SpiRisingLatch
            // 
            this.Rbtn_SpiRisingLatch.AutoSize = true;
            this.Rbtn_SpiRisingLatch.Checked = true;
            this.Rbtn_SpiRisingLatch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_SpiRisingLatch.Location = new System.Drawing.Point(124, 16);
            this.Rbtn_SpiRisingLatch.Name = "Rbtn_SpiRisingLatch";
            this.Rbtn_SpiRisingLatch.Size = new System.Drawing.Size(177, 23);
            this.Rbtn_SpiRisingLatch.TabIndex = 2;
            this.Rbtn_SpiRisingLatch.TabStop = true;
            this.Rbtn_SpiRisingLatch.Text = "Rising Edge Latch Data";
            this.Rbtn_SpiRisingLatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rbtn_SpiRisingLatch.UseVisualStyleBackColor = true;
            this.Rbtn_SpiRisingLatch.CheckedChanged += new System.EventHandler(this.Rbtn_SpiLatch_CheckedChanged);
            // 
            // Rbtn_SpiFallingLatch
            // 
            this.Rbtn_SpiFallingLatch.AutoSize = true;
            this.Rbtn_SpiFallingLatch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbtn_SpiFallingLatch.Location = new System.Drawing.Point(346, 16);
            this.Rbtn_SpiFallingLatch.Name = "Rbtn_SpiFallingLatch";
            this.Rbtn_SpiFallingLatch.Size = new System.Drawing.Size(180, 23);
            this.Rbtn_SpiFallingLatch.TabIndex = 1;
            this.Rbtn_SpiFallingLatch.Text = "Falling Edge Latch Data";
            this.Rbtn_SpiFallingLatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rbtn_SpiFallingLatch.UseVisualStyleBackColor = true;
            this.Rbtn_SpiFallingLatch.CheckedChanged += new System.EventHandler(this.Rbtn_SpiLatch_CheckedChanged);
            // 
            // TabPg_I2C
            // 
            this.TabPg_I2C.Controls.Add(this.gbx_setI2CTiming);
            this.TabPg_I2C.Location = new System.Drawing.Point(4, 23);
            this.TabPg_I2C.Name = "TabPg_I2C";
            this.TabPg_I2C.Size = new System.Drawing.Size(707, 519);
            this.TabPg_I2C.TabIndex = 4;
            this.TabPg_I2C.Text = "I2C";
            this.TabPg_I2C.UseVisualStyleBackColor = true;
            // 
            // gbx_setI2CTiming
            // 
            this.gbx_setI2CTiming.Controls.Add(this.PnlMsg);
            this.gbx_setI2CTiming.Controls.Add(this.Pnl_I2CImage);
            this.gbx_setI2CTiming.Controls.Add(this.panel2);
            this.gbx_setI2CTiming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_setI2CTiming.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_setI2CTiming.Location = new System.Drawing.Point(0, 0);
            this.gbx_setI2CTiming.Name = "gbx_setI2CTiming";
            this.gbx_setI2CTiming.Size = new System.Drawing.Size(707, 519);
            this.gbx_setI2CTiming.TabIndex = 0;
            this.gbx_setI2CTiming.TabStop = false;
            this.gbx_setI2CTiming.Text = "I2C Timing Setting";
            // 
            // PnlMsg
            // 
            this.PnlMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMsg.Location = new System.Drawing.Point(3, 371);
            this.PnlMsg.Name = "PnlMsg";
            this.PnlMsg.Size = new System.Drawing.Size(701, 145);
            this.PnlMsg.TabIndex = 2;
            // 
            // Pnl_I2CImage
            // 
            this.Pnl_I2CImage.Controls.Add(this.PicBoxI2C);
            this.Pnl_I2CImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_I2CImage.Location = new System.Drawing.Point(3, 180);
            this.Pnl_I2CImage.Name = "Pnl_I2CImage";
            this.Pnl_I2CImage.Size = new System.Drawing.Size(701, 191);
            this.Pnl_I2CImage.TabIndex = 1;
            // 
            // PicBoxI2C
            // 
            this.PicBoxI2C.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxI2C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBoxI2C.Image = global::XM_Tek_Studio_Pro.Properties.Resources.i2c_timing;
            this.PicBoxI2C.Location = new System.Drawing.Point(0, 0);
            this.PicBoxI2C.Name = "PicBoxI2C";
            this.PicBoxI2C.Size = new System.Drawing.Size(701, 191);
            this.PicBoxI2C.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxI2C.TabIndex = 0;
            this.PicBoxI2C.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbl_i2csckL);
            this.panel2.Controls.Add(this.lbl_i2csckH);
            this.panel2.Controls.Add(this.lbl_seti2Mhz);
            this.panel2.Controls.Add(this.LblI2cFreqVal);
            this.panel2.Controls.Add(this.lbl_shwi2cSckFreq);
            this.panel2.Controls.Add(this.lbl_shwI2CSck);
            this.panel2.Controls.Add(this.lbl_shwi2cSysClk);
            this.panel2.Controls.Add(this.PicI2cTiming);
            this.panel2.Controls.Add(this.lbl_shwi2cMhz);
            this.panel2.Controls.Add(this.lbl_shwdivideClk);
            this.panel2.Controls.Add(this.lbl_i2cTimeSysClk);
            this.panel2.Controls.Add(this.TxtI2CSysClk);
            this.panel2.Controls.Add(this.TxtI2CSckH);
            this.panel2.Controls.Add(this.TxtI2CSckL);
            this.panel2.Controls.Add(this.lbl_i2cshowSysClk);
            this.panel2.Controls.Add(this.lbl_shwi2cSckH);
            this.panel2.Controls.Add(this.lbl_shwi2cSckL);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(701, 160);
            this.panel2.TabIndex = 0;
            // 
            // lbl_i2csckL
            // 
            this.lbl_i2csckL.AutoSize = true;
            this.lbl_i2csckL.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_i2csckL.Location = new System.Drawing.Point(286, 70);
            this.lbl_i2csckL.Name = "lbl_i2csckL";
            this.lbl_i2csckL.Size = new System.Drawing.Size(31, 19);
            this.lbl_i2csckL.TabIndex = 29;
            this.lbl_i2csckL.Text = "\"H\"";
            // 
            // lbl_i2csckH
            // 
            this.lbl_i2csckH.AutoSize = true;
            this.lbl_i2csckH.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_i2csckH.Location = new System.Drawing.Point(161, 68);
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
            // LblI2cFreqVal
            // 
            this.LblI2cFreqVal.AutoSize = true;
            this.LblI2cFreqVal.Location = new System.Drawing.Point(160, 110);
            this.LblI2cFreqVal.Name = "LblI2cFreqVal";
            this.LblI2cFreqVal.Size = new System.Drawing.Size(29, 17);
            this.LblI2cFreqVal.TabIndex = 26;
            this.LblI2cFreqVal.Text = "XXX";
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
            // PicI2cTiming
            // 
            this.PicI2cTiming.Image = global::XM_Tek_Studio_Pro.Properties.Resources.spi_sck_speed;
            this.PicI2cTiming.Location = new System.Drawing.Point(18, 13);
            this.PicI2cTiming.Name = "PicI2cTiming";
            this.PicI2cTiming.Size = new System.Drawing.Size(400, 139);
            this.PicI2cTiming.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicI2cTiming.TabIndex = 22;
            this.PicI2cTiming.TabStop = false;
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
            // TxtI2CSysClk
            // 
            this.TxtI2CSysClk.Location = new System.Drawing.Point(520, 104);
            this.TxtI2CSysClk.Name = "TxtI2CSysClk";
            this.TxtI2CSysClk.Size = new System.Drawing.Size(100, 24);
            this.TxtI2CSysClk.TabIndex = 15;
            this.TxtI2CSysClk.Text = "0";
            // 
            // TxtI2CSckH
            // 
            this.TxtI2CSckH.Location = new System.Drawing.Point(520, 29);
            this.TxtI2CSckH.Name = "TxtI2CSckH";
            this.TxtI2CSckH.Size = new System.Drawing.Size(100, 24);
            this.TxtI2CSckH.TabIndex = 13;
            this.TxtI2CSckH.Text = "0";
            this.TxtI2CSckH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtI2CSckH.Leave += new System.EventHandler(this.Txt_SpiSck_Leave);
            // 
            // TxtI2CSckL
            // 
            this.TxtI2CSckL.Location = new System.Drawing.Point(520, 67);
            this.TxtI2CSckL.Name = "TxtI2CSckL";
            this.TxtI2CSckL.Size = new System.Drawing.Size(100, 24);
            this.TxtI2CSckL.TabIndex = 14;
            this.TxtI2CSckL.Text = "0";
            this.TxtI2CSckL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBox_TabKeySend_KeyDown);
            this.TxtI2CSckL.Leave += new System.EventHandler(this.Txt_SpiSck_Leave);
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
            this.lbl_shwi2cSckH.Location = new System.Drawing.Point(430, 32);
            this.lbl_shwi2cSckH.Name = "lbl_shwi2cSckH";
            this.lbl_shwi2cSckH.Size = new System.Drawing.Size(65, 17);
            this.lbl_shwi2cSckH.TabIndex = 11;
            this.lbl_shwi2cSckH.Text = "SCK \"H\" = ";
            // 
            // lbl_shwi2cSckL
            // 
            this.lbl_shwi2cSckL.AutoSize = true;
            this.lbl_shwi2cSckL.Location = new System.Drawing.Point(433, 70);
            this.lbl_shwi2cSckL.Name = "lbl_shwi2cSckL";
            this.lbl_shwi2cSckL.Size = new System.Drawing.Size(62, 17);
            this.lbl_shwi2cSckL.TabIndex = 10;
            this.lbl_shwi2cSckL.Text = "SCK \"L\" = ";
            // 
            // TabPg_Finish
            // 
            this.TabPg_Finish.Controls.Add(this.Gpx_IfCmd);
            this.TabPg_Finish.Location = new System.Drawing.Point(4, 23);
            this.TabPg_Finish.Name = "TabPg_Finish";
            this.TabPg_Finish.Size = new System.Drawing.Size(707, 519);
            this.TabPg_Finish.TabIndex = 7;
            this.TabPg_Finish.Text = "Finished";
            this.TabPg_Finish.UseVisualStyleBackColor = true;
            // 
            // Gpx_IfCmd
            // 
            this.Gpx_IfCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gpx_IfCmd.Location = new System.Drawing.Point(0, 0);
            this.Gpx_IfCmd.Name = "Gpx_IfCmd";
            this.Gpx_IfCmd.Size = new System.Drawing.Size(707, 519);
            this.Gpx_IfCmd.TabIndex = 1;
            this.Gpx_IfCmd.TabStop = false;
            this.Gpx_IfCmd.Text = "Command";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnNext);
            this.panel1.Controls.Add(this.BtnPrev);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(227, 568);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 61);
            this.panel1.TabIndex = 0;
            // 
            // BtnNext
            // 
            this.BtnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNext.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNext.Location = new System.Drawing.Point(601, 17);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(95, 32);
            this.BtnNext.TabIndex = 1;
            this.BtnNext.Text = "Next";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnPrev
            // 
            this.BtnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrev.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrev.Location = new System.Drawing.Point(492, 17);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(92, 32);
            this.BtnPrev.TabIndex = 0;
            this.BtnPrev.Text = "Prev";
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // TrvInterface
            // 
            this.TrvInterface.Dock = System.Windows.Forms.DockStyle.Left;
            this.TrvInterface.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrvInterface.HideSelection = false;
            this.TrvInterface.Location = new System.Drawing.Point(3, 22);
            this.TrvInterface.Name = "TrvInterface";
            treeNode1.Name = "TrvNode_Interface";
            treeNode1.Text = "1.Interface";
            treeNode2.Name = "TrvNode_CPU";
            treeNode2.Text = "2.CPU";
            treeNode3.Name = "TrvNode_RGBTiming";
            treeNode3.Text = "3.RGB Timing";
            treeNode4.Name = "TrvNode_Interface";
            treeNode4.Text = "4.RGB Interface";
            treeNode5.Name = "TrvNode_SPI_1";
            treeNode5.Text = "5.SPI_1";
            treeNode6.Name = "TrvNode_SPI_2";
            treeNode6.Text = "6.SPI_2";
            treeNode7.Name = "TrvNode_I2C";
            treeNode7.Text = "6.I2C";
            treeNode8.Name = "TrvNode_Finish";
            treeNode8.Text = "7.Finish";
            this.TrvInterface.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.TrvInterface.Size = new System.Drawing.Size(224, 607);
            this.TrvInterface.TabIndex = 0;
            this.TrvInterface.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.TrvInterface_DrawNode);
            this.TrvInterface.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvInterface_AfterSelect);
            // 
            // CmsGeneralSet
            // 
            this.CmsGeneralSet.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmsGeneralSet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToClipBoradToolStripMenuItem});
            this.CmsGeneralSet.Name = "CmsGeneralSet";
            this.CmsGeneralSet.Size = new System.Drawing.Size(169, 26);
            this.CmsGeneralSet.Text = "Help";
            // 
            // CopyToClipBoradToolStripMenuItem
            // 
            this.CopyToClipBoradToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Save_48x48;
            this.CopyToClipBoradToolStripMenuItem.Name = "CopyToClipBoradToolStripMenuItem";
            this.CopyToClipBoradToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.CopyToClipBoradToolStripMenuItem.Text = "CopyToClipBorad";
            this.CopyToClipBoradToolStripMenuItem.Click += new System.EventHandler(this.CopyToClipBoradToolStripMenuItem_Click);
            // 
            // InterfaceSetting_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(945, 632);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InterfaceSetting_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AutoSet Page";
            this.Load += new System.EventHandler(this.InterfaceSetting_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.TabCtrlf.ResumeLayout(false);
            this.TabPg_Interface.ResumeLayout(false);
            this.gbx_InitConfig.ResumeLayout(false);
            this.gbx_InitConfig.PerformLayout();
            this.gbx_FpgaSetting.ResumeLayout(false);
            this.gbx_FpgaSetting.PerformLayout();
            this.TabPg_CPU.ResumeLayout(false);
            this.gbx_busDef.ResumeLayout(false);
            this.gbx_busDef.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DataBusDef)).EndInit();
            this.gbx_CpuModeSel.ResumeLayout(false);
            this.gbx_CpuModeSel.PerformLayout();
            this.TabPg_RgbTiming.ResumeLayout(false);
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
            this.TabPg_RgbInterface.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_showDataBus)).EndInit();
            this.gbx_dataBusType.ResumeLayout(false);
            this.gbx_dataBusType.PerformLayout();
            this.gbx_rgbInterface.ResumeLayout(false);
            this.gbx_rgbInterface.PerformLayout();
            this.TabPg_SPI_1.ResumeLayout(false);
            this.Gbx_SpiRdSck.ResumeLayout(false);
            this.Gbx_SpiRdSck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSpiRdClk)).EndInit();
            this.Gbx_SpiWrSck.ResumeLayout(false);
            this.Gbx_SpiWrSck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSpiWrClk)).EndInit();
            this.Gbx_SpiType.ResumeLayout(false);
            this.Gbx_SpiType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSpiInterfaceType)).EndInit();
            this.TabPg_SPI_2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCsSelCtrl)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSpiRdMode)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSpiLatchMode)).EndInit();
            this.TabPg_I2C.ResumeLayout(false);
            this.gbx_setI2CTiming.ResumeLayout(false);
            this.Pnl_I2CImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxI2C)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicI2cTiming)).EndInit();
            this.TabPg_Finish.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.CmsGeneralSet.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView TrvInterface;
        private System.Windows.Forms.TabControl TabCtrlf;
        private System.Windows.Forms.TabPage TabPg_Interface;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbx_FpgaSetting;
        private System.Windows.Forms.Label lbl_sysClk;
        private System.Windows.Forms.ComboBox CboFpgaIf;
        private System.Windows.Forms.Label lbl_interface;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.TabPage TabPg_CPU;
        private System.Windows.Forms.TabPage TabPg_RgbTiming;
        private System.Windows.Forms.TabPage TabPg_SPI_1;
        private System.Windows.Forms.TabPage TabPg_RgbInterface;
        private System.Windows.Forms.GroupBox gbx_InitConfig;
        private System.Windows.Forms.Label lbl_defaultConfig;
        private System.Windows.Forms.Label lbl_loadConfig;
        private System.Windows.Forms.Button BtnSetDefault;
        private System.Windows.Forms.Button BtnLoadConfig;
        private System.Windows.Forms.TextBox TxtSysClk;
        private System.Windows.Forms.GroupBox gbx_busDef;
        private System.Windows.Forms.PictureBox pic_DataBusDef;
        private System.Windows.Forms.RadioButton Rbtn_18bitD17D0;
        private System.Windows.Forms.RadioButton Rbtn_18bitD23D0;
        private System.Windows.Forms.RadioButton Rbtn_9bitD17D9;
        private System.Windows.Forms.RadioButton Rbtn_16bitD15D0;
        private System.Windows.Forms.RadioButton Rbtn_16bitD17D10D8D1;
        private System.Windows.Forms.RadioButton Rbtn_9bitD8D0;
        private System.Windows.Forms.RadioButton Rbtn_8bitD17D10;
        private System.Windows.Forms.RadioButton Rbtn_8BitD7D0;
        private System.Windows.Forms.GroupBox gbx_CpuModeSel;
        private System.Windows.Forms.RadioButton RbtnM68;
        private System.Windows.Forms.RadioButton RbtnI80;
        private System.Windows.Forms.GroupBox gbx_polarity;
        private System.Windows.Forms.GroupBox gbx_timeset;
        private System.Windows.Forms.TextBox TxtVSyncSum;
        private System.Windows.Forms.TextBox TxtVfp;
        private System.Windows.Forms.TextBox TxtVactive;
        private System.Windows.Forms.TextBox TxtVbp;
        private System.Windows.Forms.TextBox TxtVsync;
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
        private System.Windows.Forms.TextBox TxtHSyncSum;
        private System.Windows.Forms.TextBox TxtHfp;
        private System.Windows.Forms.TextBox TxtHactive;
        private System.Windows.Forms.TextBox TxtHbp;
        private System.Windows.Forms.TextBox TxtHsync;
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
        private System.Windows.Forms.TextBox TxtPixelClk;
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
        private System.Windows.Forms.RadioButton Rbtn_24bitD23;
        private System.Windows.Forms.RadioButton Rbtn_18bitD21;
        private System.Windows.Forms.RadioButton Rbtn_18bitD17;
        private System.Windows.Forms.RadioButton Rbtn_16bitD21;
        private System.Windows.Forms.RadioButton Rbtn_16bitD17;
        private System.Windows.Forms.RadioButton Rbtn_16bitD15;
        private System.Windows.Forms.RadioButton Rbtn_8bit;
        private System.Windows.Forms.RadioButton Rbtn_6bit;
        private System.Windows.Forms.GroupBox gbx_rgbInterface;
        private System.Windows.Forms.RadioButton Rbtn_DeMod;
        private System.Windows.Forms.RadioButton Rbtn_HsVsMod;
        private System.Windows.Forms.RadioButton Rbtn_HsVsDeMod;
        private System.Windows.Forms.PictureBox pic_showDataBus;
        private System.Windows.Forms.GroupBox Gbx_SpiWrSck;
        private System.Windows.Forms.Label lbl_SckMhz;
        private System.Windows.Forms.Label lbl_SckWrFreqVal;
        private System.Windows.Forms.Label lbl_shwSckFreq;
        private System.Windows.Forms.Label lbl_shwSck;
        private System.Windows.Forms.Label lbl_shwSysClk;
        private System.Windows.Forms.Label lbl_shwSpiSysClk;
        private System.Windows.Forms.Label lbl_spiSysClk;
        private System.Windows.Forms.TextBox TxtSpiWrSckH;
        private System.Windows.Forms.TextBox TxtSpiWrSckL;
        private System.Windows.Forms.Label lbl_shwSckHVal;
        private System.Windows.Forms.Label lbl_shwScklVal;
        private System.Windows.Forms.PictureBox PicSpiWrClk;
        private System.Windows.Forms.GroupBox Gbx_SpiType;
        private System.Windows.Forms.PictureBox PicSpiInterfaceType;
        private System.Windows.Forms.RadioButton Rbtn_spi3wire;
        private System.Windows.Forms.RadioButton Rbtn_spi4wire;
        private System.Windows.Forms.Label lbl_shwSckL;
        private System.Windows.Forms.Label lbl_shwSckH;
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
        private System.Windows.Forms.TabPage TabPg_I2C;
        private System.Windows.Forms.GroupBox gbx_setI2CTiming;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_i2csckL;
        private System.Windows.Forms.Label lbl_i2csckH;
        private System.Windows.Forms.Label lbl_seti2Mhz;
        private System.Windows.Forms.Label LblI2cFreqVal;
        private System.Windows.Forms.Label lbl_shwi2cSckFreq;
        private System.Windows.Forms.Label lbl_shwI2CSck;
        private System.Windows.Forms.Label lbl_shwi2cSysClk;
        private System.Windows.Forms.PictureBox PicI2cTiming;
        private System.Windows.Forms.Label lbl_shwi2cMhz;
        private System.Windows.Forms.Label lbl_shwdivideClk;
        private System.Windows.Forms.Label lbl_i2cTimeSysClk;
        private System.Windows.Forms.TextBox TxtI2CSysClk;
        private System.Windows.Forms.TextBox TxtI2CSckH;
        private System.Windows.Forms.TextBox TxtI2CSckL;
        private System.Windows.Forms.Label lbl_i2cshowSysClk;
        private System.Windows.Forms.Label lbl_shwi2cSckH;
        private System.Windows.Forms.Label lbl_shwi2cSckL;
        private System.Windows.Forms.Panel PnlMsg;
        private System.Windows.Forms.Panel Pnl_I2CImage;
        private System.Windows.Forms.PictureBox PicBoxI2C;
        private System.Windows.Forms.TabPage TabPg_Finish;
        private System.Windows.Forms.GroupBox Gpx_IfCmd;
        private System.Windows.Forms.ContextMenuStrip CmsGeneralSet;
        private System.Windows.Forms.ToolStripMenuItem CopyToClipBoradToolStripMenuItem;
        private System.Windows.Forms.Label LblFileName;
        private System.Windows.Forms.TabPage TabPg_SPI_2;
        private System.Windows.Forms.GroupBox Gbx_SpiRdSck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_SckRdFreqVal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtSpiRdSckH;
        private System.Windows.Forms.TextBox TxtSpiRdSckL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox PicSpiRdClk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox PicSpiLatchMode;
        private System.Windows.Forms.RadioButton Rbtn_SpiRisingLatch;
        private System.Windows.Forms.RadioButton Rbtn_SpiFallingLatch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton Rbtn_RdWithDummyClk;
        private System.Windows.Forms.RadioButton Rbtn_RdWithNoDummy;
        private System.Windows.Forms.PictureBox PicSpiRdMode;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox PicCsSelCtrl;
        private System.Windows.Forms.RadioButton Rbtn_SpiCsIntSel;
        private System.Windows.Forms.RadioButton Rbtn_SpiCsByUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtSpiRdSysClk;
        private System.Windows.Forms.Label lbl_shwSysClkMhz;
        private System.Windows.Forms.TextBox TxtSpiWrSysClk;
        private System.Windows.Forms.Label lbl_shwSysClkVal;
    }
}
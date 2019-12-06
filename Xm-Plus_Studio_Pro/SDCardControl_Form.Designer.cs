namespace XM_Tek_Studio_Pro
{
    partial class SDCardControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RichTextBox_SDCardReadInfo = new System.Windows.Forms.RichTextBox();
            this.statusStrip_SDCard = new System.Windows.Forms.StatusStrip();
            this.toolStrStaLab_SDCardStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.SDCardControBar = new System.Windows.Forms.ToolStripProgressBar();
            this.TabControl_SDCard = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Button_Next = new System.Windows.Forms.Button();
            this.groupBox_SDStatus = new System.Windows.Forms.GroupBox();
            this.button_Download_All = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_ReadBlockNums = new System.Windows.Forms.TextBox();
            this.textBox_ReadStartAddr = new System.Windows.Forms.TextBox();
            this.button_Multi_RD = new System.Windows.Forms.Button();
            this.button_Single_RD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.groupBox_SD_Info = new System.Windows.Forms.GroupBox();
            this.button_Save_SDInfo = new System.Windows.Forms.Button();
            this.button_Load_SDInfo = new System.Windows.Forms.Button();
            this.DataGridView_SDCard = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Button_Prev = new System.Windows.Forms.Button();
            this.groupBox_Function = new System.Windows.Forms.GroupBox();
            this.Button_Load = new System.Windows.Forms.Button();
            this.Button_Save = new System.Windows.Forms.Button();
            this.groupBox_SD_Program = new System.Windows.Forms.GroupBox();
            this.groupBox_Result = new System.Windows.Forms.GroupBox();
            this.statusStrip_SDCard.SuspendLayout();
            this.TabControl_SDCard.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_SDStatus.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox_SD_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_SDCard)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox_Function.SuspendLayout();
            this.groupBox_Result.SuspendLayout();
            this.SuspendLayout();
            // 
            // RichTextBox_SDCardReadInfo
            // 
            this.RichTextBox_SDCardReadInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBox_SDCardReadInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RichTextBox_SDCardReadInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox_SDCardReadInfo.Location = new System.Drawing.Point(6, 22);
            this.RichTextBox_SDCardReadInfo.Name = "RichTextBox_SDCardReadInfo";
            this.RichTextBox_SDCardReadInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RichTextBox_SDCardReadInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.RichTextBox_SDCardReadInfo.Size = new System.Drawing.Size(453, 553);
            this.RichTextBox_SDCardReadInfo.TabIndex = 6;
            this.RichTextBox_SDCardReadInfo.Text = "";
            this.RichTextBox_SDCardReadInfo.TextChanged += new System.EventHandler(this.RichTextBox_SDCardReadInfo_TextChanged);
            this.RichTextBox_SDCardReadInfo.DoubleClick += new System.EventHandler(this.RichTextBox_SDCardReadInfo_DoubleClick);
            // 
            // statusStrip_SDCard
            // 
            this.statusStrip_SDCard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusStrip_SDCard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip_SDCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrStaLab_SDCardStatus,
            this.SDCardControBar});
            this.statusStrip_SDCard.Location = new System.Drawing.Point(0, 588);
            this.statusStrip_SDCard.Name = "statusStrip_SDCard";
            this.statusStrip_SDCard.Size = new System.Drawing.Size(1046, 31);
            this.statusStrip_SDCard.TabIndex = 7;
            this.statusStrip_SDCard.Text = "No Found SDCARD";
            // 
            // toolStrStaLab_SDCardStatus
            // 
            this.toolStrStaLab_SDCardStatus.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrStaLab_SDCardStatus.Name = "toolStrStaLab_SDCardStatus";
            this.toolStrStaLab_SDCardStatus.Size = new System.Drawing.Size(148, 26);
            this.toolStrStaLab_SDCardStatus.Text = "SD Card Status :";
            // 
            // SDCardControBar
            // 
            this.SDCardControBar.Maximum = 100000;
            this.SDCardControBar.Name = "SDCardControBar";
            this.SDCardControBar.Size = new System.Drawing.Size(430, 25);
            // 
            // TabControl_SDCard
            // 
            this.TabControl_SDCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_SDCard.Controls.Add(this.tabPage1);
            this.TabControl_SDCard.Controls.Add(this.tabPage2);
            this.TabControl_SDCard.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl_SDCard.Location = new System.Drawing.Point(8, 5);
            this.TabControl_SDCard.Name = "TabControl_SDCard";
            this.TabControl_SDCard.SelectedIndex = 0;
            this.TabControl_SDCard.Size = new System.Drawing.Size(565, 581);
            this.TabControl_SDCard.TabIndex = 0;
            this.TabControl_SDCard.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.Button_Next);
            this.tabPage1.Controls.Add(this.groupBox_SDStatus);
            this.tabPage1.Controls.Add(this.groupBox_SD_Info);
            this.tabPage1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(557, 554);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SD Init";
            // 
            // Button_Next
            // 
            this.Button_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Next.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Next.Location = new System.Drawing.Point(474, 392);
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.Size = new System.Drawing.Size(75, 154);
            this.Button_Next.TabIndex = 10;
            this.Button_Next.Text = "Prevent";
            this.Button_Next.UseVisualStyleBackColor = true;
            this.Button_Next.Click += new System.EventHandler(this.Button_Next_Click);
            // 
            // groupBox_SDStatus
            // 
            this.groupBox_SDStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_SDStatus.Controls.Add(this.button_Download_All);
            this.groupBox_SDStatus.Controls.Add(this.groupBox3);
            this.groupBox_SDStatus.Controls.Add(this.button_Connect);
            this.groupBox_SDStatus.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_SDStatus.ForeColor = System.Drawing.Color.Black;
            this.groupBox_SDStatus.Location = new System.Drawing.Point(6, 386);
            this.groupBox_SDStatus.Name = "groupBox_SDStatus";
            this.groupBox_SDStatus.Size = new System.Drawing.Size(462, 159);
            this.groupBox_SDStatus.TabIndex = 4;
            this.groupBox_SDStatus.TabStop = false;
            this.groupBox_SDStatus.Text = "SDCard Connect and Read";
            // 
            // button_Download_All
            // 
            this.button_Download_All.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Download_All.Location = new System.Drawing.Point(5, 77);
            this.button_Download_All.Name = "button_Download_All";
            this.button_Download_All.Size = new System.Drawing.Size(162, 76);
            this.button_Download_All.TabIndex = 6;
            this.button_Download_All.Text = "Download";
            this.button_Download_All.UseVisualStyleBackColor = true;
            this.button_Download_All.Click += new System.EventHandler(this.Button_Download_All_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.textBox_ReadBlockNums);
            this.groupBox3.Controls.Add(this.textBox_ReadStartAddr);
            this.groupBox3.Controls.Add(this.button_Multi_RD);
            this.groupBox3.Controls.Add(this.button_Single_RD);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(174, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 138);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SDCard Read( Block / Uint )";
            // 
            // textBox_ReadBlockNums
            // 
            this.textBox_ReadBlockNums.Location = new System.Drawing.Point(33, 108);
            this.textBox_ReadBlockNums.Name = "textBox_ReadBlockNums";
            this.textBox_ReadBlockNums.Size = new System.Drawing.Size(69, 22);
            this.textBox_ReadBlockNums.TabIndex = 5;
            this.textBox_ReadBlockNums.Text = "0x00000001";
            // 
            // textBox_ReadStartAddr
            // 
            this.textBox_ReadStartAddr.Location = new System.Drawing.Point(33, 46);
            this.textBox_ReadStartAddr.Name = "textBox_ReadStartAddr";
            this.textBox_ReadStartAddr.Size = new System.Drawing.Size(69, 22);
            this.textBox_ReadStartAddr.TabIndex = 4;
            this.textBox_ReadStartAddr.Text = "0x00000000";
            // 
            // button_Multi_RD
            // 
            this.button_Multi_RD.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Multi_RD.Location = new System.Drawing.Point(150, 79);
            this.button_Multi_RD.Name = "button_Multi_RD";
            this.button_Multi_RD.Size = new System.Drawing.Size(120, 56);
            this.button_Multi_RD.TabIndex = 3;
            this.button_Multi_RD.Text = "Multi-RD";
            this.button_Multi_RD.UseVisualStyleBackColor = true;
            this.button_Multi_RD.Click += new System.EventHandler(this.Button_Multi_RD_Click);
            // 
            // button_Single_RD
            // 
            this.button_Single_RD.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Single_RD.Location = new System.Drawing.Point(150, 17);
            this.button_Single_RD.Name = "button_Single_RD";
            this.button_Single_RD.Size = new System.Drawing.Size(120, 56);
            this.button_Single_RD.TabIndex = 2;
            this.button_Single_RD.Text = "Single-RD";
            this.button_Single_RD.UseVisualStyleBackColor = true;
            this.button_Single_RD.Click += new System.EventHandler(this.Button_Single_RD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Block Numbers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start   Addrress";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_Connect
            // 
            this.button_Connect.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Connect.Location = new System.Drawing.Point(6, 21);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(162, 50);
            this.button_Connect.TabIndex = 0;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.Button_Connect_Click);
            // 
            // groupBox_SD_Info
            // 
            this.groupBox_SD_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_SD_Info.Controls.Add(this.button_Save_SDInfo);
            this.groupBox_SD_Info.Controls.Add(this.button_Load_SDInfo);
            this.groupBox_SD_Info.Controls.Add(this.DataGridView_SDCard);
            this.groupBox_SD_Info.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_SD_Info.ForeColor = System.Drawing.Color.Black;
            this.groupBox_SD_Info.Location = new System.Drawing.Point(6, 2);
            this.groupBox_SD_Info.Name = "groupBox_SD_Info";
            this.groupBox_SD_Info.Size = new System.Drawing.Size(543, 379);
            this.groupBox_SD_Info.TabIndex = 3;
            this.groupBox_SD_Info.TabStop = false;
            this.groupBox_SD_Info.Text = "MicroSD info Table";
            // 
            // button_Save_SDInfo
            // 
            this.button_Save_SDInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save_SDInfo.Location = new System.Drawing.Point(5, 333);
            this.button_Save_SDInfo.Name = "button_Save_SDInfo";
            this.button_Save_SDInfo.Size = new System.Drawing.Size(266, 40);
            this.button_Save_SDInfo.TabIndex = 4;
            this.button_Save_SDInfo.Text = "Save as";
            this.button_Save_SDInfo.UseVisualStyleBackColor = true;
            this.button_Save_SDInfo.Click += new System.EventHandler(this.Button_Save_SDInfo_Click);
            // 
            // button_Load_SDInfo
            // 
            this.button_Load_SDInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Load_SDInfo.Location = new System.Drawing.Point(271, 333);
            this.button_Load_SDInfo.Name = "button_Load_SDInfo";
            this.button_Load_SDInfo.Size = new System.Drawing.Size(267, 40);
            this.button_Load_SDInfo.TabIndex = 3;
            this.button_Load_SDInfo.Text = "Load";
            this.button_Load_SDInfo.UseVisualStyleBackColor = true;
            this.button_Load_SDInfo.Click += new System.EventHandler(this.Button_Load_SDInfo_Click);
            // 
            // DataGridView_SDCard
            // 
            this.DataGridView_SDCard.AllowUserToResizeColumns = false;
            this.DataGridView_SDCard.AllowUserToResizeRows = false;
            this.DataGridView_SDCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DataGridView_SDCard.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_SDCard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView_SDCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_SDCard.DefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridView_SDCard.Location = new System.Drawing.Point(228, 127);
            this.DataGridView_SDCard.Name = "DataGridView_SDCard";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_SDCard.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridView_SDCard.RowHeadersWidth = 60;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_SDCard.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridView_SDCard.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataGridView_SDCard.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_SDCard.RowTemplate.Height = 24;
            this.DataGridView_SDCard.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_SDCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView_SDCard.Size = new System.Drawing.Size(76, 40);
            this.DataGridView_SDCard.TabIndex = 2;
            this.DataGridView_SDCard.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView_SDCard_CellBeginEdit);
            this.DataGridView_SDCard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_SDCard_CellContentClick);
            this.DataGridView_SDCard.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_SDCard_CellValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.Button_Prev);
            this.tabPage2.Controls.Add(this.groupBox_Function);
            this.tabPage2.Controls.Add(this.groupBox_SD_Program);
            this.tabPage2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(557, 554);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Download SDCard";
            // 
            // Button_Prev
            // 
            this.Button_Prev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Prev.Location = new System.Drawing.Point(473, 417);
            this.Button_Prev.Name = "Button_Prev";
            this.Button_Prev.Size = new System.Drawing.Size(75, 125);
            this.Button_Prev.TabIndex = 11;
            this.Button_Prev.Text = "Next";
            this.Button_Prev.UseVisualStyleBackColor = true;
            this.Button_Prev.Click += new System.EventHandler(this.Button_Prev_Click);
            // 
            // groupBox_Function
            // 
            this.groupBox_Function.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Function.Controls.Add(this.Button_Load);
            this.groupBox_Function.Controls.Add(this.Button_Save);
            this.groupBox_Function.Location = new System.Drawing.Point(4, 410);
            this.groupBox_Function.Name = "groupBox_Function";
            this.groupBox_Function.Size = new System.Drawing.Size(463, 133);
            this.groupBox_Function.TabIndex = 6;
            this.groupBox_Function.TabStop = false;
            this.groupBox_Function.Text = "Function";
            // 
            // Button_Load
            // 
            this.Button_Load.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Load.Location = new System.Drawing.Point(101, 27);
            this.Button_Load.Name = "Button_Load";
            this.Button_Load.Size = new System.Drawing.Size(89, 106);
            this.Button_Load.TabIndex = 10;
            this.Button_Load.Text = "Load File Log";
            this.Button_Load.UseVisualStyleBackColor = true;
            this.Button_Load.Click += new System.EventHandler(this.Button_Load_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Save.Location = new System.Drawing.Point(6, 27);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(89, 106);
            this.Button_Save.TabIndex = 9;
            this.Button_Save.Text = "Save File Log";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // groupBox_SD_Program
            // 
            this.groupBox_SD_Program.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_SD_Program.Location = new System.Drawing.Point(4, 3);
            this.groupBox_SD_Program.Name = "groupBox_SD_Program";
            this.groupBox_SD_Program.Size = new System.Drawing.Size(544, 408);
            this.groupBox_SD_Program.TabIndex = 0;
            this.groupBox_SD_Program.TabStop = false;
            this.groupBox_SD_Program.Text = "Program";
            // 
            // groupBox_Result
            // 
            this.groupBox_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Result.Controls.Add(this.RichTextBox_SDCardReadInfo);
            this.groupBox_Result.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Result.Location = new System.Drawing.Point(579, 5);
            this.groupBox_Result.Name = "groupBox_Result";
            this.groupBox_Result.Size = new System.Drawing.Size(465, 581);
            this.groupBox_Result.TabIndex = 9;
            this.groupBox_Result.TabStop = false;
            this.groupBox_Result.Text = "Result";
            // 
            // SDCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1046, 619);
            this.Controls.Add(this.groupBox_Result);
            this.Controls.Add(this.TabControl_SDCard);
            this.Controls.Add(this.statusStrip_SDCard);
            this.Name = "SDCardControl";
            this.Text = "SDCardControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SDCardControl_FormClosing);
            this.Load += new System.EventHandler(this.SDCardControl_Load);
            this.Resize += new System.EventHandler(this.SDCardControl_Resize);
            this.statusStrip_SDCard.ResumeLayout(false);
            this.statusStrip_SDCard.PerformLayout();
            this.TabControl_SDCard.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox_SDStatus.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_SD_Info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_SDCard)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox_Function.ResumeLayout(false);
            this.groupBox_Result.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

            

        #endregion
        private System.Windows.Forms.RichTextBox RichTextBox_SDCardReadInfo;
        private System.Windows.Forms.StatusStrip statusStrip_SDCard;
        private System.Windows.Forms.ToolStripStatusLabel toolStrStaLab_SDCardStatus;
        private System.Windows.Forms.TabControl TabControl_SDCard;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DataGridView_SDCard;
        private System.Windows.Forms.GroupBox groupBox_SD_Info;
        private System.Windows.Forms.GroupBox groupBox_SDStatus;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.GroupBox groupBox_SD_Program;
        private System.Windows.Forms.GroupBox groupBox_Result;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_ReadBlockNums;
        private System.Windows.Forms.TextBox textBox_ReadStartAddr;
        private System.Windows.Forms.Button button_Multi_RD;
        private System.Windows.Forms.Button button_Single_RD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripProgressBar SDCardControBar;
        private System.Windows.Forms.Button button_Save_SDInfo;
        private System.Windows.Forms.Button button_Load_SDInfo;
        private System.Windows.Forms.GroupBox groupBox_Function;
        private System.Windows.Forms.Button Button_Next;
        private System.Windows.Forms.Button Button_Prev;
        private System.Windows.Forms.Button Button_Load;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Button button_Download_All;
    }
}
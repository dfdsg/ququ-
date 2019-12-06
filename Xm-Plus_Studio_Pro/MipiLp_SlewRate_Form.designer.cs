namespace XM_Tek_Studio_Pro
{
    partial class MipiLp_SlewRate_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MipiLp_SlewRate_Form));
            this.start_test = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Cbx_Item = new System.Windows.Forms.ComboBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_1585 = new System.Windows.Forms.RadioButton();
            this.radioButton_400700 = new System.Windows.Forms.RadioButton();
            this.radioButton_700950 = new System.Windows.Forms.RadioButton();
            this.lblMsg = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // start_test
            // 
            this.start_test.Location = new System.Drawing.Point(358, 12);
            this.start_test.Margin = new System.Windows.Forms.Padding(2);
            this.start_test.Name = "start_test";
            this.start_test.Size = new System.Drawing.Size(64, 26);
            this.start_test.TabIndex = 0;
            this.start_test.Text = "Start";
            this.start_test.UseVisualStyleBackColor = true;
            this.start_test.Click += new System.EventHandler(this.Start_Test_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "Instrument Setting : ";
            // 
            // Cbx_Item
            // 
            this.Cbx_Item.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbx_Item.FormattingEnabled = true;
            this.Cbx_Item.Location = new System.Drawing.Point(110, 12);
            this.Cbx_Item.Name = "Cbx_Item";
            this.Cbx_Item.Size = new System.Drawing.Size(243, 22);
            this.Cbx_Item.TabIndex = 14;
            this.Cbx_Item.SelectedIndexChanged += new System.EventHandler(this.Cbx_Item_SelectedIndexChanged);
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Time,
            this.Column2,
            this.RF});
            this.DataGridView1.Location = new System.Drawing.Point(10, 82);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.Size = new System.Drawing.Size(410, 269);
            this.DataGridView1.TabIndex = 16;
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.AutoSize = true;
            this.Lbl_Msg.Location = new System.Drawing.Point(12, 373);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(189, 14);
            this.Lbl_Msg.TabIndex = 17;
            this.Lbl_Msg.Text = "Step1 : Use Ch2 for Measurement.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "Step2 : Let target Tx waveform on the screen.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Step3 : Push the \"Start\" button.";
            // 
            // radioButton_1585
            // 
            this.radioButton_1585.AutoSize = true;
            this.radioButton_1585.Checked = true;
            this.radioButton_1585.Location = new System.Drawing.Point(11, 49);
            this.radioButton_1585.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_1585.Name = "radioButton_1585";
            this.radioButton_1585.Size = new System.Drawing.Size(103, 18);
            this.radioButton_1585.TabIndex = 20;
            this.radioButton_1585.TabStop = true;
            this.radioButton_1585.Text = "R/F = 15%~85%";
            this.radioButton_1585.UseVisualStyleBackColor = true;
            // 
            // radioButton_400700
            // 
            this.radioButton_400700.AutoSize = true;
            this.radioButton_400700.Location = new System.Drawing.Point(110, 49);
            this.radioButton_400700.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_400700.Name = "radioButton_400700";
            this.radioButton_400700.Size = new System.Drawing.Size(189, 18);
            this.radioButton_400700.TabIndex = 21;
            this.radioButton_400700.TabStop = true;
            this.radioButton_400700.Text = "R = 400~700mV ; F = 400~930mV";
            this.radioButton_400700.UseVisualStyleBackColor = true;
            // 
            // radioButton_700950
            // 
            this.radioButton_700950.AutoSize = true;
            this.radioButton_700950.Location = new System.Drawing.Point(287, 49);
            this.radioButton_700950.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_700950.Name = "radioButton_700950";
            this.radioButton_700950.Size = new System.Drawing.Size(103, 18);
            this.radioButton_700950.TabIndex = 22;
            this.radioButton_700950.TabStop = true;
            this.radioButton_700950.Text = "R = 700~950mV";
            this.radioButton_700950.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(13, 359);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 14);
            this.lblMsg.TabIndex = 23;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Voltage";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time(ns)";
            this.Time.Name = "Time";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "SR(V/us)";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // RF
            // 
            this.RF.HeaderText = "Edge";
            this.RF.Name = "RF";
            // 
            // MipiLp_SlewRate_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 420);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.radioButton_700950);
            this.Controls.Add(this.radioButton_400700);
            this.Controls.Add(this.radioButton_1585);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Cbx_Item);
            this.Controls.Add(this.start_test);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MipiLp_SlewRate_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MIPI_LP_SLEW_RATE_TEST";
            this.Load += new System.EventHandler(this.MIPI_LP_SLEW_RATE_TEST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_test;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cbx_Item;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_1585;
        private System.Windows.Forms.RadioButton radioButton_400700;
        private System.Windows.Forms.RadioButton radioButton_700950;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RF;
    }
}
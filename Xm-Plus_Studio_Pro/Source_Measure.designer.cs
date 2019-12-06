namespace XM_Tek_Studio_Pro
{
    partial class Source_Measure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Source_Measure));
            this.Cbx_Item = new System.Windows.Forms.ComboBox();
            this.Btn_Measure = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Lbl_Info = new System.Windows.Forms.Label();
            this.Btn_Suspend = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Lbl_Frame = new System.Windows.Forms.Label();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.comboBox_Source_Measure_Start = new System.Windows.Forms.ComboBox();
            this.comboBox_Source_Measure_End = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Load_File = new System.Windows.Forms.Button();
            this.TxtBox_File_Path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtBox_Excel_Cell = new System.Windows.Forms.TextBox();
            this.checkBox_Disable_Excel_Setting = new System.Windows.Forms.CheckBox();
            this.Btn_Excel_Close = new System.Windows.Forms.Button();
            this.CboBox_Excel_Sheet = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cbx_Item
            // 
            this.Cbx_Item.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbx_Item.FormattingEnabled = true;
            this.Cbx_Item.Location = new System.Drawing.Point(135, 18);
            this.Cbx_Item.Name = "Cbx_Item";
            this.Cbx_Item.Size = new System.Drawing.Size(165, 22);
            this.Cbx_Item.TabIndex = 0;
            this.Cbx_Item.SelectedIndexChanged += new System.EventHandler(this.Cbx_Item_SelectedIndexChanged);
            // 
            // Btn_Measure
            // 
            this.Btn_Measure.Location = new System.Drawing.Point(283, 11);
            this.Btn_Measure.Name = "Btn_Measure";
            this.Btn_Measure.Size = new System.Drawing.Size(58, 38);
            this.Btn_Measure.TabIndex = 1;
            this.Btn_Measure.Text = "Measure ";
            this.Btn_Measure.UseVisualStyleBackColor = true;
            this.Btn_Measure.Click += new System.EventHandler(this.Btn_Measure_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(10, 291);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(346, 231);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Gray Level";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Source V";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Polarity";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(91, 528);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(265, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // Lbl_Info
            // 
            this.Lbl_Info.AutoSize = true;
            this.Lbl_Info.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Info.Location = new System.Drawing.Point(204, 534);
            this.Lbl_Info.Name = "Lbl_Info";
            this.Lbl_Info.Size = new System.Drawing.Size(47, 12);
            this.Lbl_Info.TabIndex = 4;
            this.Lbl_Info.Text = "255/255";
            // 
            // Btn_Suspend
            // 
            this.Btn_Suspend.Location = new System.Drawing.Point(283, 54);
            this.Btn_Suspend.Name = "Btn_Suspend";
            this.Btn_Suspend.Size = new System.Drawing.Size(58, 39);
            this.Btn_Suspend.TabIndex = 5;
            this.Btn_Suspend.Text = "Suspend";
            this.Btn_Suspend.UseVisualStyleBackColor = true;
            this.Btn_Suspend.Click += new System.EventHandler(this.Btn_Suspend_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.comboBox2.Location = new System.Drawing.Point(119, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(158, 20);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.Text = "Positive";
            // 
            // Lbl_Frame
            // 
            this.Lbl_Frame.AutoSize = true;
            this.Lbl_Frame.Location = new System.Drawing.Point(5, 19);
            this.Lbl_Frame.Name = "Lbl_Frame";
            this.Lbl_Frame.Size = new System.Drawing.Size(107, 12);
            this.Lbl_Frame.TabIndex = 7;
            this.Lbl_Frame.Text = "Frame Polarity : ";
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.AutoSize = true;
            this.Lbl_Msg.Location = new System.Drawing.Point(10, 559);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(305, 12);
            this.Lbl_Msg.TabIndex = 8;
            this.Lbl_Msg.Text = "Note : Ch1 = ref. source ; Ch4 = real source level";
            // 
            // comboBox_Source_Measure_Start
            // 
            this.comboBox_Source_Measure_Start.FormattingEnabled = true;
            this.comboBox_Source_Measure_Start.Location = new System.Drawing.Point(119, 42);
            this.comboBox_Source_Measure_Start.Name = "comboBox_Source_Measure_Start";
            this.comboBox_Source_Measure_Start.Size = new System.Drawing.Size(158, 20);
            this.comboBox_Source_Measure_Start.TabIndex = 9;
            this.comboBox_Source_Measure_Start.SelectedIndexChanged += new System.EventHandler(this.CboBox_Source_Measure_Start_SelectedIndexChanged);
            // 
            // comboBox_Source_Measure_End
            // 
            this.comboBox_Source_Measure_End.FormattingEnabled = true;
            this.comboBox_Source_Measure_End.Location = new System.Drawing.Point(119, 65);
            this.comboBox_Source_Measure_End.Name = "comboBox_Source_Measure_End";
            this.comboBox_Source_Measure_End.Size = new System.Drawing.Size(158, 20);
            this.comboBox_Source_Measure_End.TabIndex = 10;
            this.comboBox_Source_Measure_End.SelectedIndexChanged += new System.EventHandler(this.CboBox_Source_Measure_End_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Start(Gray Value):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "End(Gray Value) :";
            // 
            // Btn_Load_File
            // 
            this.Btn_Load_File.Location = new System.Drawing.Point(294, 35);
            this.Btn_Load_File.Name = "Btn_Load_File";
            this.Btn_Load_File.Size = new System.Drawing.Size(47, 33);
            this.Btn_Load_File.TabIndex = 13;
            this.Btn_Load_File.Text = "Load Excel File";
            this.Btn_Load_File.UseVisualStyleBackColor = true;
            this.Btn_Load_File.Click += new System.EventHandler(this.Btn_Load_File_Click);
            // 
            // TxtBox_File_Path
            // 
            this.TxtBox_File_Path.Location = new System.Drawing.Point(79, 35);
            this.TxtBox_File_Path.Name = "TxtBox_File_Path";
            this.TxtBox_File_Path.Size = new System.Drawing.Size(209, 21);
            this.TxtBox_File_Path.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "File Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 533);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "Process Status :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "Work_Sheet:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TxtBox_Excel_Cell);
            this.groupBox1.Controls.Add(this.checkBox_Disable_Excel_Setting);
            this.groupBox1.Controls.Add(this.Btn_Excel_Close);
            this.groupBox1.Controls.Add(this.CboBox_Excel_Sheet);
            this.groupBox1.Controls.Add(this.TxtBox_File_Path);
            this.groupBox1.Controls.Add(this.Btn_Load_File);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 136);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel Setting";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "Cell_Loca : ";
            // 
            // TxtBox_Excel_Cell
            // 
            this.TxtBox_Excel_Cell.Location = new System.Drawing.Point(79, 96);
            this.TxtBox_Excel_Cell.Name = "TxtBox_Excel_Cell";
            this.TxtBox_Excel_Cell.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtBox_Excel_Cell.Size = new System.Drawing.Size(209, 21);
            this.TxtBox_Excel_Cell.TabIndex = 28;
            this.TxtBox_Excel_Cell.Text = "A1";
            this.TxtBox_Excel_Cell.TextChanged += new System.EventHandler(this.TxtBox_Excel_Cell_TextChanged);
            // 
            // checkBox_Disable_Excel_Setting
            // 
            this.checkBox_Disable_Excel_Setting.AutoSize = true;
            this.checkBox_Disable_Excel_Setting.Checked = true;
            this.checkBox_Disable_Excel_Setting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Disable_Excel_Setting.Location = new System.Drawing.Point(7, 16);
            this.checkBox_Disable_Excel_Setting.Name = "checkBox_Disable_Excel_Setting";
            this.checkBox_Disable_Excel_Setting.Size = new System.Drawing.Size(318, 16);
            this.checkBox_Disable_Excel_Setting.TabIndex = 26;
            this.checkBox_Disable_Excel_Setting.Text = "Disable Excel Setting (not to Open and Save file)";
            this.checkBox_Disable_Excel_Setting.UseVisualStyleBackColor = true;
            this.checkBox_Disable_Excel_Setting.CheckedChanged += new System.EventHandler(this.CboBox_Disable_Excel_Setting_CheckedChanged);
            // 
            // Btn_Excel_Close
            // 
            this.Btn_Excel_Close.Location = new System.Drawing.Point(294, 80);
            this.Btn_Excel_Close.Name = "Btn_Excel_Close";
            this.Btn_Excel_Close.Size = new System.Drawing.Size(47, 37);
            this.Btn_Excel_Close.TabIndex = 25;
            this.Btn_Excel_Close.Text = "Close File";
            this.Btn_Excel_Close.UseVisualStyleBackColor = true;
            this.Btn_Excel_Close.Click += new System.EventHandler(this.Btn_Excel_Close_Click);
            // 
            // CboBox_Excel_Sheet
            // 
            this.CboBox_Excel_Sheet.FormattingEnabled = true;
            this.CboBox_Excel_Sheet.Location = new System.Drawing.Point(79, 66);
            this.CboBox_Excel_Sheet.Name = "CboBox_Excel_Sheet";
            this.CboBox_Excel_Sheet.Size = new System.Drawing.Size(209, 20);
            this.CboBox_Excel_Sheet.TabIndex = 22;
            this.CboBox_Excel_Sheet.SelectedIndexChanged += new System.EventHandler(this.CboBox_Excel_Sheet_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.Lbl_Frame);
            this.groupBox2.Controls.Add(this.comboBox_Source_Measure_Start);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Btn_Suspend);
            this.groupBox2.Controls.Add(this.comboBox_Source_Measure_End);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Btn_Measure);
            this.groupBox2.Location = new System.Drawing.Point(12, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 101);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Measure Setting";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "Instrument Setting: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 22);
            this.button1.TabIndex = 23;
            this.button1.Text = "find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Source_Measure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.Lbl_Info);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Cbx_Item);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Source_Measure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Source Measure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Source_Measure_FormClosing);
            this.Load += new System.EventHandler(this.Source_Measure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cbx_Item;
        private System.Windows.Forms.Button Btn_Measure;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label Lbl_Info;
        private System.Windows.Forms.Button Btn_Suspend;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Lbl_Frame;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label Lbl_Msg;
        private System.Windows.Forms.ComboBox comboBox_Source_Measure_Start;
        private System.Windows.Forms.ComboBox comboBox_Source_Measure_End;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Load_File;
        private System.Windows.Forms.TextBox TxtBox_File_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CboBox_Excel_Sheet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btn_Excel_Close;
        private System.Windows.Forms.CheckBox checkBox_Disable_Excel_Setting;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtBox_Excel_Cell;
        private System.Windows.Forms.Button button1;
    }
}
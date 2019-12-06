namespace XM_Tek_Studio_Pro
{
    partial class PWM_Measure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PWM_Measure));
            this.Cbo_PwmItem = new System.Windows.Forms.ComboBox();
            this.Btn_Measure = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Suspend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cbo_PwmItem
            // 
            this.Cbo_PwmItem.FormattingEnabled = true;
            this.Cbo_PwmItem.Location = new System.Drawing.Point(16, 18);
            this.Cbo_PwmItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cbo_PwmItem.Name = "Cbo_PwmItem";
            this.Cbo_PwmItem.Size = new System.Drawing.Size(275, 22);
            this.Cbo_PwmItem.TabIndex = 0;
            this.Cbo_PwmItem.SelectedIndexChanged += new System.EventHandler(this.Cbo_PwmItem_SelectedIndexChanged);
            // 
            // Btn_Measure
            // 
            this.Btn_Measure.Location = new System.Drawing.Point(300, 18);
            this.Btn_Measure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Measure.Name = "Btn_Measure";
            this.Btn_Measure.Size = new System.Drawing.Size(123, 35);
            this.Btn_Measure.TabIndex = 1;
            this.Btn_Measure.Text = "Measure";
            this.Btn_Measure.UseVisualStyleBackColor = true;
            this.Btn_Measure.Click += new System.EventHandler(this.Btn_Measure_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(13, 118);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(408, 347);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Freq";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Duty";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Width";
            this.Column4.Name = "Column4";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 61);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(276, 35);
            this.progressBar1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(124, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "255/255";
            // 
            // Btn_Suspend
            // 
            this.Btn_Suspend.Location = new System.Drawing.Point(300, 61);
            this.Btn_Suspend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Suspend.Name = "Btn_Suspend";
            this.Btn_Suspend.Size = new System.Drawing.Size(123, 35);
            this.Btn_Suspend.TabIndex = 5;
            this.Btn_Suspend.Text = "Suspend";
            this.Btn_Suspend.UseVisualStyleBackColor = true;
            this.Btn_Suspend.Click += new System.EventHandler(this.Btn_Suspend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 481);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Note : Ch2 = P.W.M ";
            // 
            // PWM_Measure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 511);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Btn_Suspend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Btn_Measure);
            this.Controls.Add(this.Cbo_PwmItem);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PWM_Measure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PWM Measure";
            this.Load += new System.EventHandler(this.PWM_Measure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cbo_PwmItem;
        private System.Windows.Forms.Button Btn_Measure;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Suspend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
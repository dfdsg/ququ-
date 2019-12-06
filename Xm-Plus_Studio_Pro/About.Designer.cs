namespace XM_Tek_Studio_Pro
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Btn_OK = new System.Windows.Forms.Button();
            this.txtbox_title = new System.Windows.Forms.TextBox();
            this.label_version = new System.Windows.Forms.Label();
            this.label_author = new System.Windows.Forms.Label();
            this.label_company = new System.Windows.Forms.Label();
            this.txtBox_version = new System.Windows.Forms.TextBox();
            this.txtBox_author = new System.Windows.Forms.TextBox();
            this.txtbox_company = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XM_Tek_Studio_Pro.Properties.Resources.XmPlus;
            this.pictureBox1.Location = new System.Drawing.Point(10, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Btn_OK
            // 
            this.Btn_OK.Location = new System.Drawing.Point(149, 151);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(91, 34);
            this.Btn_OK.TabIndex = 2;
            this.Btn_OK.Text = "OK";
            this.Btn_OK.UseVisualStyleBackColor = true;
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // txtbox_title
            // 
            this.txtbox_title.BackColor = System.Drawing.SystemColors.Control;
            this.txtbox_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox_title.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_title.Location = new System.Drawing.Point(65, 4);
            this.txtbox_title.Multiline = true;
            this.txtbox_title.Name = "txtbox_title";
            this.txtbox_title.Size = new System.Drawing.Size(264, 19);
            this.txtbox_title.TabIndex = 3;
            this.txtbox_title.Text = "             Xm-Plus  Display Studio\n\r\n";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_version.Location = new System.Drawing.Point(106, 34);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(51, 14);
            this.label_version.TabIndex = 4;
            this.label_version.Text = "Version:";
            // 
            // label_author
            // 
            this.label_author.AutoSize = true;
            this.label_author.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_author.Location = new System.Drawing.Point(111, 68);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(46, 14);
            this.label_author.TabIndex = 5;
            this.label_author.Text = "Author:";
            // 
            // label_company
            // 
            this.label_company.AutoSize = true;
            this.label_company.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_company.Location = new System.Drawing.Point(98, 118);
            this.label_company.Name = "label_company";
            this.label_company.Size = new System.Drawing.Size(59, 14);
            this.label_company.TabIndex = 6;
            this.label_company.Text = "Company:";
            // 
            // txtBox_version
            // 
            this.txtBox_version.BackColor = System.Drawing.SystemColors.Control;
            this.txtBox_version.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_version.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_version.Location = new System.Drawing.Point(163, 34);
            this.txtBox_version.Multiline = true;
            this.txtBox_version.Name = "txtBox_version";
            this.txtBox_version.Size = new System.Drawing.Size(200, 27);
            this.txtBox_version.TabIndex = 7;
            this.txtBox_version.Text = "Xm-Plus Display Studio\n\r\n";
            // 
            // txtBox_author
            // 
            this.txtBox_author.BackColor = System.Drawing.SystemColors.Control;
            this.txtBox_author.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox_author.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_author.Location = new System.Drawing.Point(163, 67);
            this.txtBox_author.Multiline = true;
            this.txtBox_author.Name = "txtBox_author";
            this.txtBox_author.Size = new System.Drawing.Size(225, 27);
            this.txtBox_author.TabIndex = 8;
            this.txtBox_author.Text = "Brandy.Liu";
            // 
            // txtbox_company
            // 
            this.txtbox_company.BackColor = System.Drawing.SystemColors.Control;
            this.txtbox_company.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox_company.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_company.Location = new System.Drawing.Point(163, 118);
            this.txtbox_company.Multiline = true;
            this.txtbox_company.Name = "txtbox_company";
            this.txtbox_company.Size = new System.Drawing.Size(216, 27);
            this.txtbox_company.TabIndex = 9;
            this.txtbox_company.Text = "Xiamen Xm-Plus Technology Ltd\n";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(163, 88);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 27);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Alf,Chang, Tim.Lin,Wesley,Chen";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 194);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtbox_company);
            this.Controls.Add(this.txtBox_author);
            this.Controls.Add(this.txtBox_version);
            this.Controls.Add(this.label_company);
            this.Controls.Add(this.label_author);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.txtbox_title);
            this.Controls.Add(this.Btn_OK);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Btn_OK;
        private System.Windows.Forms.TextBox txtbox_title;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.Label label_company;
        private System.Windows.Forms.TextBox txtBox_version;
        private System.Windows.Forms.TextBox txtBox_author;
        private System.Windows.Forms.TextBox txtbox_company;
        private System.Windows.Forms.TextBox textBox1;
    }
}
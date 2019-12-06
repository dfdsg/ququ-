namespace XM_Tek_Studio_Pro
{
    partial class USB_Flash_Program
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USB_Flash_Program));
            this.dataGridView_UsbFalsh = new System.Windows.Forms.DataGridView();
            this.richTextBox_UsbFlash = new System.Windows.Forms.RichTextBox();
            this.button_FlashRead = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_VID = new System.Windows.Forms.TextBox();
            this.textBox_PID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Checksum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Vendor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Product = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Serial = new System.Windows.Forms.TextBox();
            this.button_Write = new System.Windows.Forms.Button();
            this.button_Erase = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UsbFalsh)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_UsbFalsh
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_UsbFalsh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_UsbFalsh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_UsbFalsh.Location = new System.Drawing.Point(12, 40);
            this.dataGridView_UsbFalsh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_UsbFalsh.Name = "dataGridView_UsbFalsh";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_UsbFalsh.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_UsbFalsh.RowTemplate.Height = 24;
            this.dataGridView_UsbFalsh.Size = new System.Drawing.Size(692, 221);
            this.dataGridView_UsbFalsh.TabIndex = 0;
            this.dataGridView_UsbFalsh.TabStop = false;
            // 
            // richTextBox_UsbFlash
            // 
            this.richTextBox_UsbFlash.Location = new System.Drawing.Point(12, 268);
            this.richTextBox_UsbFlash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox_UsbFlash.Name = "richTextBox_UsbFlash";
            this.richTextBox_UsbFlash.Size = new System.Drawing.Size(202, 329);
            this.richTextBox_UsbFlash.TabIndex = 1;
            this.richTextBox_UsbFlash.TabStop = false;
            this.richTextBox_UsbFlash.Text = "";
            this.richTextBox_UsbFlash.TextChanged += new System.EventHandler(this.RichTextBox_UsbFlash_TextChanged);
            // 
            // button_FlashRead
            // 
            this.button_FlashRead.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_FlashRead.Location = new System.Drawing.Point(220, 550);
            this.button_FlashRead.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_FlashRead.Name = "button_FlashRead";
            this.button_FlashRead.Size = new System.Drawing.Size(105, 48);
            this.button_FlashRead.TabIndex = 5;
            this.button_FlashRead.Text = "Read";
            this.button_FlashRead.UseVisualStyleBackColor = true;
            this.button_FlashRead.Click += new System.EventHandler(this.Button_FlashRead_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "VID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(387, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "PID :";
            // 
            // textBox_VID
            // 
            this.textBox_VID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_VID.Location = new System.Drawing.Point(270, 270);
            this.textBox_VID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_VID.MaxLength = 6;
            this.textBox_VID.Name = "textBox_VID";
            this.textBox_VID.Size = new System.Drawing.Size(80, 27);
            this.textBox_VID.TabIndex = 0;
            this.textBox_VID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_VID_KeyDown);
            // 
            // textBox_PID
            // 
            this.textBox_PID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PID.Location = new System.Drawing.Point(437, 270);
            this.textBox_PID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_PID.MaxLength = 6;
            this.textBox_PID.Name = "textBox_PID";
            this.textBox_PID.Size = new System.Drawing.Size(80, 27);
            this.textBox_PID.TabIndex = 1;
            this.textBox_PID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_PID_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(539, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Checksum :";
            // 
            // textBox_Checksum
            // 
            this.textBox_Checksum.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Checksum.Location = new System.Drawing.Point(652, 270);
            this.textBox_Checksum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Checksum.Name = "textBox_Checksum";
            this.textBox_Checksum.ReadOnly = true;
            this.textBox_Checksum.Size = new System.Drawing.Size(52, 27);
            this.textBox_Checksum.TabIndex = 8;
            this.textBox_Checksum.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(221, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(271, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vendor String (max. 47 char)";
            // 
            // textBox_Vendor
            // 
            this.textBox_Vendor.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Vendor.Location = new System.Drawing.Point(220, 349);
            this.textBox_Vendor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Vendor.MaxLength = 47;
            this.textBox_Vendor.Name = "textBox_Vendor";
            this.textBox_Vendor.Size = new System.Drawing.Size(485, 34);
            this.textBox_Vendor.TabIndex = 2;
            this.textBox_Vendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Vendor_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(220, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(276, 27);
            this.label5.TabIndex = 3;
            this.label5.Text = "Product String (max. 47 char)";
            // 
            // textBox_Product
            // 
            this.textBox_Product.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Product.Location = new System.Drawing.Point(220, 425);
            this.textBox_Product.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Product.MaxLength = 47;
            this.textBox_Product.Name = "textBox_Product";
            this.textBox_Product.Size = new System.Drawing.Size(485, 34);
            this.textBox_Product.TabIndex = 3;
            this.textBox_Product.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Product_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(220, 472);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(278, 27);
            this.label6.TabIndex = 3;
            this.label6.Text = "Serial Number (max. 15 char)";
            // 
            // textBox_Serial
            // 
            this.textBox_Serial.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Serial.Location = new System.Drawing.Point(220, 500);
            this.textBox_Serial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Serial.MaxLength = 15;
            this.textBox_Serial.Name = "textBox_Serial";
            this.textBox_Serial.Size = new System.Drawing.Size(200, 34);
            this.textBox_Serial.TabIndex = 4;
            this.textBox_Serial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Serial_KeyDown);
            // 
            // button_Write
            // 
            this.button_Write.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Write.Location = new System.Drawing.Point(595, 550);
            this.button_Write.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Write.Name = "button_Write";
            this.button_Write.Size = new System.Drawing.Size(110, 48);
            this.button_Write.TabIndex = 7;
            this.button_Write.Text = "Write";
            this.button_Write.UseVisualStyleBackColor = true;
            this.button_Write.Click += new System.EventHandler(this.Button_Write_Click);
            // 
            // button_Erase
            // 
            this.button_Erase.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Erase.Location = new System.Drawing.Point(408, 550);
            this.button_Erase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Erase.Name = "button_Erase";
            this.button_Erase.Size = new System.Drawing.Size(100, 48);
            this.button_Erase.TabIndex = 6;
            this.button_Erase.Text = "Erase";
            this.button_Erase.UseVisualStyleBackColor = true;
            this.button_Erase.Click += new System.EventHandler(this.Button_Erase_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.open_48;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.Save_48x48;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::XM_Tek_Studio_Pro.Properties.Resources.exit_64x64;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // USB_Flash_Programming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 612);
            this.Controls.Add(this.textBox_Checksum);
            this.Controls.Add(this.textBox_PID);
            this.Controls.Add(this.textBox_Serial);
            this.Controls.Add(this.textBox_Product);
            this.Controls.Add(this.textBox_Vendor);
            this.Controls.Add(this.textBox_VID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Erase);
            this.Controls.Add(this.button_Write);
            this.Controls.Add(this.button_FlashRead);
            this.Controls.Add(this.richTextBox_UsbFlash);
            this.Controls.Add(this.dataGridView_UsbFalsh);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "USB_Flash_Programming";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB_Flash_Program";
            this.Load += new System.EventHandler(this.USB_flash_programming_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UsbFalsh)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_UsbFalsh;
        private System.Windows.Forms.RichTextBox richTextBox_UsbFlash;
        private System.Windows.Forms.Button button_FlashRead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_VID;
        private System.Windows.Forms.TextBox textBox_PID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Checksum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Vendor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Product;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Serial;
        private System.Windows.Forms.Button button_Write;
        private System.Windows.Forms.Button button_Erase;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}
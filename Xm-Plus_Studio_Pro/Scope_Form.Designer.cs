namespace XM_Tek_Studio_Pro
{
    partial class Scope_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scope_Form));
            this.gbx = new System.Windows.Forms.GroupBox();
            this.pic_DigitalScope = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_autoRun = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_autoSave = new System.Windows.Forms.CheckBox();
            this.cbx_devices = new System.Windows.Forms.ComboBox();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_RunImage = new System.Windows.Forms.Button();
            this.txtbox_filename = new System.Windows.Forms.TextBox();
            this.lbl_device = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DigitalScope)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx
            // 
            this.gbx.Controls.Add(this.pic_DigitalScope);
            this.gbx.Location = new System.Drawing.Point(13, 13);
            this.gbx.Margin = new System.Windows.Forms.Padding(4);
            this.gbx.Name = "gbx";
            this.gbx.Padding = new System.Windows.Forms.Padding(4);
            this.gbx.Size = new System.Drawing.Size(643, 357);
            this.gbx.TabIndex = 0;
            this.gbx.TabStop = false;
            this.gbx.Text = "Image";
            // 
            // pic_DigitalScope
            // 
            this.pic_DigitalScope.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_DigitalScope.Location = new System.Drawing.Point(4, 21);
            this.pic_DigitalScope.Margin = new System.Windows.Forms.Padding(4);
            this.pic_DigitalScope.Name = "pic_DigitalScope";
            this.pic_DigitalScope.Size = new System.Drawing.Size(635, 332);
            this.pic_DigitalScope.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_DigitalScope.TabIndex = 0;
            this.pic_DigitalScope.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk_autoRun);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chk_autoSave);
            this.groupBox2.Controls.Add(this.cbx_devices);
            this.groupBox2.Controls.Add(this.lbl_filename);
            this.groupBox2.Controls.Add(this.Btn_Save);
            this.groupBox2.Controls.Add(this.Btn_RunImage);
            this.groupBox2.Controls.Add(this.txtbox_filename);
            this.groupBox2.Controls.Add(this.lbl_device);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(17, 378);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(643, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Infomation";
            // 
            // chk_autoRun
            // 
            this.chk_autoRun.AutoSize = true;
            this.chk_autoRun.Location = new System.Drawing.Point(436, 23);
            this.chk_autoRun.Margin = new System.Windows.Forms.Padding(4);
            this.chk_autoRun.Name = "chk_autoRun";
            this.chk_autoRun.Size = new System.Drawing.Size(76, 21);
            this.chk_autoRun.TabIndex = 8;
            this.chk_autoRun.Text = "AutoRun";
            this.chk_autoRun.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = ".png";
            // 
            // chk_autoSave
            // 
            this.chk_autoSave.AutoSize = true;
            this.chk_autoSave.Location = new System.Drawing.Point(436, 58);
            this.chk_autoSave.Margin = new System.Windows.Forms.Padding(4);
            this.chk_autoSave.Name = "chk_autoSave";
            this.chk_autoSave.Size = new System.Drawing.Size(80, 21);
            this.chk_autoSave.TabIndex = 6;
            this.chk_autoSave.Text = "AutoSave";
            this.chk_autoSave.UseVisualStyleBackColor = true;
            // 
            // cbx_devices
            // 
            this.cbx_devices.FormattingEnabled = true;
            this.cbx_devices.Location = new System.Drawing.Point(77, 21);
            this.cbx_devices.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_devices.Name = "cbx_devices";
            this.cbx_devices.Size = new System.Drawing.Size(351, 25);
            this.cbx_devices.TabIndex = 5;
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Location = new System.Drawing.Point(8, 59);
            this.lbl_filename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(65, 17);
            this.lbl_filename.TabIndex = 4;
            this.lbl_filename.Text = "FileName:";
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(536, 54);
            this.Btn_Save.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(99, 30);
            this.Btn_Save.TabIndex = 3;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_RunImage
            // 
            this.Btn_RunImage.Location = new System.Drawing.Point(536, 15);
            this.Btn_RunImage.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_RunImage.Name = "Btn_RunImage";
            this.Btn_RunImage.Size = new System.Drawing.Size(99, 31);
            this.Btn_RunImage.TabIndex = 2;
            this.Btn_RunImage.Text = "Run";
            this.Btn_RunImage.UseVisualStyleBackColor = true;
            this.Btn_RunImage.Click += new System.EventHandler(this.Btn_RunImage_Click);
            // 
            // txtbox_filename
            // 
            this.txtbox_filename.Location = new System.Drawing.Point(77, 52);
            this.txtbox_filename.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_filename.Name = "txtbox_filename";
            this.txtbox_filename.Size = new System.Drawing.Size(258, 24);
            this.txtbox_filename.TabIndex = 1;
            // 
            // lbl_device
            // 
            this.lbl_device.AutoSize = true;
            this.lbl_device.Location = new System.Drawing.Point(22, 24);
            this.lbl_device.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_device.Name = "lbl_device";
            this.lbl_device.Size = new System.Drawing.Size(50, 17);
            this.lbl_device.TabIndex = 0;
            this.lbl_device.Text = "Device:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_info});
            this.statusStrip1.Location = new System.Drawing.Point(0, 479);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(665, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_info
            // 
            this.tssl_info.Name = "tssl_info";
            this.tssl_info.Size = new System.Drawing.Size(30, 17);
            this.tssl_info.Text = "Info";
            // 
            // Scope_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 501);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbx);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scope_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xm-Plus Oscilloscope";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Scope_Form_FormClosed);
            this.Load += new System.EventHandler(this.Scope_Form_Load);
            this.gbx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_DigitalScope)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx;
        private System.Windows.Forms.PictureBox pic_DigitalScope;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_RunImage;
        private System.Windows.Forms.TextBox txtbox_filename;
        private System.Windows.Forms.Label lbl_device;
        private System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.ComboBox cbx_devices;
        private System.Windows.Forms.CheckBox chk_autoSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_autoRun;
    }
}
namespace XM_Tek_Studio_Pro
{
    partial class ImgShow_Form
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
            this.pnl_img = new System.Windows.Forms.Panel();
            this.lbl_msg = new System.Windows.Forms.Label();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.pic_show = new System.Windows.Forms.PictureBox();
            this.pnl_img.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_show)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_img
            // 
            this.pnl_img.Controls.Add(this.lbl_msg);
            this.pnl_img.Controls.Add(this.Btn_Close);
            this.pnl_img.Controls.Add(this.pic_show);
            this.pnl_img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_img.Location = new System.Drawing.Point(0, 0);
            this.pnl_img.Name = "pnl_img";
            this.pnl_img.Size = new System.Drawing.Size(470, 450);
            this.pnl_img.TabIndex = 1;
            // 
            // lbl_msg
            // 
            this.lbl_msg.AutoSize = true;
            this.lbl_msg.Location = new System.Drawing.Point(376, 429);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(0, 12);
            this.lbl_msg.TabIndex = 1;
            // 
            // Btn_Close
            // 
            this.Btn_Close.Image = global::XM_Tek_Studio_Pro.Properties.Resources.closeall;
            this.Btn_Close.Location = new System.Drawing.Point(424, 3);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(46, 33);
            this.Btn_Close.TabIndex = 0;
            this.Btn_Close.UseVisualStyleBackColor = true;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // pic_show
            // 
            this.pic_show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_show.Location = new System.Drawing.Point(0, 0);
            this.pic_show.Name = "pic_show";
            this.pic_show.Size = new System.Drawing.Size(470, 450);
            this.pic_show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_show.TabIndex = 0;
            this.pic_show.TabStop = false;
            // 
            // ImgShow_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 450);
            this.Controls.Add(this.pnl_img);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImgShow_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImgShow_Form";
            this.TopMost = true;
            this.pnl_img.ResumeLayout(false);
            this.pnl_img.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Panel pnl_img;
        private System.Windows.Forms.PictureBox pic_show;
        private System.Windows.Forms.Label lbl_msg;
    }
}
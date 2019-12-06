namespace XM_Tek_Studio_Pro
{
    partial class Splash
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
            this.appMini = new System.Windows.Forms.Label();
            this.bigApp = new System.Windows.Forms.Label();
            this.tasks = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.minimize = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.XmPrgb = new XM_Tek_Studio_Pro.ProgressBarEx();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // appMini
            // 
            this.appMini.AutoSize = true;
            this.appMini.BackColor = System.Drawing.Color.Transparent;
            this.appMini.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.appMini.ForeColor = System.Drawing.Color.Black;
            this.appMini.Location = new System.Drawing.Point(14, 9);
            this.appMini.Name = "appMini";
            this.appMini.Size = new System.Drawing.Size(253, 18);
            this.appMini.TabIndex = 0;
            this.appMini.Text = "Xiamen Xm-Plus Technology Ltd";
            // 
            // bigApp
            // 
            this.bigApp.AutoSize = true;
            this.bigApp.BackColor = System.Drawing.Color.Transparent;
            this.bigApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bigApp.ForeColor = System.Drawing.Color.Black;
            this.bigApp.Location = new System.Drawing.Point(30, 69);
            this.bigApp.Name = "bigApp";
            this.bigApp.Size = new System.Drawing.Size(344, 55);
            this.bigApp.TabIndex = 1;
            this.bigApp.Text = "Display Studio";
            // 
            // tasks
            // 
            this.tasks.AutoSize = true;
            this.tasks.BackColor = System.Drawing.Color.Transparent;
            this.tasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tasks.ForeColor = System.Drawing.Color.Black;
            this.tasks.Location = new System.Drawing.Point(12, 192);
            this.tasks.Name = "tasks";
            this.tasks.Size = new System.Drawing.Size(136, 29);
            this.tasks.TabIndex = 2;
            this.tasks.Text = "current task";
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.close.ForeColor = System.Drawing.Color.White;
            this.close.Location = new System.Drawing.Point(397, 1);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(36, 26);
            this.close.TabIndex = 3;
            this.close.Text = "r";
            // 
            // minimize
            // 
            this.minimize.AutoSize = true;
            this.minimize.BackColor = System.Drawing.Color.Transparent;
            this.minimize.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.minimize.ForeColor = System.Drawing.Color.White;
            this.minimize.Location = new System.Drawing.Point(362, 1);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(36, 26);
            this.minimize.TabIndex = 4;
            this.minimize.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XM_Tek_Studio_Pro.Properties.Resources.XmPlus;
            this.pictureBox1.Location = new System.Drawing.Point(363, 173);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // XmPrgb
            // 
            this.XmPrgb.BackColor = System.Drawing.Color.Transparent;
            this.XmPrgb.BackgroundColor = System.Drawing.Color.White;
            this.XmPrgb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.XmPrgb.Image = null;
            this.XmPrgb.Location = new System.Drawing.Point(83, 127);
            this.XmPrgb.Name = "XmPrgb";
            this.XmPrgb.ProgressColor = System.Drawing.Color.Red;
            this.XmPrgb.Size = new System.Drawing.Size(278, 10);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(439, 229);
            this.Controls.Add(this.XmPrgb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.close);
            this.Controls.Add(this.tasks);
            this.Controls.Add(this.bigApp);
            this.Controls.Add(this.appMini);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(439, 229);
            this.MinimumSize = new System.Drawing.Size(439, 229);
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label appMini;
        private System.Windows.Forms.Label bigApp;
        private System.Windows.Forms.Label tasks;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label minimize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ProgressBarEx XmPrgb;
    }
}
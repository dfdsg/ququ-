namespace XM_Tek_Studio_Pro
{
    partial class MainSetting_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSetting_Form));
            this.Main_PicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Main_PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_PicBox
            // 
            this.Main_PicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_PicBox.Image = global::XM_Tek_Studio_Pro.Properties.Resources.XmMain;
            this.Main_PicBox.Location = new System.Drawing.Point(0, 0);
            this.Main_PicBox.Name = "Main_PicBox";
            this.Main_PicBox.Size = new System.Drawing.Size(1262, 644);
            this.Main_PicBox.TabIndex = 0;
            this.Main_PicBox.TabStop = false;
            // 
            // MainSetting_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 644);
            this.Controls.Add(this.Main_PicBox);
            this.Font = new System.Drawing.Font("Calibri", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainSetting_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            ((System.ComponentModel.ISupportInitialize)(this.Main_PicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Main_PicBox;
    }
}
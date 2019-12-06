namespace XM_Tek_Studio_Pro
{
    partial class Setting_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting_Form));
            this.gbx = new System.Windows.Forms.GroupBox();
            this.ChkBox_Debug = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbox_delaytime = new System.Windows.Forms.TextBox();
            this.ChkBox_CmdDelayTime = new System.Windows.Forms.CheckBox();
            this.ChkBox_TxCmd = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkBox_LogMsg = new System.Windows.Forms.CheckBox();
            this.tssl_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.gbx.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx
            // 
            this.gbx.Controls.Add(this.ChkBox_Debug);
            this.gbx.Controls.Add(this.label1);
            this.gbx.Controls.Add(this.txtbox_delaytime);
            this.gbx.Controls.Add(this.ChkBox_CmdDelayTime);
            this.gbx.Controls.Add(this.ChkBox_TxCmd);
            this.gbx.Location = new System.Drawing.Point(13, 4);
            this.gbx.Margin = new System.Windows.Forms.Padding(4);
            this.gbx.Name = "gbx";
            this.gbx.Padding = new System.Windows.Forms.Padding(4);
            this.gbx.Size = new System.Drawing.Size(299, 92);
            this.gbx.TabIndex = 0;
            this.gbx.TabStop = false;
            this.gbx.Text = "Setting";
            // 
            // ChkBox_Debug
            // 
            this.ChkBox_Debug.AutoSize = true;
            this.ChkBox_Debug.Checked = true;
            this.ChkBox_Debug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBox_Debug.Location = new System.Drawing.Point(16, 71);
            this.ChkBox_Debug.Name = "ChkBox_Debug";
            this.ChkBox_Debug.Size = new System.Drawing.Size(124, 21);
            this.ChkBox_Debug.TabIndex = 4;
            this.ChkBox_Debug.Text = "Debug Command";
            this.ChkBox_Debug.UseVisualStyleBackColor = true;
            this.ChkBox_Debug.CheckedChanged += new System.EventHandler(this.ChkBox_Debug_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "between instructions";
            // 
            // txtbox_delaytime
            // 
            this.txtbox_delaytime.Location = new System.Drawing.Point(103, 43);
            this.txtbox_delaytime.Name = "txtbox_delaytime";
            this.txtbox_delaytime.Size = new System.Drawing.Size(57, 24);
            this.txtbox_delaytime.TabIndex = 2;
            // 
            // ChkBox_CmdDelayTime
            // 
            this.ChkBox_CmdDelayTime.AutoSize = true;
            this.ChkBox_CmdDelayTime.Location = new System.Drawing.Point(16, 45);
            this.ChkBox_CmdDelayTime.Name = "ChkBox_CmdDelayTime";
            this.ChkBox_CmdDelayTime.Size = new System.Drawing.Size(90, 21);
            this.ChkBox_CmdDelayTime.TabIndex = 1;
            this.ChkBox_CmdDelayTime.Text = "Delay Time";
            this.ChkBox_CmdDelayTime.UseVisualStyleBackColor = true;
            this.ChkBox_CmdDelayTime.CheckedChanged += new System.EventHandler(this.ChkBox_CmdDelayTime_CheckedChanged);
            // 
            // ChkBox_TxCmd
            // 
            this.ChkBox_TxCmd.AutoSize = true;
            this.ChkBox_TxCmd.Location = new System.Drawing.Point(16, 23);
            this.ChkBox_TxCmd.Name = "ChkBox_TxCmd";
            this.ChkBox_TxCmd.Size = new System.Drawing.Size(64, 21);
            this.ChkBox_TxCmd.TabIndex = 0;
            this.ChkBox_TxCmd.Text = "TxCmd";
            this.ChkBox_TxCmd.UseVisualStyleBackColor = true;
            this.ChkBox_TxCmd.CheckedChanged += new System.EventHandler(this.ChkBox_TxCmd_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkBox_LogMsg);
            this.groupBox1.Location = new System.Drawing.Point(13, 104);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(299, 46);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // ChkBox_LogMsg
            // 
            this.ChkBox_LogMsg.AutoSize = true;
            this.ChkBox_LogMsg.Location = new System.Drawing.Point(16, 18);
            this.ChkBox_LogMsg.Name = "ChkBox_LogMsg";
            this.ChkBox_LogMsg.Size = new System.Drawing.Size(132, 21);
            this.ChkBox_LogMsg.TabIndex = 0;
            this.ChkBox_LogMsg.Text = "Output to Log Msg";
            this.ChkBox_LogMsg.UseVisualStyleBackColor = true;
            this.ChkBox_LogMsg.CheckedChanged += new System.EventHandler(this.ChkBox_LogMsg_CheckedChanged);
            // 
            // tssl_info
            // 
            this.tssl_info.Name = "tssl_info";
            this.tssl_info.Size = new System.Drawing.Size(51, 17);
            this.tssl_info.Text = "Setting ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_info});
            this.statusStrip1.Location = new System.Drawing.Point(0, 155);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(322, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Setting_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 177);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbx);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Form_Load);
            this.gbx.ResumeLayout(false);
            this.gbx.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx;
        private System.Windows.Forms.CheckBox ChkBox_TxCmd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkBox_LogMsg;
        private System.Windows.Forms.ToolStripStatusLabel tssl_info;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_delaytime;
        private System.Windows.Forms.CheckBox ChkBox_CmdDelayTime;
        private System.Windows.Forms.CheckBox ChkBox_Debug;
    }
}
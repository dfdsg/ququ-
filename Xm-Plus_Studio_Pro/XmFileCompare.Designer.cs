namespace XM_Tek_Studio_Pro
{
    partial class XmFileCompare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmFileCompare));
            this.Gbx_Input = new System.Windows.Forms.GroupBox();
            this.lbl_Msg = new System.Windows.Forms.Label();
            this.TxtBoxState = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCompare = new System.Windows.Forms.Button();
            this.BtnClr = new System.Windows.Forms.Button();
            this.BtnLoadFileB = new System.Windows.Forms.Button();
            this.BtnLoadFileA = new System.Windows.Forms.Button();
            this.TxtBoxFileB = new System.Windows.Forms.TextBox();
            this.TxtBoxFileA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RtfMsg = new System.Windows.Forms.RichTextBox();
            this.Gbx_Input.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gbx_Input
            // 
            this.Gbx_Input.Controls.Add(this.lbl_Msg);
            this.Gbx_Input.Controls.Add(this.TxtBoxState);
            this.Gbx_Input.Controls.Add(this.label3);
            this.Gbx_Input.Controls.Add(this.BtnCompare);
            this.Gbx_Input.Controls.Add(this.BtnClr);
            this.Gbx_Input.Controls.Add(this.BtnLoadFileB);
            this.Gbx_Input.Controls.Add(this.BtnLoadFileA);
            this.Gbx_Input.Controls.Add(this.TxtBoxFileB);
            this.Gbx_Input.Controls.Add(this.TxtBoxFileA);
            this.Gbx_Input.Controls.Add(this.label2);
            this.Gbx_Input.Controls.Add(this.label1);
            this.Gbx_Input.Dock = System.Windows.Forms.DockStyle.Top;
            this.Gbx_Input.Location = new System.Drawing.Point(0, 0);
            this.Gbx_Input.Name = "Gbx_Input";
            this.Gbx_Input.Size = new System.Drawing.Size(427, 165);
            this.Gbx_Input.TabIndex = 0;
            this.Gbx_Input.TabStop = false;
            this.Gbx_Input.Text = "Input:";
            // 
            // lbl_Msg
            // 
            this.lbl_Msg.AutoSize = true;
            this.lbl_Msg.Location = new System.Drawing.Point(219, 129);
            this.lbl_Msg.Name = "lbl_Msg";
            this.lbl_Msg.Size = new System.Drawing.Size(0, 15);
            this.lbl_Msg.TabIndex = 10;
            // 
            // TxtBoxState
            // 
            this.TxtBoxState.Location = new System.Drawing.Point(85, 93);
            this.TxtBoxState.Name = "TxtBoxState";
            this.TxtBoxState.Size = new System.Drawing.Size(244, 23);
            this.TxtBoxState.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Condition:";
            // 
            // BtnCompare
            // 
            this.BtnCompare.Location = new System.Drawing.Point(85, 122);
            this.BtnCompare.Name = "BtnCompare";
            this.BtnCompare.Size = new System.Drawing.Size(128, 29);
            this.BtnCompare.TabIndex = 7;
            this.BtnCompare.Text = "Compare";
            this.BtnCompare.UseVisualStyleBackColor = true;
            this.BtnCompare.Click += new System.EventHandler(this.BtnCompare_Click);
            // 
            // BtnClr
            // 
            this.BtnClr.Location = new System.Drawing.Point(338, 93);
            this.BtnClr.Name = "BtnClr";
            this.BtnClr.Size = new System.Drawing.Size(77, 23);
            this.BtnClr.TabIndex = 6;
            this.BtnClr.Text = "Clear";
            this.BtnClr.UseVisualStyleBackColor = true;
            this.BtnClr.Click += new System.EventHandler(this.BtnClr_Click);
            // 
            // BtnLoadFileB
            // 
            this.BtnLoadFileB.Location = new System.Drawing.Point(337, 58);
            this.BtnLoadFileB.Name = "BtnLoadFileB";
            this.BtnLoadFileB.Size = new System.Drawing.Size(77, 23);
            this.BtnLoadFileB.TabIndex = 5;
            this.BtnLoadFileB.Text = "Load";
            this.BtnLoadFileB.UseVisualStyleBackColor = true;
            this.BtnLoadFileB.Click += new System.EventHandler(this.BtnLoadFileB_Click);
            // 
            // BtnLoadFileA
            // 
            this.BtnLoadFileA.Location = new System.Drawing.Point(336, 24);
            this.BtnLoadFileA.Name = "BtnLoadFileA";
            this.BtnLoadFileA.Size = new System.Drawing.Size(78, 23);
            this.BtnLoadFileA.TabIndex = 4;
            this.BtnLoadFileA.Text = "Load";
            this.BtnLoadFileA.UseVisualStyleBackColor = true;
            this.BtnLoadFileA.Click += new System.EventHandler(this.BtnLoadFileA_Click);
            // 
            // TxtBoxFileB
            // 
            this.TxtBoxFileB.Location = new System.Drawing.Point(84, 58);
            this.TxtBoxFileB.Name = "TxtBoxFileB";
            this.TxtBoxFileB.Size = new System.Drawing.Size(245, 23);
            this.TxtBoxFileB.TabIndex = 3;
            // 
            // TxtBoxFileA
            // 
            this.TxtBoxFileA.Location = new System.Drawing.Point(82, 24);
            this.TxtBoxFileA.Name = "TxtBoxFileA";
            this.TxtBoxFileA.Size = new System.Drawing.Size(247, 23);
            this.TxtBoxFileA.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Compare:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RtfMsg);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 357);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message:";
            // 
            // RtfMsg
            // 
            this.RtfMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtfMsg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RtfMsg.Location = new System.Drawing.Point(3, 19);
            this.RtfMsg.Name = "RtfMsg";
            this.RtfMsg.Size = new System.Drawing.Size(421, 335);
            this.RtfMsg.TabIndex = 0;
            this.RtfMsg.Text = "";
            // 
            // XmFileCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 522);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Gbx_Input);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XmFileCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "XmFileCompare";
            this.Gbx_Input.ResumeLayout(false);
            this.Gbx_Input.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gbx_Input;
        private System.Windows.Forms.Button BtnCompare;
        private System.Windows.Forms.Button BtnClr;
        private System.Windows.Forms.Button BtnLoadFileB;
        private System.Windows.Forms.Button BtnLoadFileA;
        private System.Windows.Forms.TextBox TxtBoxFileB;
        private System.Windows.Forms.TextBox TxtBoxFileA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox RtfMsg;
        private System.Windows.Forms.TextBox TxtBoxState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Msg;
    }
}
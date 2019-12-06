namespace XM_Tek_Studio_Pro
{
    partial class TC_S8521_Form
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
            this.cbo_Parity = new System.Windows.Forms.ComboBox();
            this.cbo_DataBit = new System.Windows.Forms.ComboBox();
            this.cbo_BaudRate = new System.Windows.Forms.ComboBox();
            this.cbo_CommPort = new System.Windows.Forms.ComboBox();
            this.lbl_parity = new System.Windows.Forms.Label();
            this.lbl_databit = new System.Windows.Forms.Label();
            this.lbl_baudrate = new System.Windows.Forms.Label();
            this.lbl_ComPort = new System.Windows.Forms.Label();
            this.gbx_ComPort = new System.Windows.Forms.GroupBox();
            this.cbo_StopBit = new System.Windows.Forms.ComboBox();
            this.lbl_stopbit = new System.Windows.Forms.Label();
            this.SendCMDtextBox = new System.Windows.Forms.TextBox();
            this.ReadDatatextBox = new System.Windows.Forms.TextBox();
            this.SendCmdbutton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.StatustoolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TransmitFormattextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbx_ComPort.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_Parity
            // 
            this.cbo_Parity.Enabled = false;
            this.cbo_Parity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Parity.FormattingEnabled = true;
            this.cbo_Parity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark",
            "Space"});
            this.cbo_Parity.Location = new System.Drawing.Point(98, 126);
            this.cbo_Parity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_Parity.Name = "cbo_Parity";
            this.cbo_Parity.Size = new System.Drawing.Size(134, 27);
            this.cbo_Parity.TabIndex = 8;
            this.cbo_Parity.Text = "None";
            // 
            // cbo_DataBit
            // 
            this.cbo_DataBit.Enabled = false;
            this.cbo_DataBit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_DataBit.FormattingEnabled = true;
            this.cbo_DataBit.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbo_DataBit.Location = new System.Drawing.Point(98, 91);
            this.cbo_DataBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_DataBit.Name = "cbo_DataBit";
            this.cbo_DataBit.Size = new System.Drawing.Size(134, 27);
            this.cbo_DataBit.TabIndex = 7;
            this.cbo_DataBit.Text = "8";
            // 
            // cbo_BaudRate
            // 
            this.cbo_BaudRate.Enabled = false;
            this.cbo_BaudRate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_BaudRate.FormattingEnabled = true;
            this.cbo_BaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbo_BaudRate.Location = new System.Drawing.Point(98, 56);
            this.cbo_BaudRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_BaudRate.Name = "cbo_BaudRate";
            this.cbo_BaudRate.Size = new System.Drawing.Size(134, 27);
            this.cbo_BaudRate.TabIndex = 6;
            this.cbo_BaudRate.Text = "9600";
            // 
            // cbo_CommPort
            // 
            this.cbo_CommPort.Enabled = false;
            this.cbo_CommPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_CommPort.FormattingEnabled = true;
            this.cbo_CommPort.Location = new System.Drawing.Point(98, 21);
            this.cbo_CommPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_CommPort.Name = "cbo_CommPort";
            this.cbo_CommPort.Size = new System.Drawing.Size(134, 27);
            this.cbo_CommPort.TabIndex = 5;
            // 
            // lbl_parity
            // 
            this.lbl_parity.AutoSize = true;
            this.lbl_parity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_parity.Location = new System.Drawing.Point(12, 129);
            this.lbl_parity.Name = "lbl_parity";
            this.lbl_parity.Size = new System.Drawing.Size(50, 19);
            this.lbl_parity.TabIndex = 3;
            this.lbl_parity.Text = "Parity:";
            // 
            // lbl_databit
            // 
            this.lbl_databit.AutoSize = true;
            this.lbl_databit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_databit.Location = new System.Drawing.Point(12, 94);
            this.lbl_databit.Name = "lbl_databit";
            this.lbl_databit.Size = new System.Drawing.Size(73, 19);
            this.lbl_databit.TabIndex = 2;
            this.lbl_databit.Text = "Data Bits:";
            // 
            // lbl_baudrate
            // 
            this.lbl_baudrate.AutoSize = true;
            this.lbl_baudrate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_baudrate.Location = new System.Drawing.Point(12, 59);
            this.lbl_baudrate.Name = "lbl_baudrate";
            this.lbl_baudrate.Size = new System.Drawing.Size(80, 19);
            this.lbl_baudrate.TabIndex = 1;
            this.lbl_baudrate.Text = "Baud Rate:";
            // 
            // lbl_ComPort
            // 
            this.lbl_ComPort.AutoSize = true;
            this.lbl_ComPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ComPort.Location = new System.Drawing.Point(12, 24);
            this.lbl_ComPort.Name = "lbl_ComPort";
            this.lbl_ComPort.Size = new System.Drawing.Size(76, 19);
            this.lbl_ComPort.TabIndex = 0;
            this.lbl_ComPort.Text = "COM Port:";
            // 
            // gbx_ComPort
            // 
            this.gbx_ComPort.Controls.Add(this.cbo_StopBit);
            this.gbx_ComPort.Controls.Add(this.cbo_Parity);
            this.gbx_ComPort.Controls.Add(this.cbo_DataBit);
            this.gbx_ComPort.Controls.Add(this.cbo_BaudRate);
            this.gbx_ComPort.Controls.Add(this.cbo_CommPort);
            this.gbx_ComPort.Controls.Add(this.lbl_stopbit);
            this.gbx_ComPort.Controls.Add(this.lbl_parity);
            this.gbx_ComPort.Controls.Add(this.lbl_databit);
            this.gbx_ComPort.Controls.Add(this.lbl_baudrate);
            this.gbx_ComPort.Controls.Add(this.lbl_ComPort);
            this.gbx_ComPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_ComPort.Location = new System.Drawing.Point(12, 13);
            this.gbx_ComPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbx_ComPort.Name = "gbx_ComPort";
            this.gbx_ComPort.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbx_ComPort.Size = new System.Drawing.Size(249, 199);
            this.gbx_ComPort.TabIndex = 1;
            this.gbx_ComPort.TabStop = false;
            this.gbx_ComPort.Text = "Comport";
            // 
            // cbo_StopBit
            // 
            this.cbo_StopBit.Enabled = false;
            this.cbo_StopBit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_StopBit.FormattingEnabled = true;
            this.cbo_StopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbo_StopBit.Location = new System.Drawing.Point(98, 161);
            this.cbo_StopBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_StopBit.Name = "cbo_StopBit";
            this.cbo_StopBit.Size = new System.Drawing.Size(134, 27);
            this.cbo_StopBit.TabIndex = 9;
            this.cbo_StopBit.Text = "1";
            // 
            // lbl_stopbit
            // 
            this.lbl_stopbit.AutoSize = true;
            this.lbl_stopbit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stopbit.Location = new System.Drawing.Point(12, 164);
            this.lbl_stopbit.Name = "lbl_stopbit";
            this.lbl_stopbit.Size = new System.Drawing.Size(70, 19);
            this.lbl_stopbit.TabIndex = 4;
            this.lbl_stopbit.Text = "Stop Bits:";
            // 
            // SendCMDtextBox
            // 
            this.SendCMDtextBox.Location = new System.Drawing.Point(141, 217);
            this.SendCMDtextBox.Name = "SendCMDtextBox";
            this.SendCMDtextBox.Size = new System.Drawing.Size(120, 22);
            this.SendCMDtextBox.TabIndex = 2;
            // 
            // ReadDatatextBox
            // 
            this.ReadDatatextBox.Location = new System.Drawing.Point(141, 251);
            this.ReadDatatextBox.Name = "ReadDatatextBox";
            this.ReadDatatextBox.Size = new System.Drawing.Size(120, 22);
            this.ReadDatatextBox.TabIndex = 3;
            // 
            // SendCmdbutton
            // 
            this.SendCmdbutton.Location = new System.Drawing.Point(12, 216);
            this.SendCmdbutton.Name = "SendCmdbutton";
            this.SendCmdbutton.Size = new System.Drawing.Size(113, 23);
            this.SendCmdbutton.TabIndex = 4;
            this.SendCmdbutton.Text = "Send&&Read CMD";
            this.SendCmdbutton.UseVisualStyleBackColor = true;
            this.SendCmdbutton.Click += new System.EventHandler(this.SendCmdbutton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.StatustoolStripLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 308);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(280, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel1.Text = "Status :";
            // 
            // StatustoolStripLabel
            // 
            this.StatustoolStripLabel.Name = "StatustoolStripLabel";
            this.StatustoolStripLabel.Size = new System.Drawing.Size(39, 22);
            this.StatustoolStripLabel.Text = "None";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(127, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(127, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = ":";
            // 
            // TransmitFormattextBox
            // 
            this.TransmitFormattextBox.Location = new System.Drawing.Point(141, 279);
            this.TransmitFormattextBox.Name = "TransmitFormattextBox";
            this.TransmitFormattextBox.Size = new System.Drawing.Size(120, 22);
            this.TransmitFormattextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "TransmitFormat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(127, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = ":";
            // 
            // TC_S8521_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 333);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TransmitFormattextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.SendCmdbutton);
            this.Controls.Add(this.ReadDatatextBox);
            this.Controls.Add(this.SendCMDtextBox);
            this.Controls.Add(this.gbx_ComPort);
            this.Name = "TC_S8521_Form";
            this.Text = "TC_S8521";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TC_S8521_Form_FormClosed);
            this.gbx_ComPort.ResumeLayout(false);
            this.gbx_ComPort.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_Parity;
        private System.Windows.Forms.ComboBox cbo_DataBit;
        private System.Windows.Forms.ComboBox cbo_BaudRate;
        private System.Windows.Forms.ComboBox cbo_CommPort;
        private System.Windows.Forms.Label lbl_parity;
        private System.Windows.Forms.Label lbl_databit;
        private System.Windows.Forms.Label lbl_baudrate;
        private System.Windows.Forms.Label lbl_ComPort;
        private System.Windows.Forms.GroupBox gbx_ComPort;
        private System.Windows.Forms.ComboBox cbo_StopBit;
        private System.Windows.Forms.Label lbl_stopbit;
        private System.Windows.Forms.TextBox SendCMDtextBox;
        private System.Windows.Forms.TextBox ReadDatatextBox;
        private System.Windows.Forms.Button SendCmdbutton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel StatustoolStripLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TransmitFormattextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
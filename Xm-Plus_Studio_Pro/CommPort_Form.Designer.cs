namespace XM_Tek_Studio_Pro
{
    partial class CommPort_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommPort_Form));
            this.gbx_ComPort = new System.Windows.Forms.GroupBox();
            this.cbo_StopBit = new System.Windows.Forms.ComboBox();
            this.cbo_Parity = new System.Windows.Forms.ComboBox();
            this.cbo_DataBit = new System.Windows.Forms.ComboBox();
            this.cbo_BaudRate = new System.Windows.Forms.ComboBox();
            this.cbo_CommPort = new System.Windows.Forms.ComboBox();
            this.lbl_stopbit = new System.Windows.Forms.Label();
            this.lbl_parity = new System.Windows.Forms.Label();
            this.lbl_databit = new System.Windows.Forms.Label();
            this.lbl_baudrate = new System.Windows.Forms.Label();
            this.lbl_ComPort = new System.Windows.Forms.Label();
            this.Btn_CommPass = new System.Windows.Forms.Button();
            this.Btn_CommCancel = new System.Windows.Forms.Button();
            this.gbx_ComPort.SuspendLayout();
            this.SuspendLayout();
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
            this.gbx_ComPort.Location = new System.Drawing.Point(13, 16);
            this.gbx_ComPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbx_ComPort.Name = "gbx_ComPort";
            this.gbx_ComPort.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbx_ComPort.Size = new System.Drawing.Size(323, 268);
            this.gbx_ComPort.TabIndex = 0;
            this.gbx_ComPort.TabStop = false;
            this.gbx_ComPort.Text = "Comport";
            // 
            // cbo_StopBit
            // 
            this.cbo_StopBit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_StopBit.FormattingEnabled = true;
            this.cbo_StopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbo_StopBit.Location = new System.Drawing.Point(159, 217);
            this.cbo_StopBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_StopBit.Name = "cbo_StopBit";
            this.cbo_StopBit.Size = new System.Drawing.Size(134, 27);
            this.cbo_StopBit.TabIndex = 9;
            // 
            // cbo_Parity
            // 
            this.cbo_Parity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Parity.FormattingEnabled = true;
            this.cbo_Parity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark",
            "Space"});
            this.cbo_Parity.Location = new System.Drawing.Point(159, 172);
            this.cbo_Parity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_Parity.Name = "cbo_Parity";
            this.cbo_Parity.Size = new System.Drawing.Size(134, 27);
            this.cbo_Parity.TabIndex = 8;
            // 
            // cbo_DataBit
            // 
            this.cbo_DataBit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_DataBit.FormattingEnabled = true;
            this.cbo_DataBit.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbo_DataBit.Location = new System.Drawing.Point(159, 127);
            this.cbo_DataBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_DataBit.Name = "cbo_DataBit";
            this.cbo_DataBit.Size = new System.Drawing.Size(134, 27);
            this.cbo_DataBit.TabIndex = 7;
            // 
            // cbo_BaudRate
            // 
            this.cbo_BaudRate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_BaudRate.FormattingEnabled = true;
            this.cbo_BaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbo_BaudRate.Location = new System.Drawing.Point(159, 82);
            this.cbo_BaudRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_BaudRate.Name = "cbo_BaudRate";
            this.cbo_BaudRate.Size = new System.Drawing.Size(134, 27);
            this.cbo_BaudRate.TabIndex = 6;
            // 
            // cbo_CommPort
            // 
            this.cbo_CommPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_CommPort.FormattingEnabled = true;
            this.cbo_CommPort.Location = new System.Drawing.Point(159, 37);
            this.cbo_CommPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_CommPort.Name = "cbo_CommPort";
            this.cbo_CommPort.Size = new System.Drawing.Size(134, 27);
            this.cbo_CommPort.TabIndex = 5;
            // 
            // lbl_stopbit
            // 
            this.lbl_stopbit.AutoSize = true;
            this.lbl_stopbit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stopbit.Location = new System.Drawing.Point(36, 220);
            this.lbl_stopbit.Name = "lbl_stopbit";
            this.lbl_stopbit.Size = new System.Drawing.Size(70, 19);
            this.lbl_stopbit.TabIndex = 4;
            this.lbl_stopbit.Text = "Stop Bits:";
            // 
            // lbl_parity
            // 
            this.lbl_parity.AutoSize = true;
            this.lbl_parity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_parity.Location = new System.Drawing.Point(68, 175);
            this.lbl_parity.Name = "lbl_parity";
            this.lbl_parity.Size = new System.Drawing.Size(50, 19);
            this.lbl_parity.TabIndex = 3;
            this.lbl_parity.Text = "Parity:";
            // 
            // lbl_databit
            // 
            this.lbl_databit.AutoSize = true;
            this.lbl_databit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_databit.Location = new System.Drawing.Point(36, 135);
            this.lbl_databit.Name = "lbl_databit";
            this.lbl_databit.Size = new System.Drawing.Size(73, 19);
            this.lbl_databit.TabIndex = 2;
            this.lbl_databit.Text = "Data Bits:";
            // 
            // lbl_baudrate
            // 
            this.lbl_baudrate.AutoSize = true;
            this.lbl_baudrate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_baudrate.Location = new System.Drawing.Point(23, 85);
            this.lbl_baudrate.Name = "lbl_baudrate";
            this.lbl_baudrate.Size = new System.Drawing.Size(80, 19);
            this.lbl_baudrate.TabIndex = 1;
            this.lbl_baudrate.Text = "Baud Rate:";
            // 
            // lbl_ComPort
            // 
            this.lbl_ComPort.AutoSize = true;
            this.lbl_ComPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ComPort.Location = new System.Drawing.Point(28, 41);
            this.lbl_ComPort.Name = "lbl_ComPort";
            this.lbl_ComPort.Size = new System.Drawing.Size(76, 19);
            this.lbl_ComPort.TabIndex = 0;
            this.lbl_ComPort.Text = "COM Port:";
            // 
            // Btn_CommPass
            // 
            this.Btn_CommPass.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_CommPass.Location = new System.Drawing.Point(119, 292);
            this.Btn_CommPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_CommPass.Name = "Btn_CommPass";
            this.Btn_CommPass.Size = new System.Drawing.Size(102, 41);
            this.Btn_CommPass.TabIndex = 1;
            this.Btn_CommPass.Text = "OK";
            this.Btn_CommPass.UseVisualStyleBackColor = true;
            this.Btn_CommPass.Click += new System.EventHandler(this.Btn_CommPass_Click);
            // 
            // Btn_CommCancel
            // 
            this.Btn_CommCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_CommCancel.Location = new System.Drawing.Point(242, 292);
            this.Btn_CommCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_CommCancel.Name = "Btn_CommCancel";
            this.Btn_CommCancel.Size = new System.Drawing.Size(94, 41);
            this.Btn_CommCancel.TabIndex = 2;
            this.Btn_CommCancel.Text = "Cancel";
            this.Btn_CommCancel.UseVisualStyleBackColor = true;
            this.Btn_CommCancel.Click += new System.EventHandler(this.Btn_CommCancel_Click);
            // 
            // CommPort_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Btn_CommCancel;
            this.ClientSize = new System.Drawing.Size(362, 346);
            this.Controls.Add(this.Btn_CommCancel);
            this.Controls.Add(this.gbx_ComPort);
            this.Controls.Add(this.Btn_CommPass);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CommPort_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comm Port  Properties";
            this.Load += new System.EventHandler(this.CommPort_Form_Load);
            this.gbx_ComPort.ResumeLayout(false);
            this.gbx_ComPort.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_ComPort;
        private System.Windows.Forms.ComboBox cbo_CommPort;
        private System.Windows.Forms.Label lbl_stopbit;
        private System.Windows.Forms.Label lbl_parity;
        private System.Windows.Forms.Label lbl_databit;
        private System.Windows.Forms.Label lbl_baudrate;
        private System.Windows.Forms.Label lbl_ComPort;
        private System.Windows.Forms.ComboBox cbo_StopBit;
        private System.Windows.Forms.ComboBox cbo_Parity;
        private System.Windows.Forms.ComboBox cbo_DataBit;
        private System.Windows.Forms.ComboBox cbo_BaudRate;
        private System.Windows.Forms.Button Btn_CommPass;
        private System.Windows.Forms.Button Btn_CommCancel;
    }
}
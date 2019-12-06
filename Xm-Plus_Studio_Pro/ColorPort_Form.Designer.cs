namespace XM_Tek_Studio_Pro
{
    partial class ColorPort_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPort_Form));
            this.gbx_ComPort = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CboColorDev = new System.Windows.Forms.ComboBox();
            this.CboStopBit = new System.Windows.Forms.ComboBox();
            this.CboParity = new System.Windows.Forms.ComboBox();
            this.CboDataBit = new System.Windows.Forms.ComboBox();
            this.CboBaudRate = new System.Windows.Forms.ComboBox();
            this.CboCommPort = new System.Windows.Forms.ComboBox();
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
            this.gbx_ComPort.Controls.Add(this.label1);
            this.gbx_ComPort.Controls.Add(this.CboColorDev);
            this.gbx_ComPort.Controls.Add(this.CboStopBit);
            this.gbx_ComPort.Controls.Add(this.CboParity);
            this.gbx_ComPort.Controls.Add(this.CboDataBit);
            this.gbx_ComPort.Controls.Add(this.CboBaudRate);
            this.gbx_ComPort.Controls.Add(this.CboCommPort);
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
            this.gbx_ComPort.Size = new System.Drawing.Size(323, 247);
            this.gbx_ComPort.TabIndex = 0;
            this.gbx_ComPort.TabStop = false;
            this.gbx_ComPort.Text = "Comport";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Device:";
            // 
            // CboColorDev
            // 
            this.CboColorDev.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboColorDev.FormattingEnabled = true;
            this.CboColorDev.Items.AddRange(new object[] {
            "Klein Instruments  K-80",
            "KonicaMinolta CA-210"});
            this.CboColorDev.Location = new System.Drawing.Point(121, 28);
            this.CboColorDev.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CboColorDev.Name = "CboColorDev";
            this.CboColorDev.Size = new System.Drawing.Size(172, 27);
            this.CboColorDev.TabIndex = 10;
            this.CboColorDev.SelectedIndexChanged += new System.EventHandler(this.CboColorDev_SelectedIndexChanged);
            // 
            // CboStopBit
            // 
            this.CboStopBit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboStopBit.FormattingEnabled = true;
            this.CboStopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.CboStopBit.Location = new System.Drawing.Point(121, 203);
            this.CboStopBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CboStopBit.Name = "CboStopBit";
            this.CboStopBit.Size = new System.Drawing.Size(172, 27);
            this.CboStopBit.TabIndex = 9;
            // 
            // CboParity
            // 
            this.CboParity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboParity.FormattingEnabled = true;
            this.CboParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark",
            "Space"});
            this.CboParity.Location = new System.Drawing.Point(121, 168);
            this.CboParity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CboParity.Name = "CboParity";
            this.CboParity.Size = new System.Drawing.Size(172, 27);
            this.CboParity.TabIndex = 8;
            // 
            // CboDataBit
            // 
            this.CboDataBit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboDataBit.FormattingEnabled = true;
            this.CboDataBit.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.CboDataBit.Location = new System.Drawing.Point(121, 133);
            this.CboDataBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CboDataBit.Name = "CboDataBit";
            this.CboDataBit.Size = new System.Drawing.Size(172, 27);
            this.CboDataBit.TabIndex = 7;
            // 
            // CboBaudRate
            // 
            this.CboBaudRate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboBaudRate.FormattingEnabled = true;
            this.CboBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.CboBaudRate.Location = new System.Drawing.Point(121, 98);
            this.CboBaudRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CboBaudRate.Name = "CboBaudRate";
            this.CboBaudRate.Size = new System.Drawing.Size(172, 27);
            this.CboBaudRate.TabIndex = 6;
            // 
            // CboCommPort
            // 
            this.CboCommPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboCommPort.FormattingEnabled = true;
            this.CboCommPort.Location = new System.Drawing.Point(121, 63);
            this.CboCommPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CboCommPort.Name = "CboCommPort";
            this.CboCommPort.Size = new System.Drawing.Size(172, 27);
            this.CboCommPort.TabIndex = 5;
            // 
            // lbl_stopbit
            // 
            this.lbl_stopbit.AutoSize = true;
            this.lbl_stopbit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stopbit.Location = new System.Drawing.Point(42, 206);
            this.lbl_stopbit.Name = "lbl_stopbit";
            this.lbl_stopbit.Size = new System.Drawing.Size(70, 19);
            this.lbl_stopbit.TabIndex = 4;
            this.lbl_stopbit.Text = "Stop Bits:";
            // 
            // lbl_parity
            // 
            this.lbl_parity.AutoSize = true;
            this.lbl_parity.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_parity.Location = new System.Drawing.Point(59, 171);
            this.lbl_parity.Name = "lbl_parity";
            this.lbl_parity.Size = new System.Drawing.Size(50, 19);
            this.lbl_parity.TabIndex = 3;
            this.lbl_parity.Text = "Parity:";
            // 
            // lbl_databit
            // 
            this.lbl_databit.AutoSize = true;
            this.lbl_databit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_databit.Location = new System.Drawing.Point(39, 136);
            this.lbl_databit.Name = "lbl_databit";
            this.lbl_databit.Size = new System.Drawing.Size(73, 19);
            this.lbl_databit.TabIndex = 2;
            this.lbl_databit.Text = "Data Bits:";
            // 
            // lbl_baudrate
            // 
            this.lbl_baudrate.AutoSize = true;
            this.lbl_baudrate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_baudrate.Location = new System.Drawing.Point(29, 101);
            this.lbl_baudrate.Name = "lbl_baudrate";
            this.lbl_baudrate.Size = new System.Drawing.Size(80, 19);
            this.lbl_baudrate.TabIndex = 1;
            this.lbl_baudrate.Text = "Baud Rate:";
            // 
            // lbl_ComPort
            // 
            this.lbl_ComPort.AutoSize = true;
            this.lbl_ComPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ComPort.Location = new System.Drawing.Point(33, 66);
            this.lbl_ComPort.Name = "lbl_ComPort";
            this.lbl_ComPort.Size = new System.Drawing.Size(76, 19);
            this.lbl_ComPort.TabIndex = 0;
            this.lbl_ComPort.Text = "COM Port:";
            // 
            // Btn_CommPass
            // 
            this.Btn_CommPass.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_CommPass.Location = new System.Drawing.Point(119, 271);
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
            this.Btn_CommCancel.Location = new System.Drawing.Point(242, 271);
            this.Btn_CommCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_CommCancel.Name = "Btn_CommCancel";
            this.Btn_CommCancel.Size = new System.Drawing.Size(94, 41);
            this.Btn_CommCancel.TabIndex = 2;
            this.Btn_CommCancel.Text = "Cancel";
            this.Btn_CommCancel.UseVisualStyleBackColor = true;
            this.Btn_CommCancel.Click += new System.EventHandler(this.Btn_CommCancel_Click);
            // 
            // ColorPort_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Btn_CommCancel;
            this.ClientSize = new System.Drawing.Size(362, 327);
            this.Controls.Add(this.Btn_CommCancel);
            this.Controls.Add(this.gbx_ComPort);
            this.Controls.Add(this.Btn_CommPass);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ColorPort_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Comm Port  Properties";
            this.Load += new System.EventHandler(this.ColorPort_Form_Load);
            this.gbx_ComPort.ResumeLayout(false);
            this.gbx_ComPort.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_ComPort;
        private System.Windows.Forms.ComboBox CboCommPort;
        private System.Windows.Forms.Label lbl_stopbit;
        private System.Windows.Forms.Label lbl_parity;
        private System.Windows.Forms.Label lbl_databit;
        private System.Windows.Forms.Label lbl_baudrate;
        private System.Windows.Forms.Label lbl_ComPort;
        private System.Windows.Forms.ComboBox CboStopBit;
        private System.Windows.Forms.ComboBox CboParity;
        private System.Windows.Forms.ComboBox CboDataBit;
        private System.Windows.Forms.ComboBox CboBaudRate;
        private System.Windows.Forms.Button Btn_CommPass;
        private System.Windows.Forms.Button Btn_CommCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboColorDev;
    }
}
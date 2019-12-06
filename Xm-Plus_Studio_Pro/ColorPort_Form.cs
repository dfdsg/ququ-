using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class ColorPort_Form : Form
    {
        private int  PortCout = 0;
        private string ColorDev =null, DevSelect = null, Comport = null, BaudRate = null, Databit = null, Parity = null, StopBits = null;
        
        public ColorPort_Form()
        {
            InitializeComponent();
        }

        public ColorPort_Form(string SelDeV)
        {
            InitializeComponent();
            this.DevSelect = SelDeV;
        }

        private void SetCommtUI()
        {
            XM_Ini_Util XmIni = new XM_Ini_Util(Setting.ExeSysIniPath);
            XM_Digital_Util IOLib = new XM_Digital_Util();
            int Device = 0;
            ColorDev = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.COLORDEV);
            Comport = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.COMPORT);
            BaudRate = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.BAUDRATE);
            Databit = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.DATABIT);
            Parity = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.PARITY);
            StopBits = XmIni.IniReadValue(XMPLUSPARS.SECTION3, XMPLUSPARS.STOPBIT);

            if (!IOLib.StrToNumber<int>(ColorDev, ref Device)) return;

            CboColorDev.SelectedIndex = Device;
            CboCommPort.SelectedIndex = (CboCommPort.Items.IndexOf(Comport) < 0) ? 0 : CboCommPort.Items.IndexOf(Comport);
            CboBaudRate.SelectedIndex = CboBaudRate.Items.IndexOf(BaudRate);
            CboDataBit.SelectedIndex = CboDataBit.Items.IndexOf(Databit);
            CboParity.SelectedIndex = CboParity.Items.IndexOf(Parity);
            CboStopBit.SelectedIndex = CboStopBit.Items.IndexOf(StopBits);
        }

        private void Btn_CommPass_Click(object sender, EventArgs e)
        {
            string ColorDev = null, ColorPort = null, ColorDataRate = null, ColorDataBit = null, ColorParity = null, ColorStopbit = null, StrNull = "NULL";
            XM_Ini_Util XmIni = new XM_Ini_Util(Setting.ExeSysIniPath);

            int a = CboBaudRate.SelectedIndex;

            ColorDev = CboColorDev.SelectedIndex < 0 ? StrNull : CboColorDev.SelectedIndex.ToString();
            ColorPort = string.IsNullOrEmpty(CboCommPort.SelectedItem.ToString()) ? StrNull : CboCommPort.SelectedItem.ToString();
            ColorDataRate = CboBaudRate.SelectedIndex < 0 ? StrNull : CboBaudRate.SelectedItem.ToString();
            ColorDataBit = CboDataBit.SelectedIndex < 0 ? StrNull : CboDataBit.SelectedItem.ToString();
            ColorParity = CboParity.SelectedIndex < 0 ? StrNull : CboParity.SelectedItem.ToString();
            ColorStopbit = CboStopBit.SelectedIndex < 0 ? StrNull : CboStopBit.SelectedItem.ToString();

            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.COLORDEV, ColorDev);
            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.COMPORT, ColorPort);
            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.BAUDRATE, ColorDataRate);
            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.DATABIT, ColorDataBit);
            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.PARITY, ColorParity);
            XmIni.IniWriteValue(XMPLUSPARS.SECTION3, XMPLUSPARS.STOPBIT, ColorStopbit);

            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void Btn_CommCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CboColorDev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CboColorDev.SelectedIndex ==0)
                CboStopBit.Enabled = CboParity.Enabled = CboDataBit.Enabled = CboBaudRate.Enabled = false;
            else
                CboStopBit.Enabled = CboParity.Enabled = CboDataBit.Enabled = CboBaudRate.Enabled = true;
        }

        private void ColorPort_Form_Load(object sender, EventArgs e)
        {
            string[] Ports = SerialPort.GetPortNames();
            this.PortCout = Ports.Length;
            if (PortCout > 0)
            {
                foreach (string port in Ports)
                    CboCommPort.Items.Add(port);
            }
            else
                CboCommPort.Items.Add("Null");

            if (new XM_IO_Util().IsFileExist(Setting.ExeSysIniPath)) SetCommtUI();
        }
    }
}

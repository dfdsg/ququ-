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
    public partial class CommPort_Form : Form
    {
        private string DevSelect = null;
        private string Comport = null;
        private string BaudRate = null;
        private string Databit = null;
        private string Parity = null;
        private string StopBits = null;
        private int PortCout = 0;

        public CommPort_Form()
        {
            InitializeComponent();
        }

        public CommPort_Form(string SelDeV)
        {
            InitializeComponent();
            this.DevSelect = SelDeV;
        }

        private void SetCommtUI()
        {
            XM_Ini_Util XmIni = new XM_Ini_Util(Setting.ExeSysIniPath);
            Comport = XmIni.IniReadValue(DevSelect, XMPLUSPARS.COMPORT);
            BaudRate = XmIni.IniReadValue(DevSelect, XMPLUSPARS.BAUDRATE);
            Databit = XmIni.IniReadValue(DevSelect, XMPLUSPARS.DATABIT);
            Parity = XmIni.IniReadValue(DevSelect, XMPLUSPARS.PARITY);
            StopBits = XmIni.IniReadValue(DevSelect, XMPLUSPARS.STOPBIT);

            cbo_CommPort.SelectedIndex = (cbo_CommPort.Items.IndexOf(Comport) < 0) ? 0 : cbo_CommPort.Items.IndexOf(Comport);
            cbo_BaudRate.SelectedIndex = cbo_BaudRate.Items.IndexOf(BaudRate);
            cbo_DataBit.SelectedIndex = cbo_DataBit.Items.IndexOf(Databit);
            cbo_Parity.SelectedIndex = cbo_Parity.Items.IndexOf(Parity);
            cbo_StopBit.SelectedIndex = cbo_StopBit.Items.IndexOf(StopBits);
        }

        private void Btn_CommPass_Click(object sender, EventArgs e)
        {
            XM_Ini_Util XmIni = new XM_Ini_Util(Setting.ExeSysIniPath);
            XmIni.IniWriteValue(DevSelect, XMPLUSPARS.COMPORT, cbo_CommPort.SelectedItem.ToString());
            XmIni.IniWriteValue(DevSelect, XMPLUSPARS.BAUDRATE, cbo_BaudRate.SelectedItem.ToString());
            XmIni.IniWriteValue(DevSelect, XMPLUSPARS.DATABIT, cbo_DataBit.SelectedItem.ToString());
            XmIni.IniWriteValue(DevSelect, XMPLUSPARS.PARITY, cbo_Parity.SelectedItem.ToString());
            XmIni.IniWriteValue(DevSelect, XMPLUSPARS.STOPBIT, cbo_StopBit.SelectedItem.ToString());
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void CommPort_Form_Load(object sender, EventArgs e)
        {
            string[] Ports = SerialPort.GetPortNames();
            this.PortCout = Ports.Length;
            if (PortCout > 0)
            {
                foreach (string port in Ports)
                    cbo_CommPort.Items.Add(port);
            }
            else
                cbo_CommPort.Items.Add("Null");

            if (new XM_IO_Util().IsFileExist(Setting.ExeSysIniPath)) SetCommtUI();
        }

        private void Btn_CommCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

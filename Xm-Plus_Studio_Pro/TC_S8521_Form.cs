using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using XM_Tek_Studio_Pro.StudioUtil;
using System.Threading;

namespace XM_Tek_Studio_Pro
{
    public partial class TC_S8521_Form : Form
    {
        //private string DevSelect = null;
        //private string Comport = null;
        //private string BaudRate = null;
        //private string Databit = null;
        //private string Parity = null;
        //private string StopBits = null;

        private const string EQUIPMENTSTART = "%,217";
        private const string EQUIPMENTEND = "%,217=0";
        private const string R_TEMPER_PV = "!,100";
        private const string W_TEMPER_SV = "!,101=";
        private const string R_TEMPER_SV = "!,101";
 
        public class Temperature
        {
            public static readonly char   StartChar='@';
            public static string ID = "001";
            public static readonly char DelimiterChars = ',';
            public static readonly char[] FunctionChar = { '%', '!', '$', '#', '^' };
            public static string TempAddr;
            public static int CheckSum;
            public static string W_RearString = "\r\n";
            public static string R_RearString = "\r";
            public static readonly string EndString ="Ok";
            public static string TransmitData;
            public static string ReceiverData;
            public static string Write_OK="@001";
        }

       // private int PortCout = 0;

        private char[] RxBuf = new char[128];
        string CommPort = null, CommBaudRate = null, CommDatabit = null, CommParity = null, CommStopBits = null;
        public bool isCommOpen = false;
        private SerialPort xmComm;

        public  SerialPort GetxmComm()
        {
            return xmComm;
        }

        public string AppendCheckSum(string Cmd)
        {
            try
            {
                char[] Cmdchar = Cmd.ToCharArray();
                int SumValue = 0;
                string CheckSum = "";
                for (int i = 0; i < Cmdchar.Length; i++)
                {
                    SumValue = SumValue + Cmdchar[i];
                }
                CheckSum = (SumValue % 255).ToString("X02");
                Cmd = Cmd + CheckSum + Temperature.W_RearString;
                return Cmd;
            }
            catch (Exception ex )
            {
                throw ex ;
            }
        }

        public bool CheckSumStatus(string Cmd)
        {
            bool ret = true;
            try
            {
                int SumValue = 0;
                string CheckSum = "";
                string CalCheckSum = "";

                if (!Cmd.EndsWith("\r"))
                { ret = false; }
                else
                {
                  Cmd = Cmd.Remove(Cmd.Length - 1, 1);
                  CheckSum = Cmd.Substring(Cmd.Length - 2);
                  Cmd = Cmd.Remove(Cmd.Length - 2, 2);
                }

                char[] Cmdchar = Cmd.ToCharArray();
                for (int i = 0; i < Cmdchar.Length; i++)
                {
                    SumValue = SumValue + Cmdchar[i];
                }

                CalCheckSum = (SumValue % 255).ToString("X02");
                
                if (CalCheckSum.CompareTo(CheckSum) != 0)
                { ret = false; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public bool CommOpen()
        {
            bool ret = true;

            cbo_CommPort.Text = CommPort;
            CommBaudRate = cbo_BaudRate.Text;
            CommDatabit = cbo_DataBit.Text;
            CommParity = cbo_Parity.Text;
            CommStopBits = cbo_StopBit.Text;

            this.xmComm = new SerialPort
            {
                PortName = CommPort,
                BaudRate = int.Parse(CommBaudRate),
                DataBits = int.Parse(CommDatabit)
            };

            switch (CommParity)
            {
                case "None":
                    this.xmComm.Parity = Parity.None;
                    break;
                case "Even":
                    this.xmComm.Parity = Parity.Even;
                    break;
                case "Odd":
                    this.xmComm.Parity = Parity.Odd;
                    break;
                case "Mark":
                    this.xmComm.Parity = Parity.Mark;
                    break;
                case "Space":
                    this.xmComm.Parity = Parity.Space;
                    break;
                default:
                    this.xmComm.Parity = Parity.None;
                    break;
            }

            switch (CommStopBits)
            {
                case "1":
                    this.xmComm.StopBits = StopBits.One;
                    break;
                case "1.5":
                    this.xmComm.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    this.xmComm.StopBits = StopBits.Two;
                    break;
                default:
                    this.xmComm.StopBits = StopBits.One;
                    break;
            }

            try
            {
                this.xmComm.ReadTimeout = 1000;
                this.xmComm.WriteTimeout = 1000;
                this.xmComm.WriteBufferSize = 8192;
                this.xmComm.ReadBufferSize = 8192;
                this.xmComm.RtsEnable = true;    //For CA210
                this.xmComm.DtrEnable = true;    //For CA210
                isCommOpen = true;
                this.xmComm.Open();
                this.xmComm.DiscardInBuffer();
                this.xmComm.DiscardOutBuffer();
            }
            catch (Exception ex)
            {
                if (ex.Source != null)
                    ret = false;

                isCommOpen = false;
            }

            if (!this.xmComm.IsOpen)
            { ret = false; StatustoolStripLabel.Text = "Connect Fail!..."; toolStrip1.BackColor = Color.Red; }
            else { StatustoolStripLabel.Text = "Connect Successful!..."; toolStrip1.BackColor = Color.Green; }

            return ret;
        }

        public void CommClose()
        {
            try
            {
                this.xmComm.Close();
                isCommOpen = false;
            }
            catch (Exception ex)
            {
                Log.F(this.GetType().FullName, "CommClose() Error: " + ex.Message);
            }
        }

        public void Connectbutton_Click(object sender, EventArgs e)
        {
            CommOpen();
            //GetxmComm();
        }

        public void DisConnbutton_Click(object sender, EventArgs e)
        {
            CommClose();
        }

        private bool Read( ref string RdCmd)
        {
            bool ret = true;
            ReadData(ref RdCmd);
            ret = CheckSumStatus(RdCmd);
            if (ret)
            {
                if (RdCmd.Contains("Ok"))
                {
                    if (RdCmd.Contains("="))
                        RdCmd = RdCmd.Substring(RdCmd.IndexOf("="));
                    RdCmd = RdCmd.Substring(RdCmd.IndexOf("=") + 1, RdCmd.IndexOf(",") - 1);
                }
                else { ret = false; }
            }
            return ret;
        }

        //public bool Read(ref string RdCmd)
        //{
        //    ReadData(ref RdCmd);
        //    return CheckSumStatus(RdCmd);


        //}

        public bool ReadData(ref string RetStr)
        {
            bool ret = true;
            try
            {
                RetStr = this.xmComm.ReadExisting();
            }
            catch (Exception)
            {
                ret = false;
                throw;
            }
            return ret;
        }

        public void ReadDatabutton_Click(object sender, EventArgs e)
        {
            string RData = "";
            Read(ref RData);
            ReadDatatextBox.Text = RData;
        }

        public bool Send(string Command)
        {
            return SendCmd(Command);
        }

        public bool SendRead(string Command, ref string RdCmd)
        {
            return SendAndRead(Command, ref RdCmd);
        }

        public bool SendCmd(string Cmd)
        {
            if (this.xmComm == null) return false;
            char[] ElecsCmd = Cmd.ToCharArray();
            this.xmComm.Write(ElecsCmd, 0, ElecsCmd.Length);
            return true;
        }

        private void TC_S8521_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
        //    CommClose();
        }

        public bool SendAndRead(string Command, ref string RetStr)
        {
            bool ret = true;

            if (Send(Command))
            {
                Thread.Sleep(500);
                ret = Read(ref RetStr);
            }
            else
                ret = false;

            return ret;
        }

        private void SendCmdbutton_Click(object sender, EventArgs e)
        {
             string ReadData= "";
             TransmitFormattextBox.Text = AppendCheckSum(SendCMDtextBox.Text);
             SendAndRead(AppendCheckSum(SendCMDtextBox.Text),ref ReadData);
             ReadDatatextBox.Text = ReadData;
        }

        public TC_S8521_Form( ref SerialPort xmComm,string Comport,ref bool ConnectStatus)
        {
            InitializeComponent();
            CommPort = Comport;
            try
            {
                if (xmComm == null)
                {
                    if (!CommOpen())
                    { ConnectStatus = false; xmComm = null; }
                    else xmComm = this.xmComm;
                }
                else { StatustoolStripLabel.Text = "Connect Successful!..."; toolStrip1.BackColor = Color.Green; }
                 
            }
            catch (Exception ex )
            {

                throw ex;
            }
           
        }
    }
}

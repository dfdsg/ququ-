using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using XM_Tek_Studio_Pro.StudioUtil;
using Excel = Microsoft.Office.Interop.Excel;


namespace XM_Tek_Studio_Pro
{
    public partial class Instrument : Form
    {
        //int CheckFlag = 0;  //only for test
        //====SU241 COMMAND LIST==
        // MONITOR CONDITION: "1, MON?" + Enter
        // MONITOR TEMPERATURE SETTING: "1, TEMP?" + Enter
        // SET POWER ON/OFF: "1, POWER, NO" + Enter / "1, POWER, OFF" + Enter
        // SET TEMPERATURE: "1, TEMP, S23.0" + Enter 
        // SET OPERATING MODE: "1, MODE, STANDBY" + Enter  //key word: STANDBY, OFF, CONSTANT
        // 1 means SU241 RS485 address
        //====SU241 COMMAND LIST==

        public static readonly string XM_TEMPER_TEMPERATURESET = "TEMPERATURE SET";

        public static readonly string XM_TEMPER_INSTRUMENT_SET = "INSTRUMENT SET";
        public static readonly string XM_TEMPER_POWERSET = "POWER SET";
        public static readonly string XM_TEMPER_POWERSET1 = "POWER SET1";
        public static readonly string XM_TEMPER_POWERSET2 = "POWER SET2";
        public static readonly string XM_TEMPER_POWERSET3 = "POWER SET3";
        public static readonly string XM_TEMPER_POWERSET4 = "POWER SET4";
        public static readonly string XM_TEMPER_POWERSET5 = "POWER SET5";
        public static readonly string XM_TEMPER_POWERSET6 = "POWER SET6";
        public static readonly string XM_TEMPER_POWERSET7 = "POWER SET7";
        public static readonly string XM_TEMPER_POWERSET8 = "POWER SET8";

        public static readonly string XM_TEMPER_FPGA_SET = "FPGA SET";
        public static readonly string XM_TEMPER_INITIAL_CODE = "DISPLAY INITIAL CODE";
        public static readonly string XM_TEMPER_DISPLAY_ON = "DISPLAY ON";
        public static readonly string XM_TEMPER_DISPLAY_OFF = "DISPLAY OFF";
        public static readonly string XM_TEMPER_SLEEP_IN = "SLEEP IN";
        public static readonly string XM_TEMPER_SLEEP_OUT = "SLEEP OUT";

        public static readonly string XM_TEMPER_CMDSET = "CMD SET";
        public static readonly string XM_TEMPER_CMDSET1 = "CMD SET1";
        public static readonly string XM_TEMPER_CMDSET2 = "CMD SET2";
        public static readonly string XM_TEMPER_CMDSET3 = "CMD SET3";
        public static readonly string XM_TEMPER_CMDSET4 = "CMD SET4";
        public static readonly string XM_TEMPER_CMDSET5 = "CMD SET5";
        public static readonly string XM_TEMPER_CMDSET6 = "CMD SET6";
        public static readonly string XM_TEMPER_CMDSET7 = "CMD SET7";
        public static readonly string XM_TEMPER_CMDSET8 = "CMD SET8";
        public static readonly string XM_TEMPER_CMDSET9 = "CMD SET9";
        public static readonly string XM_TEMPER_CMDSET10 = "CMD SET10";
        public static readonly string XM_TEMPER_CMDSET11 = "CMD SET11";
        public static readonly string XM_TEMPER_CMDSET12 = "CMD SET12";
        public static readonly string XM_TEMPER_CMDSET13 = "CMD SET13";
        public static readonly string XM_TEMPER_CMDSET14 = "CMD SET14";
        public static readonly string XM_TEMPER_CMDSET15 = "CMD SET15";
        public static readonly string XM_TEMPER_CMDSET16 = "CMD SET16";
        public static readonly string XM_TEMPER_CMDSET17 = "CMD SET17";
        public static readonly string XM_TEMPER_CMDSET18 = "CMD SET18";
        public static readonly string XM_TEMPER_CMDSET19 = "CMD SET19";
        public static readonly string XM_TEMPER_CMDSET20 = "CMD SET20";

        public static readonly string XM_TEMPER_IMAGE_SHOW = "IMAGE SHOW";
        public static readonly string XM_TEMPER_IMAGECMDSET = "IMAGE CMD SET";
        public static readonly string XM_TEMPER_IMAGECMDSET1 = "IMAGE CMD SET";
        public static readonly string XM_TEMPER_IMAGECMDSET2 = "IMAGE CMD SET2";
        public static readonly string XM_TEMPER_IMAGECMDSET3 = "IMAGE CMD SET3";
        public static readonly string XM_TEMPER_IMAGECMDSET4 = "IMAGE CMD SET4";
        public static readonly string XM_TEMPER_IMAGECMDSET5 = "IMAGE CMD SET5";
        public static readonly string XM_TEMPER_IMAGECMDSET6 = "IMAGE CMD SET6";
        public static readonly string XM_TEMPER_IMAGECMDSET7 = "IMAGE CMD SET7";
        public static readonly string XM_TEMPER_IMAGECMDSET8 = "IMAGE CMD SET8";
        public static readonly string XM_TEMPER_IMAGECMDSET9 = "IMAGE CMD SET9";
        public static readonly string XM_TEMPER_IMAGECMDSET10 = "IMAGE CMD SET10";
        public static readonly string XM_TEMPER_IMAGECMDSET11 = "IMAGE CMD SET11";
        public static readonly string XM_TEMPER_IMAGECMDSET12 = "IMAGE CMD SET12";
        public static readonly string XM_TEMPER_IMAGECMDSET13 = "IMAGE CMD SET13";
        public static readonly string XM_TEMPER_IMAGECMDSET14 = "IMAGE CMD SET14";
        public static readonly string XM_TEMPER_IMAGECMDSET15 = "IMAGE CMD SET15";
        public static readonly string XM_TEMPER_IMAGECMDSET16 = "IMAGE CMD SET16";

        public static readonly string XM_TEMPER_SAVE_FILE = "SAVE FILE";
        public static readonly string XM_TEMPER_SAVE_FILE1 = "SAVE FILE1";
        public static readonly string XM_TEMPER_SAVE_FILE2 = "SAVE FILE2";
        public static readonly string XM_TEMPER_SAVE_FILE3 = "SAVE FILE3";
        public static readonly string XM_TEMPER_SAVE_FILE4 = "SAVE FILE4";
        public static readonly string XM_TEMPER_SAVE_FILE5 = "SAVE FILE5";
        public static readonly string XM_TEMPER_SAVE_FILE6 = "SAVE FILE6";
        public static readonly string XM_TEMPER_SAVE_FILE7 = "SAVE FILE7";
        public static readonly string XM_TEMPER_SAVE_FILE8 = "SAVE FILE8";
        public static readonly string XM_TEMPER_SAVE_FILE9 = "SAVE FILE9";
        public static readonly string XM_TEMPER_SAVE_FILE10 = "SAVE FILE10";
        public static readonly string XM_TEMPER_SAVE_FILE11 = "SAVE FILE11";
        public static readonly string XM_TEMPER_SAVE_FILE12 = "SAVE FILE12";
        public static readonly string XM_TEMPER_SAVE_FILE13 = "SAVE FILE13";
        public static readonly string XM_TEMPER_SAVE_FILE14 = "SAVE FILE14";
        public static readonly string XM_TEMPER_SAVE_FILE15 = "SAVE FILE15";
        public static readonly string XM_TEMPER_SAVE_FILE16 = "SAVE FILE16";
        //public static readonly string XM_TEMPER_SAVE_FILE = "SAVE FILE ";


        enum MSG : int { MSG_MULTIRD = 1, MSG_TIMETEXT, MSG_TEMPERTEXT, TEXTBOX, MSG_ONOFFTIMETEXT, MSG_RESULT };
        int /*vddio,*/Measure_Voltage_Number, Measure_Current_Number;
        string Sample_Index,/* Temperature,*/ Envior_type, FilePath;
        int OnOffTime = 0;

        private int PortCout = 0;
        private char[] RxBuf = new char[128];
        public bool isCommOpen = false;

        Thread XmThead;

        string Item1_PowerTest_TxtPath = "";
        string Item1_PoweronoffTxtPath = "";

        DateTime startDate;
        // private XM_ExeMainCmd ExeCmd = new XM_ExeMainCmd();
        XM_ExeMainCmd ExeCmd = ScriptSetting_Form.ExeCmd;
        private bool bStopRun = false;
        private string XmStr = null;

        public class XM_Temperature
        {
            public static readonly char StartChar = '@';
            public static string ID = "001";
            public static readonly char DelimiterChars = ',';
            public static readonly char[] FunctionChar = { '%', '!', '$', '#', '^' };
            public static string TempAddr;
            public static int CheckSum;
            public static string W_RearString = "\r\n";
            public static string R_RearString = "\r";
            public static readonly string EndString = "Ok";
            public static string TransmitData;
            public static string ReceiverData;
            public static string Write_OK = "@001";
        }

        public class XM_Comm_Temperature
        {
            public class TestItem
            {

                public List<string> CmdList = new List<string>();
                public string ItemName = "";
            }


            public static TestItem[] TemperCmdList = new TestItem[512];
        }

        public class XM_Comm_Control_Temperature
        {
            public static XM_Comm_Temperature XM_Comm_Base_Temperature;

            public static List<XM_Comm_Temperature> XM_Comm_Type_Temperature = new List<XM_Comm_Temperature>();
        }

        private XM_EquipVisa_Util XM_EquipVisa;
        private XM_EquipVisa_Util XM_EquipVisa_CurrMeter;
        private XM_EquipVisa_Util XM_EquipVisa_VolMeter;

        char[] rdBuf = new char[128];
        string CurrentMeter = null, VoltageMeter = null;
       // private XM_ExeMainCmd TemperExeCmd = null;
        public SerialPort XmComm = null;

        private void InitalTempeture_Item()
        {

            for (int i = 0; i < 512; i++)
            {
                XM_Comm_Temperature.TemperCmdList[i] = null;
                XM_Comm_Temperature.TemperCmdList[i] = new XM_Comm_Temperature.TestItem();
            }
        }

        public XM_EquipVisa_Util XM_EquipVisa1 { get => XM_EquipVisa; set => XM_EquipVisa = value; }
        public XM_EquipVisa_Util XM_EquipVisa_CurrMeter1 { get => XM_EquipVisa_CurrMeter; set => XM_EquipVisa_CurrMeter = value; }
        public XM_EquipVisa_Util XM_EquipVisa_VolMeter1 { get => XM_EquipVisa_VolMeter; set => XM_EquipVisa_VolMeter = value; }


        public Instrument()
        {
            InitializeComponent();
            XM_Comm_Control_Temperature.XM_Comm_Type_Temperature.Add(new XM_Comm_Temperature());
            InitalTempeture_Item();

           // TemperExeCmd = new XM_ExeMainCmd();

            string[] Ports = SerialPort.GetPortNames();
            this.PortCout = Ports.Length;
            if (PortCout > 0)
            {
                foreach (string port in Ports)
                    Temper_CommPort.Items.Add(port);
            }
            else
                Temper_CommPort.Items.Add("Null");
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
                Cmd = Cmd + CheckSum + XM_Temperature.W_RearString;
                return Cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void checkEanble_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkEanble)
            //{
            //    Comportlabel.Enabled = false;
            //    Temper_CommPort.Enabled = false;
            //    TC_S8521button.Enabled = false;
            //}

        }

        private int CheckInstrument()
        {
            XM_EquipVisa = new XM_EquipVisa_Util();
            XM_IO_Util FileUtil = new XM_IO_Util();
            int Voltage_flag = 0, Current_flag = 0, MIPI_flag = 0, Power_flag = 0, /*File_Flag = 0,*/ CheckFlag = 0, PowerSupplyCount = 0;
            string[] equitment = XM_EquipVisa.SearchAllEquip();
            string InstruCmd = "*IDN?", rdStrTemp = null, rdStr = null, date = DateTime.Today.ToString("yyyyMMdd"), Temp = null;
            string PowerSupplyName = "GW INSTEK", DigitMeterName = "34465A", XMBridgeName = "Xm";

            char[] SplitDotChar = { ',' };

            InvokerResultRichText("", Color.Black);
            /*Equipment Test*/
            for (int i = 0; i < equitment.Length; i++)
            {

                XM_EquipVisa = new XM_EquipVisa_Util(equitment[i]);
                Temp = rdStr = null;
                if (XM_EquipVisa.VisaSendandRead(InstruCmd, out rdStr) == 0 && !String.IsNullOrEmpty(rdStr)) //read instrument and return model name
                {
                    string[] str = rdStr.Split(SplitDotChar);

                    if (string.Compare(str[0], PowerSupplyName) == 0)
                    {

                        if(PowerSupplyCount == 0 )
                        {
                            InvokerResultRichText(" Power supply Connection is OK!.......... ", Color.Green);
                            PowerSupply1textBox.Text = equitment[i];
                            PowerSupply1textBox.BackColor = Color.GreenYellow;
                            Application.DoEvents();
                            Power_flag = 1;
                            XM_EquipVisa.VisaSend("OUT0");
                            PowerSupplyCount++;
                        }else
                        {
                            InvokerResultRichText(" Power supply Connection is OK!.......... ", Color.Green);
                            PowerSupply2textBox.Text = equitment[i];
                            PowerSupply2textBox.BackColor = Color.GreenYellow;
                            Application.DoEvents();
                            Power_flag = 1;
                            XM_EquipVisa.VisaSend("OUT0");
                            PowerSupplyCount++;
                        }                   
                        continue;
                    }

                    if (string.Compare(str[1], DigitMeterName) == 0)
                    {
                        XM_EquipVisa.VisaSendandRead("CONFigure?", out rdStrTemp);
                        rdStrTemp = rdStrTemp.Substring(1, 5);
                        if (string.Compare(rdStrTemp, 0, "VOLT", 0, 4) == 0)
                        {

                            InvokerResultRichText(" Voltage Meter Connection is OK!.......... ", Color.Green);
                            VoltageMetertextBox.Text = equitment[i];
                            VoltageMetertextBox.BackColor = Color.GreenYellow;
                            Voltage_flag = 1;
                            VoltageMeter = equitment[i];
                            continue;
                        }
                        if (string.Compare(rdStrTemp, 0, "CURR", 0, 4) == 0)
                        {

                            InvokerResultRichText(" Current Meter Connection is OK!.......... ", Color.Green);
                            CurrentMetertextBox.Text = equitment[i];
                            CurrentMetertextBox.BackColor = Color.GreenYellow;
                            CurrentMeter = equitment[i];
                            Current_flag = 1;
                        }
                    }

                }
                XM_EquipVisa.VisaClose();
            }

            ////Check XMBridge FPGA
            uint Reg = 0;
            XM_Dev_Util deviceUtil = new XM_Dev_Util();

            if (deviceUtil.GetUSBDevs() > 0)
            {
                List<XM_Dev_Util.XMDevInfo> UsbDevice = deviceUtil.FindXMDev();
                XM_Dev_Util.XMDevInfo[] UsbDeviceInfo = UsbDevice.ToArray(); ;
                XM_ExeWol_Util WhiskeyUtil = new XM_ExeWol_Util();
                if (UsbDevice.Count == 1) Temp = UsbDeviceInfo[0].DevID.Substring(0, 2);

                XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x00, ref Reg, 3);   //0x161129
                if (Reg != 0 && Temp == XMBridgeName)
                {

                    InvokerResultRichText("XM Bridge Connection is OK!..........", Color.Green);
                    MIPISystemtextBox.Text = "XM Bridge Connected";
                    MIPISystemtextBox.BackColor = Color.GreenYellow;
                    MIPI_flag = 1;
                }
            }

            //Check File
            //string FilePath = string.Concat(Setting.ExeLogDirPath, "\\", DateTime.Today.ToString("yyyyMMdd"), "_", "Cut1.0_Item 1_1_Power.xls");
            //if (!FileUtil.FileExist(FilePath))
            //{
            //    InvokerResultRichText("XM_Tek_Studio_Pro.Resources.Cut1.0_Item 1_1_Power.xls is Exist!" , Color.Black);
            //    FileUtil.OutputDll(FilePath, "XM_Tek_Studio_Pro.Resources.Cut1.0_Item 1_1_Power.xls");
            //   // FilePathBox.BackColor = Color.GreenYellow;
            //}
            //else
            //    lbl_FileStatus.Text = "File Exists";

            // FilePathBox.Text = FilePath;


            if (MIPI_flag == 0) { MIPISystemtextBox.BackColor = Color.LightGray; InvokerResultRichText("XM Bridge Connection is Fail!..........", Color.Red); }
            if (Voltage_flag == 0) { VoltageMetertextBox.BackColor = Color.LightGray; InvokerResultRichText(" Voltage Meter Connection is Fail!.......... ", Color.Red); }
            if (Current_flag == 0) { CurrentMetertextBox.BackColor = Color.LightGray; InvokerResultRichText(" Current Meter Connection is Fail!.......... ", Color.Red); }
            if (Power_flag == 0) { PowerSupply1textBox.BackColor = Color.LightGray; InvokerResultRichText(" Power supply Connection is Fail!.......... ", Color.Red); }
            if (MIPI_flag == 1 && Voltage_flag == 1 && Current_flag == 1 && Power_flag == 1) CheckFlag = 1;
            return CheckFlag;
        }

        private void CheckInstrumentbutton_Click(object sender, EventArgs e)
        {
            CheckInstrument();
        }



        private bool CheckSumStatus(string Cmd)
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

        private bool ComparekeepRun(double a, double b)
        {
            bool KeepGo = true;

            if (Math.Abs(a - b) < 0.5)
            { KeepGo = false; }
            return KeepGo;
        }

        private void COM_KeyIn(string command)  //important #2
        {
            ////only for test  //20170621
            //string date = DateTime.Today.ToString("yyyyMMdd");
            //string dateNow = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            //string DirPath = @"D:\SU241\";
            //string FilePath = @"D:\SU241\" + date + ".txt";
            //FilePathBox.Text = FilePath;
            //Application.DoEvents();
            ////only for test

            //Comport.WriteLine(command);
            //byte[] commEnter = new byte[] { 0x0D, 0x0A };
            //for (int i = 0; i < 2; i++)
            //{
            //    Comport.Write(commEnter, i, 1);
            //}

            //Thread.Sleep(600);
            //ShowBox1.Text = Comport.ReadExisting();

            ////only for test  //20170621
            //if (!System.IO.Directory.Exists(DirPath))
            //    System.IO.Directory.CreateDirectory(DirPath);
            //// This text is added only once to the file.
            //if (!File.Exists(FilePath))
            //{
            //    // Create a file to write to.
            //    string createText = "Hello and Welcome" + Environment.NewLine;
            //    File.WriteAllText(FilePath, createText);
            //}

            //// This text is always added, making the file longer over time
            //// if it is not deleted.
            //File.AppendAllText(FilePath, dateNow + "  " + ShowBox1.Text + Environment.NewLine);
            ////only for test

        }

        private void CONSTANT_RUN_Click(object sender, EventArgs e)
        {
            COM_KeyIn("1, MODE, CONSTANT");
        }

        private void Condition_Click(object sender, EventArgs e)
        {
            COM_KeyIn("1, MON?");
        }

        public bool CurrentMeaDevice(ref XM_ExeWol_Util MipiUtil, ref XM_EquipVisa_Util CurrMeter, ref double[] Current)
        {
            string Temp = "", rdStrTemp = "";
            // if test is error, then repeat times.
            int TestNum = 3;

            Byte[,] GPIO_Reg = new Byte[4, 3] { { 0x0F, 0x1F, 0x1E }, { 0x0F, 0x2F, 0x2D }, { 0x0F, 0x4F, 0x4B }, { 0x0F, 0x8F, 0x87 } };
            string tmep_gpio1 = "", tmep_gpio2 = "", tmep_gpio3 = "";

            MipiUtil.FpgaRead(0xfa, 1, ref tmep_gpio1);
            MipiUtil.FpgaRead(0xfb, 1, ref tmep_gpio2);
            MipiUtil.FpgaRead(0xfc, 1, ref tmep_gpio3);

            for (int i = 0; i < TestNum; i++)
            {
                CurrMeter.VisaSendandRead("CONFigure?", out rdStrTemp);
                if (string.IsNullOrEmpty(rdStrTemp))
                {
                    Thread.Sleep(100);//originalL1000
                    ShowBox1.Text = string.Concat("Current Repeat read ", i.ToString());
                    continue;
                }

                rdStrTemp = rdStrTemp.Substring(1, 5);
                if (string.Compare(rdStrTemp, 0, "CURR", 0, 4) == 0) break;
            }

            Thread.Sleep(100);

            for (int i = 0; i < Current.Length; i++)
            {
                MipiUtil.GpioCtrl(0x11, 0x02, GPIO_Reg[i, 0]);
                Thread.Sleep(200);
                MipiUtil.GpioCtrl(0x11, 0x02, GPIO_Reg[i, 1]);
                Thread.Sleep(200);
                MipiUtil.GpioCtrl(0x11, 0x02, GPIO_Reg[i, 2]);

                Thread.Sleep(1500);//original:2000

                for (int j = 0; j < TestNum; j++)
                {
                    CurrMeter.VisaSendandRead("Read?", out Temp);
                    if (string.IsNullOrEmpty(Temp) || string.Compare(Temp, "Device,Read Err,Connection,Fail") == 0)
                    {
                        ShowBox1.Text = string.Concat("Current Repeat Read ", i.ToString());
                        Application.DoEvents();
                        continue;
                    }
                    else
                        break;
                }

                if (Double.TryParse(Temp, out double n))
                    Current[i] = n * 1000;

                MipiUtil.GpioCtrl(0x11, 0x02, GPIO_Reg[i, 1]);
                Thread.Sleep(200);
                MipiUtil.GpioCtrl(0x11, 0x02, GPIO_Reg[i, 0]);
                Thread.Sleep(200);

                byte[] tempgoip = new byte[1];
                tempgoip[0] = Convert.ToByte(tmep_gpio1, 16);
                MipiUtil.FpgaWrite(0xfa, tempgoip);
                tempgoip[0] = Convert.ToByte(tmep_gpio2, 16);
                MipiUtil.FpgaWrite(0xfb, tempgoip);
                tempgoip[0] = Convert.ToByte(tmep_gpio3, 16);
                MipiUtil.FpgaWrite(0xfc, tempgoip);
            }
            return true;
        }

        public bool CurrentMeaDeviceAddress(ref XM_ExeWol_Util WhiskeyUtil, ref double[] Current, XM_EquipVisa_Util SlEqutVddio, XM_EquipVisa_Util SlEqutAvdd, XM_EquipVisa_Util SlEqutAvee)
        {

            string Temp = "";
            SlEqutVddio.VisaSendandRead("CONFigure?", out string rdStrTemp);
            if (rdStrTemp == "")
            {
                Thread.Sleep(2000);
                //   SlEqut.SimpleSendRead(MeterAddress, "CONFigure?", ref rdStrTemp);
                SlEqutVddio.VisaSendandRead("CONFigure?", out rdStrTemp);
                ShowBox1.Text = "Current Repeat read";
            }
            if (rdStrTemp == "")
            {
                Thread.Sleep(2000);
                //   SlEqut.SimpleSendRead(MeterAddress, "CONFigure?", ref rdStrTemp);
                SlEqutVddio.VisaSendandRead("CONFigure?", out rdStrTemp);
                ShowBox1.Text = "Current Repeat read 1";
            }
            rdStrTemp = rdStrTemp.Substring(1, 5);
            if (string.Compare(rdStrTemp, 0, "CURR", 0, 4) != 0)
            {
                SlEqutVddio.VisaSend("CONFigure:CURRent:DC AUTO,DEFault");
            }

            SlEqutAvdd.VisaSendandRead("CONFigure?", out rdStrTemp);
            if (rdStrTemp == "")
            {
                Thread.Sleep(2000);
                //   SlEqut.SimpleSendRead(MeterAddress, "CONFigure?", ref rdStrTemp);
                SlEqutAvdd.VisaSendandRead("CONFigure?", out rdStrTemp);
                ShowBox1.Text = "Current Repeat read";
            }
            if (rdStrTemp == "")
            {
                Thread.Sleep(2000);
                //   SlEqut.SimpleSendRead(MeterAddress, "CONFigure?", ref rdStrTemp);
                SlEqutAvdd.VisaSendandRead("CONFigure?", out rdStrTemp);
                ShowBox1.Text = "Current Repeat read 1";
            }
            rdStrTemp = rdStrTemp.Substring(1, 5);
            if (string.Compare(rdStrTemp, 0, "CURR", 0, 4) != 0)
            {
                SlEqutAvdd.VisaSend("CONFigure:CURRent:DC AUTO,DEFault");
            }


            SlEqutAvee.VisaSendandRead("CONFigure?", out rdStrTemp);
            if (rdStrTemp == "")
            {
                Thread.Sleep(2000);
                //   SlEqut.SimpleSendRead(MeterAddress, "CONFigure?", ref rdStrTemp);
                SlEqutAvee.VisaSendandRead("CONFigure?", out rdStrTemp);
                ShowBox1.Text = "Current Repeat read";
            }
            if (rdStrTemp == "")
            {
                Thread.Sleep(2000);
                //   SlEqut.SimpleSendRead(MeterAddress, "CONFigure?", ref rdStrTemp);
                SlEqutAvee.VisaSendandRead("CONFigure?", out rdStrTemp);
                ShowBox1.Text = "Current Repeat read 1";
            }
            rdStrTemp = rdStrTemp.Substring(1, 5);
            if (string.Compare(rdStrTemp, 0, "CURR", 0, 4) != 0)
            {
                SlEqutAvee.VisaSend("CONFigure:CURRent:DC AUTO,DEFault");
            }




            for (int i = 0; i < 3; i++)
            {

                switch (i)
                {
                    case 0:
                        SlEqutVddio.VisaSendandRead("Read?", out Temp);
                        break;
                    case 1:
                        SlEqutAvdd.VisaSendandRead("Read?", out Temp);
                        break;
                    case 2:
                        SlEqutAvee.VisaSendandRead("Read?", out Temp);
                        break;
                    default:
                        break;
                }


                if (Temp == "")
                {
                    Thread.Sleep(2000);

                    switch (i)
                    {
                        case 0:
                            SlEqutVddio.VisaSendandRead("Read?", out Temp);
                            break;
                        case 1:
                            SlEqutAvdd.VisaSendandRead("Read?", out Temp);
                            break;
                        case 2:
                            SlEqutAvee.VisaSendandRead("Read?", out Temp);
                            break;
                        default:
                            break;
                    }
                    ShowBox1.Text = "Current Repeat read A";
                }

                if (!Double.TryParse(Temp, out double n))
                {
                    Thread.Sleep(2000);

                    switch (i)
                    {
                        case 0:
                            SlEqutVddio.VisaSendandRead("Read?", out Temp);
                            break;
                        case 1:
                            SlEqutAvdd.VisaSendandRead("Read?", out Temp);
                            break;
                        case 2:
                            SlEqutAvee.VisaSendandRead("Read?", out Temp);
                            break;
                        default:
                            break;
                    }
                    ShowBox1.Text = "Current Repeat read B";
                }



                Current[i] = Convert.ToDouble(Temp);




            }

            return true;
        }

        private void Excel_sheet3_Click(object sender, EventArgs e)  //Item 1_1_Power Excel sheet 3
        {
            string date = DateTime.Today.ToString("yyyyMMdd");
            //string pathFile = @"D:\XXXX_Cut1.0_Item 1_1_Power.xls";
            string filePath = string.Empty;
            int[] StartPointSet = new int[2] { 9, 12 };  // StartPoint[1] = vertical, StartPoint[0] = horizontal
            int[] StartPoint = StartPointSet;  // StartPoint[1] = vertical, StartPoint[0] = horizontal
            int t = 0;
            //int TEMP = 25;

            // Table form{ Temperature(C), VDDIO(V), VSP(V), VSN(V), measurement mode}
            // measurement mode=  0: No measure, 1: Module measure VDDIO(A), VSP(A), VSN(A), 
            //                    2: DDI COB measure VDDIO(A), VSP(A), VSN(A), VCL, GVDDP, GVDDN,
            //                                       VCOM, VGH, VGHO2, VGL, VGLO2, VDD, LVDSVDD,
            //                    3:TDDI COB measure VDDIO(A), VSP(A), VSN(A), VCL, GVDDP, GVDDN,
            //                                       VCOM, VGH, VGHO2, VGL, VGLO2, VDD, LVDSVDD, VREF_TP, VDDS
            double[,] Table_COB = new double[7, 5] {  { -30, 1.8, 5.4, -5.4, 2 },
                                                   { -30, 1.8, 6.5, -6.5, 2 },
                                                   {  25, 1.8, 5.4, -5.4, 2 },
                                                   {  25, 1.8, 6.5, -6.5, 2 },
                                                   {  85, 1.8, 5.4, -5.4, 2 },
                                                   {  85, 1.8, 6.5, -6.5, 2 },
                                                   {  25,   0,   0,    0, 0 },
                                                };

            double[,] Table_Module = new double[3, 5] {
                                                   {  25, 1.8, 5.4, -5.4, 1 },
                                                   {  25, 1.8, 6.5, -6.5, 1 },
                                                   {  25,   0,   0,    0, 0 },
                                                };

            //Check File Path
            if (File.Exists(filePath) == false)
            {

                //Excel.Application excelApp;
                //Excel._Workbook wBook;
                //Excel._Worksheet wSheet;
                //Excel.Range wRange;

                // 開啟一個新的應用程式
                Excel.Application excelApp = new Excel.Application
                {

                    // 讓Excel文件可見
                    Visible = true,

                    // 停用警告訊息
                    DisplayAlerts = false
                };

                // filePath = @"D:\XXXX_Cut1.0_Item 1_1_Power.xls";
                excelApp.Workbooks.Open(@"D:\XXXX_Cut1.0_Item 1_1_Power.xls");
                // 引用第一個活頁簿
                Excel._Workbook wBook = excelApp.Workbooks[1];
                //wBook = excelApp.Workbooks[3];

                // 設定活頁簿焦點
                //wBook.Activate();
                filePath = @"D:\" + date + "_SSL2130_Cut1.0_Item 1_1_Power.xls";
                wBook.SaveAs(filePath);
                //關閉活頁簿
                wBook.Close(false, Type.Missing, Type.Missing);

                //關閉Excel
                excelApp.Quit();

                //釋放Excel資源
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                wBook = null;
                //wSheet = null;
                //wRange = null;
                excelApp = null;
                GC.Collect();

            }


            for (t = 0; t <= 6; t++)  //for COB measurement
            {
                //A. Enviroment Adjust 

                //mask for test  
#if false
                //SU241
                TEMP = Convert.ToInt32(Table_COB[t, 0]) ;
                if (SETTING_TEMP(TEMP) != 0)  //return Error Code
                {
                    return; //cancel measurement
                }
#endif
                //mask for test
                //Power supply


                //IC setting

                //for
                {
                    Mea_and_Sav(StartPoint, Convert.ToInt32(Table_COB[t, 4]), filePath);
                }

                // for next table start point
                StartPoint[0] = StartPointSet[0] + 19;
                StartPoint[1] = StartPointSet[1] - 1;
            }

        }

        private bool ExeTemperCmd(string ItmeName)
        {
            bool Result = true;
            for (int j = 0; j < 128; j++)
            {
                if (ItmeName.CompareTo(XM_Comm_Temperature.TemperCmdList[j].ItemName) == 0)
                {
                    Result = SendScript(XM_Comm_Temperature.TemperCmdList[j].CmdList.ToArray());
                }
            }
            return Result;
        }

        private bool ExeTemperCmd(string ItmeName, int ItemContentIndex)
        {
            bool Result = true;
            for (int j = 0; j < 128; j++)
            {
                if (ItmeName.CompareTo(XM_Comm_Temperature.TemperCmdList[j].ItemName) == 0)
                {
                    Result = SendScript(XM_Comm_Temperature.TemperCmdList[j].CmdList.ToArray(), ItemContentIndex);
                    break;
                }
            }
            return Result;
        }

        private bool ExeTemperCmdContent(string ItmeName, ref int ContentIndex)
        {
            bool Result = true;
            //int Image_Num = 0;
            for (int j = 0; j < 128; j++)
            {
                if (ItmeName.CompareTo(XM_Comm_Temperature.TemperCmdList[j].ItemName) == 0)
                {
                    //Result = SendScript(TemperCmdList[j].CmdList.ToArray(), ImageIndex);
                    ContentIndex = j;
                    //Image_Num = j;
                    break;
                }
            }

            return Result;
        }

        private bool ExeTemperCmdNum(string ItmeName, ref int ContentIndex)
        {
            bool Result = true;
            //int Image_Num = 0;
            for (int j = 0; j < 128; j++)
            {
                if (ItmeName.CompareTo(XM_Comm_Temperature.TemperCmdList[j].ItemName) == 0)
                {
                    //Result = SendScript(TemperCmdList[j].CmdList.ToArray(), ImageIndex);
                    ContentIndex = XM_Comm_Temperature.TemperCmdList[j].CmdList.Count;
                    //Image_Num = j;
                    break;
                }
            }

            return Result;
        }

        private bool ExeTemperSetNum(string ItmeName, ref int SetIndex, int type)
        {
            bool Result = true;
            SetIndex = 0;
            string tempstring = ItmeName;

            switch (type)
            {
                case 0:
                    for (int i = 1; i <= 128; i++)
                    {
                        for (int j = 0; j < 128; j++)
                        {
                            if ((ItmeName + i.ToString()).CompareTo(XM_Comm_Temperature.TemperCmdList[j].ItemName) == 0)
                            {
                                SetIndex++;
                            }
                        }
                    }
                    break;
                case 1:
                    for (int j = 0; j < 128; j++)
                    {
                        if ((ItmeName).CompareTo(XM_Comm_Temperature.TemperCmdList[j].ItemName) == 0)
                        {
                            SetIndex++;
                        }
                    }
                    break;
                default:
                    break;
            }



            return Result;
        }

        public bool Excel_Data_Save(double[] Data, Excel.Application excelApp, int sheet, ref int[] StartPoint, int RecordType)
        {
            // StartPoint[0] = horizontal direction, locate[1]= vertical direction
            // RecordType = 1 is horizontal direction, 2 is vertical direction


            //private void Mea_and_Sav(int[] StartPoint, int type, string FilePath)
            int i = 0;

            //double[] meaValue = new double[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            //meaValue sequence: VDDIO(A), VSP(A), VSN(A), VCL, GVDDP, GVDDN,
            //                   VCOM, VGH, VGHO2, VGL, VGLO2, VDD, LVDSVDD, VREF_TP, VDDS

            //Relay control & Meter Measure

            //Relay control & Meter Measure

            Thread.Sleep(600);  //mask for test

            //Excel setting
            //Excel.Application excelApp;
            Excel._Workbook wBook;
            Excel._Worksheet wSheet;
            //Excel.Range wRange;


            // 引用第一個活頁簿
            wBook = excelApp.Workbooks[1];
            //wBook = excelApp.Workbooks[3];
            //wBook = excelApp.Workbooks[sheet];

            // 設定活頁簿焦點
            wBook.Activate();

            try
            {

                // 引用第一個工作表
                //   wSheet = (Excel._Worksheet)wBook.Worksheets[1];
                //wSheet = (Excel._Worksheet)wBook.Worksheets[3];
                wSheet = (Excel._Worksheet)wBook.Worksheets[sheet];
                //wSheet = (Excel._Worksheet)wBook.Worksheets[6];
                // 命名工作表的名稱
                //   wSheet.Name = "工作表測試";

                // 設定工作表焦點
                wSheet.Activate();

                //Thread.Sleep(600);  //mask for test
                if (RecordType == 1)  //for horizontal direction record
                {
                    for (i = 0; i < Data.Length; i++)
                    {
                        excelApp.Cells[StartPoint[1], StartPoint[0]] = Data[i];
                        StartPoint[0]++;
                    }

                }

                else if (RecordType == 2)  // for vertical direction record
                {
                    for (i = 0; i < Data.Length; i++)
                    {
                        excelApp.Cells[StartPoint[1], StartPoint[0]] = Data[i];
                        StartPoint[1]++;
                    }

                }

                try
                {


                    wBook.Save();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("儲存檔案出錯，檔案可能正在使用" + Environment.NewLine + ex.Message);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("產生報表時出錯！" + Environment.NewLine + ex.Message);
            }



            return true;
        }

        public bool Excel_Open(Excel.Application excelApp, string FilePath)
        {
            //Excel.Application excelApp;

            Excel._Workbook wBook;
            //Excel._Worksheet wSheet;
            //Excel.Range wRange;

            // 開啟一個新的應用程式
            //excelApp = new Excel.Application();

            // 讓Excel文件可見
            excelApp.Visible = true;

            // 停用警告訊息
            excelApp.DisplayAlerts = false;

            // filePath = @"D:\XXXX_Cut1.0_Item 1_1_Power.xls";
            excelApp.Workbooks.Open(FilePath);
            Thread.Sleep(500);
            // 引用第一個活頁簿
            wBook = excelApp.Workbooks[1];
            Thread.Sleep(500);

            return true;
        }

        public bool Excel_Close(Excel.Application excelApp)
        {
            //關閉活頁簿
            //wBook.Close(false, Type.Missing, Type.Missing);

            //關閉Excel
            excelApp.Quit();

            //釋放Excel資源
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            //wBook = null;
            //wSheet = null;
            //wRange = null;
            excelApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();  //only for test
            Thread.Sleep(500);  //mask for test
            return true;
        }

        //public bool Enter_Initial_Code(ref XM_ExeWol_Util XmPlusUtil)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        byte[] display_status = new byte[1];
        //        bool ret = XmPlusUtil.MipiRead(0x0a, 1, ref display_status);
        //        if (display_status[0] == 0x9c)
        //        {
        //            return true;
        //        }
        //        else {
        //            // XmPlusUtil.GpioCtrl(0x11, 0x00, 0x0f);
        //            // Thread.Sleep(200);
        //            // ResetWhisktyTiming(ref XmPlusUtil);
        //            // SetXmBridgeTiming(ref XmPlusUtil);
        //            // Thread.Sleep(100);
        //            // XmPlusUtil.ResetCtrl(1, true);
        //            // Thread.Sleep(100);
        //            // Initinal_code(ref XmPlusUtil,0);


        //            //Thread.Sleep(200);
        //            ResetWhisktyTiming(ref XmPlusUtil);
        //            SetXmBridgeTiming(ref XmPlusUtil);
        //            Thread.Sleep(500);
        //            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x00);
        //            Thread.Sleep(100);
        //            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x01);
        //            Thread.Sleep(100);
        //            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x03);
        //            Thread.Sleep(100);
        //            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x07);
        //            Thread.Sleep(100);
        //            XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x0f);
        //            Thread.Sleep(200);
        //            XmPlusUtil.ResetCtrl(0, true);
        //            Thread.Sleep(200);
        //            //Initinal_code(ref XmPlusUtil, 0);
        //            ExeTemperCmd(XM_TEMPER_INITIAL_CODE);
        //            Thread.Sleep(200);
        //        }
        //    }
        //    return false;

        //}

        //public bool Enter_Initial_Code_Inversion(ref XM_ExeWol_Util XmPlusUtil,int Inversion_Index)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        byte[] display_status = new byte[1];
        //        bool ret = XmPlusUtil.MipiRead(0x0a, 1, ref display_status);
        //        if (display_status[0] == 0x9c)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            XmPlusUtil.GpioCtrl(0x11, 0x00, 0x00);
        //            Thread.Sleep(200);
        //            ResetWhisktyTiming(ref XmPlusUtil);
        //            SetXmBridgeTiming(ref XmPlusUtil);
        //            Thread.Sleep(500);
        //            XmPlusUtil.GpioCtrl(0x11, 0x00, 0x01);
        //            Thread.Sleep(100);
        //            XmPlusUtil.GpioCtrl(0x11, 0x00, 0x03);
        //            Thread.Sleep(100);
        //            XmPlusUtil.GpioCtrl(0x11, 0x00, 0x07);
        //            Thread.Sleep(100);
        //            XmPlusUtil.GpioCtrl(0x11, 0x00, 0x0f);
        //            Thread.Sleep(100);
        //            XmPlusUtil.ResetCtrl(0, true);
        //            Thread.Sleep(200);
        //            //Initinal_code(ref XmPlusUtil, 0);
        //            ExeTemperCmd(XM_TEMPER_INITIAL_CODE);
        //            Thread.Sleep(500);
        //            IC_Inversion(ref XmPlusUtil, Inversion_Index);
        //            Thread.Sleep(500);
        //        }
        //    }
        //    return false;

        //}

        public bool IC_PowerAndReset_Ctrl(ref XM_ExeWol_Util XmPlusUtil, ref XM_EquipVisa_Util PowerSupply, double[,] SinglePwr, int step)
        {
            bool StepFlag = false;
            double[,] SetPwr = new double[4, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            Array.Copy(SinglePwr, SetPwr, SinglePwr.Length);
            switch (step)
            {
                case 1:
                    {

                        ////XmPlusUtil.ResetCtrl(0, false);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x91);
                        ////Power Ctrl
                        ////XmPlusUtil.GpioCtrl(0x11, 0x00, 0x02);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfa, 0x11);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, 0x00);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x02);
                        //// PowerSupplyON(ref PowerSupply, SetPwr);
                        //// XmPlusUtil.BackLight_0_Ctrl(true, false);
                        //Thread.Sleep(2000);
                        ExeTemperCmd(XM_TEMPER_CMDSET1);
                        StepFlag = true;
                        break;
                    }
                case 2:
                    {

                        ////XmPlusUtil.ResetCtrl(0, false);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x91);
                        ////Power Ctrl
                        ////XmPlusUtil.GpioCtrl(0x11, 0x00, 0x01);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfa, 0x11);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, 0x00);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x01);
                        //// PowerSupplyON(ref PowerSupply, SetPwr);
                        //// XmPlusUtil.BackLight_0_Ctrl(true, false);
                        //Thread.Sleep(2000);
                        ExeTemperCmd(XM_TEMPER_CMDSET2);
                        StepFlag = true;
                        break;
                    }
                case 3:
                    {

                        //// XmPlusUtil.ResetCtrl(0, false);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x91);
                        ////Power Ctrl
                        ////XmPlusUtil.GpioCtrl(0x11, 0x00, 0x03);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfa, 0x11);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, 0x00);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x03);
                        ////PowerSupplyON(ref PowerSupply, SetPwr);
                        ////XmPlusUtil.BackLight_0_Ctrl(true, false);
                        //Thread.Sleep(2000);
                        ExeTemperCmd(XM_TEMPER_CMDSET3);
                        StepFlag = true;
                        break;
                    }
                case 4:
                    {

                        ////XmPlusUtil.ResetCtrl(0, false);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x91);
                        ////Power Ctrl
                        ////XmPlusUtil.GpioCtrl(0x11, 0x00, 0x07);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfa, 0x11);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, 0x00);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x07);
                        ////PowerSupplyON(ref PowerSupply, SetPwr);
                        ////XmPlusUtil.BackLight_0_Ctrl(true, false);
                        //Thread.Sleep(2000);
                        ExeTemperCmd(XM_TEMPER_CMDSET4);
                        StepFlag = true;
                        break;
                    }
                case 5:
                    {
                        ////Power Ctrl
                        //XmPlusUtil.GpioCtrl(0x11, 0x00, 0x07);
                        //Thread.Sleep(2000);
                        //// XmPlusUtil.BackLight_0_Ctrl(true, false);
                        ////RESET=high->low->high
                        ////XmPlusUtil.ResetCtrl(0, true);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00);
                        //Thread.Sleep(30);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x90);
                        //Thread.Sleep(15);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9e, 0x00);
                        ExeTemperCmd(XM_TEMPER_CMDSET5);
                        StepFlag = true;
                        break;
                    }

                default:
                    {
                        StepFlag = false;
                        break;
                    }

            }
            return StepFlag;
        }

        public bool IC_Status(ref XM_ExeWol_Util XmPlusUtil, int step)
        {
            bool StepFlag = false;
            switch (step)
            {
                case 1:
                    {
                        //XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xB7, 0x03, 0x04); //Ultra Low power
                        ExeTemperCmd(XM_TEMPER_CMDSET6);
                        StepFlag = true;
                        break;
                    }

                case 2:
                    {
                        //Deep standby
                        //XM_Comm_Control.XM_Comm_Base.Bridge_WriteReg(0xB7, 0x03, 0x00);
                        //XmPlusUtil.MipiWrite(0x05, 0x28);
                        //Thread.Sleep(120);
                        //XmPlusUtil.MipiWrite(0x05, 0x10);
                        //Thread.Sleep(100);
                        //XmPlusUtil.MipiWrite(0x23, 0x00, 0x80);
                        //XmPlusUtil.MipiWrite(0x23, 0xf7, 0x01);
                        //Thread.Sleep(100);
                        ExeTemperCmd(XM_TEMPER_CMDSET7);
                        StepFlag = true;
                        break;
                    }

                case 3:
                    {
                        //Exit Deep standby and go into Sleep In
                        //RESET=high->low->high
                        //XmPlusUtil.ResetCtrl(0, true);
                        ExeTemperCmd(XM_TEMPER_CMDSET8);
                        StepFlag = true;
                        break;
                    }

                case 4:
                    {
                        //Sleep out & Display off
                        //Initinal_code(ref XmPlusUtil, 0);

                        //  bool Result = Enter_Initial_Code(ref XmPlusUtil);
                        //Thread.Sleep(120);
                        //XmPlusUtil.MipiWrite(0x05, 0x11);
                        //Thread.Sleep(120);
                        //XmPlusUtil.MipiWrite(0x05, 0x10);
                        //Thread.Sleep(120);
                        //XmPlusUtil.MipiWrite(0x05, 0x11);
                        //Thread.Sleep(120);
                        //XmPlusUtil.MipiWrite(0x05, 0x28);
                        //Thread.Sleep(100);
                        ExeTemperCmd(XM_TEMPER_CMDSET9);

                        //ExeTemperCmd(XM_TEMPER_SLEEP_OUT);
                        //ExeTemperCmd(XM_TEMPER_DISPLAY_OFF);
                        StepFlag = true;
                        break;
                    }

                case 5:
                    {
                        StepFlag = true;
                        break;
                    }

                default:
                    {
                        break;
                    }

            }
            return StepFlag;

        }

        private void ItemPowerbutton_Click(object sender, EventArgs e)
        {
            InvokerResultRichText("", Color.Black);
            if (ItemPowerbutton.Text == "Item1.1 Power test RUN")
            {

                if (comboBox_Envior_type.Text == "COB")
                {
                    Measure_Voltage_Number = int.Parse(comboBox_COB_Vol.Text);
                    Measure_Current_Number = int.Parse(comboBox_COB_Cur.Text);
                }
                else if (comboBox_Envior_type.Text == "Panel")
                {
                    Measure_Voltage_Number = int.Parse(comboBox_Panel_Vol.Text);
                    Measure_Current_Number = int.Parse(comboBox_Panel_Cur.Text);
                }

                Sample_Index = SampletextBox.Text;
                Envior_type = comboBox_Envior_type.Text;

                try
                {

                    InitalTempeture_Item();
                    SetTextValue(Item1_PowerTest_TxtPath);
                    InvokeText("STOP", Color.Black, 1);
                    startDate = DateTime.Now;
                    Start_Timer();
                    XmThead = new Thread(new ParameterizedThreadStart(TempertureTest))
                    {
                        IsBackground = true
                    };

                    XmThead.Start(XmComm);
                }
                catch (Exception ex)
                {

                    InvokeText("Item1.1 Power test RUN", Color.Black, 1);
                    Stop_Timer();
                    throw ex;
                }
            }
            else
            { if (XmThead != null && XmThead.IsAlive) { XmThead.Abort(); InvokeText("Item1.1 Power test RUN", Color.Black, 1); Stop_Timer(); } }
        }

        private void Loadpoweronoffbutton_Click(object sender, EventArgs e)
        {
            string line; int Count = 0;
            try
            {
                XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSysIniPath);
                string FilePath = IniUtil.IniReadValue("System", "ScriptDir");
                FilePath = (FilePath == "NULL") ? Setting.ExeSptDirPath : FilePath;
                InvokerResultRichText("", Color.Blue);
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "*.txt|*.*",
                    FileName = "default.txt",
                    InitialDirectory = FilePath,
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    Setting.ExeWolConfigPath = Item1_PoweronoffTxtPath = openFileDialog.FileName;
                    XM_Ini_Util iniUtil = new XM_Ini_Util(Item1_PoweronoffTxtPath);
                    InvokerResultRichText("\r\n\r\n" + Item1_PoweronoffTxtPath, Color.Black);
                    PowerOnOffbutton.Enabled = true;

                    IniUtil.IniWriteValue("System", "ScriptDir", Path.GetDirectoryName(openFileDialog.FileName));
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName, Encoding.Default))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            InvokerResultRichText((++Count).ToString() + ": " + line, Color.Blue);
                        }
                    }
                    InvokerResultRichText("\r\nPower On Off Test : Load File is OK! ", Color.Green);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void InvokeText(String Context, object Color, int ChoiceText)
        {
            MyMarshalToForm((int)MSG.MSG_TEMPERTEXT, Context, Color, ChoiceText);
        }

        private void InvokeTextBox(String Context, object Color)
        {
            MyMarshalToForm((int)MSG.TEXTBOX, Context, Color);
        }

        private void InvokeTimeText(String Context, object Color)
        {
            MyMarshalToForm((int)MSG.MSG_TIMETEXT, Context, Color);
        }

        private void InvokeOnOffTimeText(String Context, object Color)
        {
            MyMarshalToForm((int)MSG.MSG_ONOFFTIMETEXT, Context, Color);
        }

        private void InvokerResultRichText(String Context, object Color)
        {
            MyMarshalToForm((int)MSG.MSG_RESULT, Context, Color);
        }

        private void Instrument_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmComm_TemperClose(XmComm);
        }

        private void LoadInitialCodebutton_Click(object sender, EventArgs e)
        {
            try
            {
                string line; int Count = 0;
                XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSysIniPath);
                string FilePath = IniUtil.IniReadValue("System", "ScriptDir");
                InvokerResultRichText("", Color.Blue);
                FilePath = (FilePath == "NULL") ? Setting.ExeSptDirPath : FilePath;

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "*.txt|*.*",
                    FileName = "default.txt",
                    InitialDirectory = FilePath,
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Setting.ExeWolConfigPath = Item1_PowerTest_TxtPath = openFileDialog.FileName;
                    XM_Ini_Util iniUtil = new XM_Ini_Util(Item1_PowerTest_TxtPath);
                    InvokerResultRichText("\r\n" + Item1_PowerTest_TxtPath, Color.Black);
                    ItemPowerbutton.Enabled = true;

                    IniUtil.IniWriteValue("System", "ScriptDir", Path.GetDirectoryName(openFileDialog.FileName));
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName, Encoding.Default))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            InvokerResultRichText((++Count).ToString() + ": " + line, Color.Blue);
                        }
                    }
                    InvokerResultRichText("\r\nPower Test : Load File is OK! ", Color.Green);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Mea_and_Sav(int[] StartPoint, int type, string FilePath)
        {
            int i = 0;

            double[] meaValue = new double[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            //meaValue sequence: VDDIO(A), VSP(A), VSN(A), VCL, GVDDP, GVDDN,
            //                   VCOM, VGH, VGHO2, VGL, VGLO2, VDD, LVDSVDD, VREF_TP, VDDS

            //Relay control & Meter Measure

            //Relay control & Meter Measure


            //Excel setting
            Excel._Workbook wBook;
            Excel._Worksheet wSheet;
            // Excel.Range wRange;

            // 開啟一個新的應用程式
            Excel.Application excelApp = new Excel.Application
            {

                // 讓Excel文件可見
                Visible = true,

                // 停用警告訊息
                DisplayAlerts = false
            };

            // 加入新的活頁簿
            //excelApp.Workbooks.Add(Type.Missing);
            //excelApp.Workbooks.Open(@"D:\XXXX_Cut1.0_Item 1_1_Power.xls");

            excelApp.Workbooks.Open(FilePath);

            // 引用第一個活頁簿
            wBook = excelApp.Workbooks[1];
            //wBook = excelApp.Workbooks[3];

            // 設定活頁簿焦點
            wBook.Activate();

            try
            {
                // 引用第一個工作表
                //   wSheet = (Excel._Worksheet)wBook.Worksheets[1];
                wSheet = (Excel._Worksheet)wBook.Worksheets[3];
                //wSheet = (Excel._Worksheet)wBook.Worksheets[6];
                // 命名工作表的名稱
                //   wSheet.Name = "工作表測試";

                // 設定工作表焦點
                wSheet.Activate();
                Thread.Sleep(600);
                if (type == 2)
                {
                    for (i = 0; i < 16; i++)
                    {
                        if (i != 3) // skip Power(mW) cell
                        {
                            excelApp.Cells[StartPoint[1], StartPoint[0]] = meaValue[i];
                        }
                        StartPoint[0]++;
                    }
                    StartPoint[1]++;
                    StartPoint[0] = StartPoint[0] - 16;
                }

                /*
                excelApp.Cells[1, 1] = "Excel測試";

                // 設定第1列資料
                excelApp.Cells[1, 1] = "名稱";
                excelApp.Cells[1, 2] = "數量";
                // 設定第1列顏色
                wRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[1, 2]];
                wRange.Select();
                wRange.Font.Color = ColorTranslator.ToOle(Color.White);
                wRange.Interior.Color = ColorTranslator.ToOle(Color.DimGray);

                // 設定第2列資料
                excelApp.Cells[2, 1] = "AA";
                excelApp.Cells[2, 2] = "10";

                // 設定第3列資料
                excelApp.Cells[3, 1] = "BB";
                excelApp.Cells[3, 2] = "20";

                // 設定第4列資料
                excelApp.Cells[4, 1] = "CC";
                excelApp.Cells[4, 2] = "30";

                // 設定第5列資料
                excelApp.Cells[5, 1] = "總計";
                // 設定總和公式 =SUM(B2:B4)
                excelApp.Cells[5, 2].Formula = string.Format("=SUM(B{0}:B{1})", 2, 4);
                // 設定第5列顏色
                wRange = wSheet.Range[wSheet.Cells[5, 1], wSheet.Cells[5, 2]];
                wRange.Select();
                wRange.Font.Color = ColorTranslator.ToOle(Color.Red);
                wRange.Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                */
                // 自動調整欄寬
                /*
                wRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[5, 2]];
                wRange.Select();
                wRange.Columns.AutoFit();
                */

                try
                {
                    //另存活頁簿
                    // wBook.SaveAs(pathFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    //string NewPathFile = @"D:\NEW_XXXX_Cut1.0_Item 1_1_Power.xls";
                    //wBook.SaveAs(pathFile);
                    //Console.WriteLine("儲存文件於 " + Environment.NewLine + pathFile);
                    //wBook.SaveAs(NewPathFile);
                    //Console.WriteLine("儲存文件於 " + Environment.NewLine + NewPathFile);
                    wBook.SaveAs(FilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("儲存檔案出錯，檔案可能正在使用" + Environment.NewLine + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("產生報表時出錯！" + Environment.NewLine + ex.Message);
            }

            //關閉活頁簿
            wBook.Close(false, Type.Missing, Type.Missing);

            //關閉Excel
            excelApp.Quit();

            //釋放Excel資源
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            wBook = null;
            wSheet = null;
            //wRange = null;
            excelApp = null;
            GC.Collect();


        }

        private void POWER_ON_Click(object sender, EventArgs e)
        {
            COM_KeyIn("1, POWER, ON");
        }

        private void PowerONOFFRestTest(object d)
        {
            SerialPort XmComm_Temper = (SerialPort)d;
            XM_ExeWol_Util XmPlusUtil = new XM_ExeWol_Util();
            XM_EquipVisa_Util CurrMeter = new XM_EquipVisa_Util();
            XM_EquipVisa_Util VolMeter = new XM_EquipVisa_Util();
            XM_IO_Util FileUtil = new XM_IO_Util();

            int ContentIndex = 0, CmdSet_Num = 0, SaveFile_Num = 0, TestNum = 0, i = 0, locate = 0, Cmdset_Index = 0;
            int LoopTime = OnOffTime, Savecmd_Num = 0, PowerSet_Num = 0;


            string Curr_Addr = CurrentMetertextBox.Text;
            string Volt_Addr = VoltageMetertextBox.Text;
            string Temperature_Read = "";
            string date = DateTime.Today.ToString("yyyyMMdd");

            bool KeepGo = true;

            InvokerResultRichText("", Color.Black); InvokeText("STOP", (object)(Color.Blue), 2);
            InvokerResultRichText("Test Data :" + date, Color.Black);

            ExeTemperCmdContent(XM_TEMPER_TEMPERATURESET, ref ContentIndex);
            ExeTemperSetNum(XM_TEMPER_CMDSET, ref CmdSet_Num, 0);
            ExeTemperSetNum(XM_TEMPER_SAVE_FILE, ref SaveFile_Num, 1);
            ExeTemperCmdContent(XM_TEMPER_CMDSET + 1, ref Cmdset_Index);
            ExeTemperSetNum(XM_TEMPER_POWERSET, ref PowerSet_Num, 0);
            //假設一個溫度
            ExeTemperCmdNum(XM_TEMPER_TEMPERATURESET, ref TestNum);
            string[] Save_File = new string[TestNum];

            DateTime startDate = DateTime.Now;

            //Open instrument
            CurrMeter = new XM_EquipVisa_Util(Curr_Addr);
            VolMeter = new XM_EquipVisa_Util(Volt_Addr);

            ExeTemperCmd(XM_TEMPER_INSTRUMENT_SET);
            NewMethod(XmComm_Temper);

            //Setting Enviornment
            for (int TempratureIist = 0; TempratureIist < TestNum; TempratureIist++)
            {
                string SaveFile_Path = string.Concat(Setting.ExeLogDirPath, "\\", "Cut1.0_Item 1_1_PowerOnOff" + "_" + Sample_Index + "_" + Envior_type + "_" + "Temperature" + XM_Comm_Temperature.TemperCmdList[ContentIndex].CmdList[TempratureIist] + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv");

                Save_File[TempratureIist] = SaveFile_Path;
                string line_string = "";

                if (SaveFile_Num != 0)
                    FileUtil.OutputCSV(Save_File[TempratureIist], "\r\n" + "==============" + "POWER SET :" + XM_TEMPER_POWERSET + (TempratureIist + 1) + "\r\n");

                if (checkEanble.Checked)
                {
                    InvokerResultRichText("Set Temperature and waiting until Temperatue is " + XM_Comm_Temperature.TemperCmdList[ContentIndex].CmdList[TempratureIist] + "°C!", Color.Black);
                    // Set Tempeture.
                    SendAndRead(XmComm_Temper, "@001,!,101=" + XM_Comm_Temperature.TemperCmdList[ContentIndex].CmdList[TempratureIist], ref Temperature_Read);
                    do
                    {
                        Thread.Sleep(1000);
                        // 讀出來的溫度需除以100. 
                        if (!SendAndRead(XmComm_Temper, "@001,!,100", ref Temperature_Read))
                            Temperature_Read = "0";
                        KeepGo = ComparekeepRun((double.Parse(Temperature_Read) / 100), (double.Parse(XM_Comm_Temperature.TemperCmdList[ContentIndex].CmdList[TempratureIist])));
                    } while (KeepGo);

                    InvokerResultRichText("Keepping Temperature is" + XM_Comm_Temperature.TemperCmdList[ContentIndex].CmdList[TempratureIist] + "°C " + "about half hour for Enviroment Stable", Color.Black);

                    // 讓待測物可以在30分後(代表固定的溫度一段時間再測試).
                    Thread.Sleep(1800000);
                }

                for (int EnviorIist = 0; EnviorIist < PowerSet_Num; EnviorIist++)
                {
                    ResetWhisktyTiming(ref XmPlusUtil);
                    //ExeTemperCmd(XM_TEMPER_FPGA_SET);

                    Thread.Sleep(1000);

                    ExeTemperCmd(XM_TEMPER_POWERSET + (EnviorIist + 1).ToString());
                    InvokerResultRichText("POWER SET :" + XM_TEMPER_POWERSET + (EnviorIist + 1), Color.Black);

                    if (SaveFile_Num != 0)
                        FileUtil.OutputCSV(Save_File[TempratureIist], "\r\n" + "==============" + "POWER SET :" + XM_TEMPER_POWERSET + (EnviorIist + 1) + "\r\n");

                    //On Off Repeat
                    for (i = 0; i < LoopTime; i++)
                    {
                        ExeTemperCmd(XM_TEMPER_FPGA_SET);
                        InvokeOnOffTimeText(string.Concat("Loop Time:", i.ToString()), Color.Green);

                        Application.DoEvents();
                        Savecmd_Num = 0;

                        // Clear old data
                        if (i == 0)
                        {
                            for (int Rep = 0; Rep < 3; Rep++)
                            {
                                if (Measure_Current_Number != 0)
                                    SaveMeaCur(ref XmPlusUtil, ref CurrMeter, ref line_string, ref locate, Measure_Current_Number);
                                if (Measure_Voltage_Number != 0)
                                    SaveMeaVol(ref XmPlusUtil, ref VolMeter, ref line_string, ref locate, Measure_Voltage_Number);
                                locate = 0;
                                line_string = "";
                            }
                        }

                        for (int j = 1; j <= CmdSet_Num; j++)
                        {
                            InvokeOnOffTimeText(string.Concat("Timer:", i.ToString()), Color.Blue);
                            InvokerResultRichText("CMD SET :" + XM_TEMPER_CMDSET + (j).ToString(), Color.Black);
                            ExeTemperCmd(XM_TEMPER_CMDSET + (j).ToString());

                            if ((XM_TEMPER_SAVE_FILE).CompareTo(XM_Comm_Temperature.TemperCmdList[j + Savecmd_Num + Cmdset_Index].ItemName) == 0)
                            {
                                InvokerResultRichText(XM_TEMPER_SAVE_FILE + " : Measure Data and Ready to Save Data!", Color.Black);

                                if (Measure_Current_Number != 0)
                                    SaveMeaCur(ref XmPlusUtil, ref CurrMeter, ref line_string, ref locate, Measure_Current_Number);
                                if (Measure_Voltage_Number != 0)
                                    SaveMeaVol(ref XmPlusUtil, ref VolMeter, ref line_string, ref locate, Measure_Voltage_Number);

                                Savecmd_Num++;
                            }
                            Thread.Sleep(100);
                            // 取得兩個時間相差幾秒。
                            //ts = DateTime.Now - startDate;
                            //InvokeTimeText(ts.ToString(), Color.LightGreen);
                            //Application.DoEvents();
                        }
                        if (SaveFile_Num != 0)
                        {
                            if (line_string != "")
                            {
                                InvokerResultRichText("MeasureData :" + line_string.Substring(0, line_string.LastIndexOf(',')) + ". mA or V !", Color.Green);

                                line_string += "\r\n";
                                FileUtil.OutputCSV(Save_File[TempratureIist], line_string);
                                locate = 0; line_string = "";
                            }
                            else
                                MessageBox.Show(" Output Data is empty, Please stop to check! ");
                        }
                        Application.DoEvents();
                    }
                    Thread.Sleep(100);
                }
            }

            CurrMeter.VisaClose();
            VolMeter.VisaClose();

            if (checkEanble.Checked)
            {
                InvokeText("Item 1.1 Power On Off test RUN", (object)(Color.Green), 2);
                // 測試完後先降溫至25度,再停機.
                InvokerResultRichText("Finally Change temperature to 25°C before stop machine! Please waiting! ", Color.Black);
                Temperature_Stop(XmComm_Temper);
                XmComm_TemperClose(XmComm_Temper);
            }

            InvokeText("Item 1.1 Power On Off test RUN", Color.Black, 2);
            InvokerResultRichText("Chamber Test had ended! YA!", Color.Blue);
            Stop_Timer();
        }

        private void NewMethod(SerialPort XmComm_Temper)
        {
            if (checkEanble.Checked) Temperature_Initial(XmComm_Temper);
            else { InvokerResultRichText("By pass Chamber machine When Testing", Color.Black); }
        }

        private void POWER_OFF_Click(object sender, EventArgs e)
        {
            COM_KeyIn("1, POWER, OFF");
        }

        private void PowerOnOffbutton_Click(object sender, EventArgs e)
        {
            InvokerResultRichText("", Color.Black);

            Sample_Index = SampletextBox.Text;

            if (comboBox_Envior_type.Text == "COB")
            {
                Measure_Voltage_Number = int.Parse(comboBox_COB_Vol.Text);
                Measure_Current_Number = int.Parse(comboBox_COB_Cur.Text);
            }
            else if (comboBox_Envior_type.Text == "Panel")
            {
                Measure_Voltage_Number = int.Parse(comboBox_Panel_Vol.Text);
                Measure_Current_Number = int.Parse(comboBox_Panel_Cur.Text);
            }

            Envior_type = comboBox_Envior_type.Text;
            //FilePath = FilePathBox.Text;
            OnOffTime = int.Parse(OnOffTimetextBox.Text);

            if (PowerOnOffbutton.Text == "Item 1.1 Power On Off test RUN")
            {
                try
                {

                    InitalTempeture_Item();
                    SetTextValue(Item1_PoweronoffTxtPath);
                    InvokeText("STOP", Color.Black, 2);
                    startDate = DateTime.Now;
                    Start_Timer();
                    XmThead = new Thread(new ParameterizedThreadStart(PowerONOFFRestTest))
                    {
                        IsBackground = true
                    };
                    XmThead.Start(XmComm);
                }
                catch (Exception ex)
                {
                    InvokeText("Item 1.1 Power On Off test RUN", Color.Black, 2);
                    Stop_Timer();
                    throw ex;
                }
            }

            else { if (XmThead != null && XmThead.IsAlive) { XmThead.Abort(); InvokeText("Item 1.1 Power On Off test RUN", Color.Black, 2); Stop_Timer(); } }
        }

        public bool PowerONandCheck(ref XM_ExeWol_Util XmPlusUtil, ref XM_EquipVisa_Util PowerSupply, double[,] channel_setting)  //20170802 add
        {
            //==== channel_setting Form ===
            // [i][0] =  control channel sequence
            // [i][1] = Set voltage value
            // [i][2] = Set current value 


            //string[] SET = new string[2] { "ISET", "VSET" };
            //string[] CHECK = new string[2] { "IOUT", "VOUT" };
            string[] SET = new string[2] { "VSET", "ISET" };
            string[] CHECK = new string[2] { "VOUT", "IOUT" };

            string Temp = "";


            XmPlusUtil.GpioCtrl(0x11, 0x00, 0x00);

            PowerSupply.VisaSend("OUT0");
            Thread.Sleep(5000);
            Application.DoEvents();

            for (int j = 0; j < 2; j++)  //setting voltage and current
            {
                for (int i = 0; i < 4; i++)
                {
                    if (channel_setting[i, 0] <= 0 || channel_setting[i, 0] > 4) //skip error setting
                    {
                        continue;
                    }

                    Temp = SET[j] + channel_setting[i, 0] + ":" + channel_setting[i, j + 1];
                    PowerSupply.VisaSend(Temp);
                }
            }

            //output
            Thread.Sleep(3000);
            PowerSupply.VisaSendandRead("STATUS?", out string rdTemp);
            Temp = rdTemp.Substring(5, 1);
            if (Temp == "0")
            {
                PowerSupply.VisaSend("OUT1");
                Thread.Sleep(1000);
            }


            for (int i = 0; i < 4; i++)
            {

                if (channel_setting[i, 0] <= 0 || channel_setting[i, 0] > 4) //skip error setting
                {
                    continue;
                }

                Temp = CHECK[1] + channel_setting[i, 0] + "?";
                PowerSupply.VisaSendandRead(Temp, out rdTemp);
                PowerSupply.VisaSendandRead(Temp, out rdTemp);
                string[] str = rdTemp.Split('A');
                // Thread.Sleep(1000);
                if (Convert.ToDouble(str[0]) > (channel_setting[i, 2]) * 0.95)  //mask for test
                {
                    PowerSupply.VisaSend("OUT0");  //off power for over current protect
                    return false;
                }
            }

            return true;

        }

        public bool PowerCtrlAndReset_IC(ref XM_ExeWol_Util WhiskeyUtil, int step)
        {
            bool StepFlag = false;
            //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfa, 0x11);   //Enable GPIO
            //SL_WhiskyComm_Util WhiskeyUtil = new SL_WhiskyComm_Util();
            switch (step)
            {
                case 1:
                    {
                        WhiskeyUtil.GpioCtrl(0x11, 0x00, 0x02);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, 0x00);   //Reset Low
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x02);   //VDDI=off, AVDD=on, AVEE=off
                        StepFlag = true;
                        break;
                    }

                case 2:
                    {
                        WhiskeyUtil.GpioCtrl(0x11, 0x00, 0x01);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, 0x00);   //Reset Low
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x01);   //VDDI=on, AVDD=off, AVEE=off
                        StepFlag = true;
                        break;
                    }
                case 3:

                    {
                        WhiskeyUtil.GpioCtrl(0x11, 0x00, 0x03);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, 0x00);   //Reset Low
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x03);   //VDDI=on, AVDD=on, AVEE=off
                        StepFlag = true;
                        break;
                    }

                case 4:
                    {
                        WhiskeyUtil.GpioCtrl(0x11, 0x00, 0x07);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, 0x00);   //Reset Low
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x07);   //VDDI=on, AVDD=on, AVEE=on
                        StepFlag = true;
                        break;
                    }

                case 5:
                    {
                        WhiskeyUtil.GpioCtrl(0x11, 0x10, 0x07);

                        Thread.Sleep(100);
                        //RESET=high->low->high

                        WhiskeyUtil.GpioCtrl(0x11, 0x10, 0x07);
                        Thread.Sleep(5);
                        WhiskeyUtil.GpioCtrl(0x11, 0x00, 0x07);
                        Thread.Sleep(5);
                        WhiskeyUtil.GpioCtrl(0x11, 0x10, 0x07);

                        StepFlag = true;
                        break;
                    }

                case 6:
                    {
                        WhiskeyUtil.GpioCtrl(0x11, 0x00, 0x00);
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfb, 0x00);   //Reset Low
                        //XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0xfc, 0x00);   //VDDI=off, AVDD=off, AVEE=off
                        StepFlag = true;
                        break;
                    }

                default:
                    {
                        StepFlag = false;
                        break;
                    }

            }

            return StepFlag;
        }

        private int PowerSupply(bool Enable, double VddioVol, double VSN, double VSP)
        {

            return 0;
        }

        private void RichTextBox_status_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Text?", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                InvokerResultRichText("", Color.Black);
            }
        }

        private bool ResetWhisktyTiming(ref XM_ExeWol_Util WhiskeyUtil)
        {
            WhiskeyUtil.BridgeWrite(0xc0, 0x01, 0x00);
            Thread.Sleep(100);
            return true;
        }

        private bool Read(SerialPort XmComm, ref string RdCmd)
        {
            bool ret = true;
            ReadData(XmComm, ref RdCmd);
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

        private bool ReadData(SerialPort xmComm, ref string RetStr)
        {
            bool ret = true;
            try
            {
                RetStr = xmComm.ReadExisting();
            }
            catch (Exception)
            {
                ret = false;
                throw;
            }
            return ret;
        }

        private void SaveMeaCur(ref XM_ExeWol_Util XmPlusUtil, ref XM_EquipVisa_Util CurrMeter,
                                   ref string line_string, ref int locate, int MeaCurNum)
        {
            //Measure three current of Power(such as Vddio,AVDD,AVEE)  
            double[] Cur_Num = new double[MeaCurNum];
            for (int i = 0; i < Cur_Num.Length; i++)
            {
                Cur_Num[i] = 0;
            }
            double[] Current_total = new double[256];
            CurrentMeaDevice(ref XmPlusUtil, ref CurrMeter, ref Cur_Num);

            for (int k = 0; k < Cur_Num.Length; k++)
            {
                Current_total[locate] = Cur_Num[k];
                locate++;
                line_string += Cur_Num[k] + ",";
            }
        }

        private void SaveMeaVol(ref XM_ExeWol_Util XmPlusUtil, ref XM_EquipVisa_Util VolMeter,
                                 ref string line_string, ref int locate, int Measure_Voltage_Number)
        {
            //Measure three current of Power(such as Vddio,AVDD,AVEE)  
            double[] Vol_Num = new double[Measure_Voltage_Number];
            double[] Vol_total = new double[256];
            VoltageMeaDevice(ref XmPlusUtil, ref VolMeter, ref Vol_Num, Measure_Voltage_Number);

            for (int k = 0; k < Vol_Num.Length; k++)
            {
                Vol_total[locate] = Vol_Num[k];
                locate++;
                line_string += Vol_Num[k] + ",";
            }
        }

        private bool SetPowerSupply(ref XM_EquipVisa_Util Powersupply, double[,] channel_setting)  //20170802 add
        {
            string[] SET = new string[2] { "VSET", "ISET" };
            string[] CHECK = new string[2] { "VOUT", "IOUT" };

            string Temp = "";



            for (int j = 0; j < 2; j++)  //setting voltage and current
            {
                for (int i = 0; i < 4; i++)
                {
                    if (channel_setting[i, 0] <= 0 || channel_setting[i, 0] > 4) //skip error setting
                    {
                        continue;
                    }

                    Temp = SET[j] + channel_setting[i, 0] + ":" + channel_setting[i, j + 1];
                    Powersupply.VisaSend(Temp);
                }
            }


            //output
            Thread.Sleep(3000);
            Powersupply.VisaSendandRead("STATUS?", out string rdTemp);
            if (string.IsNullOrEmpty(rdTemp)) Powersupply.VisaSendandRead("STATUS?", out rdTemp);
            if (!string.IsNullOrEmpty(rdTemp))
            {
                Temp = rdTemp.Substring(5, 1);
                if (Temp == "0")
                {
                    Powersupply.VisaSend("OUT1");

                }
            }
            else
                Powersupply.VisaSend("OUT1");

            Thread.Sleep(1000);

            return true;

        }

        private int SETTING_TEMP(int SET)  //important #3
        {
            int ErrCode = 0;
            int Temp_flag = 0;
            float f_value = 0;
            float set_temp = 0;
            while (Temp_flag == 0)
            {
                COM_KeyIn("1, MON?");
                //ShowBox1.Text;
                string[] substrings = Regex.Split(ShowBox1.Text, ",");
                if (float.TryParse(substrings[0], out f_value))  //setting temperature , every step is less than 2 degree c to change to target temperature.
                {
                    //set_temp = SET[i, 1];
                    set_temp = SET;
                    if (Math.Abs(set_temp - f_value) <= 2)
                    {
                        string s = set_temp.ToString("#.0");
                        COM_KeyIn("1, TEMP, S" + s);
                        if (Math.Abs(set_temp - f_value) <= 0.5)
                        {
                            Temp_flag = 1;
                        }
                    }
                    else
                    {
                        if (set_temp - f_value > 2)
                        {
                            set_temp = f_value + 2;
                            string s = set_temp.ToString("#.0");
                            COM_KeyIn("1, TEMP, S" + s);
                        }
                        if (set_temp - f_value < -2)
                        {
                            set_temp = f_value - 2;
                            string s = set_temp.ToString("#.0");
                            COM_KeyIn("1, TEMP, S" + s);
                        }
                    }
                    //ErrCnt++;
                }
                else
                {
                    ErrCode = ErrCode | 1;  //if SU241 response error format. Record it!
                }

                if (substrings[3] == "0\r")  //check if SU241 has alarm
                {
                    if (substrings[2] == "OFF" || substrings[2] == "STANDBY")
                    {
                        COM_KeyIn("1, MODE, CONSTANT"); //if no alarm , start SU241.
                    }
                }
                else
                {
                    COM_KeyIn("1, MODE, STANDBY");
                    ShowBox1.Text = "SU241 has alarm!";
                    ErrCode = ErrCode | 2;  //if SU241 response alarm. Record it!
                }
                if (ErrCode == 0)
                {
                    for (int k = 0; k < 40; k++)
                    {
                        Thread.Sleep(1000);
                        ShowBox1.Text = System.String.Format("Wait for temperature[{0}C] adjust - {1}", SET, 39 - k);
                        Application.DoEvents();
                    }

                }
                else
                {
                    Temp_flag = 1;
                }

                if (Temp_flag == 1 && ErrCode == 0)
                {

                    for (int k = 0; k < 180; k++)
                    {
                        ShowBox1.Text = System.String.Format("Wait for temperature[{0}C] stable - {1}", SET, 179 - k);
                        Thread.Sleep(1000);  //delay 180s for temperature stable
                        Application.DoEvents();
                    }
                }
            }

            return ErrCode;
        }

        private bool Show_PIC(int step)
        {
            bool StepFlag = false;
            switch (step)
            {
                case 1:
                    {
                        StepFlag = true;
                        break;
                    }

                case 2:
                    {
                        StepFlag = true;
                        break;
                    }

                case 3:
                    {
                        StepFlag = true;
                        break;
                    }

                case 4:
                    {
                        StepFlag = true;
                        break;
                    }

                case 5:
                    {
                        StepFlag = true;
                        break;
                    }

                case 6:
                    {
                        StepFlag = true;
                        break;
                    }

                case 7:
                    {
                        StepFlag = true;
                        break;
                    }

                case 8:
                    {
                        StepFlag = true;
                        break;
                    }

                case 9:
                    {
                        StepFlag = true;
                        break;
                    }

                case 10:
                    {
                        StepFlag = true;
                        break;
                    }

                default:
                    {
                        break;
                    }

            }
            return StepFlag;
        }

        private bool Sav_Data_to_Excel(double[] Data, string FilePath, int sheet, ref int[] StartPoint, int RecordType)
        {
            // StartPoint[0] = horizontal direction, locate[1]= vertical direction
            // RecordType = 1 is horizontal direction, 2 is vertical direction


            //private void Mea_and_Sav(int[] StartPoint, int type, string FilePath)
            int i = 0;

            //double[] meaValue = new double[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            //meaValue sequence: VDDIO(A), VSP(A), VSN(A), VCL, GVDDP, GVDDN,
            //                   VCOM, VGH, VGHO2, VGL, VGLO2, VDD, LVDSVDD, VREF_TP, VDDS

            //Relay control & Meter Measure

            //Relay control & Meter Measure

            Thread.Sleep(600);  //mask for test

            //Excel setting
            Excel.Application excelApp;
            Excel._Workbook wBook;
            Excel._Worksheet wSheet;
            //Excel.Range wRange;

            // 開啟一個新的應用程式
            excelApp = new Excel.Application();

            Thread.Sleep(600);  //mask for test
            // 讓Excel文件可見
            excelApp.Visible = true;

            // 停用警告訊息
            excelApp.DisplayAlerts = false;

            // 加入新的活頁簿
            //excelApp.Workbooks.Add(Type.Missing);
            //excelApp.Workbooks.Open(@"D:\XXXX_Cut1.0_Item 1_1_Power.xls");

            excelApp.Workbooks.Open(FilePath);

            // 引用第一個活頁簿
            wBook = excelApp.Workbooks[1];
            //wBook = excelApp.Workbooks[3];
            //wBook = excelApp.Workbooks[sheet];

            // 設定活頁簿焦點
            wBook.Activate();



            try
            {
                // 引用第一個工作表
                //   wSheet = (Excel._Worksheet)wBook.Worksheets[1];
                //wSheet = (Excel._Worksheet)wBook.Worksheets[3];
                wSheet = (Excel._Worksheet)wBook.Worksheets[sheet];
                //wSheet = (Excel._Worksheet)wBook.Worksheets[6];
                // 命名工作表的名稱
                //   wSheet.Name = "工作表測試";

                // 設定工作表焦點
                wSheet.Activate();

                //Thread.Sleep(600);  //mask for test
                if (RecordType == 1)  //for horizontal direction record
                {
                    for (i = 0; i < Data.Length; i++)
                    {
                        excelApp.Cells[StartPoint[1], StartPoint[0]] = Data[i];
                        StartPoint[0]++;
                    }

                    /*
                    for (i = 0; i < 16; i++)
                    {
                        if (i != 3) // skip Power(mW) cell
                        {
                            excelApp.Cells[StartPoint[1], StartPoint[0]] = meaValue[i];
                        }
                        StartPoint[0]++;
                    }
                    StartPoint[1]++;
                    StartPoint[0] = StartPoint[0] - 16;
                    */
                }

                else if (RecordType == 2)  // for vertical direction record
                {
                    for (i = 0; i < Data.Length; i++)
                    {
                        excelApp.Cells[StartPoint[1], StartPoint[0]] = Data[i];
                        StartPoint[1]++;
                    }

                }

                /*
                excelApp.Cells[1, 1] = "Excel測試";

                // 設定第1列資料
                excelApp.Cells[1, 1] = "名稱";
                excelApp.Cells[1, 2] = "數量";
                // 設定第1列顏色
                wRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[1, 2]];
                wRange.Select();
                wRange.Font.Color = ColorTranslator.ToOle(Color.White);
                wRange.Interior.Color = ColorTranslator.ToOle(Color.DimGray);

                // 設定第2列資料
                excelApp.Cells[2, 1] = "AA";
                excelApp.Cells[2, 2] = "10";

                // 設定第3列資料
                excelApp.Cells[3, 1] = "BB";
                excelApp.Cells[3, 2] = "20";

                // 設定第4列資料
                excelApp.Cells[4, 1] = "CC";
                excelApp.Cells[4, 2] = "30";

                // 設定第5列資料
                excelApp.Cells[5, 1] = "總計";
                // 設定總和公式 =SUM(B2:B4)
                excelApp.Cells[5, 2].Formula = string.Format("=SUM(B{0}:B{1})", 2, 4);
                // 設定第5列顏色
                wRange = wSheet.Range[wSheet.Cells[5, 1], wSheet.Cells[5, 2]];
                wRange.Select();
                wRange.Font.Color = ColorTranslator.ToOle(Color.Red);
                wRange.Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                */
                // 自動調整欄寬
                /*
                wRange = wSheet.Range[wSheet.Cells[1, 1], wSheet.Cells[5, 2]];
                wRange.Select();
                wRange.Columns.AutoFit();
                */

                try
                {
                    //另存活頁簿
                    // wBook.SaveAs(pathFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    //string NewPathFile = @"D:\NEW_XXXX_Cut1.0_Item 1_1_Power.xls";
                    //wBook.SaveAs(pathFile);
                    //Console.WriteLine("儲存文件於 " + Environment.NewLine + pathFile);
                    //wBook.SaveAs(NewPathFile);
                    //Console.WriteLine("儲存文件於 " + Environment.NewLine + NewPathFile);
                    wBook.SaveAs(FilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("儲存檔案出錯，檔案可能正在使用" + Environment.NewLine + ex.Message);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("產生報表時出錯！" + Environment.NewLine + ex.Message);
            }

            //關閉活頁簿
            wBook.Close(false, Type.Missing, Type.Missing);

            //關閉Excel
            excelApp.Quit();

            //釋放Excel資源
            Thread.Sleep(300);  //mask for test
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            wBook = null;
            wSheet = null;
            //wRange = null;
            excelApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();  //only for test
            Thread.Sleep(300);  //mask for test

            return true;
        }

        private void ShowBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void STANDBY_Click(object sender, EventArgs e)
        {
            COM_KeyIn("1, MODE, STANDBY");
        }

        private bool SetTextValue(string _txtPath)
        {
            try
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                string LoadFilePath = _txtPath;
                string SaveFilePath = LoadFilePath.Replace("txt", "ini");

                StreamReader sr = new StreamReader(LoadFilePath, Encoding.Default);

                string line;
                int Line_Length = -1;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        line = line.Replace("[", "");
                        line = line.Replace("]", "");
                        Line_Length++;
                        XM_Comm_Temperature.TemperCmdList[Line_Length].ItemName = line;
                    }
                    else
                    {
                        if (!line.StartsWith("#") && !line.Equals(""))
                            XM_Comm_Temperature.TemperCmdList[Line_Length].CmdList.Add(line);
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }

        private bool SendCmd(ScriptInfo CmdInfo, bool Konica, ref string RdStr)
        {
            bool ret = true;
            ret = ExeCmd.ExcuteCmd(ExeCmd.GetXmCmd(), ExeCmd.GetXmClass(), ref RdStr);
            return ret;
        }

        private bool SendScript(string[] TemperCommands)
        {

            double Ratio = (double)100 / TemperCommands.Length;
            string Err = null, RdStr = null; bool ret;

            List<ScriptInfo> lScriptInfo = new List<ScriptInfo>();
            Err = ExeCmd.ExamScript(TemperCommands, lScriptInfo);
            XmCmd XMCmds = new XmCmd(lScriptInfo);
            ExeCmd.RunInfo.lScriptInfo = XMCmds.lScriptInfo;
            for (int i = 0; i < XMCmds.lScriptInfo.Count; i++)
            {
                if (ExeCmd.ExamCmd(lScriptInfo[i]))
                {

                    ret = ExeCmd.ExcuteCmd(ExeCmd.GetXmCmd(), ExeCmd.GetXmClass(), ref RdStr);

                    if (ExeCmd.IsEndLoopCmd() && ExeCmd.CompleteLoop()) FibForLoop();

                    RdStr = null;
                }
                Application.DoEvents();
                // GammaPgsBar.Value = (int)(i * Ratio);
            }
            return true;
        }

        private void FibForLoop()
        {
            bool ret = true;
            string RdStr = null;
            ScriptInfo[] RunSptInfo = new ScriptInfo[ExeCmd.RunInfo.RunLoop.EndLine - ExeCmd.RunInfo.RunLoop.StartLine - 1];
            Array.Copy(ExeCmd.RunInfo.lScriptInfo.ToArray(), ExeCmd.RunInfo.RunLoop.StartLine + 1, RunSptInfo, 0, ExeCmd.RunInfo.RunLoop.EndLine - ExeCmd.RunInfo.RunLoop.StartLine - 1);
            if (ExeCmd.RunInfo.RunLoop.Formula.CompareTo("plus") == 0)
            {
                for (int i = ExeCmd.RunInfo.RunLoop.LoopStart; i <= ExeCmd.RunInfo.RunLoop.LoopEnd; i += ExeCmd.RunInfo.RunLoop.LoopStep)
                {
                    ExeCmd.RunInfo.RunLoopList[ExeCmd.RunInfo.RunLoopList.Count - 1].Index = i;
                    for (int j = 0; j < RunSptInfo.Length; j++)
                    {
                        if (ExeCmd.ExamCmd(RunSptInfo[j]))
                        {
                               ret = ExeCmd.ExcuteCmd(ExeCmd.GetXmCmd(), ExeCmd.GetXmClass(), ref RdStr);
                            if (Setting.TxCmd && ExeCmd.RunInfo.XmCmdInfo.Excute)
                                // InvokeTxMsg(j + 1, ExeCmd.RunInfo.XmCmdInfo.XmCmd);
                                DealWithSystemCmd(ExeCmd, j + 1, ref RdStr, ref XmStr);
                            if (ExeCmd.IsEndLoopCmd() && ExeCmd.CompleteLoop())
                            {
                                FibForLoop();
                                ExeCmd.RunInfo.RunLoop = ExeCmd.RunInfo.RunLoopList[ExeCmd.RunInfo.RunLoopList.Count - 1];
                            }
                            if (ExeCmd.IsPauseCmd()) { ExeCmd.SetPause(false); if (bStopRun) break; };//Check and Stop Running

                        }
                        Main_Form.frmMain.InvokePrgbPos(j + 1);
                    }
                    if (bStopRun) break;
                }
            }
            else
            {
                for (int i = ExeCmd.RunInfo.RunLoop.LoopStart; i >= ExeCmd.RunInfo.RunLoop.LoopEnd; i -= ExeCmd.RunInfo.RunLoop.LoopStep)
                {
                    ExeCmd.RunInfo.RunLoopList[ExeCmd.RunInfo.RunLoopList.Count - 1].Index = i;
                    for (int j = 0; j < RunSptInfo.Length; j++)
                    {
                        if (ExeCmd.ExamCmd(RunSptInfo[j]))
                        {
                            ret = ExeCmd.ExcuteCmd(ExeCmd.GetXmCmd(), ExeCmd.GetXmClass(), ref RdStr);
                            if (Setting.TxCmd && ExeCmd.RunInfo.XmCmdInfo.Excute)
                                ////InvokeTxMsg(j + 1, ExeCmd.RunInfo.XmCmdInfo.XmCmd);
                                //DealWithSystemCmd(ExeCmd, j + 1, ref RdStr, ref XmStr);
                                if (ExeCmd.IsEndLoopCmd() && ExeCmd.CompleteLoop())
                                {
                                    FibForLoop();
                                    ExeCmd.RunInfo.RunLoop = ExeCmd.RunInfo.RunLoopList[ExeCmd.RunInfo.RunLoopList.Count - 1];
                                }
                            if (ExeCmd.IsPauseCmd()) { ExeCmd.SetPause(false); if (bStopRun) break; };//Check and Stop Running

                        }
                        Main_Form.frmMain.InvokePrgbPos(j + 1);
                    }
                    if (bStopRun) break;
                }
            }
            ExeCmd.RunInfo.RunLoop = null;
            ExeCmd.RunInfo.RunLoopList.RemoveAt(ExeCmd.RunInfo.RunLoopList.Count - 1);
        }

        private void DealWithSystemCmd(XM_ExeMainCmd ExeCmd, int Line, ref string RdStr, ref string XmStr)
        {
            if (ExeCmd.RunInfo.XmCmdInfo.Excute && ExeCmd.IsPauseCmd()) {} //InvokePause(Line, ExeCmd.RunInfo.XmCmdInfo.XmCmd); }
            if (ExeCmd.RunInfo.XmCmdInfo.Excute && ExeCmd.IsScopeCmd()) {}//InvokeScope(Line, ExeCmd.RunInfo.XmCmdInfo.XmCmd);
            if (ExeCmd.RunInfo.XmCmdInfo.Excute && ExeCmd.IsGammaCmd()) {} //InvokeGamma(Line, ExeCmd.RunInfo.XmCmdInfo.XmCmd);
            if (ExeCmd.RunInfo.XmCmdInfo.Excute && !string.IsNullOrEmpty(RdStr)) { XmStr += String.Format("Read[{0}]: {1}\n", Line, RdStr); }
            RdStr = null;
        }


        private bool SendScript(string[] TemperCommands, int ImageIndex)
        {
            double Ratio = (double)100 / TemperCommands.Length;
            string Err = null, RdStr = null;
            List<ScriptInfo> lScriptInfo = new List<ScriptInfo>();
            Err = ExeCmd.ExamScript(TemperCommands, lScriptInfo);
            // for (int i = 0; i < lScriptInfo.Count; i++)
            // {
            if (ExeCmd.ExamCmd(lScriptInfo[ImageIndex]))
            {
                SendCmd(lScriptInfo[ImageIndex], false, ref RdStr);
                RdStr = null;
            }
            Application.DoEvents();
            // GammaPgsBar.Value = (int)(i * Ratio);
            // }
            return true;
        }

        private bool Send(SerialPort xmComm, string Command)
        {
            return SendCmd(xmComm, AppendCheckSum(Command));
        }

        private bool SendRead(SerialPort xmComm, string Command, ref string RdCmd)
        {
            return SendAndRead(xmComm, Command, ref RdCmd);
        }

        private bool SendCmd(SerialPort xmComm, string Cmd)
        {
            if (xmComm == null) return false;
            char[] ElecsCmd = Cmd.ToCharArray();
            xmComm.Write(ElecsCmd, 0, ElecsCmd.Length);
            return true;
        }

        private bool SendAndRead(SerialPort xmComm, string Command, ref string RetStr)
        {
            bool ret = true;

            if (Send(xmComm, Command))
            {
                Thread.Sleep(500);
                ret = Read(xmComm, ref RetStr);
            }
            else
                ret = false;

            return ret;
        }

        private void TC_S8521button_Click(object sender, EventArgs e)
        {
            InvokerResultRichText("", Color.Black);
            bool Result = true;
            try
            {
                if (Temper_CommPort.Text != "" && Temper_CommPort.Text != "Null")
                {
                    TC_S8521_Form TC_S8521 = new TC_S8521_Form(ref XmComm, Temper_CommPort.Text,ref  Result);
                    if (Result) { InvokerResultRichText(" Chamber machine Connection is OK! ", Color.Black); checkEanble.Checked = true; }
                    else { InvokerResultRichText(" Chamber machine Connection is Fail! ", Color.Black); }
                    TC_S8521.ShowDialog();
                }
                else
                    MessageBox.Show(" Please choice Commport! ");
            }
            catch (Exception  )
            {
                MessageBox.Show(" Please Check Commport Connect Status or choice right Commport! ");
               // throw  ;
            }
        }

        private void Temperature_Click(object sender, EventArgs e)
        {
            COM_KeyIn("1, TEMP?");
        }

        private void TempertureTest(object d)
        {
            SerialPort XmComm_Temper = (SerialPort)d;
            XM_ExeWol_Util XmPlusUtil = new XM_ExeWol_Util();
            XM_IO_Util FileUtil = new XM_IO_Util();

            //Setting Enviornment
            int Temper_Num = 0, PowerSet_Num = 0, CmdSet_Num = 0, ImageSet_Num = 0, ImagNum = 0, ContentIndex = 0;
            int locate = 0, Savecmd_Num = 0, Cmdset_Index = 0, ImageCmdset_Index = 0, ImageShow_Index = 0;
            int i = 0, j = 0, TempratureIist = 0, EnviorIist = 0, SaveFile_Num = 0;
            
            double[] Current = new double[Measure_Current_Number];
            double[] Voltage = new double[Measure_Voltage_Number];

            bool ret = false;

            
            string date = DateTime.Today.ToString("yyyyMMdd");
            string Temperature_Read = "", line_string = "";
            string Curr_Addr = CurrentMetertextBox.Text;
            string Volt_Addr = VoltageMetertextBox.Text;

            InvokerResultRichText("Test Data :" + date, Color.Black);

            ExeTemperCmdContent(XM_TEMPER_CMDSET + 1, ref Cmdset_Index);
            ExeTemperCmdContent(XM_TEMPER_IMAGECMDSET + 1, ref ImageCmdset_Index);
            ExeTemperCmdContent(XM_TEMPER_IMAGE_SHOW, ref ImageShow_Index);
            ExeTemperCmdNum(XM_TEMPER_TEMPERATURESET, ref Temper_Num);
            ExeTemperSetNum(XM_TEMPER_POWERSET, ref PowerSet_Num, 0);
            ExeTemperSetNum(XM_TEMPER_CMDSET, ref CmdSet_Num, 0);
            ExeTemperSetNum(XM_TEMPER_IMAGECMDSET, ref ImageSet_Num, 0);
            ExeTemperCmdNum(XM_TEMPER_IMAGE_SHOW, ref ImagNum);
            ExeTemperSetNum(XM_TEMPER_SAVE_FILE, ref SaveFile_Num, 1);

            string[] Save_File = new string[Temper_Num];

            DateTime startDate = DateTime.Now;


            XM_EquipVisa_CurrMeter = new XM_EquipVisa_Util(Curr_Addr);
            XM_EquipVisa_VolMeter = new XM_EquipVisa_Util(Volt_Addr);

            // define power supply.
            ExeTemperCmd(XM_TEMPER_INSTRUMENT_SET);

            if (checkEanble.Checked) { Temperature_Initial(XmComm_Temper); }
            else { InvokerResultRichText("By pass Chamber machine When Testing", Color.Black); }

            // Get Temperature number.
            ExeTemperCmdContent(XM_TEMPER_TEMPERATURESET, ref ContentIndex);

            for (TempratureIist = 0; TempratureIist < Temper_Num; TempratureIist++)
            {
                FilePath = string.Concat(Setting.ExeLogDirPath, "\\","Cut1.0_Item 1_1_Power" + "_" + Sample_Index + "_" + Envior_type + "_" + "Temperature" + XM_Comm_Temperature.TemperCmdList[ContentIndex].CmdList[TempratureIist] + "_"+ DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv");
                Save_File[TempratureIist] = FilePath;

                byte[] rdval = new byte[1];

                // Set Tempeture.
                bool KeepGo = false;

                if (checkEanble.Checked)
                {
                    InvokerResultRichText("Set Temperature and waiting until Temperatue is "+ XM_Comm_Temperature.TemperCmdList[ContentIndex].CmdList[TempratureIist] + "°C!" , Color.Black);
                    SendAndRead(XmComm_Temper, "@001,!,101=" + XM_Comm_Temperature.TemperCmdList[ContentIndex].CmdList[TempratureIist], ref Temperature_Read);
                    do
                    {
                        Thread.Sleep(1000);
                        // 讀出來的溫度需除以100. 
                        if (!SendAndRead(XmComm_Temper, "@001,!,100", ref Temperature_Read))
                            Temperature_Read = "0";
                        KeepGo = ComparekeepRun((double.Parse(Temperature_Read) / 100), (double.Parse(XM_Comm_Temperature.TemperCmdList[ContentIndex].CmdList[TempratureIist])));
                    } while (KeepGo);

                    InvokerResultRichText("Keepping Temperature is" + XM_Comm_Temperature.TemperCmdList[ContentIndex].CmdList[TempratureIist] + "°C " + "about half hour for Enviroment Stable", Color.Black);

                    // 讓待測物可以在30分後(代表固定的溫度一段時間再測試).
                    Thread.Sleep(1800000);
                }

                for (EnviorIist = 0; EnviorIist < PowerSet_Num; EnviorIist++)
                {
                    ResetWhisktyTiming(ref XmPlusUtil);

                    //Set XmBridge Borard Timing.
                    ExeTemperCmd(XM_TEMPER_FPGA_SET);

                    Thread.Sleep(1000);

                    InvokerResultRichText("POWER SET :"+ XM_TEMPER_POWERSET + (EnviorIist + 1) , Color.Black);
                    ExeTemperCmd(XM_TEMPER_POWERSET + (EnviorIist + 1).ToString());

                    InvokerResultRichText("Open CSV File ", Color.Black);

                    InvokeOnOffTimeText(string.Concat("Timer:", i.ToString()), Color.Blue);
                    InvokerResultRichText("CMD SET :" + XM_TEMPER_CMDSET + (j).ToString(), Color.Black);
                    ExeTemperCmd(XM_TEMPER_CMDSET + (j).ToString());

                    if (SaveFile_Num != 0)
                        FileUtil.OutputCSV(Save_File[TempratureIist], "\r\n" + "=========" + "POWER SET :" + XM_TEMPER_POWERSET + (EnviorIist + 1) + "\r\n");
                    
                    // IC setting.
                    Savecmd_Num = 0;
                    for (i = 1; i <= CmdSet_Num/*6*/; i++)
                    {
                        InvokerResultRichText("CMD SET :" + XM_TEMPER_CMDSET + (i).ToString(), Color.Black);
                        ExeTemperCmd(XM_TEMPER_CMDSET + (i).ToString());

                        Thread.Sleep(1000); //origin: 2000  

                        if ((XM_TEMPER_SAVE_FILE).CompareTo(XM_Comm_Temperature.TemperCmdList[i + Savecmd_Num + Cmdset_Index].ItemName) == 0)
                        {
                            InvokerResultRichText(XM_TEMPER_SAVE_FILE + " : Measure Data and Ready to Save Data!", Color.Black);
                            if (Measure_Current_Number != 0)
                                SaveMeaCur(ref XmPlusUtil, ref XM_EquipVisa_CurrMeter, ref line_string, ref locate, Measure_Current_Number);
                            if (Measure_Voltage_Number != 0)
                                SaveMeaVol(ref XmPlusUtil, ref XM_EquipVisa_VolMeter, ref line_string, ref locate, Measure_Voltage_Number);

                            if((Measure_Voltage_Number != 0) || (Measure_Current_Number != 0))
                            InvokerResultRichText("MeasureData :" + line_string.Substring(0, line_string.LastIndexOf(',')) + ". mA or V !", Color.Green);

                            line_string += "\r\n";
                            FileUtil.OutputCSV(Save_File[TempratureIist], line_string);
                            Savecmd_Num++;
                        }

                        //ts = DateTime.Now - startDate;
                        //InvokeTimeText(ts.ToString(), Color.LightGreen);

                        locate = 0;
                        line_string = "";
                        Application.DoEvents();
                    }

                    // Image Setting
                    Savecmd_Num = 0;

                    for (i = 1; i <= ImageSet_Num; i++)
                    {
                        InvokerResultRichText("IMAGE SET :" + XM_TEMPER_IMAGECMDSET + (i).ToString(), Color.Black);
                        ExeTemperCmd(XM_TEMPER_IMAGECMDSET + (i).ToString());
                        for (j = 1; j <= ImagNum; j++)
                        {
                            InvokerResultRichText("IMAGE SHOW : Picture "+ j +" Name : "+ XM_Comm_Temperature.TemperCmdList[ImageShow_Index].CmdList[j - 1], Color.Black);
                            ret = ExeTemperCmd(XM_TEMPER_IMAGE_SHOW, j - 1);

                            Thread.Sleep(1000); //origin: 2000  // mask for test;

                            if ((XM_TEMPER_SAVE_FILE).CompareTo(XM_Comm_Temperature.TemperCmdList[i + Savecmd_Num + ImageCmdset_Index].ItemName) == 0)
                            {
                                InvokerResultRichText(XM_TEMPER_SAVE_FILE + " : Measure Data and Ready to Save Data!", Color.Black);
                                if (Measure_Current_Number != 0)
                                    SaveMeaCur(ref XmPlusUtil, ref XM_EquipVisa_CurrMeter, ref line_string, ref locate, Measure_Current_Number);
                                if (Measure_Voltage_Number != 0)
                                    SaveMeaVol(ref XmPlusUtil, ref XM_EquipVisa_VolMeter, ref line_string, ref locate, Measure_Voltage_Number);

                                if ((Measure_Voltage_Number != 0) || (Measure_Current_Number != 0))
                                    InvokerResultRichText("MeasureData :" + line_string.Substring( 0, line_string.LastIndexOf(','))+ ". mA or V !", Color.Green);
                               
                                line_string += "\r\n";
                                FileUtil.OutputCSV(Save_File[TempratureIist], line_string);
                                //Savecmd_Num++;
                            }

                            //ts = DateTime.Now - startDate;
                            //InvokeTimeText(ts.ToString(), Color.LightGreen);
                            locate = 0;
                            line_string = "";
                            Thread.Sleep(100);
                        }
                        Savecmd_Num++;
                    }
                }
            }

            InvokeTextBox(FilePath, Color.LightGreen);
            XM_EquipVisa_CurrMeter.VisaClose();
            XM_EquipVisa_VolMeter.VisaClose();

            if (checkEanble.Checked)
            {
                // 測試完後先降溫至25度,再停機.
                InvokerResultRichText("Finally Change temperature to 25°C before stop machine! Please waiting! ", Color.Black);
                Temperature_Stop(XmComm_Temper);
                XmComm_TemperClose(XmComm_Temper);
            }

            InvokeText("Item1.1 Power test RUN", Color.Green, 1);
            InvokerResultRichText("Chamber Test had ended!", Color.Blue);
            Stop_Timer();
        }

        private bool Temperature_Initial(SerialPort xmComm)
        {
            bool Result = true;
            string ReadData = "";
            // 停機.
            Result = SendAndRead(xmComm,"@001,%,217=0", ref ReadData);
            if (!Result) return Result;
            Thread.Sleep(15000);// 10Secs.
            InvokerResultRichText("Initial Status : 1. Stop machine ( 停機 ). Please waiting 15 Secs", Color.Black);

            // 運轉模式: 1:程式模式  2:定值模式.
            Result = SendAndRead(xmComm, "@001,%,313=0", ref ReadData);
            if (!Result) return Result;
            Thread.Sleep(150);// 1Secs.
            InvokerResultRichText("Initial Status : 2. Set Run Mode ( 定值模式 ). Please waiting 150m Secs", Color.Black);


            // 運轉模式: 設定定值時間為0,保證在每個測試項都能在固定的溫度做完).
            Result = SendAndRead(xmComm, "@001,$,111=0", ref ReadData);
            if (!Result) return Result;
            Thread.Sleep(150);
            InvokerResultRichText("Initial Status : 3. Set Run Time ( 定值模式時間持續至停機 ). Please waiting 150m Secs", Color.Black);

            // 運轉模式: 1.00:當斷電重啓時,是以停機狀態呈現(可簡單知道是否有無斷電過).
            Result = SendAndRead(xmComm, "@001,!,122=1.00", ref ReadData);
            if (!Result) return Result;
            Thread.Sleep(150);
            InvokerResultRichText("Initial Status : 4.Set Restart Mode ( 突然斷電重啓時,以停機狀態呈現 ). Please waiting 150m Secs", Color.Black);

            // 開機.
            Result = SendAndRead(xmComm, "@001,%,217=1", ref ReadData);
            if (!Result) return Result;
            Thread.Sleep(15000);//15 Secs.
            InvokerResultRichText("Initial Status : 5.Start machine( 開機 ). Please waiting 15 Secs", Color.Black);
          
            // 濕度設為0. 
            Result = Send(xmComm, "@001,!,201=0");
            if (!Result) return Result;
            Thread.Sleep(150);
            InvokerResultRichText("Initial Status : 6.Set SV ( 濕度 ). Please waiting 150m Secs", Color.Black);

            return Result;
        }

        private bool Temperature_Stop(SerialPort xmComm)
        {
            bool Result = true, KeepGo = true;
            string ReadData = "";
            string Temperature_Read = "";
            if (checkEanble.Checked)
            {
                // Set Tempeture.
                SendAndRead(xmComm, "@001,!,101=25.0", ref Temperature_Read);
                do
                {
                    Thread.Sleep(1000);
                    // 讀出來的溫度需除以100. 
                    if (!SendAndRead(xmComm, "@001,!,100", ref Temperature_Read))
                        Temperature_Read = "0";
                    KeepGo = ComparekeepRun((double.Parse(Temperature_Read) / 100), 25.0);
                } while (KeepGo);

                Thread.Sleep(100);// 10Secs.
                // 停機.
                Result = SendAndRead(xmComm, "@001,%,217=0", ref ReadData);
                if (!Result) return Result;
                Thread.Sleep(100);// 10Secs.
            }
            return Result;
        }

        public bool VoltageMeaDevice(ref XM_ExeWol_Util MipiUtil, ref XM_EquipVisa_Util XmEqut, ref double[] Voltage, int Measure_Voltage_Number)  
        {
            string Temp = "";
            string rdStrTemp = "";
            Byte[] GPIO_Reg = new Byte[15] { 0x12, 0x22, 0x32, 0x42, 0x52, 0x62, 0x72, 0x82, 0x92, 0xa2, 0xb2, 0xc2, 0xd2, 0xe2, 0xf2 };
            byte Gpio_H_Reg = 0, Gpio_L_Reg = 0;
            int TestNum = 3;
            uint Reg = 0;

            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xfb, ref Gpio_H_Reg);
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xfc, ref Gpio_L_Reg);

            Reg = (byte)(Gpio_H_Reg & 0xf2);
            for (int i = 0; i < Measure_Voltage_Number; i++) { GPIO_Reg[i] = (byte)(GPIO_Reg[i] | Reg); }

            for (int i = 0; i < TestNum; i++)
            {
                XmEqut.VisaSendandRead("CONFigure?", out rdStrTemp);
                rdStrTemp = rdStrTemp.Substring(1, 5);
                if (string.Compare(rdStrTemp, 0, "VOLT", 0, 4) != 0)
                    XmEqut.VisaSend("CONFigure:VOLTage:DC AUTO,DEFault");
                else
                    break;
            }

            for (int i = 0; i < Measure_Voltage_Number; i++)
            {
                MipiUtil.GpioCtrl(0x11, 0x02);
                Thread.Sleep(100);

                MipiUtil.GpioCtrl(0x11, GPIO_Reg[i]);
                Thread.Sleep(500);//original:1000
                XmEqut.VisaSendandRead("Read?", out Temp);
                if (string.IsNullOrEmpty(Temp))
                {
                    Thread.Sleep(1000);//original:2000
                    XmEqut.VisaSendandRead("Read?", out Temp);
                    ShowBox1.Text = "Current Repeat read A";
                }

                Voltage[i] = Convert.ToDouble(Temp);
            }
            MipiUtil.GpioCtrl(0x11, 0x02, 0x0f);
            return true;
        }

        public bool VoltageMeaDevice(ref XM_ExeWol_Util MipiUtil, ref XM_EquipVisa_Util XmEqut, ref double[] Voltage, int Measure_Voltage_Number, int DelayItem)
        {
            string Temp = "";
            string rdStrTemp = "";

            Byte[] GPIO_Reg = new Byte[15] { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80, 0x90, 0xa0, 0xb0, 0xc0, 0xd0, 0xe0, 0xf0 };
            byte Gpio_H_Reg = 0, Gpio_L_Reg = 0;
            int TestNum = 3;
            uint Reg = 0;

            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xfb, ref Gpio_H_Reg);
            XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0xfc, ref Gpio_L_Reg);

            Reg = (byte)(Gpio_H_Reg & 0xf0);
            for (int i = 0; i < Measure_Voltage_Number; i++) { GPIO_Reg[i] = (byte)(GPIO_Reg[i] | Reg); }

            for (int i = 0; i < TestNum; i++)
            {
                XmEqut.VisaSendandRead("CONFigure?", out rdStrTemp);
                rdStrTemp = rdStrTemp.Substring(1, 5);
                if (string.Compare(rdStrTemp, 0, "VOLT", 0, 4) != 0)
                    XmEqut.VisaSend("CONFigure:VOLTage:DC AUTO,DEFault");
                else
                    break;
            }

            for (int i = 0; i < Measure_Voltage_Number; i++)
            {
                MipiUtil.GpioCtrl(0x11, 0x00);
                Thread.Sleep(100);

                MipiUtil.GpioCtrl(0x11, GPIO_Reg[i]);
                if(DelayItem<=3 && i<=2) Thread.Sleep(10000);
                else Thread.Sleep(500);//original:1000
                XmEqut.VisaSendandRead("Read?", out Temp);
                if (string.IsNullOrEmpty(Temp))
                {
                    Thread.Sleep(1000);//original:2000
                    XmEqut.VisaSendandRead("Read?", out Temp);
                    ShowBox1.Text = "Current Repeat read A";
                }

                Voltage[i] = Convert.ToDouble(Temp);
            }
            MipiUtil.GpioCtrl(0x11, 0x00, 0x0f);
            return true;
        }

        private bool XmComm_TemperClose(SerialPort xmComm)
        {
            {
                try
                {
                    xmComm.Close();
                    isCommOpen = false;
                }
                catch (Exception ex)
                {
                    Log.F(this.GetType().FullName, "CommClose() Error: " + ex.Message);
                }
            }
            return true;
        }

        private void Start_Timer()
        {
            // Call this procedure when the application starts.  
            // Set to 1 second.  
            Execute_timer.Interval = 1000;

            Execute_timer.Tick += new EventHandler(Timer_Tick);

            // Enable timer.  
            Execute_timer.Enabled = true;

        }
        private void Stop_Timer()
        {
            Execute_timer.Enabled = false;
        }

        private void btn_PwrTest_Click(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object Sender, EventArgs e)
        {
            // Set the caption to the current time.  
            Execute_Time_Text.Text = (DateTime.Now - startDate).ToString();
        }

        //========================Update UI Component==========================//
        private delegate void MarshalToForm(int action, String textToAdd, object dt, int iRowRefresh = -1);

        ///  <summary>
        ///  Enables accessing a form's controls from another thread 
        ///  </summary>
        ///  
        ///  <param name="action"> a String that names the action to perform on the form </param>
        ///  <param name="textToDisplay"> text that the form displays or the code uses for 
        ///  another purpose. Actions that don't use text ignore this parameter.  </param>

        private void MyMarshalToForm(int Action, String textToDisplay, object dt, int choice = 1)
        {
            try
            {
                object[] args = { Action, textToDisplay, dt, choice };
                MarshalToForm MarshalToFormDelegate = null;

                //  The AccessForm routine contains the code that accesses the form.

                MarshalToFormDelegate = new MarshalToForm(AccessForm);

                //  Execute AccessForm, passing the parameters in args.

                base.Invoke(MarshalToFormDelegate, args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AccessForm(int Action, String formText, object dt, int choicetext)
        {
            switch (Action)
            {
                case (int)MSG.MSG_TEMPERTEXT:
                    if(choicetext==1)
                    ItemPowerbutton.Text = formText;
                    if (choicetext == 2)
                    PowerOnOffbutton.Text = formText;
                    break;
                case (int)MSG.TEXTBOX:
                    //FilePathBox.Text = formText;
                    //FilePathBox.ForeColor = (System.Drawing.Color)dt;
                    break;
                case (int)MSG.MSG_TIMETEXT:
                    Execute_Time_Text.Text = formText;
                    break;
                case (int)MSG.MSG_ONOFFTIMETEXT:
                    ShowBox1.Text = formText;
                    break;
                case (int)MSG.MSG_RESULT:
                    if (formText == "")
                    { richTextBox_status.Text = ""; }
                    else
                    {
                        richTextBox_status.SelectionColor = (System.Drawing.Color)dt;
                        richTextBox_status.AppendText(formText + "\r\n");
                        richTextBox_status.SelectionStart = richTextBox_status.Text.Length;
                        richTextBox_status.ScrollToCaret();
                    }
                    break;
                default:
                    break;
            }
        }

        /* public int SETTING_TEMP_OBJ(int SET, XM_ExeMainCmd SU241)  //important #3  //only for test
         {
             int ErrCode = 0;
             int Temp_flag = 0;
             float f_value = 0;
             float set_temp = 0;
             while (Temp_flag == 0)
             {
                 COM_KeyIn("1, MON?");
                 //ShowBox1.Text;
                 string[] substrings = Regex.Split(ShowBox1.Text, ",");
                 if (float.TryParse(substrings[0], out f_value))  //setting temperature , every step is less than 2 degree c to change to target temperature.
                 {
                     //set_temp = SET[i, 1];
                     set_temp = SET;
                     if (Math.Abs(set_temp - f_value) <= 2)
                     {
                         string s = set_temp.ToString("#.0");
                         COM_KeyIn("1, TEMP, S" + s);
                         if (Math.Abs(set_temp - f_value) <= 0.5)
                         {
                             Temp_flag = 1;
                         }
                     }
                     else
                     {
                         if (set_temp - f_value > 2)
                         {
                             set_temp = f_value + 2;
                             string s = set_temp.ToString("#.0");
                             COM_KeyIn("1, TEMP, S" + s);
                         }
                         if (set_temp - f_value < -2)
                         {
                             set_temp = f_value - 2;
                             string s = set_temp.ToString("#.0");
                             COM_KeyIn("1, TEMP, S" + s);
                         }
                     }
                     //ErrCnt++;
                 }
                 else
                 {
                     ErrCode = ErrCode | 1;  //if SU241 response error format. Record it!
                 }

                 if (substrings[3] == "0\r")  //check if SU241 has alarm
                 {
                     if (substrings[2] == "OFF" || substrings[2] == "STANDBY")
                     {
                         COM_KeyIn("1, MODE, CONSTANT"); //if no alarm , start SU241.
                     }
                 }
                 else
                 {
                     COM_KeyIn("1, MODE, STANDBY");
                     ShowBox1.Text = "SU241 has alarm!";
                     ErrCode = ErrCode | 2;  //if SU241 response alarm. Record it!
                 }
                 if (ErrCode == 0)
                 {
                     //Thread.Sleep(50000);  //delay 50s for temperature change
                     for (int k = 0; k < 40; k++)
                     {
                         Thread.Sleep(1000);
                         ShowBox1.Text = System.String.Format("Wait for temperature[{0}C] adjust - {1}", SET, 39 - k);
                         Application.DoEvents();
                     }

                 }
                 else
                 {
                     Temp_flag = 1;
                 }

                 if (Temp_flag == 1 && ErrCode == 0)
                 {
                     //   ShowBox1.Text = "Wait for temperature stable";
                     //   Thread.Sleep(180000);  //delay 180s for temperature stable
                     for (int k = 0; k < 180; k++)
                     {
                         //ShowBox1.Text = "Wait for temperature stable";
                         ShowBox1.Text = System.String.Format("Wait for temperature[{0}C] stable - {1}", SET, 179 - k);
                         Thread.Sleep(1000);  //delay 180s for temperature stable
                         Application.DoEvents();
                     }
                 }
             }

             return ErrCode;
         }*/
    }
}

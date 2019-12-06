/* Agilent VISA Example in C#
* -------------------------------------------------------------------
* This program illustrates a few commonly used programming
* features of your Agilent oscilloscope.
* -------------------------------------------------------------------
*/

using System;
using System.Text;
using System.IO.Ports;
using System.Threading;



namespace XM_Tek_Studio_Pro.StudioUtil
{

    public class XM_EquipVisa_Util
    {
        //==================================================VISA32======================================================//
        public int m_nResourceManager;
        public int m_nSession;
        public string m_strVisaAddress;
        public string EquipName = null;
        public string EquipAliasName = null;
        public bool bOpen = false;
        private int nViStatus;

        public struct EquitDevice
        {
            public string VisaName { get; set; }
            public string CommName { get; set; }
            public string Type { get; set; }
            public int Speed { get; set; }
            public bool VisaFlag { get; set; }
            public string Message { get; set; }
        }

        public struct OSCType
        {
            public string KeySight;
            public string Agilent;
            public string Tektronix;
            public string GetPictureFromOSC;

            public OSCType(string KeySight,string Agilent, string Tektronix, string FromOSC)
            {
                this.KeySight = KeySight;
                this.Agilent = Agilent;
                this.Tektronix = Tektronix;
                this.GetPictureFromOSC = FromOSC;
            }
        }
        
        /* Open the default VISA resource manager.*/
        public XM_EquipVisa_Util()
        {
            OpenResourceManager();
        }

        public XM_EquipVisa_Util(string strVisaAddress)
        {
            // Save VISA addres in member variable.
            m_strVisaAddress = strVisaAddress;
            // Open the default VISA resource manager.
            OpenResourceManager();
            // Open a VISA resource session.
            bOpen  = OpenSession() == 0 ? true : false;
        }

        public int VisaSend(string strCommandOrQuery)
        {
            // Send command or query to the device.
            string strWithNewline;
            strWithNewline = String.Format("{0}\n", strCommandOrQuery);
            // CheckVisaStatus(nViStatus);
            nViStatus = visa32.viPrintf(m_nSession, strWithNewline);
            // CheckVisaStatus(nViStatus);
            nViStatus =visa32.viFlush(m_nSession, visa32.VI_WRITE_BUF);
            // CheckVisaStatus(nViStatus);
            return nViStatus;
        }

        public int VisaRead(out string strReadResult)
        {
            nViStatus = visa32.viRead(m_nSession, out strReadResult, 1024);
            //CheckVisaStatus(nViStatus);
            if (String.IsNullOrEmpty(strReadResult) || (nViStatus != 0)) strReadResult = "Device Read Err,Not Support Read,Connection,Fail";
            visa32.viFlush(m_nSession, visa32.VI_READ_BUF);


            return nViStatus;
        }

        public int VisaSendandRead(string strSendCommand, out string strReadResult)
        {
            // Send command or query to the device.
            nViStatus = VisaSend(strSendCommand);
            //CheckVisaStatus(nViStatus);
            visa32.viFlush(m_nSession, visa32.VI_WRITE_BUF);
            //CheckVisaStatus(nViStatus);

            // Read command or query to the device.
            nViStatus = VisaRead(out strReadResult);
            //CheckVisaStatus(nViStatus);
            visa32.viFlush(m_nSession, visa32.VI_READ_BUF);
            // CheckVisaStatus(nViStatus);

            return nViStatus;
        }

        public int VisaReadPictureBinaryFormat(out byte[] strReadDataArray, out int length, string OSCType)
        {
            // Results array, big enough to hold a PNG.
            strReadDataArray = new byte[300000];
            // int length; // Number of bytes returned from instrument.
            // Set the default number of bytes that will be contained in
            // the ResultsArray to 300,000 (300kB).
            length = 300000;
            // Read return value string from the device.
            int nViStatus = 0;
            //Type of ReadPicture depend on OSC
            if (OSCType == "AGILENT" || OSCType == "KEYSIGHT")
            {
                nViStatus = visa32.viScanf(m_nSession, "%#b", ref length,
                                         strReadDataArray);
                nViStatus = visa32.viFlush(m_nSession, visa32.VI_READ_BUF);
                //if Wrong Syntax be send to Equipment, we need to check and clear quene.
                nViStatus = CheckSCPIQuerySyntax();
            }
            if (OSCType == "TEKTRONIX")
            {
                nViStatus = visa32.viRead(m_nSession, strReadDataArray, length,
                                          out length);
                nViStatus = visa32.viFlush(m_nSession, visa32.VI_READ_BUF);
            }
            //CheckVisaStatus(nViStatus);
          //  Close();
            return nViStatus;
        }

        public int CheckSCPIQuerySyntax()
        {
            nViStatus = VisaSendandRead(":SYSTem:ERRor?", out string strReadResult);
            if (strReadResult.Contains("No error")) return nViStatus;
            if (!strReadResult.Contains("no error")) VisaSend("*CLS"); return -1;
        }

        public int OscilloScopeImage(out string GetPictureFromOSC , int ChoiseSaveCmd)
        {

            string VISACmdSet = null;
            GetPictureFromOSC = null;

            XM_EquipVisa_Util.OSCType OSC_Type = new XM_EquipVisa_Util.OSCType("KEYSIGHT","AGILENT", "TEKTRONIX", "");
            
            SetTimeoutSeconds("5");//5sec

            VisaSendandRead("*IDN?",out string IdStr);
 
            if (IdStr.Contains(OSC_Type.Agilent) || IdStr.Contains(OSC_Type.KeySight))
            {
                VISACmdSet = ":STOP";
                nViStatus = VisaSend(VISACmdSet);

                VISACmdSet = ":HARDcopy:INKSaver OFF";
                nViStatus = VisaSend(VISACmdSet);

                VISACmdSet = ChoiseSaveCmd == 0 ? ":DISPlay:DATA? PNG,SCReen,1,NORMal" : ":DISPlay:DATA? PNG, COLor";
                VisaSend(VISACmdSet);

                GetPictureFromOSC = OSC_Type.Agilent;

            }
            else if(IdStr.Contains(OSC_Type.Tektronix))
            {
                VISACmdSet = ":SAVe:IMAGe:FILEFormat PNG";
                nViStatus = VisaSend(VISACmdSet);

                VISACmdSet = ":HARDCOPY:INKSAVER OFF";
                nViStatus = VisaSend(VISACmdSet);

                VISACmdSet = ":HARDCopy:LAYout PORTRait";
                nViStatus = VisaSend(VISACmdSet);

                //VISACmdSet = ":DATa:ENCdg RIBinary";
                //nViStatus = VisaSend(VISACmdSet);

                //VISACmdSet = ":WFMOutpre:BYT_Nr 1";//byte
                //nViStatus = VisaSend(VISACmdSet);

                VISACmdSet = ":HARDCOPY STARt";
                nViStatus = VisaSend(VISACmdSet);

                GetPictureFromOSC = OSC_Type.Tektronix;

            }
           
            return nViStatus ;
        }
        public void OpenResourceManager()
        {
            nViStatus = visa32.viOpenDefaultRM(out this.m_nResourceManager);
            if (nViStatus < visa32.VI_SUCCESS)
                throw new
                ApplicationException("Failed to open Resource Manager");    
        }

        private int OpenSession()
        {
            nViStatus = visa32.viOpen(this.m_nResourceManager,
                                      this.m_strVisaAddress, visa32.VI_NO_LOCK,
                                      visa32.VI_TMO_IMMEDIATE, out this.m_nSession);
            // CheckVisaStatus(nViStatus);
            return nViStatus;
        }

        public bool IsOpen() { return (bOpen == true) ? true : false; }

        public string[] SearchAllEquip()
        {
            string[] devices = new string[128];
            uint Equipment_Num = 0;
            try
            {
                Find_MeasureResource(devices, out Equipment_Num);
            }
            catch (Exception ex)
            {
                { throw new ApplicationException(ex.ToString()); };
            }

            return devices;
        }

        public string[] Find_MeasureResource(string[] RsrcName, out uint num)
        {
            StringBuilder buffer = new StringBuilder("", 100);
            visa32.viFindRsrc(this.m_nResourceManager, "?*INSTR", out int list, out int nmatches, buffer);
            num = (uint)nmatches;
            for (int idx = 0; idx < nmatches; idx++)
            {
                RsrcName[idx] = buffer.ToString();
                visa32.viFindNext(list, buffer);
            }
            return RsrcName;
        }

        public int SetTimeoutSeconds(string Seconds)
        {
            int nViStatus;

            nViStatus = visa32.viSetAttribute(this.m_nSession,
                                              visa32.VI_ATTR_TMO_VALUE, int.Parse(Seconds) * 1000);
            // CheckVisaStatus(nViStatus);
            return nViStatus;

        }

        public bool VisaOpen()
        {
            if (String.IsNullOrEmpty(this.EquipName)) return false;
            bool ret = true;

            try
            {
                bOpen = ret = OpenSession() == 0 ? true : false;
            }
            catch (SystemException ex)
            {
                Console.Write(ex.Data);
                bOpen = ret = false;
            }
            return ret;
        }

        public int VisaClose()
        {
            int nViStatus=0;
            try
            { 
                if (m_nSession != 0)
                visa32.viClose(m_nSession);
                if (m_nResourceManager != 0)
                visa32.viClose(m_nResourceManager);
            }

            catch (Exception ex)
            {  throw new ApplicationException(ex.ToString());  }
 
            return nViStatus;
        }

        //==================================================COMPORT==========================================================//
        private SerialPort XmComm = null;
        private char[] RxBuf = new char[128];
        string CommPort = null, CommBaudRate = null, CommDatabit = null, CommParity = null, CommStopBits = null;
        private int RdCount = 8;
        private bool isCommOpen = false;

        public XM_EquipVisa_Util(string CommPort, string CommBaudRate, string CommDatabit, string CommParity, string CommStopBits)
        {
            this.CommPort = CommPort;
            this.CommBaudRate = CommBaudRate;
            this.CommDatabit = CommDatabit;
            this.CommParity = CommParity;
            this.CommStopBits = CommStopBits;
        }

        public bool CommOpen()
        {
            bool ret = true;
            XmComm = new SerialPort
            {
                PortName = CommPort,
                BaudRate = int.Parse(CommBaudRate),
                DataBits = int.Parse(CommDatabit)
            };

            switch (CommParity)
            {
                case "None":
                    XmComm.Parity = Parity.None;
                    break;
                case "Even":
                    XmComm.Parity = Parity.Even;
                    break;
                case "Odd":
                    XmComm.Parity = Parity.Odd;
                    break;
                case "Mark":
                    XmComm.Parity = Parity.Mark;
                    break;
                case "Space":
                    XmComm.Parity = Parity.Space;
                    break;
                default:
                    XmComm.Parity = Parity.None;
                    break;
            }

            switch (CommStopBits)
            {
                case "1":
                    XmComm.StopBits = StopBits.One;
                    break;
                case "1.5":
                    XmComm.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    XmComm.StopBits = StopBits.Two;
                    break;
                default:
                    XmComm.StopBits = StopBits.One;
                    break;
            }

            try
            {
                XmComm.ReadTimeout = 1000;
                XmComm.WriteTimeout = 1000;
                XmComm.WriteBufferSize = 8192;
                XmComm.ReadBufferSize = 8192;
                XmComm.RtsEnable = true;    //For CA210
                XmComm.DtrEnable = true;    //For CA210
                isCommOpen = true;
                XmComm.Open();
                XmComm.DiscardInBuffer();
                XmComm.DiscardOutBuffer();

            }
            catch (Exception ex)
            {
                if (ex.Source != null)
                    ret = false;

                isCommOpen = false;
            }

            if (!XmComm.IsOpen)
                ret = false;

            return ret;
        }

        private void DataReceivedHandler( object sender,SerialDataReceivedEventArgs e)
        {
            //SerialPort sp = (SerialPort)sender;
            string indata = XmComm.ReadExisting();

        }

        public void CommClose()
        {
            try
            {
                this.XmComm.Close();
                isCommOpen = false;
            }
            catch (Exception ex)
            {
                Log.F(this.GetType().FullName, "CommClose() Error: " + ex.Message);
            }
        }

        public bool Write(string Command)
        {

            if (XmComm == null) return false;
            char[] ElecsCmd = Command.ToCharArray();
            XmComm.Write(ElecsCmd, 0, ElecsCmd.Length);
            return true;
        }

        public bool Write(string Command, int Delay)
        {
            if (XmComm == null) return false;
            char[] ElecsCmd = Command.ToCharArray();
            XmComm.Write(ElecsCmd, 0, ElecsCmd.Length);
            Thread.Sleep(Delay);
            return true;
        }

        public bool WriteAndRead(string Command, int Delay, ref string RetStr)
        {
            XmComm.DiscardOutBuffer();
            bool ret = true;
            if (Write(Command))
            {
                Thread.Sleep(Delay);
                ret = Read(ref RetStr);
            }
            else
                ret = false;

            return ret;
        }

        public bool KonicaWrAndRd(string Command, int Delay, ref string RetStr)
        {
            XmComm.DiscardOutBuffer();
            int Count = 0;
            bool ret = true;
            if (Write(Command))
            {
                while (Count < RdCount)
                {
                    Thread.Sleep(Delay);
                    ret = Read(ref RetStr);
                    if (!string.IsNullOrEmpty(RetStr)) break;
                    Count++;
                }
                if (Count > RdCount) return false;
            }
            else
                ret = false;

            return ret;
        }

        public bool WriteAndRead(string Command, ref string RetStr)
        {
            bool ret = true;

            if (Write(Command))
            {
                Thread.Sleep(50);
                ret = Read(ref RetStr);
            }
            else
                ret = false;

            return ret;
        }

        public bool KonicaRd(int Delay, ref string RetStr)
        {
            bool ret = true;
            int Sleep = Delay, Count = 0;
            try
            {
                while (Count < RdCount)
                {
                    Sleep = (int)(Math.Sqrt(Count) * 20 + 30 * Count + Delay);
                    Thread.Sleep(Sleep);
                    RetStr = XmComm.ReadExisting();
                    if (!string.IsNullOrEmpty(RetStr)) break;
                    Count++;
                }

                if (Count > RdCount) return false;
            }
            catch (Exception)
            {
                ret = false;
                throw;
            }

            return ret;
        }

        public bool Read(int Delay, ref string RetStr)
        {
            bool ret = true;
            try
            {
                Thread.Sleep(Delay);
                RetStr = XmComm.ReadExisting();
            }
            catch (Exception)
            {
                ret = false;
                throw;
            }

            return ret;
        }

        public bool Read(ref string RetStr)
        {
            bool ret = true;
            try
            {
                RetStr = XmComm.ReadExisting();
            }
            catch (Exception)
            {
                ret = false;
                throw;
            }

            return ret;
        }

        public bool IsCommOpen()
        {
            return isCommOpen;
        }

    }
}



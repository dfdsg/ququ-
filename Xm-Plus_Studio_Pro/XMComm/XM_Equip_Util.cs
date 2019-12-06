#define VISASUPPORT  
#if (VISASUPPORT)
using Ivi.Visa.Interop;
#endif
using System;
using System.Text;

namespace XM_Tek_Studio_Pro
{

    public class EquitDevice
    {
        public string VisaName { get; set; }
        public string CommName { get; set; }
        public string Type { get; set; }
        public int Speed { get; set; }
        public bool VisaFlag { get; set; }
        public string Message { get; set; }
    }

    public class XM_Equip_Util
    {
#if (VISASUPPORT)
        ResourceManagerClass Rm = new ResourceManagerClass();
        FormattedIO488Class IO_Obj = new FormattedIO488Class();
#endif
        private string InstruAddr = null;
        private string InstruName = null;
        private string InstruNickName = null;
        private bool bOpen = false;
        private XM_Visa_Util VisaUtil;
#if (VISASUPPORT)


        public bool Open(string Addr)
        {
            Rm = new ResourceManagerClass();
            IO_Obj = new FormattedIO488Class();

            if (String.IsNullOrEmpty(Addr)) return false;
            this.InstruAddr = Addr;
            bool ret = true;
            try
            {
                IO_Obj.IO = (IMessage)Rm.Open(this.InstruAddr, AccessMode.NO_LOCK, 500, null);
                IO_Obj.IO.Timeout = 500;
                bOpen = ret = true;
                
            }
            catch (Exception e)
            {
                try
                {
                    IO_Obj.IO.Close();
                }
                catch { }

                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(IO_Obj);
                }
                catch { }

                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(Rm);
                }
                catch { }

                Rm = null;
                IO_Obj = null;
                bOpen = ret = false;
                Log.F(this.GetType().FullName, "Open() :" + e.Message);
            }
            return ret;
        }

        public bool Open()
        {
            Rm = new ResourceManagerClass();
            IO_Obj = new FormattedIO488Class();

            if (String.IsNullOrEmpty(this.InstruName)) return false;
            bool ret = true;
            try
            {
                IO_Obj.IO = (IMessage)Rm.Open(this.InstruName, AccessMode.NO_LOCK, 500, null);
                IO_Obj.IO.Timeout = 500;
                bOpen = ret = true;
            }
            catch (Exception e)
            {
               
                try
                {
                    IO_Obj.IO.Close();
                }
                catch { }

                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(IO_Obj);
                }
                catch { }

                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(Rm);
                }
                catch { }

                Rm = null;
                IO_Obj = null;
                bOpen =  ret = false;
                Log.F(this.GetType().FullName, "Open() :" + e.Message);
            }
            return ret;
        }

        public bool Send(string  instruCmd)
        {
            bool ret = true;
            if (String.IsNullOrEmpty(instruCmd)) return false;
            try
            {
                IO_Obj.WriteString(instruCmd, true);
            }
            catch{
                ret = false;
            }

            return ret;
        }

        public bool ToughSend(string instruCmd)
        {
            bool ret = true;
            if (String.IsNullOrEmpty(instruCmd)) return false;
            if (!bOpen) return false;

            try
            {
                IO_Obj.WriteString(instruCmd, true);
            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        public bool Read(ref string instruRdCmd)
        {
            bool ret = true;
            try
            {
                instruRdCmd = IO_Obj.ReadString();
            }
            catch {
                instruRdCmd = "Device,Read Err,Connection,Fail";
                ret = false;
            }    
            return ret;
        }

        public bool ToughRead(ref string instruRdCmd)
        {
            bool ret = true;
            if (!bOpen) return false;
            try
            {
                instruRdCmd = IO_Obj.ReadString();
            }
            catch
            {
                instruRdCmd = "Device,Read Err,Connection,Fail";
                ret = false;
            }
            return ret;
        }

        public bool SendRead(string instruCmd, ref string instruRdCmd)
        {

            IO_Obj.FlushRead();
            if (!Send(instruCmd)) return false;
            System.Threading.Thread.Sleep(150);  //20170731 add
            if (!Read(ref instruRdCmd)) return false;
            return true;

        }

        public bool ToughSendRead(string instruCmd, ref string instruRdCmd)
        {
            if (!bOpen) return false;
            IO_Obj.FlushRead();
            if (!ToughSend(instruCmd)) return false;
            System.Threading.Thread.Sleep(200);  //20170731 add
            if (!ToughRead(ref instruRdCmd)) return false;
            return true;

        }

        public bool SimpleSendRead(string instruAddr, string instruCmd, ref string intruRdstr)
        {
            bool ret = true;
            if (!Open(instruAddr)) return false;
            if (!SendRead(instruCmd, ref intruRdstr)) ret = false; ;
            Close();
            return ret;            
        }

        public bool SimpleSend(string instruAddr, string instruCmd)   //20170731 add
        {
            bool ret = true;
            if (!Open(instruAddr)) return false;
            if (!Send(instruCmd)) return false;
            //if (!SendRead(instruCmd, ref intruRdstr)) ret = false; 
            Close();
            return ret;
        }
    

        public bool Close()
        {
            try
            {
                IO_Obj.IO.Close();
            }
            catch { }

            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(IO_Obj);
            }
            catch { }

            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Rm);
            }
            catch { }

            Rm = null;
            IO_Obj = null;
            bOpen = false;
            return true;
        }

        public string[] SearchAllEquip()
        {
            ResourceManager Rm = new ResourceManager();
            ResourceManagerClass Rmc = new ResourceManagerClass();
            string[] devices = null;
            try
            {
                devices = Rm.FindRsrc("?*INSTR");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return devices;
        }

        public string[] SearchEquipWithComm()
        {
            ResourceManager Rm = new ResourceManager();
            ResourceManagerClass Rmc = new ResourceManagerClass();
            return Rm.FindRsrc("ASRL?*INSTR{VI_ATTR_ASRL_BAUD == 9600}");
        }

        public void  SetInstruName(string InstruName, string NickName)
        {
            this.InstruName = InstruName;
            this.InstruNickName = NickName;
        }
#endif
        public bool IsOpen(){return (bOpen == true) ? true : false;   }
        public string GetInstruNickName() { return this.InstruNickName; }
        public string GetInstrName() { return this.InstruName; }

        public string[] VisaSearchEuqip()
        {
            string[] EquitDev = new string[100];
            VisaUtil.Find_MeasureResource(EquitDev, out uint DevNum);
            Array.Resize(ref EquitDev, (int)DevNum);
            return EquitDev;
        }

        public bool VisaOpen()
        {
            VisaUtil = new XM_Visa_Util(InstruName);
            VisaUtil.VisaOpen();
            bOpen = true;
            return true;
        }

        public void VisaClose()
        {
            VisaUtil.Close();
            bOpen = false;
        }

        public bool VisaSendRead(string Command,ref string Msg)
        {
            StringBuilder Result = new StringBuilder(1000);
            Result = VisaUtil.DoSendRead(Command);
            Msg = Result.ToString();
            return true;
        }

        public bool VisaSend(string Command)
        {
            VisaUtil.DoSendCommand(Command);
            return true;
        }

        public bool VisaRead(ref string Msg)
        {
            Msg = VisaUtil.QueryCommand();
            return true;
        }
    }
}

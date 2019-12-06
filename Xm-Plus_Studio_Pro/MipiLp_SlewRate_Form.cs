using System;
using System.Windows.Forms;
using Ivi.Visa.Interop;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class MipiLp_SlewRate_Form : Form
    {
         
        public MipiLp_SlewRate_Form()
        {
            InitializeComponent();
            
        }
        private void DoInstrumentIO(string addr)
        {
            XM_EquipVisa_Util EquipDev = new  XM_EquipVisa_Util(addr);
            string devStr = null;
            bool ret = true;
            try
            {
                ret = EquipDev.VisaOpen();
                EquipDev.VisaSendandRead("*IDN?",out devStr);
                Cbx_Item.Items.Add(addr + " ; " + devStr);
                EquipDev.VisaClose();
            }
            catch (Exception e)
            {
                Log.F(this.GetType().FullName, "DoInstrumentIO():" + e.Message);
                Cbx_Item.Items.Add("Can't open ; " + addr);
            }
            finally
            {
                try {

                    EquipDev.VisaClose();
                    EquipDev = null;
                }
                catch { }
               
            }
            if(EquipDev != null) EquipDev.VisaClose();
        }
        private void Start_Test_Click(object sender, EventArgs e)
        {
            string str=null,addr = Cbx_Item.SelectedItem.ToString();
            char[] delimiterChars = { ';' };
            string[] words = addr.Split(delimiterChars);
            double x1 =0, y1 = 0, x2 = 0, y2 = 0, deltaX = 0, deltaY = 0, step = 0, slewrate = 0;
       
            DataGridViewRowCollection rows = DataGridView1.Rows;
            XM_EquipVisa_Util EquipDev = new XM_EquipVisa_Util(words[0].Trim());
            bool ret = EquipDev.VisaOpen();
            EquipDev.SetTimeoutSeconds("500");
            EquipDev.VisaSendandRead("*IDN?", out string devStr);

            if (radioButton_1585.Checked)
            {     
                EquipDev.VisaSend(":MEASure:CLEar");
                Thread.Sleep(100);
                //initial trigger 15%~85%
                EquipDev.VisaSend(":MEASure:RISetime CHANNEL2");
                EquipDev.VisaSend(":MEASure:THResholds:PERCent CHANNEL2,85,50,15");
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,PERCent");
                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MARKer:X1Position?", out devStr);
                x1 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y1Position?", out devStr);
                y1 = double.Parse(devStr.ToString());
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:X2Position?", out devStr);
                x2 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y2Position?", out devStr);
                Thread.Sleep(100);
                y2 = double.Parse(devStr);
                Application.DoEvents();

                deltaX = x2 - x1;
                deltaY = y2 - y1;
                step = deltaY / 4;

                //measure 15% slew rate (y1+50mV)
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                EquipDev.VisaSend(":SYSTem: HEADer OFF");
                
                str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05).ToString() + "," + (((y1 + 0.05) + y1) / 2).ToString() + "," + y1.ToString() ;
                EquipDev.VisaSend(str);
                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MEASure:RISetime? CHANnel2", out devStr);
                slewrate = double.Parse(devStr);              
                rows.Add(new Object[] { (((y1 + 0.05) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Rise" });
                Thread.Sleep(500);
                Application.DoEvents();

                for (int i = 1; i <= 4; i++)
                {
                    //measure y1 + 50mV + step
                    EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                    str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05 + step * i).ToString() + "," + (((y1 + 0.05 + step * i) + y1) / 2).ToString() + "," + (y1 + step * i).ToString() ;
                    EquipDev.VisaSend(str);
                    EquipDev.VisaSend(":MARKer:MODE MEASurement");
                    EquipDev.VisaSendandRead(":MEASure:RISetime? CHANnel2", out devStr);
                    Thread.Sleep(100);
                    slewrate = double.Parse(devStr);
                    rows.Add(new Object[] { (((y1 + 0.05 + step * i) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Rise" });
                    Thread.Sleep(500);
                    Application.DoEvents();
                }

                //FALL
                EquipDev.VisaSend(":MEASure:CLEar");
                Thread.Sleep(100);
                //initial trigger 15%~85%
                EquipDev.VisaSend(":MEASure:FALLtime CHANNEL2");
                EquipDev.VisaSend(":MEASure:THResholds:PERCent CHANNEL2,85,50,15");
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,PERCent");
                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MARKer:X1Position?",out devStr);
                Thread.Sleep(100);
                x1 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y1Position?",  out devStr);
                y1 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:X2Position?" ,out devStr);

                Thread.Sleep(100);
                x2 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y2Position?",  out devStr);
                Thread.Sleep(100);
                y2 = double.Parse(devStr);
                Application.DoEvents();

                deltaX = x2 - x1;
                deltaY = y2 - y1;
                step = deltaY / 4;
 
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05).ToString() + "," + (((y1 + 0.05) + y1) / 2).ToString() + "," + y1.ToString() ;
                EquipDev.VisaSend(str);
                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MEASure:FALLtime? CHANNEL2", out devStr);
                slewrate = double.Parse(devStr);
                rows.Add(new Object[] { (((y1 + 0.05) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Fall" });
                Thread.Sleep(500);
                Application.DoEvents();

                for (int i = 1; i <= 4; i++)
                {
                    //measure y1 + 50mV + step
                    EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                    str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05 + step * i).ToString() + "," + (((y1 + 0.05 + step * i) + y1) / 2).ToString() + "," + (y1 + step * i).ToString() ;
                    EquipDev.VisaSend(str);
                    EquipDev.VisaSend(":MARKer:MODE MEASurement");
                    EquipDev.VisaSendandRead(":MEASure:FALLtime? CHANNEL2", out devStr);
                    slewrate = double.Parse(devStr);
                    rows.Add(new Object[] { (((y1 + 0.05 + step * i) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Fall" });
                    Thread.Sleep(500);
                    Application.DoEvents();
                }
            }
            else if (radioButton_400700.Checked) //400~700
            {
                EquipDev.VisaSend(":MEASure:CLEar");
                Thread.Sleep(100);
                //initial trigger 400~700mV
                EquipDev.VisaSend(":MEASure:RISetime CHANNEL2");
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                str = ":MEASure:THResholds:ABSolute CHANNEL2,0.7,0.55,0.4";
                EquipDev.VisaSend(str);

                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MARKer:X1Position?",out devStr);
                x1 = double.Parse(devStr);
                Application.DoEvents();

                EquipDev.VisaSendandRead(":MARKer:Y1Position?", out devStr);
                Thread.Sleep(100);
                y1 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:X2Position?", out devStr);
                Thread.Sleep(100);
                x2 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y2Position?", out devStr);
                Thread.Sleep(100);
                y2 = double.Parse(devStr);
                Application.DoEvents();

                deltaX = x2 - x1;
                deltaY = y2 - y1;
                step = deltaY / 4;

                //measure 15% slew rate (y1+50mV)
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05).ToString() + "," + (((y1 + 0.05) + y1) / 2).ToString() + "," + y1.ToString() ;
                EquipDev.VisaSend(str);
                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MEASure:RISetime? CHANNEL2", out devStr);
               
                Thread.Sleep(100);
                slewrate = double.Parse(devStr);

                rows.Add(new Object[] { (((y1 + 0.05) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Rise" });
                Thread.Sleep(500);
                Application.DoEvents();

                for (int i = 1; i <= 4; i++)
                {
                    //measure y1 + 50mV + step
                    EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                    str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05 + step * i).ToString() + "," + (((y1 + 0.05 + step * i) + y1) / 2).ToString() + "," + (y1 + step * i).ToString() ;
                    EquipDev.VisaSend(str);
                    EquipDev.VisaSend(":MARKer:MODE MEASurement");
                    EquipDev.VisaSendandRead(":MEASure:RISetime? CHANNEL2", out devStr);

                    Thread.Sleep(100);
                    slewrate = double.Parse(devStr);
                    rows.Add(new Object[] { (((y1 + 0.05 + step * i) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Rise" });
                    Thread.Sleep(500);
                    Application.DoEvents();
                }

                //FALL
                EquipDev.VisaSend(":MEASure:CLEar");
                Thread.Sleep(100);
                //initial trigger 15%~85%
                EquipDev.VisaSend(":MEASure:FALLtime CHANNEL2");
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                str = ":MEASure:THResholds:ABSolute CHANNEL2,0.93,0.665,0.4";
                EquipDev.VisaSend(str);
                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MARKer:X1Position?",out devStr);
               
                Thread.Sleep(100);
                x1 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y1Position?",  out devStr);
                Thread.Sleep(100);
                y1 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:X2Position?", out devStr);
                Thread.Sleep(100);
                x2 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y2Position?",  out devStr);             
                Thread.Sleep(100);
                y2 = double.Parse(devStr);
                Application.DoEvents();

                deltaX = x2 - x1;
                deltaY = y2 - y1;
                step = deltaY / 4;

                //measure 15% slew rate (y1+50mV)
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05).ToString() + "," + (((y1 + 0.05) + y1) / 2).ToString() + "," + y1.ToString() ;
                EquipDev.VisaSend(str);
                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MEASure:FALLtime? CHANNEL2", out devStr);
               
                Thread.Sleep(100);
                slewrate = double.Parse(devStr);
                rows.Add(new Object[] { (((y1 + 0.05) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Fall" });
                Thread.Sleep(500);
                Application.DoEvents();

                for (int i = 1; i <= 4; i++)
                {
                    //measure y1 + 50mV + step
                    EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                    str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05 + step * i).ToString() + "," + (((y1 + 0.05 + step * i) + y1) / 2).ToString() + "," + (y1 + step * i).ToString() ;
                    EquipDev.VisaSend(str);
                    EquipDev.VisaSend(":MARKer:MODE MEASurement");
                    EquipDev.VisaSendandRead(":MEASure:FALLtime? CHANNEL2", out devStr);
                    Thread.Sleep(100);
                    slewrate = double.Parse(devStr);
                    rows.Add(new Object[] { (((y1 + 0.05 + step * i) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Fall" });
                    Thread.Sleep(500);
                    Application.DoEvents();
                }
            }
            else
            {
                EquipDev.VisaSend(":MEASure:CLEar");
                Thread.Sleep(100);
                //initial trigger 700~950mV
                EquipDev.VisaSend(":MEASure:RISetime CHANNEL2");
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                str = ":MEASure:THResholds:ABSolute CHANNEL2,0.95,0.825,0.7";
                EquipDev.VisaSend(str);

                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MARKer:X1Position?",out devStr);
                Thread.Sleep(100);
                x1 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y1Position?", out devStr);
                Thread.Sleep(100);
                y1 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:X2Position?", out devStr);
                Thread.Sleep(100);
                x2 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y2Position?", out devStr);
                
                Thread.Sleep(100);
                y2 = double.Parse(devStr);
                Application.DoEvents();

                deltaX = x2 - x1;
                deltaY = y2 - y1;
                step = deltaY / 4;

                //measure 15% slew rate (y1+50mV)
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05).ToString() + "," + (((y1 + 0.05) + y1) / 2).ToString() + "," + y1.ToString() ;
                EquipDev.VisaSend(str);
                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MEASure:RISetime? CHANNEL2", out devStr);

                Thread.Sleep(100);
                slewrate = double.Parse(devStr);

                rows.Add(new Object[] { (((y1 + 0.05) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Rise" });
                Thread.Sleep(500);
                Application.DoEvents();

                for (int i = 1; i <= 4; i++)
                {
                    //measure y1 + 50mV + step
                    EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                    str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05 + step * i).ToString() + "," + (((y1 + 0.05 + step * i) + y1) / 2).ToString() + "," + (y1 + step * i).ToString() ;
                    EquipDev.VisaSend(str);
                    EquipDev.VisaSend(":MARKer:MODE MEASurement");
                    EquipDev.VisaSendandRead(":MEASure:RISetime? CHANNEL2", out devStr);

                    Thread.Sleep(100);
                    slewrate = double.Parse(devStr);
                    rows.Add(new Object[] { (((y1 + 0.05 + step * i) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Rise" });
                    Thread.Sleep(500);
                    Application.DoEvents();
                }

                //FALL
                EquipDev.VisaSend(":MEASure:CLEar");
                Thread.Sleep(100);
                //initial trigger 15%~85%
                EquipDev.VisaSend(":MEASure:FALLtime CHANNEL2");
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                str = ":MEASure:THResholds:ABSolute CHANNEL2,0.95,0.825,0.7";
                EquipDev.VisaSend(str);
                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MARKer:X1Position?", out devStr);

                Thread.Sleep(100);
                x1 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y1Position?", out devStr);
  
                Thread.Sleep(100);
                y1 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:X2Position?", out devStr);
               
                Thread.Sleep(100);
                x2 = double.Parse(devStr);
                Application.DoEvents();
                EquipDev.VisaSendandRead(":MARKer:Y2Position?",out  devStr);

                Thread.Sleep(100);
                y2 = double.Parse(devStr);
                Application.DoEvents();

                deltaX = x2 - x1;
                deltaY = y2 - y1;
                step = deltaY / 4;

                //measure 15% slew rate (y1+50mV)
                EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05).ToString() + "," + (((y1 + 0.05) + y1) / 2).ToString() + "," + y1.ToString() ;
                EquipDev.VisaSend(str);
                EquipDev.VisaSend(":MARKer:MODE MEASurement");
                EquipDev.VisaSendandRead(":MEASure:FALLtime? CHANNEL2", out devStr);
                Thread.Sleep(100);
                slewrate = double.Parse(devStr);
                rows.Add(new Object[] { (((y1 + 0.05) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Fall" });
                Thread.Sleep(500);
                Application.DoEvents();

                for (int i = 1; i <= 4; i++)
                {
                    //measure y1 + 50mV + step
                    EquipDev.VisaSend(":MEASure:THResholds:METHod CHANNEL2,ABSolute");
                    str = ":MEASure:THResholds:ABSolute CHANNEL2," + (y1 + 0.05 + step * i).ToString() + "," + (((y1 + 0.05 + step * i) + y1) / 2).ToString() + "," + (y1 + step * i).ToString() ;
                    EquipDev.VisaSend(str);
                    EquipDev.VisaSend(":MARKer:MODE MEASurement");
                    EquipDev.VisaSendandRead(":MEASure:FALLtime? CHANNEL2", out devStr);
                    //rdItems = (object[])ioobj.ReadList(IEEEASCIIType.ASCIIType_Any, ",");
                    Thread.Sleep(100);
                    slewrate = double.Parse(devStr);
                    rows.Add(new Object[] { (((y1 + 0.05 + step * i) + y1) / 2), slewrate * 1000000000, 0.05 / slewrate / 1000000, "Fall" });
                    Thread.Sleep(500);
                    Application.DoEvents();
                }
            }



            EquipDev.VisaClose();

        }

        private void Cbx_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbx_Item.SelectedItem == null)
                start_test.Enabled = false;
            else
                start_test.Enabled = true;
        }

        private void MIPI_LP_SLEW_RATE_TEST_Load(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager();
            string[] address = rm.FindRsrc("?*INSTR");
            if (Cbx_Item.SelectedItem == null)
                start_test.Enabled = false;
            else
                start_test.Enabled = true;

            foreach (string i in address)
            {
                if (i.Contains("ASRL"))
                    continue;
                DoInstrumentIO(i);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ivi.Visa.Interop;
using System.Threading;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class PWM_Measure : Form
    {
        public static bool stop = false;
        public static int i = 0;
        string rdStrTemp = null;

        XM_EquipVisa_Util XM_EquipVisa;

        public PWM_Measure()
        {
            InitializeComponent();
        }

        private void DoInstrumentIO(string addr)
        {
            XM_EquipVisa= new XM_EquipVisa_Util();
            XM_EquipVisa = new  XM_EquipVisa_Util(addr);
            try
            {
                XM_EquipVisa.SetTimeoutSeconds("500");
                XM_EquipVisa.VisaSendandRead("*IDN?", out rdStrTemp);
                Cbo_PwmItem.Items.Add(addr + " ; "+ rdStrTemp.ToString());
            }
            catch (Exception e)
            {
                Log.F(this.GetType().FullName, "DoInstrumentIO() :" + e.Message);       
                Cbo_PwmItem.Items.Add("Can't open ; " + addr);
            }
            finally
            {
                try { XM_EquipVisa.VisaClose(); }
                catch { }
                try
                {
                    XM_EquipVisa.VisaClose();
                }
                catch { }
                try
                {
                    XM_EquipVisa.VisaClose();
                }
                catch { }
            }
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
    
        //}

        private void Btn_Measure_Click(object sender, EventArgs e)
        {
            string addr = null;
            XM_ExeWol_Util WhiskeyUtil = new XM_ExeWol_Util();
            stop = false;
            Btn_Suspend.BackColor = System.Drawing.Color.FromArgb(255, 153, 0);
            Btn_Suspend.Text = "Suspend";


          //  WhiskeyUtil.MipiBridgeSelect(0x01);
            WhiskeyUtil.SetFpgaTiming(0x33, 0x11, 0x13, 0xff, 0x20, 0x0a);
            WhiskeyUtil.SetMipiVideo(1920, 1080, 60, 16, 16, 10, 10, 4, 4);
            WhiskeyUtil.SetMipiDsi(4, 780, "burst");

            WhiskeyUtil.GpioCtrl(0x11, 0x10, 0x07);

            Thread.Sleep(10);
            WhiskeyUtil.GpioCtrl(0x11, 0x00, 0x07);
            Thread.Sleep(5);
            WhiskeyUtil.GpioCtrl(0x11, 0x10, 0x07);
            Thread.Sleep(10);

            //MIPI CD disable
            WhiskeyUtil.MipiWrite(0x29, 0xff, 0x21, 0x30, 0x40);
            WhiskeyUtil.MipiWrite(0x23, 0x6b, 0xfe);


            //OSC bias always on
            WhiskeyUtil.MipiWrite(0x29, 0xff, 0x21, 0x30, 0x44);
            WhiskeyUtil.MipiWrite(0x23, 0x03, 0x03);

            // GVDDN on
            WhiskeyUtil.MipiWrite(0x29, 0xff, 0x21, 0x30, 0x12);
            WhiskeyUtil.MipiWrite(0x23, 0x6c, 0x03);

            //PWM
            // GVDDN on
            WhiskeyUtil.MipiWrite(0x29, 0xff, 0x21, 0x30, 0x25);
            WhiskeyUtil.MipiWrite(0x23, 0x04, 0x06);

            WhiskeyUtil.MipiWrite(0x29, 0xff, 0x21, 0x30, 0x00);



            addr = Cbo_PwmItem.SelectedItem.ToString();
            
            char[] delimiterChars = { ';' };
            string[] words = addr.Split(delimiterChars);
            double Freq = 0, Duty = 0, Width=0;

            XM_EquipVisa.SetTimeoutSeconds("500");
            XM_EquipVisa.VisaSendandRead("*IDN?", out rdStrTemp);

            XM_EquipVisa.VisaSend("*RST");//Oscilloscope reset
            XM_EquipVisa.VisaSend(":AUTOSCALE");//Oscilloscope AUTOSCALE
            Thread.Sleep(8000);

            XM_EquipVisa.VisaSend(":CHANnel1:DISPlay 0");
            XM_EquipVisa.VisaSend(":CHANnel2:DISPlay 1");
            XM_EquipVisa.VisaSend(":CHANnel3:DISPlay 0");
            XM_EquipVisa.VisaSend(":CHANnel4:DISPlay 0");
       


            for (i = 0; i < 256; i++)
            {
                if (stop)
                {
                    stop = false;
                    /* Close session */
                    //ioobj.IO.Close();
                    break;
                    //MessageBox.Show("Progress Suspend " + i+"%");
                }

                WhiskeyUtil.MipiWrite(0x05, 0x28);
                Thread.Sleep(100);
                WhiskeyUtil.MipiWrite(0x05, 0x10);

                WhiskeyUtil.MipiWrite(0x29, 0x51, (byte)i, 0);
                WhiskeyUtil.MipiWrite(0x23, 0x53, 0x24);
                WhiskeyUtil.MipiWrite(0x23, 0x55, 0x01);

                WhiskeyUtil.MipiWrite(0x05, 0x11);
                Thread.Sleep(120);
                WhiskeyUtil.MipiWrite(0x05, 0x29);
                WhiskeyUtil.ImageFill(255, 255, 255);




                /* AUTOSCALE - This command evaluates all the input signals and
                * sets the correct conditions to display all of the active signals.
                */
                //		ioobj.WriteString(":AUTOSCALE\n");
                //		 Thread.Sleep(200);

                /* CHANNEL_PROBE - Sets the probe attenuation factor for the
                * selected channel.  The probe attenuation factor may be from
                * 0.1 to 1000.
                */
                //   ioobj.WriteString(":CHAN1:PROBE 10\n");

                /* CHANNEL_RANGE - Sets the full scale vertical range in volts.
                * The range value is eight times the volts per division.
                */
                //   ioobj.WriteString(":CHANNEL1:RANGE 8\n");

                /* TIME_RANGE - Sets the full scale horizontal time in seconds.
                * The range value is ten times the time per division.
                */
                XM_EquipVisa.VisaSend(":TIM:RANG 2e-3");

                /* TIME_REFERENCE - Possible values are LEFT and CENTER:
                *  - LEFT sets the display reference one time division from the
                *    left.
                *  - CENTER sets the display reference to the center of the screen.
                */
                XM_EquipVisa.VisaSend(":TIMEBASE:REFERENCE CENTER");

                /* TRIGGER_SOURCE - Selects the channel that actually produces the
                * TV trigger.  Any channel can be selected.
                */
                XM_EquipVisa.VisaSend(":TRIGGER:TV:SOURCE CHANNEL2");

                /* TRIGGER_MODE - Set the trigger mode to, EDGE, GLITch, PATTern,
                * CAN, DURation, IIC, LIN, SEQuence, SPI, TV, or USB.
                */
                XM_EquipVisa.VisaSend(":TRIGGER:MODE EDGE");

                /* TRIGGER_EDGE_SLOPE - Set the slope of the edge for the trigger
                * to either POSITIVE or NEGATIVE.
                */

                XM_EquipVisa.VisaSend(":TRIGGER:EDGE:SLOPE POSITIVE");


                //image.fill i,i,i;

                XM_EquipVisa.VisaSend(":TIMebase:RANGe 1ms");

 
                Thread.Sleep(100);
                Application.DoEvents();

                XM_EquipVisa.VisaSend(":CHANnel2:SCALe 1V");
                XM_EquipVisa.VisaSend(":TIMebase:RANGe 1ms");

                XM_EquipVisa.VisaSend(":TRIGger:EDGE:LEVel 0.5,CHANnel2");

  
                Thread.Sleep(100);
                Application.DoEvents();


                //ioobj.WriteString(":STOP\n");
                XM_EquipVisa.VisaSend(":MEASure:FREQuency CHANNEL2");
                XM_EquipVisa.VisaSend(":MEASure:FREQuency?");
                XM_EquipVisa.VisaRead(out rdStrTemp);
                Thread.Sleep(10);
                Freq = double.Parse(rdStrTemp.ToString());
                Application.DoEvents();


                //ioobj.WriteString(":STOP\n");
                XM_EquipVisa.VisaSend(":MEASure:DUTY CHANNEL2");
                XM_EquipVisa.VisaSend(":MEASure:DUTY?");
                XM_EquipVisa.VisaRead(out rdStrTemp);
                Thread.Sleep(10);
                Freq = double.Parse(rdStrTemp.ToString());
                Application.DoEvents();

                //		ioobj.WriteString(":STOP\n");
                XM_EquipVisa.VisaSend(":MEASure:PWIDth CHANNEL2");
                XM_EquipVisa.VisaSend(":MEASure:PWIDth?");
                XM_EquipVisa.VisaRead(out rdStrTemp);
                Thread.Sleep(10);
                Width = double.Parse(rdStrTemp.ToString()) * 1000 * 1000;
                Application.DoEvents();

                DataGridViewRowCollection rows = dataGridView1.Rows;
                rows.Add(new Object[] { i.ToString(), Freq.ToString(), Duty.ToString(), Width.ToString() });

                label1.Text = i + "/255";
                progressBar1.Value = i;

                Application.DoEvents();

            }
            if (i == 255)
            {
                Btn_Suspend.Text = "Finish";
                Btn_Suspend.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);

            }

            // Close session 
            XM_EquipVisa.VisaClose();



        }

        private void Btn_Suspend_Click(object sender, EventArgs e)
        {
            stop = true;
            Btn_Suspend.Text = "Reseum";
            Btn_Suspend.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
            XM_EquipVisa.VisaClose();
        }

        private void Cbo_PwmItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_PwmItem.SelectedItem == null)
                Btn_Measure.Enabled = false;
            else
                Btn_Measure.Enabled = true;
        }

        private void PWM_Measure_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            XM_EquipVisa = new XM_EquipVisa_Util();
            string[] address =new string[128];
            XM_EquipVisa.Find_MeasureResource(address, out uint num);
            if (Cbo_PwmItem.SelectedItem == null)
                Btn_Measure.Enabled = false;
            else
                Btn_Measure.Enabled = true;

            foreach (string i in address)
            {
                DoInstrumentIO(i);
            }
        }
    }
}

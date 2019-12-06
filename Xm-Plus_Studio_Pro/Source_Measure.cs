using System;
using System.Windows.Forms;
using Ivi.Visa.Interop;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class Source_Measure : Form
    {
        Excel.Application excelApp = new Excel.Application();
        Excel._Workbook wBook;
        Excel._Worksheet wSheet;
        Excel.Range wRange;
        public int[] StartPoint = new int[2] { 0, 0 };  // StartPoint[1] = vertical, StartPoint[0] = horizontal 

        public static bool stop = false;
        public static int i = 0;
        public static string FilePath = "";
        public static bool FileReady = false;
        public static double Triger_Voltage=1.2;
        System.Timers.Timer t = new System.Timers.Timer(100);   //实例化Timer类，设置间隔时间为100毫秒； 

        XM_EquipVisa_Util XM_EquipVisa;
        string rdStrTemp = null;
       


        public Source_Measure()
        {
            InitializeComponent();
             
            t.Elapsed += new System.Timers.ElapsedEventHandler(Reflesh_Excel_Cell); //到达时间的时候执行事件；   
            t.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
         //   t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   

        }
        private void DoInstrumentIO(string addr)
        {
            XM_EquipVisa = new XM_EquipVisa_Util(addr);
            try
            {
                XM_EquipVisa.SetTimeoutSeconds("3");
                XM_EquipVisa.VisaSendandRead("*IDN?", out rdStrTemp);

                if (!String.IsNullOrEmpty(rdStrTemp))
                {
                    if (rdStrTemp.Contains("MSO"))//agilent
                    {
                        Cbx_Item.Items.Add((addr) + " ; " + rdStrTemp.ToString());
                        
                    }
                    else if (rdStrTemp.Contains("DSO"))//agilent
                    {
                        Cbx_Item.Items.Add((addr) + " ; " + rdStrTemp.ToString());
                        XM_EquipVisa = new XM_EquipVisa_Util(addr);
                    }
                    else if (rdStrTemp.Contains("DPO"))//Tektronix
                    {
                        Cbx_Item.Items.Add((addr) + " ; " + rdStrTemp.ToString());
                        XM_EquipVisa = new XM_EquipVisa_Util(addr);
                    }
                }
            }
            catch (Exception e)
            {
                Log.F(this.GetType().FullName, "DoInstrumentIO():" + e.Message);       
                Cbx_Item.Items.Add("Can't open ; " + addr);
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

        private void Btn_Measure_Click(object sender, EventArgs e)
        {
           
            double[] Mea_Data = new double[1];
            int Start = int.Parse(comboBox_Source_Measure_Start.Text);
            int End = int.Parse(comboBox_Source_Measure_End.Text);

            XM_ExeWol_Util WhiskeyUtil = new XM_ExeWol_Util();
            stop = false;
            Btn_Suspend.BackColor = System.Drawing.Color.FromArgb(255, 153, 0);
            Btn_Suspend.Text = "Suspend";

            string addr = null;
            addr = Cbx_Item.SelectedItem.ToString();
            char[] delimiterChars = { ';' };
            string[] words = addr.Split(delimiterChars);

            double stdv, vmin, offset;

            XM_EquipVisa.SetTimeoutSeconds("3");

            XM_EquipVisa.VisaSend("*RST");//Oscilloscope reset
            XM_EquipVisa.VisaSend(":AUTOSCALE");//Oscilloscope AUTOSCALE

            ChangetoInt(TxtBox_Excel_Cell.Text, StartPoint);

            StartPoint[1] += int.Parse(comboBox_Source_Measure_Start.Text);


            //StartPoint[0] = int.Parse(textBox_Vertical.Text);
            //StartPoint[1] = int.Parse(textBox_Horizontal.Text);

            /*Wait Autoscale done*/
            Thread.Sleep(3000);

            for (i = Start; i <= End; i++)
            {
                if (stop)
                {
                    stop = false;
                    /* Close session */
                    //ioobj.IO.Close();
                    break;
                    //MessageBox.Show("Progress Suspend " + i+"%");
                }

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
                XM_EquipVisa.VisaSend(":TIM:RANG 2e-3");//' Set the time range to 0.002 seconds.

                /* TIME_REFERENCE - Possible values are LEFT and CENTER:
                *  - LEFT sets the display reference one time division from the
                *    left.
                *  - CENTER sets the display reference to the center of the screen.
                */
                XM_EquipVisa.VisaSend(":TIMEBASE:REFERENCE CENTER");

                /* TRIGGER_SOURCE - Selects the channel that actually produces the
                * TV trigger.  Any channel can be selected.
                */
                XM_EquipVisa.VisaSend(":TRIGGER:TV:SOURCE CHANNEL1");

                /* TRIGGER_MODE - Set the trigger mode to, EDGE, GLITch, PATTern,
                * CAN, DURation, IIC, LIN, SEQuence, SPI, TV, or USB.
                */
                XM_EquipVisa.VisaSend(":TRIGGER:MODE EDGE");

                /* TRIGGER_EDGE_SLOPE - Set the slope of the edge for the trigger
                * to either POSITIVE or NEGATIVE.
                */
                if (comboBox2.Text == "Positive")
                    XM_EquipVisa.VisaSend(":TRIGGER:EDGE:SLOPE POSITIVE");
                else
                    XM_EquipVisa.VisaSend(":TRIGGER:EDGE:SLOPE NEGATIVE");

                XM_EquipVisa.VisaSend(":CHANnel1:OFFSet 0 V");
                XM_EquipVisa.VisaSend(":CHANnel1:SCALe  1.12 V");

                /* Send full screen pattern for source measure
                 */
                // Device.MipiOpen("com22");                          //設定 Elecs Comm Port
                //Device.MipiWrite("image.fill "+ i.ToString() +" "+i.ToString() +" "+i.ToString());
                WhiskeyUtil.ImageFill((byte)i, (byte)i, (byte)i);
                //image.fill i,i,i;
                Thread.Sleep(200);
                XM_EquipVisa.VisaSend(":TIMebase:RANGe 100ms");
                if (comboBox2.Text == "Positive")
                {
                    XM_EquipVisa.VisaSend(":MEASure:VTOP CHANNEL1");
                    XM_EquipVisa.VisaSend(":MEASure:VTOP?");
                }
                else
                {
                    XM_EquipVisa.VisaSend(":MEASure:VBASe CHANNEL1");
                    XM_EquipVisa.VisaSend(":MEASure:VBASe?");
                }
                Thread.Sleep(1000);
                Application.DoEvents();
                // ioobj.WriteString("MEASure:VOLTage:DC? MAX,DEF");//test by usinf 34401

                XM_EquipVisa.VisaRead(out rdStrTemp);
                stdv = double.Parse(rdStrTemp);
                if (comboBox2.Text == "Positive")
                {
                    offset = stdv;
                   XM_EquipVisa.VisaSend(":TRIGger:EDGE:LEVel 0.12, CHANnel1");
                }
                else
                {
                    offset = stdv;
                    XM_EquipVisa.VisaSend(":TRIGger:EDGE:LEVel -0.12, CHANnel1");
                }
                XM_EquipVisa.VisaSend(":CHANnel4:SCALe 200mV");
                
                XM_EquipVisa.VisaSend(string.Concat(":CHANnel4:OFFSet ", offset));
                XM_EquipVisa.VisaSend(":TIMebase:RANGe 500us");
                XM_EquipVisa.VisaSend(":TIMebase:POSition 2.5E-3");
                Thread.Sleep(500);
                Application.DoEvents();
  
                XM_EquipVisa.VisaSend(":MEASure:VAVerage CHANNEL4");
                XM_EquipVisa.VisaSend(":MEASure:VAVerage?");
                XM_EquipVisa.VisaRead(out rdStrTemp);
                Thread.Sleep(100);
                Mea_Data [0] = vmin = double.Parse(rdStrTemp.ToString());
                Application.DoEvents();

                if(!checkBox_Disable_Excel_Setting.Checked)
                {
                    Excel_Data_Save(Mea_Data, excelApp, CboBox_Excel_Sheet.Text, ref StartPoint, 2);
                    Application.DoEvents();
                }

                DataGridViewRowCollection rows = dataGridView1.Rows;
                rows.Add(new Object[] { i, vmin, comboBox2.Text });

                Lbl_Info.Text = i + "/" + comboBox_Source_Measure_End.Text;
                if(int.Parse(comboBox_Source_Measure_End.Text) == int.Parse(comboBox_Source_Measure_Start.Text)) progressBar1.Value = 100;
                else progressBar1.Value =(int) ((i- int.Parse(comboBox_Source_Measure_Start.Text))/ (int.Parse(comboBox_Source_Measure_End.Text)- int.Parse(comboBox_Source_Measure_Start.Text)))*100;

                Application.DoEvents();

            }
            if (i == 255)
            {
                Btn_Suspend.Text = "Finish";
                Btn_Suspend.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);

            }

        }

        private void Btn_Suspend_Click(object sender, EventArgs e)
        {
            stop = true;
            Btn_Suspend.Text = "Reseum";
            Btn_Suspend.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
        }

        private void Cbx_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbx_Item.SelectedItem == null)
                Btn_Measure.Enabled = false;
            else
                Btn_Measure.Enabled = true;
            XM_EquipVisa = new XM_EquipVisa_Util(Cbx_Item.Text.Remove(Cbx_Item.Text.IndexOf(";")));
        }

        private void Source_Measure_Load(object sender, EventArgs e)
        {
           
            
            Lbl_Info.BackColor = System.Drawing.Color.Transparent;
         
            if (Cbx_Item.SelectedItem == null)
                Btn_Measure.Enabled = false;
            else
                Btn_Measure.Enabled = true;
           
            for (int i = 0; i <=255 ; i++)
            {
                comboBox_Source_Measure_Start.Items.Add(i);
                comboBox_Source_Measure_End.Items.Add(i);
            }
            comboBox_Source_Measure_Start.Text = "0";
            comboBox_Source_Measure_End.Text = "255";
            Lbl_Info.Text = Lbl_Info.Text = comboBox_Source_Measure_Start.Text + "/" + comboBox_Source_Measure_End.Text;


        }

        private void CboBox_Source_Measure_Start_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lbl_Info.Text = comboBox_Source_Measure_Start.Text + "/" + comboBox_Source_Measure_End.Text;
        }

        private void CboBox_Source_Measure_End_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lbl_Info.Text = comboBox_Source_Measure_Start.Text + "/" + comboBox_Source_Measure_End.Text;
        }

        private bool Excel_Open(Excel.Application excelApp, string FilePath)
        {
            // 讓Excel文件可見
            excelApp.Visible = true;

            // 停用警告訊息
            excelApp.DisplayAlerts = false;

            excelApp.Workbooks.Open(FilePath);
            Thread.Sleep(500);
            // 引用第一個活頁簿
            wBook = excelApp.Workbooks[1];
            Thread.Sleep(500);

            return true;
        }

        private void Btn_Load_File_Click(object sender, EventArgs e)
        {
            
            //if (excelApp == null)
            { Excel.Application excelApp = new Excel.Application(); }

            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Select file",
                InitialDirectory = ".\\",
                Filter = "xls files (*.*)|*.xls"
            };
            TxtBox_File_Path.Text  = "";
            CboBox_Excel_Sheet.Items.Clear();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = TxtBox_File_Path.Text = dialog.FileName;
                if (Excel_Open(excelApp, FilePath))//only for test
                {
                    foreach (Excel.Worksheet sheet in excelApp.Worksheets)
                    {
                        CboBox_Excel_Sheet.Items.Add(sheet.Name.ToString());
                    }
                    CboBox_Excel_Sheet.Text = CboBox_Excel_Sheet.Items[0].ToString();
                    // 引用第一個活頁簿
                    wBook = excelApp.Workbooks[1];
                    //引用第一個工作表
                    wSheet = (Excel._Worksheet)wBook.Worksheets[CboBox_Excel_Sheet.Text];
                    wSheet.Activate();
                    wRange = (Excel.Range)wSheet.Range[TxtBox_Excel_Cell.Text];
                    //wRange = (Excel.Range)wSheet.Cells[ int.Parse(textBox_Horizontal.Text), int.Parse(textBox_Vertical.Text)];
                    wRange.Activate();
                    ChangetoInt(TxtBox_Excel_Cell.Text, StartPoint);
                    FileReady = true;
                    t.Enabled = true;
                }
            }
        }

        public bool Excel_Data_Save(double[] Data, Excel.Application excelApp, string sheet, ref int[] StartPoint, int RecordType)
        {

            int i = 0;

            Thread.Sleep(600);  //mask for test

            // 引用第一個活頁簿
            wBook = excelApp.Workbooks[1];

            // 設定活頁簿焦點
            wBook.Activate();

            try
            {
                wSheet = (Excel._Worksheet)wBook.Worksheets[sheet];

                // 設定工作表焦點
                wSheet.Activate();

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

        private void CboBox_Excel_Sheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (FileReady)
                {
                    wBook = excelApp.Workbooks[1];
                    wSheet = (Excel._Worksheet)wBook.Worksheets[CboBox_Excel_Sheet.Text];
                    wSheet.Activate();
                    wRange = (Excel.Range)wSheet.Range[TxtBox_Excel_Cell.Text];
                    //wRange = (Excel.Range)wSheet.Cells[ int.Parse(textBox_Horizontal.Text), int.Parse(textBox_Vertical.Text)];
                    wRange.Activate();
                    ChangetoInt(TxtBox_Excel_Cell.Text, StartPoint);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            };
        }
        public bool Excel_Close(Excel.Application excelApp)
        {
            //關閉Excel
            excelApp.Quit();

            //釋放Excel資源
           // System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            excelApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();  //only for test
            Thread.Sleep(500);  //mask for test
            return true;
        }

        private void TxtBox_Vertical_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (FileReady)
                {
                    wBook = excelApp.Workbooks[1];
                    wSheet = (Excel._Worksheet)wBook.Worksheets[CboBox_Excel_Sheet.Text];
                    wSheet.Activate();
                    wRange = (Excel.Range)wSheet.Range[TxtBox_Excel_Cell.Text];
                    //wRange = (Excel.Range)wSheet.Cells[ int.Parse(textBox_Horizontal.Text), int.Parse(textBox_Vertical.Text)];
                    wRange.Activate();
                    ChangetoInt(TxtBox_Excel_Cell.Text, StartPoint);
                }
            }
            catch (Exception ex)
            { throw new ApplicationException(ex.ToString()); };
        }

        private void TxtBox_Horizontal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (FileReady)
                {
                    wBook = excelApp.Workbooks[1];
                    wSheet = (Excel._Worksheet)wBook.Worksheets[CboBox_Excel_Sheet.Text];
                    wSheet.Activate();
                    wRange = (Excel.Range)wSheet.Range[TxtBox_Excel_Cell.Text];
                    //wRange = (Excel.Range)wSheet.Cells[int.Parse(TxtBox_Horizontal.Text), int.Parse(textBox_Vertical.Text)];
                    wRange.Activate();
                    ChangetoInt(TxtBox_Excel_Cell.Text, StartPoint);
                }
            }
            catch (Exception ex)
            { throw new ApplicationException(ex.ToString()); };
        }



        private void Source_Measure_FormClosing(object sender, FormClosingEventArgs e)
        {
            Excel_Close(excelApp);
        }

        private void CboBox_Disable_Excel_Setting_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_Disable_Excel_Setting.Checked)
            {
                Btn_Load_File.Enabled = true;
                Btn_Excel_Close.Enabled = true;
            }

            else
            {
                Btn_Load_File.Enabled = false;
                Btn_Excel_Close.Enabled = false;
            }
                
        }

        private void TxtBox_Excel_Cell_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (FileReady && TxtBox_Excel_Cell.Text.Length == 2 && Regex.IsMatch(TxtBox_Excel_Cell.Text.Substring(0, 1).ToUpper(), @"[A-Z]+"))
                {
                    wBook = excelApp.Workbooks[1];
                    wSheet = (Excel._Worksheet)wBook.Worksheets[CboBox_Excel_Sheet.Text];
                    wSheet.Activate();
                    wRange = (Excel.Range)wSheet.Range[TxtBox_Excel_Cell.Text];
                    //wRange = (Excel.Range)wSheet.Cells[ int.Parse(textBox_Horizontal.Text), int.Parse(textBox_Vertical.Text)];
                    wRange.Activate();
                    ChangetoInt(TxtBox_Excel_Cell.Text, StartPoint);
                }
            }
            catch (Exception ex)
            { throw new ApplicationException(ex.ToString()); };
        }
        private void ChangetoInt(string alph, int[] TempStartPoint)
        {
            int[] StartPoint = new int[2] { 0, 0 };  // StartPoint[1] = vertical, StartPoint[0] = horizontal 
            int alph_Length = 0;
            string tempstring = alph.Substring(0, 1);
            if (!Regex.IsMatch(alph.ToUpper(), @"[A-Z]+"))
            {
                throw new Exception("Invalid parameter");
            }
            else
            {
                for (int j = 0; j < alph.Length; j++)
                {
                    tempstring=alph.Substring(j, 1);
                    if (Regex.IsMatch(tempstring.ToUpper(), @"[A-Z]+"))
                        alph_Length++;

                }
                tempstring= alph.Substring(0, alph_Length);
                int index = 0;
                char[] chars = tempstring.ToUpper().ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    index += ((int)chars[i] - (int)'A' + 1) * (int)Math.Pow(26, chars.Length - i - 1);
                }
                TempStartPoint[1] = int.Parse(alph.Substring(1, alph.Length - 1));
                TempStartPoint[0] = index;
            }
        }
        public void Reflesh_Excel_Cell(object source, System.Timers.ElapsedEventArgs e)
        {
            //if (FileReady)
            //{
            //    string tempstring = "";
            //    wRange = (Excel.Range)excelApp.ActiveCell;
            //    tempstring = wRange.Address;
            //    tempstring = tempstring.Replace("$", "");
            //    //textBox_Excel_Cell.Text = tempstring;

            //    //textBox_Excel_Cell.InvokeIfRequired(() =>
            //    //{
            //    //    textBox_Excel_Cell.Text = "hello";
            //    //});
            //    //textBox_Excel_Cell.InvokeIfRequired(helloAction);
            //}
        }
        public void Reflesh_Cell(string name)
        { TxtBox_Excel_Cell.Text = name; }

        private void Btn_Excel_Close_Click(object sender, EventArgs e)
        {
            Excel_Close(excelApp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] address = new string[128];
            XM_EquipVisa = new XM_EquipVisa_Util();
            XM_EquipVisa.Find_MeasureResource(address, out uint num);
            for (int i = 0; i < num; i++)
            {
                DoInstrumentIO(address[i]);
            }
        }
    }
}

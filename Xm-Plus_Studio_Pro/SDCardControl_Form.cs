using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Threading;
using XM_Tek_Studio_Pro.StudioUtil;

using System.Text.RegularExpressions;


namespace XM_Tek_Studio_Pro
{

    public partial class SDCardControl : Form
    {
        long bs = (long)Math.Pow(2, 24);
        byte[] buf = new byte[512 * 2 + 2 * 2];
        byte[,] bufftemp = new byte[(long)Math.Pow(2, 24), (long)Math.Pow(2, 4)];

        List <byte> Downloadlist = new List<byte>();
        List<bool> ChkBoxStatus = new List<bool>();
        List<string> FilePathStatus = new List<string>();
        List< DataGridView > ListGridView = new List<DataGridView>();

        ArrayList ChkBox_Path = new ArrayList();
        object [] InfoTableList = new object[11];
        DataGridView tab1GridView;
        DataGridView tab2GridView;
        DataTable tab1dt = new DataTable();
        DataTable tab2dt = new DataTable();
        Thread Download;
        Thread Multi_RD, Single_RD;

        enum MSG : int { MSG_VAL = 1, MSG_PROG, MSG_RICH, MSG_MULTIRD, MSG_DOWNLOAD, MSG_SDTEXT };

        int uSD_RD_addr = 0, uSD_RD_blocknums = 1;
        // "false":SDSC, "true":SDHC/SDXC.
        // bool RunState = true;
        bool sd_type = true;
        bool LoadSDCardInfo = false;
        int SDCardType = 0;
        bool DownloadResult = true;

        int fpga_addr = 0, fpga_leng = 0;
        int init_addr = 0, init_leng = 0;
        int disp_addr = 0, disp_leng = 0;
        int Auto_intv = 0;
        int imag_nums = 0, imag_size = 0, imag_addr = 0;
        string ic_version;

        int AutoCalimag_nums = 0;
        bool Run = true;
        bool EnaResultLog = true;
        string KeepResultLog = "";

        XM_SDCard_Util SDCard_Util = new XM_SDCard_Util();
       
        string [] Tab1ColList = new string[2]{  "Item",
                                                "Value"};

        string[] Tab1RowList = new string[14]{  "IC/Data/Version",
                                                "FPGA Addr",
                                                "FPGA Length",
                                                "Initial Code Addr",
                                                "Initial Code Length",
                                                "Display Off Addr",
                                                "Display Off Length",
                                                "Auto Run Interval (ms)",
                                                "Image Numbers",
                                                "Image Size(Block)",
                                                "Image Start Addr" ,
                                                "",
                                                "",
                                                ""};

        string[] Tab2ColList = new string[2]{   "Item",
                                                "File Path"};

        string[] Tab2RowList = new string[5]{   "SDCard Info",
                                                "FPGA Setting",
                                                "Display Initial",
                                                "Display off",
                                                "Image(Picture)"};


        private void AutoLoadFileEvent(int row, int col, string FilePath, bool Ena_Ckb, int Row_Ind, ref int Addr, ref int Blocks, ref bool Recount)
        {
            DataGridViewButtonCell cell = (DataGridViewButtonCell)DataGridView_SDCard.Rows[row].Cells[col];

            DataGridView_SDCard.Rows[row].Cells[col - 1].Value = FilePath;
            Deal_ChkBox_Path(DataGridView_SDCard, row, col, Ena_Ckb, 3);
           
            // SDCardInfo
            switch (row + 1)
            {
                case 1:
                    if (ChkBoxStatus[0])
                    {
                        LoadSDCardInfo = true;
                        FilePath = SDCard_Util.SDCard_Item[0].ItemFilePath[0]  ;
                        InfoTable(FilePath, ref Addr, ref Blocks, false);
                    }
                    break;
                case 2:
                    // FPGA Setting
                    if (ChkBoxStatus[1])
                    {
                        LoadSDCardInfo = true;
                        FilePath = SDCard_Util.SDCard_Item[1].ItemFilePath[0];
                        CalAddandBlocks(FilePath, ref Addr, ref Blocks);
                        InfoTableList[1] = string.Format("0x" + Addr.ToString("X08")); ;
                        InfoTableList[2] = string.Format("0x" + Blocks.ToString("X04"));
                    }
                    break;
                case 3:
                    // Display Init
                    if (ChkBoxStatus[2])
                    {
                        LoadSDCardInfo = true;
                        FilePath = SDCard_Util.SDCard_Item[2].ItemFilePath[0];
                        CalAddandBlocks(FilePath, ref Addr, ref Blocks);
                        InfoTableList[3] = string.Format("0x" + Addr.ToString("X08"));
                        InfoTableList[4] = string.Format("0x" + Blocks.ToString("X04"));
                    }
                    break;
                case 4:
                    // Display Off
                    if (ChkBoxStatus[3])
                    {
                        LoadSDCardInfo = true;
                        FilePath = SDCard_Util.SDCard_Item[3].ItemFilePath[0];
                        CalAddandBlocks(FilePath, ref Addr, ref Blocks);
                        InfoTableList[5] = string.Format("0x" + Addr.ToString("X08"));
                        InfoTableList[6] = string.Format("0x" + Blocks.ToString("X04"));
                    }
                    break;
                default:
                    //advoid to recount block size and start address for Image.
                    // Image
                    if (ChkBoxStatus[row])
                    {
                        FilePath = (string)DataGridView_SDCard.Rows[row].Cells[2].Value;
                        SDCard_Util.SDCard_Item[row].ItemFilePath[0] = FilePath;

                        AutoCalimag_nums++;
                        SDCard_Util.SDCard_Item[4].ImageNum = AutoCalimag_nums;

                            // Image
                        if(Recount)
                        {
                            Recount = false;
                            InfoTableList[10] = string.Format("0x" + (Addr + Blocks).ToString("X08"));
                            CalAddandBlocks(FilePath, ref Addr, ref Blocks);
                            InfoTableList[9] = string.Format("0x" + Blocks.ToString("X04"));
                        }

                        InfoTableList[8] = string.Format("0x" + SDCard_Util.SDCard_Item[4].ImageNum.ToString("X04"));

                        // Enable Checkbox. 
                        Deal_ChkBox_Path(DataGridView_SDCard, row, col, true, 3);

                        if (DataGridView_SDCard.RowCount <= row + 1)
                        {
                            // autu add one Row on datagridview at last.
                            ListGridView[1].AllowUserToAddRows = true;
                            ListGridView[1].CurrentCell = ListGridView[1].Rows[row + 1].Cells[0];
                            ListGridView[1].AllowUserToAddRows = false;
                            ListGridView[1].Refresh();
                            Deal_ChkBox_Path(ListGridView[1], 0, 0, false, 0);
                            Deal_ChkBox_Path(DataGridView_SDCard, row, col, true, 3);
                        }
                        ListGridView[1].Refresh();
                    }

                    break;
            }
            ListGridView[1].Refresh();
        }

        private void Button_Download_All_Click(object sender, EventArgs e)
        {
            if (button_Download_All.Text == "Download")
            {
                Run = true;
                RichTextBox_SDCardReadInfo.Text = "";
                button_Download_All.Text = "Stop";
                try
                {
                    Download = new Thread(DownloadAll)
                    {
                        IsBackground = true
                    };
                    Download.Start();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                if (Download != null && Download.IsAlive) { Run = true; Download.Abort(); button_Download_All.Text = "Download"; }
            }
        }

        private void DownloadAll()
        {
            KeepResultLog = "";
            EnaResultLog = true;
            InvokeDownload_Bott("Stop");
            DownloadResult = true;
            int imag_index = 0;
            if (Connect(ref SDCardType))
            {
                if (SDCardType == 1)
                {
                    // toolStrStaLab_SDCardStatus.Text = "";
                    InvokeSDText("SD Card Status : Found SDHC/SDXC !!", (object)(Color.Green));
                }
                if (SDCardType == 5)
                {
                    // toolStrStaLab_SDCardStatus.Text = "";
                    InvokeSDText("SD Card Status : Found SDSC !!", (object)(Color.Green));
                }
                DownloadResult = true;
            }
            else
            {
                InvokeSDText("SD Card Status : No Found !!", (object)(Color.Red));
                DownloadResult = false;
            }


            int Pro_Max = SDCardControBar.Maximum, Pro_Start = 0, Pro_End = 0;
            InvokePrgbMax(Pro_Max); InvokePrgbPos(0);


            if (ChkBoxStatus[0] & DownloadResult)
            {
                Pro_End = Pro_End + (Pro_Max / 10);
                if (!Download_InfoTable()) { DownloadResult = false; }
                Pro_Start = Pro_End;

            }
            if (ChkBoxStatus[1] & DownloadResult)
            {
                Pro_End = Pro_End + (Pro_Max / 10);
                if (!Download_FPGA_Setting(Pro_Start, Pro_End)) { DownloadResult = false; }
                Pro_Start = Pro_End;

            }
            if (ChkBoxStatus[2] & DownloadResult)
            {
                Pro_End = Pro_End + (Pro_Max / 10);
                if (!Download_Display_Init(Pro_Start, Pro_End)) { DownloadResult = false; }
                Pro_Start = Pro_End;

            }
            if (ChkBoxStatus[3] & DownloadResult)
            {
                Pro_End = Pro_End + (Pro_Max / 10);
                if (!Download_Display_Off(Pro_Start, Pro_End)) { DownloadResult = false; }
                Pro_Start = Pro_End;
            }

            for (int i = 4; i < AutoCalimag_nums + 4/*ListGridView[1].RowCount*/ ; i++)
            {
                // not only checkbox is checked but also  ItemFilePath is not empty. 
                if (ChkBoxStatus[i] && DownloadResult && SDCard_Util.SDCard_Item[i].ItemFilePath[0] != "")
                {
                    if (!Download_Image((Pro_Start + (int)((imag_index * (Pro_Max - Pro_End)) / AutoCalimag_nums)),
                        (Pro_Start + (int)(((imag_index + 1) * (Pro_Max - Pro_End)) / AutoCalimag_nums)), i - 4,
                        Convert.ToInt32((string)InfoTableList[9], 16) * (i - 4)))
                    { DownloadResult = false; }
                    imag_index++;
                }
            }

            InvokeDownload_Bott("Download");
            InvokePrgbPos(Pro_Max);

            if (DownloadResult)
            {
                XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Result", true);
                MessageBox.Show("Download MicroSD is successful!", "Result");
            }

            else
            {
                XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Result", true);
                MessageBox.Show("Download MicroSD is Fail!", "Result");
            }

        }
        private void Button_Connect_Click(object sender, EventArgs e)
        {
            if (Connect(ref SDCardType))
            {
                if (SDCardType == 1)
                {
                    toolStrStaLab_SDCardStatus.Text = "";
                    InvokeSDText("SD Card Status : Found SDHC/SDXC !!", (object)(Color.Green));
                }
                if (SDCardType == 5)
                {
                    toolStrStaLab_SDCardStatus.Text = "";
                    InvokeSDText("SD Card Status : Found SDSC !!", (object)(Color.Green));
                }
            }
            else
            {
                InvokeSDText("SD Card Status : No Found !!", (object)(Color.Red));
            }
        }


        private bool Connect(ref int SDCardType)
        {
            InvokePrgbPos(0);
            // "false":SDSC, "true":SDHC/SDXC.
            bool ReadResult = false;
            IntPtr ptr = Marshal.AllocHGlobal((int)bs);
            int i, x, y, j;

            // FPGA to uSD interface set (spi clk divid, "H":1, "L":2, 60MHz/3=20MHz)
            SDCard_Util.UsbWriteAD04(0xf8, 0x01, 0xf8, 0x02);
            // interface setting, 0x30:SD card
            SDCard_Util.UsbWriteAD02(0xa0, 0x30);

            //-----------------------------------------------------
            // SD card reset/initialize dummy clk when CS="H", >74 clk.

            // uSD.Spi_cs_H.
            SDCard_Util.Spi_cs_H();
            // Data_Wr_Mode.
            SDCard_Util.Data_Wr_Mode();

            InvokePrgbPos(10);
            x = 80;
            for (i = 0; i < x; i++)
            {
                buf[i] = 0xff;
            }
            Marshal.Copy(buf, 0, ptr, x);
            SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);
            //-----------------------------------------------------
            // CS:"L"->CMD0->response 0x01->CS:"H"->8 dummy clk

            // uSD.Spi_cs_L.
            SDCard_Util.Spi_cs_L();

            // Addr_Wr_Mode.
            SDCard_Util.Addr_Wr_Mode();

            buf[0] = 0x40;                                              // CMD0
            buf[1] = 0x00; buf[2] = 0x00; buf[3] = 0x00; buf[4] = 0x00; // 0 parameter
            buf[5] = 0x95;                                              // CRC
            buf[6] = 0xff;                                              // dummy clk, 8clks(1byte)
            x = 7;
            Marshal.Copy(buf, 0, ptr, x);
            SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);

            // Data_Rd_Mode.
            SDCard_Util.Data_Rd_Mode();

            InvokePrgbPos(15);
            i = 0;
            do
            {
                // uSD.rd_8bit.
                SDCard_Util.Rd_8bit(ref x);

                i++;
                //   InvokeRichBox(i.ToString("D04") + ":CMD0 response (0x01) : 0x" + x.ToString("X02") + "\r\n");
            } while ((x != 0x01) & (i < 10));

            InvokePrgbPos(5);
            if (x == 0x01)
            {  /*InvokeRichBox("CMD0...pass \r\n");*/}
            else
                InvokeRichBox("CMD0...fail \r\n");

            // uSD.Spi_cs_H_wd.
            SDCard_Util.Spi_cs_H_wd();

            //-----------------------------------------------------
            // cmd8 : 0x00 0x00 0x01 0x5a : SDHC/SDXC used. SDSC : response 0x05, illigal command
            // response : R1+4bytes

            // uSD.Spi_cs_L.
            SDCard_Util.Spi_cs_L();

            // Addr_Wr_Mode.
            SDCard_Util.Addr_Wr_Mode();

            buf[0] = 0x48;                                              // CMD8
            buf[1] = 0x00; buf[2] = 0x00; buf[3] = 0x01; buf[4] = 0x5a; // [31:12]为0，[11:8]为VHS值，[7:0]Check Pattern，可以为任意值，用于检测SD卡通信是否正确的。若该命令的返回值最后一字节和Check pattern值相同，说明SPI通信成功。
            buf[5] = 0x9b;                                              // CRC, CMD8 : CRC must
            buf[6] = 0xff;                                              // dummy clk, 8clks(1byte)
            x = 7;
            Marshal.Copy(buf, 0, ptr, x);
            SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);

            // Data_Rd_Mode.
            SDCard_Util.Data_Rd_Mode();

            i = 0;
            do
            {
                // rd_8bit.
                SDCard_Util.Rd_8bit(ref x);

                if (x == 0x01) { sd_type = true; } else if (x == 0x05) { sd_type = false; }
                i++;
                //   InvokeRichBox(i.ToString("D04") + ":CMD8 response (0x01/0x05) : 0x" + x.ToString("X02") + "\r\n");
            }
            while ((x != 0x01) & (x != 0x05) & (i < 10));
            if (x == 0x01)
            {
                InvokeRichBox("CMD8...SDHC/SDXC >> pass \r\n");
                ReadResult = true;
                SDCardType = x;
            }
            else if (x == 0x05)
            {
                InvokeRichBox("CMD8...SDSC >> pass \r\n");
                ReadResult = true;
                SDCardType = x;
            }
            else
            {
                InvokeRichBox("CMD8...fail \r\n");
                ReadResult = false;
                SDCardType = x;
            }

            // Spi_cs_H_wd.
            SDCard_Util.Spi_cs_H_wd();

            InvokePrgbPos(20);
            //-----------------------------------------------------
            // initial cmd, CMD55 + ACMD41
            // send CMD55, response 0x01
            // send CMD41, response 0x00 => success

            i = 0; y = 0; j = 0;
            do
            {
                i++;
                // uSD.Spi_cs_L.
                SDCard_Util.Spi_cs_L();

                // Addr_Wr_Mode.
                SDCard_Util.Addr_Wr_Mode();

                buf[0] = 0x77;                                              // CMD55
                buf[1] = 0x00; buf[2] = 0x00; buf[3] = 0x00; buf[4] = 0x00; // 0 parameter
                buf[5] = 0xff;                                              // CRC, don't care
                buf[6] = 0xff;                                              // dummy clk, 8clks(1byte)
                x = 7;
                Marshal.Copy(buf, 0, ptr, x);
                SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);

                // Data_Rd_Mode.
                SDCard_Util.Data_Rd_Mode();

                do
                {  // rd_8bit.
                    SDCard_Util.Rd_8bit(ref y);
                    // InvokeRichBox(i.ToString("D04") + ":CMD55  response (0x01) : 0x" + y.ToString("X02") + "\r\n");
                    j++;
                } while ((y == 0xff) & (j < 50));

                // Spi_cs_H_wd.
                SDCard_Util.Spi_cs_H_wd();

                // uSD.Spi_cs_L.
                SDCard_Util.Spi_cs_L();

                // Addr_Wr_Mode.
                SDCard_Util.Addr_Wr_Mode();

                buf[0] = 0x69;                                              // ACMD41
                buf[1] = 0x40;                                              // host support SDXC/SDHC
                buf[2] = 0x00; buf[3] = 0x00; buf[4] = 0x00;                // 0 parameter
                buf[5] = 0xff;                                              // CRC, don't care
                buf[6] = 0xff;                                              // dummy clk, 8clks(1byte)
                x = 7;
                Marshal.Copy(buf, 0, ptr, x);
                SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);
                InvokePrgbPos(((int)(75 * i / 100) < 75) ? (20 + (int)(75 * i / 100)) : 95);
                // Data_Rd_Mode.
                SDCard_Util.Data_Rd_Mode();

                // rd_8bit.
                SDCard_Util.Rd_8bit(ref x);

                // InvokeRichBox(i.ToString("D04") + ":ACMD41 response (0x00) : 0x" + x.ToString("X02") + "\r\n");

                // Spi_cs_H_wd.
                SDCard_Util.Spi_cs_H_wd();

            } while ((x != 0x00) & (i < 50));

            if ((y == 0x01) & (x == 0x00))
            {
                InvokeRichBox("CMD55 + ACMD41...pass \r\n" + "Connect ok! .........." + "\r\n");
            }
            else
            {
                InvokeRichBox("CMD55 + ACMD41...fail \r\n" + "Connect fail! .........." + "\r\n");
            }
            //-----------------------------------------------------
            Marshal.FreeHGlobal(ptr);
            InvokePrgbPos(100);
            return ReadResult;
        }

        private void Button_Multi_RD_Click(object sender, EventArgs e)
        {
            if (button_Multi_RD.Text == "Multi-RD")
            {
                Run = true;
                try
                {
                    Multi_RD = new Thread(MultiReadBlock)
                    {
                        IsBackground = true
                    };
                    Multi_RD.Start();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            { if (Multi_RD != null && Multi_RD.IsAlive) { Multi_RD.Abort();  Run = false; button_Multi_RD.Text = "Multi-RD"; InvokePrgbPos(100); } }
        }

        private void Button_Next_Click(object sender, EventArgs e)
        {
            TabControl_SDCard.SelectedIndex = 1;
        }

        private void Button_Single_RD_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////////////////////////////////////
            if (button_Single_RD.Text == "Single-RD")
            {
                Run = true;
                try
                {
                    Single_RD = new Thread(SingleReadBlock)
                    {
                        IsBackground = true
                    };
                    Single_RD.Start();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            { if (Single_RD != null && Single_RD.IsAlive) { Single_RD.Abort(); Run = false; button_Single_RD.Text = "Single-RD"; InvokePrgbPos(100); } }
            ///////////////////////////////////////////////////////////////////////////////////////
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSDCardDirPath);
                string FilePath = IniUtil.IniReadValue("System", "ScriptDir");
                FilePath = (FilePath == "NULL") ? Setting.ExeImgDirPath : FilePath;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "Txt Files|*.txt|*.text|*.spt",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    Title = "Save Program Log",
                    InitialDirectory = FilePath,//Setting.ExeSDCardDirPath
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Show filename on the File Path.
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    for (int Row_Length = 0; Row_Length < ListGridView[1].RowCount-1; Row_Length++)
                    {
                        sw.Write(ChkBoxStatus[Row_Length] +";");
                        sw.Write(SDCard_Util.SDCard_Item[Row_Length].ItemFilePath[0]);
                        sw.Write("\r\n");
                    }
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void Button_Load_Click(object sender, EventArgs e)
        {
            
            try
            {
                int PreCount = 0;
                InvokePrgbPos(0);
                InvokePrgbMax(100);
                
                XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSDCardDirPath);
                string FilePath = IniUtil.IniReadValue("System", "ScriptDir");
                FilePath = (FilePath == "NULL") ? Setting.ExeImgDirPath : FilePath;

                //if (!File.Exists(FilePath))
                //{
                //    XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Confirm Message", true);
                //    MessageBox.Show("File Path is not exist, Please check again !", "Confirm Message");
                //}

                OpenFileDialog Save_Program_Log = new OpenFileDialog
                {
                    FileName = "Save Program Log.txt",
                    Filter = "Text Files|*.txt|*.text|*.spt",
                    InitialDirectory = FilePath,
                    DefaultExt = "*.txt"
                };

                if (Save_Program_Log.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Clear Checkbox and FilePath status.
                    AutoCalimag_nums = 0;
                    for (int i = 0; i < ChkBoxStatus.Count - 1; i++)
                    {
                        DataGridView_SDCard.Rows[i].Cells[2].Value = "";
                    }
                    Deal_ChkBox_Path(ListGridView[1], 0, 0, false, 4);
                    ListGridView[1].Refresh();

                    char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                    string line, TempString, TempPath;
                    int Row_Ind = 0;
                    LoadSDCardInfo = false;
                    using (StreamReader sr = new StreamReader(Save_Program_Log.FileName, Encoding.Default))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            PreCount = Row_Ind++;
                        }
                    }
                    Row_Ind = 0;
                    int Addr = 0, Blocks = 1; AutoCalimag_nums = 0;
                    bool Recount = true;
                    using (StreamReader sr = new StreamReader(Save_Program_Log.FileName, Encoding.Default))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            InvokePrgbPos((int)(Row_Ind * 100 / PreCount));
                            Console.WriteLine(line.ToString());

                            TempPath = line.Substring(line.IndexOf(';') + 1);
                            if (!File.Exists(TempPath))
                            {
                                XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Confirm Message", true);
                                MessageBox.Show(TempPath + " is not exist, Please check again !", "Confirm Message");
                                break;
                            }
                            else
                            {
                                TempString = line.Substring(0, line.IndexOf(';'));
                                ChkBoxStatus[Row_Ind] = bool.Parse(TempString);
                                SDCard_Util.SDCard_Item[Row_Ind].ItemFilePath[0] = TempPath;
                                AutoLoadFileEvent(Row_Ind, 3, TempPath, ChkBoxStatus[Row_Ind], Row_Ind, ref Addr, ref Blocks, ref Recount);
                                Row_Ind++;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                InvokePrgbPos(0);
                XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Confirm Message", true);
                MessageBox.Show("File Content is abnormal, Please check again !", "Confirm Message");
            }
            InvokePrgbPos(SDCardControBar.Maximum);
        }

        // Read SDCardInfo from load file (bottun).
        private void Button_Load_SDInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int Addr = 0, Blocks = 0;
                XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSDCardDirPath);
                string FilePath = IniUtil.IniReadValue("System", "ScriptDir");
                FilePath = (FilePath == "NULL") ? Setting.ExeImgDirPath : FilePath;

                OpenFileDialog SdCard_InfoFile = new OpenFileDialog
                {
                    FileName = "SDCard_InfoScript.txt",
                    Filter = "Text Files|*.txt|*.text|*.spt",
                    InitialDirectory = FilePath,
                    DefaultExt = "*.txt"
                };

                if (SdCard_InfoFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InfoTable(SdCard_InfoFile.FileName, ref Addr,ref Blocks,true);
                    LoadSDCardInfo = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Button_Prev_Click(object sender, EventArgs e)
        {
            TabControl_SDCard.SelectedIndex = 0;
        }

        private void Button_Save_SDInfo_Click(object sender, EventArgs e)
        {
            try
            {
                XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSDCardDirPath);
                string FilePath = IniUtil.IniReadValue("System", "ScriptDir");
                FilePath = (FilePath == "NULL") ? Setting.ExeImgDirPath : FilePath;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "Txt Files|*.txt|*.text|*.spt",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    Title = "Save SDCard_InfoScript",
                    InitialDirectory = FilePath
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //IniUtil.IniWriteValue("System", "ImageDir", ImaageFile.FileName);
                    // Show filename on the File Path.
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        for (int Row_Length = 0; Row_Length < ListGridView[0].RowCount - 3; Row_Length++)
                        {
                            for (int Col_Length = 0; Col_Length < ListGridView[0].ColumnCount; Col_Length++)
                            {
                                if (Col_Length == 0)
                                    sw.Write((string)ListGridView[0].Rows[Row_Length].Cells[Col_Length].Value + "=");
                                else
                                    sw.Write((string)ListGridView[0].Rows[Row_Length].Cells[Col_Length].Value);
                            }
                            sw.Write("\r\n");
                        }
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       

        private void CalAddandBlocks(string Filepath, ref Int32 Addr, ref Int32 Blocks)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string FilePath = Filepath;
            StreamReader sr = new StreamReader(FilePath, Encoding.Default);
            string line;
            int Row_Length = 0;
            int Length = 0;
            int Line_Length = 0;

            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(delimiterChars);
                // Console.WriteLine(line.ToString());
                Line_Length = words.Length >= 16 ? 16 : words.Length - 1;

                for (int i = 0; i < Line_Length; i++)
                {
                   // bufftemp[Row_Length, i] = (Convert.ToByte(words[i], 16));
                    Length++;
                }

                Row_Length++;
            }
            Addr = Addr + Blocks;
            Blocks = (Length) % 512 == 0 ? ((Length) / 512) : (((Length) / 512) + 1);
        }

        private void Chagne_DataGridView(DataGridView GridView, string TabPage_Index)
        {
            try
            {
                GridView.AutoGenerateColumns = true;
                GridView.AllowUserToAddRows = true;
                GridView.Dock = DockStyle.Fill;
                GridView.DataSource = null;
                DataTable dt = new DataTable();
                dt = null;
                GridView.Columns.Clear();

                // show row index be set start from 1, not 0(zero).
                //int rowNumber = 1;

                if (TabPage_Index == "tabPage1")
                {
                    dt = tab1dt;
                }
                else
                {
                    dt = tab2dt;
                }
                //// Show the index on the HeaderCell.
                //foreach (DataGridViewRow row1 in GridView.Rows)//Re-Writing code  
                //{
                //    if (row1.IsNewRow) continue;
                //    // set to HeaderCell.Value must be string format.
                //    row1.HeaderCell.Value = string.Format("{0}", rowNumber);
                //    rowNumber++;
                //}

                GridView.DataSource = dt;
                GridView.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CheckboxAll_CheckedChanged(object sender, EventArgs e)
        {
            // advoid to Checkbox is fail after checkboxall be checked.
            ListGridView[1].CurrentCell = ListGridView[1].Rows[0].Cells[1];

            foreach (DataGridViewRow dr in DataGridView_SDCard.Rows)
               dr.Cells[0].Value = ((CheckBox)DataGridView_SDCard.Controls.Find("checkboxAll", true)[0]).Checked;
                Deal_ChkBox_Path(DataGridView_SDCard, 0, 0, false, 2);
        }

        private void Deal_ChkBox_Path(DataGridView GridView, int row, int col, bool SetStatus, int intial)
        {
            int start = 0, end = 0;
            switch (intial)
            { 
                case 0:
                    if (GridView.RowCount > ChkBoxStatus.Count)
                    {
                        start = 0;// ChkBoxStatus.Count;
                        end = GridView.RowCount - ChkBoxStatus.Count;
                    }
                    for (int Length = start; Length < end; Length++)
                    {
                        ChkBoxStatus.Add(false);
                        FilePathStatus.Add("");
                    }
                    for (int i = 0; i < GridView.RowCount; i++)
                    {
                        GridView.Rows[i].Cells[0].Value = ChkBoxStatus[i];
                    }
                    break;
                // modify checkbox and FilePathStatus.
                case 1:
                    {
                        DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DataGridView_SDCard.Rows[row].Cells[col];
                        if (Convert.ToBoolean(cell.EditedFormattedValue) == true)
                            ChkBoxStatus[row] = true;
                        else
                            ChkBoxStatus[row] = false;
                        break;
                    }
                // Setting checkBox is checked or not.
                case 2:
                    {
                        for (int i = 0; i < GridView.RowCount; i++)
                        {
                            ChkBoxStatus[i] = SetStatus;
                        }
                        break;
                    }
                // Assign Checkbox status directly.
                case 3:
                    {
                        ChkBoxStatus[row] = SetStatus;
                        for (int i = 0; i < GridView.RowCount; i++)
                        {
                            GridView.Rows[i].Cells[0].Value = ChkBoxStatus[i];
                        }
                        break;
                    }
                // Clr prevent data
                case 4:
                    {
                        for (int i = 0; i < GridView.RowCount; i++)
                        {
                            ChkBoxStatus[i] = SetStatus;
                            GridView.Rows[i].Cells[0].Value = ChkBoxStatus[i];
                        }
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < GridView.RowCount-1; i++)
                        {
                            ChkBoxStatus[i] = SetStatus;
                            GridView.Rows[i].Cells[0].Value = ChkBoxStatus[i];
                        }
                        break;
                    }
                default:
                    break;
            }
        }

       

        private bool Download_InfoTable()
        {
            try
            {
                string line;
                int Row_Length = 0;

                byte[] ICVersion = new byte[16];
                int Length = 0;
                int Line_Length = 0;
                int j = 0;

                for (int Index = 0; Index < InfoTableList.Length; Index++)
                {

                    line = (string)InfoTableList[Index];
                    line = line.Substring(line.IndexOf('=') + 1);

                    if (Row_Length == 0)
                    {
                        if (line.Length != 16)
                        { line = line.PadRight(16, '\0'); }
                        ICVersion = Encoding.ASCII.GetBytes(line);
                        Line_Length = line.Length > 16 ? 16 : 16;// line.Length;
                        for (j = 0; j < Line_Length; j++)
                        {
                            bufftemp[Row_Length, j] = ICVersion[j];
                        }
                    }
                    else if (Row_Length >= 1 && Row_Length <= 2)
                    {
                       // if (line.StartsWith("0x"))
                        //{
                            line = line.Replace("0x", "");
                            if (Row_Length == 1)
                            {
                                line = line.PadLeft(8, '0');
                                Length = 0;
                            }
                            if (Row_Length == 2)
                                line = line.PadLeft(4, '0');
                            for (j = 0; j < line.Length; j++)
                            {
                                // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                if ((j % 2 == 1))
                                {
                                    bufftemp[1, (j / 2) + Length] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                }
                            }
                            Length = j / 2;
                        //}
                    }
                    else if (Row_Length >= 3 && Row_Length <= 4)
                    {
                        //if (line.StartsWith("0x"))
                        //{
                            line = line.Replace("0x", "");
                            if (Row_Length == 3)
                            {
                                Length = 0;
                                line = line.PadLeft(8, '0');
                            }
                            if (Row_Length == 4)
                                line = line.PadLeft(4, '0');
                            for (j = 0; j < line.Length; j++)
                            {
                                // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                if ((j % 2 == 1))
                                {
                                    bufftemp[2, (j / 2) + Length] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                }
                            }
                            Length = j / 2;
                        //}
                    }
                    else if (Row_Length >= 5 && Row_Length <= 6)
                    {
                       // if (line.StartsWith("0x"))
                       // {
                            line = line.Replace("0x", "");
                            if (Row_Length == 5)
                            {
                                Length = 0;
                                line = line.PadLeft(8, '0');
                            }
                            if (Row_Length == 6)
                                line = line.PadLeft(4, '0');

                            for (j = 0; j < line.Length; j++)
                            {
                                // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                if ((j % 2 == 1))
                                {
                                    bufftemp[4, (j / 2) + Length] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                }
                            }
                            Length = j / 2;
                        //}
                    }
                    else if (Row_Length == 7)
                    {
                        // Length = 0;
                        //if (line.StartsWith("0x"))
                        if (Regex.IsMatch(line.ToUpper(), @"[a-fA-Z]+")) 
                        {
                            line = line.Replace("0x", "");
                            line = line.PadLeft(4, '0');
                            for (j = 0; j < line.Length; j++)
                            {
                                // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                if ((j % 2 == 1))
                                {
                                    bufftemp[5, 4 + (j / 2)] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                }
                            }
                        }
                        else
                        {
                            //line = "0x"+line.PadLeft(4, '0');
                            line = Convert.ToUInt32(line).ToString("x");
                            //line = line.Replace("0x", "");
                            line = line.PadLeft(4, '0');
                            for (j = 0; j < line.Length; j++)
                            {
                                // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                if ((j % 2 == 1))
                                {
                                    bufftemp[5, 4 + (j / 2)] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                }
                            }
                        }
                    }
                    else
                    {
                       // if (line.StartsWith("0x"))
                       // {
                            line = line.Replace("0x", "");
                            if (Row_Length == 8)
                            {
                                Length = 0;
                                line = line.PadLeft(4, '0');
                            }

                            if (Row_Length == 9)
                                line = line.PadLeft(4, '0');

                            if (Row_Length == 10)
                            {
                                Length = Length + 4;
                                line = line.PadLeft(8, '0');
                            }

                            for (j = 0; j < line.Length; j++)
                            {
                                // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                if ((j % 2 == 1))
                                {
                                    bufftemp[6, (j / 2) + Length] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                }
                            }
                            Length = j / 2;
                       // }
                    }
                    Row_Length++;
                }

                // Download SDCardInfo with this function.
                return SD_single_block_write(0, bufftemp, "Download  " + Tab2RowList[0] + ". Please Wait!..........\r\n");
            }
            catch (Exception)
            {
                XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Error Message", true);
                MessageBox.Show("Input String/Data Content is abnormal, Please check again !", "Error Message");
                return false;
            }
        }

        private bool Download_FPGA_Setting(int Pro_Start, int Pro_End)
        {
            try
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                string FilePath = SDCard_Util.SDCard_Item[1].ItemFilePath[0];
                StreamReader sr = new StreamReader(FilePath, Encoding.Default);
                string line;
                int Row_Length = 0;
                int Length = 0;
                int Line_Length = 0;


                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(delimiterChars);
                    // Console.WriteLine(line.ToString());
                    Line_Length = words.Length >= 16 ? 16 : words.Length - 1;

                    for (int i = 0; i < Line_Length; i++)
                    {
                        //bufftemp[1][Row_Length, i] = (Convert.ToByte(words[i], 16));
                        bufftemp[Row_Length, i] = (Convert.ToByte(words[i], 16));
                        Length++;
                    }
                    Row_Length++;
                }


                int Blocks = (Length) % 512 == 0 ? ((Length) / 512) :
                                 (((Length) / 512) + 1);

                SDCard_Util.SDCard_Item[1].Addr = SDCard_Util.SDCard_Item[0].Addr + SDCard_Util.SDCard_Item[0].Block_Length;
                SDCard_Util.SDCard_Item[1].Block_Length = Blocks;

                // Download SDCardFPGA with this function.
                return SD_multi_block_write(Pro_Start, Pro_End,  SDCard_Util.SDCard_Item[1].Addr, Blocks, bufftemp, "Download " + Tab2RowList[1] + ". Please Wait! ..........\r\n");
                //-----------------------------------------------------
                // Marshal.FreeHGlobal(ptr);

            }
            catch (Exception ex )
            {

                throw ex ;
            }
            
        }

        private bool Download_Display_Init(int Pro_Start, int Pro_End)
        {
            try
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                string FilePath = SDCard_Util.SDCard_Item[2].ItemFilePath[0];
                StreamReader sr = new StreamReader(FilePath, Encoding.Default);
                string line;
                int Row_Length = 0;
                int Length = 0;
                int Line_Length = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(delimiterChars);
                    // Console.WriteLine(line.ToString());
                    Line_Length = words.Length >= 16 ? 16 : words.Length - 1;
                    for (int i = 0; i < Line_Length; i++)
                    {
                        //bufftemp[2][Row_Length, i] = (Convert.ToByte(words[i], 16));
                        bufftemp[Row_Length, i] = (Convert.ToByte(words[i], 16));
                        Length++;
                    }
                    Row_Length++;
                }

                int Blocks = (Length) % 512 == 0 ? ((Length) / 512) :
                                 (((Length) / 512) + 1);
                //ListGridView[0].Rows[1].Cells[2].Value = "0x" + Blocks.ToString("X04");

                SDCard_Util.SDCard_Item[2].Addr = Convert.ToInt32((string)InfoTableList[1], 16) + Convert.ToInt32((string)InfoTableList[2], 16);
                SDCard_Util.SDCard_Item[2].Block_Length = Blocks;

                // Download SDCardDisplayInit with this function.
                return SD_multi_block_write(Pro_Start, Pro_End, SDCard_Util.SDCard_Item[2].Addr, Blocks, bufftemp, "Download  " + Tab2RowList[2] + ". Please Wait! ..........\r\n");
                //-----------------------------------------------------
                // Marshal.FreeHGlobal(ptr);
            }
            catch (Exception ex )
            {

                throw ex ;
            }
        }

        private bool Download_Display_Off(int Pro_Start, int Pro_End)
        {
            try
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                string FilePath = SDCard_Util.SDCard_Item[3].ItemFilePath[0];
                StreamReader sr = new StreamReader(FilePath, Encoding.Default);
                string line;
                int Row_Length = 0;
                int Length = 0;
                int Line_Length = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(delimiterChars);
                    // Console.WriteLine(line.ToString());
                    Line_Length = words.Length >= 16 ? 16 : words.Length - 1;
                    for (int i = 0; i < Line_Length; i++)
                    {
                        //bufftemp[3][Row_Length, i] = (Convert.ToByte(words[i], 16));
                        bufftemp[Row_Length, i] = (Convert.ToByte(words[i], 16));
                        Length++;
                    }
                    Row_Length++;
                }

                int Blocks = (Length) % 512 == 0 ? ((Length) / 512) :(((Length) / 512) + 1);
                //ListGridView[0].Rows[1].Cells[2].Value = "0x" + Blocks.ToString("X04");

                SDCard_Util.SDCard_Item[3].Addr = Convert.ToInt32((string)InfoTableList[3], 16) + Convert.ToInt32((string)InfoTableList[4], 16);
                SDCard_Util.SDCard_Item[3].Block_Length = Blocks;

                // Download SDCardDisplayoff with this function.
                return SD_multi_block_write(Pro_Start, Pro_End, SDCard_Util.SDCard_Item[3].Addr, Blocks, bufftemp, "Download  " + Tab2RowList[3] + ". Please Wait! ..........\r\n");
                //-----------------------------------------------------
                // Marshal.FreeHGlobal(ptr);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool Download_Image(int Pro_Start, int Pro_End, int ImageNum, int addr)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string FilePath = SDCard_Util.SDCard_Item[4 + ImageNum].ItemFilePath[0];
            StreamReader sr = new StreamReader(FilePath, Encoding.Default);
            string line;
            int Row_Length = 0;
            int Length = 0;
            int Line_Length = 0;

            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(delimiterChars);
                // Console.WriteLine(line.ToString());
                Line_Length = words.Length >= 16 ? 16 : words.Length - 1;
                for (int i = 0; i < Line_Length; i++)
                {
                    //bufftemp[4][Row_Length, i] = (Convert.ToByte(words[i], 16));
                    bufftemp[Row_Length, i] = (Convert.ToByte(words[i], 16));
                    Length++;
                }
                Row_Length++;
            }

            int Blocks = (Length) % 512 == 0 ? ((Length) / 512) : (((Length) / 512) + 1);

            SDCard_Util.SDCard_Item[4].Block_Length = Convert.ToInt32((string)InfoTableList[9], 16);

            // Download SDCardImage with this function.
            return SD_multi_block_write(Pro_Start, Pro_End, Convert.ToInt32((string)InfoTableList[10], 16) + addr, Blocks, bufftemp, "Download  " + "Image(Picture"+ (ImageNum + 1).ToString() + ")" +/*Tab2RowList[4]*/  ". Please Wait! ..........\r\n\r\n");
            //-----------------------------------------------------
        }

        private void DisableColumnHeaderSort(DataGridView GridView)
        {
            for (int j = 0; j < GridView.ColumnCount; j++)
            {
                GridView.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void DataGridView_SDCard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (TabControl_SDCard.SelectedIndex == 1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        Deal_ChkBox_Path(DataGridView_SDCard, e.RowIndex, e.ColumnIndex, false, 1);
                        if (DataGridView_SDCard.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                        {
                            XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Warning", true);
                            MessageBox.Show("Enable CheckBox Before Load File! ", "Warning");
                            ListGridView[1].AllowUserToAddRows = true;
                            ListGridView[1].CurrentCell = ListGridView[1].Rows[e.RowIndex].Cells[1];
                            ListGridView[1].AllowUserToAddRows = false;
                            Deal_ChkBox_Path(DataGridView_SDCard, e.RowIndex, e.ColumnIndex, false, 3);
                            ListGridView[1].AllowUserToAddRows = true;
                            ListGridView[1].CurrentCell = ListGridView[1].Rows[e.RowIndex].Cells[0];
                            ListGridView[1].AllowUserToAddRows = false;
                            ListGridView[1].Refresh();
                        } 
                    }

                    if (e.RowIndex >= 0)
                    {
                        switch (e.ColumnIndex)
                        {
                            case 3:
                                LoadFileEvent(e.RowIndex, e.ColumnIndex);
                                break;
                            case 4:
                                //for image item
                                SDCard_Util.SDCard_Item[e.RowIndex].ItemFilePath[0] = "";
                                DataGridView_SDCard.Rows[e.RowIndex].Cells[e.ColumnIndex - 2].Value = "";
                                Deal_ChkBox_Path(DataGridView_SDCard, e.RowIndex, e.ColumnIndex, false, 3);
                                break;
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // When user keyin string from UI, it need to save info. 
        private void DataGridView_SDCard_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 1 && DataGridView_SDCard.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (InfoTableList.Length > e.RowIndex)
                {
                    string TempData = DataGridView_SDCard.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    switch (e.RowIndex)
                    {
                        case 0: 
                        {
                                if (TempData.Length > 16)
                                {
                                    XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Error", true);
                                    MessageBox.Show("Keyin char is within the range of 1 to 16 chars  !", "Error");
                                    DataGridView_SDCard.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = InfoTableList[e.RowIndex];
                                }
                                else { InfoTableList[e.RowIndex] = TempData; }
                                break;
                        }
                        case 1:
                            {
                                SetInfoRule(TempData, 10, e.RowIndex, e.ColumnIndex, Math.Pow(2, 32)-1);
                                break;
                            }
                        case 2:
                            {
                                SetInfoRule(TempData, 6, e.RowIndex, e.ColumnIndex, Math.Pow(2, 16)-1);
                                break;
                            }
                        case 3:
                            {
                                SetInfoRule(TempData, 10, e.RowIndex, e.ColumnIndex, Math.Pow(2, 32)-1);
                                break;
                            }
                        case 4:
                            {
                                SetInfoRule(TempData, 6, e.RowIndex, e.ColumnIndex, Math.Pow(2, 16)-1);
                                break;
                            }
                        case 5:
                            {
                                SetInfoRule(TempData, 10, e.RowIndex, e.ColumnIndex, Math.Pow(2, 32)-1);
                                break;
                            }
                        case 6:
                            {
                                SetInfoRule(TempData, 6, e.RowIndex, e.ColumnIndex, Math.Pow(2, 16) - 1);
                                break;
                            }
                        case 7: 
                            {
                                SetInfoRule(TempData, 6, e.RowIndex, e.ColumnIndex, Math.Pow(2, 16) - 1);
                                break;
                            }
                        case 8:
                            {
                                SetInfoRule(TempData, 6, e.RowIndex, e.ColumnIndex, Math.Pow(2, 16) - 1);
                                break;
                            }
                        case 9:
                            {
                                SetInfoRule(TempData, 6, e.RowIndex, e.ColumnIndex, Math.Pow(2, 16) - 1);
                                break;
                            }
                        case 10:
                            {
                                SetInfoRule(TempData, 10, e.RowIndex, e.ColumnIndex, Math.Pow(2, 16) - 32);
                                break;
                            }
                        default:
                                break;
                    }
                }
            }
        }

        private void SetInfoRule(string TempData, int ValibBit, int Row, int Col, double RangeValue)
        {
            string Error_Mes = ValibBit == 6 ? "0 to 2^16. Such as 0xXXXX(Hex)!" : "0 to 2^32. Such as 0xXXXXXXXX(Hex)!";
           
            if (Regex.IsMatch(TempData, @"^[0-9]+$") && TempData.Length < 11)
            {//if (!Regex.IsMatch(InfoTableList[e.RowIndex].ToString(), @"^[0-9a-fxA-FX]+$"))
                if (double.Parse(TempData) > RangeValue)
                {
                    XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Warning", true);
                    MessageBox.Show("Input Value is range of 0 ~ "+ RangeValue + "(Dec)"+", Please Check again, Thz !", "Warning");
                    DataGridView_SDCard.Rows[Row].Cells[Col].Value = InfoTableList[Row];
                }
                else { InfoTableList[Row] = TempData; }
            }
            else if (!Regex.IsMatch(TempData.ToString(), @"^[0-9a-fxA-FX]+$"))
            {
                XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Warning", true);
                MessageBox.Show("Input Value is within the range of " + Error_Mes, "Warning");
                DataGridView_SDCard.Rows[Row].Cells[Col].Value = InfoTableList[Row];
            }
            else
            {
                if (TempData.Length > ValibBit || !TempData.ToUpper().StartsWith("0X"))
                {
                    XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Warning", true);
                    MessageBox.Show("Input Value is within the range of " + Error_Mes, "Warning");
                    DataGridView_SDCard.Rows[Row].Cells[Col].Value = InfoTableList[Row];
                }
                else { InfoTableList[Row] = TempData; }
            }

        }

        // advoid Users to edit for certain cell
        private void DataGridView_SDCard_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //判断是否可以编辑  
            if (dgv.Columns[e.ColumnIndex].Name == "Item"
                || dgv.Columns[e.ColumnIndex].Name == "File Path")//&&
                                                                  //  !(bool)dgv["Column2", e.RowIndex].Value)
            {
                // Can't edit for this cell
                e.Cancel = true;
            }
        }

        private void GenerateBotton(DataGridView GridView, int addColumns_num)
        {
            //檢查 dataGridView1 中是否至少綁定了一列
            //if (string.IsNullOrEmpty(GridView.Columns[0].Name))
            //return;

            //DataGridView 中專門用來顯示 Checkbox 控件的列對象；dataGridView1 中添加此對象後，綁定數據時就會自動為每行創建一個新的 CheckBox 控件
            //當然這一步也可以省略，換成直接在 dataGridView1 的 Columns 屬性中添加一列，然後將其 ColumnType 設置成 DataGridViewCheckBoxColumn 即可
            DataGridViewButtonColumn gridViewBottonCol = new DataGridViewButtonColumn
            {
                Width = 20,
                HeaderText = "Load",
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
                ReadOnly = false //若為 true 則無法選擇 CheckBox
            };

            //把 dataGridView1 的第一列設置成 CheckBox 格式的列
            GridView.Columns.Insert(3, gridViewBottonCol);

            DataGridViewButtonColumn gridViewBottonCol1 = new DataGridViewButtonColumn
            {
                Width = 20,
                HeaderText = "Clear",
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
                ReadOnly = false //若為 true 則無法選擇 CheckBox
            };

            //把 dataGridView1 的第一列設置成 CheckBox 格式的列
            GridView.Columns.Insert(4, gridViewBottonCol1);
        }

        private void GenerateCheckbox(DataGridView GridView)
        {
            GridView.Controls.Clear();

            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            DatagridViewCheckBoxHeaderCell cbHeader = new DatagridViewCheckBoxHeaderCell();
            colCB.HeaderCell = cbHeader;
            GridView.Columns.Insert(0, colCB);

            cbHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(CbHeader_OnCheckBoxClicked);
        }

        private void GenerateDataGridViewColRow(DataGridView GridView, string[] ColList, string[] RowList, ref DataTable dt)
        {
            // add Columns.
            foreach (var Col in ColList)
            {
                DataColumn colItem = new DataColumn(Col, Type.GetType("System.String"));
                dt.Columns.Add(colItem);
            }
            // add Rows.
            DataRow NewRow;
            for (int j = 0; j < RowList.Length; j++)
            {
                NewRow = dt.NewRow();
                NewRow[Tab1ColList[0]] = RowList[j];
                dt.Rows.Add(NewRow);
            }
            GridView.DataSource = dt;
        }

        private void InitialPgsBar()
        {
            InvokePrgbMax(100);
            RichTextBox_SDCardReadInfo.Text = "";
        }

        private void InvokePrgbMax(int Val)
        {
            MyMarshalToForm((int)MSG.MSG_VAL, Val.ToString(), "");
        }

        private void InvokePrgbPos(int Pos)
        {
            MyMarshalToForm((int)MSG.MSG_PROG, Pos.ToString(), "");
        }

        private void InfoTable(string Filepath, ref int Addr, ref int Blocks, bool ShowStatus)
        {
            // SD information table address from 0x0000~0x01ff(512 bytes)
            //-----------------------------------------------------
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string FilePath = Filepath;
            string line;
            int Row_Length = 0;

            // byte[] test = new byte[100];
            byte[] ICVersion = new byte[16];
            int Length = 0;
            int Line_Length = 0;
            int j = 0;
           
            try
            {
                using (StreamReader sr = new StreamReader(FilePath, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line.ToString());
                        line = line.Substring(line.IndexOf('=') + 1);
                        InfoTableList[Row_Length] = line;
                        // InfoName
                        if (Row_Length == 0)
                        {
                            if (line.Length != 16)
                            { line = line.PadRight(16, '\0'); }
                            ICVersion = Encoding.ASCII.GetBytes(line);
                            Line_Length = line.Length > 16 ? 16 : 16;// line.Length;
                            for (j = 0; j < Line_Length; j++)
                            {
                                bufftemp[Row_Length, j] = ICVersion[j];
                            }
                        }
                        else if (Row_Length >= 1 && Row_Length <= 2)
                        {
                            if (line.StartsWith("0x"))
                            {
                                line = line.Replace("0x", "");
                                if (Row_Length == 1)
                                {
                                    line = line.PadLeft(8, '0');
                                    Length = 0;
                                }
                                if (Row_Length == 2)
                                    line = line.PadLeft(4, '0');
                                for (j = 0; j < line.Length; j++)
                                {
                                    // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                    if ((j % 2 == 1))
                                    {
                                        bufftemp[1, (j / 2) + Length] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                    }
                                }
                                Length = j / 2;
                            }
                        }
                        else if (Row_Length >= 3 && Row_Length <= 4)
                        {
                            if (line.StartsWith("0x"))
                            {
                                line = line.Replace("0x", "");
                                if (Row_Length == 3)
                                {
                                    Length = 0;
                                    line = line.PadLeft(8, '0');
                                }
                                if (Row_Length == 4)
                                    line = line.PadLeft(4, '0');
                                for (j = 0; j < line.Length; j++)
                                {
                                    // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                    if ((j % 2 == 1))
                                    {
                                        bufftemp[2, (j / 2) + Length] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                    }
                                }
                                Length = j / 2;
                            }
                        }
                        else if (Row_Length >= 5 && Row_Length <= 6)
                        {
                            if (line.StartsWith("0x"))
                            {
                                line = line.Replace("0x", "");
                                if (Row_Length == 5)
                                {
                                    Length = 0;
                                    line = line.PadLeft(8, '0');
                                }
                                if (Row_Length == 6)
                                    line = line.PadLeft(4, '0');

                                for (j = 0; j < line.Length; j++)
                                {
                                    // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                    if ((j % 2 == 1))
                                    {
                                        bufftemp[4, (j / 2) + Length] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                    }
                                }
                                Length = j / 2;
                            }
                        }
                        else if (Row_Length == 7)
                        {
                            // Length = 0;
                            if (line.StartsWith("0x"))
                            {
                                line = line.Replace("0x", "");
                                line = line.PadLeft(4, '0');
                                for (j = 0; j < line.Length; j++)
                                {
                                    // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                    if ((j % 2 == 1))
                                    {
                                        bufftemp[5, 4 + (j / 2)] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                    }
                                }
                            }
                            else
                            {
                                //line = "0x"+line.PadLeft(4, '0');
                                line = Convert.ToInt16(line).ToString("x");
                                line = line.Replace("0x", "");
                                line = line.PadLeft(4, '0');
                                for (j = 0; j < line.Length; j++)
                                {
                                    // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                    if ((j % 2 == 1))
                                    {
                                        bufftemp[5, 4 + (j / 2)] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (line.StartsWith("0x"))
                            {
                                line = line.Replace("0x", "");
                                if (Row_Length == 8)
                                {
                                    Length = 0;
                                    line = line.PadLeft(4, '0');
                                }

                                if (Row_Length == 9)
                                    line = line.PadLeft(4, '0');

                                if (Row_Length == 10)
                                {
                                    Length = Length + 4;
                                    line = line.PadLeft(8, '0');
                                }

                                for (j = 0; j < line.Length; j++)
                                {
                                    // in order to get two bit(0~1, 2~3, ..., N-2~N-1) from String each time.
                                    if ((j % 2 == 1))
                                    {
                                        bufftemp[6, (j / 2) + Length] = (Convert.ToByte(("0x" + line.Substring(j - 1, 2)), 16));
                                    }
                                }
                                Length = j / 2;
                            }
                        }
                        Row_Length++;
                    }
                    //LoadSDCardInfoPath = FilePath;
                    if (ShowStatus)
                    {
                        for (int i = 0; i < ListGridView[0].RowCount; i++)
                        {
                            if (i < InfoTableList.Length)
                                ListGridView[0].Rows[i].Cells[1].Value = InfoTableList[i]; // When Form is maximum , componet need to reset loaction and size.;

                            // Row_Length is string type.
                            if (i == 7)
                            {
                                // Show Decimal
                                if (InfoTableList[i].ToString().ToUpper().StartsWith("0X"))
                                    ListGridView[0].Rows[i].Cells[1].Value = Convert.ToInt32(InfoTableList[i].ToString(), 16);
                                else
                                    ListGridView[0].Rows[i].Cells[1].Value = Convert.ToInt32(InfoTableList[i].ToString(), 10);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Confirm Message", true);
                MessageBox.Show("File Content is abnormal, Please check again !", "Confirm Message");
            }
        }

        private void InvokeRichBox(String Context)
        {
            MyMarshalToForm((int)MSG.MSG_RICH, Context, "");
        }

        private void InvokeMultiRD_Bott(String Context)
        {
            MyMarshalToForm((int)MSG.MSG_MULTIRD, Context, "");
        }

        private void InvokeDownload_Bott(String Context)
        {
            MyMarshalToForm((int)MSG.MSG_DOWNLOAD, Context, "");
        }

        private void InvokeSDText(String Context, object Color)
        {
            MyMarshalToForm((int)MSG.MSG_SDTEXT, Context, Color);
        }

        private void Init_DataGridView(DataGridView GridView, string TabPage_Index)
        {
            try
            {
                GridView.AutoGenerateColumns = true;
                GridView.AllowUserToAddRows = true;
                // GridView.Dock = DockStyle.Fill;
                GridView.DataSource = null;
                DataTable dt = new DataTable();
                GridView.Columns.Clear();

                // show row index be set start from 1, not 0(zero).
                //int rowNumber = 1;

                if (TabPage_Index == "tabPage1")
                {
                    GenerateDataGridViewColRow(GridView, Tab1ColList, Tab1RowList, ref tab1dt);
                    dt = tab1dt;
                }
                else
                {
                    GenerateDataGridViewColRow(GridView, Tab2ColList, Tab2RowList, ref tab2dt);
                    dt = tab2dt;
                }

                // Show the index on the HeaderCell.
                //foreach (DataGridViewRow row1 in GridView.Rows)//Re-Writing code  
                //{
                //    if (row1.IsNewRow) continue;
                //    // set to HeaderCell.Value must be string format.
                //    row1.HeaderCell.Value = string.Format("{0}", rowNumber);
                //    rowNumber++;
                //}
                dt.AcceptChanges();
                GridView.DataSource = dt;
                GridView.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadFileEvent(int row, int col)
        {
            DataGridViewButtonCell cell = (DataGridViewButtonCell)DataGridView_SDCard.Rows[row].Cells[col];

            XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSDCardDirPath);
            string FilePath = IniUtil.IniReadValue("System", "ScriptDir");
            FilePath = (FilePath == "NULL") ? Setting.ExeImgDirPath : FilePath;

            XM_IO_Util IO_Util = new XM_IO_Util();

            //in order to Keep Document alway exist.
            //if (!File.Exists(Setting.ExeSDCardDirPath))
            //{
            //    IO_Util.CreateDir(Setting.ExeSDCardDirPath);
            //}
            // TempString = "\\MicroSDInfo.txt";
            //FilePath = FilePath;//Setting.ExeSDCardDirPath;// + TempString;

            OpenFileDialog SDCard_File = new OpenFileDialog
            {
                FileName = "SDCardGenFile.txt",
                Filter = "Text Files|*.txt|*.text|*.spt",
                InitialDirectory = FilePath,
                DefaultExt = "*.txt"
            };

            if (SDCard_File.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //IniUtil.IniWriteValue("System", "ScriptDir", SDCard_File.FileName);
                // Show filename on the File Path.
                DataGridView_SDCard.Rows[row].Cells[col - 1].Value = SDCard_File.FileName;
                Deal_ChkBox_Path(DataGridView_SDCard, row, col, true, 3);
                LoadSDCardInfo = true;
                if (DataGridView_SDCard.RowCount <= row + 1 && row >= 4)
                {
                    // autu add one Row on datagridview at last.
                    ListGridView[1].AllowUserToAddRows = true;
                    ListGridView[1].CurrentCell = ListGridView[1].Rows[row + 1].Cells[0];
                    ListGridView[1].AllowUserToAddRows = false;
                    ListGridView[1].Refresh();
                    Deal_ChkBox_Path(ListGridView[1], 0, 0, false, 0);
                    Deal_ChkBox_Path(DataGridView_SDCard, row, col, true, 3);
                }
            }
        }

        private void LoadPictureEvent(int row, int col)
        {
            DataGridViewButtonCell cell = (DataGridViewButtonCell)ListGridView[1].Rows[row].Cells[col];

            XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSDCardDirPath);
            string FilePath = IniUtil.IniReadValue("System", "ScriptDir");
            FilePath = (FilePath == "NULL") ? Setting.ExeImgDirPath : FilePath;

            OpenFileDialog ImageFile = new OpenFileDialog
            {
                FileName = "SDCard_InfoScript.txt",
                Filter = "Text Files|*.txt|*.text|*.spt",
                InitialDirectory = FilePath,
                DefaultExt = "*.txt"
            };

            if (ImageFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IniUtil.IniWriteValue("System", "ImageDir", ImageFile.FileName);
                // Show filename on the File Path.
                ListGridView[1].Rows[row].Cells[col - 1].Value = ImageFile.FileName;
                
                int Addr = 0, Blocks = 1 ;
                LoadSDCardInfo = true;
                SDCard_Util.SDCard_Item[4].ItemFilePath[row - 4] = ImageFile.FileName;

                Addr = Convert.ToInt32((string)InfoTableList[5], 16);
                Blocks = Convert.ToInt32((string)InfoTableList[6], 16);

                // When Checkbox is enabled, ImageNum will not to add, advoid to recount. 
                if (SDCard_Util.SDCard_Item[4].ImageNum <= row - 3)
                    SDCard_Util.SDCard_Item[4].ImageNum = AutoCalimag_nums = row - 3;

                for (int i = 0; i < row - 3; i++)
                {
                    if (SDCard_Util.SDCard_Item[4].ItemFilePath[i] == "")
                        SDCard_Util.SDCard_Item[4].ImageNum--;
                }

                // Image
                InfoTableList[10] = string.Format("0x" + (Addr + Blocks).ToString("X08"));
                CalAddandBlocks(ImageFile.FileName, ref Addr, ref Blocks);
                InfoTableList[8] = string.Format("0x" + SDCard_Util.SDCard_Item[4].ImageNum.ToString("X04"));
                InfoTableList[9] = string.Format("0x" + Blocks.ToString("X04"));

                // Enable Checkbox. 
                Deal_ChkBox_Path(DataGridView_SDCard, row, col, true, 3);

                // autu add one Row on datagridview at last.
                ListGridView[1].AllowUserToAddRows = true;
                ListGridView[1].CurrentCell = ListGridView[1].Rows[row + 1].Cells[0];
                ListGridView[1].AllowUserToAddRows = false;
                ListGridView[1].Refresh();
                Deal_ChkBox_Path(ListGridView[1], 0, 0, false, 0);
                Deal_ChkBox_Path(DataGridView_SDCard, row, col, true, 3);
            }
        }

        private bool UpdataInfortable()
        {
            int Addr = 0, Blocks = 1, ImageNum = 0;
            for (int i = 0; i < ListGridView[1].RowCount; i++)
            {
                if (i <= 3)
                {
                    if (ChkBoxStatus[i] == true)
                    {
                        switch (i)
                        {
                            case 0:
                                InfoTable(SDCard_Util.SDCard_Item[i].ItemFilePath[0], ref Addr, ref Blocks, false);
                                break;
                            case 1:
                                CalAddandBlocks(SDCard_Util.SDCard_Item[i].ItemFilePath[0], ref Addr, ref Blocks);
                                InfoTableList[1] = string.Format("0x00000001");
                                InfoTableList[2] = string.Format("0x" + Blocks.ToString("X04"));
                                Addr = Convert.ToInt32((string)InfoTableList[1], 16);
                                Blocks = Convert.ToInt32((string)InfoTableList[2], 16);
                                break;
                            case 2:
                                CalAddandBlocks(SDCard_Util.SDCard_Item[i].ItemFilePath[0], ref Addr, ref Blocks);
                                InfoTableList[3] = string.Format("0x" + Addr.ToString("X08"));
                                InfoTableList[4] = string.Format("0x" + Blocks.ToString("X04"));
                                Addr = Convert.ToInt32((string)InfoTableList[3], 16);
                                Blocks = Convert.ToInt32((string)InfoTableList[4], 16);
                                break;
                            case 3:
                                CalAddandBlocks(SDCard_Util.SDCard_Item[i].ItemFilePath[0], ref Addr, ref Blocks);
                                InfoTableList[5] = string.Format("0x" + Addr.ToString("X08"));
                                InfoTableList[6] = string.Format("0x" + Blocks.ToString("X04"));
                                Addr = Convert.ToInt32((string)InfoTableList[5], 16);
                                Blocks = Convert.ToInt32((string)InfoTableList[6], 16);
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    if (ChkBoxStatus[i] == true)
                    {
                        CalAddandBlocks(SDCard_Util.SDCard_Item[4].ItemFilePath[ImageNum], ref Addr, ref Blocks);
                        ImageNum++;
                        if (ImageNum == 1)
                        {
                            InfoTableList[9] = string.Format("0x" + Blocks.ToString("X04"));
                            InfoTableList[10] = string.Format("0x" + (Convert.ToInt32((string)InfoTableList[5], 16) + Convert.ToInt32((string)InfoTableList[6], 16)).ToString("X08"));
                        }
                            InfoTableList[8] = string.Format("0x" + ImageNum.ToString("X04"));  
                    }
                }
            }
            return true;
        }

        private void MultiReadBlock()
        {
            EnaResultLog = true;
            InvokeMultiRD_Bott("Stop");
            InvokePrgbPos(0);
                IntPtr ptr = Marshal.AllocHGlobal((int)bs);
                int i, x, y;
                //-----------------------------------------------------
                // default block size : 512 bytes
                // multiple block read
                uSD_RD_addr = Function.StrToHexOrDec(textBox_ReadStartAddr.Text);
                uSD_RD_blocknums = Function.StrToHexOrDec(textBox_ReadBlockNums.Text);

                if (sd_type == false)
                {
                    uSD_RD_addr = uSD_RD_addr << 9;
                }

                // uSD.Spi_cs_L.
                SDCard_Util.Spi_cs_L();

                // Addr_Wr_Mode.
                SDCard_Util.Addr_Wr_Mode();

                buf[0] = 0x52;                                              // CMD18 : multiple block read
                buf[1] = (byte)((uSD_RD_addr >> 24) & 0xff);
                buf[2] = (byte)((uSD_RD_addr >> 16) & 0xff);
                buf[3] = (byte)((uSD_RD_addr >> 8) & 0xff);
                buf[4] = (byte)((uSD_RD_addr >> 0) & 0xff);                 // 4 byte address
                buf[5] = 0xff;                                              // CRC, don't care
                buf[6] = 0xff;                                              // dummy clk, 8clks(1byte)
                x = 7;
                Marshal.Copy(buf, 0, ptr, x);
                SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);

                // Data_Rd_Mode.
                SDCard_Util.Data_Rd_Mode();

                InvokePrgbPos(5);
                i = 0;
                do
                {
                    // rd_8bit.
                    SDCard_Util.Rd_8bit(ref x);

                    i++;
                    InvokeRichBox(i.ToString("D04") + ":CMD18(multi read) response (0x00) : 0x" + x.ToString("X02") + "\r\n");
                } while ((x != 0x00) & (i < 10));
                if (x != 0x00)
                { InvokeRichBox("multi read fail! \r\n" + "Read Multi-Block fail!\r\n "); goto TheEnd; }
                else
                { InvokeRichBox("multi read ok! \r\n" + "Read Multi-Block ok!\r\n "); }

                InvokePrgbPos(10);

                y = 0;
                do
                {
                    y++;
                    do
                    {
                        // rd_8bit.
                        SDCard_Util.Rd_8bit(ref x);

                        i++;
                        InvokePrgbPos(((int)(10 * i / 100) < 10) ? (10 + (int)(10 * i / 100)) : 20);
                    } while (x != 0xfe );                                        // single read start byte : 0xfe
                   
                    // 512byte data + 2byte CRC. (FPGA SPI read needed 2 times)
                    x = 512 * 2 + 2 * 2;

                    SDCard_Util.UsbReadScanner(ptr, (uint)x, 0x00);
                    Marshal.Copy(ptr, buf, 0, (int)x);

                    InvokeRichBox("block 0x" + y.ToString("X08") + ": ......\r\n");
                    for (i = 0; i < 512; i++)
                    {
                        InvokeRichBox(i.ToString("D3") + ":0x" + buf[i * 2 + 1].ToString("X02") + "\r\n");
                        InvokePrgbPos(((int)(75 * i / 512) < 75) ? (20 + (int)(75 * i / 512)) : 95);
                    }
                } while (y < uSD_RD_blocknums && Run);

                // Spi_cs_H_wd.
                SDCard_Util.Spi_cs_H_wd();
                //-----------------------------------------------------
                // CMD12 : stop transmission

                // uSD.Spi_cs_L.
                SDCard_Util.Spi_cs_L();

                // Addr_Wr_Mode.
                SDCard_Util.Addr_Wr_Mode();

                buf[0] = 0x4c;                                              // CMD12 : stop transmission
                buf[1] = 0x00; buf[2] = 0x00; buf[3] = 0x00; buf[4] = 0x00; // 0 parameter
                buf[5] = 0xff;                                              // CRC, don't care
                buf[6] = 0xff;                                              // dummy clk, 8clks(1byte)
                x = 7;
                Marshal.Copy(buf, 0, ptr, x);
                SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);

                // Data_Rd_Mode.
                SDCard_Util.Data_Rd_Mode();

                i = 0;
                do
                {
                    // rd_8bit.
                    SDCard_Util.Rd_8bit(ref x);

                    i++;
                    InvokeRichBox(i.ToString("D04") + ":CMD12 response (> 0) : 0x" + x.ToString("X02") + "\r\n");
                    InvokePrgbPos(((int)(5 * i / 100) < 5) ? (95 + (int)(5 * i / 100)) : 100);
                } while ((x == 0x00) & (i < 10));
                if (x > 0x00)
                { InvokeRichBox("CMD12 stop trans...pass! \r\n" + "Read Multi-Block ok!\r\n "); }
                else
                { InvokeRichBox("CMD12 stop trans...fail! \r\n" + "Read Multi-Block fail!\r\n "); }

                TheEnd:
                // Spi_cs_H_wd.
                SDCard_Util.Spi_cs_H_wd();
                //-----------------------------------------------------
                Marshal.FreeHGlobal(ptr);
                InvokePrgbPos(100);
                Run = false;
                InvokeMultiRD_Bott("Multi-RD");

        }

        private void ManualSetColumnWidth(DataGridView GridView, string TabPage_Index)
        {
            GridView.RowHeadersWidth = 35;

            // Data of alignment is middleCenter.
            GridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ColumnHeader of alignment is TopCenter.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Calibri", 10, FontStyle.Regular);
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            //
            int test = 0;
            foreach (DataGridViewColumn column in GridView.Columns)
            {
                if (test / 2 == 0)
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                test++;
            }

            //設置標題高度
            GridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            GridView.ColumnHeadersHeight = 37;

            // Set the column header style.


            if (TabPage_Index == "tabPage1")
            {
                GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                GridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            else
            {

                GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                GridView.Columns[0].Width = 40;
                GridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                GridView.Columns[2].Width = 255;
                GridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                GridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

        }

        // Show Text information on RichTextbox on time.
        private void RichTextBox_SDCardReadInfo_TextChanged(object sender, EventArgs e)
        {
            
            //RichTextBox_SDCardReadInfo.SelectionStart = RichTextBox_SDCardReadInfo.TextLength;

            //// Scrolls the contents of the control to the current caret position.
            //RichTextBox_SDCardReadInfo.Suspend();
            //RichTextBox_SDCardReadInfo.ScrollToCaret();
            //RichTextBox_SDCardReadInfo.Resume();
        }

        private void RichTextBox_SDCardReadInfo_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Result Log ?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //delete
                RichTextBox_SDCardReadInfo.Clear();
            }
        }

        public SDCardControl()
        {
            InitializeComponent();

            SDCard_Util.GroBoxResult_X = groupBox_Result.Location.X;
            SDCard_Util.GroBoxResult_Y = groupBox_Result.Location.Y;
            SDCard_Util.GroBoxResult_Width = groupBox_Result.Width;
            SDCard_Util.GroBoxResult_Height = groupBox_Result.Height;

            SDCard_Util.TabControl_X = TabControl_SDCard.Location.X;
            SDCard_Util.TabControl_Y = TabControl_SDCard.Location.Y;
            SDCard_Util.TabControl_Width = TabControl_SDCard.Width;
            SDCard_Util.TabControl_Height = TabControl_SDCard.Height;

            SDCard_Util.buttonSaveSDInfo_X = button_Save_SDInfo.Location.X;
            SDCard_Util.buttonSaveSDInfo_Y = button_Save_SDInfo.Location.Y;
            SDCard_Util.buttonSaveSDInfo_Width = button_Save_SDInfo.Width;
            SDCard_Util.buttonSaveSDInfo_Height = button_Save_SDInfo.Height;

            SDCard_Util.buttonLoadSDInfo_X = button_Load_SDInfo.Location.X;
            SDCard_Util.buttonLoadSDInfo_Y = button_Load_SDInfo.Location.Y;
            SDCard_Util.buttonLoadSDInfo_Width = button_Load_SDInfo.Width;
            SDCard_Util.buttonLoadSDInfo_Height = button_Load_SDInfo.Height;

            SDCard_Util.WindowsForm_Width = this.Width;
            SDCard_Util.WindowsForm_Height = this.Height;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void SDCardControl_Load(object sender, EventArgs e)
        {
           
            ArrayList ArrayList = new ArrayList();
            InitialPgsBar();
            toolStrStaLab_SDCardStatus.Text = "SD Card Status : No Found !!";
            toolStrStaLab_SDCardStatus.ForeColor = Color.Red;

            tab1GridView = DataGridView_SDCard;
            tab2GridView = DataGridView_SDCard;
            ListGridView.Add(tab1GridView);
            ListGridView.Add(tab2GridView);

            SDCard_Util.InitalSDCard_Item();

            for (int i = ListGridView.Count - 1; i >= 0; i--)
            {
                // Set DataGridView odd row color.
                ListGridView[i].AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
                if (i == 1)
                {
                    Init_DataGridView(ListGridView[i], TabControl_SDCard.TabPages[i].Name);
                    GenerateCheckbox(ListGridView[i]);
                    GenerateBotton(ListGridView[i], 3);
                    ManualSetColumnWidth(ListGridView[i], TabControl_SDCard.TabPages[i].Name);
                    DisableColumnHeaderSort(ListGridView[i]);
                    TabControl_SDCard.SelectedIndex = 1;
                }
                else
                {
                    Init_DataGridView(ListGridView[i], TabControl_SDCard.TabPages[i].Name);
                    ManualSetColumnWidth(ListGridView[i], TabControl_SDCard.TabPages[i].Name);
                    ListGridView[i].Controls.Clear();
                    DisableColumnHeaderSort(ListGridView[i]);
                    TabControl_SDCard.SelectedIndex = 0;
                }
            }
            TabControl_SDCard.SelectedIndex = 1;
        }

        private void SDCardControlForm_Resize()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            if (this.WindowState == FormWindowState.Maximized)
            {

                TabControl_SDCard.Width = (screenWidth * 2 / 3) - 10;
                TabControl_SDCard.Height = screenHeight - groupBox_SDStatus.Height;
                groupBox_Result.Location = new Point(screenWidth * 2 / 3, 5);
                groupBox_Result.Width = (screenWidth * 1 / 3) - 10;
                groupBox_Result.Height = TabControl_SDCard.Height;
                if (TabControl_SDCard.SelectedIndex == 0)
                {
                    button_Save_SDInfo.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    button_Load_SDInfo.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    button_Save_SDInfo.Location = new Point(button_Save_SDInfo.Location.X, button_Save_SDInfo.Location.Y);
                    button_Save_SDInfo.Width = TabControl_SDCard.Width / 2 - 16;
                    button_Load_SDInfo.Location = new Point(button_Save_SDInfo.Location.X + button_Save_SDInfo.Width, button_Save_SDInfo.Location.Y);
                    button_Load_SDInfo.Width = TabControl_SDCard.Width / 2 - 16;
                }
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Width = SDCard_Util.WindowsForm_Width;
                this.Height = SDCard_Util.WindowsForm_Height;

                groupBox_Result.Location = new Point(SDCard_Util.GroBoxResult_X, SDCard_Util.GroBoxResult_Y);
                groupBox_Result.Width = SDCard_Util.GroBoxResult_Width;
                groupBox_Result.Height = SDCard_Util.GroBoxResult_Height;

                TabControl_SDCard.Location = new Point(SDCard_Util.TabControl_X, SDCard_Util.TabControl_Y);
                TabControl_SDCard.Width = SDCard_Util.TabControl_Width;
                TabControl_SDCard.Height = SDCard_Util.TabControl_Height;

                button_Save_SDInfo.Location = new Point(SDCard_Util.buttonSaveSDInfo_X, SDCard_Util.buttonSaveSDInfo_Y);
                button_Save_SDInfo.Width = SDCard_Util.buttonSaveSDInfo_Width;

                button_Load_SDInfo.Location = new Point(SDCard_Util.buttonLoadSDInfo_X, SDCard_Util.buttonLoadSDInfo_Y);
                button_Load_SDInfo.Width = SDCard_Util.buttonLoadSDInfo_Width;
            }
        }

        // When Form is maximum , componet need to reset loaction and size.
        private void SDCardControl_Resize(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            SDCardControlForm_Resize();
        }

        private void ShowSDCardInfo(bool SaveTableInfo)
        {
            if (!SaveTableInfo)
            {
                LoadSDCardInfo = true;
                for (int i = 0; i < 11/*ListGridView[0].RowCount*/; i++)
                {
                    if (InfoTableList[i] == null)
                    { if (i == 0) InfoTableList[i] = "XM_PLUS"; if (i == 7) InfoTableList[i] = 3000; }
                    if (i < InfoTableList.Length)
                        ListGridView[0].Rows[i].Cells[1].Value = InfoTableList[i]; // When Form is maximum , componet need to reset loaction and size.;
                                                                                   // Row_Length is string type.
                }
            }
            else
            {
                InfoTableList[0] = ListGridView[0].Rows[0].Cells[1].Value;
                InfoTableList[1] = ListGridView[0].Rows[1].Cells[1].Value;
                InfoTableList[2] = ListGridView[0].Rows[2].Cells[1].Value;
                InfoTableList[3] = ListGridView[0].Rows[3].Cells[1].Value;
                InfoTableList[4] = ListGridView[0].Rows[4].Cells[1].Value;
                InfoTableList[5] = ListGridView[0].Rows[5].Cells[1].Value;
                InfoTableList[6] = ListGridView[0].Rows[6].Cells[1].Value;
                InfoTableList[7] = ListGridView[0].Rows[7].Cells[1].Value;
                InfoTableList[8] = ListGridView[0].Rows[8].Cells[1].Value;
                InfoTableList[9] = ListGridView[0].Rows[9].Cells[1].Value;
                InfoTableList[10] = ListGridView[0].Rows[10].Cells[1].Value;
            }
        }

        // SD card Single block write.
        private bool SD_single_block_write(int addr, byte[,] bufftemp, string DownItem)
        {
            //EnaResultLog = false;
            // SD block size = 512 byte, XM used as default setting
            InvokePrgbMax(100);
            InvokePrgbPos(0);
            byte[] bufwr = new byte[517];               // 512 data byte + 3byte write start(0xff,0xff,0xfe) + 2 byte CRC
            bool WriteBlockResult = true;

            IntPtr ptr = Marshal.AllocHGlobal((int)bs);
            int i, x, y;

            //-----------------------------------------------------
            // default block size : 512 bytes
            // single block write => CMD24
            if (sd_type == false)
            { addr = addr << 9; }

            SDCard_Util.Spi_cs_L();

            SDCard_Util.Addr_Wr_Mode();

            bufwr[0] = 0x58;                            // CMD24
            bufwr[1] = (byte)((addr >> 24) & 0xff);
            bufwr[2] = (byte)((addr >> 16) & 0xff);
            bufwr[3] = (byte)((addr >> 8) & 0xff);
            bufwr[4] = (byte)((addr >> 0) & 0xff);      // 4 byte address
            bufwr[5] = 0xff;                            // CRC, don,t care
            bufwr[6] = 0xff;                            // dummy clk, 8clks(1byte)
            x = 7;
            Marshal.Copy(bufwr, 0, ptr, x);
            SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);

            SDCard_Util.Data_Rd_Mode();
            InvokePrgbPos(5);
            i = 0;
            do
            {
                SDCard_Util.Rd_8bit(ref x);
                i++;
                //InvokeRichBox(i.ToString("D04") + ":CMD24 response (0x00) : 0x" + x.ToString("X02") + "\r\n");
                InvokePrgbPos(((int)(15 * i / 100) < 15) ? (5 + (int)(15 * i / 100)) : 20);
            } while ((x != 0x00) & (i < 10));
            if (x != 0x00)
            { InvokeRichBox("CMD24...fail \r\n\r\n"); WriteBlockResult = false;  return WriteBlockResult; }
            else
            { /*InvokeRichBox("CMD24...pass \r\n\r\n");*/ }
            //-----------------------------------------------------
            bufwr[0] = 0xff; bufwr[1] = 0xff; bufwr[2] = 0xfe;  // single write start byte : 0xfe

            for (int row = 0; row < 32; row++)
            {
                for (int col = 0; col < 16; col++)
                {
                    bufwr[(row* 16) + col + 3] = bufftemp[row, col];
                }
            }

            bufwr[515] = 0xff; bufwr[516] = 0xff;               // CRC

            SDCard_Util.Addr_Wr_Mode();

            x = 517;
            Marshal.Copy(bufwr, 0, ptr, x);
            SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);        // SD single block progranning
            //-----------------------------------------------------

            SDCard_Util.Data_Rd_Mode();
            InvokePrgbPos(30);

            i = 0;
            do
            {
                SDCard_Util.Rd_8bit(ref x);
                y = x & 0x0f;
                i++;
               // InvokeRichBox(i.ToString("D04") + ": write response (0xX5) : 0x" + x.ToString("X02") + "\r\n");
                InvokePrgbPos(((int)(10* i / 100) < 10) ? (30 + (int)(10 * i / 100)) : 40);
            } while ((y != 0x05) && (i < 10));

            if (y == 0x05)
            { InvokeRichBox("write success... \r\n\r\n"); }
            else
            { InvokeRichBox("write fail... \r\n\r\n"); WriteBlockResult = false; return WriteBlockResult; }
            Thread.Sleep(10);
            //-----------------------------------------------------
            i = 0;
            do
            {
                SDCard_Util.Rd_8bit(ref x);
                i++;
               // InvokeRichBox(i.ToString("D04") + ": status response (0xff) : 0x" + x.ToString("X02") + "\r\n");
                Thread.Sleep(10);
                InvokePrgbPos(((int)(10 * i / 100) < 10) ? (40 + (int)(10 * i / 100)) : 50);
            } while ((x != 0xff) & (i < 50));

            // Show Download Data on RichTextBox.
            for (int row = 0; row < 32; row++)
            {
                for (int col = 0; col < 16; col++)
                {
                   // InvokeRichBox("0x" + bufftemp[row, col].ToString("X02") + "  ");
                    InvokePrgbPos(((int)(50 * ((row * 16) + col) / 510) < 50) ? (50 + (int)(50 * ((row * 16) + col) / 510)) : 100);
                }
                //InvokeRichBox("\r\n");
            }

            if (x != 0xff)
            { InvokeRichBox("\r\n" + DownItem + "single block write fail... \r\n\r\n"); WriteBlockResult = false; return WriteBlockResult; }
            else
            { InvokeRichBox("\r\n" + DownItem + "single block write ok... \r\n\r\n"); }


            SDCard_Util.Spi_cs_H_wd();
            //-----------------------------------------------------
            Marshal.FreeHGlobal(ptr);
            //EnaResultLog = true;
            return WriteBlockResult;
        }

        // SD Only Read one Block once. 
        private void SingleReadBlock()
        {
            InvokePrgbPos(0);
            EnaResultLog = true;
            IntPtr ptr = Marshal.AllocHGlobal((int)bs);
            int i, x;

            //-----------------------------------------------------
            // default block size : 512 bytes
            // single block read
            uSD_RD_addr = Function.StrToHexOrDec(textBox_ReadStartAddr.Text);
            if (sd_type == false)
            {
                uSD_RD_addr = uSD_RD_addr << 9;
            }

            // uSD.Spi_cs_L.
            SDCard_Util.Spi_cs_L();

            // Addr_Wr_Mode.
            SDCard_Util.Addr_Wr_Mode();

            buf[0] = 0x51;                                              // CMD17
            buf[1] = (byte)((uSD_RD_addr >> 24) & 0xff);
            buf[2] = (byte)((uSD_RD_addr >> 16) & 0xff);
            buf[3] = (byte)((uSD_RD_addr >> 8) & 0xff);
            buf[4] = (byte)((uSD_RD_addr >> 0) & 0xff);                // 4 byte address
            buf[5] = 0xff;                                              // CRC, don't care
            buf[6] = 0xff;                                              // dummy clk, 8clks(1byte)
            x = 7;
            Marshal.Copy(buf, 0, ptr, x);
            SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);

            // Data_Rd_Mode.
            SDCard_Util.Data_Rd_Mode();

            InvokePrgbPos(10);
            i = 0;
            do
            {
                // rd_8bit.
                SDCard_Util.Rd_8bit(ref x);

                i++;

                InvokeRichBox(i.ToString("D04") + ":CMD17(single read) response (0x00) : 0x" + x.ToString("X02") + "\r\n");
            } while ((x != 0x00) && (i < 10));

            // single read start byte : 0xfe
            i = 0;
            do
            {
                // rd_8bit.
                SDCard_Util.Rd_8bit(ref x);

                i++;
                InvokePrgbPos(((int)(10 * i / 100) < 10) ? (10 + (int)(10 * i / 100)) : 20);
            } while (x != 0xfe && i < 10);
            if (x == 0) { InvokeRichBox("Read Single Block fail!\r\n "); InvokePrgbPos(100); goto TheEnd; }
            x = 512 * 2 + 2 * 2;
            SDCard_Util.UsbReadScanner(ptr, (uint)x, 0x00);
            Marshal.Copy(ptr, buf, 0, (int)x);


            // Spi_cs_H_wd.
            SDCard_Util.Spi_cs_H_wd();

            InvokeRichBox("single block read :\r\n");
            for (i = 0; i < 512; i++)
            {
                InvokeRichBox(i.ToString("D3") + ":0x" + buf[i * 2 + 1].ToString("X02") + "\r\n");
                InvokePrgbPos(((int)(85 * i / 510) < 85) ? (10 + (int)(85 * i / 510)) : 95);
            }

            //-----------------------------------------------------
            if (uSD_RD_addr == 0)
            {
                LoadSDCardInfo = true;
                fpga_addr = (buf[0x10 * 2 + 1] << 24) + (buf[0x11 * 2 + 1] << 16) + (buf[0x12 * 2 + 1] << 8) + buf[0x13 * 2 + 1];
                fpga_leng = (buf[0x14 * 2 + 1] << 8) + buf[0x15 * 2 + 1];

                init_addr = (buf[0x20 * 2 + 1] << 24) + (buf[0x21 * 2 + 1] << 16) + (buf[0x22 * 2 + 1] << 8) + buf[0x23 * 2 + 1];
                init_leng = (buf[0x24 * 2 + 1] << 8) + buf[0x25 * 2 + 1];

                disp_addr = (buf[0x40 * 2 + 1] << 24) + (buf[0x41 * 2 + 1] << 16) + (buf[0x42 * 2 + 1] << 8) + buf[0x43 * 2 + 1];
                disp_leng = (buf[0x44 * 2 + 1] << 8) + buf[0x45 * 2 + 1];

                Auto_intv = (buf[0x54 * 2 + 1] << 8) + buf[0x55 * 2 + 1];

                imag_nums = (buf[0x60 * 2 + 1] << 8) + buf[0x61 * 2 + 1];
                imag_size = (buf[0x62 * 2 + 1] << 8) + buf[0x63 * 2 + 1];
                imag_addr = (buf[0x66 * 2 + 1] << 24) + (buf[0x67 * 2 + 1] << 16) + (buf[0x68 * 2 + 1] << 8) + buf[0x69 * 2 + 1];

                ic_version = "";
                for (i = 0; i < 16; i++)
                {
                    ic_version += Convert.ToChar(buf[i * 2 + 1]);
                }
                //this.DataGridView_SDCard.CellBeginEdit += null;
                //this.DataGridView_SDCard.CellContentClick += null;
                //this.DataGridView_SDCard.CellValueChanged += null;
                ListGridView[0].Rows[0].Cells[1].Value = InfoTableList[0] = string.Format(ic_version);
                ListGridView[0].Rows[1].Cells[1].Value = InfoTableList[1] = string.Format("0x" + fpga_addr.ToString("X08"));
                ListGridView[0].Rows[2].Cells[1].Value = InfoTableList[2] = string.Format("0x" + fpga_leng.ToString("X04"));
                ListGridView[0].Rows[3].Cells[1].Value = InfoTableList[3] = string.Format("0x" + init_addr.ToString("X08"));
                ListGridView[0].Rows[4].Cells[1].Value = InfoTableList[4] = string.Format("0x" + init_leng.ToString("X04"));
                ListGridView[0].Rows[5].Cells[1].Value = InfoTableList[5] = string.Format("0x" + disp_addr.ToString("X08"));
                ListGridView[0].Rows[6].Cells[1].Value = InfoTableList[6] = string.Format("0x" + disp_leng.ToString("X04"));
                ListGridView[0].Rows[7].Cells[1].Value = InfoTableList[7] = string.Format(Auto_intv.ToString("d"));
                ListGridView[0].Rows[8].Cells[1].Value = InfoTableList[8] = string.Format("0x" + imag_nums.ToString("X04"));
                ListGridView[0].Rows[9].Cells[1].Value = InfoTableList[9] = string.Format("0x" + imag_size.ToString("X04"));
                ListGridView[0].Rows[10].Cells[1].Value = InfoTableList[10] = string.Format("0x" + imag_addr.ToString("X08"));
                //this.DataGridView_SDCard.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView_SDCard_CellBeginEdit);
                //this.DataGridView_SDCard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_SDCard_CellContentClick);
                //this.DataGridView_SDCard.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_SDCard_CellValueChanged);
            }
            InvokeRichBox("Read Single Block ok!\r\n ");
            InvokePrgbPos(100);
            TheEnd:
            //-----------------------------------------------------
            Marshal.FreeHGlobal(ptr);

        }

        // SD card multi block write.
        private bool SD_multi_block_write(int Pro_Start, int Pro_End, int addr, int blocks, byte[,] bufftemp, string DownItem)
        {
            EnaResultLog = false;
            try
            {
                /* SD block size = 512 byte, XM used as default setting.
               512 data byte + 3byte write start(0xff,0xff,0xfc) + 2 byte CRC. 
            */
                byte[] bufwr = new byte[517];
                IntPtr ptr = Marshal.AllocHGlobal((int)bs);
                int i, x, y, bk_cnt = 0;

                //============== Step 1 - Write Block Number to FPGA ================//
                /* multi block write => CMD25(0x59) 
                4 byte address and CRC(1byte) Set Dummy clk(1byte) set */
                if (sd_type == false)
                { addr = addr << 9; }

                SDCard_Util.Spi_cs_L();

                SDCard_Util.Addr_Wr_Mode();
                bufwr[0] = 0x59;
                bufwr[1] = (byte)((addr >> 24) & 0xff);
                bufwr[2] = (byte)((addr >> 16) & 0xff);
                bufwr[3] = (byte)((addr >> 8) & 0xff);
                bufwr[4] = (byte)((addr >> 0) & 0xff);      // 4 byte address
                bufwr[5] = 0xff;                            // CRC, don,t care
                bufwr[6] = 0xff;                            // dummy clk, 8clks(1byte)
                x = 7;
                Marshal.Copy(bufwr, 0, ptr, x);
                SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);
                SDCard_Util.Data_Rd_Mode();

                i = 0;
                do
                {
                    SDCard_Util.Rd_8bit(ref x);
                    i++;
                } while ((x != 0x00) & (i < 10));
                if (x != 0x00)
                {
                    InvokeRichBox(DownItem + "CMD25...fail \r\n\r\n");
                    return false;
                }

                //======== Step 2 - Download one Block(512Bytes) each time ==========//
                do
                {
                    // multi block write start byte : 0xfc
                    bufwr[0] = 0xff; bufwr[1] = 0xff; bufwr[2] = 0xfc;

                    for (int row = 0; row < 32; row++)
                    {
                        for (int col = 0; col < 16; col++)
                        { bufwr[(row * 16) + col + 3] = bufftemp[row + (bk_cnt * 32), col]; }
                    }

                    // CRC.
                    bufwr[515] = 0xff; bufwr[516] = 0xff;
                    bk_cnt++;

                    SDCard_Util.Addr_Wr_Mode();
                    x = 517;
                    Marshal.Copy(bufwr, 0, ptr, x);
                    SDCard_Util.UsbWriteScanner(ptr, (uint)x, 0x00);        // SD single block progranning
                                                                            //-----------------------------------------------------
                    SDCard_Util.Data_Rd_Mode();
                    i = 0;
                    do
                    {
                        SDCard_Util.Rd_8bit(ref x);
                        y = x & 0x0f;
                        i++;
                    } while ((y != 0x05) & (i < 10));
                    if (y != 0x05)
                    {
                        InvokeRichBox(DownItem +"write fail...!");
                        return false;
                    }
                    //Thread.Sleep(10); //Original(do not delete) 
                    //-----------------------------------------------------
                    i = 0;
                    do
                    {
                        SDCard_Util.Rd_8bit(ref x);
                        i++;
                       //  Thread.Sleep(10); //Original(do not delete) 
                    } while ((x != 0xff) & (i < 500));
                    
                    if ((x != 0xff))
                    {
                        InvokeRichBox(DownItem +"multi block "+ bk_cnt.ToString("X04") + " >> write fail... \r\n\r\n");
                        return false;
                    }
                    else
                    {
                        InvokeRichBox(DownItem + "multi block " + bk_cnt.ToString("X04") + " >> write ok... \r\n\r\n");
                    }
                    InvokePrgbPos(((int)((Pro_End - Pro_Start) * bk_cnt / blocks) < Pro_End) ? 
                      (Pro_Start + (int)((Pro_End - Pro_Start) * bk_cnt / blocks)) : Pro_End);

                } while (bk_cnt < blocks);
                if(bk_cnt == blocks)
                    EnaResultLog = true; InvokeRichBox("\r\n");

                //======== Step 3 - Write Stop Cmd (0xfd) to FPGA ==========//
                // stop multiple block write byte : 0xfd
                SDCard_Util.UsbWriteAD02(0x80, 0xfd);
                SDCard_Util.Data_Rd_Mode();
                i = 0;
                do
                {
                    SDCard_Util.Rd_8bit(ref x);
                    i++;
                    Thread.Sleep(10);
                } while ((x != 0xff) & (i < 50));
                if (x != 0xff)
                {
                    InvokeRichBox(DownItem + "Stop multiple block write fail... \r\n\r\n");
                    return false;
                }

                SDCard_Util.Spi_cs_H_wd();
                //-----------------------------------------------------
                Marshal.FreeHGlobal(ptr);
                EnaResultLog = true;
                return true;
            }
            catch (Exception ex )
            {
                throw ex;
            }
            
        }

        private void SDCardControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            tab1dt.Dispose(); tab2dt.Dispose(); bufftemp = null; buf = null;
        }

        // Switch Tab1 and Tab2 need to reset datagridview and value.
        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            int index = TabControl_SDCard.SelectedIndex;
            if (e.TabPage == this.tabPage1)
            {
                if (LoadSDCardInfo)
                {UpdateLoadFileStatus(); }

                // first Binding datagridview and show in tabPage1 
                tabPage1.Controls.Add(ListGridView[index]);
                this.groupBox_SD_Info.Controls.Add(ListGridView[index]);
                Chagne_DataGridView(ListGridView[index], e.TabPage.Name);
                ManualSetColumnWidth(ListGridView[index], e.TabPage.Name);
                ListGridView[index].Controls.Clear();
                DisableColumnHeaderSort(ListGridView[index]);

                if (LoadSDCardInfo)
                { ShowSDCardInfo(false);}
            }
            else // if (e.TabPage == this.tabPage2)
            {
                if (LoadSDCardInfo)
                { ShowSDCardInfo(true);}

                // first Binding datagridview and show in tabPage2 
                tabPage1.Controls.Add(ListGridView[index]);
                this.groupBox_SD_Program.Controls.Add(ListGridView[index]);
                Chagne_DataGridView(ListGridView[index], e.TabPage.Name);
                GenerateCheckbox(ListGridView[index]);
                GenerateBotton(ListGridView[index],3);
                ManualSetColumnWidth(ListGridView[index], e.TabPage.Name);
                DisableColumnHeaderSort(ListGridView[index]);
                Deal_ChkBox_Path(ListGridView[index], 0, 0, false, 0);
            }

            SDCardControlForm_Resize();
            ListGridView[index].AllowUserToAddRows = false;
        }

        private void UpdateLoadFileStatus()
        {
            int Row_Ind = 0; string TempString = "";
            int Addr = 0, Blocks = 1; AutoCalimag_nums = 0;
            bool Recount = true;
            if (ListGridView[1].Rows[0].Cells[2].Value.ToString() == "")
            {
                TempString = "Do you want to AutoSave MicroSDInfo(.txt) in Document Which named SDCard ?";
                XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Confirm Message", true);
                if (MessageBox.Show(TempString, "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        ArrayList StringList = new ArrayList();
                        XM_IO_Util IO_Util = new XM_IO_Util();
                        string FilePath = "";
                        //in order to Keep Document alway exist.
                        if (!File.Exists(Setting.ExeSDCardDirPath))
                        {
                            IO_Util.CreateDir(Setting.ExeSDCardDirPath);
                        }
                        TempString = "\\MicroSDInfo.txt";
                        FilePath = Setting.ExeSDCardDirPath + TempString;

                        for (int i = 0; i < InfoTableList.Length; i++)
                        {
                            TempString = "";
                           if (InfoTableList[i] == null)
                             {if (i == 0) InfoTableList[i] = "XM_PLUS"; if (i == 7) InfoTableList[i] = 0xBB8; }
                                         TempString = Tab1RowList[i] + "=" + InfoTableList[i];
                            StringList.Add(TempString);
                        }

                        if (File.Exists(FilePath))
                        {
                            IO_Util.FileDelete(FilePath);
                        }
                        IO_Util.OutputTxt(FilePath, StringList);

                        ListGridView[1].Rows[0].Cells[0].Value = true;
                        ListGridView[1].Rows[0].Cells[2].Value = FilePath;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }

            for (int Row = 0; Row < ListGridView[1].RowCount; Row++)
            {
                InvokePrgbPos((int)((Row_Ind + 1) * 100 / ListGridView[1].RowCount));
                ChkBoxStatus[Row_Ind] = (bool)ListGridView[1].Rows[Row].Cells[0].Value;
                TempString = SDCard_Util.SDCard_Item[Row_Ind].ItemFilePath[0] = ListGridView[1].Rows[Row].Cells[2].Value.ToString();
                AutoLoadFileEvent(Row_Ind, 3, TempString, ChkBoxStatus[Row_Ind], Row_Ind, ref Addr, ref Blocks, ref Recount);
                InvokePrgbPos((int)((Row_Ind + 1) * 100 / ListGridView[1].RowCount));
                Row_Ind++;
            }  
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

        private void MyMarshalToForm(int Action, String textToDisplay, object dt, int iRowToRefresh = -1)
        {
            try
            {
                object[] args = { Action, textToDisplay, dt, iRowToRefresh };
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

        private void AccessForm(int Action, String formText, object dt, int iRowRefresh)
        {
            
            switch (Action)
            {
                case (int)MSG.MSG_RICH:
                    // Disable drawing for UI
                    XM_SDCard_Util.SuspendDrawing(RichTextBox_SDCardReadInfo);
                    if (!EnaResultLog)
                    {
                        RichTextBox_SDCardReadInfo.Text = KeepResultLog + formText;
                    }
                    else
                    {
                        RichTextBox_SDCardReadInfo.AppendText(formText);
                        KeepResultLog = RichTextBox_SDCardReadInfo.Text;
                    }
                    // Keep scroll is at last
                    XM_SDCard_Util.ScrollToBottom(RichTextBox_SDCardReadInfo);
                    // Enable drawing for UI
                    XM_SDCard_Util.ResumeDrawing(RichTextBox_SDCardReadInfo);
                    break;
                case (int)MSG.MSG_VAL:
                    SDCardControBar.Maximum = int.Parse(formText);
                    break;
                case (int)MSG.MSG_PROG:
                    SDCardControBar.Value = int.Parse(formText);
                    break;
                case (int)MSG.MSG_SDTEXT:
                    toolStrStaLab_SDCardStatus.Text = formText;
                    toolStrStaLab_SDCardStatus.ForeColor = (System.Drawing.Color)dt;
                    break;
                case (int)MSG.MSG_MULTIRD:
                    button_Multi_RD.Text = formText;
                    break;
                case (int)MSG.MSG_DOWNLOAD:
                    button_Download_All.Text = formText;
                    break;
                default:
                    break;
                    
            }
        }

        //================Creat Checkbox for Tab2 datagridview================//
        class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
        {
            Point checkBoxLocation;
            Size checkBoxSize;
            bool _checked = false;
            Point _cellLocation = new Point();
            System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
            public event CheckBoxClickedHandler OnCheckBoxClicked;

            public DatagridViewCheckBoxHeaderCell()
            {
            }

            protected override void Paint(System.Drawing.Graphics graphics,
                System.Drawing.Rectangle clipBounds,
                System.Drawing.Rectangle cellBounds,
                int rowIndex,
                DataGridViewElementStates dataGridViewElementState,
                object value,
                object formattedValue,
                string errorText,
                DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle,
                DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    dataGridViewElementState, value,
                    formattedValue, errorText, cellStyle,
                    advancedBorderStyle, paintParts);
                Point p = new Point();
                Size s = CheckBoxRenderer.GetGlyphSize(graphics,
                System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
                p.X = cellBounds.Location.X +
                    (cellBounds.Width / 2) - (s.Width / 2);
                p.Y = cellBounds.Location.Y +
                    (cellBounds.Height / 2) - (s.Height / 2);
                _cellLocation = cellBounds.Location;
                checkBoxLocation = p;
                checkBoxSize = s;
                if (_checked)
                    _cbState = System.Windows.Forms.VisualStyles.
                        CheckBoxState.CheckedNormal;
                else
                    _cbState = System.Windows.Forms.VisualStyles.
                        CheckBoxState.UncheckedNormal;
                CheckBoxRenderer.DrawCheckBox
                (graphics, checkBoxLocation, _cbState);
            }

            protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
            {

                Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
                if (p.X >= checkBoxLocation.X && p.X <=
                    checkBoxLocation.X + checkBoxSize.Width
                && p.Y >= checkBoxLocation.Y && p.Y <=
                    checkBoxLocation.Y + checkBoxSize.Height)
                {
                    _checked = !_checked;
                    if (OnCheckBoxClicked != null)
                    {
                        OnCheckBoxClicked(ref _checked);
                        this.DataGridView.InvalidateCell(this);
                    }
                }
                base.OnMouseClick(e);
            }
        }

        public delegate void CheckBoxClickedHandler(ref bool state);

        public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
        {
            bool _bChecked;
            public DataGridViewCheckBoxHeaderCellEventArgs(bool bChecked)
            {
                _bChecked = bChecked;
            }
            public bool Checked
            {
                get { return _bChecked; }
            }
        }
       
        private void CbHeader_OnCheckBoxClicked(ref bool state)
        {
            // advoid to Checkbox is fail after checkboxall be checked.
            ListGridView[1].CurrentCell = ListGridView[1].Rows[0].Cells[1];
            bool Refresh = true;
            int Length = 0;
            Length = ListGridView[1].RowCount == Tab2RowList.Length ? Tab2RowList.Length : ListGridView[1].RowCount - 1;
            if (state)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (ListGridView[1].Rows[i].Cells[2].Value.ToString() == "")
                    {
                        ListGridView[1].AllowUserToAddRows = true;
                        ListGridView[1].CurrentCell = ListGridView[1].Rows[i].Cells[0];
                        ListGridView[1].AllowUserToAddRows = false;
                        Refresh = false;
                        state = false;
                        XM_Sytem_API.FindAndMoveMsgBox("SDCardControl", "Warning", true);
                        MessageBox.Show("Enable CheckBox Before Load File! ", "Warning");
                    }
                }   
            }
            else
            { /*LoadSDCardInfo = false;*/ }

            if (Refresh)
            {
                for (int i = 0; i < Length; i++)
                {
                    ListGridView[1].AllowUserToAddRows = true;
                    ListGridView[1].CurrentCell = ListGridView[1].Rows[i].Cells[1];
                    ListGridView[1].AllowUserToAddRows = false;
                    
                    ListGridView[1].Rows[i].Cells[0].Value = state;
                    Deal_ChkBox_Path(DataGridView_SDCard, 0, 0, state, 5);


                    ListGridView[1].AllowUserToAddRows = true;
                    ListGridView[1].CurrentCell = ListGridView[1].Rows[i].Cells[0];
                    ListGridView[1].AllowUserToAddRows = false;
                }
                //foreach (DataGridViewRow dr in DataGridView_SDCard.Rows)
                //    dr.Cells[0].Value = state;
            }

            ListGridView[1].Refresh();

        }
    }
}

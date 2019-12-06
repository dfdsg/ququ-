using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace XM_Tek_Studio_Pro
{

    public partial class USB2EPP_ComEdit : Form
    {
        string openfilename, savefilename, saveasfilename;
        char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

        public USB2EPP_ComEdit()
        {
            InitializeComponent();
            savefilename = "";
        }
//--------------------------------------------------------------------------------------------
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Command File(*.txt)|*.txt",
                Title = "Select a Command File"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openfilename = openFileDialog1.FileName;
                richTextBox_info.Text += openfilename + "\r\n";
                richTextBox_comedit.ResetText();
                using (FileStream input = new FileStream(openfilename, FileMode.Open))
                {
                    string line;
                    StreamReader reader = new StreamReader(input,Encoding.Default);
                    while ((line = reader.ReadLine()) != null)
                    {
                        richTextBox_comedit.Text += line + "\r\n";
                    }
                    input.Close();
                }
                savefilename = openfilename;
                this.Text = openfilename;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savefilename != "")
            {
                richTextBox_comedit.SaveFile(savefilename, RichTextBoxStreamType.PlainText);
                richTextBox_info.Text += savefilename + "\r\n";
                this.Text = savefilename;
            }
            else
            {
                Save_As();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save_As();
        }
        private void Save_As()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Command File(*.txt)|*.txt",
                Title = "Select a Command File"
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveasfilename = saveFileDialog1.FileName;
                richTextBox_comedit.SaveFile(saveasfilename, RichTextBoxStreamType.PlainText);
                savefilename = saveasfilename;
                this.Text = saveasfilename;
                richTextBox_info.Text += saveasfilename + "\r\n";
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
//--------------------------------------------------------------------------------------------
        private void RichTextBox_info_TextChanged(object sender, EventArgs e)
        {
            richTextBox_info.SelectionStart = richTextBox_info.TextLength;
            richTextBox_info.ScrollToCaret();
        }
//--------------------------------------------------------------------------------------------
        private void Btn_AllComSend_Click(object sender, EventArgs e)
        {
            if (Parm.Usb_bConn)
            {
                All_command_send();
            }
            else
            {
                richTextBox_info.Text += "USB controller not find....\r\n";
            }
        }
//--------------------------------------------------------------------------------------------
        private void All_command_send()
        {
            int cnt;
            cnt = richTextBox_comedit.Lines.Length;
            Command_Send(0, cnt-1);
        }

        private void RichTextBox_comedit_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //--------------------------------------------------------------------------------------------
        private void Command_Send(int start,int end)
        {
            int i, value, x = 0;
            bool result;
            byte[] buf = new byte[256];
            IntPtr ptr = Marshal.AllocHGlobal(256);

            string line;
            string[] words;
            for (i = start; i <= end; i++)
            {
                line = richTextBox_comedit.Lines[i];
                words = line.Split(delimiterChars);
                //      richTextBox_info.Text += line + "\r\n";
                foreach (string s in words)
                {
                    if (s.StartsWith("//"))
                    {
                        break;
                    }
                    else if (s.StartsWith("aw") | s.StartsWith("AW"))
                    {
                        if (x > 0)
                        {
                            richTextBox_info.Text += "Addr write : 0x" + buf[0].ToString("X2") + "\r\n";
                            XM_Comm_Control.XM_Comm_Base.AddrWr(buf[0]);
                        }
                        x = 0;
                    }
                    else if (s.StartsWith("dw") | s.StartsWith("DW"))
                    {
                        if (x > 0)
                        {
                            richTextBox_info.Text += "Data write : 0x" + buf[0].ToString("X2") + "\r\n";
                            XM_Comm_Control.XM_Comm_Base.DataWr(buf[0]);
                        }
                        x = 0;
                    }
                    else if (s.StartsWith("adw") | s.StartsWith("ADW"))
                    {
                        if ((x > 1) & (x <= 20))
                        {
                            richTextBox_info.Text += "Addr/Data write : \r\n";
                            switch (x)
                            {
                                case 2:
                                case 3:
                                    Epp2USB.UsbWriteAD02(buf[0], buf[1]);
                                    richTextBox_info.Text += "0x" + buf[0].ToString("X2") + ", 0x" + buf[1].ToString("X2") + "\r\n";
                                    break;
                                case 4:
                                case 5:
                                    Epp2USB.UsbWriteAD04(buf[0], buf[1], buf[2], buf[3]);
                                    richTextBox_info.Text += "0x" + buf[0].ToString("X2") + ", 0x" + buf[1].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[2].ToString("X2") + ", 0x" + buf[3].ToString("X2") + "\r\n";
                                    break;
                                case 6:
                                case 7:
                                    Epp2USB.UsbWriteAD06(buf[0], buf[1], buf[2], buf[3], buf[4], buf[5]);
                                    richTextBox_info.Text += "0x" + buf[0].ToString("X2") + ", 0x" + buf[1].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[2].ToString("X2") + ", 0x" + buf[3].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[4].ToString("X2") + ", 0x" + buf[5].ToString("X2") + "\r\n";
                                    break;
                                case 8:
                                case 9:
                                    Epp2USB.UsbWriteAD08(buf[0], buf[1], buf[2], buf[3], buf[4], buf[5], buf[6], buf[7]);
                                    richTextBox_info.Text += "0x" + buf[0].ToString("X2") + ", 0x" + buf[1].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[2].ToString("X2") + ", 0x" + buf[3].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[4].ToString("X2") + ", 0x" + buf[5].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[6].ToString("X2") + ", 0x" + buf[7].ToString("X2") + "\r\n";
                                    break;
                                case 10:
                                case 11:
                                    Epp2USB.UsbWriteAD10(buf[0], buf[1], buf[2], buf[3], buf[4], buf[5], buf[6], buf[7], buf[8], buf[9]);
                                    richTextBox_info.Text += "0x" + buf[0].ToString("X2") + ", 0x" + buf[1].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[2].ToString("X2") + ", 0x" + buf[3].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[4].ToString("X2") + ", 0x" + buf[5].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[6].ToString("X2") + ", 0x" + buf[7].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[8].ToString("X2") + ", 0x" + buf[9].ToString("X2") + "\r\n";
                                    break;
                                case 12:
                                case 13:
                                    Epp2USB.UsbWriteAD12(buf[0], buf[1], buf[2], buf[3], buf[4], buf[5], buf[6], buf[7], buf[8], buf[9]
                                                        , buf[10], buf[11]);
                                    richTextBox_info.Text += "0x" + buf[0].ToString("X2") + ", 0x" + buf[1].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[2].ToString("X2") + ", 0x" + buf[3].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[4].ToString("X2") + ", 0x" + buf[5].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[6].ToString("X2") + ", 0x" + buf[7].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[8].ToString("X2") + ", 0x" + buf[9].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[10].ToString("X2") + ", 0x" + buf[11].ToString("X2") + "\r\n";
                                    break;
                                case 14:
                                case 15:
                                    Epp2USB.UsbWriteAD14(buf[0], buf[1], buf[2], buf[3], buf[4], buf[5], buf[6], buf[7], buf[8], buf[9]
                                                        , buf[10], buf[11], buf[12], buf[13]);
                                    richTextBox_info.Text += "0x" + buf[0].ToString("X2") + ", 0x" + buf[1].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[2].ToString("X2") + ", 0x" + buf[3].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[4].ToString("X2") + ", 0x" + buf[5].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[6].ToString("X2") + ", 0x" + buf[7].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[8].ToString("X2") + ", 0x" + buf[9].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[10].ToString("X2") + ", 0x" + buf[11].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[12].ToString("X2") + ", 0x" + buf[13].ToString("X2") + "\r\n";
                                    break;
                                case 16:
                                case 17:
                                    Epp2USB.UsbWriteAD16(buf[0], buf[1], buf[2], buf[3], buf[4], buf[5], buf[6], buf[7], buf[8], buf[9]
                                                        , buf[10], buf[11], buf[12], buf[13], buf[14], buf[15]);
                                    richTextBox_info.Text += "0x" + buf[0].ToString("X2") + ", 0x" + buf[1].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[2].ToString("X2") + ", 0x" + buf[3].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[4].ToString("X2") + ", 0x" + buf[5].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[6].ToString("X2") + ", 0x" + buf[7].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[8].ToString("X2") + ", 0x" + buf[9].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[10].ToString("X2") + ", 0x" + buf[11].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[12].ToString("X2") + ", 0x" + buf[13].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[14].ToString("X2") + ", 0x" + buf[15].ToString("X2") + "\r\n";
                                    break;
                                case 18:
                                case 19:
                                    Epp2USB.UsbWriteAD18(buf[0], buf[1], buf[2], buf[3], buf[4], buf[5], buf[6], buf[7], buf[8], buf[9]
                                                        , buf[10], buf[11], buf[12], buf[13], buf[14], buf[15], buf[16], buf[17]);
                                    richTextBox_info.Text += "0x" + buf[0].ToString("X2") + ", 0x" + buf[1].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[2].ToString("X2") + ", 0x" + buf[3].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[4].ToString("X2") + ", 0x" + buf[5].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[6].ToString("X2") + ", 0x" + buf[7].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[8].ToString("X2") + ", 0x" + buf[9].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[10].ToString("X2") + ", 0x" + buf[11].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[12].ToString("X2") + ", 0x" + buf[13].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[14].ToString("X2") + ", 0x" + buf[15].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[16].ToString("X2") + ", 0x" + buf[17].ToString("X2") + "\r\n";
                                    break;
                                case 20:
                                case 21:
                                    Epp2USB.UsbWriteAD20(buf[0], buf[1], buf[2], buf[3], buf[4], buf[5], buf[6], buf[7], buf[8], buf[9]
                                                        , buf[10], buf[11], buf[12], buf[13], buf[14], buf[15], buf[16], buf[17], buf[18], buf[19]);
                                    richTextBox_info.Text += "0x" + buf[0].ToString("X2") + ", 0x" + buf[1].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[2].ToString("X2") + ", 0x" + buf[3].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[4].ToString("X2") + ", 0x" + buf[5].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[6].ToString("X2") + ", 0x" + buf[7].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[8].ToString("X2") + ", 0x" + buf[9].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[10].ToString("X2") + ", 0x" + buf[11].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[12].ToString("X2") + ", 0x" + buf[13].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[14].ToString("X2") + ", 0x" + buf[15].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[16].ToString("X2") + ", 0x" + buf[17].ToString("X2") + "\r\n";
                                    richTextBox_info.Text += "0x" + buf[18].ToString("X2") + ", 0x" + buf[19].ToString("X2") + "\r\n";
                                    break;
                                default:
                                    break;
                            }
                        }
                        x = 0;
                    }
                    else if (s.StartsWith("bdw") | s.StartsWith("BDW"))
                    {
                        if ((x > 0) & (x < 256))
                        {
                            Marshal.Copy(buf, 0, ptr, x);
                            result = Epp2USB.UsbWriteScanner(ptr, (uint)x, 0x00);
                            richTextBox_info.Text += "Bulk Data write : " + x.ToString() + " bytes\r\n";
                        }
                        x = 0;
                    }
                    else if (s.StartsWith("dr") | s.StartsWith("DR"))
                    {
                        value = (int)XM_Comm_Control.XM_Comm_Base.DataRd();
                        richTextBox_info.Text += "Data Read : 0x" + value.ToString("X2") + "\r\n";
                        x = 0;
                    }
                    else if (s.StartsWith("d1ms") | s.StartsWith("D1MS"))
                    {
                        Thread.Sleep(buf[0]);
                        richTextBox_info.Text += "Delay (ms) : " + buf[0].ToString() + "\r\n";
                        x = 0;
                    }
                    else if (s.Equals("", StringComparison.Ordinal))
                    {
                    }
                    else
                    {
                        value = Function.StrToHexOrDec(s);
                        if ((value >= 0) & (value < 256))
                        {
                            buf[x] = (byte)value;
                      //      richTextBox_info.Text += "x: " + x.ToString() + ", value: " + value.ToString() + "\r\n";
                            x++;
                        }
                    }
                }
            }
            richTextBox_info.Text += "............................\r\n";
            Marshal.FreeHGlobal(ptr);
        }
//--------------------------------------------------------------------------------------------
        private void Btn_SelectComSend_Click(object sender, EventArgs e)
        {
            int x, y, z, start, end;
            int a;
            if (Parm.Usb_bConn)
            {
                if (richTextBox_comedit.SelectionLength > 0)
                {
                    x = richTextBox_comedit.GetFirstCharIndexOfCurrentLine();
                //    richTextBox_info.Text += x.ToString() + "\r\n";
                    a = richTextBox_comedit.SelectionStart;
                //    richTextBox_info.Text += a.ToString() + "\r\n";
                    start = richTextBox_comedit.GetLineFromCharIndex(x);
                    richTextBox_info.Text += "Start Line: " + start.ToString() + "\r\n";
                    y = richTextBox_comedit.SelectionLength;
                //    richTextBox_info.Text += y.ToString() + "\r\n";
                    end = richTextBox_comedit.GetLineFromCharIndex(a + y - 1);
                    richTextBox_info.Text += "End Line : " + end.ToString() + "\r\n";
                    z = richTextBox_comedit.Text.IndexOf('\n', a + y - 1);
                //    richTextBox_info.Text += z.ToString() + "\r\n";
                    richTextBox_comedit.SelectionStart = x;
                    if (z > 0)
                    {
                        richTextBox_comedit.SelectionLength = z - x;
                    }
                    else
                    {
                        richTextBox_comedit.SelectionLength = a + y - x;
                    }

                    Command_Send(start, end);
                }
                else
                {
                    richTextBox_info.Text += "No selection..........\r\n";
                }

            }
            else
            {
                richTextBox_info.Text += "USB controller not find....\r\n";
            }
        }



    }

    public static class Function
    {
        public static int StrToHexOrDec(string num)
        {
            int value = 0;

            if (num != null && (num.StartsWith("0x") || num.StartsWith("0X")))
            {
                if (int.TryParse(num.Substring(2), System.Globalization.NumberStyles.HexNumber, null, out value) == true) { }
                else
                {
                    MessageBox.Show("HexNumber format Error.....\r\n" + "Please input 0x + (0~9,A~F)... \r\n");
                    return -1;
                }
            }
            else if (num != null)
            {
                if (int.TryParse(num, System.Globalization.NumberStyles.Integer, null, out value) == true) { }
                else
                {
                    MessageBox.Show("DecNumber format Error.....\r\n" + "Please input 0~9... \r\n");
                    return -1;
                }
            }
            return value;
        }

        public static float StrToFloat(string num)
        {
            float value = 0;

            if (num != null && (num.StartsWith("0x") || num.StartsWith("0X")))
            {
                MessageBox.Show("float format Error.....\r\n" + "Please input Float number... \r\n");
                return -1;
            }
            else if (num != null)
            {
                if (float.TryParse(num, System.Globalization.NumberStyles.Float, null, out value) == true) { }
                else
                {
                    MessageBox.Show("float format Error.....\r\n" + "Please input 0~9... \r\n");
                    return -1;
                }
            }
            return value;
        }
    }
}

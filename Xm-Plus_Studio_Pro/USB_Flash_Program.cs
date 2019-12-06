using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class USB_Flash_Program : Form
    {
        int vid = 0, pid = 0, checksum = 0;
        string vendor, product, serial;
        string openfilename, savefilename, saveasfilename;

        public USB_Flash_Program()
        {
            InitializeComponent();
        }

        private void USB_flash_programming_Load(object sender, EventArgs e)
        {
            dataGridView_UsbFalsh.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8);
            dataGridView_UsbFalsh.RowHeadersDefaultCellStyle.Font = new Font("Arial", 8);
            dataGridView_UsbFalsh.DefaultCellStyle.Font = new Font("Arial", 8);
            Data_Gridview_Set();
            savefilename = "";

            UsbCheck();
        }

        private bool UsbCheck()
        {
            if (Epp2USB.FindScanner(0x0, 0x0))
            {
                AddMsg("USB Connection OK.......", Color.Green);
                return true;
            }
            else
            {
                AddMsg("USB Fail, Please re-Plug again", Color.Red);
                return false;
            }
        }

        private void AddMsg(string txt, Color clr = new Color())
        {
            richTextBox_UsbFlash.SelectionColor = clr;
            richTextBox_UsbFlash.AppendText(txt + Environment.NewLine);
        }

        private void AddMsg1(string txt, Color clr = new Color())
        {
            richTextBox_UsbFlash.SelectionColor = clr;
            richTextBox_UsbFlash.AppendText(txt);
        }
        //---------------------------------------------------------------------------------------------
        private void Data_Gridview_Set()
        {
            int x = 0;
            int columnwidth = 24;
            int columnwidth1 = 16;
            int xsize = 32, ysize = 8;

            for (x = 0; x < xsize; x++)
            {
                if (x < 16)
                {
                    dataGridView_UsbFalsh.Columns.Add("Add" + x, x.ToString("X"));
                    dataGridView_UsbFalsh.Columns[x].Width = columnwidth;
                }
                else
                {
                    dataGridView_UsbFalsh.Columns.Add("Add" + x, (x-16).ToString("X"));
                    dataGridView_UsbFalsh.Columns[x].Width = columnwidth1;
                }
            }
    
            for (x = 0; x < (ysize-1) ; x++)
            {
                dataGridView_UsbFalsh.Rows.Add();
                dataGridView_UsbFalsh.RowHeadersWidth = 50;
            }
            for (x = 0; x < ysize; x++)
            {
                dataGridView_UsbFalsh.Rows[x].HeaderCell.Value = (x * 16).ToString("X2");
                dataGridView_UsbFalsh.Rows[x].Height = 20;
            }
        }
//---------------------------------------------------------------------------------------------
        private void RichTextBox_UsbFlash_TextChanged(object sender, EventArgs e)
        {
            richTextBox_UsbFlash.SelectionStart = richTextBox_UsbFlash.TextLength;
            richTextBox_UsbFlash.ScrollToCaret();
        }
//---------------------------------------------------------------------------------------------
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Flash data(*.bin)|*.bin",
                Title = "Select a Flash data File"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openfilename = openFileDialog1.FileName;
                using (FileStream input = new FileStream(openfilename, FileMode.Open))
                {
                    int data, x, cnt;
                    x = 0;
                    BinaryReader reader = new BinaryReader(input);
                    cnt = Convert.ToInt16(input.Length);
                    for(x=0;x<cnt;x++)
                    {
                        data = reader.ReadByte();
                        Parm.flashbuf[x] = (uint)data;
                    }
                    input.Close();
                }
                Datagridview_Update();
                AddMsg(openfilename, Color.Black);
                savefilename = openfilename;
                this.Text = openfilename;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savefilename != "")
            {
                Datagridview_Read();
                using (FileStream output = File.Create(savefilename))
                {
                    int x = 0;
                    BinaryWriter writer = new BinaryWriter(output);
                    for (x = 0; x < 128; x++)
                    {
                        writer.Write((byte)Parm.flashbuf[x]);
                    }
                    output.Close();
                }
                AddMsg(savefilename, Color.Black);
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

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_As()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Flash data(*.bin)|*.bin",
                Title = "Select a Flash data File"
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Datagridview_Read();
                saveasfilename = saveFileDialog1.FileName;
                using (FileStream output = File.Create(saveasfilename))
                {
                    int x = 0;
                    BinaryWriter writer = new BinaryWriter(output);
                    for (x = 0; x < 128; x++)
                    {
                        writer.Write((byte)Parm.flashbuf[x]);
                    }
                    output.Close();
                }
                AddMsg(saveasfilename, Color.Black);
                savefilename = saveasfilename;
                this.Text = saveasfilename;
            }
        }
//---------------------------------------------------------------------------------------------
        private void Button_FlashRead_Click(object sender, EventArgs e)
        {
            if (UsbCheck() == true)
            {
                Flash_Read();
            }
        }
        private void Flash_Read()
        {
            byte x;
            int test;
            AddMsg("Flash Reading........", Color.Black);
            XM_Bridge_Flash.InterfaceEnable();
            for (x = 0; x < 64; x++)
            {
                test = XM_Bridge_Flash.Read(x);
                Parm.flashbuf[x * 2] = (uint)(test & 0x00ff);
                Parm.flashbuf[x * 2 + 1] = (uint)((test >> 8) & 0x00ff);

                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2, (int)(x / 8)].Value = "";
                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2 + 1, (int)(x / 8)].Value = "";

                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2 + 16, (int)(x / 8)].Value = "";
                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2 + 17, (int)(x / 8)].Value = "";

                dataGridView_UsbFalsh.Update();


                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2, (int)(x / 8)].Value = (Parm.flashbuf[x * 2]).ToString("X2");
                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2 + 1, (int)(x / 8)].Value = (Parm.flashbuf[x * 2 + 1]).ToString("X2");

                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2 + 16, (int)(x / 8)].Value = Convert.ToChar(Parm.flashbuf[x * 2]);
                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2 + 17, (int)(x / 8)].Value = Convert.ToChar(Parm.flashbuf[x * 2 + 1]);

                dataGridView_UsbFalsh.Update();
                AddMsg1("..", Color.Black);
                richTextBox_UsbFlash.Update();
            }
            AddMsg("", Color.Black);
            AddMsg("Finish.......", Color.Black);
            Read_Infor_Fill();
        }
        //---------------------------------------------------------------------------------------------
        private void Datagridview_Read()
        {
            int x, y;
            for (y = 0; y < 8; y++)
            {
                for (x = 0; x < 16; x++)
                {
                    if (dataGridView_UsbFalsh[x, y].Value != null)
                    {
                        Parm.flashbuf[y * 16 + x] = (uint)Function.StrToHexOrDec("0x" + dataGridView_UsbFalsh[x, y].Value.ToString());
                    }
                    else
                    {
                        AddMsg("No data.....", Color.Red);
                    }
                }
            }
        }

        private void Datagridview_Update()
        {
            byte x;
            for (x = 0; x < 64; x++)
            {
                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2, (int)(x / 8)].Value = (Parm.flashbuf[x * 2]).ToString("X2");
                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2 + 1, (int)(x / 8)].Value = (Parm.flashbuf[x * 2 + 1]).ToString("X2");

                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2 + 16, (int)(x / 8)].Value = Convert.ToChar(Parm.flashbuf[x * 2]);
                dataGridView_UsbFalsh[(int)(x - 8 * (x / 8)) * 2 + 17, (int)(x / 8)].Value = Convert.ToChar(Parm.flashbuf[x * 2 + 1]);

                dataGridView_UsbFalsh.Update();
            }
            Read_Infor_Fill();
        }

        private void Read_Infor_Fill()
        {
            uint x,cnt;
            textBox_VID.Text = "0x" + Parm.flashbuf[1].ToString("X2") + Parm.flashbuf[0].ToString("X2");
            textBox_PID.Text = "0x" + Parm.flashbuf[3].ToString("X2") + Parm.flashbuf[2].ToString("X2");
            textBox_Checksum.Text = "0x" + Parm.flashbuf[4].ToString("X2");

            vid = Function.StrToHexOrDec(textBox_VID.Text);
            pid = Function.StrToHexOrDec(textBox_PID.Text);
            checksum = Function.StrToHexOrDec(textBox_Checksum.Text);
           
            cnt= Parm.flashbuf[0x10];
            if ((cnt != 0x00) & (cnt != 0xff))
            {
                textBox_Vendor.Text = "";
                for (x = 0; x < cnt; x++)
                {
                    textBox_Vendor.Text += Convert.ToChar(Parm.flashbuf[0x11 + x]);
                }
            }
            else
            {
                textBox_Vendor.Text = "";
            }
            vendor = textBox_Vendor.Text;

            cnt = Parm.flashbuf[0x40];
            if ((cnt != 0x00) & (cnt != 0xff))
            {
                textBox_Product.Text = "";
                for (x = 0; x < cnt; x++)
                {
                    textBox_Product.Text += Convert.ToChar(Parm.flashbuf[0x41 + x]);
                }
            }
            else
            {
                textBox_Product.Text = "";
            }
            product = textBox_Product.Text;

            cnt = Parm.flashbuf[0x70];
      //      if ((cnt != 0x00) & (cnt != 0xff))
            if (cnt < 16)
            {
                textBox_Serial.Text = "";
                for (x = 0; x < cnt; x++)
                {
                    textBox_Serial.Text += Convert.ToChar(Parm.flashbuf[0x71 + x]);
                }
            }
            else
            {
                textBox_Serial.Text = "";
            }
            serial = textBox_Serial.Text;

        }

//---------------------------------------------------------------------------------------------
        private void TextBox_VID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                vid = Function.StrToHexOrDec(textBox_VID.Text);
                textBox_VID.Text = "0x" + vid.ToString("X4");
                dataGridView_UsbFalsh[0, 0].Value = (vid & 0x00ff).ToString("X2");
                dataGridView_UsbFalsh[1, 0].Value = ((vid >> 8) & 0x00ff).ToString("X2");
                dataGridView_UsbFalsh[16, 0].Value = Convert.ToChar(vid & 0x00ff);
                dataGridView_UsbFalsh[17, 0].Value = Convert.ToChar((vid >> 8) & 0x00ff);
                Checksum_Cal();
            }
        }

        private void TextBox_PID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                pid = Function.StrToHexOrDec(textBox_PID.Text);
                textBox_PID.Text = "0x" + pid.ToString("X4");
                dataGridView_UsbFalsh[2, 0].Value = (pid & 0x00ff).ToString("X2");
                dataGridView_UsbFalsh[3, 0].Value = ((pid >> 8) & 0x00ff).ToString("X2");
                dataGridView_UsbFalsh[18, 0].Value = Convert.ToChar(pid & 0x00ff);
                dataGridView_UsbFalsh[19, 0].Value = Convert.ToChar((pid >> 8) & 0x00ff);
                Checksum_Cal();
            }
        }

        private void Checksum_Cal()
        {
            checksum = (vid & 0x00ff) + ((vid >> 8) & 0x00ff) + (pid & 0x00ff) + ((pid >> 8) & 0x00ff) + 1;
            checksum = checksum & 0x0000ff;
            textBox_Checksum.Text = "0x" + checksum.ToString("X2");
            dataGridView_UsbFalsh[4, 0].Value = checksum.ToString("X2");
            dataGridView_UsbFalsh[20, 0].Value = Convert.ToChar(checksum);

            int x;
            for (x = 5; x < 16; x++)
            {
                dataGridView_UsbFalsh[x, 0].Value = "FF";
                dataGridView_UsbFalsh[16 + x, 0].Value = Convert.ToChar(0xFF);
            }

        }

        private void TextBox_Vendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                int cnt, x;
                vendor = textBox_Vendor.Text;
                cnt = vendor.Length;
                if ((cnt != 0x00) & (cnt != 0xFF))
                {
                    for (x = 1; x <= cnt; x++)
                    {
                        dataGridView_UsbFalsh[x % 16, 1 + x / 16].Value = (Convert.ToInt32(vendor[x-1])).ToString("X");
                        dataGridView_UsbFalsh[16 + x % 16, 1 + x / 16].Value = vendor[x - 1];
                    }
                    for (x = (cnt+1); x < 48; x++)
                    {
                        dataGridView_UsbFalsh[x % 16, 1 + x / 16].Value = "FF";
                        dataGridView_UsbFalsh[16 + x % 16, 1 + x / 16].Value = Convert.ToChar(0xFF);
                    }
                }
                else
                {
                    for (x = 1; x < 48; x++)
                    {
                        dataGridView_UsbFalsh[x % 16, 1 + x / 16].Value = "FF";
                        dataGridView_UsbFalsh[16 + x % 16, 1 + x / 16].Value = Convert.ToChar(0xFF);
                    }
                }
                dataGridView_UsbFalsh[0, 1].Value = cnt.ToString("X2");
                AddMsg("Vendor String char. num.:" + cnt.ToString(), Color.Black);
            }
        }

        private void TextBox_Product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                int cnt, x;
                product = textBox_Product.Text;
                cnt = product.Length;
                if ((cnt != 0x00) & (cnt != 0xFF))
                {
                    for (x = 1; x <= cnt; x++)
                    {
                        dataGridView_UsbFalsh[x % 16, 4 + x / 16].Value = (Convert.ToInt32(product[x - 1])).ToString("X");
                        dataGridView_UsbFalsh[16 + x % 16, 4 + x / 16].Value = product[x - 1];
                    }
                    for (x = (cnt+1); x < 48; x++)
                    {
                        dataGridView_UsbFalsh[x % 16, 4 + x / 16].Value = "FF";
                        dataGridView_UsbFalsh[16 + x % 16, 4 + x / 16].Value = Convert.ToChar(0xFF);
                    }
                }
                else
                {
                    for (x = 1; x < 48; x++)
                    {
                        dataGridView_UsbFalsh[x % 16, 4 + x / 16].Value = "FF";
                        dataGridView_UsbFalsh[16 + x % 16, 4 + x / 16].Value = Convert.ToChar(0xFF);
                    }
                }
                dataGridView_UsbFalsh[0, 4].Value = cnt.ToString("X2");
                AddMsg("Product String char. num.:" + cnt.ToString(), Color.Black);
            }
        }

        private void TextBox_Serial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                int cnt, x;
                serial = textBox_Serial.Text;
                cnt = serial.Length;
                if ((cnt != 0x00) & (cnt != 0xFF))
                {
                    for (x = 1; x <= cnt; x++)
                    {
                        dataGridView_UsbFalsh[x % 16, 7 + x / 16].Value = (Convert.ToInt32(serial[x - 1])).ToString("X");
                        dataGridView_UsbFalsh[16 + x % 16, 7 + x / 16].Value = serial[x - 1];
                    }
                    for (x = (cnt + 1); x < 16; x++)
                    {
                        dataGridView_UsbFalsh[x % 16, 7 + x / 16].Value = "FF";
                        dataGridView_UsbFalsh[16 + x % 16, 7 + x / 16].Value = Convert.ToChar(0xFF);
                    }
                }
                else
                {
                    for (x = 1; x < 16; x++)
                    {
                        dataGridView_UsbFalsh[x % 16, 7 + x / 16].Value = "FF";
                        dataGridView_UsbFalsh[16 + x % 16, 7 + x / 16].Value = Convert.ToChar(0xFF);
                    }
                }
                dataGridView_UsbFalsh[0, 7].Value = cnt.ToString("X2");
                AddMsg("Serial String char. num.:" + cnt.ToString(), Color.Black);
            }
        }

//---------------------------------------------------------------------------------------------
        private void Button_Erase_Click(object sender, EventArgs e)
        {
            byte x;
            if (UsbCheck() == true)
            {
                AddMsg("Flash Erase........", Color.Black);
                richTextBox_UsbFlash.Refresh();

                XM_Bridge_Flash.InterfaceEnable();
                XM_Bridge_Flash.WriteEnable();
                for (x = 0; x < 64; x++)
                {
                    XM_Bridge_Flash.Erase(x);
                }
                XM_Bridge_Flash.WriteDisable();
                AddMsg("", Color.Black);
                AddMsg("Finish.......", Color.Black);
                richTextBox_UsbFlash.Refresh();
                Flash_Read();
            }
        }

        private void Button_Write_Click(object sender, EventArgs e)
        {
            byte x;
            UInt16 data;
            if (UsbCheck() == true)
            {
                Datagridview_Read();
                AddMsg("Flash Write........", Color.Black);
                richTextBox_UsbFlash.Refresh();

                XM_Bridge_Flash.InterfaceEnable();
                XM_Bridge_Flash.WriteEnable();
                for (x = 0; x < 64; x++)
                {
                    data = (UInt16)(Parm.flashbuf[x * 2] + (Parm.flashbuf[x * 2 + 1] << 8));
                    XM_Bridge_Flash.Write(x, data);
                    AddMsg(x + ":" + data.ToString("X"), Color.Black);
                }
                XM_Bridge_Flash.WriteDisable();
                AddMsg("", Color.Black);
                AddMsg("Finish.......", Color.Black);
                richTextBox_UsbFlash.Refresh();
                Flash_Read();
            }
        }

    }
}

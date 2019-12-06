using System;
using System.Drawing;
using System.Windows.Forms;

namespace XM_Tek_Studio_Pro
{

    public partial class Help_Form : Form
    {
        public Help_Form()
        {
            InitializeComponent();
        }

        private void Help_Form_Load(object sender, EventArgs e)
        {
            string[] HelpCmds = new string[91];
            int i = 0;
            HelpCmds[i] = "fpga.set Pll_Bank_En EPP_EN  I/F_Mode1   I/F_Mode2   DCM_m   DCM_d";
            i++;
            HelpCmds[i] = "fpga.write  Addr    Data1	    Data2	    Data3       Data4";
            i++;
            HelpCmds[i] = "fpga.read   Addr    ReadNum";
            i++;
            HelpCmds[i] = "bridge.write Addr	    Data1	    Data2";
            i++;
            HelpCmds[i] = "bridge.read  Addr  RdNum";
            i++;
            HelpCmds[i] = "gpio.dir gpiodir";
            i++;
            HelpCmds[i] = "gpio.write GpioHb GpioLb";
            i++;
            HelpCmds[i] = "gpio.h.set  GpioHb";
            i++;
            HelpCmds[i] = "gpio.l.set  GpioLb";
            i++;
            HelpCmds[i] = "gpio.read";
            i++;
            HelpCmds[i] = "gpio.clr";
            i++;
            HelpCmds[i] = "mipi.dsi LaneNum  Speed  MipiMode(syncpulse burst syncevent)";
            i++;
            HelpCmds[i] = "mipi.video  V_Line  H_Pixels    Framerate      Vbp  Vfp     Hbp     Hfp	    Vsync   Hsync";
            i++;
            HelpCmds[i] = "mipi.write   Dcstype    Data[]";
            i++;
            HelpCmds[i] = "mipi.read   Addr        ReadNum";
            i++;
            HelpCmds[i] = "mipi.wirte.hs   DcsType    Data[]";
            i++;
            HelpCmds[i] = "mipi.read.hs    Addr        RdNum";
            i++;
            HelpCmds[i] = "mipi.bta";
            i++;
            HelpCmds[i] = "mipi.ulp";
            i++;
            HelpCmds[i] = "image.fill  R   G   B";
            i++;
            HelpCmds[i] = "image.write  FileName.bmp";
            i++;
            HelpCmds[i] = "image.show  FileName.bmp";
            i++;
            HelpCmds[i] = "instr.define    InstrumentAddr      Alias";
            i++;
            HelpCmds[i] = "instr.send  InstrumentAddr      Command";
            i++;
            HelpCmds[i] = "instr.xfer  InstrumentAddr/Alias      Command";
            i++;
            HelpCmds[i] = "instr.read  InstrumentAddr/Alias";
            i++;
            HelpCmds[i] = "instr.close InstrumentAddr/Alias";
            i++;
            HelpCmds[i] = "version";
            i++;
            HelpCmds[i] = "delay";
            i++;
            HelpCmds[i] = "sleep";
            i++;
            HelpCmds[i] = "scope.show";
            i++;
            HelpCmds[i] = "scope.save DevName FileName.png";
            i++;
            HelpCmds[i] = "pause   Hint";
            i++;
            HelpCmds[i] = "for start end step plus/minus";
            i++;
            HelpCmds[i] = "endfor";
            i++;
            HelpCmds[i] = "usb.cmd.write   Data[]";
            i++;
            HelpCmds[i] = "txt.wr   parameter   filename.txt";
            i++;
            HelpCmds[i] = "rt4832.0.wrirte Register Data";
            i++;
            HelpCmds[i] = "rt4832.2.wrirte Register Data";
            i++;
            HelpCmds[i] = "rt4832.0.Read Register RdNum";
            i++;
            HelpCmds[i] = "rt4832.2.Read Register RdNum";
            i++;
            HelpCmds[i] = "rt4832.0.vol VspVol VsnVol";
            i++;
            HelpCmds[i] = "rt4832.2.vol VspVol VsnVol";
            i++;
            HelpCmds[i] = "rt4832.0.bl Single/Dual";
            i++;
            HelpCmds[i] = "rt4832.2.bl Single/Dual";
            i++;
            HelpCmds[i] = "rt4832.0.lcd 0/1(disable/enable)";
            i++;
            HelpCmds[i] = "rt4832.2.lcd 0/1(disable/enable)";
            i++;
            HelpCmds[i] = "rt4832.0.led 0/1(disable/enable)";
            i++;
            HelpCmds[i] = "rt4832.2.led 0/1(disable/enable)";
            i++;
            HelpCmds[i] = "rt4832.0.delay 1/2/3(1=1ms,2=2ms,3=5ms)";
            i++;
            HelpCmds[i] = "rt4832.2.delay 1/2/3(1=1ms,2=2ms,3=5ms)";
            i++;
            HelpCmds[i] = "rt4832.0.set VspVol VsnVol single/dual";
            i++;
            HelpCmds[i] = "rt4832.2.set VspVol VsnVol single/dual";
            i++;
            HelpCmds[i] = "rt4832.0.bright 0/1(10bit/11bit) Brightness(0~2047)";
            i++;
            HelpCmds[i] = "rt4832.2.bright 0/1(10bit/11bit) Brightness(0~2047)";
            i++;
            HelpCmds[i] = "rst.en 1/0";
            i++;
            HelpCmds[i] = "rst.trigger D1Time D2Time";
            i++;
            HelpCmds[i] = "rst.pol 1/0";
            i++;
            HelpCmds[i] = "rst.set D2Time 1/0";
            i++;
            HelpCmds[i] = "rst.reset ";
            i++;
            HelpCmds[i] = "ca210.send  Cmd";
            i++;
            HelpCmds[i] = "ca210.xfer  Cmd Delay    File.txt";
            i++;
            HelpCmds[i] = "ca210.read   File.txt";
            i++;
            HelpCmds[i] = "comm.send  Data";
            i++;
            HelpCmds[i] = "comm.xfer   Data";
            i++;
            HelpCmds[i] = "comm.read";
            i++;
            HelpCmds[i] = "k80.flicker.read File.txt";
            i++;
            HelpCmds[i] = "k80.bright.read  File.txt";
            i++;
            HelpCmds[i] = "cpu.addr.write  Cmd[]";
            i++;
            HelpCmds[i] = "cpu.data.write  Cmd[]";
            i++;
            HelpCmds[i] = "mcu.cs.h";
            i++;
            HelpCmds[i] = "mcu.cs.l";
            i++;
            HelpCmds[i] = "spi.set cs sckinv  rddummy wrclk   rdclk";
            i++;
            HelpCmds[i] = "spi.addr.write  Cmd[]";
            i++;
            HelpCmds[i] = "spi.data.write  Cmd[]";
            i++;
            HelpCmds[i] = "spi.cs.h";
            i++;
            HelpCmds[i] = "spi.cs.l";
            i++;
            HelpCmds[i] = "i2c.set LowPluseWidth HighPluseWidth";
            i++;
            HelpCmds[i] = "i2c.addr  slaveaddr";
            i++;
            HelpCmds[i] = "i2c.write Data[]";
            i++;
            HelpCmds[i] = "i2c.read";
            i++;
            HelpCmds[i] = "i2c.read.num rdcnt rdcnt rdcnt";
            i++;
            HelpCmds[i] = "dev.addr.mode cmd";
            i++;
            HelpCmds[i] = "dev.i2c.addr.write Cmd[]";
            i++;
            HelpCmds[i] = "dev.i2c.data.write Cmd[]";
            i++;
            HelpCmds[i] = "dev.rd";
            i++;
            HelpCmds[i] = "dev.dummy.rd";
            i++;
            HelpCmds[i] = "chamber.on";
            i++;
            HelpCmds[i] = "chamber.off";
            i++;
            HelpCmds[i] = "chamber.Temp Temp";
            i++;
            HelpCmds[i] = "dev.data.read";
            i++;
            tslb_msg.Text = "Select it and Ctrl-C";

            dgv_help.ColumnCount = 2;
            dgv_help.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Beige
            };
            dgv_help.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
           
            // Set the column header names.
            dgv_help.Columns[0].Name = "Item";
            dgv_help.Columns[1].Name = "Command";
            dgv_help.Columns[0].Width = 50;
            dgv_help.Columns[1].Width = 650;

            dgv_help.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_help.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            for ( i = 0; i < HelpCmds.Length; i++)
                dgv_help.Rows.Insert(i, i, HelpCmds[i]);
        
        }

       
    }
}

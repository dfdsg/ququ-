using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace XM_Tek_Studio_Pro.StudioUtil
{
    class XM_Param_Util
    {
        public static List<XM_Param_Util.RegInfo> ListRegInfo = new List<XM_Param_Util.RegInfo>();
        private const int BYTENUM = 8;
        private byte GetShiftRange(uint Mask)
        {
            byte  Range = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((Mask & 0x01) == 1)       
                    Range++;

                Mask = Mask >> 1;
            }
            return Range;
        }

        private byte GetShiftMask(uint Mask)
        {
            for (int i = 0; i < 32; i++)
            {
                if ((Mask & 0x01) == 1  )
                       return  (byte)i;
                Mask = Mask >> 1;
            }
            return 0;
        }

        private bool CompareRange(uint Value,double Low, double High)
        {
            if (Value >= Low && Value < High)
                return true;
            else
                return false;
        }

        public int GetWriteNum(string Name)
        {
            RegInfo info = ListRegInfo.Find(x => x.Name.Contains(Name));
            byte Range = GetShiftRange(info.Mask);
            return (Range / BYTENUM) + 1;
        }

        /*
         Name: Inpust , RegName
         RegVal: Read Data form FPGA Board
         Value:  Combine with RegVal and Value
         Return: Look up RegTable and Return Value
         */
        public uint AutoLoopUpGetData(string Name, uint RegVal, uint Value)
        {
            byte Shift = 0;   
            RegInfo info = ListRegInfo.Find(x => x.Name.Contains(Name));
            if (CompareRange(Value, 0, Math.Pow(2, GetShiftRange(info.Mask))))
            {
                Shift = GetShiftMask(info.Mask);
                uint shiftData = (Value << Shift);
                uint AndData = (RegVal & ~(info.Mask));
                return  (uint) (AndData | shiftData);       
            }
            return 0;
        }

        /*
            Name: Inpust , RegName
            RegVal: Read Data form FPGA Board
            Return: Return Pure Data , often use reading Reg Function
        */
        public uint LoopUpTableGetPureData(string Name, uint RegVal)
        {
            RegInfo info = ListRegInfo.Find(x => x.Name.Contains(Name));
            uint Value = (uint)Math.Pow(2, GetShiftRange(info.Mask)) - 1;
            return (RegVal >> GetShiftMask(info.Mask)) & Value;
        }

        public bool AutoUpdateListValue(string Name, uint Value)
        {
            byte Range = 0;
            RegInfo info = ListRegInfo.Find(x => x.Name.Contains(Name));
            int index = ListRegInfo.IndexOf(info);
            Range = GetShiftRange(info.Mask);
            if (CompareRange(Value, 0, Math.Pow(2, Range)))
            {
                info.Value = Value;
                ListRegInfo.RemoveAt(index);
                ListRegInfo.Insert(index, info);
            }
            else
                return false;

            return true;
        }

        public void UpdateRegValue(string Name, uint value)
        {
            RegInfo info = ListRegInfo.Find(x => x.Name.Contains(Name));
            int index = ListRegInfo.IndexOf(info);
            info.Value = value;
            ListRegInfo.RemoveAt(index);
            ListRegInfo.Insert(index, info);
        }
        
        
        public uint GetRangeByTxtName(string Name)
        {
            RegInfo info = ListRegInfo.Find(x => x.TxtName.Contains(Name));
            return GetShiftRange(info.Mask);
        }
        
        public bool GetValueByName(string Name, ref uint value)
        {
            RegInfo info = ListRegInfo.Find(x => x.Name.Contains(Name));
            if (info == null) return false;
            value = info.Value;
            return true;
        }

        public uint GetValueByName(string Name)
        {
            RegInfo info = ListRegInfo.Find(x => x.Name.Contains(Name));
            if (info == null) return 0;
            return info.Value;
        }

        public bool GetAddrByName(string Name, ref byte RegAddr)
        {
            RegInfo info = ListRegInfo.Find(x => x.Name.Contains(Name));
            if (info == null) return false;
            RegAddr = info.Reg;
            return true;
        }

        public byte GetAddrByName(string Name)
        {
            RegInfo info = ListRegInfo.Find(x => x.Name.Contains(Name));
            if (info == null) return 0;
           return info.Reg;
        }

        public bool GetAddrByTxtName(string Name, ref byte RegAddr)
        {
            RegInfo info = ListRegInfo.Find(x => x.TxtName.Contains(Name));
            if (info == null) return false;
            RegAddr = info.Reg;
            return true;
        }

        public string GetRegNameByTxtName(string Name)
        {
            RegInfo info = ListRegInfo.Find(x => x.TxtName.Contains(Name));
            if (info == null) return null;
            return info.Name;

        }

        public bool GetRegNameByTxtName(string Name, string RegName)
        {
            RegInfo info = ListRegInfo.Find(x => x.TxtName.Contains(Name));
            if (info == null) return false;
            RegName = info.Name;
            return true;
        }

        public byte GetAddrByTxtName(string Name)
        {
            RegInfo info = ListRegInfo.Find(x => x.TxtName.Contains(Name));
            return (byte)info.Reg;
        }

        public string GetRootByName(string Name)
        {
            RegInfo info = ListRegInfo.Find(x => x.Name.Contains(Name));
            if (info == null) return null;
            return info.RootIni;
        }

        public void FillInfoList()
        {
            
            ListRegInfo.Add(new RegInfo { Name = "CS_RST_PINCTRL", RootIni = "SLLCONFIG", TxtName = "txtbox_rstctrl", Reg = 0x90, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "DSX_RGBDSX", RootIni = "SLLCONFIG", TxtName = "txtbox_rgxdsx", Reg = 0x92, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "DDR3SEL", RootIni = "SLLCONFIG", TxtName = "txtbox_ddr3sel", Reg = 0x93, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "SPI_RDDUMMYCLK", RootIni = "SLLCONFIG", TxtName = "txtbox_spirddummyclk", Reg = 0x94, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "SPI_WRCLKH_L", RootIni = "SLLCONFIG", TxtName = "txtbox_spiwrclkh", Reg = 0x95, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "SPI_RDCLKH_L", RootIni = "SLLCONFIG", TxtName = "txtbox_spirdclkh", Reg = 0x96, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "CS123SEL", RootIni = "SLLCONFIG", TxtName = "txtbox_cs123sel", Reg = 0x98, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "I2C_STOP_START", RootIni = "SLLCONFIG", TxtName = "txtbox_i2cStop", Reg = 0x9B, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "I2C_SCKH_L", RootIni = "SLLCONFIG", TxtName = "txtbox_i2csckh", Reg = 0x9C, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "I2C_RDBYTE_CNT", RootIni = "SLLCONFIG", TxtName = "txtbox_i2crdbytecnt", Reg = 0x9D, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "INTERFACEMODE", RootIni = "SLLCONFIG", TxtName = "txtbox_interfacemode", Reg = 0xA0, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGBMODE_POLARITY", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbpolarity", Reg = 0xa1, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_TH", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbth", Reg = 0xa2, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_TV", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbtv", Reg = 0xa3, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });       
            ListRegInfo.Add(new RegInfo { Name = "RGB_THDS", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbthds", Reg = 0xa4, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_TVDS", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbtvds", Reg = 0xa5, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_THBP", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbthbp", Reg = 0xa6, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_TVBP", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbtvbp", Reg = 0xa7, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_THPW", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbthpw", Reg = 0xa8, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_TVPW", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbtvpw", Reg = 0xa9, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "DDR3_1ADDR", RootIni = "SLLCONFIG", TxtName = "txtbox_ddr3_1addr", Reg = 0xab, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "DDR3_3ADDR", RootIni = "SLLCONFIG", TxtName = "txtbox_ddr3_3addr", Reg = 0xac, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_NORMALDATA", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbnormaldata", Reg = 0xad, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "SSD2828_BANKEN_MODESET", RootIni = "SLLCONFIG", TxtName = "txtbox_2828_bankmode", Reg = 0xb0, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "SSD2828_BANKCOLOR_SHUTDOWN", RootIni = "SLLCONFIG", TxtName = "txtbox_2828_bankcolor", Reg = 0xb1, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "REG_2828BX_WRRDEN", RootIni = "SLLCONFIG", TxtName = "txtbox_2828bx_wrrden", Reg = 0xb2, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "REG_2828BX_SPICSX", RootIni = "SLLCONFIG", TxtName = "txtbox_2828bx_spicsx", Reg = 0xb3, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_TH_2828BX", RootIni = "SLLCONFIG", TxtName = "txtbox_rgb_th_2828bx", Reg = 0xb4, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_TV_2828BX", RootIni = "SLLCONFIG", TxtName = "txtbox_rgb_tv_2828bx", Reg = 0xb5, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_THDS_2828BX", RootIni = "SLLCONFIG", TxtName = "txtbox_rgb_thds_2828bx", Reg = 0xb6, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_TVDS_2828BX", RootIni = "SLLCONFIG", TxtName = "txtbox_rgb_tvds_2828bx", Reg = 0xb7, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_THBP_2828BX", RootIni = "SLLCONFIG", TxtName = "txtbox_rgb_thbp_2828bx", Reg = 0xb8, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_TVBP_2828BX", RootIni = "SLLCONFIG", TxtName = "txtbox_rgb_tvbp_2828bx", Reg = 0xb9, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_THPW_2828BX", RootIni = "SLLCONFIG", TxtName = "txtbox_thpw_2828bx", Reg = 0xba, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_TVPW_2828BX", RootIni = "SLLCONFIG", TxtName = "txtbox_tvpw_2828bx", Reg = 0xbb, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "RGB_RGBDSX_2828BX", RootIni = "SLLCONFIG", TxtName = "txtbox_rgbdsx_2828bx", Reg = 0xbc, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "LCD_LED_POWER_SET", RootIni = "SLLCONFIG", TxtName = "txtbox_lcdledpowerset", Reg = 0xbd, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "DCM_EN_RST", RootIni = "SLLCONFIG", TxtName = "txtbox_dcm_en_rst", Reg = 0xF0, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "DCM_MULTIPLY", RootIni = "SLLCONFIG", TxtName = "txtbox_dcmmultiply", Reg = 0xf1, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "DCM_DIVIDE", RootIni = "SLLCONFIG", TxtName = "txtbox_dcmdivide", Reg = 0xf2, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "PLLEN_RST", RootIni = "SLLCONFIG", TxtName = "txtbox_pll_en_rst", Reg = 0xf3, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "GPIO_DIR", RootIni = "SLLCONFIG", TxtName = "txtbox_gpio_dir", Reg = 0xfa, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "GPIOA_HB", RootIni = "SLLCONFIG", TxtName = "txtbox_gpioa_hb", Reg = 0xfb, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "GPIOA_LB", RootIni = "SLLCONFIG", TxtName = "txtbox_gpioa_lb", Reg = 0xfc, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });
            ListRegInfo.Add(new RegInfo { Name = "REG_GPIO", RootIni = "SLLCONFIG", TxtName = "txtbox_reg_gpio", Reg = 0xff, Direction = "WR", InitVal = 0, Mask = 255, Value = 0 });

        }
        public class RegInfo
        {
            public string Name { get; set; }
            public string TxtName { get; set; }
            public string RootIni { get; set; }
            public byte Reg { get; set; }
            public string Direction { get; set; }
            public uint InitVal { get; set; }
            public uint Mask { get; set; }
            public uint Value { get; set; }
        }
    }
}

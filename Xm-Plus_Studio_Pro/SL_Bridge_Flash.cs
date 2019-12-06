using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SL_Tek_Studio_Pro
{
    class SL_Bridge_Flash
    {
        public static void InterfaceEnable()
        {
            SL_Comm_Base.GL600IOCtrl.GpioOE(1, 1, 1, 0, 0, 0, 0); // GPIO1:CS, GPIO2:SK, GPIO3:DI, GPIO4:DO,
        }

        public static void InterfaceSet(int cs, int sk, int di)
        {
            SL_Comm_Base.GL600IOCtrl.GpioWR(cs, sk, di, 0, 0, 0, 0);
        }

        public static int Dout()
        {
            int data;
            data = (SL_Comm_Base.GL600IOCtrl.GpioRD() & 0x08) >> 3;
            return data;
        }

        public static int Read(byte addr)
        {
            int wrcnt = 9;
            int rdcnt = 16;
            int x, data, bit;
            int rddata;

            //         data = (addr&0x7f)|0x300;     //8 bits
            data = (addr & 0x3f) | 0x180;   //16 bits

            SL_Bridge_Flash.InterfaceSet(0, 0, 0); // CS = "L", disable
            for (x = (wrcnt - 1); x >= 0; x--)
            {
                bit = (data >> x) & 0x01;
                SL_Bridge_Flash.InterfaceSet(1, 0, bit);
                SL_Bridge_Flash.InterfaceSet(1, 1, bit);
            }
            SL_Bridge_Flash.InterfaceSet(1, 0, 0);

            rddata = 0;
            for (x = (rdcnt - 1); x >= 0; x--)
            {
                SL_Bridge_Flash.InterfaceSet(1, 1, 0);
                SL_Bridge_Flash.InterfaceSet(1, 0, 0);
                bit = SL_Bridge_Flash.Dout();
                rddata = (bit << x) + rddata;
            }
            SL_Bridge_Flash.InterfaceSet(0, 0, 0);
            return rddata;
        }

        public static void WriteEnable()
        {
            int wrcnt = 9;
            int x, data, bit;

            data = 0x130;   //16 bits
            SL_Bridge_Flash.InterfaceSet(0, 0, 0); // CS = "L", disable
            for (x = (wrcnt - 1); x >= 0; x--)
            {
                bit = (data >> x) & 0x01;
                SL_Bridge_Flash.InterfaceSet(1, 0, bit);
                SL_Bridge_Flash.InterfaceSet(1, 1, bit);
            }
            SL_Bridge_Flash.InterfaceSet(0, 0, 0);
        }

        public static void WriteDisable()
        {
            int wrcnt = 9;
            int x, data, bit;

            data = 0x100;   //16 bits
            SL_Bridge_Flash.InterfaceSet(0, 0, 0); // CS = "L", disable
            for (x = (wrcnt - 1); x >= 0; x--)
            {
                bit = (data >> x) & 0x01;
                SL_Bridge_Flash.InterfaceSet(1, 0, bit);
                SL_Bridge_Flash.InterfaceSet(1, 1, bit);
            }
            SL_Bridge_Flash.InterfaceSet(0, 0, 0);
        }

        public static void Write(byte addr, UInt16 par)
        {
            int adcnt = 9;
            int wrcnt = 16;
            int x, data, bit;

            data = (addr & 0x3f) | 0x140;   //16 bits
            SL_Bridge_Flash.InterfaceSet(0, 0, 0); // CS = "L", disable
            for (x = (adcnt - 1); x >= 0; x--)
            {
                bit = (data >> x) & 0x01;
                SL_Bridge_Flash.InterfaceSet(1, 0, bit);
                SL_Bridge_Flash.InterfaceSet(1, 1, bit);
            }

            data = par & 0xffff;   //16 bits
            for (x = (wrcnt - 1); x >= 0; x--)
            {
                bit = (data >> x) & 0x01;
                SL_Bridge_Flash.InterfaceSet(1, 0, bit);
                SL_Bridge_Flash.InterfaceSet(1, 1, bit);
            }
            SL_Bridge_Flash.InterfaceSet(0, 0, 0);
            Thread.Sleep(10);
        }

        public static void Erase(byte addr)
        {
            int adcnt = 9;
            int x, data, bit;

            data = (addr & 0x3f) | 0x1c0;   //16 bits
            SL_Bridge_Flash.InterfaceSet(0, 0, 0); // CS = "L", disable
            for (x = (adcnt - 1); x >= 0; x--)
            {
                bit = (data >> x) & 0x01;
                SL_Bridge_Flash.InterfaceSet(1, 0, bit);
                SL_Bridge_Flash.InterfaceSet(1, 1, bit);
            }
            SL_Bridge_Flash.InterfaceSet(0, 0, 0);
            Thread.Sleep(10);
        }
    }
}

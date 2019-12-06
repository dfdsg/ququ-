using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XM_Tek_Studio_Pro
{
    public partial class SubTabPage : MyFormPage
    {
        public SubTabPage()
        {
            InitializeComponent();
            this.pnl = panel1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool ret = XM_Comm_Control.XM_Comm_Base.CommBase_WriteReg(0x9a, 0x11,0x12);
            ushort val = 0;
            if(ret == true)
            { 
                 XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x9a,ref val);
                 XM_Comm_Control.XM_Comm_Base.CommBase_ReadReg(0x9a, ref val);
            }
        }
    }
}

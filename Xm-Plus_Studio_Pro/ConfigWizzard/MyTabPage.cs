using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XM_Tek_Studio_Pro
{

    public partial class MyTabPage : TabPage
    {
        private Form frm;
        public MyTabPage(MyFormPage frm_ctrl)
        {
            this.frm = frm_ctrl;
            this.Controls.Add(frm_ctrl.pnl);
            this.Text = frm_ctrl.Text;
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                frm.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class MyFormPage : Form
    {
        public Panel pnl;
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace XM_Tek_Studio_Pro
{
    public partial class Splash : Form
    {
        Thread XmThead = null;
        public int PrgbRate =0;
        enum MSG : int { MSG_RATE = 1, MSG_DONE };
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            XmThead = new Thread(Run)
            {
                IsBackground = true
            };
            XmThead.Start();
        }

        public void InvokeRate(int Rate)
        {
            MyMarshalToForm((int)MSG.MSG_RATE, Rate);
        }

        public void InvokeDone(int Rate)
        {
            MyMarshalToForm((int)MSG.MSG_DONE, Rate);
        }

        private void Run()
        {
            while(true)
            { 
                Thread.Sleep(10);
                InvokeRate(PrgbRate++);
                if (PrgbRate > 100) break;
            }
            InvokeDone(0);
        }

        public delegate void MarshalToForm(int Action, int Rate);
        public void MyMarshalToForm(int Action, int Rate)
        {
            try
            {
                object[] args = { Action, Rate };
                MarshalToForm MarshalToFormDelegate = null;

                //  The AccessForm routine contains the code that accesses the form.

                MarshalToFormDelegate = new MarshalToForm(ActionItem);

                //  Execute AccessForm, passing the parameters in args.

                base.Invoke(MarshalToFormDelegate, args);
            }
            catch (Exception ex)
            {
                { throw new ApplicationException(ex.ToString()); };
            }
        }

        public void ActionItem(int Action, int Rate)
        {
            switch (Action)
            {
                case (int)MSG.MSG_RATE:
                    XmPrgb.Value = Rate;
                    break;
                case (int)MSG.MSG_DONE:
                    this.Close();
                    break;
                default:
                    break;
            }

        }
    }
}

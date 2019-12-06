using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class Setting_Form : Form
    {


        public Setting_Form()
        {
            InitializeComponent();
        }

        private void ChkBox_TxCmd_CheckedChanged(object sender, EventArgs e)
        {
            XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSysIniPath);
            Setting.TxCmd = (ChkBox_TxCmd.Checked == true) ? true : false;
            IniUtil.IniWriteValue("System", "TxCmd", Setting.TxCmd.ToString());
        }

        private void ChkBox_LogMsg_CheckedChanged(object sender, EventArgs e)
        {
            XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSysIniPath);
            Log.OutLog = (ChkBox_LogMsg.Checked == true) ? true : false;
            IniUtil.IniWriteValue("System", "OutLog", Log.OutLog.ToString());
        }

        private void ChkBox_Debug_CheckedChanged(object sender, EventArgs e)
        {
            XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSysIniPath);
            Setting.CmdMsg = (ChkBox_Debug.Checked == true) ? true : false;
            IniUtil.IniWriteValue("System", "CmdMsg", Setting.CmdMsg.ToString());
        }

        private void ChkBox_CmdDelayTime_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBox_CmdDelayTime.Checked == true)
                txtbox_delaytime.Enabled = true;
            else
                txtbox_delaytime.Enabled = false;
        }

        private void Setting_Form_Load(object sender, EventArgs e)
        {
            XM_Ini_Util IniUtil = new XM_Ini_Util(Setting.ExeSysIniPath);
            string TxCmd = IniUtil.IniReadValue("System", "TxCmd");
            string OutLog = IniUtil.IniReadValue("System", "OutLog");
            string CmdDelay = IniUtil.IniReadValue("System", "CmdDelayTime");
   
           
            Setting.TxCmd = (TxCmd.CompareTo("False") == 0) ? false : true;
            Setting.T_EveryCmd = (int.TryParse(CmdDelay, out int DelayTime)) ? DelayTime : 35; 
            Log.OutLog = (OutLog.CompareTo("True") == 0) ? true : false;

            ChkBox_TxCmd.Checked = (Setting.TxCmd) ? true : false;
            ChkBox_CmdDelayTime.Checked = (Setting.T_EveryCmd != 35) ? true : false;
            ChkBox_LogMsg.Checked = (Log.OutLog) ? true : false;
            txtbox_delaytime.Enabled = ChkBox_CmdDelayTime.Checked;
            IniUtil.IniWriteValue("System", "TxCmd", Setting.TxCmd ? "True" : "False");
            IniUtil.IniWriteValue("System", "CmdMsg", Setting.CmdMsg ? "True" : "False");
            IniUtil.IniWriteValue("System", "OutLog", Log.OutLog ? "True" : "False");
            IniUtil.IniWriteValue("System", "CmdDelayTime", Setting.T_EveryCmd.ToString());

            txtbox_delaytime.Text = Setting.T_EveryCmd.ToString();
        }


    }
}

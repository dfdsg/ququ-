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
    public partial class Scope_Form : Form
    {

        int g_ScreenLength; // Number of bytes returned from instrument.
        int nViStatus;
        private List<EquipAlias> OsciioList = new List<EquipAlias>();
        private XM_EquipVisa_Util XM_EquipVisa;
        private XM_EquipVisa_Util.OSCType OSC_Type = new XM_EquipVisa_Util.OSCType("KEYSIGHT","Agilent", "Tektronix", "");

        public Scope_Form()
        {
            InitializeComponent();
        }

        /*
         Tips:
             MSO:9 
              DSO:3
        */
        private void Scope_Form_Load(object sender, EventArgs e)
        {
            XM_EquipVisa = new XM_EquipVisa_Util();
            string[] ScopeDev = new string[100];

            XM_EquipVisa.Find_MeasureResource(ScopeDev, out uint DevNum);
            
            string  RdStr = null;
            for (int i=0;i< DevNum; i++)
            {
                XM_EquipVisa = new XM_EquipVisa_Util(ScopeDev[i]);
               
                int nViStatus = XM_EquipVisa.VisaSendandRead("*IDN?", out RdStr);

                if (!String.IsNullOrEmpty(RdStr))
                {
                    string[] DevName = RdStr.Split(',');
                    if (DevName.Length < 2) continue;
                    if (DevName[0].Contains("KEYSIGHT")|| DevName[0].Contains("AGILENT"))//agilent
                    {
                        if (DevName[1].Contains("3104")) { OsciioList.Add(new EquipAlias(ScopeDev[i], RdStr, ":DISPlay:DATA? PNG, COLor", 1)); }
                        else if (DevName[1].Contains("3054")) { OsciioList.Add(new EquipAlias(ScopeDev[i], RdStr, ":DISPlay:DATA? PNG, COLor", 1)); }
                        else if (DevName[1].Contains("9254")) { OsciioList.Add(new EquipAlias(ScopeDev[i], RdStr, ":DISPlay:DATA? PNG,SCReen,1,NORMal", 0)); }
                        else if(DevName[1].Contains("S204")) { OsciioList.Add(new EquipAlias(ScopeDev[i], RdStr, ":DISPlay:DATA? PNG,SCReen,1,NORMal", 0)); }
                        else
                            OsciioList.Add(new EquipAlias(ScopeDev[i], RdStr, ":DISPlay:DATA? PNG, COLor", 1));
                        OSC_Type.GetPictureFromOSC = OSC_Type.KeySight;
                        cbx_devices.Items.Add(RdStr);
                    }
                    else if(RdStr.Contains("DPO"))
                    {
                        OsciioList.Add(new EquipAlias(ScopeDev[i], RdStr,"", 0));
                        OSC_Type.GetPictureFromOSC = OSC_Type.Tektronix;
                        cbx_devices.Items.Add(RdStr);
                    }
                }
   
            }        
            if (cbx_devices.Items.Count > 0) cbx_devices.SelectedIndex = 0;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            string FileName = null, Temp = null;
            tssl_info.ForeColor = Color.Black;
            XM_IO_Util ioUtil = new XM_IO_Util();
            if (pic_DigitalScope.Image == null) { tssl_info.ForeColor = Color.Red; tssl_info.Text = "No Image"; return; }

            tssl_info.Text = "Start";

            if (chk_autoSave.Checked == false && String.IsNullOrEmpty(txtbox_filename.Text))
            {
                tssl_info.Text = "Please Input the Filename";
                tssl_info.ForeColor = Color.Red;
                return;
            }

            if (chk_autoSave.Checked == true)
                FileName = "Scope_" + DateTime.Now.ToLocalTime().ToString("yyyyMMdd-HHmmss");
            else
            {
                if (String.IsNullOrEmpty(txtbox_filename.Text)) { tssl_info.ForeColor = Color.Red; tssl_info.Text = "Please Input Finame"; return; }
                FileName = txtbox_filename.Text;
            }

            FileName = Setting.ExeScopeDirPath + "\\" + FileName;
            if (ioUtil.FileExist(FileName + ".png"))
            {
                Temp = FileName + "_" + DateTime.Now.ToLocalTime().ToString("yyyyMMdd-HHmmss") + ".png";
                pic_DigitalScope.Image.Save(Temp);
                MessageBox.Show("File Exist, Save FilieName: " + Temp);
            }
            else
                pic_DigitalScope.Image.Save(FileName + ".png");

            tssl_info.Text = "Save Successfully";

        }

        private void Scope_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(Setting.ExeScopeDirPath);

            foreach (var fi in di.GetFiles())
            {
                if (fi.Name.Substring(0, 1).CompareTo(".") == 0)
                {
                    try
                    {
                        fi.Delete();
                    }
                    catch
                    {
                        // Extract some information from this exception, and then   
                        // throw it to the parent method.  
                    }
                    finally
                    {

                    }
                }
            }
        }

        private void Btn_RunImage_Click(object sender, EventArgs e)
        {
            byte[] ScopeScreenResultsArray; // Screen Results array.
            try
            {
                XM_EquipVisa = new XM_EquipVisa_Util();
                XM_IO_Util IoUtil = new XM_IO_Util();
                Btn_RunImage.Enabled = false;
                string strPath = null;
                string GetOSCType = null;


                if (cbx_devices.Items.Count < 1) return;

                EquipAlias RunOscillscope = null;
                foreach (EquipAlias OscilloScope in OsciioList)
                {
                    if (OscilloScope.AliasName.CompareTo(cbx_devices.SelectedItem.ToString()) == 0)
                    {
                        RunOscillscope = OscilloScope;
                        break;
                    }
                }

                XM_EquipVisa = new XM_EquipVisa_Util(RunOscillscope.MainName);

                if (!String.IsNullOrEmpty(OSC_Type.GetPictureFromOSC))
                {
                  
                    XM_EquipVisa.OscilloScopeImage(out GetOSCType, RunOscillscope.Type);
                    nViStatus = XM_EquipVisa.VisaReadPictureBinaryFormat(out ScopeScreenResultsArray, out g_ScreenLength, GetOSCType);

                  
                    strPath = IoUtil.FileExist(strPath) ? Setting.ExeScopeDirPath + "\\.scope_screen.png" : Setting.ExeScopeDirPath + "\\.scope_" + DateTime.Now.ToLocalTime().ToString("yyyyMMdd-HHmmss") + ".png";

                    FileStream fStream = File.Open(strPath, FileMode.Create);
                    fStream.Position = 0;
                    fStream.Write(ScopeScreenResultsArray, 0, g_ScreenLength);
                    fStream.Close();        

                    pic_DigitalScope.Load(strPath);

                    if (chk_autoRun.Checked) XM_EquipVisa.VisaSend(":RUN");
                    Btn_RunImage.Enabled = true;
                    XM_EquipVisa.VisaClose();

        
                }
            }
            catch (Exception ex)
            { throw new ApplicationException(ex.ToString()); };
        }
    }
}

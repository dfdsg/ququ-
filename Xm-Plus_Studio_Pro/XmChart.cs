using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using XM_Tek_Studio_Pro.StudioUtil;

namespace XM_Tek_Studio_Pro
{
    public partial class XmChart : Form
    {
        ArrayList BrightRatioList;
        ArrayList IdealRatioList;
        ArrayList SpecMaxRatioList;
        ArrayList SpecMinRatioList;
        ArrayList AntiLogList;
        private const int MAX_GRAYLEVEL = 256;
        float UserSpecMax = 0, UserSpecMin = 0;

        private int Num = 0;

        public XmChart()
        {
            InitializeComponent();
        }

        public XmChart(ArrayList GammaAntiLog)
        {
            InitializeComponent();
            this.AntiLogList = GammaAntiLog;
            this.Num = 1;
        }

        public XmChart(ArrayList BrightRatio, ArrayList IdealRatio, ArrayList SpecMax, ArrayList SpecMin,float UserSpecMax,float UserSpecMin)
        {
            InitializeComponent();
            this.BrightRatioList = BrightRatio;
            this.IdealRatioList = IdealRatio;
            this.SpecMaxRatioList = SpecMax;
            this.SpecMinRatioList = SpecMin;
            this.UserSpecMax = UserSpecMax;
            this.UserSpecMin = UserSpecMin;
            this.Num = 6;
        }

        private void XmChart_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            if (Num == 6 && (BrightRatioList == null || IdealRatioList == null || SpecMaxRatioList == null || SpecMinRatioList == null)) return;
            if (Num == 1 && (AntiLogList == null)) return;

            if (Num == 1) PlotAntiLog();
            if (Num == 6) PlotIdealChart();

        }

        private void PlotAntiLog()
        {
            double Value = 0;
            XM_Digital_Util Tool = new XM_Digital_Util();
            GammaChart.Series.Clear();

            Series LogSeries = new Series("AntiLog", 100)
            {
                Color = Color.Red,
                ChartType = SeriesChartType.Line
            };

           

            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                Value = !Tool.StrToNumber<double>((string)AntiLogList[i].ToString(), ref Value) ? 0 : Value;
                Value = double.IsInfinity(Value) ? 0 : Value;
                LogSeries.Points.AddXY(i, Value);

            }

            GammaChart.Series.Add(LogSeries);
            GammaChart.ChartAreas[0].AxisY.Minimum = 1;//設定Y軸最小值
            GammaChart.ChartAreas[0].AxisY.Maximum = 3;//設定Y軸最大值
            GammaChart.ChartAreas[0].AxisX.Minimum = 0;//設定Y軸最小值
            GammaChart.ChartAreas[0].AxisX.Maximum = 256;//設定Y軸最大值       
            GammaChart.ChartAreas[0].AxisX.Interval = 10;

            GammaChart.Legends[0].Docking = Docking.Top; //自訂顯示位置
            GammaChart.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
            GammaChart.Series[0].BorderWidth = 3;
            GammaChart.ChartAreas[0].AxisY.LabelStyle.Format = "#.##";
            GammaChart.ChartAreas[0].AxisY.Interval = 0.1;

        }

        private void PlotIdealChart()
        {
            GammaChart.Series.Clear();

            Series IdealSeries = new Series("Bright Ratio", 100)
            {
                Color = Color.Red,
                ChartType = SeriesChartType.Line
            };

            Series BrightSeries = new Series("Ideal Ratio", 100)
            {
                Color = Color.Blue,
                ChartType = SeriesChartType.Line
            };

            Series Spec_Max_Series = new Series(Math.Round(UserSpecMax, 2).ToString(), 100)
            {
                Color = Color.DarkOrange,
                ChartType = SeriesChartType.Line
            };

            Series Spec_Min_Series = new Series(Math.Round(UserSpecMin, 2).ToString(), 100)
            {
                Color = Color.Green,
                ChartType = SeriesChartType.Line
            };

            for (int i = 0; i < MAX_GRAYLEVEL; i++)
            {
                IdealSeries.Points.AddXY(i, BrightRatioList[i]);
                BrightSeries.Points.AddXY(i, IdealRatioList[i]);
                Spec_Max_Series.Points.AddXY(i, SpecMaxRatioList[i]);
                Spec_Min_Series.Points.AddXY(i, SpecMinRatioList[i]);
            }

            GammaChart.Series.Add(IdealSeries);
            GammaChart.Series.Add(BrightSeries);
            GammaChart.Series.Add(Spec_Max_Series);
            GammaChart.Series.Add(Spec_Min_Series);
            GammaChart.ChartAreas[0].AxisY.Minimum = 0;//設定Y軸最小值
            GammaChart.ChartAreas[0].AxisY.Maximum = 100;//設定Y軸最大值
            GammaChart.ChartAreas[0].AxisX.Minimum = 0;//設定Y軸最小值
            GammaChart.ChartAreas[0].AxisX.Maximum = 256;//設定Y軸最大值       
            GammaChart.ChartAreas[0].AxisX.Interval = 10;

            GammaChart.Legends[0].Docking = Docking.Top; //自訂顯示位置
            GammaChart.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

            GammaChart.Series[0].BorderWidth = 3;
            GammaChart.Series[1].BorderWidth = 3;



        }
    }
}

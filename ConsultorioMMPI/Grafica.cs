
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media;

namespace ConsultorioMMPI
{
    public partial class Grafica : Form
    {
        public Grafica()
        {
            InitializeComponent();

            float x1 = float.Parse("1");
            float x2 = float.Parse("20");
            float x3 = float.Parse("15");
            float x4 = float.Parse("12");
            float x5 = float.Parse("3");
            float x6 = float.Parse("6");
            float x7 = float.Parse("7");
            float x8 = float.Parse("8");
            float x9 = float.Parse("9");
            float x10 = float.Parse("10");

            var chart = chart1.ChartAreas[0];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;

            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = true;

            chart.AxisX.Minimum = 1;
            chart.AxisX.Maximum = 12;

            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 50;

            chart.AxisX.Interval = 1;
            chart.AxisY.Interval = 51;


            chart1.Series.Add("valor1");
            chart1.Series["valor1"].ChartType = SeriesChartType.Line;
            chart1.Series["valor1"].Color = System.Drawing.Color.Red;
            chart1.Series[0].IsVisibleInLegend = false;

            chart1.Series["valor1"].Points.AddXY(1, x1);
            chart1.Series["valor1"].Points.AddXY(2, x2);
            chart1.Series["valor1"].Points.AddXY(3, x3);
            chart1.Series["valor1"].Points.AddXY(4, x4);
            chart1.Series["valor1"].Points.AddXY(5, x5);
            chart1.Series["valor1"].Points.AddXY(6, x6);
            chart1.Series["valor1"].Points.AddXY(7, x7);
            chart1.Series["valor1"].Points.AddXY(8, x8);
            chart1.Series["valor1"].Points.AddXY(9, x9);
            chart1.Series["valor1"].Points.AddXY(10, x10);


        }
    }
}

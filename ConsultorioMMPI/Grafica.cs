
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media;
using ConsultorioMMPI.Clases.Escalas;

namespace ConsultorioMMPI
{
    public partial class Grafica : Form
    {
        public Grafica()
        {
            InitializeComponent();




        }

        public RespuestaEscalas Resultados { get; internal set; }

        private void Grafica_Load(object sender, EventArgs e)
        {
            CargarDatosGrafica(Resultados.escalasDeValidez.lstEscalas);
        }

        private void CargarDatosGrafica(List<Escala> escala)
        {
            chart1.DataSource = escala;
            Series series = new Series("valor");
            Series maximo = new Series("maximo");
            Series minimo = new Series("minimo");

            series.XValueMember = "siglas";
            series.YValueMembers = "puntuacionT";
            chart1.ChartAreas[0].AxisY.Maximum = 120;
            chart1.ChartAreas[0].AxisY.Minimum = 18;
            chart1.ChartAreas[0].AxisY.Interval = 10;
            chart1.Series.Add(maximo);
            chart1.Series.Add(minimo);
            for (int i = 0; i < Resultados.escalasDeValidez.lstEscalas.Count(); i++)
            {
                chart1.Series["maximo"].Points.Add(new DataPoint(0, escala[i].maximo));
                chart1.Series["minimo"].Points.Add(new DataPoint(0, escala[i].minimo));
            }
            chart1.Series["maximo"].ChartType = SeriesChartType.Point;
            chart1.Series["minimo"].ChartType = SeriesChartType.Point;

            chart1.DataBind();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

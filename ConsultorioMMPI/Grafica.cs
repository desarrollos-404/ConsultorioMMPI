
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
        public List<Escala> _escala;
        public Grafica()
        {
            InitializeComponent();
        }
        public Grafica(List<Escala> escala)
        {
            InitializeComponent();
            _escala = escala;
        }

       // public RespuestaEscalas Resultados { get; internal set; }

        private void Grafica_Load(object sender, EventArgs e)
        {
            CargarDatosGrafica(_escala);
        }

        private void CargarDatosGrafica(List<Escala> escala)
        {

            #region Creacion_del_detalle
            listView1.Items.Clear();

            for (int i = 0; i <= escala.Count; i++)
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = "";
                column.Width = 100;
                listView1.Columns.Add(column);
            }

            ListViewItem item = new ListViewItem("Escala");

            for (int i = 0; i < escala.Count; i++)
            {
                string valor = escala[i].siglas;
                item.SubItems.Add(valor);
            }
            listView1.Items.Add(item);

            ListViewItem item2 = new ListViewItem("Puntaje crudo");
            for (int i = 0; i < escala.Count; i++)
            {
                string valor = escala[i].puntuacionNatural.ToString();
                item2.SubItems.Add(valor);
            }
            listView1.Items.Add(item2);

            ListViewItem item4 = new ListViewItem("Puntaje T");
            for (int i = 0; i < escala.Count; i++)
            {
                string valor = escala[i].puntuacionT.ToString();
                item4.SubItems.Add(valor);
            }
            listView1.Items.Add(item4);
            #endregion


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
            for (int i = 0; i < escala.Count(); i++)
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

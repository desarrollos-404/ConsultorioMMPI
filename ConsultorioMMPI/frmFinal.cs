using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConsultorioMMPI.Clases;
using ConsultorioMMPI.Clases.Escalas;

namespace ConsultorioMMPI
{
    public partial class frmFinal : Form
    {


        public frmFinal(RespuestaEscalas objResultados, int sinContestar)
        {
            InitializeComponent();
            tbInterpretación.ShowTab(tbResultados);
            CargarGrids(objResultados);
            CargarInterpretaciones(objResultados, sinContestar);
            lblSinContestar.Text = "Preguntas SIN CONTESTAR: " + sinContestar.ToString();
        }

        private void CargarInterpretaciones(RespuestaEscalas objResultados, int sinContestar)
        {
            //cargar sin contestar
            lblSinContestarPuntuacion.Text = sinContestar.ToString();
            lblSinContestarDescripcion.Text = clsInterpretacion.InterpretacionSinContestar(sinContestar);
            //Cargar escalas de validez
            lblPtInvar.Text = objResultados.escalasDeValidez.lstEscalas.Where(x => x.siglas == "INVAR-R").FirstOrDefault().puntuacionT.ToString();
            lblPtInver.Text = objResultados.escalasDeValidez.lstEscalas.Where(x => x.siglas == "INVER-R").FirstOrDefault().puntuacionT.ToString();
            lblPtFR.Text = objResultados.escalasDeValidez.lstEscalas.Where(x => x.siglas == "F-R").FirstOrDefault().puntuacionT.ToString();
            lblPtFPSIR.Text = objResultados.escalasDeValidez.lstEscalas.Where(x => x.siglas == "FPSI-R").FirstOrDefault().puntuacionT.ToString();
            lblPtFS.Text = objResultados.escalasDeValidez.lstEscalas.Where(x => x.siglas == "FS").FirstOrDefault().puntuacionT.ToString();
            lblPtFVSR.Text = objResultados.escalasDeValidez.lstEscalas.Where(x => x.siglas == "FVS-R").FirstOrDefault().puntuacionT.ToString();
            lblPtSI.Text = objResultados.escalasDeValidez.lstEscalas.Where(x => x.siglas == "SI").FirstOrDefault().puntuacionT.ToString();
            lblPtLR.Text = objResultados.escalasDeValidez.lstEscalas.Where(x => x.siglas == "L-R").FirstOrDefault().puntuacionT.ToString();
            lblPtKR.Text = objResultados.escalasDeValidez.lstEscalas.Where(x => x.siglas == "K-R").FirstOrDefault().puntuacionT.ToString();


        }

        private void CargarGrids(RespuestaEscalas objResultados)
        {
            grdEscalasDeValidez.DataSource = objResultados.escalasDeValidez.lstEscalas;

            grdEscalasOrdenSuperior.DataSource = objResultados.escalasDeOrdenSuperior.lstEscalas;
            grdEscalasClinicasReestructuradas.DataSource = objResultados.escalasDeClinicasReestructuradas.lstEscalas;
            grdEscalasProblemasSomaticosCognitivos.DataSource = objResultados.somaticosCognitivos.lstEscalas;
            grdProblemasInternalizados.DataSource = objResultados.escalasDeProblemasInternalizados.lstEscalas;
            grdProblemasExternalizados.DataSource = objResultados.escalasDeProblemasExternalizados.lstEscalas;
            grdEscalasProbleasInterpersonlaes.DataSource = objResultados.escalasDeProblemasInterpersonales.lstEscalas;
            grdEscalasInteresEspecifico.DataSource = objResultados.escalasDeInteresEspecifico.lstEscalas;
            grdPSY5.DataSource = objResultados.escalasDePSY_5.lstEscalas;
        }

        private void tbResultados_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void grdEscalasDeValidez_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColor(sender, e);
        }
        private void SetColor(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "puntuacionT")  //Si es la columna a evaluar
            {
                int valor = (int)e.Value;
                if (valor >= 80)   //Si el valor de la celda contiene la palabra hora
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (valor <= 69)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        private void grdEscalasOrdenSuperior_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColor(sender, e);
        }

        private void grdEscalasClinicasReestructuradas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColor(sender, e);
        }

        private void grdEscalasProblemasSomaticosCognitivos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColor(sender, e);
        }

        private void grdProblemasInternalizados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColor(sender, e);
        }

        private void grdProblemasExternalizados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColor(sender, e);
        }

        private void grdEscalasProbleasInterpersonlaes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColor(sender, e);
        }

        private void grdEscalasInteresEspecifico_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColor(sender, e);
        }

        private void grdPSY5_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetColor(sender, e);
        }

        private void grdEscalasDeValidez_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            dgv.ClearSelection();
        }

        private void grdEscalasOrdenSuperior_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            dgv.ClearSelection();
        }

        private void grdEscalasClinicasReestructuradas_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            dgv.ClearSelection();
        }

        private void grdEscalasProblemasSomaticosCognitivos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            dgv.ClearSelection();
        }

        private void grdProblemasInternalizados_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            dgv.ClearSelection();
        }

        private void grdProblemasExternalizados_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            dgv.ClearSelection();
        }

        private void grdEscalasProbleasInterpersonlaes_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            dgv.ClearSelection();
        }

        private void grdEscalasInteresEspecifico_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            dgv.ClearSelection();
        }

        private void grdPSY5_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            dgv.ClearSelection();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ConsultorioMMPI.Clases;
using ConsultorioMMPI.Clases.Escalas;
using MetroFramework.Controls;

namespace ConsultorioMMPI
{
    public partial class frmFinal : Form
    {

        RespuestaEscalas resultados = new RespuestaEscalas();

        public frmFinal(RespuestaEscalas objResultados, int sinContestar)
        {
            InitializeComponent();
            tbInterpretación.ShowTab(tbResultados);
            CargarGrids(objResultados);
            CargarInterpretaciones(objResultados, sinContestar);
            lblSinContestar.Text = "Preguntas SIN CONTESTAR: " + sinContestar.ToString();
            resultados = objResultados;
        }

        private void CargarInterpretaciones(RespuestaEscalas objResultados, int sinContestar)
        {
            //cargar sin contestar
            lblSinContestarPuntuacion.Text = sinContestar.ToString();
            lblSinContestarDescripcion.Text = clsInterpretacion.InterpretacionSinContestar(sinContestar);
            //Cargar escalas de validez
            CargarEscalasDeValidez(objResultados.escalasDeValidez);
            CargarGridsInterpretaciones(objResultados);
        }

        private void CargarGridsInterpretaciones(RespuestaEscalas objResultados)
        {

            List<Interpretacion> lstInterpretacionOrdenSuperior = (from obj in objResultados.escalasDeOrdenSuperior.lstEscalas select clsInterpretacion.InterPretacionConclusion(obj)).ToList();
            List<Interpretacion> lstInterpretacionClincasReestructuradas = (from obj in objResultados.escalasDeClinicasReestructuradas.lstEscalas select clsInterpretacion.InterPretacionConclusion(obj)).ToList();
            List<Interpretacion> lstInterpretacionSomaticosCognitivos = (from obj in objResultados.somaticosCognitivos.lstEscalas select clsInterpretacion.InterPretacionConclusion(obj)).ToList();
            List<Interpretacion> lstInterpretacionProblemasInternalizados = (from obj in objResultados.escalasDeProblemasInternalizados.lstEscalas select clsInterpretacion.InterPretacionConclusion(obj)).ToList();
            List<Interpretacion> lstInterpretacionProblemasExternalizados = (from obj in objResultados.escalasDeProblemasExternalizados.lstEscalas select clsInterpretacion.InterPretacionConclusion(obj)).ToList();
            List<Interpretacion> lstInterpretacionProblemasInterpersonales = (from obj in objResultados.escalasDeProblemasInterpersonales.lstEscalas select clsInterpretacion.InterPretacionConclusion(obj)).ToList();
            List<Interpretacion> lstInterpretacionInteresEspecifico = (from obj in objResultados.escalasDeInteresEspecifico.lstEscalas select clsInterpretacion.InterPretacionConclusion(obj)).ToList();
            List<Interpretacion> lstInterpretacionPSY_5 = (from obj in objResultados.escalasDePSY_5.lstEscalas select clsInterpretacion.InterPretacionConclusion(obj)).ToList();

            grdIntOS.DataSource = lstInterpretacionOrdenSuperior;

        }

        private void CargarEscalasDeValidez(EscalasDeValidez escalasDeValidez)
        {
            try
            {
                List<int> conclusion = new List<int>();
                List<int> conclusion2 = new List<int>();
                List<int> lstGeneral = new List<int>();
                AsignarAControles("INVAR-R", ref lblPtInvar, ref lblINQinvar, ref lblIMPinvar, escalasDeValidez, ref conclusion);
                AsignarAControles("INVER-R", ref lblPtInver, ref lblINQinver, ref lblIMPinver, escalasDeValidez, ref conclusion);
                AsignarAControles("F-R", ref lblPtFR, ref lblINQfr, ref lblIMPfr, escalasDeValidez, ref conclusion2);
                AsignarAControles("FPSI-R", ref lblPtFPSIR, ref lblINQfpsir, ref lblIMPfpsir, escalasDeValidez, ref conclusion2);
                AsignarAControles("FS", ref lblPtFS, ref lblINQfs, ref lblIMPfs, escalasDeValidez, ref conclusion2);
                AsignarAControles("FVS-R", ref lblPtFVSR, ref lblINQfvsr, ref lblIMPfvsr, escalasDeValidez, ref conclusion2);
                AsignarAControles("SI", ref lblPtSI, ref lblINQsi, ref lblIMPsi, escalasDeValidez, ref conclusion2);
                AsignarAControles("L-R", ref lblPtLR, ref lblINQlr, ref lblIMPlr, escalasDeValidez, ref conclusion2);
                AsignarAControles("K-R", ref lblPtKR, ref lblINQkr, ref lblIMPkr, escalasDeValidez, ref conclusion2);
                txtConclusion1.Text = getConclusion1(conclusion);
                txtConclusion2.Text = getConclusion2(conclusion2);
                lstGeneral.AddRange(conclusion);
                lstGeneral.AddRange(conclusion2);
                txtConclusionGral.Text = getConclusiongral(lstGeneral);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string getConclusion1(List<int> conclusion)
        {
            if (conclusion.Any(x => x == 0))
                return "EL PROTOCOLO ES INVÁLIDO DEBIDO A INCONSISTENCIAS Y/O EXAGERACIONES";

            else if (conclusion.Any(x => x == 1))
                return "EL PROTOCOLO ES VALIDO E INTERPRETABLE CON INCONSISTENCIAS";
            else
                return "EL PROTOCOLO ES VALIDO E INTERPRETABLE";
        }
        private string getConclusion2(List<int> conclusion)
        {
            if (conclusion.Any(x => x == 0))
                return "EL PROTOCOLO PODRÍA SER INVÁLIDO DEBIDO A EXCESO DE EXAGERACIONES EN EL SÍNTOMA";

            else if (conclusion.Any(x => x == 1))
                return "EL PROTOCOLO ES VALIDO E INTERPRETABLE PRESENTANDO EXAGERACIONES EN EL SÍNTOMA";
            else
                return "EL PROTOCOLO ES VALIDO E INTERPRETABLE";
        }
        private string getConclusiongral(List<int> conclusion)
        {
            if (conclusion.Any(x => x == 0))
                return "EL PROTOCOLO ES INVALIDO";

            else if (conclusion.Any(x => x == 1))
                return "EL PROTOCOLO ES VALIDO E INTERPRETABLE PRESENTANDO EXAGERACION EN EL SINTOMA, LO QUE SIGNIFICA QUE HAY PRESENCIA DE QUEJAS SOMATICAS, COGNITIVAS Y ALTERACIONES EMOCIONALES SIGNIFICATIVAS, MISMAS QUE SE ANALIZARAN EN LA INTERPRETACIÒN DE LOS RESULTADOS";
            else
                return "EL PROTOCOLO ES VALIDO E INTERPRETABLE";
        }

        private void AsignarAControles(string siglaEscala, ref MetroLabel lblPuntos, ref TextBox lblInquietud, ref TextBox lblImplicacion, EscalasDeValidez escalasDeValidez, ref List<int> valConclusion)
        {
            var objEscala = escalasDeValidez.lstEscalas.Where(x => x.siglas == siglaEscala).FirstOrDefault();
            lblPuntos.Text = objEscala.puntuacionT.ToString();
            var interpretacion = clsInterpretacion.InterpretacionEscalasValidez(objEscala.puntuacionT, objEscala.siglas, ref valConclusion);
            lblInquietud.Text = interpretacion[0].ToString();
            lblImplicacion.Text = interpretacion[1].ToString();
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
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;

                }
                else
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                    
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

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtConclusion1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grafica grafica = new Grafica(resultados.escalasDeOrdenSuperior.lstEscalas);
            //grafica.Resultados = resultados;
            grafica.ShowDialog();
        }
    }
}

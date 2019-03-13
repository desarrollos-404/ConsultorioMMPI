using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsultorioMMPI
{
    public partial class frmUsuarios : MetroForm
    {
        public frmUsuarios(bool modificar)
        {
            InitializeComponent();
            bloquearControles(modificar);
            CargarDatosPrueba();

        }

        private void CargarDatosPrueba()
        {
            txtNSS.Text = "0912039120";
            txtNombre.Text = "Juan Perez";
            txtEdad.Text = "38";
            txtEscolaridad.Text = "Preparatoria";
            txtEstadoCivil.Text = "Casado";
            txtLugarResidencia.Text = "Gomez Palacio DGO";
            txtOcupacion.Text = "Operador";
            txtSexo.Text = "Masculino";
            txtTelefono.Text = "871-782-34-67";
            dteNacimiento.Value = new DateTime(1981, 2, 24);
            dteRegistro.Value = DateTime.Now;
        }

        private void bloquearControles(bool modificar)
        {
            if (modificar)
            {
                btnAplicar.Text = "Ver prueba";
                txtEdad.Enabled = false;
                txtEscolaridad.Enabled = false;
                txtEstadoCivil.Enabled = false;
                txtLugarResidencia.Enabled = false;
                txtNombre.Enabled = false;
                txtOcupacion.Enabled = false;
                txtSexo.Enabled = false;
                txtTelefono.Enabled = false;
                dteNacimiento.Enabled = false;
                dteRegistro.Enabled = false;
            }

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            frmPreguntas frmPreguntas = new frmPreguntas();
            frmPreguntas.WindowState = FormWindowState.Maximized;
            frmPreguntas.ShowDialog();

        }
    }
}

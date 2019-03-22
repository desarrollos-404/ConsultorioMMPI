using ConsultorioMMPI.Clases;
using ConsultorioMMPI.DataBase;
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
            btnAplicar.Visible = false;
            bloquearControles(modificar);
            
            Init();
        }
        public void Init()
        {
            List<Sexos> sexos = new List<Sexos>
        {
            new Sexos{descripcion = "Hombre", valor = 1},
            new Sexos{descripcion = "Mujer", valor = 0}
        };
            cmbsexo.DataSource = sexos;
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
            //txtSexo.Text = "Masculino";
            txtTelefono.Text = "871-782-34-67";
            dteNacimiento.Value = new DateTime(1981, 2, 24);
            dteRegistro.Value = DateTime.Now;
        }

        private void bloquearControles(bool modificar)
        {
            if (modificar)
            {
            //btnAplicar.Text = "Ver prueba";
            txtNSS.Enabled = false;
                txtEdad.Enabled = false;
                txtEscolaridad.Enabled = false;
                txtEstadoCivil.Enabled = false;
                txtLugarResidencia.Enabled = false;
                txtNombre.Enabled = false;
                txtOcupacion.Enabled = false;
                cmbsexo.Enabled = false;
                txtTelefono.Enabled = false;
                dteNacimiento.Enabled = false;
                dteRegistro.Enabled = false;
                btnGuardar.Visible = false;
            }

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPreguntas frmPreguntas = new frmPreguntas();
            frmPreguntas.WindowState = FormWindowState.Maximized;
            frmPreguntas.ShowDialog();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AgregarUsuario();
        }
        public void AgregarUsuario()
        {
            using (DataBaseEntities ctx = new DataBaseEntities())
            {
                try
                {
                    
                    Clientes usuario = new Clientes
                    {
                        NumPreventivo = txtNSS.Text,
                        Nombre = txtNombre.Text,
                        Edad = Convert.ToInt32(txtEdad.Text == "" ? "0": txtEdad.Text),
                        Escolaridad = txtEscolaridad.Text,
                        EstadoCivil = txtEstadoCivil.Text,
                        LugarResidencia = txtLugarResidencia.Text,
                        Ocupacion = txtOcupacion.Text,
                        Sexo = Convert.ToInt32(cmbsexo.SelectedValue),
                        Telefono = txtTelefono.Text,
                        FechaNacimiento = dteNacimiento.Value,
                        FechaRegistro = DateTime.Now
                    };
                    if (!ModelState.IsValid<Clientes>(usuario))
                    {
                        ClsMesageBox.MBOK(ModelState.ErrorMessages[0], "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //ClsMesageBox.MostraFormaEspera("Cargando...", this);

                    ctx.Clientes.Add(usuario);
                    ctx.SaveChanges();
                    ClsMesageBox.MBOK("El cliente se guardo correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bloquearControles(true);

                    btnGuardar.Visible = false;
                    btnAplicar.Visible = true;
                    ClsMesageBox.CerrarFormaEspera();
                }
               
                catch (Exception ex)
                {
                    ClsMesageBox.CerrarFormaEspera();
                    ClsMesageBox.MBOK("No se pudo guardar el cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnVerResultado_Click(object sender, EventArgs e)
        {

        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}

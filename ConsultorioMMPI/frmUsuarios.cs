using ConsultorioMMPI.Clases;
using ConsultorioMMPI.Clases.Escalas;
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
        public RespuestaEscalas _puntuacionNatural = new RespuestaEscalas();
        Validaciones.Validaciones validacion = new Validaciones.Validaciones();
        bool _modificar;
        public frmUsuarios(bool modificar)
        {
            InitializeComponent();
            _modificar = modificar;
            btnAplicar.Visible = false;
            btnVerResultado.Visible = false;
            txtEdad.Enabled = false;
            btnEditar.Visible = false;
            btnBuscar.Visible = false;
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
            
            txtLugarResidencia.Text = "Gomez Palacio DGO";
            txtOcupacion.Text = "Operador";
            //txtSexo.Text = "Masculino";
            txtTelefono.Text = "871-782-34-67";
            dteNacimiento.Value = new DateTime(1981, 2, 24);
            dteRegistro.Value = DateTime.Now;
        }

        private void bloquearControles(bool modificar)
        {
            try
            {
                if (modificar)
                {

                    //btnAplicar.Text = "Ver prueba";
                    //txtNSS.Enabled = false;
                    txtEdad.Enabled = false;
                    txtEscolaridad.Enabled = false;
                    txtLugarResidencia.Enabled = false;
                    txtNombre.Enabled = false;
                    txtOcupacion.Enabled = false;
                    cmbsexo.Enabled = false;
                    txtTelefono.Enabled = false;
                    dteNacimiento.Enabled = false;
                    dteRegistro.Enabled = false;
                    btnGuardar.Visible = false;
                    btnBuscar.Visible = true;
                }

            }
            catch (Exception ex )
            {

                
            }
           
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPreguntas frmPreguntas = new frmPreguntas(txtNSS.Text);
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
                        NumPreventivo = txtNSS.Text.Trim(),
                        Nombre = txtNombre.Text.Trim(),
                        Edad = Convert.ToInt32(txtEdad.Text.Trim() == "" ? "0": txtEdad.Text.Trim()),
                        Escolaridad = txtEscolaridad.Text.Trim(),
                        EstadoCivil = "nulo",
                        LugarResidencia = txtLugarResidencia.Text.Trim(),
                        Ocupacion = txtOcupacion.Text.Trim(),
                        Sexo = Convert.ToInt32(cmbsexo.SelectedValue),
                        Telefono = txtTelefono.Text.Trim(),
                        FechaNacimiento = dteNacimiento.Value,
                        FechaRegistro = DateTime.Now
                    };
                    if (!ModelState.IsValid<Clientes>(usuario))
                    {
                        ClsMesageBox.MBOK(ModelState.ErrorMessages[0], "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //ClsMesageBox.MostraFormaEspera("Cargando...", this);

                    Clientes usuarioGuardado = ctx.Clientes.Find(usuario.NumPreventivo.ToUpper().Trim());
                    if(!_modificar)
                    {
                        if (usuarioGuardado != null)
                        {
                            ClsMesageBox.MBOK("El registro ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        ctx.Clientes.Add(usuario);

                    }
                    else
                    {
                        usuarioGuardado.Nombre = usuario.Nombre;
                        usuarioGuardado.Edad = usuario.Edad;
                        usuarioGuardado.Escolaridad = usuario.Escolaridad;
                        usuarioGuardado.EstadoCivil = usuario.EstadoCivil;
                        usuarioGuardado.LugarResidencia = usuario.LugarResidencia;
                        usuarioGuardado.Ocupacion = usuario.Ocupacion;
                        usuarioGuardado.Sexo = usuario.Sexo;
                        usuarioGuardado.Telefono = usuario.Telefono;
                        usuarioGuardado.FechaNacimiento = usuario.FechaNacimiento;
                        usuarioGuardado.FechaRegistro = usuario.FechaRegistro;
                    }

                    ctx.SaveChanges();
                    ClsMesageBox.MBOK("El cliente se guardo correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNSS.Enabled = false;
                    txtEdad.Enabled = false;
                    txtEscolaridad.Enabled = false;
                    txtLugarResidencia.Enabled = false;
                    txtNombre.Enabled = false;
                    txtOcupacion.Enabled = false;
                    cmbsexo.Enabled = false;
                    txtTelefono.Enabled = false;
                    dteNacimiento.Enabled = false;
                    dteRegistro.Enabled = false;

                    btnGuardar.Visible = false;

                    if(verificaexamen(usuario.NumPreventivo))
                        btnVerResultado.Visible = true;
                    else
                        btnAplicar.Visible = true;
                   // ClsMesageBox.CerrarFormaEspera();
                }
               
                catch (Exception ex)
                {
                    ClsMesageBox.CerrarFormaEspera();
                    ClsMesageBox.MBOK("No se pudo guardar el cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public bool verificaexamen(string usuario)
        {
            using (DataBaseEntities ctx = new DataBaseEntities())
            {
                try
                {
                    Clientes usuarioGuardado = ctx.Clientes.Find(usuario.ToUpper().Trim());
                    if (usuarioGuardado.Resultados != null)
                        return true;
                    return false;
                

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        private void btnVerResultado_Click(object sender, EventArgs e)
        {
            using (DataBaseEntities ctx = new DataBaseEntities())
            {
                try
                {
                    string resp = ctx.Clientes.Where(x => x.NumPreventivo.ToUpper().Trim() == txtNSS.Text.ToUpper().Trim()).FirstOrDefault().Resultados;
                    if(string.IsNullOrEmpty(resp))
                    {
                        ClsMesageBox.MBOK("El numero preventivo no tiene respuestas guardadas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    List<string> split = resp.Split(',').ToList();
                    List<Respuesta> respuestas = new List<Respuesta>();

                    for (int i = 0; i < split.Count; i++)
                    {
                        Respuesta resps = new Respuesta
                        {
                            ID = i +1,
                            valor = Convert.ToInt32(split[i])
                        };

                        respuestas.Add(resps);
                    }

                    _puntuacionNatural = validacion.AplicarValidaciones(respuestas);

                    this.Close();
                    //ClsMesageBox.CerrarFormaEspera();
                    frmFinal frmFinal = new frmFinal(_puntuacionNatural, respuestas.Where(x => x.valor == 2).Count());
                    frmFinal.ShowDialog();
                }
                catch (Exception ex)
                {
                    
                }
            }
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

        private void txtNSS_Enter(object sender, EventArgs e)
        {
            ClsMesageBox.MBOK("", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        public int CalcularEdad(DateTime birthDate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;
            return age;
        }


        private void dteNacimiento_Validated_1(object sender, EventArgs e)
        {
            DateTime nacimiento = dteNacimiento.Value;
            int valor = CalcularEdad(nacimiento);
            if(valor <= 0)
            {
                ClsMesageBox.MBOK("La fecha de nacimiento es invalida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtEdad.Text = valor.ToString();
        }

        private void txtNSS_Validated(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }
        public void buscar()
        {
            using (DataBaseEntities ctx = new DataBaseEntities())
            {
                try
                {
                    if(string.IsNullOrEmpty(txtNSS.Text.Trim()))
                    {
                        ClsMesageBox.MBOK("El numero medico es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Clientes client = ctx.Clientes.Where(x => x.NumPreventivo.ToUpper().Trim() == txtNSS.Text.ToUpper().Trim()).FirstOrDefault();
                    if(client == null)
                    {
                        ClsMesageBox.MBOK("No existe registro con ese número medico", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ClsMesageBox.MBOK("Registro encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargavalores(client);
                    btnBuscar.Visible = false;
                    if (verificaexamen(txtNSS.Text.Trim()))
                        btnVerResultado.Visible = true;
                    else
                        btnAplicar.Visible = true;

                    btnEditar.Visible = true;

                }
                catch (Exception ex)
                {

                    
                }
            }
            

        }
        public void cargavalores(Clientes client)
        {
            txtNSS.Enabled = false;
            txtNombre.Text = client.Nombre.ToString().Trim();
            dteNacimiento.Value = client.FechaNacimiento;
            txtEdad.Text = client.Edad.ToString().Trim();
            cmbsexo.SelectedItem = client.Sexo;
            txtOcupacion.Text = client.Ocupacion.ToString().Trim();
            txtEscolaridad.Text = client.Escolaridad.ToString().Trim();
            txtLugarResidencia.Text = client.LugarResidencia.ToString().Trim();
            dteRegistro.Value = client.FechaRegistro;
            txtTelefono.Text = client.Telefono.ToString().Trim();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnVerResultado.Visible = false;
            btnEditar.Visible = false;
            btnGuardar.Visible = true;

            txtNSS.Enabled = false;
            txtEdad.Enabled = false;
            txtEscolaridad.Enabled = true;
            txtLugarResidencia.Enabled = true;
            txtNombre.Enabled = true;
            txtOcupacion.Enabled = true;
            cmbsexo.Enabled = true;
            txtTelefono.Enabled = true;
            dteNacimiento.Enabled = true;
            dteRegistro.Enabled = true;
            btnAplicar.Visible = false;
            btnVerResultado.Visible = false;
        }
    }
}

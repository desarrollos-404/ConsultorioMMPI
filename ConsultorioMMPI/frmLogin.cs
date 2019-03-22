using ConsultorioMMPI.Clases;
using ConsultorioMMPI.DataBase;
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
     
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            //ClsMesageBox.MostraFormaEspera("Cargando...", this);
            InitializeComponent();
            //ClsMesageBox.CerrarFormaEspera();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loguearse();   
        }
        public void loguearse()
        {
            try
            {
                UsuarioAcceso usuario = new UsuarioAcceso
                {
                    usuario = txtUsuario.Text.ToUpper(),
                    contrasena = txtcontrasena.Text
                };
                if (!ModelState.IsValid<UsuarioAcceso>(usuario))
                {
                    ClsMesageBox.MBOK(ModelState.ErrorMessages[0], "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //ClsMesageBox.MostraFormaEspera("Cargando...",this);
                using (DataBaseEntities ctx = new DataBaseEntities())
                {
                    UsuarioAcceso result = ctx.UsuarioAcceso.Where(x => x.usuario.ToUpper() == usuario.usuario.ToUpper() && x.contrasena == usuario.contrasena).FirstOrDefault();
                    if (result == null)
                    {
                        ClsMesageBox.MBOK("Usuario o contraseña no validos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.DialogResult = DialogResult.OK;
                }
                //ClsMesageBox.CerrarFormaEspera();

            }
            catch (Exception ex)
            {
                ClsMesageBox.CerrarFormaEspera();
                ClsMesageBox.MBOK("Error al loguearse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmLogin_Enter(object sender, EventArgs e)
        {
            loguearse();
        }
    }
}

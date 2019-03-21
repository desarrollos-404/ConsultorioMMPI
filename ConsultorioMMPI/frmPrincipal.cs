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
    public partial class frmPrincipal : Form
    {

        public frmPrincipal()
        {
            InitializeComponent();
            CrearUsuarioLogin();
            this.Visible = false;
        }

        private void CrearUsuarioLogin()
        {
            //string s = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            //string a = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //string d = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            //AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            using (DataBaseEntities ctx = new DataBaseEntities())
            {
                try
                {
                    UsuarioAcceso user= ctx.UsuarioAcceso.Where(x => x.usuario == "hjpulido" && x.contrasena == "12345").FirstOrDefault();
                    if(user == null)
                    {
                        UsuarioAcceso usuarioguardar = new UsuarioAcceso
                        {
                            usuario = "hjpulido",
                            contrasena = "12345"
                        };
                        ctx.UsuarioAcceso.Add(usuarioguardar);
                        ctx.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                }

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmUsuarios registrousuario = new frmUsuarios(false);
            registrousuario.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            int result = (int)login.ShowDialog();

            if (result == 1)
            {
                ucAvisoPrivacidad ucAvisoPrivacidad = new ucAvisoPrivacidad();
                int result2 = (int)ucAvisoPrivacidad.ShowDialog();
                if (result2 == 1)
                    this.Visible = true;
                else this.Close();
            }
            else this.Close();
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);// para usar
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmUsuarios registrousuario = new frmUsuarios(true);
            registrousuario.ShowDialog();
        }
    }
}

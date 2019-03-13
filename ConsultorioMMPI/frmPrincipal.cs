using ConsultorioMMPI.Clases;
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
        bool primeraCarga = true;
        public frmPrincipal()
        {
            InitializeComponent();
            this.Visible = false;   
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
            frmUsuarios registrousuario = new frmUsuarios();
            registrousuario.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            //int result = (int)login.ShowDialog();

            //if (result == 1)
            //{
            //    this.Visible = true;
            //}
            //else this.Close();
        }
    }
}

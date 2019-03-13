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
        public frmPrincipal formprincipal;
        public FrmLogin()
        {
            InitializeComponent();
            //formprincipal = _formprincipal;
            //formprincipal.Visible = false;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ucAvisoPrivacidad ucAvisoPrivacidad = new ucAvisoPrivacidad();
            ucAvisoPrivacidad.ShowDialog();

        }
    }
}

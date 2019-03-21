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
    public partial class Loading : MetroForm
    {
        public Loading(string strCaption)
        {
            InitializeComponent();
            MensajeCargando.Text = strCaption;
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }
    }
}

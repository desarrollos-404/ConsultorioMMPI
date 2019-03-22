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
    public partial class Loading : Form
    {
        public Loading(string caption)
        {
            InitializeComponent();
            lblTexto.Text = caption;
        }
    }
}

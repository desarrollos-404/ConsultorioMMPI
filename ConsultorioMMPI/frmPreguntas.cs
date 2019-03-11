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
    public partial class frmPreguntas : Form
    {
        public frmPreguntas()
        {
            InitializeComponent();
            int count = 0;
            for (int i = 0; i <= 337; i++)
            {
                TableLayoutPanel group = new TableLayoutPanel();
                group.ColumnCount = 2;
                group.RowCount = 1;
                for (int j = 0; j < 2; j++)
                {
                    group.Controls.Add(new RadioButton { Text = "Radio" + j, Location = new Point(j * 2, 10) }, j, 0);
                }

                count++;
                if (count <= 50)
                    group.Location = new Point(1, i * 10);
                else
                if (count > 50 && count <= 100)
                    group.Location = new Point(50, i * 10);
                else
                     if (count > 100 && count <= 150)
                    group.Location = new Point(100, i * 10);
                else
                     if (count > 150 && count <= 200)
                    group.Location = new Point(150, i * 10);
                else
                     if (count > 200 && count <= 250)
                    group.Location = new Point(200, i * 10);
                else
                     if (count > 250 && count <= 300)
                    group.Location = new Point(250, i * 10);
                else
                     if (count > 300 && count <= 350)
                    group.Location = new Point(300, i * 10);
                pnlPrincipal.Dock = DockStyle.Fill;
                pnlPrincipal.Controls.Add(group);
            }

        }
    }

}

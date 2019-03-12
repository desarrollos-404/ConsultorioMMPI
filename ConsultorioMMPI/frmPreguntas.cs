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
                group.ColumnCount = 3;
                group.RowCount = 1;

                group.RowStyles.Add(new RowStyle(SizeType.AutoSize ));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));

                group.Controls.Add(new Label { Text = "Pregunta " + i, Location = new Point(0,10) }, 0, 0);
                for (int j = 1; j < 3; j++)
                {
                    group.Controls.Add(new RadioButton { Text = "Radio" + j }, j, 0);
                }

                count++;
                if (count <= 50)
                    group.Location = new Point(i * 10, 0);
                else
                if (count > 50 && count <= 100)
                    group.Location = new Point(i * 20, 0);
                else
                     if (count > 100 && count <= 150)
                    group.Location = new Point(i * 20, 0);
                else
                     if (count > 150 && count <= 200)
                    group.Location = new Point(i * 20, 0);
                else
                     if (count > 200 && count <= 250)
                    group.Location = new Point(i * 20, 0);
                else
                     if (count > 250 && count <= 300)
                    group.Location = new Point(i * 20, 0);
                else
                     if (count > 300 && count <= 350)
                    group.Location = new Point(i * 20, 0);
                
                group.TabIndex = i;
                group.Width = 500;
                group.Height = 15;
                pnlPrincipal.AutoScroll = true;
                pnlPrincipal.Dock = DockStyle.Fill;
                pnlPrincipal.Controls.Add(group);
            }

        }
    }

}

﻿using ConsultorioMMPI.Clases;
using ConsultorioMMPI.Clases.Escalas;
using ConsultorioMMPI.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsultorioMMPI
{
    public partial class frmPreguntas : Form
    {
        public RespuestaEscalas _puntuacionNatural = new RespuestaEscalas();
        public Validaciones.Validaciones validacion = new Validaciones.Validaciones();
        public string _nss;
        public frmPreguntas(string nss)
        {
            InitializeComponent();
            _nss = nss;
            int count = 0;
            var preguntas = CargarDatosPrueba2();
            this.WindowState = FormWindowState.Maximized;
            for (int i = 0; i <= preguntas.Count - 1; i++)
            {

                TableLayoutPanel group = new TableLayoutPanel();
                group.Name = "group" + i;
                group.ColumnCount = 4;
                group.RowCount = 1;

                group.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));

                group.Controls.Add(new Label { Dock = DockStyle.Fill, Text = string.Format("{0} {1}", preguntas[i].idPregunta, preguntas[i].Descripcion), TextAlign = ContentAlignment.MiddleLeft }, 0, 0);
                for (int j = 1; j < 4; j++)
                {
                    group.Controls.Add(new RadioButton { Name = "Radio" + i + j, Tag = j - 1, Text = j == 1 ? "Verdadero" : j == 2 ? "Falso" : "No contestar" }, j, 0);
                    if (group.Controls[j].Tag.ToString() == "0")
                        ((RadioButton)group.Controls[j]).Checked = true;
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
                group.Width = 800;
                group.Height = 30;
                group.Dock = DockStyle.Top;

                pnlPrincipal.AutoScroll = true;
                pnlPrincipal.Dock = DockStyle.Fill;
                pnlPrincipal.Controls.Add(group);
            }

        }
        private List<Pregunta> CargarDatosPrueba2()
        {
            List<Pregunta> result = new List<Pregunta>();
            var strDataXML = Properties.Resources.Preguntas.ToString();
            var serializer = new XmlSerializer(typeof(List<Pregunta>), new XmlRootAttribute("Preguntas"));
            using (var stringReader = new StringReader(strDataXML))
            using (var reader = XmlReader.Create(stringReader))
                result = (List<Pregunta>)serializer.Deserialize(reader);
            return result;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            if (ClsMesageBox.MBOK("Si cierra la encuesta se perderá su avance\r\n ¿Desea salir? ", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var valido = ClsMesageBox.MBOK("¿Está seguro de sus respuestas?", "Información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (valido)
            {
                GuardaPreguntas();
            }
        }

        public void GuardaPreguntas()
        {
           // ClsMesageBox.MostraFormaEspera("Guardando, espere un momento...", this);
            List<Respuesta> respuestas = new List<Respuesta>();
            respuestas = ObtenerRespuesta();
            bool guardo = GuardarRespuestas(respuestas);
            if (!guardo)
            {
                ClsMesageBox.MBOK("No se pudo guardar las respuestas, intentelo de nuevo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _puntuacionNatural = validacion.AplicarValidaciones(respuestas);

            this.Close();
            //ClsMesageBox.CerrarFormaEspera();
            frmFinal frmFinal = new frmFinal(_puntuacionNatural, respuestas.Where(x => x.valor == 2).Count());
            frmFinal.ShowDialog();

        }

        private bool GuardarRespuestas(List<Respuesta> list)
        {
            using (DataBaseEntities ctx = new DataBaseEntities())
            {
                try
                {
                    Clientes client = ctx.Clientes.Where(x => x.NumPreventivo == _nss).FirstOrDefault();
                    if (client != null)
                    {
                        string resp = string.Empty;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (i == 0)
                                resp = list[i].valor.ToString();
                            else resp = resp + "," + list[i].valor.ToString();
                        }

                        client.Resultados = resp;
                        ctx.SaveChanges();
                    }
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

       
        public List<Respuesta> ObtenerRespuesta()
        {
            List<Respuesta> resp = new List<Respuesta>();
            for (int i = 0; i < pnlPrincipal.Controls.Count; i++)
            {
                var a = pnlPrincipal.Controls[i];
                for (int j = 0; j < a.Controls.Count; j++)
                {
                    if (a.Controls[j] is RadioButton)
                    {

                        if (((RadioButton)a.Controls[j]).Checked)
                        {

                            resp.Add(new Respuesta() { ID = i + 1, valor = (int)a.Controls[j].Tag });
                        }
                        //var b = (RadioButton)a.Controls[j];
                        //b.Checked
                    }
                    // group.Controls.Add(new RadioButton { Name = "Radio" + i + j, Tag = j - 1, Text = j == 1 ? "V" : "F" }, j, 0);
                }


            }
            return resp;
        }


    }
}

namespace ConsultorioMMPI
{
    partial class frmFinal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbInterpretación = new MetroFramework.Controls.MetroTabControl();
            this.tbResultados = new MetroFramework.Controls.MetroTabPage();
            this.tbInterpretacion = new MetroFramework.Controls.MetroTabPage();
            this.layoutPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.escalasDeValidezBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbInterpretación.SuspendLayout();
            this.tbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.escalasDeValidezBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbInterpretación
            // 
            this.tbInterpretación.Controls.Add(this.tbResultados);
            this.tbInterpretación.Controls.Add(this.tbInterpretacion);
            this.tbInterpretación.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInterpretación.Location = new System.Drawing.Point(0, 0);
            this.tbInterpretación.Name = "tbInterpretación";
            this.tbInterpretación.SelectedIndex = 0;
            this.tbInterpretación.Size = new System.Drawing.Size(928, 569);
            this.tbInterpretación.TabIndex = 0;
            this.tbInterpretación.UseSelectable = true;
            // 
            // tbResultados
            // 
            this.tbResultados.Controls.Add(this.layoutPrincipal);
            this.tbResultados.HorizontalScrollbarBarColor = true;
            this.tbResultados.HorizontalScrollbarHighlightOnWheel = false;
            this.tbResultados.HorizontalScrollbarSize = 10;
            this.tbResultados.Location = new System.Drawing.Point(4, 38);
            this.tbResultados.Name = "tbResultados";
            this.tbResultados.Size = new System.Drawing.Size(920, 527);
            this.tbResultados.TabIndex = 0;
            this.tbResultados.Text = "Resultados";
            this.tbResultados.VerticalScrollbarBarColor = true;
            this.tbResultados.VerticalScrollbarHighlightOnWheel = false;
            this.tbResultados.VerticalScrollbarSize = 10;
            // 
            // tbInterpretacion
            // 
            this.tbInterpretacion.HorizontalScrollbarBarColor = true;
            this.tbInterpretacion.HorizontalScrollbarHighlightOnWheel = false;
            this.tbInterpretacion.HorizontalScrollbarSize = 10;
            this.tbInterpretacion.Location = new System.Drawing.Point(4, 38);
            this.tbInterpretacion.Name = "tbInterpretacion";
            this.tbInterpretacion.Size = new System.Drawing.Size(913, 454);
            this.tbInterpretacion.TabIndex = 1;
            this.tbInterpretacion.Text = "Interpretación";
            this.tbInterpretacion.VerticalScrollbarBarColor = true;
            this.tbInterpretacion.VerticalScrollbarHighlightOnWheel = false;
            this.tbInterpretacion.VerticalScrollbarSize = 10;
            // 
            // layoutPrincipal
            // 
            this.layoutPrincipal.AutoScroll = true;
            this.layoutPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.layoutPrincipal.ColumnCount = 1;
            this.layoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPrincipal.Location = new System.Drawing.Point(0, 0);
            this.layoutPrincipal.Name = "layoutPrincipal";
            this.layoutPrincipal.RowCount = 2;
            this.layoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPrincipal.Size = new System.Drawing.Size(920, 527);
            this.layoutPrincipal.TabIndex = 2;
            // 
            // escalasDeValidezBindingSource
            // 
            this.escalasDeValidezBindingSource.DataSource = typeof(ConsultorioMMPI.Clases.Escalas.EscalasDeValidez);
            // 
            // frmFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 569);
            this.Controls.Add(this.tbInterpretación);
            this.Name = "frmFinal";
            this.Text = "frmFinal";
            this.tbInterpretación.ResumeLayout(false);
            this.tbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.escalasDeValidezBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tbInterpretación;
        private MetroFramework.Controls.MetroTabPage tbResultados;
        private System.Windows.Forms.TableLayoutPanel layoutPrincipal;
        private MetroFramework.Controls.MetroTabPage tbInterpretacion;
        private System.Windows.Forms.BindingSource escalasDeValidezBindingSource;
    }
}
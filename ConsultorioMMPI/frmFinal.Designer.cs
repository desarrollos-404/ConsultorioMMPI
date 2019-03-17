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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbInterpretación = new MetroFramework.Controls.MetroTabControl();
            this.tbResultados = new MetroFramework.Controls.MetroTabPage();
            this.layoutPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tbInterpretacion = new MetroFramework.Controls.MetroTabPage();
            this.escalasDeValidezBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.lstEscalasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.significadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntuacionNaturalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntuacionTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbInterpretación.SuspendLayout();
            this.tbResultados.SuspendLayout();
            this.layoutPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.escalasDeValidezBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstEscalasBindingSource)).BeginInit();
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
            // layoutPrincipal
            // 
            this.layoutPrincipal.AutoScroll = true;
            this.layoutPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.layoutPrincipal.ColumnCount = 1;
            this.layoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPrincipal.Controls.Add(this.metroGrid1, 0, 0);
            this.layoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPrincipal.Location = new System.Drawing.Point(0, 0);
            this.layoutPrincipal.Name = "layoutPrincipal";
            this.layoutPrincipal.RowCount = 2;
            this.layoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPrincipal.Size = new System.Drawing.Size(920, 527);
            this.layoutPrincipal.TabIndex = 2;
            // 
            // tbInterpretacion
            // 
            this.tbInterpretacion.HorizontalScrollbarBarColor = true;
            this.tbInterpretacion.HorizontalScrollbarHighlightOnWheel = false;
            this.tbInterpretacion.HorizontalScrollbarSize = 10;
            this.tbInterpretacion.Location = new System.Drawing.Point(4, 38);
            this.tbInterpretacion.Name = "tbInterpretacion";
            this.tbInterpretacion.Size = new System.Drawing.Size(920, 527);
            this.tbInterpretacion.TabIndex = 1;
            this.tbInterpretacion.Text = "Interpretación";
            this.tbInterpretacion.VerticalScrollbarBarColor = true;
            this.tbInterpretacion.VerticalScrollbarHighlightOnWheel = false;
            this.tbInterpretacion.VerticalScrollbarSize = 10;
            // 
            // escalasDeValidezBindingSource
            // 
            this.escalasDeValidezBindingSource.DataSource = typeof(ConsultorioMMPI.Clases.Escalas.EscalasDeValidez);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoGenerateColumns = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descripcionDataGridViewTextBoxColumn,
            this.significadoDataGridViewTextBoxColumn,
            this.siglasDataGridViewTextBoxColumn,
            this.puntuacionNaturalDataGridViewTextBoxColumn,
            this.puntuacionTDataGridViewTextBoxColumn});
            this.metroGrid1.DataSource = this.lstEscalasBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(3, 3);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(914, 150);
            this.metroGrid1.TabIndex = 0;
            // 
            // lstEscalasBindingSource
            // 
            this.lstEscalasBindingSource.DataMember = "lstEscalas";
            this.lstEscalasBindingSource.DataSource = this.escalasDeValidezBindingSource;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // significadoDataGridViewTextBoxColumn
            // 
            this.significadoDataGridViewTextBoxColumn.DataPropertyName = "significado";
            this.significadoDataGridViewTextBoxColumn.HeaderText = "significado";
            this.significadoDataGridViewTextBoxColumn.Name = "significadoDataGridViewTextBoxColumn";
            // 
            // siglasDataGridViewTextBoxColumn
            // 
            this.siglasDataGridViewTextBoxColumn.DataPropertyName = "siglas";
            this.siglasDataGridViewTextBoxColumn.HeaderText = "siglas";
            this.siglasDataGridViewTextBoxColumn.Name = "siglasDataGridViewTextBoxColumn";
            // 
            // puntuacionNaturalDataGridViewTextBoxColumn
            // 
            this.puntuacionNaturalDataGridViewTextBoxColumn.DataPropertyName = "puntuacionNatural";
            this.puntuacionNaturalDataGridViewTextBoxColumn.HeaderText = "puntuacionNatural";
            this.puntuacionNaturalDataGridViewTextBoxColumn.Name = "puntuacionNaturalDataGridViewTextBoxColumn";
            // 
            // puntuacionTDataGridViewTextBoxColumn
            // 
            this.puntuacionTDataGridViewTextBoxColumn.DataPropertyName = "puntuacionT";
            this.puntuacionTDataGridViewTextBoxColumn.HeaderText = "puntuacionT";
            this.puntuacionTDataGridViewTextBoxColumn.Name = "puntuacionTDataGridViewTextBoxColumn";
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
            this.layoutPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.escalasDeValidezBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstEscalasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tbInterpretación;
        private MetroFramework.Controls.MetroTabPage tbResultados;
        private System.Windows.Forms.TableLayoutPanel layoutPrincipal;
        private MetroFramework.Controls.MetroTabPage tbInterpretacion;
        private System.Windows.Forms.BindingSource escalasDeValidezBindingSource;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn significadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntuacionNaturalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntuacionTDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource lstEscalasBindingSource;
    }
}
namespace ConsultorioMMPI
{
    partial class AdministrarBaseDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrarBaseDatos));
            this.btnRespaldar = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblRespuesta = new MetroFramework.Controls.MetroLabel();
            this.lbporcent = new MetroFramework.Controls.MetroLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRespaldar
            // 
            this.btnRespaldar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(135)))), ((int)(((byte)(244)))));
            this.btnRespaldar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRespaldar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRespaldar.ForeColor = System.Drawing.Color.White;
            this.btnRespaldar.Location = new System.Drawing.Point(32, 73);
            this.btnRespaldar.Name = "btnRespaldar";
            this.btnRespaldar.Size = new System.Drawing.Size(197, 37);
            this.btnRespaldar.TabIndex = 7;
            this.btnRespaldar.Text = "Respaldar";
            this.btnRespaldar.UseVisualStyleBackColor = false;
            this.btnRespaldar.Click += new System.EventHandler(this.btnRespaldar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(135)))), ((int)(((byte)(244)))));
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurar.ForeColor = System.Drawing.Color.White;
            this.btnRestaurar.Location = new System.Drawing.Point(436, 73);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(197, 37);
            this.btnRestaurar.TabIndex = 8;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 153);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(601, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Location = new System.Drawing.Point(32, 198);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(51, 19);
            this.lblRespuesta.TabIndex = 10;
            this.lblRespuesta.Text = "Estatus:";
            // 
            // lbporcent
            // 
            this.lbporcent.AutoSize = true;
            this.lbporcent.Location = new System.Drawing.Point(316, 179);
            this.lbporcent.Name = "lbporcent";
            this.lbporcent.Size = new System.Drawing.Size(31, 19);
            this.lbporcent.TabIndex = 11;
            this.lbporcent.Text = "0 %";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(628, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 20);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdministrarBaseDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 237);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbporcent);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.btnRespaldar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdministrarBaseDatos";
            this.Resizable = false;
            this.Text = "Administrador de base de datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRespaldar;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private MetroFramework.Controls.MetroLabel lblRespuesta;
        private MetroFramework.Controls.MetroLabel lbporcent;
        private System.Windows.Forms.Button button2;
    }
}
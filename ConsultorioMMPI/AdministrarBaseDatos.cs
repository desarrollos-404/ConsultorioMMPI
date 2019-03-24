using ConsultorioMMPI.Clases;
using MetroFramework.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
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
    public partial class AdministrarBaseDatos : MetroForm
    {
        public AdministrarBaseDatos()
        {
            InitializeComponent();
        }

        private void btnRespaldar_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            try
            {
                Server dbserver = new Server(new ServerConnection(@"(localdb)\v11.0"));
                Backup dbbackup = new Backup() { Action = BackupActionType.Database, Database = "DataBase" };
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "RespaldoBaseDatos|*.bak";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                { 
                    dbbackup.Devices.AddDevice(saveFileDialog1.FileName, DeviceType.File);
                    dbbackup.Initialize = true;
                    dbbackup.PercentComplete += DbBackup_PercentComplete;
                    dbbackup.Complete += DbBackup_Complete;
                    dbbackup.SqlBackupAsync(dbserver);
                }
            }
            catch (Exception ex)
            {
                ClsMesageBox.MBOK(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
           if(e.Error!= null)
            {
                lblRespuesta.Invoke((MethodInvoker)delegate
                {
                    lblRespuesta.Text = e.Error.Message;
                });
            }
        }

        private void DbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.Percent;
                progressBar1.Update();
            });
            lbporcent.Invoke((MethodInvoker)delegate
            {
                lbporcent.Text = $"{e.Percent}%";
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            try
            {
                Server dbserver = new Server(new ServerConnection(@"(localdb)\v11.0"));
               
                Restore dbRestore = new Restore() { Database = "DataBase", Action = RestoreActionType.Database,ReplaceDatabase = true, NoRecovery = false, };
                OpenFileDialog openfiledialog = new OpenFileDialog();
                openfiledialog.Filter = "RespaldoBaseDatos|*.bak";
                openfiledialog.ShowDialog();

                if (openfiledialog.FileName != "")
                {
                    dbRestore.Devices.AddDevice(openfiledialog.FileName, DeviceType.File);
                    dbRestore.PercentComplete += DbRestore_PercentComplete;
                    dbRestore.Complete += DbRestore_Complete;
                    dbserver.KillAllProcesses("DataBase");

                    dbRestore.SqlRestore(dbserver);
                }
                    
            }
            catch (Exception ex)
            {
                ClsMesageBox.MBOK(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DbRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                lblRespuesta.Invoke((MethodInvoker)delegate
                {
                    lblRespuesta.Text = e.Error.Message;
                });
            }
        }

        private void DbRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.Percent;
                progressBar1.Update();
            });
            lbporcent.Invoke((MethodInvoker)delegate
            {
                lbporcent.Text = $"{e.Percent}%";
            });
        }
    }
}

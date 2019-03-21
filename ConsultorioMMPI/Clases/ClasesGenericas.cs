using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases
{
    class ClasesGenericas
    {
        public static void Tema(ref MetroForm form)
        {
           
        }
        public void ExecuteCommandSync(object command)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string result = proc.StandardOutput.ReadToEnd();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                //this.Visible = false;
                //System.IO.StreamWriter sw = new System.IO.StreamWriter(strRutaActual + "ActualizacionLog.txt", true);
                //sw.WriteLine(System.DateTime.Now.ToString() + " Error al ejecutar Comando: " + ex.ToString());
                //sw.Close();
                //XtraMessageBox.Show("Error al ejecutar Comando", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
    public class Sexos
    {
        public string descripcion { get; set; }
        public int valor { get; set; }
    }
}

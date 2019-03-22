using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace ConsultorioMMPI.Clases
{
    public class ClsMesageBox
    {
        private static Loading Cargando;
        private static Thread t;

        public static void MostraFormaEspera(string strCaption)
        {
            try
            {
                Cargando = new Loading(strCaption);
                
                t = new Thread(new ThreadStart(Carga));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción al mostrar forma de espera: \r\n" + ex.ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void Carga()
        {
            Cargando.ShowDialog();
        }
        //public static void MostraFormaEspera(MetroForm frmParent, string strCaption)
        //{
        //    try
        //    {
        //        if (SplashScreenManager.Default == null || !SplashScreenManager.Default.IsSplashFormVisible)
        //        {
        //            SplashScreenManager.ShowForm(frmParent, typeof(WaitForm1), true, true, true);
        //            SplashScreenManager.Default.SetWaitFormCaption(strCaption);
        //            SplashScreenManager.Default.SetWaitFormDescription("Espere un momento...");
        //            SplashScreenManager.Default.Properties.ParentForm = frmParent;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Excepción al mostrar forma de espera: \r\n" + ex.ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        public static void CerrarFormaEspera()
        {
            try
            {
                t.Abort();
                Cargando.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
               
            }
        }
        public static bool MBOK(string strMensaje, string strTitulo, MessageBoxButtons MBoxBotones, MessageBoxIcon MBoxIcon)
        {
            try
            {
                CerrarFormaEspera();
                DialogResult Resultado = MessageBox.Show(strMensaje, strTitulo, MBoxBotones, MBoxIcon);
                if (Resultado == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción al llamar MB DevExpress: \r\n" + ex.ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}

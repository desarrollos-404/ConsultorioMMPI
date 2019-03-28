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
        private static Form _FRM;

        public static void MostraFormaEspera(string strCaption,Form frm)
        {
            try
            {
                Cargando = new Loading(strCaption);
                _FRM = frm;
                t = new Thread(new ThreadStart(Carga));
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción al mostrar forma de espera: , " + ex.ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void Carga()
        {
            Cargando.ShowDialog(_FRM);
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
        //        MessageBox.Show("Excepción al mostrar forma de espera: , " + ex.ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        public static void CerrarFormaEspera()
        {
            try
            {
                t.Abort();
                
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
                MessageBox.Show("Excepción al llamar MB DevExpress: , " + ex.ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        //private MyWaitForm _waitForm;

        //protected void ShowWaitForm(string message)
        //{
        //    // don't display more than one wait form at a time
        //    if (_waitForm != null && !_waitForm.IsDisposed)
        //    {
        //        return;
        //    }

        //    _waitForm = new MyWaitForm();
        //    _waitForm.SetMessage(message); // "Loading data. Please wait..."
        //    _waitForm.TopMost = true;
        //    _waitForm.StartPosition = FormStartPosition.CenterScreen;
        //    _waitForm.Show();
        //    _waitForm.Refresh();

        //    // force the wait window to display for at least 700ms so it doesn't just flash on the screen
        //    System.Threading.Thread.Sleep(700);
        //    Application.Idle += OnLoaded;
        //}

        //private void OnLoaded(object sender, EventArgs e)
        //{
        //    Application.Idle -= OnLoaded;
        //    _waitForm.Close();
        //}
    }
}

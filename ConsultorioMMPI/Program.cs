using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ConsultorioMMPI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //Application.Run(new frmPrincipal());
            Application.Run(new frmPrincipal());
        }
    }
}

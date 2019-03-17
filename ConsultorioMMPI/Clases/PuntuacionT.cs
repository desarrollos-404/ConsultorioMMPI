using ConsultorioMMPI.Clases.Escalas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases
{
   public static class PuntuacionT
   {        
        public  static void CalcularPuntuacionT( ref Escala escala)
        {
            int[] arrayINVAR = new int[] { 29, 34, 38, 43, 48, 53, 58, 63, 68, 73, 78, 83, 88, 93, 98, 103, 108, 113, 118, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120 };
            int[] arrayINVER = new int[] { 111, 106, 100, 94, 88, 82, 77, 71, 65, 59, 53, 52, 58, 64, 70, 76, 81, 87, 93, 99, 105, 110, 116, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120, 120 };
            switch (escala.siglas)
            {
                case "INVAR-R":
                    if (escala.puntuacionNatural > 19)
                        escala.puntuacionT = 120;
                    else
                    escala.puntuacionT = arrayINVAR[escala.puntuacionNatural];
                    break;
                case "INVER-R":
                    if (escala.puntuacionNatural > 23)
                        escala.puntuacionT = 120;
                    else
                        escala.puntuacionT = arrayINVAR[escala.puntuacionNatural];
                    break;
                default:
                    escala.puntuacionT = 0;
                    break;
            };
        }
    }
}

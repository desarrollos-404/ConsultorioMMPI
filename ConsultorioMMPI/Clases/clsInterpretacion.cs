using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases
{
    public static class clsInterpretacion
    {
        public static string InterpretacionSinContestar(int cantidad)
        {
            if (cantidad > 15)
                return @"Las puntuaciones en algunas escalas pueden no ser validas debido a: Limitaciones en el nivel de lectura o manejo del lenguaje, psicopatología severa, obsesividad, falta de insight, falta de cooperación";
            else
            if (cantidad < 15 && cantidad > 0)
                return @"Las puntuaciones de algunas escalas pueden no ser válidas debido a la falta de respuestas selectivas.";
            else
                return @"El operador se mostro cooperador (a) y con interés para responder los reactivos de la prueba.";

        }
        public static string[] InterpretacionEscalasValidez(int cantidad, string siglas)
        {
            string[] result = new string[2];
            switch (siglas)
            {
                case "INVAR-R":
                    if (cantidad > 80)
                    {
                        result[0] = @"Exceso de inconsistencias en las respuestas";//INQUIETUD
                        result[1] = @"El protocolo es invalido";//IMPLICACIONES
                        return result;
                    }
                    else if (cantidad >= 70 && cantidad <= 80)
                    {
                        result[0] = @"Las puntuaciones en las escalas de validez y sustantivas deben interpretarse con precaución";//INQUIETUD
                        result[1] = @"El protocolo es válido e interpretable con inconsistencias";//IMPLICACIONES
                        return result;
                    }
                    else
                    {
                        result[0] = @"El operador fue cuidadoso en la forma de realizar su evaluación";//INQUIETUD
                        result[1] = @"el protocolo es valido e interpretable";//IMPLICACIONES
                        return result;
                    }
                case "INVER-R":
                    if (cantidad > 80)
                    {
                        result[0] = @"El operador se muestra poco cooperativo en la prueba";//INQUIETUD
                        result[1] = @"El protocolo es inválido";//IMPLICACIONES
                        return result;
                    }
                    else if (cantidad >= 70 && cantidad <= 80)
                    {
                        result[0] = @"Las puntuaciones en las escalas de validez y las sustantivas deben interpretarse con cautela";//INQUIETUD
                        result[1] = @"El protocolo es válido e interpretable con inconsistencias";//IMPLICACIONES
                        return result;
                    }
                    else
                    {
                        result[0] = @"El operador se muestra cooperativo en la prueba";//INQUIETUD
                        result[1] = @"el protocolo es valido e interpretable";//IMPLICACIONES
                        return result;
                    }
                case "F-R":
                    if (cantidad >= 120)
                    {
                        result[0] = @"Inconsistencia en las respuestas y exageración en el síntoma";//INQUIETUD
                        result[1] = @"El protocolo es inválido";//IMPLICACIONES
                        return result;
                    }
                    else if (cantidad >= 100 && cantidad <= 119)
                    {
                        result[0] = @" *Inconsistencias en las respuestas\r\n* psicopatología severa\r\n* estrés emocional severo\r\n*exageración en el síntoma";//INQUIETUD
                        result[1] = @"este protocolo puede no ser valido";//IMPLICACIONES
                        return result;
                    }
                    else if (cantidad >= 80 && cantidad <= 99)
                    {
                        result[0] = @"*Inconsistencia en las respuestas\r\n* psicopatología significativa\r\n* estrés emocional significativo";
                        result[1] = @"Exageración en síntoma";//IMPLICACIONES
                        return result;
                    }
                    else
                    {
                        result[0] = @"Se presenta consistencia en las respuestas";//INQUIETUD
                        result[1] = @"El protocolo es valido e interpretable";//IMPLICACIONES
                        return result;
                    }
                default:
                    return result;
                    //case "FPSI-R":
                    //    if (escala.puntuacionNatural > 15)
                    //        escala.puntuacionT = 120;
                    //    else
                    //        escala.puntuacionT = arrayFPSI[escala.puntuacionNatural];
                    //    break;
                    //case "FS":
                    //    if (escala.puntuacionNatural > 15)
                    //        escala.puntuacionT = 120;
                    //    else
                    //        escala.puntuacionT = arrayFS[escala.puntuacionNatural];
                    //    break;
                    //case "FVS-R":
                    //    if (escala.puntuacionNatural > 30)
                    //        escala.puntuacionT = 104;
                    //    else
                    //        escala.puntuacionT = arrayFVS[escala.puntuacionNatural];
                    //    break;
                    //case "SI":
                    //    if (escala.puntuacionNatural > 28)
                    //        escala.puntuacionT = 115;
                    //    else
                    //        escala.puntuacionT = arraySI[escala.puntuacionNatural];
                    //    break;
                    //case "L-R":
                    //    if (escala.puntuacionNatural > 14)
                    //        escala.puntuacionT = 92;
                    //    else
                    //        escala.puntuacionT = arrayLR[escala.puntuacionNatural];
                    //    break;
                    //case "K-R":
                    //    if (escala.puntuacionNatural > 14)
                    //        escala.puntuacionT = 73;
                    //    else
                    //        escala.puntuacionT = arrayKR[escala.puntuacionNatural];
                    //    break;
                    //default:
                    //    break;
            }
        }
    }
}

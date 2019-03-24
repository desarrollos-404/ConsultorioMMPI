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
        public static string[] InterpretacionEscalasValidez(int cantidad, string siglas, ref List<int> valConclusion)
        {
            string[] result = new string[2];
            switch (siglas)
            {
                case "INVAR-R":
                    if (cantidad >= 80)
                    {
                        result[0] = @"Exceso de inconsistencias en las respuestas";//INQUIETUD
                        result[1] = @"El protocolo es invalido";//IMPLICACIONES
                        valConclusion.Add(0);
                        return result;
                    }
                    else if (cantidad >= 70 && cantidad < 80)
                    {
                        result[0] = @"Las puntuaciones en las escalas de validez y sustantivas deben interpretarse con precaución";//INQUIETUD
                        result[1] = @"El protocolo es válido e interpretable con inconsistencias";//IMPLICACIONES
                        valConclusion.Add(1);
                        return result;
                    }
                    else
                    {
                        result[0] = @"El operador fue cuidadoso en la forma de realizar su evaluación";//INQUIETUD
                        result[1] = @"el protocolo es valido e interpretable";//IMPLICACIONES
                        valConclusion.Add(2);
                        return result;
                    }
                case "INVER-R":
                    if (cantidad >= 80)
                    {
                        result[0] = @"El operador se muestra poco cooperativo en la prueba";//INQUIETUD
                        result[1] = @"El protocolo no es válido";//IMPLICACIONES
                        valConclusion.Add(0);
                        return result;
                    }
                    else if (cantidad >= 70 && cantidad < 80)
                    {
                        result[0] = @"Las puntuaciones en las escalas de validez y las sustantivas deben interpretarse con cautela";//INQUIETUD
                        result[1] = @"El protocolo es válido e interpretable con inconsistencias";//IMPLICACIONES
                        valConclusion.Add(1);
                        return result;
                    }
                    else
                    {
                        result[0] = @"El operador se muestra cooperativo en la prueba";//INQUIETUD
                        result[1] = @"El protocolo es valido e interpretable";//IMPLICACIONES
                        valConclusion.Add(2);
                        return result;
                    }
                case "F-R":
                    if (cantidad >= 120)
                    {
                        result[0] = @"Inconsistencia en las respuestas y exageración en el síntoma";//INQUIETUD
                        result[1] = @"El protocolo es inválido";//IMPLICACIONES
                        valConclusion.Add(0);
                        return result;
                    }
                    else if (cantidad >= 100 && cantidad <= 119)
                    {
                        result[0] = @" *Inconsistencias en las respuestas\r\n* psicopatología severa\r\n* estrés emocional severo\r\n*exageración en el síntoma";//INQUIETUD
                        result[1] = @"este protocolo puede no ser valido";//IMPLICACIONES
                        valConclusion.Add(0);
                        return result;
                    }
                    else if (cantidad >= 80 && cantidad <= 99)
                    {
                        result[0] = @"*Inconsistencia en las respuestas\r\n* psicopatología significativa\r\n* estrés emocional significativo";
                        result[1] = @"Exageración en síntoma";//IMPLICACIONES
                        valConclusion.Add(1);
                        return result;

                    }
                    else
                    {
                        result[0] = @"Se presenta consistencia en las respuestas";//INQUIETUD
                        result[1] = @"El protocolo es valido e interpretable";//IMPLICACIONES
                        valConclusion.Add(2);
                        return result;
                    }
                default:
                    return result;
                case "FPSI-R":
                    if (cantidad >= 100)
                    {
                        result[0] = @"Exceso de inconsistencias en las respuestas";//INQUIETUD
                        result[1] = @"El protocolo es inválido";//IMPLICACIONES
                        valConclusion.Add(0);
                        return result;
                    }
                    else if (cantidad > 70 && cantidad <= 99)
                    {
                        result[0] = @"*Inconsistencia en las respuestas\r\n* Psicopatología significativa";//INQUIETUD
                        result[1] = @"Exagaración en el síntoma";//IMPLICACIONES
                        valConclusion.Add(1);
                        return result;
                    }
                    else
                    {
                        result[0] = @"Se presenta consistencia en las respuestas";//INQUIETUD
                        result[1] = @"El protocolo es valido e interpretable";//IMPLICACIONES
                        valConclusion.Add(2);
                        return result;
                    }
                case "FS":
                    if (cantidad >= 100)
                    {
                        result[0] = @"Las puntuaciones en las escalas somáticas pueden no ser validas.";//INQUIETUD
                        result[1] = @"Exageración en el síntoma";//IMPLICACIONES
                        valConclusion.Add(0);
                        return result;
                    }
                    else if (cantidad > 80 && cantidad <= 99)
                    {
                        result[0] = @"No hay evidencia de exageración de síntomas además de que se presenta consistencia en las respuestas obtenidas";//INQUIETUD
                        result[1] = @"Exageración en el síntoma";//IMPLICACIONES
                        valConclusion.Add(1);
                        return result;
                    }
                    else
                    {
                        result[0] = @"Se presenta consistencia en las respuestas";//INQUIETUD
                        result[1] = @"El protocolo es valido e interpretable";//IMPLICACIONES
                        valConclusion.Add(2);
                        return result;
                    }
                case "FVS-R":
                    if (cantidad >= 100)
                    {
                        result[0] = @"Las puntuaciones en las escalas somáticas y cognitivas pueden no ser validas y deben interpretarse con precaución. ";//INQUIETUD
                        result[1] = @"Exageración en el síntoma";//IMPLICACIONES
                        valConclusion.Add(0);
                        return result;
                    }
                    else if (cantidad > 80 && cantidad <= 99)
                    {
                        result[0] = @"Las puntuaciones en las escalas somáticas y cognitivas pueden no ser validas y deben interpretarse con precaución.";//INQUIETUD
                        result[1] = @"Exageración en el síntoma";//IMPLICACIONES
                        valConclusion.Add(1);
                        return result;
                    }
                    else
                    {
                        result[0] = @"No hay evidencia de exageración de síntomas además de que se presenta consistencia en las respuestas obtenidas";//INQUIETUD
                        result[1] = @"El protocolo es valido e interpretable";//IMPLICACIONES
                        valConclusion.Add(2);
                        return result;
                    }
                case "SI":
                    if (cantidad >= 100)
                    {
                        result[0] = @"Las puntuaciones en las escalas de quejas cognitivas puede no ser valida por lo que deben interpretarse con precaución.";//INQUIETUD
                        result[1] = @"Exageración en el síntoma";//IMPLICACIONES
                        valConclusion.Add(0);
                        return result;
                    }
                    else if (cantidad > 80 && cantidad <= 99)
                    {
                        result[0] = @"Las puntuaciones en las escalas de quejas cognitivas puede no ser valida por lo que deben interpretarse con precaución.";//INQUIETUD
                        result[1] = @"Exageración en el síntoma";//IMPLICACIONES
                        valConclusion.Add(1);
                        return result;
                    }
                    else
                    {
                        result[0] = @"No hay evidencia de exageración de síntomas además de que se presenta consistencia en las respuestas obtenidas";//INQUIETUD
                        result[1] = @"El protocolo es valido e interpretable";//IMPLICACIONES
                        valConclusion.Add(2);
                        return result;
                    }
                case "L-R":
                    if (cantidad >= 80)
                    {
                        result[0] = @"*Inconsistencias en las respuestas.\r\n*Posible exageración de síntomas\r\n*El operador se presenta a si mismo como una persona extremadamente positiva, negando fallas menores y deficiencias que la mayoría de las personas reconocen.";//INQUIETUD
                        result[1] = @"El protocolo puede no ser valido.";//IMPLICACIONES
                        valConclusion.Add(0);
                        return result;
                    }
                    else if (cantidad > 65 && cantidad <= 79)
                    {
                        result[0] = @"*Inconsistencia en las respuestas\r\n*Educación tradicional\r\n*El operador se presente a si mismo de una forma positiva negando algunas faltas leves y deficiencias que la mayoría de las personas reconocen.";//INQUIETUD
                        result[1] = @"Exageración en el síntoma";//IMPLICACIONES
                        valConclusion.Add(1);
                        return result;
                    }
                    else
                    {
                        result[0] = @"No hay evidencia de exageración de síntomas además de que se presenta consistencia en las respuestas obtenidas";//INQUIETUD
                        result[1] = @"El protocolo es valido e interpretable";//IMPLICACIONES
                        valConclusion.Add(2);
                        return result;
                    }
                case "K-R":
                    if (cantidad >= 71)
                    {
                        result[0] = @"El operador se presenta a si mismo como una persona extremadamente bien adaptada, lo cual no refiere un buen ajuste psicológico";//INQUIETUD
                        result[1] = @"Exageración en el síntoma";//IMPLICACIONES
                        valConclusion.Add(0);
                        return result;
                    }
                    else if (cantidad > 60 && cantidad <= 70)
                    {
                        result[0] = @"El operador se presenta a si mismo como una persona bien adaptada, lo cual refiere un buen ajuste psicológico.";//INQUIETUD
                        result[1] = @"Exageración en el síntoma";//IMPLICACIONES
                        valConclusion.Add(1);
                        return result;
                    }
                    else
                    {
                        result[0] = @"no hay evidencia de exageración de síntomas además de que se presenta consistencia en las respuestas obtenidas";//INQUIETUD
                        result[1] = @"El protocolo es valido e interpretable";//IMPLICACIONES
                        valConclusion.Add(2);
                        return result;
                    }
                    //default:
                    //    break;
            }
        }
        //public static string InterPretacionConclusion(int tipoConclusion, List<int> valoresInterpretar, ref int queFue)
        //{
        //    switch (tipoConclusion)
        //    {
        //        case 0:
        //            if (valoresInterpretar.Any(x => x >= 80))
        //            {
        //                queFue = 0;
        //                return "EL PROTOCOLO ES INVÁLIDO DEBIDO A INCONSISTENCIAS Y/O EXAGERACIONES";
        //            }

        //            else if (valoresInterpretar.Any(x => x >= 70 && x <= 79))
        //            {
        //                queFue = 1;
        //                return "EL PROTOCOLO ES VALIDO E INTERPRETABLE CON INCONSISTENCIAS";
        //            }

        //            else
        //            {
        //                queFue = 2;
        //                return "EL PROTOCOLO ES VALIDO E INTERPRETABLE";
        //            }
        //        case 1:
        //            if (valoresInterpretar.Any(x => x >= 80))
        //            {
        //                queFue = 0;
        //                return "EL PROTOCOLO ES INVÁLIDO DEBIDO A INCONSISTENCIAS Y/O EXAGERACIONES";
        //            }

        //            else if (valoresInterpretar.Any(x => x >= 70 && x <= 79))
        //            {
        //                queFue = 1;
        //                return "EL PROTOCOLO ES VALIDO E INTERPRETABLE CON INCONSISTENCIAS";
        //            }

        //            else
        //            {
        //                queFue = 2;
        //                return "EL PROTOCOLO ES VALIDO E INTERPRETABLE";
        //            }

        //        case 2:
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}

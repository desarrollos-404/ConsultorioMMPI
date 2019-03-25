using ConsultorioMMPI.Clases.Escalas;
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
        public static string InterPretacionConclusion(objInterpretacion objInterpretacion)
        {
            switch (objInterpretacion.siglas)
            {
                #region Orden superior
                case "AE/PI":
                    if (objInterpretacion.puntuacionT >= 80)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un considerable malestar emocional que es probable que sea percibido como una crisis";
                        objInterpretacion.especificaciones = @"Persona agobiada, triste, insatisfecha con su vida y confusión emocional considerable. Probable riesgo de ideación suicida debido a la presencia constante de sentimientos de desesperanza, pesimismo acerca del futuro, quejas de depresión y ansiedad y dificultades para concentrarse y enfrentar adecuadamente el estrés lo que podría derivar en conductas obsesivas.";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas CRD,CR2,CR7,ISU,";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 79)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un malestar emocional significativo";
                        objInterpretacion.especificaciones = @"Persona agobiada, triste, insatisfecha con su vida y confusión emocional considerable. Probable riesgo de ideación suicida debido a la presencia constante de sentimientos de desesperanza, pesimismo acerca del futuro, quejas de depresión y ansiedad y dificultades para concentrarse y enfrentar adecuadamente el estrés lo que podría derivar en conductas obsesivas.";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas CRD,CR2,CR7,ISU,";
                    }
                    else if (objInterpretacion.puntuacionT >= 40 && objInterpretacion.puntuacionT <= 64)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel de ajuste emocional promedio";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel de ajuste emocional superior al promedio";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "AP":
                    if (objInterpretacion.puntuacionT >= 80)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican una alteración seria del pensamiento";
                        objInterpretacion.especificaciones = @"Síntomas y dificultades asociados con la alteración del pensamiento (p, ej., delirios paranoides y no paranoides, alucinaciones auditivas y visuales, pensamientos poco realistas).";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas CR6, CR8 Y PSYC-R";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 79)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican una alteración significativa del pensamiento";
                        objInterpretacion.especificaciones = @"Síntomas y dificultades asociados con la alteración del pensamiento (p, ej., delirios paranoides y no paranoides, alucinaciones auditivas y visuales, pensamientos poco realistas).";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas CR6, CR8 Y PSYC-R";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "AC/PE":
                    if (objInterpretacion.puntuacionT >= 80)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican la presencia considerable de conductas externalizadas/ acting -out, por lo que es probable una alteración notable y que el individuo se haya involucrado en problemas";
                        objInterpretacion.especificaciones = @"Abuso de sustancias, historial de conducta criminal, conductas abusivas y violentas, pobre control de impulsos";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas CR4, CR9, PCIJ, ABS, AG; EUF, AGGR-R Y DISC-R";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 79)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican la presencia significativa de conductas externalizadas/acting out, por lo que es probable que el individuo se haya involucrado en problemas.";
                        objInterpretacion.especificaciones = @"Abuso de sustancias, historial de conducta criminal, conductas abusivas y violentas, pobre control de impulsos";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas CR4, CR9, PCIJ, ABS, AG; EUF, AGGR-R Y DISC-R";
                    }
                    else if (objInterpretacion.puntuacionT >= 40 && objInterpretacion.puntuacionT <= 64)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel de conductas reprimidas promedio";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel de conductas reprimidas superior al promedio; es poco probable que se involucre en conductas de acting-out";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                #endregion
                #region Clinicas Reestructuradas
                case "CRD":
                    if (objInterpretacion.puntuacionT >= 80)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican confusión emocional significativa, sentirse agobiado y ser extremadamente infeliz, esta triste e insatisfecho con su vida.";
                        objInterpretacion.especificaciones = @"Quejas de depresión y ansiedad. Sentimientos de desesperanza y pesimismo acerca del futuro. Dificultades para afrontar adecuadamente el estrés. Baja autoestima. Sentimientos de incapacidad para tratar con las circunstancias";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas ISU y IMD si la puntuación T es igual o mayor a 65, además de evaluar el riesgo de autolesiones e ideaciones suicidas.";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 79)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican sentimientos de tristeza e infelicidad, además de estar insatisfecho con las condiciones actuales de su vida.";
                        objInterpretacion.especificaciones = @"Quejas de depresión y ansiedad. Sentimientos de desesperanza y pesimismo acerca del futuro. Dificultades para afrontar adecuadamente el estrés. Baja autoestima. Sentimientos de incapacidad para tratar con las circunstancias";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas ISU y IMD si la puntuación T es igual o mayor a 65, además de evaluar el riesgo de autolesiones e ideaciones suicidas.";
                    }
                    else if (objInterpretacion.puntuacionT >= 40 && objInterpretacion.puntuacionT <= 64)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel del estado de animo y de satisfacción con su vida promedio.";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel del estado de animo y de satisfacción con su vida superior al promedio.";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "CR1":
                    if (objInterpretacion.puntuacionT >= 80)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un patrón difuso de quejas somáticas que involucra a diferentes sistemas del cuerpo, los cuales pueden incluir dolor de cabeza, síntomas neurológicos y gastrointestinales.";
                        objInterpretacion.especificaciones = @"Tiende a preocuparse por su salud física. Es propenso a desarrollar síntomas físicos en respuesta al estrés. Existe un componente psicológico a sus quejas. Se queja de fatiga. Se descubre con múltiples quejas somáticas.";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas CR3 Y TIM si la puntuación T es igual o menor a 39, además de evaluar la posibilidad de trastorno somato morfe.";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 79)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican múltiples quejas somáticas que pueden incluir dolores de cabeza, síntomas neurológicos y gastrointestinales.";
                        objInterpretacion.especificaciones = @"Tiende a preocuparse por su salud física. Es propenso a desarrollar síntomas físicos en respuesta al estrés. Existe un componente psicológico a sus quejas. Se queja de fatiga. Se descubre con múltiples quejas somáticas.";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas CR3 Y TIM si la puntuación T es igual o menor a 39, además de evaluar la posibilidad de trastorno somato morfe.";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un sentido de bienestar";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "CR2":
                    if (objInterpretacion.puntuacionT >= 65)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican una perdida de experiencias emocionales positivas, anhedonia significativa y perdida de interés.";
                        objInterpretacion.especificaciones = @"Es pesimista, socialmente introvertido, socialmente desvinculado, perdida de energía, muestra abundantes síntomas de depresión.";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con la escala CR2 si la puntuación T es igual o mayor a 80, para evaluar trastornos posiblemente relacionados con depresión mayor. Podría requerir tratamiento hospitalario para la depresión mayor.";
                    }
                    else if (objInterpretacion.puntuacionT >= 40 && objInterpretacion.puntuacionT <= 64)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel de bienestar psicológico promedio con pocas experiencias emocionales positivas.";
                        objInterpretacion.especificaciones = @"Es pesimista, socialmente introvertido, socialmente desvinculado, perdida de energía, muestra abundantes síntomas de depresión.";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con la escala CR2 si la puntuación T es igual o mayor a 80, además de evaluar trastornos relacionados con la depresión.";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel alto de bienestar psicológico, un amplio rango de experiencias emocionales positivas y sentimientos de confianza y energía.";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "CR3":
                    if (objInterpretacion.puntuacionT >= 65)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican tener creencias cínicas, se muestra desconfiado de los otros y cree que los otros ven solo por sus intereses.";
                        objInterpretacion.especificaciones = @"Es hostil hacia los demás y se siente perturbado en compañía de otros. Desconfía de los demás, tiene experiencias interpersonales negativas.";
                        objInterpretacion.correlacionesEmpiricas = @"Evaluar la presencia de los trastornos de personalidad que involucran la desconfianza y hostilidad hacia otros";
                    }
                    else if (objInterpretacion.puntuacionT >= 40 && objInterpretacion.puntuacionT <= 64)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican cierta desconfianza hacia los demás.";
                        objInterpretacion.especificaciones = @"Es hostil hacia los demás y se siente perturbado en compañía de otros. Desconfía de los demás, tiene experiencias interpersonales negativas.";
                        objInterpretacion.correlacionesEmpiricas = @"Evaluar la presencia de los trastornos de personalidad que involucran la desconfianza y hostilidad hacia otros";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican que describe a los otros como bien intencionados y dignos de confianza, rechaza las creencias negativas de los otros. Posibilidad de exceso de confianza.";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "CR4":
                    if (objInterpretacion.puntuacionT >= 65)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican una historia significativa de conductas antisociales.";
                        objInterpretacion.especificaciones = @"Ha tenido problemas con el sistema de justicia. No se ajusta a las normas y expectativas sociales. Tiene dificultades con las figuras de autoridad. Experiencias conflictivas en sus relación es interpersonales. Es impulsivo. Presenta conductas acting out cuando se aburre. tiene características antisociales. tiene una historia de delincuencia juvenil. se ha involucrado con el abuso de sustancias. tiene problemas familiares. es agresivo interpersonalmente.";
                        objInterpretacion.correlacionesEmpiricas = @"Evaluar la presencia del trastorno de la personalidad antisocial. Trastorno por consumo de sustancias y otros problemas externalizados.";
                    }
                    else if (objInterpretacion.puntuacionT >= 40 && objInterpretacion.puntuacionT <= 64)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican  un nivel bajo de conductas antisociales en el pasado.";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"Evaluar la presencia del trastorno de la personalidad antisocial. Trastorno por consumo de sustancias y otros problemas externalizados.";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel por debajo del promedio de conductas antisociales en el pasado.";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;

                case "CR6":
                    if (objInterpretacion.puntuacionT >= 80)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican ideas prominentes de persecución que probablemente alcancen un nivel de delirios paranoides";
                        objInterpretacion.especificaciones = @"Experimenta ideas paranoides. Es suspicaz y hostil con otros. Presenta dificultades en las relaciones interpersonales como resultado de su suspicacia. Carece de insight. Culpa a los demás de sus problemas o dificultades.";
                        objInterpretacion.correlacionesEmpiricas = @"Evaluar la presencia de trastornos que involucran pensamientos delirantes. Puede requerir tratamiento hospitalario además de evaluar la necesidad de medicación antipsicótica.";
                    }
                    else if (objInterpretacion.puntuacionT >= 70 && objInterpretacion.puntuacionT <= 79)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican ideas de persecución significativas, como creer que los otros buscan lastimarlo";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"Evaluar la presencia de trastornos que involucran ideación persecutoria";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas no indican manifestación de síntomas alarmantes";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "CR7":
                    if (objInterpretacion.puntuacionT >= 65)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican diversas experiencias emocionales negativas incluyendo ansiedad, enojo y miedo.";
                        objInterpretacion.especificaciones = @"Es inhibido conductualmente debido a sus emociones negativas. Experimenta ideación intrusiva. Tiende a la ira. Reacciona al estrés en forma marcada. Presenta problemas de sueño, incluyendo pesadillas. Se preocupa excesivamente. Se observa rumiacion obsesiva. percibe a los otros como demasiado críticos. es autocritico y propenso a culparse.";
                        objInterpretacion.correlacionesEmpiricas = @"Evaluar la presencia de trastornos relacionados con la ansiedad si la puntuación T es mayor o igual a 80";
                    }
                    else if (objInterpretacion.puntuacionT >= 40 && objInterpretacion.puntuacionT <= 64)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel de experiencias emocionales negativas promedio.";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel de experiencias emocionales negativas por debajo del promedio.";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "CR8":
                    if (objInterpretacion.puntuacionT >= 75)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un gran numero de pensamientos y percepciones inusuales.";
                        objInterpretacion.especificaciones = @"Las experiencias inusuales pueden incluir alucinaciones auditivas y/o visuales, así como ideas delirantes de persecución como la telepatía y la lectura de la mente. La prueba de la realidad puede estar significativamente dañada. Experimenta un deterioro significativo en su funcionamiento ocupacional e interpersonal.";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas CR1,QDC Y QNEU si sus puntuaciones T sin iguales o mayores a 65, pues esto implica que las experiencias aberrantes puedan incluir ilusiones somáticas; si la escala ABS tiene puntuación T mayor o igual a 65 implica que las experiencias aberrantes puedan ser inducidas por sustancias.";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 74)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican diversos pensamientos y procesos perceptuales inusuales.";
                        objInterpretacion.especificaciones = @"Experimenta desorganización del pensamiento. Emplea un pensamiento no realista. Cree que tiene habilidades perceptuales-sensoriales poco comunes.";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con las escalas CR1,QDC Y QNEU si sus puntuaciones T sin iguales o mayores a 65, pues esto implica que las experiencias aberrantes puedan incluir ilusiones somáticas; si la escala ABS tiene puntuación T mayor o igual a 65 implica que las experiencias aberrantes puedan ser inducidas por sustancias.";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "CR9":
                    if (objInterpretacion.puntuacionT >= 75)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel de activación y compromiso con su ambiente considerablemente por arriba del promedio";
                        objInterpretacion.especificaciones = @"Es inquieto y se aburre fácilmente. Presenta sobreactividad que se manifiesta en: un pobre control de impulsos, agresión, inestabilidad de humor, euforia, excitabilidad, búsqueda de sensaciones, toma de riesgos y otras formas de conducta poco controladas, muestra características de personalidad narcisista, puede tener una historia de síntomas asociados con episodios maniacos e hipomaniacos";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con la escala CR6 y CR8 si sus puntaciones T son mayor o igual que 70, ya que esto implicaría un posible trastorno socio afectivo. también es necesario evaluar la presencia de: trastornos cíclicos de humor, episodios maniacos o hipomaniacos.";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 74)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel de activación y compromiso con su ambiente por arriba del promedio.";
                        objInterpretacion.especificaciones = @"Es inquieto y se aburre fácilmente. Presenta sobreactividad que se manifiesta en: un pobre control de impulsos, agresión, inestabilidad de humor, euforia, excitabilidad, búsqueda de sensaciones, toma de riesgos y otras formas de conducta poco controladas, muestra características de personalidad narcisista, puede tener una historia de síntomas asociados con episodios maniacos e hipomaniacos";
                        objInterpretacion.correlacionesEmpiricas = @"Evaluar la presencia de trastornos de personalidad narcisista.";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un nivel de activación y compromiso con el ambiente por debajo del promedio";
                        objInterpretacion.especificaciones = @"Tiene un nivel muy bajo de energía. Esta poco comprometido con el ambiente.";
                        objInterpretacion.correlacionesEmpiricas = @"Ninguna";
                    }
                    break;
                #endregion
                #region Somaticas/Cognitivas
                case "MAL":
                    if (objInterpretacion.puntuacionT >= 80)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un sentimiento general de malestar manifestado en mala salud y sentimiento de debilidad, cansancio e incapacidad.";
                        objInterpretacion.especificaciones = @"Se preocupa por su mal salud. Propenso a quejarse de: dificultades en el sueño, fatiga, poca energía, disfunción sexual.";
                        objInterpretacion.correlacionesEmpiricas = @"Si se descarta el origen físico del malestar, evaluar la posibilidad de trastorno somato forme";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 79)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican la experiencia de mala salud y sentimientos de debilidad o cansancio";
                        objInterpretacion.especificaciones = @"Se preocupa por su mal salud. Propenso a quejarse de: dificultades en el sueño, fatiga, poca energía, disfunción sexual.";
                        objInterpretacion.correlacionesEmpiricas = @"Si se descarta el origen físico del malestar, evaluar la posibilidad de trastorno somato forme";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un sentido generalizado de bienestar físico";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "QGI":
                    if (objInterpretacion.puntuacionT >= 90)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un gran numero de quejas gastrointestinales como el mal apetito, vomito y dolores de estomago recurrentes.";
                        objInterpretacion.especificaciones = @"Tiene una historia de problemas gastrointestinales. Esta preocupado por problemas de salud";
                        objInterpretacion.correlacionesEmpiricas = @"Si se descarta el origen físico de las quejas gastrointestinales, evaluar la posibilidad de trastorno somato morfo.";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 89)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un numero significativo de quejas gastrointestinales";
                        objInterpretacion.especificaciones = @"Tiene una historia de problemas gastrointestinales. Esta preocupado por problemas de salud";
                        objInterpretacion.correlacionesEmpiricas = @"Si se descarta el origen físico de las quejas gastrointestinales, evaluar la posibilidad de trastorno somato morfo.";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"las respuestas no manifiesta síntomas alarmantes";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "QDC":
                    if (objInterpretacion.puntuacionT >= 80)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican dolores difusos de cabeza y cuello, jaquecas recurrentes y presencia de dolores de cabeza cuando la persona se altera";
                        objInterpretacion.especificaciones = @"Presenta múltiples quejas somáticas, tiende a desarrollar síntomas físicos como respuesta al estrés. Se preocupa por problemas físicos de salud. Se queja de: dolores de cabeza, dolor crónico, dificultad para concentrarse.";
                        objInterpretacion.correlacionesEmpiricas = @"Si se ha descartado el origen físico del dolor de cabeza, evaluar la presencia de un trastorno somato formo.";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 79)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican dolores de cabeza";
                        objInterpretacion.especificaciones = @"Presenta múltiples quejas somáticas, tiende a desarrollar síntomas físicos como respuesta al estrés. Se preocupa por problemas físicos de salud. Se queja de: dolores de cabeza, dolor crónico, dificultad para concentrarse.";
                        objInterpretacion.correlacionesEmpiricas = @"Si se ha descartado el origen físico del dolor de cabeza, evaluar la presencia de un trastorno somato formo.";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas no manifiestan síntomas alarmantes";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "QNEU":
                    if (objInterpretacion.puntuacionT >= 92)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un gran numero de quejas neurológicas diversas (mareos, perdida de equilibrio, insensibilidad, debilidad y parálisis, así como perdida de control sobre el movimiento incluyendo movimientos involuntarios";
                        objInterpretacion.especificaciones = @"Presenta múltiples quejas somáticas, preocupaciones por su salud física. Es propenso a desarrollar síntomas físicos en respuesta al estrés. Es posible que presente: mareos, dificultades en la coordinación y problemas sensoriales.";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con la escalas CR3 y TIM si sus puntaciones T son menor o igual a 39, ya que se podría considerar un posible trastorno de conversión. Si el origen de las quejas neurológicas ha sido descartado, evaluar la presencia de un trastorno somato forme.";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 91)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican quejas neurológicas vagas";
                        objInterpretacion.especificaciones = @"Presenta múltiples quejas somáticas, preocupaciones por su salud física. Es propenso a desarrollar síntomas físicos en respuesta al estrés. Es posible que presente: mareos, dificultades en la coordinación y problemas sensoriales.";
                        objInterpretacion.correlacionesEmpiricas = @"Es necesario realizar una correlación con la escalas CR3 y TIM si sus puntaciones T son menor o igual a 39, ya que se podría considerar un posible trastorno de conversión. Si el origen de las quejas neurológicas ha sido descartado, evaluar la presencia de un trastorno somato forme.";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas no manifiestan síntomas alarmantes";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                case "QCO":
                    if (objInterpretacion.puntuacionT >= 81)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un patrón difuso de dificultades cognitivas incluyendo problemas de memoria, dificultades de concentración, limitaciones intelectuales y confusión";
                        objInterpretacion.especificaciones = @"Quejas por problemas de memoria. Baja tolerancia a la frustración. Experimenta dificultades para concentrarse.";
                        objInterpretacion.correlacionesEmpiricas = @"Ninguna";
                    }
                    else if (objInterpretacion.puntuacionT >= 65 && objInterpretacion.puntuacionT <= 80)
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas indican un patrón difuso de dificultades cognitivas";
                        objInterpretacion.especificaciones = @"Quejas por problemas de memoria. Baja tolerancia a la frustración. Experimenta dificultades para concentrarse.";
                        objInterpretacion.correlacionesEmpiricas = @"Ninguna";
                    }
                    else
                    {
                        objInterpretacion.respuestasALaPrueba = @"Las respuestas no manifiestan síntomas alarmantes";
                        objInterpretacion.especificaciones = @"No manifiesta síntomas alarmantes";
                        objInterpretacion.correlacionesEmpiricas = @"No manifiesta síntomas alarmantes";
                    }
                    break;
                #endregion
                case "ISU":
                    escala.puntuacionT = CalculaT(arrayISU, escala.puntuacionNatural); //Cambio de prueba
                    break;
                case "LM/D":
                    escala.puntuacionT = CalculaT(arrayIMD, escala.puntuacionNatural);
                    break;
                case "DSM":
                    escala.puntuacionT = CalculaT(arrayDSM, escala.puntuacionNatural);
                    break;
                case "INE":
                    escala.puntuacionT = CalculaT(arrayINE, escala.puntuacionNatural);
                    break;
                case "P/E":
                    escala.puntuacionT = CalculaT(arrayPE, escala.puntuacionNatural);
                    break;
                case "ANS":
                    escala.puntuacionT = CalculaT(arrayANS, escala.puntuacionNatural);
                    break;
                case "TEN":
                    escala.puntuacionT = CalculaT(arrayTEN, escala.puntuacionNatural);
                    break;
                case "LCM":
                    escala.puntuacionT = CalculaT(arrayLCM, escala.puntuacionNatural);
                    break;
                case "MEM":
                    escala.puntuacionT = CalculaT(arrayMEM, escala.puntuacionNatural);
                    break;
                case "PCIJ":
                    escala.puntuacionT = CalculaT(arrayPCIJ, escala.puntuacionNatural);
                    break;
                case "ABS":
                    escala.puntuacionT = CalculaT(arrayABS, escala.puntuacionNatural);
                    break;
                case "AG":
                    escala.puntuacionT = CalculaT(arrayAG, escala.puntuacionNatural);
                    break;
                case "EUF":
                    escala.puntuacionT = CalculaT(arrayEUF, escala.puntuacionNatural);
                    break;
                case "PFA":
                    escala.puntuacionT = CalculaT(arrayPFA, escala.puntuacionNatural);
                    break;
                case "PIP":
                    escala.puntuacionT = CalculaT(arrayPIP, escala.puntuacionNatural);
                    break;
                case "ESO":
                    escala.puntuacionT = CalculaT(arrayESO, escala.puntuacionNatural);
                    break;
                case "TIM":
                    escala.puntuacionT = CalculaT(arrayTIM, escala.puntuacionNatural);
                    break;
                case "DES":
                    escala.puntuacionT = CalculaT(arrayDES, escala.puntuacionNatural);
                    break;
                case "IEL":
                    escala.puntuacionT = CalculaT(arrayIEL, escala.puntuacionNatural);
                    break;
                case "IFM":
                    escala.puntuacionT = CalculaT(arrayIFM, escala.puntuacionNatural);
                    break;
                case "AGGR-R":
                    escala.puntuacionT = CalculaT(arrayAGGR, escala.puntuacionNatural);
                    break;
                case "PSYC-R":
                    escala.puntuacionT = CalculaT(arrayPSYC, escala.puntuacionNatural);
                    break;
                case "DISC-R":
                    escala.puntuacionT = CalculaT(arrayDISC, escala.puntuacionNatural);
                    break;
                case "NEGE-R":
                    escala.puntuacionT = CalculaT(arrayNEGE, escala.puntuacionNatural);
                    break;
                case "INTR-R":
                    escala.puntuacionT = CalculaT(arrayINTR, escala.puntuacionNatural);
                    break;
            }
        }
    }
}

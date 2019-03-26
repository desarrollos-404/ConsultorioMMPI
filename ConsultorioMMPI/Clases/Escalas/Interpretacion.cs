using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases.Escalas
{
  public  class Interpretacion : Escala
    {
        public Interpretacion()
        {
            descripcion = string.Empty;
            significado = string.Empty;
            siglas = string.Empty;
            puntuacionNatural = 0;
            puntuacionT = 0;
            respuestasALaPrueba = string.Empty;
            especificaciones = string.Empty;
            correlacionesEmpiricas = string.Empty;
        }
        public string respuestasALaPrueba { get; set; }
        public string especificaciones { get; set; }
        public string correlacionesEmpiricas { get; set; }
    }
}

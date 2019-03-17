using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases.Escalas
{
    public class Escala
    {
        public Escala()
        {
            descripcion = string.Empty;
            significado = string.Empty;
            siglas = string.Empty;
            puntuacionNatural = 0;
            puntuacionT = 0;
        }
        

        public string descripcion { get; set; }
        public string significado { get; set; }
        public string siglas { get; set; }
        
        public int puntuacionNatural { get; set; }
        public int puntuacionT { get; set; }
        
        
    }
}

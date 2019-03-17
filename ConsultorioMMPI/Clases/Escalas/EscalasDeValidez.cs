using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases.Escalas
{

    public class EscalasDeValidez
    {
        public List<Escala> lstEscalas { get; set; }       
        public EscalasDeValidez()
        {
            lstEscalas = new List<Escala>();
        }
    }
}

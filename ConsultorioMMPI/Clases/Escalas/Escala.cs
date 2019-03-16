using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases.Escalas
{
    public class Escala
    {
        private int[] arrayINVAR = new int[] {
        29,
34,
38,
43,
48,
53,
58,
63,
68,
73,
78,
83,
88,
93,
98,
103,
108,
113,
118,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
120,
       };
        public string descripcion { get; set; }
        public string significado { get; set; }
        public string siglas { get; set; }
        public int puntuacionNatural { get; set; }
        private int pT { get; set; }
        public int puntuacionT
        {
            get
            {
                switch (this.siglas)
                {
                    case "INVAR":
                        return arrayINVAR[puntuacionNatural];

                    default:
                        return 0;
                };
            }
            set { pT = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases.Escalas
{

    public class EscalasDeValidez
    {
        public Escala INVAR_R { get; set; }
        public Escala INVER_R { get; set; }
        public Escala F_R { get; set; }
        public Escala FPSI_R { get; set; }
        public Escala FS { get; set; }
        public Escala FVS_R { get; set; }
        public Escala SI { get; set; }
        public Escala L_R { get; set; }
        public Escala K_R { get; set; }

        public EscalasDeValidez()
        {
            INVAR_R = new Escala()
            {
                descripcion = "INCONSISTENCIA EN LAS RESPUESTAS VARIABLES",
                significado = "RESPONDER AL AZAR",
                siglas = "INVAR-R",
                puntuacionNatural = 0,
                puntuacionT = 0
            };
        }
    }
}

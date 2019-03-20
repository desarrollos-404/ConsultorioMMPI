using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases.Escalas
{
    public class RespuestaEscalas
    {
        #region Constructor
        public RespuestaEscalas()
        {
            escalasDeValidez = new EscalasDeValidez();
            escalasDeOrdenSuperior = new EscalasDeValidez();
            escalasDeClinicasReestructuradas = new EscalasDeValidez();
            somaticosCognitivos = new EscalasDeValidez();
            escalasDeProblemasInternalizados = new EscalasDeValidez();
            escalasDeProblemasExternalizados = new EscalasDeValidez();
            escalasDeProblemasInterpersonales = new EscalasDeValidez();
            escalasDeInteresEspecifico = new EscalasDeValidez();
            escalasDePSY_5 = new EscalasDeValidez();
        }
        #endregion

        #region Propiedades
        public EscalasDeValidez escalasDeValidez { get; set; }
        public EscalasDeValidez escalasDeOrdenSuperior { get; set; }
        public EscalasDeValidez escalasDeClinicasReestructuradas { get; set; }
        public EscalasDeValidez somaticosCognitivos { get; set; }
        public EscalasDeValidez escalasDeProblemasInternalizados { get; set; }
        public EscalasDeValidez escalasDeProblemasExternalizados { get; set; }
        public EscalasDeValidez escalasDeProblemasInterpersonales { get; set; }
        public EscalasDeValidez escalasDeInteresEspecifico { get; set; }
        public EscalasDeValidez escalasDePSY_5 { get; set; }
        #endregion
    }
}

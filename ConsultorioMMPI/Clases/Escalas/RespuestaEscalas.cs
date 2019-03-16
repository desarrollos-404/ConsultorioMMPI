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
        }
        #endregion

        #region Propiedades
        public EscalasDeValidez escalasDeValidez { get; set; }
        #endregion
    }
}

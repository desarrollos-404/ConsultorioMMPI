﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ConsultorioMMPI.Clases
{
    [Serializable()]
    public class Pregunta
    {
        [System.Xml.Serialization.XmlElement("Descripcion")]
        public string Descripcion { get; set; }

        [System.Xml.Serialization.XmlElement("idPregunta")]
        public int idPregunta { get; set; }
        public int estado { get; set; }

        public Pregunta()
        {
            Descripcion = string.Empty;
            idPregunta = -1;
            estado = 2;
        }

    }
    [Serializable()]
    //[System.Xml.Serialization.XmlRoot("Cuestionario")]
    public class Cuestionario
    {
        [XmlArray("Preguntas")]
        [XmlArrayItem("Pregunta", typeof(Pregunta))]
        public Pregunta[] Pregunta { get; set; }
    }
}

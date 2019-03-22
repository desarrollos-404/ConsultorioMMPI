using ConsultorioMMPI.Clases;
using ConsultorioMMPI.Clases.Escalas;
using ConsultorioMMPI.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsultorioMMPI
{
    public partial class frmPreguntas : Form
    {
        #region Declaracion de objetos de validacion
        public RespuestaEscalas _puntuacionNatural = new RespuestaEscalas();

        public List<Validacion> VALIDACION_INVAR = new List<Validacion>() {
            new Validacion{pregunta1 = 136,Valor1 = 0,pregunta2 = 6, Valor2 = 1},
            new Validacion{pregunta1 = 257,Valor1 = 0,pregunta2 = 32, Valor2 = 1},
            new Validacion{pregunta1 = 55,Valor1 = 0,pregunta2 = 99, Valor2 = 1},
            new Validacion{pregunta1 = 67,Valor1 = 0,pregunta2 = 278, Valor2 = 1},
            new Validacion{pregunta1 = 93,Valor1 = 0,pregunta2 = 164, Valor2 = 1},
            new Validacion{pregunta1 = 123,Valor1 = 0,pregunta2 = 338, Valor2 = 1},
            new Validacion{pregunta1 = 228,Valor1 = 0,pregunta2 = 158, Valor2 = 1},
            new Validacion{pregunta1 = 331,Valor1 = 0,pregunta2 = 187, Valor2 = 1},
            new Validacion{pregunta1 = 282,Valor1 = 0,pregunta2 = 246, Valor2 = 1},
            new Validacion{pregunta1 = 323,Valor1 = 0,pregunta2 = 8, Valor2 = 1},
            new Validacion{pregunta1 = 35,Valor1 = 0,pregunta2 = 114, Valor2 = 1},
            new Validacion{pregunta1 = 171,Valor1 = 0,pregunta2 = 55, Valor2 = 1},
            new Validacion{pregunta1 = 71,Valor1 = 0,pregunta2 = 264, Valor2 = 1},
            new Validacion{pregunta1 = 164,Valor1 = 0,pregunta2 = 93, Valor2 = 1},
            new Validacion{pregunta1 = 293,Valor1 = 0,pregunta2 = 134, Valor2 = 1},
            new Validacion{pregunta1 = 158,Valor1 = 0,pregunta2 = 261, Valor2 = 1},
            new Validacion{pregunta1 = 233,Valor1 = 0,pregunta2 = 194, Valor2 = 1},
            new Validacion{pregunta1 = 252,Valor1 = 0,pregunta2 = 287, Valor2 = 1},

            new Validacion{pregunta1 = 17,Valor1 = 0,pregunta2 = 94, Valor2 = 1},
            new Validacion{pregunta1 = 40,Valor1 = 0,pregunta2 = 144, Valor2 = 1},
            new Validacion{pregunta1 = 180,Valor1 = 0,pregunta2 = 58, Valor2 = 1},
            new Validacion{pregunta1 = 79,Valor1 = 0,pregunta2 = 289, Valor2 = 1},
            new Validacion{pregunta1 = 144,Valor1 = 0,pregunta2 = 95, Valor2 = 1},
            new Validacion{pregunta1 = 266,Valor1 = 0,pregunta2 = 141, Valor2 = 1},
            new Validacion{pregunta1 = 317,Valor1 = 0,pregunta2 = 165, Valor2 = 1},
            new Validacion{pregunta1 = 245,Valor1 = 0,pregunta2 = 196, Valor2 = 1},
            new Validacion{pregunta1 = 299,Valor1 = 0,pregunta2 = 324, Valor2 = 1},

            new Validacion{pregunta1 = 24,Valor1 = 0,pregunta2 = 319, Valor2 = 1},
            new Validacion{pregunta1 = 44,Valor1 = 0,pregunta2 = 177, Valor2 = 1},
            new Validacion{pregunta1 = 327,Valor1 = 0,pregunta2 = 60, Valor2 = 1},
            new Validacion{pregunta1 = 105,Valor1 = 0,pregunta2 = 83, Valor2 = 1},
            new Validacion{pregunta1 = 108,Valor1 = 0,pregunta2 = 152, Valor2 = 1},
            new Validacion{pregunta1 = 146,Valor1 = 0,pregunta2 = 275, Valor2 = 1},
            new Validacion{pregunta1 = 166,Valor1 = 0,pregunta2 = 207, Valor2 = 1},
            new Validacion{pregunta1 = 260,Valor1 = 0,pregunta2 = 213, Valor2 = 1},
            new Validacion{pregunta1 = 329,Valor1 = 0,pregunta2 = 316, Valor2 = 1},

            new Validacion{pregunta1 = 25,Valor1 = 0,pregunta2 = 174, Valor2 = 1},
            new Validacion{pregunta1 = 177,Valor1 = 0,pregunta2 = 44, Valor2 = 1},
            new Validacion{pregunta1 = 74,Valor1 = 0,pregunta2 = 62, Valor2 = 1},
            new Validacion{pregunta1 = 265,Valor1 = 0,pregunta2 = 88, Valor2 = 1},
            new Validacion{pregunta1 = 152,Valor1 = 0,pregunta2 = 108, Valor2 = 1},
            new Validacion{pregunta1 = 276,Valor1 = 0,pregunta2 = 147, Valor2 = 1},
            new Validacion{pregunta1 = 175,Valor1 = 0,pregunta2 = 291, Valor2 = 1},
            new Validacion{pregunta1 = 267,Valor1 = 0,pregunta2 = 219, Valor2 = 1},
            new Validacion{pregunta1 = 318,Valor1 = 0,pregunta2 = 337, Valor2 = 1},

            new Validacion{pregunta1 = 29,Valor1 = 0,pregunta2 = 116, Valor2 = 1},
            new Validacion{pregunta1 = 47,Valor1 = 0,pregunta2 = 201, Valor2 = 1},
            new Validacion{pregunta1 = 223,Valor1 = 0,pregunta2 = 66, Valor2 = 1},
            new Validacion{pregunta1 = 232,Valor1 = 0,pregunta2 = 89, Valor2 = 1},
            new Validacion{pregunta1 = 303,Valor1 = 0,pregunta2 = 119, Valor2 = 1},
            new Validacion{pregunta1 = 205,Valor1 = 0,pregunta2 = 156, Valor2 = 1},
            new Validacion{pregunta1 = 291,Valor1 = 0,pregunta2 = 175, Valor2 = 1},
            new Validacion{pregunta1 = 302,Valor1 = 0,pregunta2 = 239, Valor2 = 1}
        };

        public List<Validacion> VALIDACION_INVER_V = new List<Validacion>(){
            new Validacion{pregunta1 = 17,Valor1 = 0,pregunta2 = 44, Valor2 = 0},
            new Validacion{pregunta1 = 134,Valor1 = 0,pregunta2 = 248, Valor2 = 0},
            new Validacion{pregunta1 = 30,Valor1 = 0,pregunta2 = 217, Valor2 = 0},
            new Validacion{pregunta1 = 146,Valor1 = 0,pregunta2 = 293, Valor2 = 0},
            new Validacion{pregunta1 = 37,Valor1 = 0,pregunta2 = 222, Valor2 = 0},
            new Validacion{pregunta1 = 158,Valor1 = 0,pregunta2 = 202, Valor2 = 0},
            new Validacion{pregunta1 = 48,Valor1 = 0,pregunta2 = 182, Valor2 = 0},
            new Validacion{pregunta1 = 169,Valor1 = 0,pregunta2 = 282, Valor2 = 0},
            new Validacion{pregunta1 = 57,Valor1 = 0,pregunta2 = 67, Valor2 = 0},
            new Validacion{pregunta1 = 212,Valor1 = 0,pregunta2 = 264, Valor2 = 0},
            new Validacion{pregunta1 = 83,Valor1 = 0,pregunta2 = 120, Valor2 = 0},
            new Validacion{pregunta1 = 234,Valor1 = 0,pregunta2 = 261, Valor2 = 0},
            new Validacion{pregunta1 = 101,Valor1 = 0,pregunta2 = 189, Valor2 = 0},
            new Validacion{pregunta1 = 269,Valor1 = 0,pregunta2 = 314, Valor2 = 0},
            new Validacion{pregunta1 = 109,Valor1 = 0,pregunta2 = 278, Valor2 = 0}
        };
        public List<Validacion> VALIDACION_INVER_F = new List<Validacion>(){
            new Validacion{pregunta1 = 4,Valor1 = 1,pregunta2 = 22, Valor2 = 1},
            new Validacion{pregunta1 = 178,Valor1 = 1,pregunta2 = 221, Valor2 = 1},
            new Validacion{pregunta1 = 44,Valor1 = 1,pregunta2 = 94, Valor2 = 1},
            new Validacion{pregunta1 = 201,Valor1 = 1,pregunta2 = 278, Valor2 = 1},
            new Validacion{pregunta1 = 59,Valor1 = 1,pregunta2 = 306, Valor2 = 1},
            new Validacion{pregunta1 = 261,Valor1 = 1,pregunta2 = 293, Valor2 = 1},
            new Validacion{pregunta1 = 73,Valor1 = 1,pregunta2 = 338, Valor2 = 1},
            new Validacion{pregunta1 = 83,Valor1 = 1,pregunta2 = 158, Valor2 = 1},
            new Validacion{pregunta1 = 108,Valor1 = 1,pregunta2 = 246, Valor2 = 1},
            new Validacion{pregunta1 = 119,Valor1 = 1,pregunta2 = 134, Valor2 = 1},
            new Validacion{pregunta1 = 147,Valor1 = 1,pregunta2 = 319, Valor2 = 1}
        };


        //public List<Validacion> VALIDACION_FR_V = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 14,Valor1 = 0},
        //    new Validacion{pregunta1 = 30,Valor1 = 0},
        //    new Validacion{pregunta1 = 46,Valor1 = 0},
        //    new Validacion{pregunta1 = 56,Valor1 = 0},
        //    new Validacion{pregunta1 = 67,Valor1 = 0},
        //    new Validacion{pregunta1 = 71,Valor1 = 0},
        //    new Validacion{pregunta1 = 74,Valor1 = 0},
        //    new Validacion{pregunta1 = 106,Valor1 = 0},
        //    new Validacion{pregunta1 = 117,Valor1 = 0},
        //    new Validacion{pregunta1 = 120,Valor1 = 0},
        //    new Validacion{pregunta1 = 139,Valor1 = 0},
        //    new Validacion{pregunta1 = 146,Valor1 = 0},
        //    new Validacion{pregunta1 = 164,Valor1 = 0},
        //    new Validacion{pregunta1 = 203,Valor1 = 0},
        //    new Validacion{pregunta1 = 218,Valor1 = 0},
        //    new Validacion{pregunta1 = 231,Valor1 = 0},
        //    new Validacion{pregunta1 = 240,Valor1 = 0},
        //    new Validacion{pregunta1 = 253,Valor1 = 0},
        //    new Validacion{pregunta1 = 264,Valor1 = 0},
        //    new Validacion{pregunta1 = 275,Valor1 = 0},
        //    new Validacion{pregunta1 = 277,Valor1 = 0},
        //    new Validacion{pregunta1 = 281,Valor1 = 0},
        //    new Validacion{pregunta1 = 294,Valor1 = 0},
        //    new Validacion{pregunta1 = 301,Valor1 = 0},
        //    new Validacion{pregunta1 = 310,Valor1 = 0},
        //    new Validacion{pregunta1 = 312,Valor1 = 0},
        //    new Validacion{pregunta1 = 332,Valor1 = 0}
        //};
        //public List<Validacion> VALIDACION_FR_F = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 59,Valor1 = 1},
        //    new Validacion{pregunta1 = 83,Valor1 = 1},
        //    new Validacion{pregunta1 = 102,Valor1 = 1},
        //    new Validacion{pregunta1 = 174,Valor1 = 1},
        //    new Validacion{pregunta1 = 227,Valor1 = 1}
        //};

        public List<Validacion> VALIDACION_FR = new List<Validacion>()
        {
            new Validacion{pregunta1 = 14,Valor1 = 0},
            new Validacion{pregunta1 = 30,Valor1 = 0},
            new Validacion{pregunta1 = 46,Valor1 = 0},
            new Validacion{pregunta1 = 56,Valor1 = 0},
            new Validacion{pregunta1 = 67,Valor1 = 0},
            new Validacion{pregunta1 = 71,Valor1 = 0},
            new Validacion{pregunta1 = 74,Valor1 = 0},
            new Validacion{pregunta1 = 106,Valor1 = 0},
            new Validacion{pregunta1 = 117,Valor1 = 0},
            new Validacion{pregunta1 = 120,Valor1 = 0},
            new Validacion{pregunta1 = 139,Valor1 = 0},
            new Validacion{pregunta1 = 146,Valor1 = 0},
            new Validacion{pregunta1 = 164,Valor1 = 0},
            new Validacion{pregunta1 = 203,Valor1 = 0},
            new Validacion{pregunta1 = 218,Valor1 = 0},
            new Validacion{pregunta1 = 231,Valor1 = 0},
            new Validacion{pregunta1 = 240,Valor1 = 0},
            new Validacion{pregunta1 = 253,Valor1 = 0},
            new Validacion{pregunta1 = 264,Valor1 = 0},
            new Validacion{pregunta1 = 275,Valor1 = 0},
            new Validacion{pregunta1 = 277,Valor1 = 0},
            new Validacion{pregunta1 = 281,Valor1 = 0},
            new Validacion{pregunta1 = 294,Valor1 = 0},
            new Validacion{pregunta1 = 301,Valor1 = 0},
            new Validacion{pregunta1 = 310,Valor1 = 0},
            new Validacion{pregunta1 = 312,Valor1 = 0},
            new Validacion{pregunta1 = 332,Valor1 = 0},
            new Validacion{pregunta1 = 59,Valor1 = 1},
            new Validacion{pregunta1 = 83,Valor1 = 1},
            new Validacion{pregunta1 = 102,Valor1 = 1},
            new Validacion{pregunta1 = 174,Valor1 = 1},
            new Validacion{pregunta1 = 227,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_FPSI = new List<Validacion>()
        {
            new Validacion{pregunta1 = 40,Valor1 = 0},
            new Validacion{pregunta1 = 41,Valor1 = 0},
            new Validacion{pregunta1 = 79,Valor1 = 0},
            new Validacion{pregunta1 = 86,Valor1 = 0},
            new Validacion{pregunta1 = 124,Valor1 = 0},
            new Validacion{pregunta1 = 129,Valor1 = 0},
            new Validacion{pregunta1 = 150,Valor1 = 0},
            new Validacion{pregunta1 = 168,Valor1 = 0},
            new Validacion{pregunta1 = 178,Valor1 = 0},
            new Validacion{pregunta1 = 191,Valor1 = 0},
            new Validacion{pregunta1 = 208,Valor1 = 0},
            new Validacion{pregunta1 = 252,Valor1 = 0},
            new Validacion{pregunta1 = 255,Valor1 = 0},
            new Validacion{pregunta1 = 270,Valor1 = 0},
            new Validacion{pregunta1 = 314,Valor1 = 0},
            new Validacion{pregunta1 = 317,Valor1 = 0},
            new Validacion{pregunta1 = 7,Valor1 = 1},
            new Validacion{pregunta1 = 98,Valor1 = 1},
            new Validacion{pregunta1 = 157,Valor1 = 1},
            new Validacion{pregunta1 = 221,Valor1 = 1},
            new Validacion{pregunta1 = 283,Valor1 = 1}
        };
        //public List<Validacion> VALIDACION_FPSI_V = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 40,Valor1 = 0},
        //    new Validacion{pregunta1 = 41,Valor1 = 0},
        //    new Validacion{pregunta1 = 79,Valor1 = 0},
        //    new Validacion{pregunta1 = 86,Valor1 = 0},
        //    new Validacion{pregunta1 = 124,Valor1 = 0},
        //    new Validacion{pregunta1 = 129,Valor1 = 0},
        //    new Validacion{pregunta1 = 150,Valor1 = 0},
        //    new Validacion{pregunta1 = 168,Valor1 = 0},
        //    new Validacion{pregunta1 = 178,Valor1 = 0},
        //    new Validacion{pregunta1 = 191,Valor1 = 0},
        //    new Validacion{pregunta1 = 208,Valor1 = 0},
        //    new Validacion{pregunta1 = 252,Valor1 = 0},
        //    new Validacion{pregunta1 = 255,Valor1 = 0},
        //    new Validacion{pregunta1 = 270,Valor1 = 0},
        //    new Validacion{pregunta1 = 314,Valor1 = 0},
        //    new Validacion{pregunta1 = 317,Valor1 = 0}
        //};
        //public List<Validacion> VALIDACION_FPSI_F = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 7,Valor1 = 1},
        //    new Validacion{pregunta1 = 98,Valor1 = 1},
        //    new Validacion{pregunta1 = 157,Valor1 = 1},
        //    new Validacion{pregunta1 = 221,Valor1 = 1},
        //    new Validacion{pregunta1 = 283,Valor1 = 1}
        //};
        public List<Validacion> VALIDACION_FS = new List<Validacion>()
        {
            new Validacion{pregunta1 = 15,Valor1 = 0},
            new Validacion{pregunta1 = 33,Valor1 = 0},
            new Validacion{pregunta1 = 43,Valor1 = 0},
            new Validacion{pregunta1 = 122,Valor1 = 0},
            new Validacion{pregunta1 = 133,Valor1 = 0},
            new Validacion{pregunta1 = 137,Valor1 = 0},
            new Validacion{pregunta1 = 159,Valor1 = 0},
            new Validacion{pregunta1 = 170,Valor1 = 0},
            new Validacion{pregunta1 = 199,Valor1 = 0},
            new Validacion{pregunta1 = 216,Valor1 = 0},
            new Validacion{pregunta1 = 225,Valor1 = 0},
            new Validacion{pregunta1 = 308,Valor1 = 0},
            new Validacion{pregunta1 = 2,Valor1 = 1},
            new Validacion{pregunta1 = 78,Valor1 = 1},
            new Validacion{pregunta1 = 186,Valor1 = 1},
            new Validacion{pregunta1 = 272,Valor1 = 1}
        };

        //public List<Validacion> VALIDACION_FS_V = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 15,Valor1 = 0},
        //    new Validacion{pregunta1 = 33,Valor1 = 0},
        //    new Validacion{pregunta1 = 43,Valor1 = 0},
        //    new Validacion{pregunta1 = 122,Valor1 = 0},
        //    new Validacion{pregunta1 = 133,Valor1 = 0},
        //    new Validacion{pregunta1 = 137,Valor1 = 0},
        //    new Validacion{pregunta1 = 159,Valor1 = 0},
        //    new Validacion{pregunta1 = 170,Valor1 = 0},
        //    new Validacion{pregunta1 = 199,Valor1 = 0},
        //    new Validacion{pregunta1 = 216,Valor1 = 0},
        //    new Validacion{pregunta1 = 225,Valor1 = 0},
        //    new Validacion{pregunta1 = 308,Valor1 = 0}
        //};
        //public List<Validacion> VALIDACION_FS_F = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 2,Valor1 = 1},
        //    new Validacion{pregunta1 = 78,Valor1 = 1},
        //    new Validacion{pregunta1 = 186,Valor1 = 1},
        //    new Validacion{pregunta1 = 272,Valor1 = 1}
        //};

        public List<Validacion> VALIDACION_FVS = new List<Validacion>()
        {
            new Validacion{pregunta1 = 6,Valor1 = 0},
            new Validacion{pregunta1 = 15,Valor1 = 0},
            new Validacion{pregunta1 = 43,Valor1 = 0},
            new Validacion{pregunta1 = 76,Valor1 = 0},
            new Validacion{pregunta1 = 77,Valor1 = 0},
            new Validacion{pregunta1 = 79,Valor1 = 0},
            new Validacion{pregunta1 = 93,Valor1 = 0},
            new Validacion{pregunta1 = 101,Valor1 = 0},
            new Validacion{pregunta1 = 133,Valor1 = 0},
            new Validacion{pregunta1 = 187,Valor1 = 0},
            new Validacion{pregunta1 = 200,Valor1 = 0},
            new Validacion{pregunta1 = 210,Valor1 = 0},
            new Validacion{pregunta1 = 230,Valor1 = 0},
            new Validacion{pregunta1 = 247,Valor1 = 0},
            new Validacion{pregunta1 = 261,Valor1 = 0},
            new Validacion{pregunta1 = 315,Valor1 = 0},
            new Validacion{pregunta1 = 36,Valor1 = 1},
            new Validacion{pregunta1 = 45,Valor1 = 1},
            new Validacion{pregunta1 = 55,Valor1 = 1},
            new Validacion{pregunta1 = 88,Valor1 = 1},
            new Validacion{pregunta1 = 99,Valor1 = 1},
            new Validacion{pregunta1 = 141,Valor1 = 1},
            new Validacion{pregunta1 = 156,Valor1 = 1},
            new Validacion{pregunta1 = 162,Valor1 = 1},
            new Validacion{pregunta1 = 171,Valor1 = 1},
            new Validacion{pregunta1 = 189,Valor1 = 1},
            new Validacion{pregunta1 = 193,Valor1 = 1},
            new Validacion{pregunta1 = 234,Valor1 = 1},
            new Validacion{pregunta1 = 265,Valor1 = 1},
            new Validacion{pregunta1 = 290,Valor1 = 1}
        };

        //public List<Validacion> VALIDACION_FVS_V = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 6,Valor1 = 0},
        //    new Validacion{pregunta1 = 15,Valor1 = 0},
        //    new Validacion{pregunta1 = 43,Valor1 = 0},
        //    new Validacion{pregunta1 = 76,Valor1 = 0},
        //    new Validacion{pregunta1 = 77,Valor1 = 0},
        //    new Validacion{pregunta1 = 79,Valor1 = 0},
        //    new Validacion{pregunta1 = 93,Valor1 = 0},
        //    new Validacion{pregunta1 = 101,Valor1 = 0},
        //    new Validacion{pregunta1 = 133,Valor1 = 0},
        //    new Validacion{pregunta1 = 187,Valor1 = 0},
        //    new Validacion{pregunta1 = 200,Valor1 = 0},
        //    new Validacion{pregunta1 = 210,Valor1 = 0},
        //    new Validacion{pregunta1 = 230,Valor1 = 0},
        //    new Validacion{pregunta1 = 247,Valor1 = 0},
        //    new Validacion{pregunta1 = 261,Valor1 = 0},
        //    new Validacion{pregunta1 = 315,Valor1 = 0}
        //};
        //public List<Validacion> VALIDACION_FVS_F = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 36,Valor1 = 1},
        //    new Validacion{pregunta1 = 45,Valor1 = 1},
        //    new Validacion{pregunta1 = 55,Valor1 = 1},
        //    new Validacion{pregunta1 = 88,Valor1 = 1},
        //    new Validacion{pregunta1 = 99,Valor1 = 1},
        //    new Validacion{pregunta1 = 141,Valor1 = 1},
        //    new Validacion{pregunta1 = 156,Valor1 = 1},
        //    new Validacion{pregunta1 = 162,Valor1 = 1},
        //    new Validacion{pregunta1 = 171,Valor1 = 1},
        //    new Validacion{pregunta1 = 189,Valor1 = 1},
        //    new Validacion{pregunta1 = 193,Valor1 = 1},
        //    new Validacion{pregunta1 = 234,Valor1 = 1},
        //    new Validacion{pregunta1 = 265,Valor1 = 1},
        //    new Validacion{pregunta1 = 290,Valor1 = 1}
        //};

        public List<Validacion> VALIDACION_SI = new List<Validacion>()
        {
            new Validacion{pregunta1 = 6,Valor1 = 0},
            new Validacion{pregunta1 = 24,Valor1 = 0},
            new Validacion{pregunta1 = 26,Valor1 = 0},
            new Validacion{pregunta1 = 31,Valor1 = 0},
            new Validacion{pregunta1 = 68,Valor1 = 0},
            new Validacion{pregunta1 = 74,Valor1 = 0},
            new Validacion{pregunta1 = 79,Valor1 = 0},
            new Validacion{pregunta1 = 92,Valor1 = 0},
            new Validacion{pregunta1 = 101,Valor1 = 0},
            new Validacion{pregunta1 = 106,Valor1 = 0},
            new Validacion{pregunta1 = 120,Valor1 = 0},
            new Validacion{pregunta1 = 132,Valor1 = 0},
            new Validacion{pregunta1 = 136,Valor1 = 0},
            new Validacion{pregunta1 = 137,Valor1 = 0},
            new Validacion{pregunta1 = 159,Valor1 = 0},
            new Validacion{pregunta1 = 242,Valor1 = 0},
            new Validacion{pregunta1 = 252,Valor1 = 0},
            new Validacion{pregunta1 = 268,Valor1 = 0},
            new Validacion{pregunta1 = 273,Valor1 = 0},
            new Validacion{pregunta1 = 11,Valor1 = 1},
            new Validacion{pregunta1 = 21,Valor1 = 1},
            new Validacion{pregunta1 = 53,Valor1 = 1},
            new Validacion{pregunta1 = 59,Valor1 = 1},
            new Validacion{pregunta1 = 125,Valor1 = 1},
            new Validacion{pregunta1 = 131,Valor1 = 1},
            new Validacion{pregunta1 = 156,Valor1 = 1},
            new Validacion{pregunta1 = 219,Valor1 = 1},
            new Validacion{pregunta1 = 325,Valor1 = 1}
        };
        //public List<Validacion> VALIDACION_SI_V = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 6,Valor1 = 0},
        //    new Validacion{pregunta1 = 24,Valor1 = 0},
        //    new Validacion{pregunta1 = 26,Valor1 = 0},
        //    new Validacion{pregunta1 = 31,Valor1 = 0},
        //    new Validacion{pregunta1 = 68,Valor1 = 0},
        //    new Validacion{pregunta1 = 74,Valor1 = 0},
        //    new Validacion{pregunta1 = 79,Valor1 = 0},
        //    new Validacion{pregunta1 = 92,Valor1 = 0},
        //    new Validacion{pregunta1 = 101,Valor1 = 0},
        //    new Validacion{pregunta1 = 106,Valor1 = 0},
        //    new Validacion{pregunta1 = 120,Valor1 = 0},
        //    new Validacion{pregunta1 = 132,Valor1 = 0},
        //    new Validacion{pregunta1 = 136,Valor1 = 0},
        //    new Validacion{pregunta1 = 137,Valor1 = 0},
        //    new Validacion{pregunta1 = 159,Valor1 = 0},
        //    new Validacion{pregunta1 = 242,Valor1 = 0},
        //    new Validacion{pregunta1 = 252,Valor1 = 0},
        //    new Validacion{pregunta1 = 268,Valor1 = 0},
        //    new Validacion{pregunta1 = 273,Valor1 = 0}
        //};
        //public List<Validacion> VALIDACION_SI_F = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 11,Valor1 = 1},
        //    new Validacion{pregunta1 = 21,Valor1 = 1},
        //    new Validacion{pregunta1 = 53,Valor1 = 1},
        //    new Validacion{pregunta1 = 59,Valor1 = 1},
        //    new Validacion{pregunta1 = 125,Valor1 = 1},
        //    new Validacion{pregunta1 = 131,Valor1 = 1},
        //    new Validacion{pregunta1 = 156,Valor1 = 1},
        //    new Validacion{pregunta1 = 219,Valor1 = 1},
        //    new Validacion{pregunta1 = 325,Valor1 = 1}
        //};


        public List<Validacion> VALIDACION_LR = new List<Validacion>()
        {
            new Validacion{pregunta1 = 61,Valor1 = 0},
            new Validacion{pregunta1 = 182,Valor1 = 0},
            new Validacion{pregunta1 = 268,Valor1 = 0},
            new Validacion{pregunta1 = 16,Valor1 = 1},
            new Validacion{pregunta1 = 45,Valor1 = 1},
            new Validacion{pregunta1 = 70,Valor1 = 1},
            new Validacion{pregunta1 = 95,Valor1 = 1},
            new Validacion{pregunta1 = 127,Valor1 = 1},
            new Validacion{pregunta1 = 154,Valor1 = 1},
            new Validacion{pregunta1 = 183,Valor1 = 1},
            new Validacion{pregunta1 = 211,Valor1 = 1},
            new Validacion{pregunta1 = 241,Valor1 = 1},
            new Validacion{pregunta1 = 298,Valor1 = 1},
            new Validacion{pregunta1 = 325,Valor1 = 1},
        };

        //public List<Validacion> VALIDACION_LR_V = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 61,Valor1 = 0},
        //    new Validacion{pregunta1 = 182,Valor1 = 0},
        //    new Validacion{pregunta1 = 268,Valor1 = 0}
        //};
        //public List<Validacion> VALIDACION_LR_F = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 16,Valor1 = 1},
        //    new Validacion{pregunta1 = 45,Valor1 = 1},
        //    new Validacion{pregunta1 = 70,Valor1 = 1},
        //    new Validacion{pregunta1 = 95,Valor1 = 1},
        //    new Validacion{pregunta1 = 127,Valor1 = 1},
        //    new Validacion{pregunta1 = 154,Valor1 = 1},
        //    new Validacion{pregunta1 = 183,Valor1 = 1},
        //    new Validacion{pregunta1 = 211,Valor1 = 1},
        //    new Validacion{pregunta1 = 241,Valor1 = 1},
        //    new Validacion{pregunta1 = 298,Valor1 = 1},
        //    new Validacion{pregunta1 = 325,Valor1 = 1},
        //};
        public List<Validacion> VALIDACION_KR = new List<Validacion>()
        {
            new Validacion{pregunta1 = 80,Valor1 = 0},
            new Validacion{pregunta1 = 202,Valor1 = 0},
            new Validacion{pregunta1 = 10,Valor1 = 1},
            new Validacion{pregunta1 = 23,Valor1 = 1},
            new Validacion{pregunta1 = 36,Valor1 = 1},
            new Validacion{pregunta1 = 44,Valor1 = 1},
            new Validacion{pregunta1 = 72,Valor1 = 1},
            new Validacion{pregunta1 = 89,Valor1 = 1},
            new Validacion{pregunta1 = 99,Valor1 = 1},
            new Validacion{pregunta1 = 155,Valor1 = 1},
            new Validacion{pregunta1 = 171,Valor1 = 1},
            new Validacion{pregunta1 = 187,Valor1 = 1},
            new Validacion{pregunta1 = 322,Valor1 = 1},
            new Validacion{pregunta1 = 338,Valor1 = 1}
        };

        //public List<Validacion> VALIDACION_KR_V = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 80,Valor1 = 0},
        //    new Validacion{pregunta1 = 202,Valor1 = 0}
        //};
        //public List<Validacion> VALIDACION_KR_F = new List<Validacion>()
        //{
        //    new Validacion{pregunta1 = 10,Valor1 = 1},
        //    new Validacion{pregunta1 = 23,Valor1 = 1},
        //    new Validacion{pregunta1 = 36,Valor1 = 1},
        //    new Validacion{pregunta1 = 44,Valor1 = 1},
        //    new Validacion{pregunta1 = 72,Valor1 = 1},
        //    new Validacion{pregunta1 = 89,Valor1 = 1},
        //    new Validacion{pregunta1 = 99,Valor1 = 1},
        //    new Validacion{pregunta1 = 155,Valor1 = 1},
        //    new Validacion{pregunta1 = 171,Valor1 = 1},
        //    new Validacion{pregunta1 = 187,Valor1 = 1},
        //    new Validacion{pregunta1 = 322,Valor1 = 1},
        //    new Validacion{pregunta1 = 338,Valor1 = 1}
        //};

        //Escalas de orden superior

        public List<Validacion> VALIDACION_AEPI = new List<Validacion>()
        {
            new Validacion{pregunta1 = 22,Valor1 = 0},
            new Validacion{pregunta1 = 30,Valor1 = 0},
            new Validacion{pregunta1 = 35,Valor1 = 0},
            new Validacion{pregunta1 = 48,Valor1 = 0},
            new Validacion{pregunta1 = 89,Valor1 = 0},
            new Validacion{pregunta1 = 91,Valor1 = 0},
            new Validacion{pregunta1 = 114,Valor1 = 0},
            new Validacion{pregunta1 = 119,Valor1 = 0},
            new Validacion{pregunta1 = 120,Valor1 = 0},
            new Validacion{pregunta1 = 158,Valor1 = 0},
            new Validacion{pregunta1 = 167,Valor1 = 0},
            new Validacion{pregunta1 = 169,Valor1 = 0},
            new Validacion{pregunta1 = 172,Valor1 = 0},
            new Validacion{pregunta1 = 187,Valor1 = 0},
            new Validacion{pregunta1 = 204,Valor1 = 0},
            new Validacion{pregunta1 = 228,Valor1 = 0},
            new Validacion{pregunta1 = 232,Valor1 = 0},
            new Validacion{pregunta1 = 250,Valor1 = 0},
            new Validacion{pregunta1 = 261,Valor1 = 0},
            new Validacion{pregunta1 = 288,Valor1 = 0},
            new Validacion{pregunta1 = 322,Valor1 = 0},
            new Validacion{pregunta1 = 331,Valor1 = 0},
            new Validacion{pregunta1 = 335,Valor1 = 0},
            new Validacion{pregunta1 = 4,Valor1 = 1},
            new Validacion{pregunta1 = 17,Valor1 = 1},
            new Validacion{pregunta1 = 25,Valor1 = 1},
            new Validacion{pregunta1 = 37,Valor1 = 1},
            new Validacion{pregunta1 = 57,Valor1 = 1},
            new Validacion{pregunta1 = 64,Valor1 = 1},
            new Validacion{pregunta1 = 73,Valor1 = 1},
            new Validacion{pregunta1 = 83,Valor1 = 1},
            new Validacion{pregunta1 = 102,Valor1 = 1},
            new Validacion{pregunta1 = 105,Valor1 = 1},
            new Validacion{pregunta1 = 140,Valor1 = 1},
            new Validacion{pregunta1 = 202,Valor1 = 1},
            new Validacion{pregunta1 = 217,Valor1 = 1},
            new Validacion{pregunta1 = 222,Valor1 = 1},
            new Validacion{pregunta1 = 234,Valor1 = 1},
            new Validacion{pregunta1 = 246,Valor1 = 1},
            new Validacion{pregunta1 = 282,Valor1 = 1},
            new Validacion{pregunta1 = 293,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_AP = new List<Validacion>()
        {
            new Validacion{pregunta1 = 12,Valor1 = 0},
            new Validacion{pregunta1 = 14,Valor1 = 0},
            new Validacion{pregunta1 = 46,Valor1 = 0},
            new Validacion{pregunta1 = 71,Valor1 = 0},
            new Validacion{pregunta1 = 92,Valor1 = 0},
            new Validacion{pregunta1 = 110,Valor1 = 0},
            new Validacion{pregunta1 = 122,Valor1 = 0},
            new Validacion{pregunta1 = 129,Valor1 = 0},
            new Validacion{pregunta1 = 139,Valor1 = 0},
            new Validacion{pregunta1 = 150,Valor1 = 0},
            new Validacion{pregunta1 = 168,Valor1 = 0},
            new Validacion{pregunta1 = 179,Valor1 = 0},
            new Validacion{pregunta1 = 199,Valor1 = 0},
            new Validacion{pregunta1 = 203,Valor1 = 0},
            new Validacion{pregunta1 = 216,Valor1 = 0},
            new Validacion{pregunta1 = 252,Valor1 = 0},
            new Validacion{pregunta1 = 264,Valor1 = 0},
            new Validacion{pregunta1 = 273,Valor1 = 0},
            new Validacion{pregunta1 = 287,Valor1 = 0},
            new Validacion{pregunta1 = 294,Valor1 = 0},
            new Validacion{pregunta1 = 311,Valor1 = 0},
            new Validacion{pregunta1 = 330,Valor1 = 0},
            new Validacion{pregunta1 = 332,Valor1 = 0},
            new Validacion{pregunta1 = 85,Valor1 = 1},
            new Validacion{pregunta1 = 212,Valor1 = 1},
        };
        public List<Validacion> VALIDACION_ACPE = new List<Validacion>()
        {
            new Validacion{pregunta1 = 21,Valor1 = 0},
            new Validacion{pregunta1 = 49,Valor1 = 0},
            new Validacion{pregunta1 = 66,Valor1 = 0},
            new Validacion{pregunta1 = 84,Valor1 = 0},
            new Validacion{pregunta1 = 96,Valor1 = 0},
            new Validacion{pregunta1 = 107,Valor1 = 0},
            new Validacion{pregunta1 = 131,Valor1 = 0},
            new Validacion{pregunta1 = 156,Valor1 = 0},
            new Validacion{pregunta1 = 193,Valor1 = 0},
            new Validacion{pregunta1 = 205,Valor1 = 0},
            new Validacion{pregunta1 = 223,Valor1 = 0},
            new Validacion{pregunta1 = 226,Valor1 = 0},
            new Validacion{pregunta1 = 231,Valor1 = 0},
            new Validacion{pregunta1 = 248,Valor1 = 0},
            new Validacion{pregunta1 = 253,Valor1 = 0},
            new Validacion{pregunta1 = 266,Valor1 = 0},
            new Validacion{pregunta1 = 292,Valor1 = 0},
            new Validacion{pregunta1 = 312,Valor1 = 0},
            new Validacion{pregunta1 = 316,Valor1 = 0},
            new Validacion{pregunta1 = 329,Valor1 = 0},
            new Validacion{pregunta1 = 61,Valor1 = 1},
            new Validacion{pregunta1 = 190,Valor1 = 1},
            new Validacion{pregunta1 = 237,Valor1 = 1}
        };

        //Escalas clinicas reestructuradas
        public List<Validacion> VALIDACION_CRD = new List<Validacion>()
        {
            new Validacion{pregunta1 = 6,Valor1 = 0},
            new Validacion{pregunta1 = 22,Valor1 = 0},
            new Validacion{pregunta1 = 30,Valor1 = 0},
            new Validacion{pregunta1 = 48,Valor1 = 0},
            new Validacion{pregunta1 = 62,Valor1 = 0},
            new Validacion{pregunta1 = 74,Valor1 = 0},
            new Validacion{pregunta1 = 89,Valor1 = 0},
            new Validacion{pregunta1 = 117,Valor1 = 0},
            new Validacion{pregunta1 = 130,Valor1 = 0},
            new Validacion{pregunta1 = 144,Valor1 = 0},
            new Validacion{pregunta1 = 158,Valor1 = 0},
            new Validacion{pregunta1 = 172,Valor1 = 0},
            new Validacion{pregunta1 = 187,Valor1 = 0},
            new Validacion{pregunta1 = 204,Valor1 = 0},
            new Validacion{pregunta1 = 232,Valor1 = 0},
            new Validacion{pregunta1 = 247,Valor1 = 0},
            new Validacion{pregunta1 = 261,Valor1 = 0},
            new Validacion{pregunta1 = 274,Valor1 = 0},
            new Validacion{pregunta1 = 288,Valor1 = 0},
            new Validacion{pregunta1 = 299,Valor1 = 0},
            new Validacion{pregunta1 = 315,Valor1 = 0},
            new Validacion{pregunta1 = 331,Valor1 = 0},
            new Validacion{pregunta1 = 105,Valor1 = 1},
            new Validacion{pregunta1 = 217,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_CR1 = new List<Validacion>()
        {
            new Validacion{pregunta1 = 15,Valor1 = 0},
            new Validacion{pregunta1 = 43,Valor1 = 0},
            new Validacion{pregunta1 = 76,Valor1 = 0},
            new Validacion{pregunta1 = 101,Valor1 = 0},
            new Validacion{pregunta1 = 137,Valor1 = 0},
            new Validacion{pregunta1 = 176,Valor1 = 0},
            new Validacion{pregunta1 = 230,Valor1 = 0},
            new Validacion{pregunta1 = 242,Valor1 = 0},
            new Validacion{pregunta1 = 277,Valor1 = 0},
            new Validacion{pregunta1 = 301,Valor1 = 0},
            new Validacion{pregunta1 = 328,Valor1 = 0},
            new Validacion{pregunta1 = 2,Valor1 = 1},
            new Validacion{pregunta1 = 28,Valor1 = 1},
            new Validacion{pregunta1 = 52,Valor1 = 1},
            new Validacion{pregunta1 = 65,Valor1 = 1},
            new Validacion{pregunta1 = 69,Valor1 = 1},
            new Validacion{pregunta1 = 88,Valor1 = 1},
            new Validacion{pregunta1 = 113,Valor1 = 1},
            new Validacion{pregunta1 = 125,Valor1 = 1},
            new Validacion{pregunta1 = 162,Valor1 = 1},
            new Validacion{pregunta1 = 174,Valor1 = 1},
            new Validacion{pregunta1 = 189,Valor1 = 1},
            new Validacion{pregunta1 = 227,Valor1 = 1},
            new Validacion{pregunta1 = 254,Valor1 = 1},
            new Validacion{pregunta1 = 265,Valor1 = 1},
            new Validacion{pregunta1 = 290,Valor1 = 1},
            new Validacion{pregunta1 = 313,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_CR2 = new List<Validacion>()
        {
            new Validacion{pregunta1 = 4,Valor1 = 1},
            new Validacion{pregunta1 = 17,Valor1 = 1},
            new Validacion{pregunta1 = 25,Valor1 = 1},
            new Validacion{pregunta1 = 53,Valor1 = 1},
            new Validacion{pregunta1 = 64,Valor1 = 1},
            new Validacion{pregunta1 = 83,Valor1 = 1},
            new Validacion{pregunta1 = 102,Valor1 = 1},
            new Validacion{pregunta1 = 140,Valor1 = 1},
            new Validacion{pregunta1 = 160,Valor1 = 1},
            new Validacion{pregunta1 = 182,Valor1 = 1},
            new Validacion{pregunta1 = 195,Valor1 = 1},
            new Validacion{pregunta1 = 202,Valor1 = 1},
            new Validacion{pregunta1 = 222,Valor1 = 1},
            new Validacion{pregunta1 = 246,Valor1 = 1},
            new Validacion{pregunta1 = 282,Valor1 = 1},
            new Validacion{pregunta1 = 302,Valor1 = 1},
            new Validacion{pregunta1 = 323,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_CR3 = new List<Validacion>()
        {
            new Validacion{pregunta1 = 10,Valor1 = 0},
            new Validacion{pregunta1 = 36,Valor1 = 0},
            new Validacion{pregunta1 = 55,Valor1 = 0},
            new Validacion{pregunta1 = 87,Valor1 = 0},
            new Validacion{pregunta1 = 99,Valor1 = 0},
            new Validacion{pregunta1 = 121,Valor1 = 0},
            new Validacion{pregunta1 = 142,Valor1 = 0},
            new Validacion{pregunta1 = 171,Valor1 = 0},
            new Validacion{pregunta1 = 185,Valor1 = 0},
            new Validacion{pregunta1 = 213,Valor1 = 0},
            new Validacion{pregunta1 = 238,Valor1 = 0},
            new Validacion{pregunta1 = 260,Valor1 = 0},
            new Validacion{pregunta1 = 279,Valor1 = 0},
            new Validacion{pregunta1 = 304,Valor1 = 0},
            new Validacion{pregunta1 = 326,Valor1 = 0}
        };

        public List<Validacion> VALIDACION_CR4 = new List<Validacion>()
        {
            new Validacion{pregunta1 = 5,Valor1 = 0},
            new Validacion{pregunta1 = 21,Valor1 = 0},
            new Validacion{pregunta1 = 49,Valor1 = 0},
            new Validacion{pregunta1 = 66,Valor1 = 0},
            new Validacion{pregunta1 = 96,Valor1 = 0},
            new Validacion{pregunta1 = 141,Valor1 = 0},
            new Validacion{pregunta1 = 156,Valor1 = 0},
            new Validacion{pregunta1 = 173,Valor1 = 0},
            new Validacion{pregunta1 = 205,Valor1 = 0},
            new Validacion{pregunta1 = 218,Valor1 = 0},
            new Validacion{pregunta1 = 223,Valor1 = 0},
            new Validacion{pregunta1 = 253,Valor1 = 0},
            new Validacion{pregunta1 = 266,Valor1 = 0},
            new Validacion{pregunta1 = 297,Valor1 = 0},
            new Validacion{pregunta1 = 312,Valor1 = 0},
            new Validacion{pregunta1 = 329,Valor1 = 0},
            new Validacion{pregunta1 = 19,Valor1 = 1},
            new Validacion{pregunta1 = 38,Valor1 = 1},
            new Validacion{pregunta1 = 80,Valor1 = 1},
            new Validacion{pregunta1 = 126,Valor1 = 1},
            new Validacion{pregunta1 = 190,Valor1 = 1},
            new Validacion{pregunta1 = 237,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_CR6 = new List<Validacion>()
        {
            new Validacion{pregunta1 = 14,Valor1 = 0},
            new Validacion{pregunta1 = 34,Valor1 = 0},
            new Validacion{pregunta1 = 71,Valor1 = 0},
            new Validacion{pregunta1 = 92,Valor1 = 0},
            new Validacion{pregunta1 = 110,Valor1 = 0},
            new Validacion{pregunta1 = 129,Valor1 = 0},
            new Validacion{pregunta1 = 150,Valor1 = 0},
            new Validacion{pregunta1 = 168,Valor1 = 0},
            new Validacion{pregunta1 = 194,Valor1 = 0},
            new Validacion{pregunta1 = 233,Valor1 = 0},
            new Validacion{pregunta1 = 252,Valor1 = 0},
            new Validacion{pregunta1 = 264,Valor1 = 0},
            new Validacion{pregunta1 = 270,Valor1 = 0},
            new Validacion{pregunta1 = 287,Valor1 = 0},
            new Validacion{pregunta1 = 310,Valor1 = 0},
            new Validacion{pregunta1 = 332,Valor1 = 0},
            new Validacion{pregunta1 = 212,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_CR7 = new List<Validacion>()
        {
            new Validacion{pregunta1 = 9,Valor1 = 0},
            new Validacion{pregunta1 = 23,Valor1 = 0},
            new Validacion{pregunta1 = 35,Valor1 = 0},
            new Validacion{pregunta1 = 51,Valor1 = 0},
            new Validacion{pregunta1 = 63,Valor1 = 0},
            new Validacion{pregunta1 = 77,Valor1 = 0},
            new Validacion{pregunta1 = 91,Valor1 = 0},
            new Validacion{pregunta1 = 112,Valor1 = 0},
            new Validacion{pregunta1 = 119,Valor1 = 0},
            new Validacion{pregunta1 = 132,Valor1 = 0},
            new Validacion{pregunta1 = 146,Valor1 = 0},
            new Validacion{pregunta1 = 149,Valor1 = 0},
            new Validacion{pregunta1 = 161,Valor1 = 0},
            new Validacion{pregunta1 = 206,Valor1 = 0},
            new Validacion{pregunta1 = 228,Valor1 = 0},
            new Validacion{pregunta1 = 235,Valor1 = 0},
            new Validacion{pregunta1 = 250,Valor1 = 0},
            new Validacion{pregunta1 = 263,Valor1 = 0},
            new Validacion{pregunta1 = 275,Valor1 = 0},
            new Validacion{pregunta1 = 289,Valor1 = 0},
            new Validacion{pregunta1 = 303,Valor1 = 0},
            new Validacion{pregunta1 = 318,Valor1 = 0},
            new Validacion{pregunta1 = 322,Valor1 = 0},
            new Validacion{pregunta1 = 335,Valor1 = 0}
        };

        public List<Validacion> VALIDACION_CR8 = new List<Validacion>()
        {
            new Validacion{pregunta1 = 12,Valor1 = 0},
            new Validacion{pregunta1 = 32,Valor1 = 0},
            new Validacion{pregunta1 = 46,Valor1 = 0},
            new Validacion{pregunta1 = 106,Valor1 = 0},
            new Validacion{pregunta1 = 122,Valor1 = 0},
            new Validacion{pregunta1 = 139,Valor1 = 0},
            new Validacion{pregunta1 = 159,Valor1 = 0},
            new Validacion{pregunta1 = 179,Valor1 = 0},
            new Validacion{pregunta1 = 199,Valor1 = 0},
            new Validacion{pregunta1 = 203,Valor1 = 0},
            new Validacion{pregunta1 = 216,Valor1 = 0},
            new Validacion{pregunta1 = 240,Valor1 = 0},
            new Validacion{pregunta1 = 257,Valor1 = 0},
            new Validacion{pregunta1 = 273,Valor1 = 0},
            new Validacion{pregunta1 = 294,Valor1 = 0},
            new Validacion{pregunta1 = 311,Valor1 = 0},
            new Validacion{pregunta1 = 330,Valor1 = 0},
            new Validacion{pregunta1 = 85,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_CR9 = new List<Validacion>()
        {
            new Validacion{pregunta1 = 13,Valor1 = 0},
            new Validacion{pregunta1 = 26,Valor1 = 0},
            new Validacion{pregunta1 = 39,Valor1 = 0},
            new Validacion{pregunta1 = 47,Valor1 = 0},
            new Validacion{pregunta1 = 72,Valor1 = 0},
            new Validacion{pregunta1 = 84,Valor1 = 0},
            new Validacion{pregunta1 = 97,Valor1 = 0},
            new Validacion{pregunta1 = 107,Valor1 = 0},
            new Validacion{pregunta1 = 118,Valor1 = 0},
            new Validacion{pregunta1 = 131,Valor1 = 0},
            new Validacion{pregunta1 = 143,Valor1 = 0},
            new Validacion{pregunta1 = 155,Valor1 = 0},
            new Validacion{pregunta1 = 166,Valor1 = 0},
            new Validacion{pregunta1 = 181,Valor1 = 0},
            new Validacion{pregunta1 = 193,Valor1 = 0},
            new Validacion{pregunta1 = 207,Valor1 = 0},
            new Validacion{pregunta1 = 219,Valor1 = 0},
            new Validacion{pregunta1 = 231,Valor1 = 0},
            new Validacion{pregunta1 = 244,Valor1 = 0},
            new Validacion{pregunta1 = 248,Valor1 = 0},
            new Validacion{pregunta1 = 256,Valor1 = 0},
            new Validacion{pregunta1 = 267,Valor1 = 0},
            new Validacion{pregunta1 = 292,Valor1 = 0},
            new Validacion{pregunta1 = 305,Valor1 = 0},
            new Validacion{pregunta1 = 316,Valor1 = 0},
            new Validacion{pregunta1 = 327,Valor1 = 0},
            new Validacion{pregunta1 = 337,Valor1 = 0},
            new Validacion{pregunta1 = 61,Valor1 = 1}
        };

        //Escalas de problemas especificos
        public List<Validacion> VALIDACION_MAL = new List<Validacion>()
        {
            new Validacion{pregunta1 = 18,Valor1 = 0},
            new Validacion{pregunta1 = 4,Valor1 = 1},
            new Validacion{pregunta1 = 25,Valor1 = 1},
            new Validacion{pregunta1 = 163,Valor1 = 1},
            new Validacion{pregunta1 = 174,Valor1 = 1},
            new Validacion{pregunta1 = 202,Valor1 = 1},
            new Validacion{pregunta1 = 262,Valor1 = 1},
            new Validacion{pregunta1 = 333,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_QGI = new List<Validacion>()
        {
            new Validacion{pregunta1 = 43,Valor1 = 0},
            new Validacion{pregunta1 = 76,Valor1 = 0},
            new Validacion{pregunta1 = 210,Valor1 = 0},
            new Validacion{pregunta1 = 230,Valor1 = 0},
            new Validacion{pregunta1 = 2,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_QDC = new List<Validacion>()
        {
            new Validacion{pregunta1 = 101,Valor1 = 0},
            new Validacion{pregunta1 = 176,Valor1 = 0},
            new Validacion{pregunta1 = 328,Valor1 = 0},
            new Validacion{pregunta1 = 88,Valor1 = 1},
            new Validacion{pregunta1 = 189,Valor1 = 1},
            new Validacion{pregunta1 = 265,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_QNEU = new List<Validacion>()
        {
            new Validacion{pregunta1 = 122,Valor1 = 0},
            new Validacion{pregunta1 = 277,Valor1 = 0},
            new Validacion{pregunta1 = 301,Valor1 = 0},
            new Validacion{pregunta1 = 69,Valor1 = 1},
            new Validacion{pregunta1 = 113,Valor1 = 1},
            new Validacion{pregunta1 = 125,Valor1 = 1},
            new Validacion{pregunta1 = 162,Valor1 = 1},
            new Validacion{pregunta1 = 186,Valor1 = 1},
            new Validacion{pregunta1 = 227,Valor1 = 1},
            new Validacion{pregunta1 = 313,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_QCO = new List<Validacion>()
        {
            new Validacion{pregunta1 = 31,Valor1 = 0},
            new Validacion{pregunta1 = 136,Valor1 = 0},
            new Validacion{pregunta1 = 159,Valor1 = 0},
            new Validacion{pregunta1 = 200,Valor1 = 0},
            new Validacion{pregunta1 = 240,Valor1 = 0},
            new Validacion{pregunta1 = 257,Valor1 = 0},
            new Validacion{pregunta1 = 280,Valor1 = 0},
            new Validacion{pregunta1 = 306,Valor1 = 0},
            new Validacion{pregunta1 = 59,Valor1 = 1},
            new Validacion{pregunta1 = 102,Valor1 = 1}
        };

        //ESCALAS DE PROBLEMAS INTERNALIZADOS

        public List<Validacion> VALIDACION_ISU = new List<Validacion>()
        {
            new Validacion{pregunta1 = 93,Valor1 = 0},
            new Validacion{pregunta1 = 120,Valor1 = 0},
            new Validacion{pregunta1 = 164,Valor1 = 0},
            new Validacion{pregunta1 = 251,Valor1 = 0},
            new Validacion{pregunta1 = 334,Valor1 = 0}
        };

        public List<Validacion> VALIDACION_IMD = new List<Validacion>()
        {
            new Validacion{pregunta1 = 135,Valor1 = 0},
            new Validacion{pregunta1 = 169,Valor1 = 0},
            new Validacion{pregunta1 = 214,Valor1 = 0},
            new Validacion{pregunta1 = 336,Valor1 = 0},
            new Validacion{pregunta1 = 282,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_DSM = new List<Validacion>()
        {
            new Validacion{pregunta1 = 48,Valor1 = 0},
            new Validacion{pregunta1 = 89,Valor1 = 0},
            new Validacion{pregunta1 = 232,Valor1 = 0},
            new Validacion{pregunta1 = 288,Valor1 = 0}
        };

        public List<Validacion> VALIDACION_INE = new List<Validacion>()
        {
            new Validacion{pregunta1 = 27,Valor1 = 0},
            new Validacion{pregunta1 = 68,Valor1 = 0},
            new Validacion{pregunta1 = 108,Valor1 = 0},
            new Validacion{pregunta1 = 152,Valor1 = 0},
            new Validacion{pregunta1 = 198,Valor1 = 0},
            new Validacion{pregunta1 = 229,Valor1 = 0},
            new Validacion{pregunta1 = 271,Valor1 = 0},
            new Validacion{pregunta1 = 274,Valor1 = 0},
            new Validacion{pregunta1 = 324,Valor1 = 0}
        };

        public List<Validacion> VALIDACION_PE = new List<Validacion>()
        {
            new Validacion{pregunta1 = 29,Valor1 = 0},
            new Validacion{pregunta1 = 123,Valor1 = 0},
            new Validacion{pregunta1 = 167,Valor1 = 0},
            new Validacion{pregunta1 = 224,Valor1 = 0},
            new Validacion{pregunta1 = 309,Valor1 = 0},
            new Validacion{pregunta1 = 73,Valor1 = 1},
            new Validacion{pregunta1 = 234,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_ANS = new List<Validacion>()
        {
            new Validacion{pregunta1 = 79,Valor1 = 0},
            new Validacion{pregunta1 = 146,Valor1 = 0},
            new Validacion{pregunta1 = 228,Valor1 = 0},
            new Validacion{pregunta1 = 275,Valor1 = 0},
            new Validacion{pregunta1 = 289,Valor1 = 0}
        };
        public List<Validacion> VALIDACION_TEN = new List<Validacion>()
        {
            new Validacion{pregunta1 = 119,Valor1 = 0},
            new Validacion{pregunta1 = 155,Valor1 = 0},
            new Validacion{pregunta1 = 248,Valor1 = 0},
            new Validacion{pregunta1 = 303,Valor1 = 0},
            new Validacion{pregunta1 = 318,Valor1 = 0},
            new Validacion{pregunta1 = 134,Valor1 = 1},
            new Validacion{pregunta1 = 293,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_LCM = new List<Validacion>()
        {
            new Validacion{pregunta1 = 20,Valor1 = 0},
            new Validacion{pregunta1 = 56,Valor1 = 0},
            new Validacion{pregunta1 = 90,Valor1 = 0},
            new Validacion{pregunta1 = 165,Valor1 = 0},
            new Validacion{pregunta1 = 208,Valor1 = 0},
            new Validacion{pregunta1 = 243,Valor1 = 0},
            new Validacion{pregunta1 = 284,Valor1 = 0},
            new Validacion{pregunta1 = 317,Valor1 = 0},
            new Validacion{pregunta1 = 128,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_MEM = new List<Validacion>()
        {
            new Validacion{pregunta1 = 54,Valor1 = 0},
            new Validacion{pregunta1 = 151,Valor1 = 0},
            new Validacion{pregunta1 = 258,Valor1 = 0},
            new Validacion{pregunta1 = 320,Valor1 = 0},
            new Validacion{pregunta1 = 82,Valor1 = 1},
            new Validacion{pregunta1 = 115,Valor1 = 1},
            new Validacion{pregunta1 = 184,Valor1 = 1},
            new Validacion{pregunta1 = 220,Valor1 = 1},
            new Validacion{pregunta1 = 286,Valor1 = 1}
        };
        //Escalas de problemas externalizados
        public List<Validacion> VALIDACION_PCIJ = new List<Validacion>()
        {
            new Validacion{pregunta1 = 21,Valor1 = 0},
            new Validacion{pregunta1 = 66,Valor1 = 0},
            new Validacion{pregunta1 = 96,Valor1 = 0},
            new Validacion{pregunta1 = 205,Valor1 = 0},
            new Validacion{pregunta1 = 223,Valor1 = 0},
            new Validacion{pregunta1 = 253,Valor1 = 0}
        };

        public List<Validacion> VALIDACION_ABS = new List<Validacion>()
        {
            new Validacion{pregunta1 = 49,Valor1 = 0},
            new Validacion{pregunta1 = 86,Valor1 = 0},
            new Validacion{pregunta1 = 141,Valor1 = 0},
            new Validacion{pregunta1 = 192,Valor1 = 0},
            new Validacion{pregunta1 = 266,Valor1 = 0},
            new Validacion{pregunta1 = 297,Valor1 = 0},
            new Validacion{pregunta1 = 237,Valor1 = 1}
        };
        public List<Validacion> VALIDACION_AG = new List<Validacion>()
        {
            new Validacion{pregunta1 = 23,Valor1 = 0},
            new Validacion{pregunta1 = 26,Valor1 = 0},
            new Validacion{pregunta1 = 41,Valor1 = 0},
            new Validacion{pregunta1 = 84,Valor1 = 0},
            new Validacion{pregunta1 = 231,Valor1 = 0},
            new Validacion{pregunta1 = 312,Valor1 = 0},
            new Validacion{pregunta1 = 316,Valor1 = 0},
            new Validacion{pregunta1 = 329,Valor1 = 0},
            new Validacion{pregunta1 = 337,Valor1 = 0}
        };

        public List<Validacion> VALIDACION_EUF = new List<Validacion>()
        {
            new Validacion{pregunta1 = 72,Valor1 = 0},
            new Validacion{pregunta1 = 81,Valor1 = 0},
            new Validacion{pregunta1 = 166,Valor1 = 0},
            new Validacion{pregunta1 = 181,Valor1 = 0},
            new Validacion{pregunta1 = 207,Valor1 = 0},
            new Validacion{pregunta1 = 219,Valor1 = 0},
            new Validacion{pregunta1 = 267,Valor1 = 0},
            new Validacion{pregunta1 = 285,Valor1 = 0}
        };
        //Escalas de problemas interpersonales
        public List<Validacion> VALIDACION_PFA = new List<Validacion>()
        {
            new Validacion{pregunta1 = 58,Valor1 = 0},
            new Validacion{pregunta1 = 103,Valor1 = 0},
            new Validacion{pregunta1 = 138,Valor1 = 0},
            new Validacion{pregunta1 = 180,Valor1 = 0},
            new Validacion{pregunta1 = 215,Valor1 = 0},
            new Validacion{pregunta1 = 281,Valor1 = 0},
            new Validacion{pregunta1 = 307,Valor1 = 0},
            new Validacion{pregunta1 = 19,Valor1 = 1},
            new Validacion{pregunta1 = 80,Valor1 = 1},
            new Validacion{pregunta1 = 269,Valor1 = 1}
        };
        public List<Validacion> VALIDACION_PIP = new List<Validacion>()
        {
            new Validacion{pregunta1 = 24,Valor1 = 0},
            new Validacion{pregunta1 = 60,Valor1 = 1},
            new Validacion{pregunta1 = 104,Valor1 = 1},
            new Validacion{pregunta1 = 147,Valor1 = 1},
            new Validacion{pregunta1 = 197,Valor1 = 1},
            new Validacion{pregunta1 = 239,Valor1 = 1},
            new Validacion{pregunta1 = 276,Valor1 = 1},
            new Validacion{pregunta1 = 302,Valor1 = 1},
            new Validacion{pregunta1 = 321,Valor1 = 1},
            new Validacion{pregunta1 = 327,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_ESO = new List<Validacion>()
        {
            new Validacion{pregunta1 = 278,Valor1 = 0},
            new Validacion{pregunta1 = 11,Valor1 = 1},
            new Validacion{pregunta1 = 17,Valor1 = 1},
            new Validacion{pregunta1 = 47,Valor1 = 1},
            new Validacion{pregunta1 = 57,Valor1 = 1},
            new Validacion{pregunta1 = 94,Valor1 = 1},
            new Validacion{pregunta1 = 109,Valor1 = 1},
            new Validacion{pregunta1 = 153,Valor1 = 1},
            new Validacion{pregunta1 = 201,Valor1 = 1},
            new Validacion{pregunta1 = 222,Valor1 = 1}
        };
        public List<Validacion> VALIDACION_TIM = new List<Validacion>()
        {
            new Validacion{pregunta1 = 35,Valor1 = 0},
            new Validacion{pregunta1 = 44,Valor1 = 0},
            new Validacion{pregunta1 = 91,Valor1 = 0},
            new Validacion{pregunta1 = 114,Valor1 = 0},
            new Validacion{pregunta1 = 177,Valor1 = 0},
            new Validacion{pregunta1 = 249,Valor1 = 0},
            new Validacion{pregunta1 = 295,Valor1 = 1}
        };
        public List<Validacion> VALIDACION_DES = new List<Validacion>()
        {
            new Validacion{pregunta1 = 67,Valor1 = 0},
            new Validacion{pregunta1 = 124,Valor1 = 0},
            new Validacion{pregunta1 = 175,Valor1 = 0},
            new Validacion{pregunta1 = 236,Valor1 = 0},
            new Validacion{pregunta1 = 291,Valor1 = 0},
            new Validacion{pregunta1 = 8,Valor1 = 1}
        };
        //Escalas de intereses especificos
        public List<Validacion> VALIDACION_IEL = new List<Validacion>()
        {
            new Validacion{pregunta1 = 3,Valor1 = 0},
            new Validacion{pregunta1 = 50,Valor1 = 0},
            new Validacion{pregunta1 = 100,Valor1 = 0},
            new Validacion{pregunta1 = 145,Valor1 = 0},
            new Validacion{pregunta1 = 196,Valor1 = 0},
            new Validacion{pregunta1 = 245,Valor1 = 0},
            new Validacion{pregunta1 = 296,Valor1 = 0}
        };

        public List<Validacion> VALIDACION_IFM = new List<Validacion>()
        {
            new Validacion{pregunta1 = 1,Valor1 = 0},
            new Validacion{pregunta1 = 42,Valor1 = 0},
            new Validacion{pregunta1 = 75,Valor1 = 0},
            new Validacion{pregunta1 = 111,Valor1 = 0},
            new Validacion{pregunta1 = 148,Valor1 = 0},
            new Validacion{pregunta1 = 188,Valor1 = 0},
            new Validacion{pregunta1 = 226,Valor1 = 0},
            new Validacion{pregunta1 = 259,Valor1 = 0},
            new Validacion{pregunta1 = 300,Valor1 = 0}
        };
        //5 escalas de psicopatologia de la personalidad

        public List<Validacion> VALIDACION_AGGR = new List<Validacion>()
        {
            new Validacion{pregunta1 = 26,Valor1 = 0},
            new Validacion{pregunta1 = 39,Valor1 = 0},
            new Validacion{pregunta1 = 84,Valor1 = 0},
            new Validacion{pregunta1 = 104,Valor1 = 0},
            new Validacion{pregunta1 = 147,Valor1 = 0},
            new Validacion{pregunta1 = 182,Valor1 = 0},
            new Validacion{pregunta1 = 197,Valor1 = 0},
            new Validacion{pregunta1 = 231,Valor1 = 0},
            new Validacion{pregunta1 = 239,Valor1 = 0},
            new Validacion{pregunta1 = 256,Valor1 = 0},
            new Validacion{pregunta1 = 276,Valor1 = 0},
            new Validacion{pregunta1 = 302,Valor1 = 0},
            new Validacion{pregunta1 = 316,Valor1 = 0},
            new Validacion{pregunta1 = 321,Valor1 = 0},
            new Validacion{pregunta1 = 327,Valor1 = 0},
            new Validacion{pregunta1 = 329,Valor1 = 0},
            new Validacion{pregunta1 = 24,Valor1 = 1},
            new Validacion{pregunta1 = 319,Valor1 = 1}
        };
        public List<Validacion> VALIDACION_PSYC = new List<Validacion>()
        {
            new Validacion{pregunta1 = 12,Valor1 = 0},
            new Validacion{pregunta1 = 14,Valor1 = 0},
            new Validacion{pregunta1 = 34,Valor1 = 0},
            new Validacion{pregunta1 = 40,Valor1 = 0},
            new Validacion{pregunta1 = 46,Valor1 = 0},
            new Validacion{pregunta1 = 71,Valor1 = 0},
            new Validacion{pregunta1 = 92,Valor1 = 0},
            new Validacion{pregunta1 = 129,Valor1 = 0},
            new Validacion{pregunta1 = 137,Valor1 = 0},
            new Validacion{pregunta1 = 139,Valor1 = 0},
            new Validacion{pregunta1 = 150,Valor1 = 0},
            new Validacion{pregunta1 = 168,Valor1 = 0},
            new Validacion{pregunta1 = 179,Valor1 = 0},
            new Validacion{pregunta1 = 199,Valor1 = 0},
            new Validacion{pregunta1 = 203,Valor1 = 0},
            new Validacion{pregunta1 = 216,Valor1 = 0},
            new Validacion{pregunta1 = 140,Valor1 = 0},
            new Validacion{pregunta1 = 252,Valor1 = 0},
             new Validacion{pregunta1 = 264,Valor1 = 0},
            new Validacion{pregunta1 = 270,Valor1 = 0},
            new Validacion{pregunta1 = 287,Valor1 = 0},
            new Validacion{pregunta1 = 294,Valor1 = 0},
            new Validacion{pregunta1 = 311,Valor1 = 0},
            new Validacion{pregunta1 = 330,Valor1 = 0},
            new Validacion{pregunta1 = 332,Valor1 = 0},
            new Validacion{pregunta1 = 85,Valor1 = 1},
        };
        public List<Validacion> VALIDACION_DISC = new List<Validacion>()
        {
            new Validacion{pregunta1 = 21,Valor1 = 0},
            new Validacion{pregunta1 = 42,Valor1 = 0},
            new Validacion{pregunta1 = 49,Valor1 = 0},
            new Validacion{pregunta1 = 66,Valor1 = 0},
            new Validacion{pregunta1 = 75,Valor1 = 0},
            new Validacion{pregunta1 = 107,Valor1 = 0},
            new Validacion{pregunta1 = 115,Valor1 = 0},
            new Validacion{pregunta1 = 131,Valor1 = 0},
            new Validacion{pregunta1 = 156,Valor1 = 0},
            new Validacion{pregunta1 = 193,Valor1 = 0},
            new Validacion{pregunta1 = 205,Valor1 = 0},
            new Validacion{pregunta1 = 223,Valor1 = 0},
            new Validacion{pregunta1 = 226,Valor1 = 0},
            new Validacion{pregunta1 = 253,Valor1 = 0},
            new Validacion{pregunta1 = 292,Valor1 = 0},
            new Validacion{pregunta1 = 297,Valor1 = 0},
            new Validacion{pregunta1 = 300,Valor1 = 0},
            new Validacion{pregunta1 = 61,Valor1 = 1},
            new Validacion{pregunta1 = 190,Valor1 = 1},
            new Validacion{pregunta1 = 237,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_NEGE = new List<Validacion>()
        {
            new Validacion{pregunta1 = 9,Valor1 = 0},
            new Validacion{pregunta1 = 23,Valor1 = 0},
            new Validacion{pregunta1 = 29,Valor1 = 0},
            new Validacion{pregunta1 = 56,Valor1 = 0},
            new Validacion{pregunta1 = 77,Valor1 = 0},
            new Validacion{pregunta1 = 116,Valor1 = 0},
            new Validacion{pregunta1 = 123,Valor1 = 0},
            new Validacion{pregunta1 = 146,Valor1 = 0},
            new Validacion{pregunta1 = 155,Valor1 = 0},
            new Validacion{pregunta1 = 167,Valor1 = 0},
            new Validacion{pregunta1 = 206,Valor1 = 0},
            new Validacion{pregunta1 = 209,Valor1 = 0},
            new Validacion{pregunta1 = 263,Valor1 = 0},
            new Validacion{pregunta1 = 277,Valor1 = 0},
            new Validacion{pregunta1 = 309,Valor1 = 0},
            new Validacion{pregunta1 = 37,Valor1 = 1},
            new Validacion{pregunta1 = 73,Valor1 = 1},
            new Validacion{pregunta1 = 134,Valor1 = 1},
            new Validacion{pregunta1 = 234,Valor1 = 1},
            new Validacion{pregunta1 = 293,Valor1 = 1}
        };

        public List<Validacion> VALIDACION_INTR = new List<Validacion>()
        {
            new Validacion{pregunta1 = 4,Valor1 = 1},
            new Validacion{pregunta1 = 11,Valor1 = 1},
            new Validacion{pregunta1 = 17,Valor1 = 1},
            new Validacion{pregunta1 = 47,Valor1 = 1},
            new Validacion{pregunta1 = 53,Valor1 = 1},
            new Validacion{pregunta1 = 57,Valor1 = 1},
            new Validacion{pregunta1 = 64,Valor1 = 1},
            new Validacion{pregunta1 = 102,Valor1 = 1},
            new Validacion{pregunta1 = 109,Valor1 = 1},
            new Validacion{pregunta1 = 118,Valor1 = 1},
            new Validacion{pregunta1 = 140,Valor1 = 1},
            new Validacion{pregunta1 = 153,Valor1 = 1},
            new Validacion{pregunta1 = 166,Valor1 = 1},
            new Validacion{pregunta1 = 181,Valor1 = 1},
            new Validacion{pregunta1 = 195,Valor1 = 1},
            new Validacion{pregunta1 = 201,Valor1 = 1},
            new Validacion{pregunta1 = 207,Valor1 = 1},
            new Validacion{pregunta1 = 222,Valor1 = 1},
            new Validacion{pregunta1 = 246,Valor1 = 1},
            new Validacion{pregunta1 = 323,Valor1 = 1}
        };

        #endregion
        public frmPreguntas()
        {
            InitializeComponent();
            int count = 0;
            var preguntas = CargarDatosPrueba2();
            this.WindowState = FormWindowState.Maximized;
            for (int i = 0; i <= preguntas.Count - 1; i++)
            {

                TableLayoutPanel group = new TableLayoutPanel();
                group.Name = "group" + i;
                group.ColumnCount = 4;
                group.RowCount = 1;

                group.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                group.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));

                group.Controls.Add(new Label { Dock = DockStyle.Fill, Text = string.Format("{0} {1}", preguntas[i].idPregunta, preguntas[i].Descripcion), TextAlign = ContentAlignment.MiddleLeft }, 0, 0);
                for (int j = 1; j < 4; j++)
                {
                    group.Controls.Add(new RadioButton { Name = "Radio" + i + j, Tag = j - 1, Text = j == 1 ? "Verdadero" : j == 2 ? "Falso" : "No contestar" }, j, 0);
                    if (group.Controls[j].Tag.ToString() == "2")
                        ((RadioButton)group.Controls[j]).Checked = true;
                }

                count++;
                if (count <= 50)
                    group.Location = new Point(i * 10, 0);
                else
                if (count > 50 && count <= 100)
                    group.Location = new Point(i * 20, 0);
                else
                     if (count > 100 && count <= 150)
                    group.Location = new Point(i * 20, 0);
                else
                     if (count > 150 && count <= 200)
                    group.Location = new Point(i * 20, 0);
                else
                     if (count > 200 && count <= 250)
                    group.Location = new Point(i * 20, 0);
                else
                     if (count > 250 && count <= 300)
                    group.Location = new Point(i * 20, 0);
                else
                     if (count > 300 && count <= 350)
                    group.Location = new Point(i * 20, 0);

                group.TabIndex = i;
                group.Width = 800;
                group.Height = 30;
                group.Dock = DockStyle.Top;

                pnlPrincipal.AutoScroll = true;
                pnlPrincipal.Dock = DockStyle.Fill;
                pnlPrincipal.Controls.Add(group);
            }

        }
        private List<Pregunta> CargarDatosPrueba2()
        {
            List<Pregunta> result = new List<Pregunta>();
            var strDataXML = Properties.Resources.Preguntas.ToString();
            var serializer = new XmlSerializer(typeof(List<Pregunta>), new XmlRootAttribute("Preguntas"));
            using (var stringReader = new StringReader(strDataXML))
            using (var reader = XmlReader.Create(stringReader))
                result = (List<Pregunta>)serializer.Deserialize(reader);
            return result;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            if (ClsMesageBox.MBOK("Si cierra la encuesta se perderá su avance\r\n ¿Desea salir? ", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var valido = ClsMesageBox.MBOK("¿Está seguro de sus respuestas?", "Información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (valido)
            {
                //ClsMesageBox.MostraFormaEspera("Guardando, espere un momento...",this);
                List<Respuesta> respuestas = new List<Respuesta>();
                respuestas = ObtenerRespuesta();
                bool guardo = GuardarRespuestas(respuestas);
                if (!guardo)
                {
                    ClsMesageBox.MBOK("No se pudo guardar las respuestas, intentelo de nuevo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _puntuacionNatural = AplicarValidaciones(respuestas);

                //ClsMesageBox.CerrarFormaEspera();
                frmFinal frmFinal = new frmFinal(_puntuacionNatural, respuestas.Where(x => x.valor == 2).Count());
                frmFinal.Show();
                this.Close();
            }
        }

        private bool GuardarRespuestas(List<Respuesta> list)
        {
            using (DataBaseEntities ctx = new DataBaseEntities())
            {
                try
                {
                    Clientes client = ctx.Clientes.Where(x => x.NumPreventivo == "0912039120").FirstOrDefault();
                    if (client != null)
                    {
                        string resp = string.Empty;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (i == 0)
                                resp = list[i].valor.ToString();
                            else resp = resp + "," + list[i].valor.ToString();
                        }

                        client.Resultados = resp;
                        ctx.SaveChanges();
                    }
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public RespuestaEscalas AplicarValidaciones(List<Respuesta> resp)
        {
            var puntuacionNatural = new RespuestaEscalas();

            try
            {
                int contador = resp.Count();
                int comparar1, comparar2 = 0;

                #region ESCALAS DE VALIDEZ
                #region VALIDACION_INVAR
                int ptINVAR_R = 0;
                for (int i = 0; i < VALIDACION_INVAR.Count(); i++)
                {
                    comparar1 = resp.Where(x => x.ID == VALIDACION_INVAR[i].pregunta1).ToList().FirstOrDefault().valor;
                    comparar2 = resp.Where(x => x.ID == VALIDACION_INVAR[i].pregunta2).ToList().FirstOrDefault().valor;
                    if (comparar1 == 0 && comparar2 == 1)
                        ptINVAR_R++;

                }
                var INVAR_R = new Escala()
                {
                    descripcion = "INCONSISTENCIA EN LAS RESPUESTAS VARIABLES",
                    significado = "RESPONDER AL AZAR",
                    siglas = "INVAR-R",
                    puntuacionNatural = ptINVAR_R,
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref INVAR_R);
                puntuacionNatural.escalasDeValidez.lstEscalas.Add(INVAR_R);
                #endregion

                #region VALIDACION_INVER
                int puntuacionNaturalINVER_R = 0;
                for (int i = 0; i < VALIDACION_INVER_V.Count(); i++)
                {
                    comparar1 = resp.Where(x => x.ID == VALIDACION_INVER_V[i].pregunta1).ToList().FirstOrDefault().valor;
                    comparar2 = resp.Where(x => x.ID == VALIDACION_INVER_V[i].pregunta2).ToList().FirstOrDefault().valor;
                    if (comparar1 == 0 && comparar2 == 0)
                        puntuacionNaturalINVER_R++;
                }
                for (int i = 0; i < VALIDACION_INVER_F.Count(); i++)
                {
                    comparar1 = resp.Where(x => x.ID == VALIDACION_INVER_F[i].pregunta1).ToList().FirstOrDefault().valor;
                    comparar2 = resp.Where(x => x.ID == VALIDACION_INVER_F[i].pregunta2).ToList().FirstOrDefault().valor;
                    if (comparar1 == 1 && comparar2 == 1)
                        puntuacionNaturalINVER_R--;
                }
                var INVER_R = new Escala()
                {
                    descripcion = @"INCONSISTENCIA EN RESPUESTAS ""VERDADERO""",
                    significado = "RESPONDE DE FORMA FIJA",
                    siglas = "INVER-R",
                    puntuacionNatural = puntuacionNaturalINVER_R + 11,
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref INVER_R);
                puntuacionNatural.escalasDeValidez.lstEscalas.Add(INVER_R);
                #endregion

                #region VALIDACION_FR
                var F_R = new Escala()
                {
                    descripcion = "RESPUESTAS INFRECUENTES",
                    significado = "RESPUESTAS INFRECUENTES EN LA POBLACIÓN GENERAL",
                    siglas = "F-R",
                    puntuacionNatural = TotalValidacion(VALIDACION_FR, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref F_R);
                puntuacionNatural.escalasDeValidez.lstEscalas.Add(F_R);
                #endregion

                #region VALIDACION_FPSI                
                var FPSI_R = new Escala()
                {
                    descripcion = "RESP. INFRE. DE PSICOPAT.",
                    significado = "RESPUESTAS INFRECUENTES EN LA POBLACIÓN PSIQUIÁTRICA",
                    siglas = "FPSI-R",
                    puntuacionNatural = TotalValidacion(VALIDACION_FPSI, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref FPSI_R);
                puntuacionNatural.escalasDeValidez.lstEscalas.Add(FPSI_R);
                #endregion

                #region VALIDACION_FS                
                var FS = new Escala()
                {
                    descripcion = "RESPUESTAS INFRECUENTES SOMÁTICAS",
                    significado = "QUEJAS SOMÁTICAS INFRECUENTES EN LA POBLACIÓN MÉDICA-PACIENTES.",
                    siglas = "FS",
                    puntuacionNatural = TotalValidacion(VALIDACION_FS, resp),
                    puntuacionT = 0

                };
                PuntuacionT.CalcularPuntuacionT(ref FS);
                puntuacionNatural.escalasDeValidez.lstEscalas.Add(FS);
                #endregion

                #region VALIDACION_FVS               
                var FVS_R = new Escala()
                {
                    descripcion = "VALIDEZ DEL SÍNTOMA",
                    significado = "QUEJAS",
                    siglas = "FVS-R",
                    puntuacionNatural = TotalValidacion(VALIDACION_FVS, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref FVS_R);
                puntuacionNatural.escalasDeValidez.lstEscalas.Add(FVS_R);
                #endregion

                #region VALIDACION_SI

                var SI = new Escala()
                {
                    descripcion = "ESCALAS DE SÍNTOMAS INCONSISTENTES.",
                    significado = string.Empty,
                    siglas = "SI",
                    puntuacionNatural = TotalValidacion(VALIDACION_SI, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref SI);
                puntuacionNatural.escalasDeValidez.lstEscalas.Add(SI);
                #endregion

                #region VALIDACION_LR

                var L_R = new Escala()
                {
                    descripcion = "VIRTUDES POCO COMUNES",
                    significado = "PRETENSIÓN DE ATRIBUTOS O ACTIVIDADES MORALES POCO COMUNES.",
                    siglas = "L-R",
                    puntuacionNatural = TotalValidacion(VALIDACION_LR, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref L_R);
                puntuacionNatural.escalasDeValidez.lstEscalas.Add(L_R);
                #endregion

                #region VALIDACION_KR                
                var K_R = new Escala()
                {
                    descripcion = "VALIDEZ DE ADAPTACIÓN",
                    significado = "DECLARACIÒN DE UNA BUENA ADAPTACIÓN PSICOLÓGICA",
                    siglas = "K-R",
                    puntuacionNatural = TotalValidacion(VALIDACION_KR, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref K_R);
                puntuacionNatural.escalasDeValidez.lstEscalas.Add(K_R);
                #endregion

                #endregion

                #region Escalas de orden superior OS (H-O)
                #region VALIDACION_AEPI               
                var AEPI = new Escala()
                {
                    descripcion = "ALTERACIÓN EMOCIONAL/PROBLEMAS INTERNALIZADOS",
                    significado = "ASOCIADOS CON EL ESTADO DE ANIMO Y AFECTIVOS.",
                    siglas = "AE/PI",
                    puntuacionNatural = TotalValidacion(VALIDACION_AEPI, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref AEPI);
                puntuacionNatural.escalasDeOrdenSuperior.lstEscalas.Add(AEPI);
                #endregion
                #region VALIDACION_AP                
                var AP = new Escala()
                {
                    descripcion = "ALTERACIÓN DEL PENSAMIENTO",
                    significado = "PROBLEMAS ASOCIADOS CON TRASTORNOS DEL PENSAMIENTO",
                    siglas = "AP",
                    puntuacionNatural = TotalValidacion(VALIDACION_AP, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref AP);
                puntuacionNatural.escalasDeOrdenSuperior.lstEscalas.Add(AP);
                #endregion
                #region VALIDACION_ACPE            
                var ACPE = new Escala()
                {
                    descripcion = "ALTERACIONES DE LA CONDUCTA/PROBLEMAS EXTERNALIZADOS",
                    significado = "ASOCIADOS CON PROBLEMAS DE CONDUCTA DONDE HAY UN POBRE CONTROL DE IMPULSOS",
                    siglas = "AC/PE",
                    puntuacionNatural = TotalValidacion(VALIDACION_ACPE, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref ACPE);
                puntuacionNatural.escalasDeOrdenSuperior.lstEscalas.Add(ACPE);
                #endregion
                #endregion

                #region Escalas clinicas Reestructuradas CR (RC)
                #region VALIDACION_CRD                
                var CRD = new Escala()
                {
                    descripcion = "DESMORALIZACIÓN",
                    significado = "SENTIMIENTOS DE INFELICIDAD E INSATISFACCIÓN GENERAL",
                    siglas = "CRD",
                    puntuacionNatural = TotalValidacion(VALIDACION_CRD, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref CRD);
                puntuacionNatural.escalasDeClinicasReestructuradas.lstEscalas.Add(CRD);
                #endregion
                #region VALIDACION_CR1                
                var CR1 = new Escala()
                {
                    descripcion = "QUEJAS SOMÁTICAS",
                    significado = "QUEJAS VAGAS ACERCA DE LA SALUD FÍSICA",
                    siglas = "CR1",
                    puntuacionNatural = TotalValidacion(VALIDACION_CR1, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref CR1);
                puntuacionNatural.escalasDeClinicasReestructuradas.lstEscalas.Add(CR1);
                #endregion
                #region VALIDACION_CR2               
                var CR2 = new Escala()
                {
                    descripcion = "DISMINUCIÓN DE EMOCIONES POSITIVAS",
                    significado = "AUSENCIA DE RESPUESTAS EMOCIONALES POSITIVAS",
                    siglas = "CR2",
                    puntuacionNatural = TotalValidacion(VALIDACION_CR2, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref CR2);
                puntuacionNatural.escalasDeClinicasReestructuradas.lstEscalas.Add(CR2);
                #endregion
                #region VALIDACION_CR3                
                var CR3 = new Escala()
                {
                    descripcion = "CINISMO",
                    significado = "CREENCIAS NO AUTORREFERENCIALES QUE EXPRESAN DESCONFIANZA Y UNA OPINIÓN NEGATIVA GENERALIZADA DE LOS OTROS.",
                    siglas = "CR3",
                    puntuacionNatural = TotalValidacion(VALIDACION_CR3, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref CR3);
                puntuacionNatural.escalasDeClinicasReestructuradas.lstEscalas.Add(CR3);
                #endregion
                #region VALIDACION_CR4                
                var CR4 = new Escala()
                {
                    descripcion = "CONDUCTA ANTISOCIAL",
                    significado = "ROMPIMIENTO DE REGLAS Y CONDUCTAS IRRESPONSABLES.",
                    siglas = "CR4",
                    puntuacionNatural = TotalValidacion(VALIDACION_CR4, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref CR4);
                puntuacionNatural.escalasDeClinicasReestructuradas.lstEscalas.Add(CR4);
                #endregion
                #region VALIDACION_CR6                
                var CR6 = new Escala()
                {
                    descripcion = "IDEAS DE PERSECUCIÓN",
                    significado = "CREENCIAS AUTORREFERENCIALES DE QUE OTROS REPRESENTAN UNA AMENAZA.",
                    siglas = "CR6",
                    puntuacionNatural = TotalValidacion(VALIDACION_CR6, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref CR6);
                puntuacionNatural.escalasDeClinicasReestructuradas.lstEscalas.Add(CR6);
                #endregion
                #region VALIDACION_CR7                
                var CR7 = new Escala()
                {
                    descripcion = "EMOCIONES NEGATIVAS DISFUNCIONALES",
                    significado = "ANSIEDAD DES ADAPTATIVA, ENOJO E IRRITABILIDAD.",
                    siglas = "CR7",
                    puntuacionNatural = TotalValidacion(VALIDACION_CR7, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref CR7);
                puntuacionNatural.escalasDeClinicasReestructuradas.lstEscalas.Add(CR7);
                #endregion
                #region VALIDACION_CR8                
                var CR8 = new Escala()
                {
                    descripcion = "EXPERIENCIAS ABERRANTES",
                    significado = "PERCEPCIONES Y PENSAMIENTOS RAROS.",
                    siglas = "CR8",
                    puntuacionNatural = TotalValidacion(VALIDACION_CR8, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref CR8);
                puntuacionNatural.escalasDeClinicasReestructuradas.lstEscalas.Add(CR8);
                #endregion
                #region VALIDACION_CR9               
                var CR9 = new Escala()
                {
                    descripcion = "ACTIVACIÓN HIPOMANÍACA",
                    significado = "SOBRE ACTIVACIÓN, AGRESIÓN, IMPULSIVIDAD Y PENSAMIENTO DE GRANDEZA.",
                    siglas = "CR9",
                    puntuacionNatural = TotalValidacion(VALIDACION_CR9, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref CR9);
                puntuacionNatural.escalasDeClinicasReestructuradas.lstEscalas.Add(CR9);
                #endregion
                #endregion

                #region Somaticos cognitivos

                #region VALIDACION_MAL                
                var MAL = new Escala()
                {
                    descripcion = "MALESTAR",
                    significado = "SENSACIÓN GENERALIZADA DE DEBILIDAD Y SALUD FÍSICA MALA.",
                    siglas = "MAL",
                    puntuacionNatural = TotalValidacion(VALIDACION_MAL, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref MAL);
                puntuacionNatural.somaticosCognitivos.lstEscalas.Add(MAL);
                #endregion

                #region VALIDACION_QGI                
                var QGI = new Escala()
                {
                    descripcion = "QUEJAS GASTROINTESTINALES",
                    significado = "NAUSEAS, DOLOR DE ESTOMAGO FRECUENTE, MAL APETITO.",
                    siglas = "QGI",
                    puntuacionNatural = TotalValidacion(VALIDACION_QGI, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref QGI);
                puntuacionNatural.somaticosCognitivos.lstEscalas.Add(QGI);
                #endregion

                #region VALIDACION_QDC             
                var QDC = new Escala()
                {
                    descripcion = "QUEJAS DE DOLOR DE CABEZA",
                    significado = "DOLOR DE CABEZA Y CUELLO.",
                    siglas = "QDC",
                    puntuacionNatural = TotalValidacion(VALIDACION_QDC, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref QDC);
                puntuacionNatural.somaticosCognitivos.lstEscalas.Add(QDC);
                #endregion

                #region VALIDACION_QNEU                
                var QNEU = new Escala()
                {
                    descripcion = "QUEJAS NEUROLÓGICAS",
                    significado = "MAREOS, DEBILIDAD, PARÁLISIS, PERDIDA DE EQUILIBRO, ETC.",
                    siglas = "QNEU",
                    puntuacionNatural = TotalValidacion(VALIDACION_QNEU, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref QNEU);
                puntuacionNatural.somaticosCognitivos.lstEscalas.Add(QNEU);
                #endregion

                #region VALIDACION_QCO               
                var QCO = new Escala()
                {
                    descripcion = "QUEJAS COGNITIVAS",
                    significado = "PROBLEMAS DE MEMORIA, PROBLEMAS DE CONCENTRACIÓN.",
                    siglas = "QCO",
                    puntuacionNatural = TotalValidacion(VALIDACION_QCO, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref QCO);
                puntuacionNatural.somaticosCognitivos.lstEscalas.Add(QCO);
                #endregion
                #endregion

                #region Escala de problemas internalizados
                #region VALIDACION_ISU                
                var ISU = new Escala()
                {
                    descripcion = "IDEAS SUICIDAS/DESEOS DE MUERTE",
                    significado = "REPORTES DIRECTOS DE IDEACIÓN SUICIDA E INTENTOS DE SUICIDIOS RECIENTES.",
                    siglas = "ISU",
                    puntuacionNatural = TotalValidacion(VALIDACION_ISU, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref ISU);
                puntuacionNatural.escalasDeProblemasInternalizados.lstEscalas.Add(ISU);
                #endregion

                #region VALIDACION_LMD                
                var LMD = new Escala()
                {
                    descripcion = "IMPOTENCIA/DESESPERANZA",
                    significado = "CREENCIAS DE QUE SUS METAS NO SERÁN ALCANZADAS O QUE NO PUEDEN SOLUCIONAR SUS PROBLEMAS.",
                    siglas = "LM/D",
                    puntuacionNatural = TotalValidacion(VALIDACION_IMD, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref LMD);
                puntuacionNatural.escalasDeProblemasInternalizados.lstEscalas.Add(LMD);
                #endregion

                #region VALIDACION_DSM                
                var DSM = new Escala()
                {
                    descripcion = "DESCONFIANZA DE SI MISMOS",
                    significado = "PERDIDA DE CONFIANZA, SENTIMIENTOS DE INUTILIDAD.",
                    siglas = "DSM",
                    puntuacionNatural = TotalValidacion(VALIDACION_DSM, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref DSM);
                puntuacionNatural.escalasDeProblemasInternalizados.lstEscalas.Add(DSM);
                #endregion

                #region VALIDACION_INE                
                var INE = new Escala()
                {
                    descripcion = "INEFICIENCIA",
                    significado = "CREENCIAS DE QUE SE ES INEFICIENTE E INDECISO.",
                    siglas = "INE",
                    puntuacionNatural = TotalValidacion(VALIDACION_INE, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref INE);
                puntuacionNatural.escalasDeProblemasInternalizados.lstEscalas.Add(INE);
                #endregion

                #region VALIDACION_PE                
                var PE = new Escala()
                {
                    descripcion = "PREOCUPACIÓN/ESTRÉS",
                    significado = "PREOCUPACIÓN POR DESILUSIONES, DIFICULTAD PARA MANEJAR LA PRESIÓN DEL TIEMPO.",
                    siglas = "P/E",
                    puntuacionNatural = TotalValidacion(VALIDACION_PE, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref PE);
                puntuacionNatural.escalasDeProblemasInternalizados.lstEscalas.Add(PE);
                #endregion

                #region VALIDACION_ANS                
                var ANS = new Escala()
                {
                    descripcion = "ANSIEDAD",
                    significado = "ANSIEDAD PERSISTENTE, TEMORES, PESADILLAS FRECUENTES.",
                    siglas = "ANS",
                    puntuacionNatural = TotalValidacion(VALIDACION_ANS, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref ANS);
                puntuacionNatural.escalasDeProblemasInternalizados.lstEscalas.Add(ANS);
                #endregion

                #region VALIDACION_TEN                
                var TEN = new Escala()
                {
                    descripcion = "TENDENCIA AL ENOJO",
                    significado = "SE ENOJA CON FACILIDAD, IMPACIENCIA CON LOS OTROS.",
                    siglas = "TEN",
                    puntuacionNatural = TotalValidacion(VALIDACION_TEN, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref TEN);
                puntuacionNatural.escalasDeProblemasInternalizados.lstEscalas.Add(TEN);
                #endregion

                #region VALIDACION_LCM                
                var LCM = new Escala()
                {
                    descripcion = "LIMITACIONES CONDUCTUALES POR MIEDOS",
                    significado = "MIEDOS QUE INHIBEN DE FORMA SIGNIFICATIVA LAS ACTIVIDADES NORMALES.",
                    siglas = "LCM",
                    puntuacionNatural = TotalValidacion(VALIDACION_LCM, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref LCM);
                puntuacionNatural.escalasDeProblemasInternalizados.lstEscalas.Add(LCM);
                #endregion

                #region VALIDACION_MEM                
                var MEM = new Escala()
                {
                    descripcion = "MIEDOS ESPECÍFICOS MÚLTIPLES",
                    significado = "MIEDO A LA SANGRE, AL FUEGO, TRUENOS, ETC.",
                    siglas = "MEM",
                    puntuacionNatural = TotalValidacion(VALIDACION_MEM, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref MEM);
                puntuacionNatural.escalasDeProblemasInternalizados.lstEscalas.Add(MEM);
                #endregion
                #endregion

                #region Escalas de problemas externalizados
                #region VALIDACION_PCIJ                
                var PCIJ = new Escala()
                {
                    descripcion = "PROBLEMAS DE CONDUCTA INFANTO-JUVENILES",
                    significado = "DIFICULTADES EN LA ESCUELA, CASA Y ROBOS.",
                    siglas = "PCIJ",
                    puntuacionNatural = TotalValidacion(VALIDACION_PCIJ, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref PCIJ);
                puntuacionNatural.escalasDeProblemasExternalizados.lstEscalas.Add(PCIJ);
                #endregion

                #region VALIDACION_ABS                
                var ABS = new Escala()
                {
                    descripcion = "ABUSO DE SUSTANCIAS",
                    significado = "MAL USO ACTUAL O EN EL PASADO DE ALCOHOL Y DROGAS.",
                    siglas = "ABS",
                    puntuacionNatural = TotalValidacion(VALIDACION_ABS, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref ABS);
                puntuacionNatural.escalasDeProblemasExternalizados.lstEscalas.Add(ABS);
                #endregion

                #region VALIDACION_AG                
                var AG = new Escala()
                {
                    descripcion = "AGRESIÓN",
                    significado = "CONDUCTA VIOLENTA Y AGRESIÓN FÍSICA.",
                    siglas = "AG",
                    puntuacionNatural = TotalValidacion(VALIDACION_AG, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref AG);
                puntuacionNatural.escalasDeProblemasExternalizados.lstEscalas.Add(AG);
                #endregion

                #region VALIDACION_EUF                
                var EUF = new Escala()
                {
                    descripcion = "EUFORIA",
                    significado = "PERIODOS DE GRAN ENERGÍA Y ACTIVIDAD.",
                    siglas = "EUF",
                    puntuacionNatural = TotalValidacion(VALIDACION_EUF, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref EUF);
                puntuacionNatural.escalasDeProblemasExternalizados.lstEscalas.Add(EUF);
                #endregion
                #endregion

                #region Escala de problemas interpersonales
                #region VALIDACION_PFA                
                var PFA = new Escala()
                {
                    descripcion = "PROBLEMAS FAMILIARES",
                    significado = "RELACIONES FAMILIARES CONFLICTIVAS.",
                    siglas = "PFA",
                    puntuacionNatural = TotalValidacion(VALIDACION_PFA, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref PFA);
                puntuacionNatural.escalasDeProblemasInterpersonales.lstEscalas.Add(PFA);
                #endregion

                #region VALIDACION_PIP                
                var PIP = new Escala()
                {
                    descripcion = "PASIVIDAD INTERPERSONAL",
                    significado = "SER POCO ASERTIVO Y SUMISO.",
                    siglas = "PIP",
                    puntuacionNatural = TotalValidacion(VALIDACION_PIP, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref PIP);
                puntuacionNatural.escalasDeProblemasInterpersonales.lstEscalas.Add(PIP);
                #endregion

                #region VALIDACION_ESO                
                var ESO = new Escala()
                {
                    descripcion = "EVITACIÓN SOCIAL",
                    significado = "EVITAR O NO DISFRUTAR DE EVENTOS SOCIALES.",
                    siglas = "ESO",
                    puntuacionNatural = TotalValidacion(VALIDACION_ESO, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref ESO);
                puntuacionNatural.escalasDeProblemasInterpersonales.lstEscalas.Add(ESO);
                #endregion

                #region VALIDACION_TIM                
                var TIM = new Escala()
                {
                    descripcion = "TIMIDEZ",
                    significado = "TÍMIDO, CON TENDENCIA A SENTIRSE INHIBIDO Y ANSIOSO EN TORNO A OTROS.",
                    siglas = "TIM",
                    puntuacionNatural = TotalValidacion(VALIDACION_TIM, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref TIM);
                puntuacionNatural.escalasDeProblemasInterpersonales.lstEscalas.Add(TIM);
                #endregion

                #region VALIDACION_DES                
                var DES = new Escala()
                {
                    descripcion = "DESAPEGO",
                    significado = "AVERSIÓN A LA GENTE Y A ESTAR CON ELLOS.",
                    siglas = "DES",
                    puntuacionNatural = TotalValidacion(VALIDACION_DES, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref DES);
                puntuacionNatural.escalasDeProblemasInterpersonales.lstEscalas.Add(DES);
                #endregion
                #endregion

                #region Escalas de interes especifico
                #region VALIDACION_IEL                
                var IEL = new Escala()
                {
                    descripcion = "INTERESES ESTÉTICOS-LITERARIOS",
                    significado = "LITERATURA, MÚSICA, TEATRO.",
                    siglas = "IEL",
                    puntuacionNatural = TotalValidacion(VALIDACION_IEL, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref IEL);
                puntuacionNatural.escalasDeInteresEspecifico.lstEscalas.Add(IEL);
                #endregion

                #region VALIDACION_IFM                
                var IFM = new Escala()
                {
                    descripcion = "INTERESES FÍSICO-MECÁNICOS",
                    significado = "DESARMAR Y CONSTRUIR COSAS, DEPORTES, ACTIVIDADES AL AIRE LIBRE.",
                    siglas = "IFM",
                    puntuacionNatural = TotalValidacion(VALIDACION_IFM, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref IFM);
                puntuacionNatural.escalasDeInteresEspecifico.lstEscalas.Add(IFM);
                #endregion

                #endregion

                #region Cinco escalas de psicopatología de la personalidad (PSY-5)

                #region VALIDACION_AGGR                
                var AGGR = new Escala()
                {
                    descripcion = "AGRESIVIDAD-REVISADA",
                    significado = "AGRESIÓN INSTRUMENTAL, DIRIGIDA A UN OBJETIVO.",
                    siglas = "AGGR-R",
                    puntuacionNatural = TotalValidacion(VALIDACION_AGGR, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref AGGR);
                puntuacionNatural.escalasDePSY_5.lstEscalas.Add(AGGR);
                #endregion

                #region VALIDACION_PSYC                
                var PSYC = new Escala()
                {
                    descripcion = "PSICOTICISMO-REVISADA",
                    significado = "PERDIDA DE CONTACTO CON LA REALIDAD.",
                    siglas = "PSYC-R",
                    puntuacionNatural = TotalValidacion(VALIDACION_PSYC, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref PSYC);
                puntuacionNatural.escalasDePSY_5.lstEscalas.Add(PSYC);
                #endregion

                #region VALIDACION_DISC                
                var DISC = new Escala()
                {
                    descripcion = "IMPULSIVIDAD-REVISADA",
                    significado = "CONDUCTA POCO CONTROLADA.",
                    siglas = "DISC-R",
                    puntuacionNatural = TotalValidacion(VALIDACION_DISC, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref DISC);
                puntuacionNatural.escalasDePSY_5.lstEscalas.Add(DISC);
                #endregion

                #region VALIDACION_NEGE            
                var NEGE = new Escala()
                {
                    descripcion = "NEUROTICISMO/EMOCIONALIDAD NEGATIVA-REVISADA",
                    significado = "ANSIEDAD, INSEGURIDAD, PREOCUPACIÓN Y TEMORES.",
                    siglas = "NEGE-R",
                    puntuacionNatural = TotalValidacion(VALIDACION_NEGE, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref NEGE);
                puntuacionNatural.escalasDePSY_5.lstEscalas.Add(NEGE);
                #endregion

                #region VALIDACION_INTR            
                var INTR = new Escala()
                {
                    descripcion = "INTROVERSIÓN/DISMINUCIÓN EMOCIONES POSITIVA-REVISADA",
                    significado = "RETRAIMIENTO SOCIAL, DESAPEGO Y ANHEDONIA.",
                    siglas = "INTR-R",
                    puntuacionNatural = TotalValidacion(VALIDACION_INTR, resp),
                    puntuacionT = 0
                };
                PuntuacionT.CalcularPuntuacionT(ref INTR);
                puntuacionNatural.escalasDePSY_5.lstEscalas.Add(INTR);
                #endregion

                #endregion

                //Escalas de orden superior
                return puntuacionNatural;


            }
            catch (Exception ex)
            {
                return new RespuestaEscalas();

            }
        }



        public int TotalValidacion(List<Validacion> VALIDACION, List<Respuesta> resp)
        {
            try
            {
                int comparar1, sumatoria = 0;
                for (int i = 0; i < VALIDACION.Count(); i++)
                {
                    comparar1 = resp.Where(x => x.ID == VALIDACION[i].pregunta1).ToList().FirstOrDefault().valor;
                    if (comparar1 == VALIDACION[i].Valor1)
                        sumatoria++;

                }
                //for (int i = 0; i < VALIDACION_FR_F.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_FR_F[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 1)
                //        puntuacionNatural.ResultadoF_R++;

                //}
                return sumatoria;

            }
            catch (Exception)
            {
                return -1;
            }
        }

        public List<Respuesta> ObtenerRespuesta()
        {
            List<Respuesta> resp = new List<Respuesta>();
            for (int i = 0; i < pnlPrincipal.Controls.Count; i++)
            {
                var a = pnlPrincipal.Controls[i];
                for (int j = 0; j < a.Controls.Count; j++)
                {
                    if (a.Controls[j] is RadioButton)
                    {

                        if (((RadioButton)a.Controls[j]).Checked)
                        {

                            resp.Add(new Respuesta() { ID = i + 1, valor = (int)a.Controls[j].Tag });
                        }
                        //var b = (RadioButton)a.Controls[j];
                        //b.Checked
                    }
                    // group.Controls.Add(new RadioButton { Name = "Radio" + i + j, Tag = j - 1, Text = j == 1 ? "V" : "F" }, j, 0);
                }


            }
            return resp;
        }


    }
}

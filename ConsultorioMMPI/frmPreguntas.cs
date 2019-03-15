using ConsultorioMMPI.Clases;
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
        public ResultadosSumatoria puntuacionNatural = new ResultadosSumatoria();

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
                    group.Controls.Add(new RadioButton {Name = "Radio"+i+j,Tag = j-1, Text = j == 1 ? "Verdadero" : j== 2 ? "Falso" :  "No contestar" }, j, 0);
                    if (group.Controls[j].Tag.ToString() == "0")
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
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            puntuacionNatural = new ResultadosSumatoria();
            AplicarValidaciones(ObtenerRespuesta());


        }
        public void AplicarValidaciones(List<Respuesta> resp)
        {
            try
            {
                int contador = resp.Count();
                int comparar1, comparar2 = 0;

                #region VALIDACION_INVAR
                for (int i = 0; i < VALIDACION_INVAR.Count(); i++)
                {
                    comparar1 = resp.Where(x => x.ID == VALIDACION_INVAR[i].pregunta1).ToList().FirstOrDefault().valor;
                    comparar2 = resp.Where(x => x.ID == VALIDACION_INVAR[i].pregunta2).ToList().FirstOrDefault().valor;
                    if (comparar1 == 0 && comparar2 == 1)
                            puntuacionNatural.ResultadoINVAR_R++;

                }
                #endregion
                #region VALIDACION_INVER
                puntuacionNatural.ResultadoINVER_R = puntuacionNatural.ResultadoINVER_R + 11;
                for (int i = 0; i < VALIDACION_INVER_V.Count(); i++)
                {
                    comparar1 = resp.Where(x => x.ID == VALIDACION_INVER_V[i].pregunta1).ToList().FirstOrDefault().valor;
                    comparar2 = resp.Where(x => x.ID == VALIDACION_INVER_V[i].pregunta2).ToList().FirstOrDefault().valor;
                    if (comparar1 == 0 && comparar2 == 0)
                            puntuacionNatural.ResultadoINVER_R++;

                }
                for (int i = 0; i < VALIDACION_INVER_F.Count(); i++)
                {
                    comparar1 = resp.Where(x => x.ID == VALIDACION_INVER_F[i].pregunta1).ToList().FirstOrDefault().valor;
                    comparar2 = resp.Where(x => x.ID == VALIDACION_INVER_F[i].pregunta2).ToList().FirstOrDefault().valor;
                    if (comparar1 == 1 && comparar2 == 1)
                            puntuacionNatural.ResultadoINVER_R--;
                }

                #endregion

                #region VALIDACION_FR
                puntuacionNatural.ResultadoF_R = TotalValidacion(VALIDACION_FR, resp);
                //for (int i = 0; i < VALIDACION_FR_V.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_FR_V[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 0)
                //        puntuacionNatural.ResultadoF_R++;

                //}
                //for (int i = 0; i < VALIDACION_FR_F.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_FR_F[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 1)
                //        puntuacionNatural.ResultadoF_R++;

                //}
                #endregion

                #region VALIDACION_FPSI
                puntuacionNatural.ResultadoFPSI_R = TotalValidacion(VALIDACION_FPSI, resp);
                //for (int i = 0; i < VALIDACION_FPSI_V.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_FPSI_V[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 0)
                //        puntuacionNatural.ResultadoFPSI_R++;

                //}
                //for (int i = 0; i < VALIDACION_FPSI_F.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_FPSI_F[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 1)
                //        puntuacionNatural.ResultadoFPSI_R++;

                //}
                #endregion

                #region VALIDACION_FS
                puntuacionNatural.ResultadoFS = TotalValidacion(VALIDACION_FS, resp);
                //for (int i = 0; i < VALIDACION_FS_V.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_FS_V[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 0)
                //        puntuacionNatural.ResultadoFS++;

                //}
                //for (int i = 0; i < VALIDACION_FS_F.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_FS_F[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 1)
                //        puntuacionNatural.ResultadoFS++;

                //}
                #endregion

                #region VALIDACION_FVS
                puntuacionNatural.ResultadoFVS_R = TotalValidacion(VALIDACION_FVS, resp);
                //for (int i = 0; i < VALIDACION_FVS_V.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_FVS_V[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 0)
                //        puntuacionNatural.ResultadoFVS_R++;

                //}
                //for (int i = 0; i < VALIDACION_FVS_F.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_FVS_F[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 1)
                //        puntuacionNatural.ResultadoFVS_R++;

                //}
                #endregion

                #region VALIDACION_SI
                puntuacionNatural.ResultadoSI = TotalValidacion(VALIDACION_SI, resp);
                //for (int i = 0; i < VALIDACION_SI_V.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_SI_V[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 0)
                //        puntuacionNatural.ResultadoSI++;

                //}
                //for (int i = 0; i < VALIDACION_SI_F.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_SI_F[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 1)
                //        puntuacionNatural.ResultadoSI++;

                //}
                #endregion

                #region VALIDACION_LR
                puntuacionNatural.ResultadoL_R = TotalValidacion(VALIDACION_LR, resp);
                //for (int i = 0; i < VALIDACION_LR_V.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_LR_V[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 0)
                //        puntuacionNatural.ResultadoL_R++;

                //}
                //for (int i = 0; i < VALIDACION_LR_F.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_LR_F[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 1)
                //        puntuacionNatural.ResultadoL_R--;

                //}
                #endregion

                #region VALIDACION_KR
                puntuacionNatural.ResultadoK_R = TotalValidacion(VALIDACION_KR, resp);
                //for (int i = 0; i < VALIDACION_KR_V.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_KR_V[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 0)
                //        puntuacionNatural.ResultadoK_R++;

                //}
                //for (int i = 0; i < VALIDACION_KR_F.Count(); i++)
                //{
                //    comparar1 = resp.Where(x => x.ID == VALIDACION_KR_F[i].pregunta1).ToList().FirstOrDefault().valor;
                //    if (comparar1 == 1)
                //        puntuacionNatural.ResultadoK_R++;

                //}
                #endregion




            }
            catch (Exception ex)
            {

                
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

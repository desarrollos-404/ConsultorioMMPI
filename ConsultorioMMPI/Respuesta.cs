namespace ConsultorioMMPI
{
    public class Respuesta
    {
        public int ID  { get; set; }
        public int valor { get; set; }

    }
    public class Validacion
    {
        public int pregunta1 { get; set; }
        public int pregunta2 { get; set; }
        public int Valor1 { get; set; }
        public int Valor2 { get; set; }
    }

    public class ResultadosSumatoria
    {
        public int ResultadoINVAR_R { get; set; }
        public int ResultadoINVER_R { get; set; }
        public int ResultadoF_R { get; set; }
        public int ResultadoFPSI_R { get; set; }
        public int ResultadoFS { get; set; }
        public int ResultadoFVS_R { get; set; }
        public int ResultadoSI { get; set; }
        public int ResultadoL_R { get; set; }
        public int ResultadoK_R { get; set; }
    }
}
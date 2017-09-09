using System;

namespace UCV.Comun.Modelos
{
    public class Usuario : BaseClass
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Compania Compania { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCV.Comun.Modelos
{
   public class Viaje
    {
        public Compania Compania { get; set; }
        public Ruta Ruta { get; set; }
        public decimal Costo { get; set; }
    }
}

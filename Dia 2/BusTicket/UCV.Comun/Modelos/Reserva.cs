using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCV.Comun.Modelos
{
   public class Reserva
    {
        public Usuario Usuario { get; set; }
        public DateTime FechaReserva { get; set; }
        public Compania Compania { get; set; }
        public Ruta Ruta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Models
{
    public struct Reserva
    {
        private Localizacion destino;
        private Localizacion salida;
        private DateTime fecha;

        public Localizacion Destino
        {
            get
            {
                return destino;
            }
            set
            {
                destino = value;
            }
        }
        public Localizacion Salida
        {
            get
            {
                return salida;
            }
            set
            {
                salida = value;
            }
        }
        public DateTime Fecha { get; set; }

    }
}

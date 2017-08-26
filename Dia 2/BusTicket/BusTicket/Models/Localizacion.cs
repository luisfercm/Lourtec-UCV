using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Models
{
    public struct Localizacion
    {
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Estacion { get; set; }
    }
}

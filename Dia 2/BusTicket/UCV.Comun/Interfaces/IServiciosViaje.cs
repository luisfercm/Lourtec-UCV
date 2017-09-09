using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.Comun.Interfaces
{
  public  interface IServiciosViaje
    {
        List<Viaje> GetViajes();
        void SaveViaje(Viaje viaje);
        void SaveViaje(List<Viaje> viaje);
        void UpdateViaje(Viaje viaje);
        void DeleteViaje(Viaje viaje);
    }
}

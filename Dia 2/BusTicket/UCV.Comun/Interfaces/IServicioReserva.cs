using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.Comun.Interfaces
{
    public interface IServicioReserva
    {
        List<Reserva> GetReservas();
        void SaveReserva(Reserva reserva);
        void SaveReserva(List<Reserva> reserva);
        void UpdateReserva(Reserva reserva);
        void DeleteReserva(Reserva reserva);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.Comun.Interfaces
{
    public interface IServicioCompania
    {
        List<Compania> GetCompanias();
        List<Compania> GetCompanias(string ruc);
        List<Compania> GetCompanias(string ruc, int calificacion);
        Compania GetCompanias(Guid id);
        List<Compania> GetCompanias(int calificacion);

        void GetCompanias(string[] filtros, string valores);

        void SaveCompania(Compania compania);
        void SaveCompania(List<Compania> compania);
        void UpdateCompania(Compania compania);
        bool DeleteCompania(Compania compania);
    }
}

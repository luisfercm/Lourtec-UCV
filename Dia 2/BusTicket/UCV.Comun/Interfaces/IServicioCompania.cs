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
        void SaveCompania(Compania compania);
        void SaveCompania(List<Compania> compania);
        void UpdateCompania(Compania compania);
        void DeleteCompania(Compania compania);
    }
}

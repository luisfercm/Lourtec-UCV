using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Interfaces;
using UCV.Comun.Modelos;
using UCV.DatabaseAccess.Contextos;

namespace UCV.DatabaseAccess.Servicios
{
    public class ServicioCompania : IServicioCompania
    {
        SqlBusContexto Db;
        public ServicioCompania()
        {
            Db = new SqlBusContexto();
        }

        public void DeleteCompania(Compania compania)
        {
            throw new NotImplementedException();
        }

        public List<Compania> GetCompanias()
        {
            throw new NotImplementedException();
        }

        public void SaveCompania(Compania compania)
        {
            if (compania.Ruc == null || compania.Ruc== string.Empty) {
                throw new NullReferenceException("El Ruc no puede ser nulo o vacio");
            }

            
            compania.Id = Guid.NewGuid();
            Db.Companias.Add(compania);
            Db.SaveChanges();
        }

        public void SaveCompania(List<Compania> compania)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompania(Compania compania)
        {
            throw new NotImplementedException();
        }
    }
}

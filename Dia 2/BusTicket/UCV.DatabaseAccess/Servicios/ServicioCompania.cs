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
            return Db.Companias.ToList();
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

        public void SaveCompania(List<Compania> companias)
        {
            // Validar si hay elementos vacios en la coleccion Linq Funcional/Extension
            var hayElementosVacios = companias.Where(g => g == null ||
                                   g.Ruc == null ||
                                   g.Ruc == String.Empty)
                            .Count() > 0;

            // Validar si hay elementos vacios en la coleccion Linq Clasico
            hayElementosVacios = (from g in companias
                                  where g == null ||
                                        g.Ruc == null ||
                                        g.Ruc == String.Empty
                                  select g).Count() > 0;
            if (hayElementosVacios)
            {
                throw new NullReferenceException("El Ruc no puede ser nulo o vacio");
            }
            // Recrear todos los valores con un ID nuevo Linq Funcional/Extension
            var data = companias.Select(g => new Compania
            {
                Id = Guid.NewGuid(),
                Ruc = g.Ruc,
                Calificacion = g.Calificacion
            });
            // Recrear todos los valores con un ID nuevo Linq Clasico
            data = from g in companias
                   select new Compania()
                   {
                       Id = Guid.NewGuid(),
                       Ruc = g.Ruc,
                       Calificacion = g.Calificacion,
                   };

            Db.Companias.AddRange(data);
            Db.SaveChanges();

        }

        public void UpdateCompania(Compania compania)
        {
            throw new NotImplementedException();
        }
    }
}

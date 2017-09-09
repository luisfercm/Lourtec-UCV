using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

        public bool DeleteCompania(Compania compania)
        {
            var c = Db.Companias.FirstOrDefault(g=>g.Id == compania.Id);
            try
            {
                Db.Companias.Remove(c);
                Db.SaveChanges();

                return true;
            }
            catch (Exception ex )
            {
                return false;
            }
        }


        public void TestMethod()
        {
            var testContext = new SqlAnalisisContexto();

          

            //System.Transactions; 
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {


                var q = Db.Companias;
                Db.SaveChanges();


                var q1 = Db.Companias;
                var c1 = q1.FirstOrDefault();
                c1.Ruc = "Nuevo";
                var c2 = new Compania() { Id = Guid.NewGuid() };
                Db.Companias.Add(c2);
                Db.SaveChanges();


                var q2 = Db.Companias;
                var c3 = q2.FirstOrDefault();
                Db.Companias.Remove(c3);
                Db.SaveChanges();



                 var aq = testContext.Rutas.Add(new Ruta() { Id = Guid.NewGuid() });
                 testContext.SaveChanges();

                    scope.Complete();

                }
                catch 
                {
                    scope.Dispose();
                }




            }

            

        }

        public List<Compania> GetCompanias()
        {

            List<Compania> companias = new List<Compania>();
            List<Viaje> viajes= new List<Viaje>();

            // var cutomCopaniaJoin = viajes.Join(companias, objViaje => objViaje.Compania.Ruc, objCompania => objCompania.Ruc, (objViaje, objCompania) => new { Ruc = objCompania.Ruc });

            //cutomCopaniaJoin = companias.Join(viajes,  objCompania => objCompania.Ruc, objViaje => objViaje.Compania.Ruc, (objCompania, objViaje)
            //  => new { Ruc = objViaje.Compania.Ruc });


            var CustSupJoin = viajes
                .Where(g => g.Id.ToString().Contains("Contoso"))
                .Join(companias.Where(g => g.Id.ToString().Contains("Smith")),
                sup => sup.Compania.Id,
                cust => cust.Id,
                (sup, cust) => new
                {
                    Country = sup.Id,
                    SupplierName = sup.Ruta,
                    CustomerName = cust.Calificacion
                });

            var query_where3 = from sup in viajes
                               join cust in companias
                               on sup.Compania.Id equals cust.Id
                               where sup.Id.ToString().Contains("Contoso")
                               where cust.Id.ToString().Contains("Smith")
                               select new
                               {
                                   Country = sup.Id,
                                   SupplierName = sup.Ruta,
                                   CustomerName = cust.Calificacion
                               };

 

            return Db.Companias.ToList();






         //   return Db.Companias.ToList().Select<>
        }

        public List<Compania> GetCompanias(string ruc)
        {
           return Db.Companias.Where(g => g.Ruc.Contains(ruc)).ToList();
        }

        public List<Compania> GetCompanias(string ruc, int calificacion)
        {
            return Db.Companias.Where(g => g.Ruc.Contains(ruc) && g.Calificacion > calificacion).ToList();
        }

        public Compania GetCompanias(Guid id)
        {
            return Db.Companias.FirstOrDefault(g => g.Id == id);
        }

        public List<Compania> GetCompanias(int calificacion)
        {
            return Db.Companias.Where(g =>  g.Calificacion > calificacion).ToList();
        }

        public void GetCompanias(string[] filtros, string valores)
        {
            var s = $"SELECT * FROM X WHERE";
            for (int i = 0; i < filtros.Length; i++)
            {
                s += $"{filtros[i]}={valores[i]}";
            }
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
            //Una coleccion de resultados o una coleccion de = elementos
            IEnumerable<Compania> collection= Db.Companias.Where(g => g.Id == compania.Id);

            // El primer elemento siempre
            //collection.FirstOrDefault();
            //Devuelve un unico elemento en una coleccion, si hay mas de uno devulve excepction 
            //collection.Single();


            // Firts or default puede devolver puede devolver un valor por defecto ya null o vacio
            Compania c = Db.Companias.FirstOrDefault(g => g.Id == compania.Id);

            // SIngle va arrojar una exception si no hay ningun resultado o 
            Compania single = Db.Companias.Single(g => g.Id == compania.Id);

            c.Ruc = compania.Ruc;
            c.Calificacion = compania.Calificacion;


            //Db.Entry(compania).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();


        }
    }
}

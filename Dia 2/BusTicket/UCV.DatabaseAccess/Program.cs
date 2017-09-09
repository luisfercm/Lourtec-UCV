using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UCV.Comun.Interfaces;
using UCV.Comun.Modelos;
using UCV.DatabaseAccess.Contextos;
using UCV.DatabaseAccess.Servicios;

namespace UCV.DatabaseAccess
{
    class Program
    {

        public static void TestingTXScopes()
        {
            var testContext = new SqlAnalisisContexto();
            var db = new SqlBusContexto();
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    var q = db.Companias;
                    db.SaveChanges();

                    var q1 = db.Companias;
                    var c1 = q1.FirstOrDefault();
                    c1.Ruc = "Nuevo";
                    var c2 = new Compania() { Id = Guid.NewGuid() };
                    db.Companias.Add(c2);
                    db.SaveChanges();


                    var q2 = db.Companias;
                    var c3 = q2.FirstOrDefault();
                    db.Companias.Remove(c3);
                    db.SaveChanges();

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

        public void TestingTXBeginEnd()
        {
            using (var context = new SqlBusContexto())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Database.ExecuteSqlCommand($"SELECT * FROM Companias");

                        var consulta = context.Companias;
                        foreach (var i in consulta)
                        {
                            i.Calificacion = 100000;
                        }
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }


        static void Main(string[] args)
        {
         //   TestMethod();


            var servicioCompania = new ServicioCompania();

            var compania = new Compania()
            {
                Ruc = $"Ruc Unico {new Random().Next(1, 10000).ToString()}",
                Calificacion = new Random().Next(1, 10)
            };

            var companias = new List<Compania>()
            {
                new Compania()
                {
                    Ruc = $"Ruc Masico Unico {new Random().Next(1, 10000).ToString()}",
                    Calificacion = new Random().Next(1, 10)
                },
            };

            try
            {
                servicioCompania.SaveCompania(compania);
                servicioCompania.SaveCompania(companias);
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo hacer un guardado: " + e.Message);
            }

            foreach (var c in servicioCompania.GetCompanias())
            {
                Console.WriteLine($"-- Registro ---");
                Console.WriteLine($"{c.Id}-{c.Ruc}-{c.Calificacion}");
            }

            var companiaSimple = servicioCompania.GetCompanias().FirstOrDefault();
            companiaSimple.Calificacion = 100;
            companiaSimple.Ruc += " Modificado 2";

            servicioCompania.UpdateCompania(companiaSimple);
            servicioCompania.DeleteCompania(companiaSimple);

            while (true)
            {
                if (Console.ReadLine() == "quit")
                {
                    break;
                }
            }
        }
    }
}
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Interfaces;
using UCV.Comun.Modelos;
using UCV.DatabaseAccess.Contextos;
using UCV.DatabaseAccess.Servicios;

namespace UCV.DatabaseAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            //var servicioCompania = new ServicioCompania();

            //IServicioCompania servicioCompania = new ServicioCompania();


            //var compania = new Compania()
            //{
            //    Ruc = $"Ruc Unico { new Random().Next(1, 1000000).ToString()}",
            //    Calificacion = new Random().Next(1, 10)
            //};



            //var companias = new List<Compania>() {
            //    new Compania() {
            //    Ruc= $"Ruc Unico { new Random().Next(1,1000000).ToString()}",
            //    Calificacion = new Random().Next(1,10)
            //},
            //    null,
            //  new Compania() {
            //    Ruc= String.Empty,
            //    Calificacion = 1
            //} };

            //try
            //{
            //    servicioCompania.SaveCompania(compania);
            //    servicioCompania.SaveCompania(companias);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("No se pudo guardar porque: " + e.Message);
            //}


            //foreach (var c in servicioCompania.GetCompanias())
            //{
            //    Console.WriteLine($"-- Registro --");
            //    Console.WriteLine($"{c.Id}-{c.Ruc}-{c.Calificacion}");

            //}


            using (var context = new SqlBusContexto()) {

                using (var dbContextTrasaccion = context.Database.BeginTransaction()) {

                    try
                    {
                        context.Database.ExecuteSqlCommand($"Select * from Compania");

                    }
                    catch 
                    {

                        throw;
                    }
                }
            }


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

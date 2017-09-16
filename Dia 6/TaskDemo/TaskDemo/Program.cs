using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static   void Main(string[] args)
        {

            //TaskASync();

            AsyncClass c = new AsyncClass();
            //c.Suma(1, 2);
             c.SumaAsync2(1, 2).Wait();
            

            Console.ReadKey();
        }


        public static void ParallelASync()
        {

        }

        public async static void TaskASync()
        {
            await  Task.Run(()=> 
            {
                Console.WriteLine("Antes de ejecutar 15 segundos");
              //  Task.Delay(15000);
                Console.WriteLine("Despues de ejecutar 15 segundos");
            });

            //Console.ReadKey();
        }


        public static void ParalleTask()
        {

            //while (true)
            //{
            //    Task.Run(()=>Console.WriteLine("X"));
            //    Task.Delay(10000).Wait();
            //}


            Parallel.Invoke(() => {
                Console.WriteLine("Metodo 1 " + DateTime.Now);
                Task.Delay(new Random().Next(1000, 10000));
                Console.WriteLine($"Termino metodo 1: {DateTime.Now.Millisecond}");
            },
                            () =>
                            {
                                Console.WriteLine("Metodo 2 " + DateTime.Now);
                                Task.Delay(new Random().Next(2000, 20000));
                                Console.WriteLine($"Termino metodo 2: {DateTime.Now.Millisecond}");
                            },
                                () => {
                                    Console.WriteLine("Metodo 3 " + DateTime.Now);
                                    Task.Delay(new Random().Next(3000, 30000));
                                    Console.WriteLine($"Termino metodo 3: {DateTime.Now.Millisecond}");

                                });

            Console.ReadKey();
        }

        public static void TaskTest()
        {
            System.Threading.CancellationToken x = new System.Threading.CancellationToken();

            Task task1 = new Task(() => {
                Console.WriteLine("Antes de Ejecutar 15 segundos");
                Task.Delay(15000).Wait();
                Console.WriteLine("Luego de Ejecutar 15 Segundos");
            }
            );
            task1.Start();
            var resultado = Task<string>.Run(() => {
                Console.WriteLine("Antes de Ejecutar 2");
                Task.Delay(10000).Wait();
                Console.WriteLine("Luego de Ejecutar 2");
                return "Hola Mundo";
            }).ContinueWith((q) => {
                Console.WriteLine("Antes de Ejecutar");
                Task.Delay(10000).Wait();
                Console.WriteLine("Luego de Ejecutar");
                return q + " Hola";
            });
            resultado.Wait();
            Console.WriteLine("Escribir por escribir");
            Console.WriteLine($"Resultado:{resultado.Result}");

            //task1.Start();
            Console.ReadKey();
        }
    }
}

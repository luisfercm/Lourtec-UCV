using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoException
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exception del sistema
            //var a = 0;
            //var b = 0;
            //var division = a / b;
            // System.DivideByZeroException

            // Crear el tipo de exception en un momento determinado

            // throw new System.DivideByZeroException();

            // Errores de personalizados de flujo de datos

            while (true)
            {

                var data = Console.ReadLine();

                // Pueden colocar los bloques try-catch
                // 1) Secciones especificas con errores de memoria o volatiles.
                // MemoryStream, HttpRequest, SqlServer, ADO.NET
                // 2) En secciones que instancian capas de servicios. Reciben errores personalizados
                // 3) un Try-catch generico en el flujo principal de UI.

                try
                {


                    switch (data)
                    {
                        case "1":
                            throw new System.Exception();
                        case "2":
                            throw new System.NullReferenceException();
                        case "3":
                            throw new System.NotFiniteNumberException();
                        case "4":
                            throw new LuisException();
                        default:
                            break;
                    }

                }
                // Mas especifica 
                catch (LuisException m)
                {
                    Console.WriteLine($"Mensaje:{m.Message}");
                    Console.WriteLine($"COD:{m.COD}");
                    Console.WriteLine($"MensajeSecreto:{m.MensajeSecreto}");
                }
                catch (NotFiniteNumberException ex)
                {
                    throw ex;
                }
                catch (NullReferenceException ex) {

                    Console.WriteLine($"Excepcion nulas:{ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadKey();
            }
        }
    }

    public class LuisException:Exception
        {

        public LuisException() : base()
        {

        }

        public LuisException(string message) : base( message)
        {

        }

        public string MensajeSecreto { get; set; }
        public string COD{ get; set; }

        public override string Message
        {
            get
            {
                MensajeSecreto = "Super error";
                return MensajeSecreto;
            }
        }

    }
}

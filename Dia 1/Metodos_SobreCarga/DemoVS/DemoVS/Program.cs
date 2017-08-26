using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoVS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola mundo");
            var programa = new Program();

            int num=0;
            var numero = programa.GetNumero(num);
            Execute();
            
            Console.ReadLine();
        }

        int GetNumero(out int nombre) {
            nombre = 10;
            return 5;
        }

        int GetNumero(int a , int b=0)
        {
            return a + b ;
        }
        static void Execute() {

        }
    }
}

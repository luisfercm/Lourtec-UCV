using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StaticClass
{

    static class TestA
    {
        public static int a;
        public static int b { get; set; }
        public static int c()
        {
            if (a == 0)
            {
                a = new Random().Next(1, 1000);
            }
            if (b == 0)
            {
                b = new Random().Next(100, 100000);
            }

            return a + b;
        }
    }

    class TestB
    {
        public int a;
        public int b { get; set; }
        public int c()
        {
            if (a == 0)
            {
                a = new Random().Next(1, 1000);
            }
            if (b == 0)
            {
                b = new Random().Next(100, 100000);
            }

            return a + b;
        }
    }

    class TestC
    {
        public static int a;
        public static int b { get; set; }
        public int c()
        {
            if (a == 0)
            {
                a = new Random().Next(1, 1000);
            }
            if (b == 0)
            {
                b = new Random().Next(100, 100000);
            }

            return a + b;
        }
        public static int d()
        {
            return new Random().Next(1, 1000) + new Random().Next(1, 1000);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"TestA:{TestA.c()} - Devuelve el mismo resultado cada vez");
                Console.WriteLine($"TestB:{new TestB().c()} Devuelve valores diferentes cada vez");
                Console.WriteLine($"TestC:{new TestC().c()} Debe ser instanciada cada vez pero valores son los mismos");
                Console.WriteLine($"TestD:{TestC.d()} No se debe instanciar por los valores se crean cada vez");
                Thread.Sleep(20000);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGenericAndExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //-- Herencia de genericos--
            TestA<string> a = new TestA<string>();
            a.Meta1 = "Hola";
            a.Meta2 = "Mundo";

            a.AddRange(new TestA<string>()
            {
                "a", "b", "c", "d"
            });

            List<string> b = new List<string>();
            var meta1 = "Hola";
            var meta2 = "Mundo";
            b.AddRange(new List<string>()
            {
                "a","b","c","d"
            });
            //-- Herencia de genericos--


            //-- Metodos de Extension--
            Cocinar cocina = new Cocinar();
            cocina.Freir();
            cocina.Hornear();
            cocina.Quemar();
            cocina.Hervir();

            int i = 99;
            i.Contar();
            float f = 99f;
            f.Dividir();

            CocinarExtensions.Division(f);
            //-- Metodos de Extension--

            var x = new TestB();
            x.Add("s");
            var y = new TestA<int>();
            var yy = new TestA<TestB>();
        }
    }

    // Herencia de Genericos
    public class TestA<T> : List<T>
    {
        public string Meta1 { get; set; }
        public string Meta2 { get; set; }
    }
    public class TestB : List<string>
    {

    }

    public partial class Cocinar
    {
        public List<string> Freir() { return new List<string>(); }
        public List<string> Hornear() { return new List<string>(); }
    }

    public class Z : Cocinar
    {
        public Z()
        {
        }
    }

    public static class CocinarExtensions
    {
        public static List<string> Hervir(this Cocinar c)
        {
            return new List<string>();
        }

        public static List<string> Servir(this Cocinar c)
        {
            return new List<string>();
        }

        public static void Contar(this int i)
        {

        }

        public static void Dividir(this float f)
        {

        }

        public static void Division(float f)
        {

        }
    }
}
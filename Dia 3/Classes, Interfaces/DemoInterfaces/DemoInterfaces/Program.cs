
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterfaces
{
    class Program
    {
        static IAnimal Animal { get; set; }
        public Program(IAnimal animal)
        {
            Animal = animal;
        }
        static void Main(string[] args)
        {
            GenericDemo gatos= new GenericDemo();

            foreach (var g in gatos)
            {
                g.Patas = 1;
            }


            Perro perro = new Perro();
            Gato gato = new Gato();
            Paloma rataAlada = new Paloma();
            perro.Ladrido();
            gato.Maullido();
            rataAlada.Gorgojeo();
            IAnimal animal = new Lobo();
            animal.Moverse();
            animal.Patas = 4;

            animal = new Perro();
            animal.Moverse();
            animal.Patas = 4;

            animal = new Paloma();

            animal = new Gato();


            foreach (var arg in args)
            {
                if (arg == "Perro") Animal = new Perro();
                if (arg == "Logo") Animal = new Lobo();
            }
            Animal.Patas = 3;
            Animal.Moverse();
            ((Lobo)Animal).Ladrido();
            // Las interfaces son de gran ayuda con dos conceptos
            // 1) Inversion de Control (IoC)
            // 2) Inyeccion de Dependencias (DI)

            IAnimalCompuesto x = new Paloma();
            x.Alas = 1;
            x.Patas = 2;
            x.Moverse();
        }
    }

    public class Perro : IAnimal
    {
        int IAnimal.Patas
        {
            get;
            set;
        }

        public void Ladrido()
        {

        }

        void IAnimal.Moverse()
        {

        }
    }

    public class Lobo : IAnimal
    {
        public int Patas { get; set; }
        public void Moverse() { }
        public void Ladrido()
        {

        }
    }

    public class Gato : IAnimal
    {
        public int Patas { get; set; }
        public void Moverse() { }
        public void Maullido()
        {

        }
    }

    // Ratas aladas.
    public class Paloma : IAnimalCompuesto
    {
        public int Patas { get; set; }
        int IAnimalAlado.Alas { get; set; }

        public void Moverse() { }
        public void Gorgojeo()
        {

        }
    }

    public interface IAnimal
    {
        int Patas { get; set; }
        void Moverse();
    }

    public interface IAnimalAlado
    {
        int Alas { get; set; }
    }
    public interface IAnimalCompuesto : IAnimal, IAnimalAlado
    {

    }
}
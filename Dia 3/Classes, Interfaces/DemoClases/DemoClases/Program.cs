using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoClases
{
    class Program
    {
        static void Main(string[] args)
        {
            // Abstrac Class
            //Beverage beverage = new Coffe();
            //beverage.Temp = 5;
            //beverage.Drink();
            //beverage.Components = new List<string>();

            //Beverage expresso = new Expresso();
            //expresso.Milk = 10;
            Coffe c = new Coffe(100, 30, "tostado");

            while (true)
            {
                c.Drink();
                Console.WriteLine($"Caffe restante:{c.Quantity}");
                Console.ReadKey();
            }
        }
    }

   abstract class Beverage
    {

        public Beverage()
        {
            Temp = 100;
            Quantity = 100;

        }

        public Beverage(float temp, int quantity)
        {
            Temp = temp;
            Quantity= quantity;
        }

       public  float Temp { get; set; }
        //internal
       public List<string> Components { get; set; }
       public virtual int Quantity { get; set; }

        public virtual void Drink() {
            Quantity--;
        }
    }


    class Coffe : Beverage
    {
        public Coffe():base()
        {
            Quantity = 10;
        }

        public Coffe(int quantity, float temp, string roastype) : base(temp, quantity)
        {
            this.RoastType = roastype;
        }

        public override int Quantity
        {
            //get { return 30; }
            get;set;
        }

        public virtual string CoffeType { get; set; }
        string RoastType { get; set; }

        public override void Drink()
        {
            Quantity -= 10;
            base.Drink();
            Quantity += 10;
        }
    }

    class Expresso:Coffe
    {
        public int Milk { get; set; }

        public sealed override string CoffeType
        {
            get => base.CoffeType;
            set => base.CoffeType = value;
        }
    }


    class CoffeExperiment : Expresso
    {
        //public override string CoffeType {
        //    get;set;
        //}
    }

    class Moka : Coffe
    {
        int chocolate;
    }


    class Tea: Beverage
    {

    }

}

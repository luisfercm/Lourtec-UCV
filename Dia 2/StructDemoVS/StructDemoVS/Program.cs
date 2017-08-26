using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemoVS
{
    class Program
    {
        static void Main(string[] args)
        {
            BillingDetails billing = new BillingDetails();
            billing.AccountNumber = "1234567890";
            billing.Name = "Moises Chirinos";

            Console.WriteLine("Nombre de cliente:"+ billing.Name);
            Console.WriteLine($"Numero de cuenta cliente:{ billing.AccountNumber}");

            Console.ReadKey();
        }
    }
}

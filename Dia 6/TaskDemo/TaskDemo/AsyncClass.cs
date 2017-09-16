using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    class AsyncClass
    {
        public   int Suma(int a, int b)
        {
            Console.WriteLine(a + b);
            return   a + b;
        }


        public async Task<int> SumaAsync2(int a, int b)
        {
            return await Task<int>.Run(() => { Console.WriteLine(a + b);  return Suma(a, b); });
        }

        public  Task<int> SumaAsync(int a, int b)
        {
            return  Task<int>.Run(() => { Console.WriteLine(a + b); return Suma(a, b); });
        }


    }
}

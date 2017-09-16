using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockDemo
{
    class Program
    {

        static void TEstLock()
        {

            lock(_object)
            {
                Task.Delay(10000).Wait();
            }
        }
        static void Main(string[] args)
        {


        }
    }
}

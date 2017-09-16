using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DemoTestAsync
{
    class TestClass
    {

        public void BlockMethod()
        {
            MessageBox.Show("Esto detiene todo");
            Thread.Sleep(10000);
        }

        public async void NonBlockMethod()
        {
            MessageBox.Show("No bloqueo");
            await Task.Delay(10000);
        }

        public Task NonBlockMethodAsync()
        {
            return Task.Run(()=>NonBlockMethod());
        }
    }
}

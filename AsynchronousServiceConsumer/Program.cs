using AsynchronousServiceConsumer.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            client.ServiceAsyncMethod("tt");
            client.SampleMethod("test");
            client.SampleMethodAsync("testAsync");
            Console.WriteLine("open");
            Console.ReadKey();
        }
    }
}

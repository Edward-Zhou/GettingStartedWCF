using GettingStartedOneWayClient.ServiceReference1;
using GettingStartedOneWayClient.ServiceReference3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedOneWayClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientBase<OneWayCalculatorClient>.CacheSetting = CacheSetting.Default;
            
            WSHttpBinding binding = new WSHttpBinding();
            EndpointAddress epAddress = new EndpointAddress("http://localhost:8000/oneway/service");
            OneWayCalculatorClient client = new OneWayCalculatorClient(binding,epAddress);
            
            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            client.Add(value1, value2);
            Console.WriteLine("Add({0},{1})", value1, value2);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1})", value1, value2);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1})", value1, value2);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1})", value1, value2);

            // Call the SayHello service operation
            string name = "World";
            string response = client.SayHello(name);
            Console.WriteLine("SayHello([0])", name);
            Console.WriteLine("SayHello() returned: " + response);

            CalculatorClient client1 = new CalculatorClient(binding, epAddress);
            client1.AddAsync(1,2);
            client1.Add(1, 2);

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();

        }
    }
}

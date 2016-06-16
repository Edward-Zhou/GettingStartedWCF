using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceCall
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceReference.WebService1SoapClient client = new WebServiceReference.WebService1SoapClient();
            Console.WriteLine(client.HelloWorld());
            Console.ReadLine();
        }
    }
}

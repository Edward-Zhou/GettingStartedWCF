using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WcfSelfHostWithAsyncMethod.ServiceReference1;

namespace WcfCallWithAsyncMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:808/Service1.svc");
            BasicHttpBinding binding = new BasicHttpBinding();
            Service1Client client = new Service1Client(binding,new EndpointAddress(uri));
            string result = client.TestAsyncMethod();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}

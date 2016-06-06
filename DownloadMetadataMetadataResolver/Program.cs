using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using DownloadMetadataMetadataResolver.ServiceReference1;

namespace DownloadMetadataMetadataResolver
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress metaAddress = new EndpointAddress(new Uri("http://localhost:1169/Service1.svc/mex"));
            ServiceEndpointCollection endpoints = MetadataResolver.Resolve(typeof(IService1), metaAddress);
            foreach (ServiceEndpoint point in endpoints)
            {
                if (point != null)
                {
                    using (Service1Client wcfClient = new Service1Client(point.Binding, point.Address))
                    {
                        Console.WriteLine(wcfClient.GetString(String.Format("binding is {0}, address is {1}",point.Binding,point.Address)));
                    }
                }

            }
            Console.ReadLine();

        }
    }
}

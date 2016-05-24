using AsynchronousService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:8080/AsynchronousService");
            ServiceHost host = new ServiceHost(typeof(Service1),address);
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            host.Description.Behaviors.Add(smb);
            host.Open();
            Console.WriteLine("The service is ready at {0}", address);
            Console.WriteLine("Press <Enter> to stop the service.");
            Console.ReadLine();

            // Close the ServiceHost.
            host.Close();

            
        }
    }
}

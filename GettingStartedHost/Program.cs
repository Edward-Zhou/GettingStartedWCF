using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GettingStartedLib;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;

namespace GettingStartedHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a Uri to serve as  the base address
            Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");
            //Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/Service");
            //create a ServiceHost instance
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            try
            {
                //add a  ServiceDiscoveryBehavior
                selfHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());

                selfHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());

                //add a service endpoint
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");
                //enable meta data exchange
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);
                //start service
                selfHost.Open();
                Console.WriteLine("The service is ready. ");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();


            }
            catch(CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();

            }
        }
    }
}

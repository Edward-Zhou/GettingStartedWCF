using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;


namespace GettingStartedDiscoveryProxyService
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("net.tcp://localhost:9002/CalculatorService/" + Guid.NewGuid().ToString());
            Uri announcementEndpointAddress = new Uri("net.tcp://localhost:9021/Announcement");
            //create service host
            ServiceHost host = new ServiceHost(typeof(CalculatorService),baseAddress);
            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            if (sdb == null)
            {
                host.Description.Behaviors.Add(
                    new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
            }
            else
            {
                if (!sdb.IncludeExceptionDetailInFaults)
                {
                    sdb.IncludeExceptionDetailInFaults = true;
                }
            }
            //try
            //{
                //add a service endpoint
                ServiceEndpoint netTcpEndpoint = host.AddServiceEndpoint(typeof(ICalculatorService),new NetTcpBinding(),string.Empty);
                //create an announcement endpoint, which points to the Announcement endpoint hosted by the proxy service
                AnnouncementEndpoint announcementEndpoint = new AnnouncementEndpoint(new NetTcpBinding(),new EndpointAddress(announcementEndpointAddress));
                //create a servicediscoveryBehavior and add the announcement endpoint
                ServiceDiscoveryBehavior serviceDiscoveryBehavior = new ServiceDiscoveryBehavior();
                serviceDiscoveryBehavior.AnnouncementEndpoints.Add(announcementEndpoint);
                //add the serviceDiscoveryBehavior to the service host to make the service discovnerable
                host.Description.Behaviors.Add(serviceDiscoveryBehavior);
                //start listening for messages
                host.Open();
                Console.WriteLine("Calculator Service started at {0}", baseAddress);
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();

                host.Close();
            //}
            //catch (CommunicationException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch (TimeoutException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //if (host.State != CommunicationState.Closed)
            //{
            //    Console.WriteLine("Aborting the service...");
            //    host.Abort();
            //}
        }
    }
}

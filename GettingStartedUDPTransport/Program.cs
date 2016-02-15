using GettingStartedUDPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedUDPTransport
{
    class Program
    {

        static void Main(string[] args)
        {
            string serviceAddress = "soap.udp://224.0.0.1:40000";
            UdpBinding myBinding = new UdpBinding();
            ServiceHost host = new ServiceHost(typeof(StockTickerService), new Uri(serviceAddress));
            host.AddServiceEndpoint(typeof(IStockTicker), myBinding, "");
            //ServiceMetadataBehavior smb = (ServiceMetadataBehavior)host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            ////if (smb == null)
            ////{
            ////    smb = new ServiceMetadataBehavior();
            ////    //smb.HttpGetEnabled = true;
            ////    host.Description.Behaviors.Add(smb);
            ////}
            //  if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            //      {
            //           ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            //           behavior.HttpGetEnabled = true;
            //           behavior.HttpGetUrl = new Uri("http://224.0.0.1:40000");
            //           host.Description.Behaviors.Add(behavior);
            //      }


            host.Open();
            Console.WriteLine("Start receiving stock information");
            Console.WriteLine("{0} is up and running with following endpoint(s)-", host.Description.ServiceType);
            Console.ReadLine();
        }
    }
}

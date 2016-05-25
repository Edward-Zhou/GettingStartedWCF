﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;

namespace DiscoveryProxyService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(DiscoveryProxy), new Uri("http://localhost:8080/DiscoveryProxy")))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);
                host.AddServiceEndpoint(typeof(IDiscoveryProxy),new BasicHttpBinding(),"");
                ServiceDiscoveryBehavior sdb = new ServiceDiscoveryBehavior();
                sdb.AnnouncementEndpoints.Add(new UdpAnnouncementEndpoint());
                host.Description.Behaviors.Add(sdb);
                host.AddServiceEndpoint(new UdpDiscoveryEndpoint());

                host.Open();
                Console.WriteLine("service is open");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}

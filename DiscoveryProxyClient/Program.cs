using DiscoveryProxyClient.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;

namespace DiscoveryProxyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //DiscoveryClient client = new DiscoveryClient(new UdpDiscoveryEndpoint());
            //FindResponse response = client.Find(new FindCriteria(typeof(myDiscoveryProxy)));
            //if (response.Endpoints.Count > 0)
            //{
            //    EndpointAddress address = response.Endpoints[0].Address;
            //    Console.WriteLine("service address is " + address);
            //    ServiceReference2.myDiscoveryProxyClient service = new ServiceReference2.myDiscoveryProxyClient(new BasicHttpBinding(), address);
            //    service.getString("discovery proxy");
            //}
            Console.WriteLine("app config for Discovery proxy");
            DiscoveryClient clientConfig = new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindResponse responseConfig = clientConfig.Find(new FindCriteria(typeof(ServiceReferenceAdHoc.IService1)) { Duration = TimeSpan.FromSeconds(60) });
            if (responseConfig.Endpoints.Count > 0)
            {
                EndpointAddress address = responseConfig.Endpoints[0].Address;
                Console.WriteLine("service address is " + address);
                ServiceReferenceAdHoc.Service1Client service = new ServiceReferenceAdHoc.Service1Client(new BasicHttpBinding(), address);
                Console.WriteLine(service.GetData(123));
            }
            Console.WriteLine("finish finding endpoint");
            Console.ReadLine();
            clientConfig.Close();
        }
    }

}

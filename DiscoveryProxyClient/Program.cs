using DiscoveryProxyClient.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
            #region ad-hoc
            //Console.WriteLine("app config for Discovery proxy");
            //DiscoveryClient clientConfig = new DiscoveryClient(new UdpDiscoveryEndpoint());
            //FindResponse responseConfig = clientConfig.Find(new FindCriteria(typeof(ServiceReferenceAdHoc.IService1)) { Duration = TimeSpan.FromSeconds(60) });
            //if (responseConfig.Endpoints.Count > 0)
            //{
            //    EndpointAddress address = responseConfig.Endpoints[0].Address;
            //    Console.WriteLine("service address is " + address);
            //    ServiceReferenceAdHoc.Service1Client service = new ServiceReferenceAdHoc.Service1Client(new BasicHttpBinding(), address);
            //    Console.WriteLine(service.GetData(123));
            //}
            //Console.WriteLine("finish finding endpoint");
            //Console.ReadLine();
            //clientConfig.Close();
            #endregion
            //Console.WriteLine("app config for Discovery proxy");
            //DiscoveryClient clientConfig = new DiscoveryClient(new UdpDiscoveryEndpoint());
            //FindResponse responseConfig = clientConfig.Find(new FindCriteria(typeof(WillServiceReference.ITest)) { Duration = TimeSpan.FromSeconds(10) });
            //if (responseConfig.Endpoints.Count > 0)
            //{
            //    EndpointAddress address = responseConfig.Endpoints[0].Address;
            //    Console.WriteLine("service address is " + address);
            //    WillServiceReference.TestClient service = new WillServiceReference.TestClient(new BasicHttpBinding(), address);
            //    Console.WriteLine(service.GetData("1"));
            //}
            //Console.WriteLine("finish finding endpoint");
            //Console.ReadLine();
            //clientConfig.Close();
            createChannelFactory();
        }
        public static void createChannelFactory()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(new Uri("http://10.168.197.122:8080/DiscoveryProxy"));
            Uri via = new Uri("http://10.168.197.122:8080/DiscoveryProxy/via");
            //ChannelFactory<ServiceReference2.myDiscoveryProxy> channelFactory = new ChannelFactory<myDiscoveryProxy>(binding);
            ServiceReference2.myDiscoveryProxyChannel channel = ChannelFactory<ServiceReference2.myDiscoveryProxyChannel>.CreateChannel(binding, address,via);
            channel.Open();
            Console.WriteLine(channel.getString("hello word"));
            Console.ReadLine();
            
        }
    }

}

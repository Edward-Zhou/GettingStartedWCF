using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChannelFactoryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress address = new EndpointAddress(new Uri("http://localhost:47718/Service1.svc"));
            WS2007HttpBinding binding = new WS2007HttpBinding();
            Uri via = new Uri("http://localhost:47718/Service1.svc/via");
            ChannelFactory<ChannelFactoryService.IService1Channel> channelFactory = new ChannelFactory<ChannelFactoryService.IService1Channel>(binding);
            ChannelFactoryService.IService1Channel channel = channelFactory.CreateChannel(address);
            channel.Open();
            Console.WriteLine(channel.GetData(123));
            Console.ReadLine();
        }
    }
}

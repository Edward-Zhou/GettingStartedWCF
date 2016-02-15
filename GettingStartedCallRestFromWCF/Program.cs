using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedCallRestFromWCF
{
    class Program
    {
        static readonly string RestServiceBaseAddress = "http://" + Environment.MachineName + ":8008/Service";
        static readonly string NormalServiceBaseAddress = "http://" + Environment.MachineName + ":8000/Service";
        [ServiceContract]
        public interface IRestInterface
        {
            [OperationContract, WebGet]
            int Add(int x, int y);
            [OperationContract, WebGet]
            string Echo(string input);
        }
        public class RestService : IRestInterface
        {
            public int Add(int x, int y)
            {
                return x + y;
            }
            public string Echo(string input)
            {
                return input;
            }
        }
        [ServiceContract]
        public interface INormalInterface
        {
            [OperationContract]
            int CallAdd(int x, int y);
            [OperationContract]
            string CallEcho(string input);
        }
        public class NormalService : INormalInterface
        {
            static MyRestClient client = new MyRestClient(RestServiceBaseAddress);
            public int CallAdd(int x, int y)
            {
                return client.Add(x,y);
            }
            public string CallEcho(string input)
            {
                return client.Echo(input);
            }
        }
        public class MyRestClient : ClientBase<IRestInterface>, IRestInterface
        {
            public MyRestClient(string address)
                : base(new WebHttpBinding(), new EndpointAddress(address))
            {
                this.Endpoint.Behaviors.Add(new WebHttpBehavior());
            }

            public int Add(int x, int y)
            {
                using (new OperationContextScope(this.InnerChannel))
                {
                    return base.Channel.Add(x,y);
                }
            }
            public string Echo(string input)
            {
                using (new OperationContextScope(this.InnerChannel))
                {
                    return base.Channel.Echo(input);
                }
            }
        }
        static void Main(string[] args)
        {
            ServiceHost restHost = new ServiceHost(typeof(RestService), new Uri(RestServiceBaseAddress));
            restHost.AddServiceEndpoint(typeof(IRestInterface),new WebHttpBinding(),"").Behaviors.Add(new WebHttpBehavior());
            restHost.Open();

            ServiceHost NormalHost = new ServiceHost(typeof(NormalService),new Uri(NormalServiceBaseAddress));
            NormalHost.AddServiceEndpoint(typeof(INormalInterface),new BasicHttpBinding(),"");
            NormalHost.Open();

            Console.WriteLine("Hosts open");

            ChannelFactory<INormalInterface> factory = new ChannelFactory<INormalInterface>(new BasicHttpBinding(),new EndpointAddress(NormalServiceBaseAddress));
            INormalInterface proxy = factory.CreateChannel();

            Console.WriteLine(proxy.CallAdd(123, 456));
            Console.WriteLine(proxy.CallEcho("Hello world"));

        }
    }
}

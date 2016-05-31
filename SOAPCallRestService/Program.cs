using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SOAPCallRestService
{
    class Program
    {
        static readonly string RestServiceAddress = "http://" + Environment.MachineName + ":8080/Service";
        static readonly string SoapServiceAddress = "http://" + Environment.MachineName + ":8000/Service";
        [ServiceContract]
        public interface IRestService
        {
            [OperationContract, WebGet]
            int Add(int x,int y);
            [OperationContract, WebGet]
            string Echo(string input);
        }
        public class RestService : IRestService
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
        public interface ISoapService
        {
            [OperationContract]
            int CallAdd(int x,int y);
            [OperationContract]
            string CallEcho(string input);
        }

        public class RestClient : ClientBase<IRestService>, IRestService
        {
            public RestClient(string address)
                : base(new WebHttpBinding(), new EndpointAddress(address))
            {
                this.Endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
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
        public class SoapService : ISoapService
        {
            static RestClient client = new RestClient(RestServiceAddress);
            public int CallAdd(int x, int y)
            {
                return client.Add(x,y);
            }
            public string CallEcho(string input)
            {
                return client.Echo(input);
            }
        }
        static void Main(string[] args)
        {
            ServiceHost restHost = new ServiceHost(typeof(RestService),new Uri(RestServiceAddress));
            ServiceEndpoint restSep= restHost.AddServiceEndpoint(typeof(IRestService),new WebHttpBinding(),"");
            restSep.EndpointBehaviors.Add(new WebHttpBehavior { HelpEnabled=true});
            restHost.Open();

            ServiceHost soapHost = new ServiceHost(typeof(SoapService),new Uri(SoapServiceAddress));
            ServiceEndpoint soapSep = soapHost.AddServiceEndpoint(typeof(ISoapService),new BasicHttpBinding(),"");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            soapHost.Description.Behaviors.Add(smb);
            soapHost.Open();

            Console.WriteLine("hosts opened");

            ChannelFactory<ISoapService> factory = new ChannelFactory<ISoapService>(new BasicHttpBinding(), new EndpointAddress(SoapServiceAddress));
            ISoapService proxy = factory.CreateChannel();

            Console.WriteLine(proxy.CallAdd(1,2));
            Console.WriteLine(proxy.CallEcho("hello word"));
            Console.ReadLine();
        }
    }
}

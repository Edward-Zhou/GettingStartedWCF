using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedExposeContract
{
    class Program
    {
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            [WebGet]
            string EchoWithGet(string s);

            [OperationContract]
            [WebInvoke]
            string EchoWithPost(string s);
        }
        public class Service : IService
        {
            public string EchoWithGet(string s)
            {
                return "You said " + s;
            }

            public string EchoWithPost(string s)
            {
                return "You said " + s;
            }
        }


        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Service),new Uri("http://localhost:8000/"));
            sh.AddServiceEndpoint(typeof(IService),new BasicHttpBinding(),"Soap");
            ServiceEndpoint endpoint = sh.AddServiceEndpoint(typeof(IService),new WebHttpBinding(),"Web");
            
            endpoint.Behaviors.Add(new WebHttpBehavior());

            //endpoint.EndpointBehaviors.Add(new WebHttpBehavior());

            foreach (IEndpointBehavior behavior in endpoint.Behaviors)
            {
                Console.WriteLine("Behavior: {0}", behavior.ToString());
            }
            sh.Open();
            using (WebChannelFactory<IService> wcf = new WebChannelFactory<IService>(new Uri("http://localhost:8000/web")))
            {
              
                IService channel = wcf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet by HTTP GET: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);

                Console.WriteLine("");
                Console.WriteLine("This can also be accomplished by navigating to");
                Console.WriteLine("http://localhost:8000/Web/EchoWithGet?s=Hello, world!");
                Console.WriteLine("in a web browser while this sample is running.");

                Console.WriteLine("");

                Console.WriteLine("Calling EchoWithPost by HTTP POST: ");
                s = channel.EchoWithPost("Hello, world");
                Console.WriteLine("   Output: {0}", s);
                Console.WriteLine();
            }
            using (ChannelFactory<IService> wcf = new ChannelFactory<IService>(new BasicHttpBinding(), "http://localhost:8000/Soap"))
            {
                IService channel = wcf.CreateChannel();
                string s;

                Console.WriteLine("Calling EchoWithGet on SOAP endpoint: ");
                s = channel.EchoWithGet("Hello, world");
                Console.WriteLine("   Output: {0}", s);

                Console.WriteLine("");

                Console.WriteLine("Calling EchoWithPost on SOAP endpoint: ");
                s = channel.EchoWithPost("Hello, world");
                Console.WriteLine("   Output: {0}", s);
                Console.WriteLine();
                Console.ReadLine();
            }
            sh.Close();
        }
    }
}

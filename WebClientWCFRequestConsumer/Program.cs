using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebClientWCFRequestConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            CallFromWCF();
            Console.ReadLine();
        }

        public static void CallFromWebClient()
        {
            string endpoint = "http://10.86.152.69/WcfService3/Service1.svc";
            string payload = System.IO.File.ReadAllText(@"D:\Sample\WCF\GettingStarted\WebClientWCFRequestConsumer\XMLFile1.xml");
            WebClient myWebClient = new WebClient();
            //myWebClient.Headers.Add("Content-Type", "application/soap+xml; charset=utf-8");
            myWebClient.UseDefaultCredentials = true;
            //myWebClient.Credentials = new NetworkCredential(@"domain\username","password");
            myWebClient.Headers.Add("Content-Type", "text/xml; charset=utf-8");
            //myWebClient.Headers.Add("SOAPAction", "\"http://tempuri.org/ICalculator/Add\"");
            var response = myWebClient.UploadString(endpoint, payload);
            Console.WriteLine(response);
            //byte[] byteArray = Encoding.ASCII.GetBytes(payload);
            //byte[] responseArray = myWebClient.UploadData(endpoint, "POST", byteArray);
            //Console.WriteLine("\nResponse received was {0}", Encoding.ASCII.GetString(responseArray));
            Console.ReadLine();
        }

        public static void CallFromWCF()
        {
            ServiceReference1.CalculatorClient client = new ServiceReference1.CalculatorClient();
            client.ClientCredentials.UserName.UserName = "test1";
            client.ClientCredentials.UserName.Password = "test1";
            client.Endpoint.Behaviors.Add(new InspectorBehavior());
            double result= client.Add(1,2);

            Console.WriteLine(result.ToString());
        }
        public class MyMessageInspector : IClientMessageInspector, IDispatchMessageInspector  
        {
            public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
            {
                Console.WriteLine("IClientMessageInspector AfterReceiveReply：\n{0}", reply.ToString()); 
                //throw new NotImplementedException();
            }

            public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
            {
                Console.WriteLine("IClientMessageInspector BeforeSendRequest：\n{0}", request.ToString());
                MessageHeader hdUserName = MessageHeader.CreateHeader("u","username","admin");
                MessageHeader hdPassWord = MessageHeader.CreateHeader("p","password","123");
                request.Headers.Add(hdUserName);
                request.Headers.Add(hdPassWord);
                Console.WriteLine("IClientMessageInspector BeforeSendRequest：\n{0}", request.ToString());
                return null;
            }

            object IDispatchMessageInspector.AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
            {
                Console.WriteLine("IDispatchMessageInspector.AfterReceiveRequest：\n{0}", request.ToString());
                string un = request.Headers.GetHeader<string>("u","username");
                string ps = request.Headers.GetHeader<string>("p","password");
                if (un == "admin" && ps == "123")
                {
                    Console.WriteLine("It is OK");
                }
                else
                {
                    Console.WriteLine("bad username or password");
                }
                return null;
            }

            void IDispatchMessageInspector.BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
            {
                Console.WriteLine("IDispatchMessageInspector.BeforeSendReply：\n{0}", reply.ToString());  
            }
        }
        public class InspectorBehavior : IEndpointBehavior
        {
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                clientRuntime.MessageInspectors.Add(new MyMessageInspector());
            }

            public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
                
            }

            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new MyMessageInspector());
            }

            public void Validate(ServiceEndpoint endpoint)
            {
                
            }
        }
    }
}

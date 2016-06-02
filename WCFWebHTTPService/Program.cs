using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
namespace WCFWebHTTPService
{
    class Program
    {
        static void Main(string[] args)
        {
            #region wcf web http service
            WebServiceHost host = new WebServiceHost(typeof(RestService), new Uri("http://localhost:8080/"));

            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IRestService), new WebHttpBinding(), "");
            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            sdb.HttpHelpPageEnabled = false;
            host.Description.Endpoints[0].EndpointBehaviors.Add(new WebHttpBehavior { HelpEnabled=true});

            host.Description.Behaviors.Add(new MyServiceBehavior());
            //ContractDescription cd = host.Description.Endpoints[0].Contract;
            //OperationDescription myOperationDescription = cd.Operations.Find("CreateStudent");
            //DataContractSerializerOperationBehavior serializerBehavior = myOperationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
            //if (serializerBehavior == null)
            //{
            //    serializerBehavior = new DataContractSerializerOperationBehavior(myOperationDescription);
            //    myOperationDescription.Behaviors.Add(serializerBehavior);
            //}
            //serializerBehavior.DataContractResolver = new SharedTypeResolver();


            host.Open();
            //Console.WriteLine("Service is running");
            //Console.WriteLine("Press enter to quit...");
            //Console.ReadLine();
            //host.Close();
            #endregion
            #region wcf web http service and soap service
            ServiceHost sh = new ServiceHost(typeof(RestService),new Uri("http://localhost:8090/"));
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            sh.Description.Behaviors.Add(smb);
            sh.AddServiceEndpoint(typeof(IRestService),new BasicHttpBinding(),"soap");
            ServiceEndpoint sep = sh.AddServiceEndpoint(typeof(IRestService), new WebHttpBinding(), "web");
            sep.EndpointBehaviors.Add(new WebHttpBehavior());
            sh.Open();
            Console.WriteLine("Service is running");
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
            sh.Close();
            host.Close();
            #endregion

        }
    }
}

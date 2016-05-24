using AuthenticateUserNamePasswordServiceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticateUserNamePasswordServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/AuthenticateUserNamePassword/Service");
            ServiceHost selfhost = new ServiceHost(typeof(Service1),baseAddress);
            try
            {
                ////add mex 
                //ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                //behavior.HttpGetEnabled = true;
                //selfhost.Description.Behaviors.Add(behavior);
                //selfhost.AddServiceEndpoint(typeof(IService1), MetadataExchangeBindings.CreateMexHttpBinding(), "http://localhost:8000/AuthenticateUserNamePassword/Service/mex/");

                //add username and password 
                WSHttpBinding wsbinding = new WSHttpBinding();
                wsbinding.Security.Mode = SecurityMode.Message;
                wsbinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

                selfhost.AddServiceEndpoint(typeof(IService1), wsbinding, "AuthenticateUserNamePassword");

                selfhost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine,StoreName.My,X509FindType.FindBySubjectName,"localhost");
                
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfhost.Description.Behaviors.Add(smb);
                selfhost.AddServiceEndpoint(typeof(IService1), MetadataExchangeBindings.CreateMexHttpBinding(), "http://localhost:8000/AuthenticateUserNamePassword/Service/mex");
                selfhost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfhost.Close();
            }
            catch (Exception ce)
            {

                Console.WriteLine("An exception occurred: {0}", ce.Message);

            }
        }
    }
}

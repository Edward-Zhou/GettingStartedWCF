using AuthenticateUserNamePassword.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticateUserNamePassword
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string username, password;
            GetPassword(out username,out password);

            Service1Client client = new Service1Client();
            //set username and password
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = password;

            //treat the test certificate as trusted
            client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.PeerOrChainTrust;


            string result=client.GetData(123);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        public static void GetPassword(out string username,out string password)
        {
            Console.WriteLine("Provide a valid machine or domain account. [domain\\user]");
            Console.WriteLine("   Enter username:");
            username = Console.ReadLine();
            Console.WriteLine("   Enter password:");
            password = Console.ReadLine();
            return;

        }
    }
}

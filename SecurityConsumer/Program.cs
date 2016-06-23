using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            SecurityMessageUsername.Service1Client client = new SecurityMessageUsername.Service1Client();
            client.ClientCredentials.UserName.UserName = "admin";
            client.ClientCredentials.UserName.Password = "123";
            Console.WriteLine(client.GetData(123));
            Console.ReadLine();
        }
    }
}

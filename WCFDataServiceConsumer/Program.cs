using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFDataServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            //ServiceReference1.CompositeType compositeType = new ServiceReference1.CompositeType();
            ////compositeType.uniqueId = (new System.Xml.UniqueId()).ToString();
            //var test = new System.Xml.UniqueId();
            //compositeType.MessageID =new ServiceReference1.UniqueId();
            //compositeType.MessageID.ExtensionData.ToString();
            //compositeType.BoolValue = true;
            //compositeType.StringValue = "test";
            //ServiceReference1.CompositeType result=client.GetDataUsingDataContract(compositeType);
            ServiceReference1.Person person = new ServiceReference1.Person();
            person.MessageId = new ServiceReference1.UniqueId();
            person.UserName = "test";
            ServiceReference1.Person result=client.GetPerson(person);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedOneWayServer
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IOneWayCalculator
    {
        [OperationContract(IsOneWay = true)]
        void Add(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Subtract(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Multiply(double n1, double n2);
        [OperationContract(IsOneWay = true)]
        void Divide(double n1, double n2);
        [OperationContract]
        string SayHello(string name);
    }
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class CalculatorService : IOneWayCalculator
    {
        public void Add(double n1, double n2)
        {
            Console.WriteLine("Received Add({0},{1}) - sleeping", n1, n2);
            System.Threading.Thread.Sleep(1000 * 5);
            double result = n1 + n2;
            Console.WriteLine("Processing Add({0},{1}) - result: {2}", n1, n2, result);
        }
        public void Subtract(double n1, double n2)
        {
            Console.WriteLine("Received Subtract({0},{1}) - sleeping", n1, n2);
            System.Threading.Thread.Sleep(1000 * 5);
            double result = n1 - n2;
            Console.WriteLine("Processing Subtract({0},{1}) - result: {2}", n1, n2, result);
        }
        public void Multiply(double n1, double n2)
        {
            Console.WriteLine("Received Multiply({0},{1}) - sleeping", n1, n2);
            System.Threading.Thread.Sleep(1000 * 5);
            double result = n1 * n2;
            Console.WriteLine("Processing Multiply({0},{1}) - result: {2}", n1, n2, result);
        }
        public void Divide(double n1, double n2)
        {
            Console.WriteLine("Received Divide({0},{1}) - sleeping", n1, n2);
            System.Threading.Thread.Sleep(1000 * 5);
            double result = n1 / n2;
            Console.WriteLine("Processing Divide({0},{1}) - result: {2}", n1, n2, result);
        }
        public string SayHello(string name)
        {
            Console.WriteLine("SayHello({0})", name);
            return "Hello " + name;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/oneway/service");
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                host.AddServiceEndpoint(typeof(IOneWayCalculator), new WSHttpBinding(), "");
                ServiceMetadataBehavior smb = (ServiceMetadataBehavior)host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb == null)
                {
                    smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    host.Description.Behaviors.Add(smb);
                }
                host.Open();
                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }
            
        }
    }
}

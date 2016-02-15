using GettingStartedTwoWayInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedTwoWayServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CalculatorService : ICalculatorDuplex
    {
        double result;
        string equation;
        ICalculatorDuplexCallback callback = null;

        public CalculatorService()
        {
            result = 0.0D;
            equation = result.ToString();
            callback = OperationContext.Current.GetCallbackChannel<ICalculatorDuplexCallback>();
        }

        public void Clear()
        {
            callback.Equation(equation + " = " + result.ToString());
            result = 0.0D;
            equation = result.ToString();
        }

        public void AddTo(double n)
        {
            result += n;
            equation += " + " + n.ToString();
            callback.Equals(result);
        }

        public void SubtractFrom(double n)
        {
            result -= n;
            equation += " - " + n.ToString();
            callback.Equals(result);
        }

        public void MultiplyBy(double n)
        {
            result *= n;
            equation += " * " + n.ToString();
            callback.Equals(result);
        }

        public void DivideBy(double n)
        {
            result /= n;
            equation += " / " + n.ToString();
            callback.Equals(result);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8000/twoway/service";
            ServiceHost host = new ServiceHost(typeof(CalculatorService),new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ICalculatorDuplex),new WSDualHttpBinding(),"");
            ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
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

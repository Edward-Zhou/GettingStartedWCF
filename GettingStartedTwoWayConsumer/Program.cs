using GettingStartedTwoWayConsumer.ServiceReference1;
//using GettingStartedTwoWayInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedTwoWayConsumer
{
    public class CallbackHandler : ICalculatorDuplexCallback
    {
        public void Equals(double result)
        {
            Console.WriteLine("Equals({0})", result);
        }

        public void Equation(string eqn)
        {
            Console.WriteLine("Equation({0})", eqn);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // Picks up configuration from the config file.

            CalculatorDuplexClient wcfClient
              = new CalculatorDuplexClient(new InstanceContext(new CallbackHandler()));
            try
            {
                // Call the AddTo service operation.
                double value = 100.00D;
                wcfClient.AddTo(value);

                // Call the SubtractFrom service operation.
                value = 50.00D;
                wcfClient.SubtractFrom(value);

                // Call the MultiplyBy service operation.
                value = 17.65D;
                wcfClient.MultiplyBy(value);

                // Call the DivideBy service operation.
                value = 2.00D;
                wcfClient.DivideBy(value);

                // Complete equation.
                wcfClient.Clear();

                // Wait for callback messages to complete before
                // closing.
                System.Threading.Thread.Sleep(5000);

                // Close the WCF client.
                wcfClient.Close();
                Console.WriteLine("Done!");
                Console.ReadLine();
            }
            catch (TimeoutException timeProblem)
            {
                Console.WriteLine("The service operation timed out. " + timeProblem.Message);
                wcfClient.Abort();
                Console.Read();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message);
                wcfClient.Abort();
                Console.Read();
            }


        }
    }
}

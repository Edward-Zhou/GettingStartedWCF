﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using GettingStartedHostDiscoveryClientApp.ServiceReference1;


namespace GettingStartedHostDiscoveryClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress endpointAddress = FindCalculatorServiceAddress();
            if (endpointAddress != null)
            {
                InvokeCalculatorService(endpointAddress);
            }

            Console.WriteLine("Press <ENTER> to exit.");
            Console.ReadLine();

        }
        static EndpointAddress FindCalculatorServiceAddress()
        {
            // Create DiscoveryClient
            DiscoveryClient disconveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());

            FindResponse findResponse = disconveryClient.Find(new FindCriteria(typeof(ICalculator)));

            if (findResponse.Endpoints.Count > 0)
            {
                return findResponse.Endpoints[0].Address;
            }
            else
            {
                return null;    
            }
        }
        static void InvokeCalculatorService(EndpointAddress endpointAddress)
        {
            //create a client
            CalculatorClient client = new CalculatorClient();
            client.Endpoint.Address = endpointAddress;
            Console.WriteLine("Invoking CalculatorService at {0}", endpointAddress);
            double value1 = 100.00D;
            double value2 = 15.99D;

            // Call the Add service operation.
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
            Console.WriteLine();

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();

            
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GettingStartedThrottlingService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Guid Ping();
    }
    public class Service1 : IService1
    {
        Guid sessionGuid = Guid.NewGuid();
        public Guid Ping()
        {
            Thread.Sleep(1*1000);
            return sessionGuid;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }
}

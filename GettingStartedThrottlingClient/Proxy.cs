using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedThrottlingClient
{
    public interface IServiceInterface
    {
        Guid Ping();
    }

    //public class Proxy : ClientBase<IService1>, IService1
    //{
    //    public Proxy(string endpointName)
    //        : base(endpointName)
    //    { }

    //    public Guid Ping()
    //    {
    //        return base.Channel.Ping();
    //    }
    //}
}

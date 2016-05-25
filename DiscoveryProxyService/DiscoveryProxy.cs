using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DiscoveryProxyService
{
    class DiscoveryProxy: IDiscoveryProxy
    {
        public string getString(string msg)
        {
            return msg;
        }
    }
    [ServiceContract(Name = "myDiscoveryProxy")]
    public interface IDiscoveryProxy
    {
        [OperationContract]
        string getString(string msg);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFWebHTTPServiceConsumer
{
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet]
        string WithGet(string s);
        [OperationContract]
        [WebInvoke]
        string WithPost(string s);
    }

    public class RestService : IRestService
    {
        public string WithGet(string s)
        {
            return "you get " + s;
        }
        public string WithPost(string s)
        {
            return "you post " + s;
        }
    }
}

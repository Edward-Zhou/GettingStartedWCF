using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

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
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "CreateStudent")]
        string CreateStudent(Student student);
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
        public string CreateStudent(Student student)
        {
            return student.FirstName + " " + student.LastName;
        }
    }
    [DataContract]
    public class Student
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}

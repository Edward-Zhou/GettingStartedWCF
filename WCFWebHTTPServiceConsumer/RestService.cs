using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

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
        [OperationContract]
       // [FaultContract(typeof(ErrorHandler))]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "CreateStudentObject")]
        string CreateStudentObject(Student student);
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
        public string CreateStudentObject(Student student)
        {
            //var obj = new JavaScriptSerializer().Serialize(student);
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Student));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, student);
            Console.WriteLine("\r\nUdemy.com - Serializing and Deserializing JSON in C#\r\n");
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            Console.WriteLine(sr.ReadToEnd());

            return sr.ReadToEnd();
        }

        public string CreateStudent(Student student)
        {
            try
            {
                return student.FirstName + " " + student.LastName;
            }
            catch (Exception e)
            {
                return null;//return returnError();//student.FirstName + " " + student.LastName;
            }

        }
        //public string returnError()
        //{
        //    ErrorHandler eh = new ErrorHandler { errorCode = 5, errorMessage = "test" };
        //    throw new WebFaultException<ErrorHandler>(eh, System.Net.HttpStatusCode.Forbidden);
        //}
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

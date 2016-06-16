using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Xml;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;


namespace WCFWebHTTPService
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
        [ValidateParameterInspector]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "CreateStudent")]
        string CreateStudent(Student student);
        [OperationContract]
        [FaultContract(typeof(ErrorHandler))]
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
            try {
                return student.FirstName + " " + student.LastName;
            }
            catch(Exception e)
            {
                 return returnError();//student.FirstName + " " + student.LastName;
            }
           
        }
        public string returnError()
        {
            ErrorHandler eh = new ErrorHandler { errorCode=5,errorMessage="test"};
            throw new WebFaultException<ErrorHandler>(eh,System.Net.HttpStatusCode.Forbidden);
        }
    }
    [DataContract]
    public class Student {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
    [DataContract]
    public class ErrorHandler
    {
        [DataMember]
        public int errorCode { get; set; }
        [DataMember]
        public string errorMessage { get; set; }
    }
}

public class MyErrorHandler : IErrorHandler
{
    public bool HandleError(Exception error)
    {
        return true;
    }
    public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
    {
        Message errormsg=fault;
        if (error.Message == "The data contract type 'WCFWebHTTPService.Student' cannot be deserialized because the data member 'FirstName' was found more than once in the input.")
        { 
           errormsg=Message.CreateMessage(version, "The reply action", error.Message);
        }
        fault = errormsg;
    }   

}
public class MyServiceBehavior : IServiceBehavior
{
    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
    {
    }
    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
        foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
        {
            channelDispatcher.ErrorHandlers.Add(new MyErrorHandler());
        }
    }
    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
    }   
}


public class SharedTypeResolver : DataContractResolver
{

    public override bool TryResolveType(Type dataContractType, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
    {

        if (!knownTypeResolver.TryResolveType(dataContractType, declaredType, null, out typeName, out typeNamespace))
        {

            XmlDictionary dictionary = new XmlDictionary();

            typeName = dictionary.Add(dataContractType.FullName);

            typeNamespace = dictionary.Add(dataContractType.Assembly.FullName);

        }

        return true;

    }



    public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
    {

        return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null) ?? Type.GetType(typeName + ", " + typeNamespace);

    }

}


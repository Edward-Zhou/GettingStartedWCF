using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

namespace WCFDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        [OperationContract]
        Person GetPerson(Person person);

        // TODO: Add your service operations here
    }
    public class Person
    {
        [XmlElement]
        public System.Xml.UniqueId MessageId { get; set; }
        [XmlElement]
        public string UserName { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";
        //public string messageID="";
        //[DataMember]
        //public string uniqueId 
        //{ 
        //    get{return messageID;}
        //    set{messageID=value;}
        //}
        //[DataMember]
        //public string uniqueId { get; set; }
        [XmlElement]
        public System.Xml.UniqueId MessageID
        {
            get;
            set;
        }
        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}

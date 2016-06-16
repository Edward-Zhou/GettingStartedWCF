using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
namespace WCFWebHTTPServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            #region web http service
            using (ChannelFactory<IRestService> cf = new ChannelFactory<IRestService>(new WebHttpBinding(), "http://localhost:8080/"))
            {
                cf.Endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                cf.Endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());
                IRestService channel = cf.CreateChannel();
                string s;
                Console.WriteLine("call WithGet");
                s = channel.WithGet("hello get");
                Console.WriteLine(s);
                Console.WriteLine("call WithPost");
                s = channel.WithPost("hello post");
                Console.WriteLine(s);
                Student student = new Student { FirstName = "Tom", LastName = "Jim" };
                s = channel.CreateStudent(student);
                Console.WriteLine(s);
                Console.ReadLine();
            }
            #endregion
            #region web http service and soap service
            using (WebChannelFactory<IRestService> wcf = new WebChannelFactory<IRestService>(new Uri("http://localhost:8090/web/")))
            {
                IRestService channel = wcf.CreateChannel();
                string s;
                Console.WriteLine("web http service call WithGet");
                s = channel.WithGet("web http service hello get");
                Console.WriteLine(s);
                Console.WriteLine("web http service call WithPost");
                s = channel.WithPost("web http service hello post");
                Console.WriteLine(s);
                Console.ReadLine();
            }
            using (ChannelFactory<IRestService> wcf = new ChannelFactory<IRestService>(new BasicHttpBinding(), "http://localhost:8090/soap/"))
            {
                IRestService channel = wcf.CreateChannel();
                string s;
                Console.WriteLine("soap service call WithGet");
                s = channel.WithGet("soap service hello get");
                Console.WriteLine(s);
                Console.WriteLine("soap service call WithPost");
                s = channel.WithPost("soap service hello post");
                Console.WriteLine(s);
                Console.ReadLine();
            }
            #endregion
        }
    }
}

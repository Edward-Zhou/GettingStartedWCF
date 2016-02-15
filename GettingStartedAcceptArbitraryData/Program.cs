using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedAcceptArbitraryData
{
    class Program
    {
        [ServiceContract]
        public interface IReceiveData
        {
            [WebInvoke(UriTemplate = "UploadFile/{fileName}")]
            void UploadFile(string fileName,Stream fileContents);
        }
        public class RawDataService : IReceiveData
        {
            public void UploadFile(string fileName, Stream fileContents)
            {
                byte[] buffer = new byte[10000];
                int bytesRead, totalBytesRead = 0;
                do
                {
                    bytesRead = fileContents.Read(buffer, 0, buffer.Length);
                    totalBytesRead += bytesRead;
                } while (bytesRead > 0);
                Console.WriteLine("Service: Received file {0} with {1} bytes", fileName, totalBytesRead);
            }
        }
        static void Main(string[] args)
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(RawDataService),new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IReceiveData),new WebHttpBinding(),"").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(baseAddress+"/UploadFile/Test.txt");
            req.Method = "POST";
            req.ContentType = "text/plain";
            Stream reqStream = req.GetRequestStream();
            byte[] fileToSend = new byte[12345];
            for (int i = 0; i < fileToSend.Length; i++)
            {
                fileToSend[i] = (byte)('a' + (i % 26));
            }
            reqStream.Write(fileToSend, 0, fileToSend.Length);
            reqStream.Close();
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Console.WriteLine("Client: Receive Response HTTP/{0} {1} {2}", resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
            Console.WriteLine();
            Console.ReadLine();
            host.Close();
        }
    }
}

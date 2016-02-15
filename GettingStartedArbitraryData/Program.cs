using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedArbitraryData
{
    class Program
    {
        [ServiceContract]
        public interface IImageServer
        {
            [WebGet]
            Stream GetImage(int width, int height);
        }

        public class Service : IImageServer
        {
            public Stream GetImage(int width, int height)
            {
                Bitmap bitmap = new Bitmap(width,height);
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        bitmap.SetPixel(i, j, (Math.Abs(i - j) < 2) ? Color.Blue : Color.Yellow);
                    }
                }
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Position = 0;
                WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
                return ms;
            }
        }
        static void Main(string[] args)
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service),new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IImageServer),new WebHttpBinding(),"Web").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Service is running");
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
}

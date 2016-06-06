
using DownloadMetadataMetadataExchangeClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace DownloadMetadataMetadataExchangeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("URI of the metadata documetns retreived");
            //MetadataExchangeClient metaTransfer = new MetadataExchangeClient(new Uri("http://localhost:1169/Service1.svc/mex"), MetadataExchangeClientMode.MetadataExchange);
            MetadataExchangeClient metaTransfer = new MetadataExchangeClient(new Uri("http://localhost:1169/Service1.svc"), MetadataExchangeClientMode.HttpGet);
            metaTransfer.ResolveMetadataReferences = true;
            MetadataSet metadata = metaTransfer.GetMetadata();
            foreach (MetadataSection doc in metadata.MetadataSections)
                Console.WriteLine(doc.Dialect + " : " + doc.Metadata);
            Console.ReadLine();
        }
    }
}

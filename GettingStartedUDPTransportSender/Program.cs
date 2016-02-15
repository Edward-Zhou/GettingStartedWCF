using GettingStartedUDPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace GettingStartedUDPTransportSender
{
    [DataContract(Namespace = "http://schemas.example.com")]
    public class DataStockInfo
    {
        [DataMember]
        public string Symbol;
        [DataMember]
        public float Price;
        public DataStockInfo(string symbol, float price)
        {
            this.Symbol = symbol;
            this.Price = price;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "soap.udp://224.0.0.1:40000";
            UdpBinding myBinding = new UdpBinding();
            ChannelFactory<IStockTicker> factory = new ChannelFactory<IStockTicker>(myBinding, new EndpointAddress(baseAddress));
            IStockTicker proxy = factory.CreateChannel();
            while (true)
            {
                // This will continue to mulicast stock information 
                proxy.SendStockInfo(GetStockInfo());
                int x = proxy.ResponseStockInfo(GetStockInfo());                
                Console.WriteLine(String.Format("sent stock info at {0}, the cound is {1}", DateTime.Now,x));
                // Wait for one second before sending another update
                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
            }
        }
        public static StockInfo[] GetStockInfo()
        {
            StockInfo[] stockInfo = new StockInfo[2];
            stockInfo[0] = new StockInfo("S1", 1);
            stockInfo[1] = new StockInfo("S2", 2);
            return stockInfo;
        }
        public static DataStockInfo[] GetDataStockInfo()
        {
            DataStockInfo[] dataStockInfo = new DataStockInfo[2];
            dataStockInfo[0] = new DataStockInfo("D1", 1);
            dataStockInfo[1] = new DataStockInfo("D2", 2);
            return dataStockInfo;
        }
    }
}

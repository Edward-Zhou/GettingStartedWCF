﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedUDPLib
{
    [ServiceContract]
    public interface IStockTicker
    {
        [OperationContract(IsOneWay = true)]
        void SendStockInfo(StockInfo[] stockInfo);

        [OperationContract]
        int ResponseStockInfo(StockInfo[] stockInfo);
    }
    [DataContract]
    public class StockInfo
    {
        [DataMember]
        public string Symbol;
        [DataMember]
        public float Price;
        public StockInfo(string symbol, float price)
        {
            this.Symbol = symbol;
            this.Price = price;
        }
    }
    public class StockTickerService : IStockTicker
    {
        public void SendStockInfo(StockInfo[] stockInfo)
        {
            Console.WriteLine(string.Format("Stock Name: 0, Price: $1"));
            foreach (StockInfo s in stockInfo)
            {
                Console.WriteLine(string.Format("Stock Name: {0}, Price: ${1}", s.Symbol, s.Price));
            }
        }

        public int ResponseStockInfo(StockInfo[] stockInfo)
        {
            return stockInfo.Count();
        }
    }
}

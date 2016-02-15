using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedThrottlingClient
{
    class Program
    {
        public static int Threads;
        public static int DoneThreads;
        public static int ErrorThreads;
        static void Main(string[] args)
        {
            Threads = 20;
            DoneThreads = 0;
            Console.ReadLine();
        }
        public delegate bool ThreadDelegate();
        public static void SpawnThreads(int threads)
        {
            for (int i = 0; i < threads; i++)
            {
                ThreadDelegate del = new ThreadDelegate(CallProxy);
                IAsyncResult result = del.BeginInvoke(delegate(IAsyncResult r)
                {
                    EndCall(del.EndInvoke(r));
                }, null);
            }
        }
        public static bool CallProxy()
        {
            try
            { 
                Console.WriteLine(new Proxy("ThrottleTcp").Ping());
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(-1);
                return false;
            }
        }
        public static void EndCall(bool result)
        {
            if (!result)
            {
                ErrorThreads++;
            }

            DoneThreads++;
            if (DoneThreads == Threads)
            {
                Console.WriteLine(string.Format("The {0} threads completed " +
                                  "of which {1} failed.", DoneThreads, ErrorThreads));
            }
        }

    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Web.UI;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace Tcc
{
    class Program
    {
        static void Main(string[] args)
        { 

            var orders = Order.GetOrders();

            var ordersConcat = orders.Concat(orders).Concat(orders);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var ordersGrouped = new List<Dictionary<string, List<int>>>();
   
            var dict = new Dictionary<string, List<int>>();
            foreach (var order in ordersConcat)
            {
                if (!dict.TryGetValue(order.country, out List<int> ids))
                {
                    dict[order.country] = ids = new List<int>();
                }
                ids.Add(order.id);
                
            }
            ordersGrouped.Add(dict);
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

        }
    }
}


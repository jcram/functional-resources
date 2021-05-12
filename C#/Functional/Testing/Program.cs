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

            TimeSpan tsTotal = new TimeSpan(0, 0, 0);

            for (int i = 0; i < 100; i++)  { 
                Stopwatch stopWatch = new Stopwatch();

                stopWatch.Start();

                var ordersGrouped = ordersConcat.
                    GroupBy(
                        order => order.country,
                        order => order.id).
                    ToDictionary(
                            group => group.Key,
                            group => group.ToList()
                        );

                stopWatch.Stop();

                                
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                tsTotal = tsTotal.Add(ts);

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime);
            }

           tsTotal = tsTotal.Divide(100);

            string elapsedTimeTotal = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                tsTotal.Hours, tsTotal.Minutes, tsTotal.Seconds,
                tsTotal.Milliseconds / 10);
            Console.WriteLine("RunTime media : " + elapsedTimeTotal);
        }
    }
}


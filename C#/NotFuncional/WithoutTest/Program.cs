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
            var ordersGrouped = new List<Dictionary<string, List<int>>>();
   
            var dict = new Dictionary<string, List<int>>();
            foreach (var order in Order.GetOrders())
            {
                if (!dict.TryGetValue(order.country, out List<int> ids))
                {
                    dict[order.country] = ids = new List<int>();
                }
                ids.Add(order.id);
                
            }
            ordersGrouped.Add(dict);
        }
    }
}

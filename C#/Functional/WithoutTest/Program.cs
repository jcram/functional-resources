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

	    var ordersGrouped = Order.GetOrders().
            GroupBy(
                 order => order.country,
                  order => order.id).
            ToDictionary(
                    group => group.Key,
                    group => group.ToList()
                 );
        }
    }
}

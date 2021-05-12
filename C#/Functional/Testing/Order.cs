using System;
using System.IO;
using System.Collections.Generic;
using System.Web.UI;
using Newtonsoft.Json;

namespace Tcc
{
    public class Order
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string country { get; set; }

        public Order()
        {
        }

        public static Order[] GetOrders()
        {
            var json = File.ReadAllText("orders.json");
            return  JsonConvert.DeserializeObject<Order[]>(json);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bdeli.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
}
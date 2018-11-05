using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bdeli.Models
{
    public class Booking
    {
        public string name { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public DateTime date { get; set; }
        public string time { get; set; }
        public int amount { get; set; }
        public string note { get; set; }
    }
}
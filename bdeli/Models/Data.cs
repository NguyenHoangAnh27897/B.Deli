using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bdeli.Models
{
    public class HomeMaster
    {
        public IQueryable<bD_Slide> slide { get; set; }
        public IQueryable<bD_Images> image { get; set; }

        public IQueryable<bD_Video> video { get; set; }
        public IQueryable<bD_Service> ser { get; set; }
        public IQueryable<bD_Contact> con { get; set; }
        public IQueryable<bD_Introduce> intro { get; set; }
        public IQueryable<bD_Settings> set { get; set; }
    }
}
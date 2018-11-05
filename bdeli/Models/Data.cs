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
        public IQueryable<bD_OpenTime> time { get; set; }
        public List<bD_Food> fod { get; set; }
        public List<bD_FoodType> typ { get; set; }
		public IQueryable<bD_Account> acc { get; set; }
    }
    public class GiftMaster
    {
       
        public List<bD_TypeGift> type { get; set; }
        public IEnumerable<bD_Gift> gift { get; set; }
    }

    public class Gift
    {
        public IQueryable<bD_Contact> con { get; set; }
        public List<bD_Gift> gft { get; set; }
        public List<bD_TypeGift> tpe { get; set; }
    }
    public class FoodMaster
    {
        public List<bD_FoodType> type { get; set; }
        public IEnumerable<bD_Food> food { get; set; }
    }

    public class AddToCart
    {
        public bD_Contact con { get; set; }

    }
}
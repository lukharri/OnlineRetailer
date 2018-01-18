using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRetailer.Models
{
    public class ItemThumbnailModel
    {
        public int ItemId { get; set; }
        public string ImageUrl { get; set; }
        public string Manufacturer { get; set; }
        public string ShortDescription { get; set; }
        public float SalePrice { get; set; }
        public float ListPrice { get; set; }
        public double Discount { get; set; }
    }
}
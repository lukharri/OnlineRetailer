using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRetailer
{
    public class ThumbnailModel
    {
        /*
         * Represents one item in the UI
         */
        public int ItemId { get; set; }
        public string ImageUrl { get; set; }
        public string Manufacturer { get; set; }
        public string ShortDescription { get; set; }
        public float ListPrice { get; set; }
        public float SalePrice { get; set; }
        public float Discount { get; set; }

    }
}
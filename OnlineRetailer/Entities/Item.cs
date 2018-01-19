using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OnlineRetailer.Entities
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Manufacturer Id")]
        public int ManufacturerId { get; set; }

        [Required]
        [DisplayName("Model Number")]
        public string ModelNumber { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        [DisplayName("UPC Code")]
        public string UPCCode { get; set; }

        [Required]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        [DisplayName("Long Description")]
        public string LongDescription { get; set; }

        [DisplayName("Image URL")]
        public string ImageURL { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("List Price")]
        public float ListPrice { get; set; }

        [Required]
        [DisplayName("Sale Price")]
        public float SalePrice { get; set; }

        public double Discount {
            get { return Math.Round((1 - (SalePrice / ListPrice)) * 100); }
            set { }
        }

        [DisplayName("In Stock")]
        public bool InStock { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DisplayName("Daily Special")]
        public bool IsDailySpecial { get; set; }
    }
}
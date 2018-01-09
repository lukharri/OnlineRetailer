using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineRetailer.Entities
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Manufacturer")]
        public int ManufacturerId { get; set; }

        [DisplayName("Manufactrers")]
        public ICollection<Manufacturer> Manufacturers { get; set; }

        [Required]
        [DisplayName("Model Number")]
        public string ModelNumber { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        [DisplayName("UPC Code")]
        public int UPCCode { get; set; }

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

        [Required]
        public float Discount {
            get { return SalePrice / ListPrice; } }

        [Required]
        [DisplayName("In Stock")]
        public bool InStock { get; set; }
    }
}
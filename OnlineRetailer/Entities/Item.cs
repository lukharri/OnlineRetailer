using System;
using System.Collections.Generic;
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
        public string Manufacturer { get; set; }

        [Required]
        public string ModelNumber { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public int UPCCode { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string LongDescription { get; set; }

        public string ImageURL { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public float ListPrice { get; set; }

        [Required]
        public float SalePrice { get; set; }

        [Required]
        public float Discount {
            get { return SalePrice / ListPrice; } }

        [Required]
        public bool InStock { get; set; }
    }
}
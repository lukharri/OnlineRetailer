using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineRetailer.Entities
{
    public class Watch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string ModelNumber { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public string BezelMaterial { get; set; }
        public int CastDiameter { get; set; }
        public string CaseMaterial { get; set; }
        public string CaseShape { get; set; }
        public float CaseThickness { get; set; }
        public string Crystal { get; set; }
        public string DialType { get; set; }
        public string Features { get; set; }
        public string Functions { get; set; }
        public string Gender { get; set; }
        public string Movement { get; set; }
        public string Style { get; set; }
        public int WaterResistance { get; set; }
        public string ProductCategory { get; set; }
        public int UPCCode { get; set; }
        public int MyProperty { get; set; }
        public string Warranty { get; set; }
        public string SKU { get; set; }
        
        [Required]
        public float SalePrice { get; set; }

        [Required]
        public float ListPrice { get; set; }

        [Required]
        public float Savings { get { return SalePrice / ListPrice; } }

        [Required]
        public bool InStock { get; set; }

    }
}
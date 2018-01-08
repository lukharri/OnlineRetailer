using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineRetailer.Entities
{
    public class ItemFeature
    {
        [Required]
        [Key, Column(Order = 1)]
        public int ItemId { get; set; }

        [Required]
        [Key, Column(Order = 2)]
        public int FeatureId { get; set; }

        [NotMapped]
        public int OldItemId { get; set; }

        [NotMapped]
        public int OldFeatureId { get; set; }
    }
}
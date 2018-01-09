using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OnlineRetailer.Areas.Admin.Models
{
    public class SmallButtonModel
    {
        public string Action { get; set; }
        public string Text { get; set; }
        public string Glyph { get; set; }
        public string ButtonType { get; set; }
        public int? Id { get; set; }
        public int? ItemId { get; set; }
        public int? FeatureId { get; set; }
        public int? PurchaseId { get; set; }
        public int? DetailId { get; set; }

        public string ActionParameters {
            get
            {
                var param = new StringBuilder("?");
                if (Id != null && Id > 0)
                    param.Append(String.Format("{0}={1}&", "id", Id));
                if (ItemId != null && ItemId > 0)
                    param.Append(String.Format("{0}={1}&", "itemId", ItemId));
                if (FeatureId != null && FeatureId > 0)
                    param.Append(String.Format("{0}={1}&", "featureiId", FeatureId));
                if (PurchaseId != null && PurchaseId > 0)
                    param.Append(String.Format("{0}={1}&", "purchaseId", PurchaseId));
                if (DetailId != null && DetailId > 0)
                    param.Append(String.Format("{0}={1}&", "detailId", DetailId));

                return param.ToString().Substring(0, param.Length - 1);
            }
        }


    }
}
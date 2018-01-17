using OnlineRetailer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OnlineRetailer.Extensions
{
    public static class ThumbnailExtensions
    {
        private static async Task<List<int>> GetItemIdsAsync(
            string itemId = null, ApplicationDbContext db = null)
        {
            try
            {
                if (itemId == null) return new List<int>();

                if (db == null) db = ApplicationDbContext.Create();

                return await (
                    from i in db.Items
                    where i.Id.Equals(itemId)
                    select i.Id).ToListAsync();

            }
            catch { }

            return new List<int>();
        }
    }
}
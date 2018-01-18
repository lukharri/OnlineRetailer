using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using OnlineRetailer.Areas.Admin.Models;
using OnlineRetailer.Entities;
using OnlineRetailer.Models;
using System.Data.Entity;

namespace OnlineRetailer.Areas.Admin.Extensions
{
    public static class ConversionExtensions
    {
        /*
         * Convert a collection of Items into a collection of ItemModels to display all the Items
         * in the Index view  
         */
        public static async Task<IEnumerable<ItemModel>> Convert(this IEnumerable<Item> items, ApplicationDbContext db)
        {
            if (items.Count().Equals(0))
                return new List<ItemModel>();

            var categories = await db.Categories.ToListAsync();
            var maunfacturers = await db.Manufacturers.ToListAsync();

            return from i in items
                   select new ItemModel
                   {
                       Id = i.Id,
                       ModelNumber = i.ModelNumber,
                       SKU = i.SKU,
                       UPCCode = i.UPCCode,
                       LongDescription = i.LongDescription,
                       ShortDescription = i.ShortDescription,
                       ImageURL = i.ImageURL,
                       ListPrice = i.ListPrice,
                       SalePrice = i.SalePrice,
                       Discount = i.Discount,
                       InStock = i.InStock,
                       Quantity = i.Quantity,
                       CategoryId = i.CategoryId,
                       ManufacturerId = i.ManufacturerId,
                       Manufacturers = maunfacturers,
                       Categories = categories
                   };
        }

        /*
         * Convert one Item into an ItemModel - used to display the details of an item 
         */
        public static async Task<ItemModel> Convert(this Item item, ApplicationDbContext db)
        {

            var categories = await db.Categories.FirstOrDefaultAsync(
                i => i.Id.Equals(item.CategoryId));
            var manufacturer = await db.Manufacturers.FirstOrDefaultAsync(
                i => i.Id.Equals(item.ManufacturerId));

            var model =  new ItemModel
                   {
                       Id = item.Id,
                       ModelNumber = item.ModelNumber,
                       SKU = item.SKU,
                       UPCCode = item.UPCCode,
                       LongDescription = item.LongDescription,
                       ShortDescription = item.ShortDescription,
                       ImageURL = item.ImageURL,
                       ListPrice = item.ListPrice,
                       SalePrice = item.SalePrice,
                       Discount = item.Discount,
                       InStock = item.InStock,
                       Quantity = item.Quantity,
                       CategoryId = item.CategoryId,
                       ManufacturerId = item.ManufacturerId,
                       Manufacturers = new List<Manufacturer>(),
                       Categories = new List<Category>()
                   };

            model.Manufacturers.Add(manufacturer);
            model.Categories.Add(categories);
            return (model);
        }
    }
}
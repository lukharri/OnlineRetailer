using OnlineRetailer.Areas.Admin.Extensions;
using OnlineRetailer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineRetailer.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Item
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> MensWatches()
        {
            var items = await db.Items.ToListAsync();
            var itemModels = await items.Convert(db);
            itemModels = itemModels.Where(i => i.Category == "Men's Watches");
            return View(itemModels);
        }

        public async Task<ActionResult> WomensWatches()
        {
            var items = await db.Items.ToListAsync();
            var itemModels = await items.Convert(db);
            itemModels = itemModels.Where(i => i.Category == "Women's Watches");
            return View(itemModels);
        }


        public async Task<ActionResult> Handbags()
        {
            var items = await db.Items.ToListAsync();
            var itemModels = await items.Convert(db);
            itemModels = itemModels.Where(i => i.Category == "Handbags");
            return View(itemModels);
        }


        public async Task<ActionResult> Sunglasses()
        {
            var items = await db.Items.ToListAsync();
            var itemModels = await items.Convert(db);
            itemModels = itemModels.Where(i => i.Category == "Sunglasses");
            return View(itemModels);
        }


        public async Task<ActionResult> EliniBarokas()
        {
            var items = await db.Items.ToListAsync();
            var itemModels = await items.Convert(db);
            itemModels = itemModels.Where(i => i.Manufacturer == "Elini Barokas");
            return View(itemModels);
        }


        public async Task<ActionResult> Invicta()
        {
            var items = await db.Items.ToListAsync();
            var itemModels = await items.Convert(db);
            itemModels = itemModels.Where(i => i.Manufacturer == "Invicta");
            return View(itemModels);
        }


        public async Task<ActionResult> LucienPicard()
        {
            var items = await db.Items.ToListAsync();
            var itemModels = await items.Convert(db);
            itemModels = itemModels.Where(i => i.Manufacturer == "LucienPicard");
            return View(itemModels);
        }


        public async Task<ActionResult> SwissLegend()
        {
            var items = await db.Items.ToListAsync();
            var itemModels = await items.Convert(db);
            itemModels = itemModels.Where(i => i.Manufacturer == "SwissLegend");
            return View(itemModels);
        }

    }
}
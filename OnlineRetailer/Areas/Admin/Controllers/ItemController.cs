using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineRetailer.Entities;
using OnlineRetailer.Models;
using OnlineRetailer.Areas.Admin.Extensions;
using OnlineRetailer.Areas.Admin.Models;

namespace OnlineRetailer.Areas.Admin.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Item
        public async Task<ActionResult> Index()
        {
            var items = await db.Items.ToListAsync();
            var model = await items.Convert(db);
            model = model.OrderBy(c => c.Manufacturer);
            return View(model);
        }


        // GET: Admin/Item/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            var itemModel = await item.Convert(db);
            return View(itemModel);
        }


        // GET: Admin/Item/Create
        public async Task<ActionResult> Create()
        {
            var model = new ItemModel
            {
                Manufacturers = await db.Manufacturers.ToListAsync(),
                Categories = await db.Categories.ToListAsync()
            };
            return View(model);
        }


        // POST: Admin/Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ManufacturerId,ModelNumber,SKU,UPCCode,ShortDescription,LongDescription,ImageURL,CategoryId,ListPrice,SalePrice,Quantity,InStock,IsDailySpecial")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }


        // GET: Admin/Item/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            var items = new List<Item>();
            items.Add(item);
            var itemModel = await items.Convert(db);

            return View(itemModel.FirstOrDefault());
        }


        // POST: Admin/Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ManufacturerId,ModelNumber,SKU,UPCCode,ShortDescription,LongDescription,ImageURL,CategoryId,ListPrice,SalePrice,Quantity,InStock,IsDailySpecial")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // ItemModel model = new ItemModel(item);
            var model = await item.Convert(db);
            return View(model);
        }


        // GET: Admin/Item/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            var itemModel = await item.Convert(db);
            return View(itemModel);
        }


        // POST: Admin/Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

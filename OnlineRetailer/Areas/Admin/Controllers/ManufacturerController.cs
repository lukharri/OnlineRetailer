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

namespace OnlineRetailer.Areas.Admin.Controllers
{
    public class ManufacturerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Manufacturer
        public async Task<ActionResult> Index()
        {
            return View(await db.Manufacturers.OrderBy(n => n.Name).ToListAsync());
        }

        // GET: Admin/Manufacturer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // GET: Admin/Manufacturer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Manufacturer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,BannerUrl,Summary")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                db.Manufacturers.Add(manufacturer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        // GET: Admin/Manufacturer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Admin/Manufacturer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,BannerUrl,Summary")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufacturer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        // GET: Admin/Manufacturer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Admin/Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            db.Manufacturers.Remove(manufacturer);
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

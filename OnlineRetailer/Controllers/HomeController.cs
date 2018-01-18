using OnlineRetailer.Areas.Admin.Extensions;
using OnlineRetailer.Areas.Admin.Models;
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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            var items = await db.Items.ToListAsync();
            var model = await items.Convert(db);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
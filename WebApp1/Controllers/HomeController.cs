using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Models;
using System.Data.Entity;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        ShopDbContext db = new ShopDbContext();
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Prices).Include(p => p.Category).ToList();
            return View(products);
            
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

        public ActionResult Service()
        {
            ViewBag.Message = "Your service page.";

            return View();
        }
    }
}
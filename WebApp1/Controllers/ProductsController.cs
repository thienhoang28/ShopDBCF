using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Models;
namespace WebApp1.Controllers
{
    public class ProductsController : Controller
    {
        ShopDbContext db = new ShopDbContext();
        // GET: Shop
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Prices).Include(p => p.Category).ToList();
            return View(products);
        }


        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            if(product == null)
			{
                return HttpNotFound();
			}
            
            return View(product);
        }

        //[HttpGet]
        public JsonResult GetProducts()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var result = db.Products.Include(p => p.Prices).Include(p => p.Category).ToList();
            db.Configuration.ProxyCreationEnabled = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
            db.Dispose();
		}
	}
}
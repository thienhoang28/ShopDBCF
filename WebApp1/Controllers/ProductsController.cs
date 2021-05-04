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
            
                //var products = db.Products.Include(p => p.Prices).Include(p => p.Category).ToList();
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

        [HttpPost]
        public ActionResult Index(string brand, string model, string priceFrom, string priceTo)
        {
            var products = db.Products.Include(p => p.Prices).Include(p => p.Category);
            int priceF = 0;
            int priceT = 0;
            

            if (String.Compare(priceFrom, "all") == 0)
            {
                priceF = 0;
            }
            else
            {
                priceF = int.Parse(priceFrom);
            }

            if(String.Compare(priceTo, "all") == 0)
            {
                priceT = 300000;
            }
            else
            {
                priceT = int.Parse(priceTo);
            }

            if(priceF > priceT)
            {
                priceT = 300000;
            }

            if(String.Compare(brand, "all") == 0 && String.Compare(model, "all") == 0)
            {
                var nprod = products.Where(p => (p.Prices.FirstOrDefault().Value >= priceF) && (p.Prices.FirstOrDefault().Value <= priceT));
                //return RedirectToAction("Index",nprod.ToList());
                return View(nprod.ToList());
            }
            else if(String.Compare(brand, "all") != 0 && String.Compare(model, "all") == 0)
            {
                var nprod = products.Where(p => (String.Compare(p.Category.Category_Name, brand) == 0) && (p.Prices.FirstOrDefault().Value >= priceF) && (p.Prices.FirstOrDefault().Value <= priceT));
                //return RedirectToAction("Index", nprod.ToList());
                return View(nprod.ToList());
            }
            else if(String.Compare(brand, "all") == 0 && String.Compare(model, "all") != 0)
            {
                var nprod = products.Where(p => (String.Compare(p.ModelCar, model) == 0) && (p.Prices.FirstOrDefault().Value >= priceF) && (p.Prices.FirstOrDefault().Value <= priceT));
                //return RedirectToAction("Index", nprod.ToList());
                return View(nprod.ToList());
            }
            else if(String.Compare(brand, "all") != 0 && String.Compare(model, "all") != 0)
            {
                var nprod = products.Where(p => (String.Compare(p.Category.Category_Name, brand) == 0) && (String.Compare(p.ModelCar, model) == 0) && (p.Prices.FirstOrDefault().Value >= priceF) && (p.Prices.FirstOrDefault().Value <= priceT));
                //return RedirectToAction("Index", nprod.ToList());
                return View(nprod.ToList());
            }
            else
            {
                //return RedirectToAction("Index",products.ToList());
                return View(products.ToList());
            }
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
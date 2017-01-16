using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webshop.Models;

namespace webshop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var products = db.Products;
            
            return View(products.ToList().OrderByDescending(p=>p.AddedToShop).Take(3));
        }

        public ActionResult Products()
        {
            ViewBag.Message = "a summary of all our products";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }


    }
}
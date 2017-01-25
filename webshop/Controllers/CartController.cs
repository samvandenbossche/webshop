using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webshop.Models;

namespace webshop.Controllers
{
    public class CartController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("~/Views/Cart/_CartSummaryPartial.cshtml");
        }

        public ActionResult AddToCart(long productId)
        {
            var product = db.Products.Single(p => p.ID == productId);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(product);

            // Go back to the main store page for more shopping
            //return RedirectToAction("Index");
            return Redirect(Request.UrlReferrer.ToString());
        }


        public JsonResult GetCartItems()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            return Json(cart.GetCartItems(), JsonRequestBehavior.AllowGet);
        }

        public int GetCartCount()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            return cart.GetCount();
        }

        public decimal getCartTotal()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            return cart.GetTotal();
        }

    }
}
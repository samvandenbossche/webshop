using Microsoft.AspNet.Identity;
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
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
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

            // Go back to the qfor more shopping
            return Redirect(Request.UrlReferrer.ToString());
        }

        public void ChangeQuantity(long productId, int quantity)
        {
            var product = db.Products.Single(p => p.ID == productId);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.ChangeQuantity(productId, quantity);

        }

        public void DeleteItem(long productId)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.RemoveFromCart(productId);

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

        public void ClearCart()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.EmptyCart();
        }


        public void CreateOrder()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            
                
            ApplicationUser user = UserManager.FindByNameAsync(User.Identity.Name).Result;

            /*TODO fill in this data*/
            var order = new Order();
            order.Adress = "";
            order.City = "";
            order.Country = "";
            order.Email = "";
            order.FirstName = "";
            order.LastName = "";
            order.PhoneNumber = "";

            /*remove or modify User in Model*/
            order.UserId = 1;
            order.User = user;
            order.PostalCode = "";


            cart.CreateOrder(order);

        }


    }
}
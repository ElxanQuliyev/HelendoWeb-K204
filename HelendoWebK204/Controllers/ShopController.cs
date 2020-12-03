using HelendoWebK204.Models;
using HelendoWebK204.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelendoWebK204.Controllers
{
    public class ShopController : Controller
    {
        HelendoDB db = new HelendoDB();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ShopController()
        {

        }
        public ShopController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

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

        public List<Product> FindProductByIDs(List<int> ids)
        {
            return db.Products.Where(x => ids.Contains(x.ID)).ToList();
        }
        // GET: Shop
        [Authorize]
        public ActionResult Checkout()
        {
            CheckoutVM vm = new CheckoutVM();
            var productIds = Request.Cookies["CartProduct"];
            if (productIds != null && !string.IsNullOrEmpty(productIds.Value))
            {
                //var id = productIds.Value.Split('-');
                //List<int> ids = id.Select(x=>int.Parse(x)).ToList();
                var ProductIDS = productIds.Value.Split('-').Select(x => int.Parse(x)).ToList();
                var productList = FindProductByIDs(ProductIDS);
                vm.Products = productList;
                vm.ProductIDS = ProductIDS;
                vm.User = UserManager.FindById(User.Identity.GetUserId());
            }
            return View(vm);
        }

        [HttpPost]

        public ActionResult PlaceOrder(string productIDs)
        {

            object result = null;
            var productQuantites = productIDs.Split('-').Select(x=>int.Parse(x)).ToList();
            var productBoughts = FindProductByIDs(productQuantites.Distinct().ToList());
            Order ord = new Order();
            ord.UserID = User.Identity.GetUserId();
            ord.PurchaseDate = DateTime.Now;
            ord.Status = "Pending";
            ord.TotalAmount = productBoughts.Sum(x => x.Price * productQuantites.Where(product => product == x.ID).Count());
            ord.OrderItems = new List<OrderItem>();
            ord.OrderItems.AddRange(productBoughts.Select(x => new OrderItem() { ProductID = x.ID, Quantity = productQuantites.Where(productID => productID == x.ID).Count() }));
            db.Orders.Add(ord);
            db.SaveChanges();
            result = new
            {
                success = true,

            };
            return Json(result);
        }





    }
}
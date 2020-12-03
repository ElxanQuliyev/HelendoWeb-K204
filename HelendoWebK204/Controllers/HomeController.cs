using HelendoWebK204.Models;
using HelendoWebK204.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HelendoWebK204.Controllers
{
    public class HomeController : Controller
    {
        HelendoDB db = new HelendoDB();
        public ActionResult Index()
        {
           
            HomeVM vm = new HomeVM()
            {
                Sliders = db.Sliders.ToList(),
                Products = db.Products.OrderByDescending(x => x.ID).ToList(),
                FeaturedProducts = db.Products.Where(x => x.IsFeatured).Take(3).OrderByDescending(x => x.ID).ToList()
            };
            return View(vm);
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
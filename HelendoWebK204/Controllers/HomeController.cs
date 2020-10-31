using HelendoWebK204.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelendoWebK204.Controllers
{
    public class HomeController : Controller
    {
        HelendoDB db = new HelendoDB();
        public ActionResult Index()
        {
            ViewBag.slider = db.Sliders.ToList();
            ViewBag.proList = db.Products.ToList();
            return View();
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
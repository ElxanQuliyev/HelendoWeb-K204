using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelendoWebK204.Areas.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        // GET: Dashboard/Home
        public ActionResult Index()
        {
            if (Session["ActiveAdmin"] == null) {
                return RedirectToAction("Login", "AdminAccount");
            }
            return View();
        }
    }
}
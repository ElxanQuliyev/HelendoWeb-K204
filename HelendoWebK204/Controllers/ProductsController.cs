using HelendoWebK204.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelendoWebK204.Controllers
{
    public class ProductsController : Controller
    {
        HelendoDB db = new HelendoDB();

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail (int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product selectedPro = db.Products.FirstOrDefault(p => p.ID == id);
            if (selectedPro == null)
            {
                return HttpNotFound();
            }
            ViewBag.proSingle = selectedPro;
            return View();
        }
    }
}
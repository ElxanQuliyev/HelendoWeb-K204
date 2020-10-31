using HelendoWebK204.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HelendoWebK204.Areas.Dashboard.Controllers
{
    public class AdminProductsController : Controller
    {
        HelendoDB db = new HelendoDB();
        // GET: Dashboard/AdminProducts
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Product product,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo file = new FileInfo(Photo.FileName);
                    string imgname = Guid.NewGuid() + file.Extension;
                    img.Save("~/Uploads/ProductImg/" + imgname);
                    product.ImageUrl= "/Uploads/ProductImg/" + imgname;
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }


    }
}
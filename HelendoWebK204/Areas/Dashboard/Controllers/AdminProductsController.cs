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
    [AdminFilterAccount]
    public class AdminProductsController : Controller
    {
        HelendoDB db = new HelendoDB();
        // GET: Dashboard/AdminProducts
        public ActionResult Index()
        {
            return View(db.Products.Where(x=>!x.ISDeleted).ToList());
        }

        public ActionResult Detail(int? id)
        {
            if (id == null) return HttpNotFound();

            Product selectedPro = db.Products.FirstOrDefault(x => x.ID == id);
            if (selectedPro == null) return HttpNotFound();

            return View(selectedPro);
        }

        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "Name");

            return View();
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
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
                ViewBag.CategoryList = db.Categories.ToList();
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "Name", product.categoryID);

            return View();
        }
        [HttpPost]
        public ActionResult Deleted(int? id)
        {
            object data = null;
            if (id == null)
            {
                data = new
                {
                    status = 404,
                    message="id not found",
                };
                return Json(data);
            }
            Product selectPro = db.Products.FirstOrDefault(x => x.ID == id);
            if (selectPro == null)
            {
                data = new
                {
                    status = 404,
                    message = "Product not found",
                };
                return Json(data);
            }
            data = new
            {
                status = 200,
                message = "success"
            };
            selectPro.ISDeleted = true;
            db.SaveChanges();
            return Json(data);
        }

    }
}
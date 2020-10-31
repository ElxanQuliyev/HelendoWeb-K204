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
    public class AdminSliderController : Controller
    {
        HelendoDB db = new HelendoDB();
        // GET: Dashboard/AdminSlider
        public ActionResult Index()
        {
            return View(db.Sliders.ToList());
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider sld,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo file = new FileInfo(Photo.FileName);
                    string imgname = Guid.NewGuid() + file.Extension;
                    img.Save("~/Uploads/SliderImg/" + imgname);
                    sld.ImageUrl = "/Uploads/SliderImg/" + imgname;
                }
                db.Sliders.Add(sld);
                db.SaveChanges();

                return RedirectToAction("index");
            }
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}
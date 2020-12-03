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
    public class AdminSlider2Controller : Controller
    {
        HelendoDB db = new HelendoDB();
        // GET: Dashboard/AdminSlider2
        public ActionResult Index()
        {
            return View(db.Sliders.ToList());
        }

        // GET: Dashboard/AdminSlider2/Details/5
        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return View("NotFound");
            }
            Slider selectedSlider = db.Sliders.FirstOrDefault(s => s.ID == id);
            if (selectedSlider == null)
            {
                return View("NotFound");
            }
            return View(selectedSlider);
        }
        public ActionResult NotFound()
        {
            return View();
        }
        // GET: Dashboard/AdminSlider2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/AdminSlider2/Create
        [HttpPost]
        public ActionResult Create(Slider slider,HttpPostedFileBase ImageUrl)
        {
            if (ImageUrl != null)
            {
                WebImage img = new WebImage(ImageUrl.InputStream);
                FileInfo file = new FileInfo(ImageUrl.FileName);
                string imgName = Guid.NewGuid() + file.Extension;
                img.Save("~/Uploads/SliderImg/" + imgName);
                slider.ImageUrl = "/Uploads/SliderImg/" + imgName;
                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Dashboard/AdminSlider2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/AdminSlider2/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/AdminSlider2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/AdminSlider2/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

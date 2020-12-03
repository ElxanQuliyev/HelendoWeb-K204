using HelendoWebK204.Models;
using System.Linq;
using System.Web.Mvc;

namespace HelendoWebK204.Areas.Dashboard.Controllers
{
    public class AdminAccountController : Controller
    {
        // GET: Dashboard/AdminAccount
        HelendoDB db = new HelendoDB();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(SettingsAdmin adm)
        {
            SettingsAdmin selectedAdmin = db.SettingsAdmins.FirstOrDefault(x => x.Email == adm.Email);
            if (selectedAdmin != null)
            {
                if (selectedAdmin.Password == adm.Password)
                {
                    Session["ActiveAdmin"] = selectedAdmin;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["ActiveAdmin"] = null;
            return RedirectToAction("Login");
        }

    }
}
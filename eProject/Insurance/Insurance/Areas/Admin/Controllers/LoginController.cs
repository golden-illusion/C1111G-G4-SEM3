using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model = Insurance.Areas.Admin.Models;
using Insurance.Models;
using Insurance.Areas.Admin.Models;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace Insurance.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        //
        // GET: /Admin/Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DoLogin(AdminLogin model)
        {
            if (ModelState.IsValid)
            {
                var admin = db.Admins.SingleOrDefault(adm => adm.UserName == model.UserName);
                if (admin != null)
                {
                    if (Misc.GetMd5Hash(model.Password).Equals(admin.Password))
                    {
                        Session["Admin"] = admin;
                        Session["SessionHash"] = Misc.GetMd5Hash(admin.AdminId + "-Insurance-" + admin.Password);
                        if (Session["PrevUrl"] != null)
                        {
                            return Redirect(Session["PrevUrl"].ToString());
                        }
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }
            string error = "Invalid User Name/Password";
            ModelState.AddModelError("", error);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
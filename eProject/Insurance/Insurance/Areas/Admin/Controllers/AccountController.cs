using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using model=Insurance.Areas.Admin.Models;
using Insurance.Models;

namespace Insurance.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        //
        // GET: /Admin/Account/

        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            Session["SessionHash"] = null;
            return RedirectToAction("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(model.Admin model)
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

        //
        // GET: /Admin/Account/Details/5

        public ActionResult Details(int id = 0)
        {
            model.Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // GET: /Admin/Account/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Account/Create

        [HttpPost]
        public ActionResult Create(model.Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        //
        // GET: /Admin/Account/Edit/5

        public ActionResult Edit(int id = 0)
        {
            model.Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Account/Edit/5

        [HttpPost]
        public ActionResult Edit(model.Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        //
        // GET: /Admin/Account/Delete/5

        public ActionResult Delete(int id = 0)
        {
            model.Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        //
        // POST: /Admin/Account/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            model.Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
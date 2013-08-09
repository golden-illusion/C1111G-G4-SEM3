using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurance.Models;

namespace Insurance.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class PolicyController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        //
        // GET: /Admin/Policy/

        public ActionResult Index()
        {
            return View(db.Policies.ToList());
        }

        //
        // GET: /Admin/Policy/Details/5

        public ActionResult Details(int id = 0)
        {
            Policy policy = db.Policies.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        //
        // GET: /Admin/Policy/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Policy/Create

        [HttpPost]
        public ActionResult Create(Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Policies.Add(policy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(policy);
        }

        //
        // GET: /Admin/Policy/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Policy policy = db.Policies.Find(id);
            if (policy == null)
            {
                return RedirectToAction("Index");
            }
            return View(policy);
        }

        //
        // POST: /Admin/Policy/Edit/5

        [HttpPost]
        public ActionResult Edit(Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(policy);
        }

        //
        // GET: /Admin/Policy/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Policy policy = db.Policies.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        //
        // POST: /Admin/Policy/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Policy policy = db.Policies.Find(id);
            db.Policies.Remove(policy);
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
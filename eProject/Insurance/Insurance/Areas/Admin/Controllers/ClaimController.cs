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
    //[AdminAuthorize]
    public class ClaimController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        //
        // GET: /Admin/Claim/

        public ActionResult Index()
        {
            var claims = db.Claims.Include(c => c.CustomerPolicy);
            return View(claims.ToList());
        }

        //
        // GET: /Admin/Claim/Details/5

        public ActionResult Details(int id = 0)
        {
            Claim claim = db.Claims.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        //
        // GET: /Admin/Claim/Create

        public ActionResult Create()
        {
            ViewBag.CustPolicyId = new SelectList(db.CustomerPolicies, "CustPolicyId", "CustPolicyId");
            return View();
        }

        //
        // POST: /Admin/Claim/Create

        [HttpPost]
        public ActionResult Create(Claim claim)
        {
            if (ModelState.IsValid)
            {
                db.Claims.Add(claim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustPolicyId = new SelectList(db.CustomerPolicies, "CustPolicyId", "CustPolicyId", claim.CustPolicyId);
            return View(claim);
        }

        //
        // GET: /Admin/Claim/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Claim claim = db.Claims.Find(id);
            
            if (claim == null)
            {
                return HttpNotFound();
            }
             
            ViewBag.CustPolicyId = new SelectList(db.CustomerPolicies, "CustPolicyId", "CustPolicyId", claim.CustPolicyId);
            return View(claim);
        }

        //
        // POST: /Admin/Claim/Edit/5

        [HttpPost]
        public ActionResult Edit(Claim claim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustPolicyId = new SelectList(db.CustomerPolicies, "CustPolicyId", "CustPolicyId", claim.CustPolicyId);
            return View(claim);
        }

        //
        // GET: /Admin/Claim/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Claim claim = db.Claims.Find(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        //
        // POST: /Admin/Claim/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Claim claim = db.Claims.Find(id);
            db.Claims.Remove(claim);
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
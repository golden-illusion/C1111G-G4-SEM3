using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurance.Models;
using WebMatrix.WebData;

namespace Insurance.Controllers
{
    public class ProductController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        //
        // GET: /Policy/Details/5

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
        // GET: /Policy/Create
        [Authorize]
        public ActionResult Buy(int? id = 0)
        {
            Policy policy = db.Policies.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            ViewBag.PolicyId = id;
            return View();
        }

        //
        // POST: /Policy/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(Vehicle vehicle, int policyId)
        {
            if (ModelState.IsValid)
            {
                vehicle.CustomerId = WebSecurity.GetUserId(User.Identity.Name);
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                CustomerPolicy customerPolicy = new CustomerPolicy();
                customerPolicy.StartDate = DateTime.Now.Date;
                customerPolicy.EndDate = DateTime.Now.AddDays(GetDuration(policyId));
                customerPolicy.VehicleId = vehicle.VehicleId;
                customerPolicy.PolicyId = policyId;
                db.CustomerPolicies.Add(customerPolicy);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(vehicle);
        }

        [NonAction]
        private int GetDuration(int policyId)
        {
            return db.Policies.Find(policyId).PolicyDuration;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
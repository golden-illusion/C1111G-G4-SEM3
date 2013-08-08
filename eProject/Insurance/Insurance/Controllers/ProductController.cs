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
        // GET: /Product/Index
        public ActionResult Index()
        {
            var policies = db.Policies.First();
            return View(policies);
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int? id = 0)
        {
            Policy policy = db.Policies.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        //
        // GET: /Product/Create
        [Authorize]
        public ActionResult Buy(int? id = 0)
        {
            Policy policy = db.Policies.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            Session["PolicyId"] = id;
            ViewBag.PolicyType = policy.PolicyType;
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.CustomerId = WebSecurity.GetUserId(User.Identity.Name);
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                CustomerPolicy customerPolicy = new CustomerPolicy();
                customerPolicy.StartDate = DateTime.Now.Date;
                customerPolicy.EndDate = DateTime.Now.AddDays(GetDuration(Int32.Parse(Session["PolicyId"].ToString())));
                customerPolicy.VehicleId = vehicle.VehicleId;
                customerPolicy.PolicyId = Int32.Parse(Session["PolicyId"].ToString());
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
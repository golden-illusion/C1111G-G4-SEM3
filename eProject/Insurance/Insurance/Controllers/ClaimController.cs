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
    [Authorize]
    public class ClaimController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        //
        // GET: /Claim/

        public ActionResult Index()
        {
            int customerId = WebSecurity.GetUserId(User.Identity.Name);
            var custPolicies = db.CustomerPolicies
                    .Include("Policy")
                    .Include("Vehicle")
                    .Where(cp => cp.Vehicle.CustomerId == customerId)
                    .OrderBy(cp => cp.StartDate);
            return View(custPolicies.ToList());
        }

        //
        // GET: /Claim/Create

        public ActionResult Create(int custPolicyId = 0)
        {
            CustomerPolicy custPolicy = db.CustomerPolicies.Find(custPolicyId);
            if (custPolicy == null)
            {
                return HttpNotFound();
            }
            Session["CustomerPolicyId"] = custPolicyId;
            return View();
        }

        //
        // POST: /Claim/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "InsuredAmount, ClaimableAmount")]Claim claim)
        {
            if (ModelState.IsValid)
            {
                claim.CustPolicyId = Int32.Parse(Session["CustomerPolicyId"].ToString());
                db.Claims.Add(claim);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(claim);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
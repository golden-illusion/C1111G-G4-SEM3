using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurance.Models;
using PagedList;
using PagedList.Mvc;

namespace Insurance.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class CustomerController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        //
        // GET: /Admin/Customer/

        public ActionResult Index(int page = 1)
        {
            PagedListRenderOptions options = new PagedListRenderOptions();
            options.MaximumPageNumbersToDisplay = 5;
            options.ContainerDivClasses = new string[] { "pagination" };
            options.DisplayPageCountAndCurrentLocation = true;
            ViewBag.Options = options;
            var customers = db.Customers.OrderByDescending(c => c.CustomerId);
            ViewBag.NumberOfCustomer = customers.Count<Customer>();
            return View(customers.ToPagedList(page, 2));
        }

        public ActionResult Search()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(int type, string keyword)
        {
            List<Customer> result = new List<Customer>();
            switch (type)
            {
                case 1:
                    result = db.Customers.Where(c => c.CustomerName.Contains(keyword)).Select(c => c).ToList();
                    break;
                case 2:
                    result = db.Customers.Where(c => c.UserName.Contains(keyword)).Select(c => c).ToList();
                    break;
                case 3:
                    result = db.Customers.Where(c => c.CustomerAddress.Contains(keyword)).Select(c => c).ToList();
                    break;
                case 4:
                    result = db.Customers.Where(c => c.CustomerPhone.Contains(keyword)).Select(c => c).ToList();
                    break;
                default:
                    result = db.Customers.ToList();
                    break;
            }
            ViewBag.NumberOfCustomer = result.Count<Customer>();
            return View("Index", result.ToPagedList(1, result.Count));
        }

        //
        // GET: /Admin/Customer/Details/5

        public ActionResult Details(int id = 0)
        {
            Customer customer = db.Customers.Include("Vehicles").FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        // GET: /Admin/Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Customer/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        //
        // GET: /Admin/Customer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        // POST: /Admin/Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        // GET: /Admin/Customer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        // POST: /Admin/Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
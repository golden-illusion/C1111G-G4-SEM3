using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurance.Areas.Admin.Models;
using Insurance.Models;
using PagedList;
using PagedList.Mvc;
using WebMatrix.WebData;

namespace Insurance.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class CustomerController : Controller
    {
        private InsuranceContext db = new InsuranceContext();
        private int RESULT_PER_PAGE = 20;
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
            ViewBag.ShowPagination = customers.Count() > RESULT_PER_PAGE ? true : false;
            return View(customers.ToPagedList(page, RESULT_PER_PAGE));
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
            CustomerEdit custEdit = new CustomerEdit();
            custEdit.Customer = customer;
            return View(custEdit);
        }

        //
        // POST: /Admin/Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(CustomerEdit customerEdit)
        {
            if (ModelState.IsValid)
            {
                Customer customer = customerEdit.Customer;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                var token = WebSecurity.GeneratePasswordResetToken(customer.UserName);
                var changed = WebSecurity.ResetPassword(token, customerEdit.Password);
                if (changed)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("pwd", "Failed to change customer's password");
            }

            return View(customerEdit);
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
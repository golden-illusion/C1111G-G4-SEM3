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
    public class VehicleController : Controller
    {
        private InsuranceContext db = new InsuranceContext();
        private int RESULT_PER_PAGE = 20;
        //
        // GET: /Admin/Vehicle/

        public ActionResult Index(int page = 1)
        {
            PagedListRenderOptions options = new PagedListRenderOptions();
            options.MaximumPageNumbersToDisplay = 5;
            options.ContainerDivClasses = new string[] { "pagination" };
            options.DisplayPageCountAndCurrentLocation = true;
            ViewBag.Options = options;
            var vehicles = db.Vehicles.Include(v => v.Customer).OrderByDescending(v => v.VehicleId);
            ViewBag.ShowPagination = vehicles.Count() > RESULT_PER_PAGE ? true : false;
            return View(vehicles.ToPagedList(page, RESULT_PER_PAGE));
        }

        public ActionResult Search()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(int type, string keyword)
        {
            List<Vehicle> result = new List<Vehicle>();
            var dbTemp = db.Vehicles.Include(v => v.Customer);
            switch (type)
            {
                case 1:
                    result = dbTemp.Where(v => v.VehicleName.Contains(keyword)).Select(v => v).ToList();
                    break;
                case 2:
                    result = dbTemp.Where(v => v.VehicleNumber.Contains(keyword)).Select(v => v).ToList();
                    break;
                case 3:
                    result = dbTemp.Where(v => v.VehicleModel.Contains(keyword)).Select(v => v).ToList();
                    break;
                case 4:
                    result = dbTemp.Where(v => v.VehicleBodyNumber.Contains(keyword)).Select(v => v).ToList();
                    break;
                case 5:
                    result = dbTemp.Where(v => v.VehicleEngineNumber.Contains(keyword)).Select(v => v).ToList();
                    break;
                case 6:
                    result = dbTemp.Where(v => v.Customer.CustomerName.Contains(keyword)).Select(v => v).ToList();
                    break;
                default:
                    result = dbTemp.ToList();
                    break;
            }
            ViewBag.Total = result.Count;
            return View("Index", result.ToPagedList(1, result.Count));
        }

        //
        // GET: /Admin/Vehicle/Details/5

        public ActionResult Details(int id = 0)
        {
            Vehicle vehicle = db.Vehicles.Include(v => v.Customer).SingleOrDefault(v => v.VehicleId == id);
            if (vehicle == null)
            {
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        //
        // GET: /Admin/Vehicle/Create

        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserName");
            return View();
        }

        //
        // POST: /Admin/Vehicle/Create

        [HttpPost]
        public ActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserName", vehicle.CustomerId);
            return View(vehicle);
        }

        //
        // GET: /Admin/Vehicle/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserName", vehicle.CustomerId);
            return View(vehicle);
        }

        //
        // POST: /Admin/Vehicle/Edit/5

        [HttpPost]
        public ActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "UserName", vehicle.CustomerId);
            return View(vehicle);
        }

        //
        // GET: /Admin/Vehicle/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        //
        // POST: /Admin/Vehicle/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
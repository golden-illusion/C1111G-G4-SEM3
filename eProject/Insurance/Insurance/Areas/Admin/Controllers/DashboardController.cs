using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace Insurance.Areas.Admin.Controllers
{

    [AdminAuthorize]
    public class DashboardController : Controller
    {
        //
        // GET: /Admin/Dashboard/

        
        public ActionResult Index()
        {
            return View();
        }

    }
}

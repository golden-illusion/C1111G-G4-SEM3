using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Insurance.Models;
using model = Insurance.Areas.Admin.Models;
namespace Insurance.Areas.Admin
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = httpContext.Session;

            if (httpContext.Request.RequestType == "GET"
                && !httpContext.Request.IsAjaxRequest())
            {
                session["PrevUrl"] = session["CurUrl"] ?? httpContext.Request.Url;
                session["CurUrl"] = httpContext.Request.Url;
            }

            if (session["Admin"] != null)
            {
                model.Admin admin = (model.Admin)session["Admin"];
                string sessionHash = session["SessionHash"].ToString();
                return Misc.GetMd5Hash(admin.AdminId + "-Insurance-" + admin.Password).Equals(sessionHash);
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Account",
                                action = "Login"
                            })
                        );
        }
    }
}
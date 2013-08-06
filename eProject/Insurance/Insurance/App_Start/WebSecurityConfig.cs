using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace InSurance.App_Start
{
    public class WebSecurityConfig
    {
        public static void RegisterWebSecurity()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Customers", "CustomerId", "UserName", autoCreateTables: true);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PushNotifictionTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IList<string>zaDevices=new List<string>(); 
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

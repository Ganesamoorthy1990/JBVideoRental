using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JBVideoRental
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customer_Details", action = "Login", id = UrlParameter.Optional }
             );


            routes.MapRoute(
                name: "AdminSubFolder",
                url: "admin/{controller}/{action}/{id}",
                defaults: new { controller = "Customer_Details", action = "Login", id = UrlParameter.Optional }
             );
        }
    }
}

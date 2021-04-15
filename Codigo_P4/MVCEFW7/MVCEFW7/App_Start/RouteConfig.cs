using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCEFW7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute(
           //    name: "Test",
           //    url: "Test",
           //    defaults: new { controller = "Home", action = "Contact"}
           //);

           // routes.MapRoute(
           //    name: "Persona",
           //    url: "Persona",
           //    defaults: new {
           //        controller = "Persona",
           //        action = "Index"
           //    }
           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

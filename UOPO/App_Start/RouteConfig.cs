using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UOPO
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            /* routes.MapRoute(
                name: "GroupCardsByRelease",
                url: "groupcards/release/{set}/{cardid}",
                defaults: new { controller = "GroupCards", action = "ByRelease" },
                constraints: new { set = @"\d{4}", cardid = @"\d{3}" });
            */
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VotingWebApp2._0
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Auditor",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Auditor", action = "Audit", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Voter",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Voter", action = "Vote", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
                );

            routes.MapRoute(
              name: "Admin",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
              );
            


            
        }
    }
}

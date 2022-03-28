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

            //routes.MapRoute(
            // name: "Voter",
            // url: "{Voter}",
            // defaults: new { controller = "Voter", action = "", id = UrlParameter.Optional }
            // );
            //routes.MapRoute(
            // name: "Auditor",
            // url: "{Auditor}",
            // defaults: new { controller = "Auditor", action = "", id = UrlParameter.Optional }
            // );
            routes.MapRoute(
              name: "Admin",
              url: "{Admin}/{action}/{id}",
              defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "Login",
              url: "{Login}/{action}/{id}",
              defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
              );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

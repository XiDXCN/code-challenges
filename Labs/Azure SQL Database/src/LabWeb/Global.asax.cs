﻿using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LabWeb
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Global filters
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            
            // Route configuration
            var routes = RouteTable.Routes;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Bundling configuration
            var bundles = BundleTable.Bundles;
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                   .Include("~/Scripts/bootstrap.js")
                   .Include("~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                   .Include("~/Content/bootstrap.css")
                   .Include("~/Content/site.css"));
        }
    }
}

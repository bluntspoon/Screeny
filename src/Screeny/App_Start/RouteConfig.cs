using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Screeny
{
  public class RouteConfig
  {
      public static void RegisterRoutes(RouteCollection routes)
      {
          routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
          routes.MapRoute("Default", "", new {controller = "Home", action = "Index"});
          routes.MapRoute("Upload", "Upload", new {controller = "Home", action = "Index"});
          routes.MapRoute("Browse", "Browse", new {controller = "Home", action = "Browse" });
      }
  }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelendoWebK204
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces:new string[] { "HelendoWebK204.Controllers" }

            );
            routes.MapRoute(
          name: "HomePage",
          url: "haqqimizda",
          defaults: new { controller = "Home", action = "about"},
          namespaces: new string[] { "HelendoWebK204.Controllers" }

      );
        }
    }
}

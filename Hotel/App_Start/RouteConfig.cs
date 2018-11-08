using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hoteles
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Inicio", action = "Inicio", id = UrlParameter.Optional }
            );

            routes.MapRoute("obtenerHabitaciones",
                            "obtenerHabitaciones/",
                            new { controller = "Inicio", action = "obtenerHabitaciones", id = UrlParameter.Optional },
                            new[] { "Hoteles.Controllers" });

            routes.MapRoute("obtenerDetalle",
                            "obtenerDetalle/",
                            new { controller = "Inicio", action = "obtenerDetalle", id = UrlParameter.Optional },
                            new[] { "Hoteles.Controllers" });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Area_Intro
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
                //1.Yapmanız gereken taraf hangi namespace gideceği,birden fazla kontrol ismi alabilir dizi tipinde
                //Ana projedeki homecontroller namespace'ini yapıştırdım buraya. 
                namespaces:new[] { "Area_Intro.Controllers" }
                //Namespaces içinde tırnaklar arasında boşluk bırakmadığınızdan emin olun.
            );
        }
    }
}

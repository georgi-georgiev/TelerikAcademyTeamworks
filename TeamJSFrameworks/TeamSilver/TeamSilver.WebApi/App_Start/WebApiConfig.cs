using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TeamSilver.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           // api/tags/{tagId}/posts

              config.Routes.MapHttpRoute(
                name: "categoriesApi",
                routeTemplate: "api/categories/{id}/{action}",
                defaults: new
                {
                    controller = "categories",
                    //action = "products"
                }
            );

            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/users/{action}",
                defaults: new { controller = "users" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

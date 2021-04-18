using ShopBridge.Filters;
using ShopBridge.Intefaces;
using ShopBridge.Models;
using ShopBridge.Services;
using System.Net.Http.Formatting;
using System.Web.Http;
using Unity;

namespace ShopBridge
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            // adding a action filter to validate the model values coming as input
            config.Filters.Add(new ValidateModelAttribute());

            // adding a Dependency Injection Resolver for Controller, Interface and Service class 
            var container = new UnityContainer();
            container.RegisterType<IInventoryItem, InventoryItemService>();
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

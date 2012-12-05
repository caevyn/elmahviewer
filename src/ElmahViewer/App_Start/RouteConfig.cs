using System.Web.Mvc;
using System.Web.Routing;

namespace ElmahViewer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            
            routes.MapRoute(
               name: "Default",
               url: "{applicationId}/{errorId}",
               defaults: new { controller = "ElmahViewer", action = "Index", applicationId=UrlParameter.Optional, errorId = UrlParameter.Optional });
        }
    }
}
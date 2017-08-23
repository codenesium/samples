using System.Web.Mvc;
using System.Web.Routing;

namespace sample1NS.Api.Service
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
			//the swagger controller is in Codenesium.Foundation.CommonMVC.MVC.
			//all it does is Redirect to /swagger
			//this allows us to redirect in a webapi project without a big mess
			routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Swagger", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
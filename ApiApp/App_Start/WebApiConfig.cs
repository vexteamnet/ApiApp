using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using ApiApp.Models;
using System.Web.OData.Routing.Conventions;
using System.Web.OData.Routing;

namespace ApiApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            // OData configuration
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Team>("Teams");
            // Add additional entity sets

            var model = builder.GetEdmModel();
            var conventions = ODataRoutingConventions.CreateDefaultWithAttributeRouting(config, model);
            // Add additional routing conventions

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: model,
                routingConventions: conventions,
                pathHandler: new DefaultODataPathHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

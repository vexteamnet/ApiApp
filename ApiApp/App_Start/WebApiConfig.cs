using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using VexTeamNetwork.Models;
using System.Web.OData.Routing.Conventions;
using System.Web.OData.Routing;
using Microsoft.OData.Edm.Library;
using System.Web.Http.Dispatcher;
using System.Web;

namespace ApiApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableSystemDiagnosticsTracing();
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //// OData configuration
            //ODataModelBuilder builder = new ODataConventionModelBuilder();

            //builder.Namespace = typeof(Team).Namespace;

            //builder.EntitySet<Team>("Teams")
            //    .EntityType
            //        .HasKey(t => t.Number);
            //builder.EntitySet<Event>("Events")
            //    .EntityType
            //        .HasKey(e => e.Sku)
            //        .ContainsMany(e => e.Divisions);
            //builder.EntityType<Division>()                
            //        .HasKey(d => d.EventSku)
            //        .HasKey(d => d.Name);
            //// Add additional entity sets


            //var model = builder.GetEdmModel();
            ///*
            //var events = (EdmEntitySet)model.EntityContainer.FindEntitySet("Events");
            //var divisions = (EdmEntitySet)model.EntityContainer.FindEntitySet("Divisions");
            //var divisionsProperty = new EdmNavigationPropertyInfo
            //{
            //    TargetMultiplicity = Microsoft.OData.Edm.EdmMultiplicity.Many,
            //    Target = (EdmEntityType)model.FindDeclaredType(typeof(Division).FullName),
            //    ContainsTarget = true,
            //    OnDelete = Microsoft.OData.Edm.EdmOnDeleteAction.Cascade,
            //    Name = "Divisions"
            //};
            //events.AddNavigationTarget(((EdmEntityType)model.FindDeclaredType(typeof(Event).FullName)).AddUnidirectionalNavigation(divisionsProperty), events);
            //*/
            //var conventions = ODataRoutingConventions.CreateDefaultWithAttributeRouting(config, model);
            //// Add additional routing conventions
            //conventions.Insert(0, new NavigationIndexRoutingConvention());

            //config.MapODataServiceRoute(
            //    routeName: "ODataRoute",
            //    routePrefix: null,
            //    model: model,
            //    routingConventions: conventions,
            //    pathHandler: new DefaultODataPathHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.EnableCaseInsensitive(true);


            //config.Services.Replace(typeof(IHttpControllerSelector), new HttpControllerSelector(config));
            //config.Services.Replace(typeof())
        }
    }
}

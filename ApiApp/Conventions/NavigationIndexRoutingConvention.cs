using System.Web.Http.Tracing;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;
using System.Web.Http;

namespace ApiApp.Conventions
{
    public class NavigationIndexRoutingConvention : EntitySetRoutingConvention
    {
        public override string SelectAction(ODataPath path, HttpControllerContext context, ILookup<string, HttpActionDescriptor> map)
        {
            
            context.Configuration.Services.GetTraceWriter().Info(context.Request, "ODataTracing", path.PathTemplate);
            if(context.Request.Method == HttpMethod.Get && path.PathTemplate == "~/entityset/key")
            {
                
                }
            //if (context.Request.Method == HttpMethod.Get &&
            //    path.PathTemplate == "~/entityset/key/navigation/key")
            //{
            //    NavigationPathSegment navigationSegment = path.Segments[2] as NavigationPathSegment;
            //    IEdmNavigationProperty navigationProperty = navigationSegment.NavigationProperty.Partner;
            //    IEdmEntityType declaringType = navigationProperty.DeclaringType as IEdmEntityType;

            //    string actionName = "Get" + declaringType.Name;
            //    if (map.Contains(actionName))
            //    {
            //        var keys = declaringType.DeclaredKey;
            //        // Add keys to route data, so they will bind to action parameters.
            //        KeyValuePathSegment keyValueSegment = path.Segments[1] as KeyValuePathSegment;
            //        context.RouteData.Values[ODataRouteConstants.Key] = keyValueSegment.Value;

            //        KeyValuePathSegment relatedKeySegment = path.Segments[3] as KeyValuePathSegment;
            //        context.RouteData.Values[ODataRouteConstants.RelatedKey] = relatedKeySegment.Value;

            //        return actionName;
            //    }
            //}
            //// Not a match.
            return null;
        }
    }
}

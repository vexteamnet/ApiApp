using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace ApiApp.Conventions
{
    public class HttpControllerSelector : DefaultHttpControllerSelector, IHttpControllerSelector
    {
        public HttpControllerSelector(HttpConfiguration config) : base(config) { }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            if (request.RequestUri.Segments.Length > 2 && Regex.Match(request.RequestUri.Segments[1], @"^[^(]{1,}\('[^)]{1,}'\)/$").Success)
                return base.GetControllerMapping()[Regex.Match(request.RequestUri.Segments[1], @"^[^(]{1,}").Value];
            return base.SelectController(request);
        }

        public override string GetControllerName(HttpRequestMessage request)
        {
            return base.GetControllerName(request);
        }
    }
}

using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;
using System.Web.OData;
using Ploeh.Hyprlinkr;
using ApiApp.Models.Core;
using System.Runtime.Caching;
using System;
using System.Dynamic;
using System.Web;
using System.Web.OData.Query;
using Microsoft.OData.Core.UriParser;
using System.Net.Http;

namespace ApiApp.Controllers
{
    public class TeamsController : ApiController
    {
        [Route("Teams"), EnableQuery(MaxTop = 400)]
        public IQueryable<Team> GetTeams(ODataQueryOptions queryOptions)
        {
            // Validate query options
            var settings = new ODataValidationSettings()
            {
                MaxTop = 400
            };
            queryOptions.Validate(settings);

            // Apply the filter before going through to check if links exist for significant performance improvements
            var teams = (IQueryable<Team>)queryOptions.ApplyTo(Db.core.Teams);

            // RouteLinker creates Uris for actions
            var linker = new RouteLinker(Request);

            foreach (var team in teams)
            {
                if (team.Links == null)
                {
                    team.Links = new SerializableDynamic();
                    team.Links.url = linker.GetUri<TeamsController>(c => c.GetTeam(team.Number)).ToString();
                }
            }

            var nextRequest = Request.RequestUri;
            

            return Db.core.Teams.AsQueryable();
        }

        [Route("Teams/{id}")]
        [ResponseType(typeof(SingleResult<Models.Core.Team>)), EnableQuery]
        public IHttpActionResult GetTeam(string id)
        {
            if (!Db.core.Teams.Any(t => t.Number == id))
                return NotFound();
            return Ok(SingleResult.Create(Db.core.Teams.Where(t => t.Number == id)));
        }
    }
}

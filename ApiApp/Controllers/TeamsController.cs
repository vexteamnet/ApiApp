using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;
using System.Web.OData;
using Ploeh.Hyprlinkr;
using ApiApp.Models.Core;

namespace ApiApp.Controllers
{
    public class TeamsController : ApiController
    {
        CoreContext db = new CoreContext();


        [ResponseType(typeof(IQueryable<Models.Core.Team>)), EnableQuery(PageSize = 400)]
        public IHttpActionResult GetTeams()
        {
            var linker = new RouteLinker(this.Request);

            return Ok(db.Teams.Cast<Models.Core.Team>().ForEach(t =>
                t.Links.AddRange(new List<Link>()
                {
                    new GetLink(Url.GetLink<TeamsController>(a => a.GetTeam(t.Number)).ToString())
                }))
                );
        }

        [ResponseType(typeof(SingleResult<Models.Core.Team>)), EnableQuery]
        public IHttpActionResult GetTeam(string id)
        {
            if (!db.Teams.Any(t => t.Number == id))
                return NotFound();
            return Ok(SingleResult.Create(db.Teams.Where(t => t.Number == id)));
        }
    }
}

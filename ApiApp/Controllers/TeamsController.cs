using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using VexTeamNetwork.Models;

namespace ApiApp.Controllers
{
    public class TeamsController : ApiController
    {
        CoreContext db = new CoreContext();

        [ResponseType(typeof(IQueryable<Team>)), EnableQuery(PageSize = 400)]
        public IHttpActionResult GetTeams()
        {
            return Ok(db.Teams.AsQueryable());
        }

        [ResponseType(typeof(SingleResult<Team>)), EnableQuery]
        public IHttpActionResult GetTeam(string id)
        {
            if (!db.Teams.Any(t => t.Number == id))
                return NotFound();
            return Ok(SingleResult.Create(db.Teams.Where(t => t.Number == id)));
        }
    }
}

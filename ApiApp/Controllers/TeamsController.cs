using ApiApp.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;

namespace ApiApp.Controllers
{
    public class TeamsController : ODataController
    {
        CoreContext db = new CoreContext();

        [EnableQuery, ResponseType(typeof(IQueryable<Team>))]
        public IHttpActionResult Get()
        {
            return Ok(db.Teams);
        }

        [EnableQuery, ResponseType(typeof(SingleResult<Team>))]
        public IHttpActionResult GetTeam([FromODataUri] string number)
        {
            return Ok(SingleResult.Create(db.Teams.Where(t => t.Number == number)));
        }

        bool TeamExists(string number)
        {
            return db.Teams.Any(t => t.Number == number);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

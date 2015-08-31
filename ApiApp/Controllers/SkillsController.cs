using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using VexTeamNetwork.Models;

namespace ApiApp.Controllers
{
    public class SkillsController : ApiController
    {
        private CoreContext db = new CoreContext();

        public SkillsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [Route("Events/{sku}/Skills"), ResponseType(typeof(IQueryable<Skills>)), EnableQuery(PageSize = 500)]
        public IHttpActionResult GetSkillsByEvent([FromUri] string sku, [FromUri] SkillsType? type = null)
        {
            if (!db.Events.Any(e => e.Sku == sku))
                return NotFound();

            return Ok(db.Skills.Where(s => s.EventSku == sku && (!type.HasValue || s.Type == type.Value)));
        }

        [Route("Teams/{number}/Skills"), ResponseType(typeof(IQueryable<Skills>)), EnableQuery(PageSize = 500)]
        public IHttpActionResult GetSkillsByTeam([FromUri] string number, [FromUri] SkillsType? type = null)
        {
            if (!db.Teams.Any(t => t.Number == number))
                return NotFound();

            return Ok(db.Skills.Where(s => s.TeamNumber == number && (!type.HasValue || s.Type == type.Value)));
        }

        [Route("Events/{sku}/Skills/{number}"), ResponseType(typeof(IQueryable<Skills>)), EnableQuery(PageSize = 500)]
        public IHttpActionResult GetSkillsByEventAndTeam([FromUri] string sku, [FromUri] string number)
        {
            if (!db.Events.Any(e => e.Sku == sku) || !db.Teams.Any(t => t.Number == number))
                return NotFound();

            return Ok(db.Skills.Where(s => s.TeamNumber == number && s.EventSku == sku));
        }

        [Route("Events/{sku}/Skills/{number}"), ResponseType(typeof(SingleResult<Skills>)), EnableQuery]
        public IHttpActionResult GetSkills([FromUri] string sku, [FromUri] string number, [FromUri] SkillsType type)
        {
            if (!db.Events.Any(e => e.Sku == sku) || !db.Teams.Any(t => t.Number == number))
                return NotFound();

            return Ok(db.Skills.Where(s => s.TeamNumber == number && s.EventSku == sku && s.Type == type));
        }
    }
}
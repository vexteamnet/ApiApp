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
    public class AwardsController : ApiController
    {
        private CoreContext db = new CoreContext();

        public AwardsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [Route("Events/{sku}/Awards")]
        [ResponseType(typeof(IQueryable<Award>)), EnableQuery(PageSize = 500)]
        public IHttpActionResult GetAwardsByEvent([FromUri] string sku)
        {
            if (!db.Events.Any(e => e.Sku == sku))
                return NotFound();
            return Ok(db.Awards.Include("QualifiesFor").Where(a => a.EventSku == sku));
        }

        [Route("Teams/{team}/Awards")]
        [ResponseType(typeof(IQueryable<Award>)), EnableQuery(PageSize = 500)]
        public IHttpActionResult GetAwardsByTeam([FromUri] string team, [FromUri] bool currentSeason = true)
        {
            if (!db.Teams.Any(t => t.Number == team))
                return NotFound();
            return Ok(db.Awards.Include("QualifiesFor").Where(a => a.TeamNumber == team));
        }

        [Route("Events/{sku}/Qualified")]
        [ResponseType(typeof(IQueryable<Award>)), EnableQuery(PageSize = 500)]
        public IHttpActionResult GetAwardsByQualification([FromUri] string sku)
        {
            if (!db.Events.Any(e => e.Sku == sku))
                return NotFound();
            return Ok(db.Awards.Where(a => a.QualifiesFor.Any(e => e.Sku == sku)));
        }

        [Route("Events/{sku}/Awards/{team}"), Route("Teams/{team}/Awards/{sku}")]
        [ResponseType(typeof(IQueryable<Award>)), EnableQuery]
        public IHttpActionResult GetAwards([FromUri] string sku, [FromUri] string team, [FromUri] DateTime? start = null, [FromUri] DateTime? end = null, [FromUri] string season = null)
        {
            if (!db.Awards.Any(a => a.EventSku == sku && a.TeamNumber == team))
                return NotFound();

            if(!string.IsNullOrEmpty(season) && db.Seasons.Any(s => s.Name == season))
            {
                var _season = db.Seasons.Where(s => s.Name == season).Single();
                start = _season.Start;
                end = _season.End;
            }

            var result = db.Awards.Include(nameof(Award.QualifiesFor)).Where(a => a.EventSku == sku && a.TeamNumber == team);
            if (start != null)
                throw new NotImplementedException("Start/end parameters not yet implemented on any controller.");
            if (end != null)
                throw new NotImplementedException("Start/end parameters not yet implemented on any controller.");

            return Ok(result);
        }

        [Route("Events/{sku}/Awards/{team}"), Route("Teams/{team}/Awards/{sku}")]
        [ResponseType(typeof(SingleResult<Award>)), EnableQuery]
        public IHttpActionResult GetAward([FromUri] string sku, [FromUri] string team, [FromUri] string name)
        {
            if (!db.Awards.Any(a => a.EventSku == sku && a.TeamNumber == team && a.Name == name))
                return NotFound();
            return Ok(SingleResult.Create(db.Awards.Include("QualifiesFor").Where(a => a.EventSku == sku && a.TeamNumber == team && a.Name == name)));
        }
    }
}
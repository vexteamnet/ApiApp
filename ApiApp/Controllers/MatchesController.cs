using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using ApiApp.Models.Core;

namespace ApiApp.Controllers
{
    public class MatchesController : ApiController
    {
        private CoreContext db = new CoreContext();

        public MatchesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [ResponseType(typeof(IQueryable<Match>)), Route("Events/{sku}/Matches"), EnableQuery(PageSize = 250)]
        public IHttpActionResult GetMatchesByEvent([FromUri] string sku, [FromUri] string team = null)
        {
            if (!db.Events.Any(e => e.Sku == sku))
                return NotFound();

            if (!string.IsNullOrEmpty(team))
            { // Team parameter is given
                if (!db.Teams.Any(t => t.Number == team))
                    return NotFound();

                return Ok(from m in db.Matches
                          where m.EventSku == sku && 
                          ( // Don't need to include sit teams because they're also either 1/2/3
                          m.Blue1Number == team ||
                          m.Blue2Number == team ||
                          m.Blue3Number == team ||
                          m.Red1Number == team ||
                          m.Red2Number == team ||
                          m.Red3Number == team)
                          select m);
            }

            return Ok(db.Matches.Where(m => m.EventSku == sku));
        }

        [ResponseType(typeof(IQueryable<Match>)), Route("Events/{sku}/Divisions/{div}/Matches"), EnableQuery(PageSize = 250)]
        public IHttpActionResult GetMatchesByDivision([FromUri] string sku, [FromUri] string div, [FromUri] string team = null)
        {
            if (!db.Divisions.Any(d => d.EventSku == sku && d.Name == div))
                return NotFound();

            if (!string.IsNullOrEmpty(team))
            { // Team parameter is given
                if (!db.Teams.Any(t => t.Number == team))
                    return NotFound();

                return Ok(from m in db.Matches
                          where m.EventSku == sku && m.DivisionName == div &&
                          ( // Don't need to include sit teams because they're also either 1/2/3
                          m.Blue1Number == team ||
                          m.Blue2Number == team ||
                          m.Blue3Number == team ||
                          m.Red1Number == team ||
                          m.Red2Number == team ||
                          m.Red3Number == team)
                          select m);
            }

            return Ok(db.Matches.Where(m => m.EventSku == sku && m.DivisionName == div));
        }

        [ResponseType(typeof(IQueryable<Match>)), Route("Teams/{number}/Matches"), EnableQuery(PageSize = 250)]
        public IHttpActionResult GetMatchesByTeam([FromUri] string number)
        {
            if (!db.Teams.Any(t => t.Number == number))
                return NotFound();

            return Ok(from m in db.Matches
                      where  // Don't need to include sit teams because they're also either 1/2/3
                      m.Blue1Number == number ||
                      m.Blue2Number == number ||
                      m.Blue3Number == number ||
                      m.Red1Number == number ||
                      m.Red2Number == number ||
                      m.Red3Number == number
                      select m);
        }
    }
}
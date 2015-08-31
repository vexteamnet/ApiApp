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
    public class SeasonsController : ApiController
    {
        private CoreContext db = new CoreContext();

        [ResponseType(typeof(IQueryable<Season>)), EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(db.Seasons.AsQueryable());
        }

        [ResponseType(typeof(SingleResult<Season>)), EnableQuery]
        public IHttpActionResult GetSeason([FromUri] string id)
        {
            if (!db.Seasons.Any(s => s.Name == id))
                return NotFound();

            return Ok(SingleResult.Create(db.Seasons.Where(s => s.Name == id)));
        }
    }
}
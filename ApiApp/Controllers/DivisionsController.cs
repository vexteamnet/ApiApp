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
    [RoutePrefix("Events/{sku}/Divisions")]
    public class DivisionsController : ApiController
    {
        private CoreContext db = new CoreContext();

        public DivisionsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [ResponseType(typeof(IQueryable<Division>)), EnableQuery(PageSize = 100), Route("")]
        public IHttpActionResult Get([FromUri] string sku)
        {
            return Ok(db.Divisions.Where(d => d.EventSku == sku));
        }

        [ResponseType(typeof(SingleResult<Division>)), EnableQuery, Route("{id}")]
        public IHttpActionResult GetDivision([FromUri] string sku, string id)
        {
            return Ok(SingleResult.Create(db.Divisions.Where(d => d.EventSku == sku && d.Name == id)));
        }
    }
}
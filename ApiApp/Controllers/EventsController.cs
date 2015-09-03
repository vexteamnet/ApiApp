using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using ApiApp.Models.Core;

namespace ApiApp.Controllers
{
    public class EventsController : ApiController
    {
        CoreContext db = new CoreContext();

        public EventsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        [ResponseType(typeof(IQueryable<Event>)), EnableQuery(PageSize = 200)]
        public IHttpActionResult Get()
        {
            return Ok(db.Events.Include("Divisions").AsQueryable());
        }

        [ResponseType(typeof(SingleResult<Event>)), EnableQuery]
        public IHttpActionResult GetEvent(string id)
        {
            if (!db.Events.Any(e => e.Sku == id))
                return NotFound();
            return Ok(SingleResult.Create(db.Events.Include("Divisions").Where(e => e.Sku == id)));
        }
    }
}
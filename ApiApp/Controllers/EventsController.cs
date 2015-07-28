using ApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using System.Web.OData.Routing;

namespace ApiApp.Controllers
{
    [EnableQuery]
    public class EventsController : ODataController
    {
        CoreContext db = new CoreContext();

        [EnableQuery(PageSize = 200), ODataRoute("Events"), ResponseType(typeof(IQueryable<Event>))]
        public IHttpActionResult Get()
        {
            return Ok(db.Events);
        }

        [EnableQuery(PageSize = 200), ODataRoute("Events({sku})"), ResponseType(typeof(SingleResult<Event>))]
        public IHttpActionResult GetEvent([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();
            return Ok(SingleResult.Create(db.Events.Where(e => e.Sku == sku)));
        }

        [ODataRoute("Events"), ResponseType(typeof(Event))]
        public IHttpActionResult Post([FromBody] Event ev)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Events.Add(ev);
            db.SaveChanges();

            return Created(ev);
        }

        [ODataRoute("Events({sku})/Sku"), ResponseType(typeof(string))]
        public IHttpActionResult GetSku([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Sku);
        }

        [ODataRoute("Events({sku})/Name"), ResponseType(typeof(string))]
        public IHttpActionResult GetName([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Name);
        }

        [ODataRoute("Events({sku})/Program"), ResponseType(typeof(Program))]
        public IHttpActionResult GetProgram([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Program);
        }

        [ODataRoute("Events({sku})/Levels"), ResponseType(typeof(Level))]
        public IHttpActionResult GetLevels([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Levels);
        }

        [ODataRoute("Events({sku})/Start"), ResponseType(typeof(DateTime))]
        public IHttpActionResult GetStart([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Start);
        }

        [ODataRoute("Events({sku})/Finish"), ResponseType(typeof(DateTime))]
        public IHttpActionResult GetFinish([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Finish);
        }

        [ODataRoute("Events({sku})/Season"), ResponseType(typeof(string))]
        public IHttpActionResult GetSeason([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Season);
        }

        [ODataRoute("Events({sku})/Venue"), ResponseType(typeof(Venue))]
        public IHttpActionResult GetVenue([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Venue);
        }

        [ODataRoute("Events({sku})/Venue/Name"), ResponseType(typeof(string))]
        public IHttpActionResult GetVenueName([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Venue.Name);
        }

        [ODataRoute("Events({sku})/Venue/Address"), ResponseType(typeof(string))]
        public IHttpActionResult GetVenueAddress([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Venue.Address);
        }

        [ODataRoute("Events({sku})/Venue/Region"), ResponseType(typeof(string))]
        public IHttpActionResult GetVenueRegion([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Venue.Region);
        }

        [ODataRoute("Events({sku})/Venue/Country"), ResponseType(typeof(string))]
        public IHttpActionResult GetVenueCountry([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Venue.Country);
        }

        [ODataRoute("Events({sku})/Description"), ResponseType(typeof(string))]
        public IHttpActionResult GetDescription([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Description);
        }

        [ODataRoute("Events({sku})/Contact"), ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Contact);
        }

        [ODataRoute("Events({sku})/Contact/Name"), ResponseType(typeof(string))]
        public IHttpActionResult GetContactName([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Contact.Name);
        }

        [ODataRoute("Events({sku})/Contact/Title"), ResponseType(typeof(string))]
        public IHttpActionResult GetContactTitle([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Contact.Title);
        }

        [ODataRoute("Events({sku})/Contact/Email"), ResponseType(typeof(string))]
        public IHttpActionResult GetContactEmail([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Contact.Email);
        }

        [ODataRoute("Events({sku})/Contact/Phone"), ResponseType(typeof(string))]
        public IHttpActionResult GetContactPhone([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Contact.Phone);
        }

        [ODataRoute("Events({sku})/Agenda"), ResponseType(typeof(string))]
        public IHttpActionResult GetAgenda([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Agenda);
        }

        [ODataRoute("Events({sku})"), ResponseType(typeof(Event))]
        public IHttpActionResult Patch([FromODataUri] string sku, Delta<Event> ev)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = db.Events.Find(sku);

            if (entity == null)
                return NotFound();

            ev.Patch(entity);

            db.SaveChanges();

            return Updated(entity);
        }

        [ODataRoute("Events({sku})"), ResponseType(typeof(Event))]
        public IHttpActionResult Put([FromODataUri] string sku, Event ev)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (sku != ev.Sku)
                return BadRequest();

            db.Entry(ev).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            return Updated(ev);
        }

        [ODataRoute("Events({sku})"), ResponseType(typeof(void))]
        public IHttpActionResult Delete([FromODataUri] string sku)
        {
            var entity = db.Events.Find(sku);
            if (entity == null)
                return NotFound();

            db.Events.Remove(entity);

            db.SaveChanges();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        bool EventExists(string sku)
        {
            return db.Events.Any(e => e.Sku == sku);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

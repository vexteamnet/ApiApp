using VexTeamNetwork.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using System.Web.OData.Routing;

namespace ApiApp.Controllers
{
    [EnableQuery]
    public partial class EventsController : ODataController
    {
        CoreContext db = new CoreContext();

        [EnableQuery(PageSize = 200, MaxExpansionDepth = 2), ODataRoute, ResponseType(typeof(IQueryable<Event>))]
        public IHttpActionResult Get()
        {
            return Ok(db.Events.Include(e => e.Divisions));
        }

        [EnableQuery(PageSize = 200, MaxExpansionDepth = 2), ODataRoute, ResponseType(typeof(SingleResult<Event>))]
        public IHttpActionResult GetEvent([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();
            return Ok(SingleResult.Create(db.Events.Where(e => e.Sku == sku).Include(e => e.Divisions)));
        }

        [ResponseType(typeof(Event))]
        public IHttpActionResult Post([FromBody] Event ev)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Events.Add(ev);
            db.SaveChanges();

            return Created(ev);
        }

        [ResponseType(typeof(string))]
        public IHttpActionResult GetSku([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Sku);
        }

        [ResponseType(typeof(string))]
        public IHttpActionResult GetName([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Name);
        }

        [ODataRoute("Events({sku})/Program"), ODataRoute("Events({sku})/Program/$value"), ResponseType(typeof(Program))]
        public IHttpActionResult GetProgram([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Program);
        }

        [ODataRoute("Events({sku})/Levels"), ODataRoute("Events({sku})/Levels/$value"), ResponseType(typeof(Level))]
        public IHttpActionResult GetLevels([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Levels);
        }

        [ODataRoute("Events({sku})/Start"), ODataRoute("Events({sku})/Start/$value"), ResponseType(typeof(DateTime))]
        public IHttpActionResult GetStart([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Start);
        }

        [ODataRoute("Events({sku})/Finish"), ODataRoute("Events({sku})/Finish/$value"), ResponseType(typeof(DateTime))]
        public IHttpActionResult GetFinish([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Finish);
        }

        [ODataRoute("Events({sku})/Season"), ODataRoute("Events({sku})/Season/$value"), ResponseType(typeof(string))]
        public IHttpActionResult GetSeason([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Season);
        }

        [ODataRoute("Events({sku})/Venue"), ODataRoute("Events({sku})/Venue/$value"), ResponseType(typeof(Venue))]
        public IHttpActionResult GetVenue([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Venue);
        }

        [ODataRoute("Events({sku})/Venue/Name"), ODataRoute("Events({sku})/Venue/Name/$value"), ResponseType(typeof(string))]
        public IHttpActionResult GetVenueName([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Venue.Name);
        }

        [ODataRoute("Events({sku})/Venue/Address"), ODataRoute("Events({sku})/Venue/Address/$value"), ResponseType(typeof(string))]
        public IHttpActionResult GetVenueAddress([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Venue.Address);
        }

        [ODataRoute("Events({sku})/Venue/Region"), ODataRoute("Events({sku})/Venue/Region/$value"), ResponseType(typeof(string))]
        public IHttpActionResult GetVenueRegion([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Venue.Region);
        }

        [ODataRoute("Events({sku})/Venue/Country"), ODataRoute("Events({sku})/Venue/Country/$value"), ResponseType(typeof(string))]
        public IHttpActionResult GetVenueCountry([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Venue.Country);
        }

        [ODataRoute("Events({sku})/Description"), ODataRoute("Events({sku})/Description/$value"), ResponseType(typeof(string))]
        public IHttpActionResult GetDescription([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Description);
        }

        [ODataRoute("Events({sku})/Contact"), ODataRoute("Events({sku})/Contact/$value"), ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Contact);
        }

        [ODataRoute("Events({sku})/Contact/Name"), ODataRoute("Events({sku})/Contact/Name/$value"), ResponseType(typeof(string))]
        public IHttpActionResult GetContactName([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Contact.Name);
        }

        [ODataRoute("Events({sku})/Contact/Title"), ODataRoute("Events({sku})/Contact/Title/$value"), ResponseType(typeof(string))]
        public IHttpActionResult GetContactTitle([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Contact.Title);
        }

        [ODataRoute("Events({sku})/Contact/Email"), ODataRoute("Events({sku})/Contact/Email/$value"), ResponseType(typeof(string))]
        public IHttpActionResult GetContactEmail([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Contact.Email);
        }

        [ODataRoute("Events({sku})/Contact/Phone"), ODataRoute("Events({sku})/Contact/Phone/$value"), ResponseType(typeof(string))]
        public IHttpActionResult GetContactPhone([FromODataUri] string sku)
        {
            if (!EventExists(sku))
                return NotFound();

            return Ok(db.Events.Find(sku).Contact.Phone);
        }

        [ODataRoute("Events({sku})/Agenda"), ODataRoute("Events({sku})/Agenda/$value"), ResponseType(typeof(string))]
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

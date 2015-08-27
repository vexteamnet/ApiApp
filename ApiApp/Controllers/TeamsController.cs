using VexTeamNetwork.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using System.Web.OData.Routing;

namespace ApiApp.Controllers
{
    [EnableQuery]
    public class TeamsController : ODataController
    {
        CoreContext db = new CoreContext();

        /// <summary>
        /// Gets all teams
        /// </summary>
        [EnableQuery(PageSize = 200), ODataRoute("Teams"), ResponseType(typeof(IQueryable<Team>))]
        public IHttpActionResult Get()
        {
            return Ok(db.Teams);
        }

        [EnableQuery(PageSize = 200), ODataRoute("Teams({number})"), ResponseType(typeof(SingleResult<Team>))]
        public IHttpActionResult GetTeam([FromODataUri] string number)
        {
            if (!TeamExists(number))
                return NotFound();

            return Ok(SingleResult.Create(db.Teams.Where(t => t.Number == number)));
        }

        [ODataRoute("Teams"), ResponseType(typeof(Team))]
        public IHttpActionResult Post([FromBody] Team team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Teams.Add(team);
            db.SaveChanges();
            return Created(team);
        }

        [ODataRoute("Teams({number})/Number"), ResponseType(typeof(string))]
        public IHttpActionResult GetNumber([FromODataUri]string number)
        {
            if (!TeamExists(number))
                return NotFound();

            var entity = db.Teams.Find(number);

            return Ok(entity.Number);
        }

        [ODataRoute("Teams({number})/Name"), ResponseType(typeof(string))]
        public IHttpActionResult GetName([FromODataUri]string number)
        {
            if (!TeamExists(number))
                return NotFound();

            var entity = db.Teams.Find(number);

            return Ok(entity.Name);
        }

        [ODataRoute("Teams({number})/RobotName"), ResponseType(typeof(string))]
        public IHttpActionResult GetRobotName([FromODataUri]string number)
        {
            if (!TeamExists(number))
                return NotFound();

            var entity = db.Teams.Find(number);

            return Ok(entity.RobotName);
        }

        [ODataRoute("Teams({number})/Organization"), ResponseType(typeof(string))]
        public IHttpActionResult GetOrganization([FromODataUri]string number)
        {
            if (!TeamExists(number))
                return NotFound();

            var entity = db.Teams.Find(number);

            return Ok(entity.Organization);
        }

        [ODataRoute("Teams({number})/City"), ResponseType(typeof(string))]
        public IHttpActionResult GetCity([FromODataUri]string number)
        {
            if (!TeamExists(number))
                return NotFound();

            var entity = db.Teams.Find(number);

            return Ok(entity.City);
        }

        [ODataRoute("Teams({number})/Region"), ResponseType(typeof(string))]
        public IHttpActionResult GetRegion([FromODataUri]string number)
        {
            if (!TeamExists(number))
                return NotFound();

            var entity = db.Teams.Find(number);

            return Ok(entity.Region);
        }

        [ODataRoute("Teams({number})/Country"), ResponseType(typeof(string))]
        public IHttpActionResult GetCountry([FromODataUri]string number)
        {
            if (!TeamExists(number))
                return NotFound();

            var entity = db.Teams.Find(number);

            return Ok(entity.Country);
        }

        [ODataRoute("Teams({number})/IsRegistered"), ResponseType(typeof(bool))]
        public IHttpActionResult GetIsRegistered([FromODataUri]string number)
        {
            if (!TeamExists(number))
                return NotFound();

            var entity = db.Teams.Find(number);

            return Ok(entity.IsRegistered);
        }

        [ODataRoute("Teams({number})/Level"), ResponseType(typeof(Level))]
        public IHttpActionResult GetLevel([FromODataUri]string number)
        {
            if (!TeamExists(number))
                return NotFound();

            var entity = db.Teams.Find(number);

            return Ok(entity.Level);
        }

        [ODataRoute("Teams({number})/Program"), ResponseType(typeof(Program))]
        public IHttpActionResult GetProgram([FromODataUri]string number)
        {
            if (!TeamExists(number))
                return NotFound();

            var entity = db.Teams.Find(number);

            return Ok(entity.Program);
        }

        [ODataRoute("Teams({number})"), ResponseType(typeof(Team))]
        public IHttpActionResult Patch([FromODataUri] string number, Delta<Team> team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = db.Teams.Find(number);

            if (entity == null)
                return NotFound();

            team.Patch(entity);

            db.SaveChanges();

            return Updated(entity);
        }

        [ODataRoute("Teams({number})"), ResponseType(typeof(Team))]
        public IHttpActionResult Put([FromODataUri] string number, Team update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (number != update.Number)
                return BadRequest();

            db.Entry(update).State = EntityState.Modified;

            db.SaveChanges();

            return Updated(update);
        }

        [ODataRoute("Teams({number})"), ResponseType(typeof(void))]
        public IHttpActionResult Delete([FromODataUri] string number)
        {
            var team = db.Teams.Find(number);
            if (team == null)
                return NotFound();

            db.Teams.Remove(team);

            db.SaveChanges();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
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

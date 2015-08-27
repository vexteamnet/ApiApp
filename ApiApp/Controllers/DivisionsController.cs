using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using System.Web.OData.Routing;
using VexTeamNetwork.Models;

namespace ApiApp.Controllers
{
    //[ODataRoutePrefix("Events({sku})/Divisions")]
    public partial class EventsController : ODataController
    {
        // private CoreContext db = new CoreContext();

        [EnableQuery(PageSize = 200)/*, ODataRoute("Events({sku})/Divisions"),*/ ResponseType(typeof(IQueryable<Division>))]
        public IHttpActionResult GetDivisions([FromODataUri] string sku)
        {
            return Ok(db.Divisions.Where(d => d.EventSku == sku));
        }

        [EnableQuery(PageSize = 200)/*, ODataRoute("Events({sku})/Divisions({name})"),*/ ResponseType(typeof(SingleResult<Division>))]
        public IHttpActionResult GetDivision([FromODataUri] string sku, [FromODataUri] string name)
        {
            return Ok(SingleResult.Create(db.Divisions.Select(d => d.EventSku == sku && d.Name == name)));
        }

        bool DivisionExists(string sku, string name)
        {
            return db.Divisions.Any(d => d.EventSku == sku && d.Name == name);
        }

        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
        */
    }
}

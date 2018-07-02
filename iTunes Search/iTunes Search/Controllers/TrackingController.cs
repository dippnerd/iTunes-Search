using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using iTunes_Search.Models;

namespace iTunes_Search.Controllers
{
    [RoutePrefix("api/tracking")]
    public class TrackingController : ApiController
    {
        private TrackingDBEntities db = new TrackingDBEntities();        

        // POST: api/Tracking
        [HttpPost]
        [AcceptVerbs("POST")]
        public async Task<IHttpActionResult> PostTracking(Click model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //we're checking for an exact match so we can update instead of replace
            Tracking tracking = await db.Trackings.Where(x => x.SourceId == model.id && x.Type == model.type && x.Search == model.search).FirstOrDefaultAsync();
            if (tracking == null)
            {
                //no existing entry, let's make a new one
                tracking = db.Trackings.Create();
                tracking.SourceId = model.id;
                tracking.Type = model.type;
                tracking.Search = model.search;
                tracking.Name = model.name;
                tracking.Clicks = 1;

                db.Trackings.Add(tracking);
            }
            else
            {
                //increment clicks for existing row
                tracking.Clicks++;
            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrackingExists(tracking.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tracking.Id }, tracking);
        }       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackingExists(int id)
        {
            return db.Trackings.Count(e => e.Id == id) > 0;
        }
    }
}
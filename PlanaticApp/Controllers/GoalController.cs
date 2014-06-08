using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using NewPlanner.Models;
using PlanaticApp.Models;

namespace PlanaticApp.Controllers
{
    public class GoalController : ApiController
    {
        private PlanaticAppContext db = new PlanaticAppContext();

        // GET api/Goal
        public IEnumerable<GoalItemDto> GetGoalItemDtoes()
        {
            return db.GoalItemDtoes.AsEnumerable();
        }

        // GET api/Goal/5
        public GoalItemDto GetGoalItemDto(int id)
        {
            GoalItemDto goalitemdto = db.GoalItemDtoes.Find(id);
            if (goalitemdto == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return goalitemdto;
        }

        // PUT api/Goal/5
        public HttpResponseMessage PutGoalItemDto(int id, GoalItemDto goalitemdto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != goalitemdto.GoalItemId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(goalitemdto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Goal
        public HttpResponseMessage PostGoalItemDto(GoalItemDto goalitemdto)
        {
            if (ModelState.IsValid)
            {
                db.GoalItemDtoes.Add(goalitemdto);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, goalitemdto);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = goalitemdto.GoalItemId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Goal/5
        public HttpResponseMessage DeleteGoalItemDto(int id)
        {
            GoalItemDto goalitemdto = db.GoalItemDtoes.Find(id);
            if (goalitemdto == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GoalItemDtoes.Remove(goalitemdto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, goalitemdto);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
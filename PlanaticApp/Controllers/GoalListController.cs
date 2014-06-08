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
    public class GoalListController : ApiController
    {
        private PlanaticAppContext db = new PlanaticAppContext();

        // GET api/GoalList
        public IEnumerable<GoalListDto> GetGoalListDtoes()
        {
            return db.GoalListDtoes.AsEnumerable();
        }

        // GET api/GoalList/5
        public GoalListDto GetGoalListDto(int id)
        {
            GoalListDto goallistdto = db.GoalListDtoes.Find(id);
            if (goallistdto == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return goallistdto;
        }

        // PUT api/GoalList/5
        public HttpResponseMessage PutGoalListDto(int id, GoalListDto goallistdto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != goallistdto.GoalListId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(goallistdto).State = EntityState.Modified;

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

        // POST api/GoalList
        public HttpResponseMessage PostGoalListDto(GoalListDto goallistdto)
        {
            if (ModelState.IsValid)
            {
                db.GoalListDtoes.Add(goallistdto);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, goallistdto);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = goallistdto.GoalListId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/GoalList/5
        public HttpResponseMessage DeleteGoalListDto(int id)
        {
            GoalListDto goallistdto = db.GoalListDtoes.Find(id);
            if (goallistdto == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GoalListDtoes.Remove(goallistdto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, goallistdto);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
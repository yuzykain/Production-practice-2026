using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutosalonWebAPI.Entities;
using AutosalonWebAPI.Models;

namespace AutosalonWebAPI.Controllers
{
    public class АвтомобилиController : ApiController
    {
        private AutoShowBDEntities db = new AutoShowBDEntities();

        // GET: api/Автомобили
        [ResponseType(typeof(List<ResponceАвтомобили>))]
        public IHttpActionResult GetАвтомобили()
        {
            return Ok(db.Автомобили.ToList().ConvertAll(p => new ResponceАвтомобили(p)));
        }

        // GET: api/Автомобили/5
        [ResponseType(typeof(Автомобили))]
        public IHttpActionResult GetАвтомобили(int id)
        {
            Автомобили автомобили = db.Автомобили.Find(id);
            if (автомобили == null)
            {
                return NotFound();
            }

            return Ok(автомобили);
        }

        // PUT: api/Автомобили/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutАвтомобили(int id, Автомобили автомобили)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != автомобили.id_Автомобиля)
            {
                return BadRequest();
            }

            db.Entry(автомобили).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!АвтомобилиExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Автомобили
        [ResponseType(typeof(Автомобили))]
        public IHttpActionResult PostАвтомобили(Автомобили автомобили)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Автомобили.Add(автомобили);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = автомобили.id_Автомобиля }, автомобили);
        }

        // DELETE: api/Автомобили/5
        [ResponseType(typeof(Автомобили))]
        public IHttpActionResult DeleteАвтомобили(int id)
        {
            Автомобили автомобили = db.Автомобили.Find(id);
            if (автомобили == null)
            {
                return NotFound();
            }

            db.Автомобили.Remove(автомобили);
            db.SaveChanges();

            return Ok(автомобили);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool АвтомобилиExists(int id)
        {
            return db.Автомобили.Count(e => e.id_Автомобиля == id) > 0;
        }
    }
}
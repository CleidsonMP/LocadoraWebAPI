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
using Locadora.Models;

namespace Locadora.Controllers
{
    public class FilmesController : ApiController
    {
        private LocadoraDBContext db = new LocadoraDBContext();

        // GET: api/Filmes
        public IQueryable<Filme> GetFilmes()
        {
            return db.Filmes.Where(f => f.RegAtivo.Equals("S")); 
        }

        // GET: api/Filmes/5
        [ResponseType(typeof(Filme))]
        public IHttpActionResult GetFilme(int id)
        {
            Filme filme = db.Filmes.Where(c => c.Id == id && c.RegAtivo.Equals("S")).FirstOrDefault();
            if (filme == null)
            {
                return NotFound();
            }

            return Ok(filme);
        }

        // PUT: api/Filmes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFilme(int id, Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filme.Id)
            {
                return BadRequest();
            }

            db.Entry(filme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
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

        // POST: api/Filmes
        [ResponseType(typeof(Filme))]
        public IHttpActionResult PostFilme(Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Filmes.Add(filme);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = filme.Id }, filme);
        }

        // DELETE: api/Filmes/5
        [ResponseType(typeof(Filme))]
        public IHttpActionResult PatchFilme(int id)
        {
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return NotFound();
            }
          
            filme.RegAtivo = "N";
            db.SaveChanges();

            return Ok(filme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmeExists(int id)
        {
            return db.Filmes.Count(e => e.Id == id) > 0;
        }
    }
}
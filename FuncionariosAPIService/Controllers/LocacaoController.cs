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
    public class LocacaoController : ApiController
    {
        private LocadoraDBContext db = new LocadoraDBContext();

        // GET: api/Locacao
        public IQueryable<Locacao> GetLocacoes()
        {
            return db.Locacoes;
        }

        // GET: api/Locacao/5
        [ResponseType(typeof(Locacao))]
        public IHttpActionResult GetLocacao(int id)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return NotFound();
            }

            return Ok(locacao);
        }

        // PUT: api/Locacao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocacao(int id, Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != locacao.Id)
            {
                return BadRequest();
            }
            locacao.StatusLocacao = StatusLocacao.Locado;
            db.Entry(locacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoExists(id))
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


       
        // POST: api/Locacao
        [ResponseType(typeof(Locacao))]
        public IHttpActionResult PostLocacao(Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (FilmeDisponivel(locacao.FilmeId))
            {
                Filme filme = db.Filmes.Find(locacao.FilmeId);
                filme.Disponivel = "N";
                db.Locacoes.Add(locacao);
                db.SaveChanges();

            } else return Ok("Filme indiponível para locação.");
            return CreatedAtRoute("DefaultApi", new { id = locacao.Id }, locacao);
        }

        // DELETE: api/Locacao/5
        [ResponseType(typeof(Locacao))]
        public IHttpActionResult DeleteLocacao(int id)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return NotFound();
            }

            locacao.RegAtivo = "N";
            db.SaveChanges();

            return Ok(locacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocacaoExists(int id)
        {
            return db.Locacoes.Count(e => e.Id == id) > 0;
        }

        private bool FilmeDisponivel(int id)
        {
            return db.Filmes.Count(e => e.Id == id && e.Disponivel.Equals("S")) > 0;
        }
    }
}
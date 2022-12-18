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
    public class DevolucaoController : ApiController
    {
        private LocadoraDBContext db = new LocadoraDBContext();

        // PUT: api/Devolucao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PatchLocacao(int id, Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            Locacao objLocacao = db.Locacoes.Find(id);

            Filme filme = db.Filmes.Find(objLocacao.FilmeId);
            filme.Disponivel = "S";

            objLocacao.DataDevolvido = DateTime.Now;
            objLocacao.StatusLocacao = StatusLocacao.Devolvido;
              
           
            try
            {
                db.SaveChanges();
                objLocacao = db.Locacoes.Find(id);
                if (objLocacao.DataDevolvido > objLocacao.DataDevolucao)
                    return Ok("Atenção: Filme devolvido com atraso.");
                else
                    return Ok("Filme devolvido.");


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
    }
}
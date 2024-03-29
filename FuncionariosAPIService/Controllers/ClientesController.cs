﻿using System;
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
    public class ClientesController : ApiController
    {
        private LocadoraDBContext db = new LocadoraDBContext();

        // GET: api/Clientes
        public IQueryable<Cliente> GetClientes()
        {
            return db.Clientes.Where(c=>c.RegAtivo.Equals("S"));
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = db.Clientes.Where(c=>c.Id==id && c.RegAtivo.Equals("S")).FirstOrDefault();
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!ClienteCPFExists(cliente.CPF))
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
             else
            {
                return Ok("Cliente já cadastrado para este CPF."); 
            }
           return CreatedAtRoute("DefaultApi", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PatchCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.RegAtivo = "N";
            db.SaveChanges();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }
        private bool ClienteCPFExists(string cpf)
        {
            return db.Clientes.Count(e => e.CPF == cpf) > 0;
        }
    }
}
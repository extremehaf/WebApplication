﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.DAL;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PerfilConsumoController : ApiController
    {
        // GET api/<controller>
        public List<PerfilConsumo> Get()
        {
            using (var db=new dbContext())
            {
                return db.PerfilConsumo.ToList();
            }
        }

        // GET api/<controller>/5
        public PerfilConsumo Get(int id)
        {
            using (var db = new dbContext())
            {
                return db.PerfilConsumo.Where(c=>c.Id ==id).FirstOrDefault();
            }
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]PerfilConsumo value)
        {
            using (var db = new dbContext())
            {
                value.Id = 0;
                db.PerfilConsumo.Add(value);
                db.SaveChanges();
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]PerfilConsumo value)
        {
            using (var db = new dbContext())
            {
                var perfilConsumo = db.PerfilConsumo.Where(c=>c.Id==id).FirstOrDefault();
                if (perfilConsumo!=null)
                {
                    perfilConsumo.Cofins = value.Cofins;
                    perfilConsumo.ConsumoDiario = value.ConsumoDiario;
                    perfilConsumo.ConsumoMensal = value.ConsumoMensal;
                    perfilConsumo.Icms = value.Icms;
                    perfilConsumo.Kwh = value.Kwh;
                    perfilConsumo.Pis = value.Pis;
                    perfilConsumo.Tipo = value.Tipo;
                    perfilConsumo.UsuarioId = value.UsuarioId;
                    perfilConsumo.ValorEstimado = value.ValorEstimado;
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            using (var db = new dbContext())
            {
                var perfilConsumo = db.PerfilConsumo.Where(c=>c.Id==id).FirstOrDefault();
                if (perfilConsumo!=null)
                {
                    db.PerfilConsumo.Remove(perfilConsumo);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
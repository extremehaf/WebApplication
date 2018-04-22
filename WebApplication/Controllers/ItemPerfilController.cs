using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.DAL;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ItemPerfilController : ApiController
    {
        // GET api/<controller>
        public List<ItemPerfil> Get()
        {
            using (var db = new dbContext())
            {
                return db.ItemPerfil.ToList();
            }
        }

        // GET api/<controller>/5
        public ItemPerfil Get(int id)
        {
            using (var db = new dbContext())
            {
                return db.ItemPerfil.Where(c=>c.Id ==id).FirstOrDefault();
            }
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]ItemPerfil value)
        {
            using (var db = new dbContext())
            {
                value.Id = 0;
                db.ItemPerfil.Add(value);
                db.SaveChanges();
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]ItemPerfil value)
        {
            using (var db = new dbContext())
            {
                var itemPerfil = db.ItemPerfil.Where(c => c.Id == id).FirstOrDefault();
                if (itemPerfil!=null)
                {
                    itemPerfil.DiasUso = value.DiasUso;
                    itemPerfil.PerfilId = value.PerfilId;
                    itemPerfil.Quantidade = value.Quantidade;
                    itemPerfil.RecursoId = value.RecursoId;
                    itemPerfil.Tempo_uso = value.Tempo_uso;
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            using (var db = new dbContext())
            {
                var itemPerfil = db.ItemPerfil.Where(c => c.Id == id).FirstOrDefault();
                if (itemPerfil!=null)
                {
                    db.ItemPerfil.Remove(itemPerfil);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
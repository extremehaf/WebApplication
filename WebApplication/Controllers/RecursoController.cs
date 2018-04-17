using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.DAL;
using WebApplication.Models;
namespace WebApplication.Controllers
{
    public class RecursoController : ApiController
    {
        // GET api/values
        public List<Recurso> Get()
        {
            using (var db = new dbContext())
            {
                return db.Recurso.ToList();
            }
        }
        // GET api/values
        [HttpGet]
        [Route("api/Recurso/usuario/{usuarioId}")]
        public List<Recurso> RecursosUsuario(int usuarioId)
        {
            using (var db = new dbContext())
            {
                var recursos = db.Recurso.Where(r => r.UsuarioId == usuarioId).Include(u => u.Usuario).Include(r => r.ItemPerfils).ToList();
                return recursos;
            }
        }

        // GET api/values/5

        public Recurso Get(int id)
        {
            using (var db = new dbContext())
            {
                return db.Recurso.Where(c => c.Id == id).FirstOrDefault();
            }

        }

        // POST api/values
        public void Post([FromBody]Recurso value)
        {
            using (var db = new dbContext())
            {
                db.Recurso.Add(value);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Recurso value)
        {
            using (var db = new dbContext())
            {
                var recurso = db.Recurso.Where(c => c.Id == id).FirstOrDefault();
                if (recurso != null)
                {
                    recurso.Descricao = value.Descricao;
                    recurso.Foto = value.Foto;
                    recurso.Id = value.Id;
                    recurso.ItemPerfils = value.ItemPerfils;
                    recurso.Nome = value.Nome;
                    recurso.Potencia = value.Potencia;
                    recurso.Usuario = value.Usuario;
                    recurso.UsuarioId = value.UsuarioId;
                    recurso.Voltagem = value.Voltagem;

                    db.SaveChanges();
                }

            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (var db = new dbContext())
            {
                var recurso = db.Recurso.Where(c => c.Id == id).FirstOrDefault();
                if (recurso != null)
                {
                    db.Recurso.Remove(recurso);
                    db.SaveChanges();
                }
            }
        }
    }
}

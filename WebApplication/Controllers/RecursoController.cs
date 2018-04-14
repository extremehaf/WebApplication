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
            using (var db = new dbContext()) {
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

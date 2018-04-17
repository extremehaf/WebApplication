using Newtonsoft.Json.Linq;
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
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<Usuario> Get()
        {
            using (var db = new dbContext())
            {
                var user = db.Usuario.ToList();
                return user;
            }
        }

        // GET: api/Usuario/5
        public Usuario Get(int id)
        {
            try
            {
                using (var db = new dbContext())
                {
                    var user = db.Usuario.Where(u => u.Id == id).FirstOrDefault();
                    return user;
                }
            }
            catch (Exception e)
            {
                return new Usuario();
            }
        }
        [HttpPost]
        [Route("api/Usuario/autentica/")]
        public Usuario AutenticaUsuario([FromBody]Usuario usuario)
        {
            using (var db = new dbContext())
            {
                var user = db.Usuario.Where(u => u.Email == usuario.Email).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("Email não cadastrado");
                }
                var senhaOk = Util.Criptografia.Compara(usuario.Senha, user.Senha);
                if (senhaOk)
                    return user;
                else
                    return new Usuario();
            }

        }
        // POST: api/Usuario
        public Usuario Post([FromBody]Usuario usuario)
        {
            try
            {
                using (var db = new dbContext())
                {
                    usuario.Senha = Util.Criptografia.Codifica(usuario.Senha);
                    var user = db.Usuario.Add(usuario);
                    db.SaveChanges();
                    return user;
                }
            }
            catch (Exception e)
            {
                return new Usuario();
            }

        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]Usuario value)
        {
            using (var db = new dbContext())
            {
                var user = db.Usuario.Where(c => c.Id == id).FirstOrDefault();
                if (user != null)
                {
                    user.DataNascimento = value.DataNascimento;
                    user.Email = value.Email;
                    user.Endereco = value.Endereco;
                    user.Id = value.Id;//TODO: validar se a senha foi alterada!!
                    user.Nome = value.Nome;
                    user.PerfilConsumos = value.PerfilConsumos;
                    user.Recursos = value.Recursos;
                    
                    if (user.Senha!= Util.Criptografia.Codifica(value.Senha))
                    {
                        user.Senha = value.Senha;
                    }
                    db.SaveChanges();
                }
            }
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
            using (var db = new dbContext())
            {
                var user = db.Usuario.Where(c => c.Id == id).FirstOrDefault();
                if (user!=null)
                {
                    db.Usuario.Remove(user);
                    db.SaveChanges();
                }
            }
        }
    }
}

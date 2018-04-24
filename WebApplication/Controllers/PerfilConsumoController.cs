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
    public class PerfilConsumoController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public List<PerfilConsumo> Get()
        {
            using (var db = new dbContext())
            {
                return db.PerfilConsumo.ToList();
            }
        }
        // GET api/<controller/{usuarioID}>
        [HttpGet]
        [Route("api/PerfilConsumo/usuario/{usuarioId}")]
        public List<PerfilConsumo> PerfilConsumoUsuario(int usuarioId)
        {
            using (var db = new dbContext())
            {
                var perfil = db.PerfilConsumo.Where(p => p.UsuarioId == usuarioId).Include(i => i.ItemPerfils);

                
                return perfil.ToList();
            }
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/PerfilConsumo/{id}")]
        public PerfilConsumo Get(int id)
        {
            using (var db = new dbContext())
            {
                var perfil =  db.PerfilConsumo.Where(c => c.Id == id).Include(i => i.ItemPerfils.Select(r => r.Recurso)).FirstOrDefault();

                foreach (var ip in perfil.ItemPerfils)
                {
                    ip.Recurso.Foto = null;
                }
                return perfil;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/PerfilConsumo")]
        public int Post([FromBody]PerfilConsumo value)
        {
            using (var db = new dbContext())
            {
                value.Id = 0;
                value = db.PerfilConsumo.Add(value);
                db.SaveChanges();
            }
            return value.Id;
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/PerfilConsumo/{id}")]
        public HttpResponseMessage Put(int id, [FromBody]PerfilConsumo value)
        {
            using (var db = new dbContext())
            {
                var perfilConsumo = db.PerfilConsumo.Where(c => c.Id == id).FirstOrDefault();
                if (perfilConsumo != null)
                {
                    perfilConsumo.Descricao = value.Descricao;
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
        [HttpDelete]
        [Route("api/PerfilConsumo/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            using (var db = new dbContext())
            {
                var perfilConsumo = db.PerfilConsumo.Where(c => c.Id == id).FirstOrDefault();
                if (perfilConsumo != null)
                {
                    db.PerfilConsumo.Remove(perfilConsumo);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        [Route("api/PerfilConsumo/CalculaFatura/{IdPerfil}")]
        public PerfilConsumo CalculaFaturaReais(int IdPerfil)
        {
            PerfilConsumo result = null;
            using (var db = new dbContext())
            {
                var perfil = db.PerfilConsumo.Where(c => c.Id == IdPerfil).Include(i => i.ItemPerfils.Select(r => r.Recurso)).FirstOrDefault();
                if (perfil != null)
                {
                    perfil.ValorEstimado = SomaTotalFatura(perfil);
                    var totalKwh = CalculaFaturaKwh(perfil);
                    perfil.ConsumoDiario = totalKwh / 30;
                    perfil.ConsumoMensal = totalKwh;
                    result = perfil;
                }
                db.SaveChanges();
            }
            return result;
        }

        private double CalculaFaturaKwh(PerfilConsumo perfil)
        {
            double result = 0;
            if (perfil != null)
            {
                result = SomaTotalKwh(perfil);
            }
            return result;
        }

        private double SomaValorRecurso(ItemPerfil item)
        {
            double result = 0;
            if (item.Recurso != null)
            {
                //decimal dec = (Convert.ToDecimal((item.Recurso.Potencia*100 / 1000)) * Convert.ToDecimal((item.DiasUso * item.Tempo_uso)) * item.Quantidade);
                decimal dec = (Convert.ToDecimal((item.Recurso.Potencia*100 / 1000)) * Convert.ToDecimal((item.DiasUso * item.Tempo_uso)) * item.Quantidade);
                result = (((double)item.Recurso.Potencia / (double)1000) * ((double)item.DiasUso * (double)item.Tempo_uso) * (double)item.Quantidade);
            }
            return result;
        }
        private double SomaTotalFatura(PerfilConsumo perfil)
        {
            var somaRecursos = SomaTotalKwh(perfil);
            return ((somaRecursos * ((double)perfil.Kwh + (double)perfil.Adicional + (((double)perfil.Kwh + (double)perfil.Adicional) * ((double)perfil.Icms)/(double)100))) + (somaRecursos * (((double)perfil.Cofins/(double)100) + ((double)perfil.Pis)/(double)100)));
        }

        private double SomaTotalKwh(PerfilConsumo perfil)
        {
            double somaRecursosKwh = 0;
            foreach (var item in perfil.ItemPerfils)
            {
                somaRecursosKwh += SomaValorRecurso(item);
            }
            return somaRecursosKwh;
        }
    }
}
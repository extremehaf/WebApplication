using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public String Endereco { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<PerfilConsumo> PerfilConsumos { get; set; }
        public virtual ICollection<Recurso> Recursos { get; set; }
        public Usuario()
        {
        }

        public Usuario(int id, String nome, String email, String senha, String endereco, DateTime dataNascimento)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Endereco = endereco;
            this.DataNascimento = dataNascimento;
        }
    }
}
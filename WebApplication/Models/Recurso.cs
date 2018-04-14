﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Recurso
    {
        public int Id { get; set; }
        public String Descricao { get; set; }
        public int UsuarioId { get; set; }
        public String Nome { get; set; }
        public byte[] Foto { get; set; }
        public String Voltagem { get; set; }
        public int Potencia { get; set; }
        public virtual ICollection<ItemPerfil> ItemPerfils { get; set; }
        public virtual Usuario Usuario { get; set; }
        public Recurso()
        {
            this.Foto = null;
        }

        public Recurso(String nome, String d, byte[] f, String v, int p)
        {
            this.Nome = nome;
            this.Descricao = d;
            this.Foto = f;
            this.Voltagem = v;
            this.Potencia = p;
        }
    }
}
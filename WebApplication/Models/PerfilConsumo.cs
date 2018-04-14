using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace WebApplication.Models
{
    public class PerfilConsumo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public double Icms { get; set; }
        public double Pis { get; set; }
        public double Cofins { get; set; }
        public double Kwh { get; set; }
        public double ConsumoDiario { get; set; }
        public double ConsumoMensal { get; set; }
        public double ValorEstimado { get; set; }
        public virtual ICollection<ItemPerfil> ItemPerfils { get; set; }
        [DataMember(IsRequired = false)]
        public virtual Usuario Usuario { get; set; }

        public PerfilConsumo()
        {
            this.ItemPerfils = new List<ItemPerfil>();
        }

        public PerfilConsumo(int id, int usuarioId, String tipo, double icms, double pis, double cofins, double kwh, double consumoDiario, double consumoMensal, double valorEstimado, List<ItemPerfil> itemPerfils)
        {
            this.Id = id;
            this.UsuarioId = usuarioId;
            this.Tipo = tipo;
            this.Icms = icms;
            this.Pis = pis;
            this.Cofins = cofins;
            this.Kwh = kwh;
            this.ConsumoDiario = consumoDiario;
            this.ConsumoMensal = consumoMensal;
            this.ValorEstimado = valorEstimado;
            this.ItemPerfils = itemPerfils;
        }


    }
}
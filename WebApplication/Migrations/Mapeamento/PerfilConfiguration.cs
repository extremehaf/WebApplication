using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Migrations.Mapeamento
{
    internal partial class PerfilConsumoConfiguration : EntityTypeConfiguration<PerfilConsumo>
    {
        public PerfilConsumoConfiguration()
        {
            ToTable("PERFIL_CONSUMO");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UsuarioId).HasColumnName("usuario_id");
            Property(x => x.Tipo).HasColumnName("tipo");
            Property(x => x.Icms).HasColumnName("icms");
            Property(x => x.Pis).HasColumnName("pis");
            Property(x => x.Cofins).HasColumnName("cofins");
            Property(x => x.Kwh).HasColumnName("kwh");     
            Property(x => x.ConsumoDiario).HasColumnName("consumo_diario");
            Property(x => x.ConsumoMensal).HasColumnName("consumo_mensal");
            Property(x => x.ValorEstimado).HasColumnName("consumo_estimado");

            HasMany(e => e.ItemPerfils).WithRequired(e => e.PerfilConsumo).HasForeignKey(e => e.PerfilId).WillCascadeOnDelete(false);

            InitializePartial();
        }
        partial void InitializePartial();
    }
}
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
            Property(x => x.UsuarioId).IsRequired().HasColumnName("usuario_id");
            Property(x => x.Tipo).IsRequired().HasMaxLength(250).HasColumnName("tipo");
            Property(x => x.Icms).IsRequired().HasColumnName("icms");
            Property(x => x.Pis).IsRequired().HasColumnName("pis");
            Property(x => x.Cofins).IsRequired().HasColumnName("cofins");
            Property(x => x.Kwh).IsRequired().HasColumnName("kwh");     
            Property(x => x.ConsumoDiario).IsOptional().HasColumnName("consumo_diario");
            Property(x => x.ConsumoMensal).IsOptional().HasColumnName("consumo_mensal");
            Property(x => x.ValorEstimado).IsOptional().HasColumnName("consumo_estimado");

            HasMany(e => e.ItemPerfils).WithRequired(e => e.PerfilConsumo).HasForeignKey(e => e.PerfilId).WillCascadeOnDelete(false);

            InitializePartial();
        }
        partial void InitializePartial();
    }
}
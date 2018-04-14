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
    internal partial class ItemPerfilConfiguration : EntityTypeConfiguration<ItemPerfil>
    {
        public ItemPerfilConfiguration()
        {
            ToTable("ITEM_PERFIL");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Quantidade).HasColumnName("quantidade").IsRequired();
            Property(x => x.Dias_uso).HasColumnName("senha").IsRequired();
          

        
            InitializePartial();
        }
        partial void InitializePartial();
    }
}
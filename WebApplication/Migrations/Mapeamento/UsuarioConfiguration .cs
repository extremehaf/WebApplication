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
    internal partial class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("USUARIO");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnName("nome").IsRequired().HasMaxLength(250);
            Property(x => x.Senha).HasColumnName("senha").IsRequired().HasMaxLength(250);
            Property(x => x.Email).HasColumnName("email").IsRequired().HasMaxLength(250);
            Property(x => x.Endereco).HasColumnName("endereco").HasMaxLength(250);
            Property(x => x.DataNascimento).HasColumnName("data_nascimento").IsRequired();

            HasMany(e => e.PerfilConsumos).WithRequired(e => e.Usuario).HasForeignKey(e => e.UsuarioId).WillCascadeOnDelete(false);
            HasMany(e => e.Recursos).WithRequired(e => e.Usuario).HasForeignKey(e => e.UsuarioId).WillCascadeOnDelete(false);

            InitializePartial();
        }
        partial void InitializePartial();
    }
}
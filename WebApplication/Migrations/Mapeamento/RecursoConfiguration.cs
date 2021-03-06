﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Migrations.Mapeamento
{
    internal partial class RecursoConfiguration : EntityTypeConfiguration<Recurso>
    {
        public RecursoConfiguration()
        {
            ToTable("RECURSO");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnName("nome").IsRequired().HasMaxLength(250);
            Property(x => x.UsuarioId).HasColumnName("usuario_id").IsRequired();
            Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(250);
            Property(x => x.Foto).HasColumnName("foto");
            Property(x => x.Potencia).HasColumnName("potencia").IsRequired();
            Property(x => x.Voltagem).HasColumnName("voltagem").IsRequired();

            HasMany(e => e.ItemPerfils).WithRequired(e => e.Recurso).HasForeignKey(e => e.RecursoId).WillCascadeOnDelete(true);

            InitializePartial();
        }
        partial void InitializePartial();
    }
}
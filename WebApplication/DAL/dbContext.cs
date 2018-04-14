using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;
using WebApplication.Models;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;

namespace WebApplication.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class dbContext : DbContext
    {
        //public virtual DbSet<Product> Products { get; set; }
        public dbContext() : base("CONEXAO")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Usuario> Usuario { get; set; }
        public IDbSet<Recurso> Recurso { get; set; }

        public IDbSet<PerfilConsumo> ProPerfilConsumoduto { get; set; }
        public IDbSet<ItemPerfil> ItemPerfil { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //carrega dinamicamente todas configuracoes
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null
                    && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }
    }
}

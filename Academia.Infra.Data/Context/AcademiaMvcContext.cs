using Academia.Domain.Entities;
using Academia.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.Context
{
    public class AcademiaMvcContext : DbContext
    {
        public AcademiaMvcContext() : base("AcademiaMvc")
        {
        }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Plano> Planos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").
                Configure(p => p.IsKey());

            modelBuilder.Properties<string>().
                Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().
                Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new EstadoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DtCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DtCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DtCadastro").IsModified = false;
                }

            }
            return base.SaveChanges();
        }
    }
}

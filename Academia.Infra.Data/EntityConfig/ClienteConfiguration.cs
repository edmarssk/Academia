using Academia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.EntityConfig
{
    public class ClienteConfiguration: EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome).HasMaxLength(80).IsRequired();

            Property(c => c.Cpf).IsRequired().HasMaxLength(11);

            Property(c => c.DtNascimento).IsRequired();

            Property(c => c.Ativo).IsRequired();

            ToTable("Clientes");
        }
    }
}

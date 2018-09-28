using Academia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.EntityConfig
{
    public class EnderecoConfiguration: EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            HasKey(e => e.EnderecoId);

            Property(e => e.Logradouro).IsRequired().HasMaxLength(150);

            Property(e => e.Numero).IsRequired();

            Property(e => e.Cep).IsRequired().HasMaxLength(8);

            Property(e => e.EstadoSigla).IsRequired().HasMaxLength(2);

            ToTable("Enderecos");

            HasRequired(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

        }
    }
}

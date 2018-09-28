using Academia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.EntityConfig
{
    public class PlanoConfiguration: EntityTypeConfiguration<Plano>
    {
        public PlanoConfiguration()
        {
            Property(c => c.Nome).HasMaxLength(100);
            Property(c => c.Descricao).HasMaxLength(250);
            Property(c => c.Nome).IsRequired();
            Property(c => c.PeriodoMeses).IsRequired();
            
        }
    }
}

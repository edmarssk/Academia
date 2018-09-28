using Academia.Domain.Entities;
using Academia.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.Repositories
{
    public class EnderecoRepository: BaseRepository<Endereco>, IEnderecoRepository
    {
        public IEnumerable<Endereco> FindByCep(string cep)
        {
            return find(e => e.Cep == cep);
        }
    }
}

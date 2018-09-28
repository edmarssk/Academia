using Academia.Domain.Entities;
using Academia.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.Repositories
{
    public class ClienteRepository: BaseRepository<Cliente>, IClienteRepository
    {


        public Cliente ObterPorCpf(string cpf)
        {
            // O codigo abaixo substitui o Context.Cliente.find(e => e.Cpf == cpf).First();
            return find(e => e.Cpf == cpf).FirstOrDefault();
        }
    }
}

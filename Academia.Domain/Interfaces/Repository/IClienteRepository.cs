using Academia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces.Repository
{
    public interface IClienteRepository: IBaseRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
    }
}

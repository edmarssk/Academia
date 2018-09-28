using Academia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces.Repository.ReadOnly
{
    public interface IClienteReadOnlyRepository
    {
        IEnumerable<Cliente> ObterTodos();

        Cliente ObterPorID(int id);

        Cliente ObterPorCPF(string cpf);
    }
}

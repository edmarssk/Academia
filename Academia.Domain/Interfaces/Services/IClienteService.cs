using Academia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces.Services
{
    public interface IClienteService: IDisposable
    {
        void Adicionar(Cliente cliente);

        Cliente BuscarPorId(int id);

        Cliente BuscarPorCpf(string cpf);

        IEnumerable<Cliente> BuscarTodos();

        void Atualizar(Cliente cliente);

        void Remover(Cliente cliente);

    }
}

using Academia.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Interface
{
    public interface IClienteAppService : IDisposable
    {
        void Adicionar(ClienteEnderecoVM cliente);

        ClienteEnderecoVM BuscarPorId(int id);

        ClienteEnderecoVM BuscarPorCpf(string id);

        IEnumerable<ClienteVM> BuscarTodos();

        void Atualizar(ClienteEnderecoVM cliente);

        void Remover(ClienteEnderecoVM cliente);
    }
}

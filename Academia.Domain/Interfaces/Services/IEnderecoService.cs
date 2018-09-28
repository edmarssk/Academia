using Academia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces.Services
{
    public interface IEnderecoService : IDisposable
    {
        void Adicionar(Endereco endereco);

        Endereco BuscarPorId(int id);

        IEnumerable<Endereco> BuscarTodos();

        IEnumerable<Endereco> BuscarPorCep();

        void Atualizar(Endereco endereco);

        void Remover(Endereco endereco);
    }
}

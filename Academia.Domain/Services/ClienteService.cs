using Academia.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces.Repository;
using Academia.Domain.Interfaces.Repository.ReadOnly;

namespace Academia.Domain.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteReadOnlyRepository _clienteReadOnlyRepository;

        public ClienteService(IClienteRepository clienteRepository, IClienteReadOnlyRepository clienteReadOnlyRepository)
        {
            _clienteRepository = clienteRepository;
            _clienteReadOnlyRepository = clienteReadOnlyRepository;
        }

        public void Adicionar(Cliente cliente)
        {
            _clienteRepository.Add(cliente);
        }

        public void Atualizar(Cliente cliente)
        {
            _clienteRepository.Update(cliente);
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            return _clienteReadOnlyRepository.ObterPorCPF(cpf);
        }

        public Cliente BuscarPorId(int id)
        {
            return _clienteReadOnlyRepository.ObterPorID(id);
        }

        public IEnumerable<Cliente> BuscarTodos()
        {
            return _clienteReadOnlyRepository.ObterTodos();
        }

        public void Remover(Cliente cliente)
        {
            _clienteRepository.Remove(cliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
    }
}

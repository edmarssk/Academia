using Academia.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Application.ViewModel;
using Academia.Infra.Data.Repositories;
using AutoMapper;
using Academia.Domain.Entities;
using Academia.Domain.Interfaces.Services; 

namespace Academia.Application
{
    public class ClienteAppService : AppServiceBase, IClienteAppService
    {

        // public readonly ClienteRepository _clienteRepository = new ClienteRepository();
        // public readonly ClienteReadOnlyRepository _clienteReadOnlyRepository = new ClienteReadOnlyRepository();
        public AppServiceBase appService = new AppServiceBase();

        public readonly IClienteService _clienteRepository;

        public ClienteAppService(IClienteService servico)
        {
            _clienteRepository = servico;
        }

        public void Adicionar(ClienteEnderecoVM clienteEnderecoVm)
        {

            var cliente = Mapper.Map<ClienteEnderecoVM, Cliente>(clienteEnderecoVm);
            var endereco = Mapper.Map<ClienteEnderecoVM, Endereco>(clienteEnderecoVm);
            cliente.Enderecos.Add(endereco);

            BeginTransaction();

            _clienteRepository.Adicionar(cliente);

            Commit();

        }

        public void Atualizar(ClienteEnderecoVM clienteEnderecoVm)
        {
           // var cliente = Mapper.Map<ClienteVM, Cliente>(clienteVm);

            var cliente = Mapper.Map<ClienteEnderecoVM, Cliente>(clienteEnderecoVm);
            var endereco = Mapper.Map<ClienteEnderecoVM, Endereco>(clienteEnderecoVm);
            cliente.Enderecos.Add(endereco);
            BeginTransaction();
            _clienteRepository.Atualizar(cliente);
            Commit();
        }

        public ClienteEnderecoVM BuscarPorCpf(string id)
        {
            return Mapper.Map<Cliente, ClienteEnderecoVM>(_clienteRepository.BuscarPorCpf(id));
        }

        public ClienteEnderecoVM BuscarPorId(int id)
        {
            //var clio = _clienteRepository.GetById(id);
            //var clienteEndereco = Mapper.Map<Cliente, ClienteEnderecoVM>(clio);
            //clienteEndereco = Mapper.Map<Endereco, ClienteEnderecoVM>(clio.Enderecos.First());
            //return clienteEndereco;

            var cliente = Mapper.Map<Cliente, ClienteEnderecoVM>(_clienteRepository.BuscarPorId(id));
            return cliente;

            //throw new NotImplementedException();
        }

        public IEnumerable<ClienteVM> BuscarTodos()
        {
            //return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteVM>>(_clienteRepository.GetAll());
            var clientes = _clienteRepository.BuscarTodos();
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteVM>>(clientes);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        public void Remover(ClienteEnderecoVM clienteVM)
        {
            var cliente = Mapper.Map<ClienteEnderecoVM, Cliente>(clienteVM);
            BeginTransaction();
            _clienteRepository.Remover(cliente);
            Commit();
        }
    }
}

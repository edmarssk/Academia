using Academia.Application;
using Academia.Application.Interface;
using Academia.Application.ViewModel;
using Academia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Academia.Services.WebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // GET: api/Clientes
        public IEnumerable<ClienteVM> Get()
        {
            return _clienteAppService.BuscarTodos();
        }
        //[HttpGet]
        //public IEnumerable<string> obterTodos()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Clientes/5
        public ClienteEnderecoVM Get(int id)
        {
            return _clienteAppService.BuscarPorId(id);
        }

        // POST: api/Clientes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}

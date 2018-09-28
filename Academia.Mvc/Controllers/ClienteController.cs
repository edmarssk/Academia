using Academia.Application;
using Academia.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Academia.Infra.CrossCutting.MvcFilters;
using Academia.Application.Interface;

namespace Academia.Mvc.Controllers
{
    // Você pode usar o tratamento de erro colocando em todos os controles essa classe, ou configurar ela no FilterConfig na pasta AppStart
    //[GlobalErrorsHandlerPublic]
    //[RoutePrefix("Registro/Contas/")]
    [Route("{action=index}")]
    public class ClienteController : Controller
    {

        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteApp)
        {
            _clienteAppService = clienteApp;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            return View(_clienteAppService.BuscarTodos());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = _clienteAppService.BuscarPorId(id.Value);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        
        [Route("{idpedido:int?}/Clientes/{idcliente:int?}")]
        public ActionResult Testar(int? idpedido,int? idcliente)
        {
            return RedirectToAction("Index");
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoVM cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteAppService.Adicionar(cliente);
                    return RedirectToAction("Index");

                }
                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cliente = _clienteAppService.BuscarPorId(id.Value);
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
       // public ActionResult Edit([Bind(Include = "ClienteId,Nome,Email,Cpf,Ativo")] ClienteVM cliente)
        public ActionResult Edit(ClienteEnderecoVM cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteAppService.Atualizar(cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cliente = _clienteAppService.BuscarPorId(id.Value);
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var cliente = _clienteAppService.BuscarPorId(id);
                _clienteAppService.Remover(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

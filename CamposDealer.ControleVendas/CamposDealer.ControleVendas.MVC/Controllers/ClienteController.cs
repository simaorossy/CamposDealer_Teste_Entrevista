using CamposDealer.ControleVendas.Db;
using CamposDealer.ControleVendas.Db.Repositories;
using CamposDealer.ControleVendas.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealer.ControleVendas.MVC.Controllers
{
    public class ClienteController : Controller
    {
        public ClienteRepository _clienteRepository;

        public ClienteController(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            return View(_clienteRepository.ListarClientes());
        }

        public IActionResult Create()
        {
            return View();
        }

        public JsonResult Save(ClienteDto model)
        {
            var retorno = new ResponseJsonDto() { Status = true, Mensagem = "ok" };
            var cliente = new Cliente(){Nome = model.Nome, Cidade = model.Cidade };
             _clienteRepository.SalvarCliente(cliente);
            return Json(retorno);
        }

        [HttpGet("/Cliente/Edit")]
        public IActionResult Edit(int idCliente)
        {
            var cliente = _clienteRepository.PesquisarCliente(idCliente);
            return View(cliente);
        }

        [HttpPost]
        public JsonResult Edit(ClienteDto model)
        {
            var retorno = new ResponseJsonDto() { Status=true, Mensagem="ok"};
            var cliente = new Cliente() {Id= model.Id, Nome = model.Nome, Cidade = model.Cidade };
            _clienteRepository.AtualizarCliente(cliente);
            return Json(retorno);
        }

        [HttpPost]
        public JsonResult Delete(int idCliente)
        {
            var retorno = new ResponseJsonDto() { Status = true, Mensagem = "ok" };
            _clienteRepository.PesquisarCliente(idCliente);
            _clienteRepository.ExcluirCliente(idCliente);
            return Json(retorno);
        }

        public void SalvarLista(List<Cliente> clientes)
        {
            _clienteRepository.SalvarListaCliente(clientes);
        }
    }
}

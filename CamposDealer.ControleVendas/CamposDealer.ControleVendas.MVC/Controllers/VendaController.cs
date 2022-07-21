using CamposDealer.ControleVendas.Db;
using CamposDealer.ControleVendas.Db.Repositories;
using CamposDealer.ControleVendas.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealer.ControleVendas.MVC.Controllers
{
    public class VendaController : Controller
    {
        public VendaRepository _vendaRepository;
        public ClienteRepository _clienteRepository;
        public ProdutoRepository _produtoRepository;

        public VendaController(VendaRepository vendaRepository, ClienteRepository clienteRepository, ProdutoRepository produtoRepository)
        {
            _vendaRepository = vendaRepository;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            return View(_vendaRepository.ListarVendas());
        }

        public IActionResult Create()
        {
            var model = new VendaDto()
            {
                ListaCliente = _clienteRepository.ListarClientes(),
                ListaProduto = _produtoRepository.ListarProdutos()
            };

            return View(model);
        }

        public JsonResult Save(VendaDto model)
        {
            var produto = _produtoRepository.PesquisarProduto(model.IdProduto);
            var cliente = _clienteRepository.PesquisarCliente(model.IdCliente);

            var retorno = new ResponseJsonDto() { Status = true, Mensagem = "ok" };
            var venda = new Venda() { 
                Cliente = cliente, 
                Produto = produto, 
                QuantidadeProduto = model.QuantidadeProduto, 
                ValorUnitario = model.ValorUnitario, 
                DataVenda = model.DataVenda, 
                ValorVenda = model.ValorVenda 
            };
            _vendaRepository.SalvarVenda(venda);
            return Json(retorno);
        }

        [HttpGet("/Venda/Edit")]
        public IActionResult Edit(int idVenda)
        {
            var venda = _vendaRepository.PesquisarVenda(idVenda);
            return View(venda);
        }

        [HttpPost]
        public JsonResult Edit(VendaDto model)
        {
            var retorno = new ResponseJsonDto() { Status = true, Mensagem = "ok" };
            var venda = new Venda()
            {
                Id = model.Id,
                Cliente = model.Cliente,
                Produto = model.Produto,
                QuantidadeProduto = model.QuantidadeProduto,
                ValorUnitario = model.ValorUnitario,
                DataVenda = model.DataVenda,
                ValorVenda = model.ValorVenda
            };
            _vendaRepository.AtualizarVenda(venda);
            return Json(retorno);
        }

        [HttpPost]
        public JsonResult Delete(int idVenda)
        {
            var retorno = new ResponseJsonDto() { Status = true, Mensagem = "ok" };
            _vendaRepository.PesquisarVenda(idVenda);
            _vendaRepository.ExcluirVenda(idVenda);
            return Json(retorno);
        }
    }
}

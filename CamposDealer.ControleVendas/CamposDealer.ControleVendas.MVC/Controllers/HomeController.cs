using CamposDealer.ControleVendas.Db;
using CamposDealer.ControleVendas.Db.Models.ViewModel;
using CamposDealer.ControleVendas.Db.Repositories;
using CamposDealer.ControleVendas.MVC.Models;
using CamposDealer.ControleVendas.Services.Model;
using CamposDealer.ControleVendas.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CamposDealer.ControleVendas.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ClienteRepository _clienteRepository;
        public ProdutoRepository _produtoRepository;
        public VendaRepository _vendaRepository;
        public HomeController(ClienteRepository clienteRepository, ProdutoRepository produtoRepository, VendaRepository vendaRepository)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _vendaRepository = vendaRepository;
        }

        public IActionResult Index()
        {
            if(_clienteRepository.ListarClientes().Count() == 0 && _produtoRepository.ListarProdutos().Count() == 0)
                ViewData["DbEmpty"] = "";
            else
                ViewData["DbEmpty"] = "disabled";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost("/Home/Sinc")]
        public async Task Sinc()
        {
            var venda = new VendaApi();
            var produto = new ProdutoApi();
            var cliente = new ClienteApi();

            List<ClienteApi> listaCliente = await Service.GetCliente();
            List<Cliente> clientes = cliente.ConverterApiParaModel(listaCliente);
            _clienteRepository.SalvarListaCliente(clientes);

            var listaProduto = await Service.GetProduto();
            List<Produto> produtos = produto.ConverterApiParaModel(listaProduto);
            _produtoRepository.SalvarListaProduto(produtos);

            var listaVenda = await Service.GetVenda();
            List<VendaViewModel> vendas = venda.ConverterApiParaModel(listaVenda);
            List<Venda> listaVendas = ConverterViewModelParaModel(vendas);
            _vendaRepository.SalvarListaVenda(listaVendas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Venda> ConverterViewModelParaModel(List<VendaViewModel> vendas)
        {
            List<Venda> venda = new List<Venda>();
            foreach (var v in vendas)
            {
                var produto = _produtoRepository.PesquisarProduto(v.IdProduto);
                var cliente = _clienteRepository.PesquisarCliente(v.IdCliente);

                venda.Add(
                    new Venda()
                    {
                        DataVenda = v.DataVenda,
                        QuantidadeProduto = v.QuantidadeProduto,
                        ValorUnitario = v.ValorUnitario,
                        ValorVenda = v.ValorVenda,
                        Produto = produto,
                        Cliente = cliente
                    });
            }
            return venda;
        }
    }
}
using CamposDealer.ControleVendas.Db;
using CamposDealer.ControleVendas.Db.Repositories;
using CamposDealer.ControleVendas.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CamposDealer.ControleVendas.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        public ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            return View(_produtoRepository.ListarProdutos());
        }

        public IActionResult Create()
        {
            return View();
        }

        public JsonResult Save(ProdutoDto model)
        {
            var retorno = new ResponseJsonDto() { Status = true, Mensagem = "ok" };
            var produto = new Produto() { Nome = model.Nome, Valor = model.Valor };
            _produtoRepository.SalvarProduto(produto);
            return Json(retorno);
        }

        [HttpGet("/Produto/Edit")]
        public IActionResult Edit(int idProduto)
        {
            var cliente = _produtoRepository.PesquisarProduto(idProduto);
            return View(cliente);
        }

        [HttpPost]
        public JsonResult Edit(ProdutoDto model)
        {
            var retorno = new ResponseJsonDto() { Status = true, Mensagem = "ok" };
            var produto = new Produto() { Id = model.Id, Nome = model.Nome, Valor = model.Valor };
            _produtoRepository.AtualizarProduto(produto);
            return Json(retorno);
        }

        [HttpPost]
        public JsonResult Delete(int idProduto)
        {
            var retorno = new ResponseJsonDto() { Status = true, Mensagem = "ok" };
            _produtoRepository.PesquisarProduto(idProduto);
            _produtoRepository.ExcluirProduto(idProduto);
            return Json(retorno);
        }
    }
}

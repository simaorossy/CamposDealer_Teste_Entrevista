using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Db.Repositories
{  
    public class ProdutoRepository
    {
        private readonly CamposDealerContext _CamposDealerContext;

        public ProdutoRepository(CamposDealerContext camposDealerContext)
        {
            _CamposDealerContext = camposDealerContext;
        }

        public IEnumerable<Produto> ListarProdutos() => 
            _CamposDealerContext.Produtos.ToList();

        public Produto PesquisarProduto(int idProduto)
        {
            var produto = _CamposDealerContext.Produtos.FirstOrDefault(x => x.Id == idProduto);

            if (produto == null)
                throw new InvalidOperationException($"Produto id '{idProduto}' não encontrado!");

            return produto;
        }

        public void SalvarProduto(Produto produto)
        {
            _CamposDealerContext.Add(produto);
            _CamposDealerContext.SaveChanges();
        }

        public void AtualizarProduto(Produto produto)
        {
            var product = _CamposDealerContext.Produtos.FirstOrDefault(x => x.Id == produto.Id);
            if(product != null)
            {
                product.Nome = produto.Nome;
                product.Valor = produto.Valor;
                _CamposDealerContext.SaveChanges();
            }           
        }

        public void ExcluirProduto(int idProduto)
        {
            try
            {
                var produto = PesquisarProduto(idProduto);
                _CamposDealerContext.Remove(produto);
                _CamposDealerContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException($"O cliente não pode ser excluido, pois contem uma venda no nome dele!");
            }
        }

        public void SalvarListaProduto(List<Produto> lista)
        {
            _CamposDealerContext.Produtos.AddRange(lista);
            _CamposDealerContext.SaveChanges();
        }
    }
}

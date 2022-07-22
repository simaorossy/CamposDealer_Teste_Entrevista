using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Db.Repositories
{
    public class VendaRepository
    {
        private readonly CamposDealerContext _CamposDealerContext;

        public VendaRepository(CamposDealerContext camposDealerContext)
        {
            _CamposDealerContext = camposDealerContext;
        }

        public IEnumerable<Venda> ListarVendas()
        {
            return _CamposDealerContext.Vendas.Include(x=>x.Produto).Include(x=>x.Cliente).ToList();
        }
            

        public Venda PesquisarVenda(int idVenda)
        {
            var venda = _CamposDealerContext.Vendas.Include(x => x.Produto).Include(x => x.Cliente).FirstOrDefault(x => x.Id == idVenda);

            if (venda == null)
                throw new InvalidOperationException($"Venda id '{idVenda}' não encontrado!");

            return venda;
        }

        public void SalvarVenda(Venda venda)
        {
            _CamposDealerContext.Vendas.Add(venda);
            _CamposDealerContext.SaveChanges();
        }

        public void AtualizarVenda(Venda venda)
        {
            var vend = _CamposDealerContext.Vendas.FirstOrDefault(x => x.Id == venda.Id);
            if(vend != null)
            {
                vend.Cliente = venda.Cliente;
                vend.Produto = venda.Produto;
                vend.QuantidadeProduto = venda.QuantidadeProduto;
                vend.ValorUnitario = venda.ValorUnitario;
                vend.DataVenda = venda.DataVenda;
                vend.ValorVenda = venda.ValorVenda;

                _CamposDealerContext.SaveChanges();
            }           
        }

        public void ExcluirVenda(int idVenda)
        {
            var produto = PesquisarVenda(idVenda);
            _CamposDealerContext.Remove(produto);
            _CamposDealerContext.SaveChanges();
        }

        public void SalvarListaVenda(List<Venda> lista)
        {
            _CamposDealerContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT(Vendas, RESEED, 0)");

            _CamposDealerContext.Vendas.AddRange(lista);
            _CamposDealerContext.SaveChanges();
        }
    }
}

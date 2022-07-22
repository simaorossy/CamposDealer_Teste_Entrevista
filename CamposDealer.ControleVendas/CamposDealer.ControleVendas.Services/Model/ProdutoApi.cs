using CamposDealer.ControleVendas.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Services.Model
{
    public class ProdutoApi
    {
        public int idProduto { get; set; }
        public string dscProduto { get; set; } = default!;
        public float vlrUnitario { get; set; }

        public List<Produto> ConverterApiParaModel(IEnumerable<ProdutoApi> api)
        {
            List<Produto> clientes = new List<Produto>();
            foreach (ProdutoApi produto in api)
            {
                clientes.Add(new Produto() { Nome = produto.dscProduto, Valor = produto.vlrUnitario});
            }
            return clientes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Db.Models.ViewModel
{
    public class VendaViewModel
    {

        public int Id { get; set; } //idVenda
        public int IdProduto { get; set; } //idVenda
        public int IdCliente { get; set; } //idVenda
        public Cliente? Cliente { get; set; } //idCliente
        public Produto? Produto { get; set; } //idProduto
        public int QuantidadeProduto { get; set; } //qtdVenda
        public double ValorUnitario { get; set; } //vlrUnitarioVenda
        public DateTime DataVenda { get; set; } //dthVenda
        public double ValorVenda { get; set; } //vlrTotalVenda

    }
}

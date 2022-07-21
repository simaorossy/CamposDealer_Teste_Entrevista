using CamposDealer.ControleVendas.Db;
using Microsoft.AspNetCore.Mvc;
namespace CamposDealer.ControleVendas.MVC.Models
{
    public class VendaDto
    {
        public IEnumerable<Cliente> ListaCliente { get; set; }
        public IEnumerable<Produto> ListaProduto { get; set; }
        public int Id { get; set; } //idVenda
        public int IdCliente { get; set; } //idVenda
        public Cliente? Cliente { get; set; } //idCliente
        public int IdProduto { get; set; } //idProduto
        public Produto? Produto { get; set; } //idProduto
        public int QuantidadeProduto { get; set; } //qtdVenda
        public double ValorUnitario { get; set; } //vlrUnitarioVenda
        public DateTime DataVenda { get; set; } //dthVenda
        public double ValorVenda { get; set; } //vlrTotalVenda


    }
}

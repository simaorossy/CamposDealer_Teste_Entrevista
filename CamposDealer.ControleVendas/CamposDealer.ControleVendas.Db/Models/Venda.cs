namespace CamposDealer.ControleVendas.Db
{
    public class Venda
    {
        public int Id { get; set; } //idVenda
        public Cliente? Cliente { get; set; } //idCliente
        public Produto? Produto { get; set; } //idProduto
        public int QuantidadeProduto { get; set; } //qtdVenda
        public double ValorUnitario { get; set; } //vlrUnitarioVenda
        public DateTime DataVenda { get; set; } //dthVenda
        public double ValorVenda { get; set; } //vlrTotalVenda

    }
}

using Microsoft.EntityFrameworkCore;

namespace CamposDealer.ControleVendas.Db
{
    public class CamposDealerContext : DbContext
    {
        public CamposDealerContext(DbContextOptions<CamposDealerContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Produto> Produtos { get; set; } = default!;
        public DbSet<Venda> Vendas { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

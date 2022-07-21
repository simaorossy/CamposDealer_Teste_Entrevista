using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Services.Model
{
    public class Produto
    {
        public int idProduto { get; set; }
        public string dscProduto { get; set; } = default!;
        public double vlrUnitario { get; set; }
    }
}

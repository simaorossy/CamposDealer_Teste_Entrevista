using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Services.Model
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nmCliente { get; set; } = default!;
        public string Cidade { get; set; } = default!;
    }
}

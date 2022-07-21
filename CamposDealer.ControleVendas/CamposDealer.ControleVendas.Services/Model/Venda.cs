﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Services.Model
{
    public class Venda
    {
        public int idVenda { get; set; }
        public string dthVenda { get; set; } = default!;
        public int idCliente { get; set; }
        public int idProduto { get; set; }
        public int qtdVenda { get; set; }
        public double vlrUnitarioVenda { get; set; }

    }
}
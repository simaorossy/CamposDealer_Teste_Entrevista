using CamposDealer.ControleVendas.Db;
using CamposDealer.ControleVendas.Db.Models;
using CamposDealer.ControleVendas.Db.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Services.Model
{
    public class VendaApi
    {
        public int idVenda { get; set; }
        public string dthVenda { get; set; } = default!;
        public int idCliente { get; set; }
        public int idProduto { get; set; }
        public int qtdVenda { get; set; }
        public double vlrUnitarioVenda { get; set; }
        public double vlrTotalVenda { get; set; }


        public List<VendaViewModel> ConverterApiParaModel(IEnumerable<VendaApi> api)
        {
            List<VendaViewModel> vendas = new List<VendaViewModel>();
            foreach (VendaApi venda in api)
            {
                //Filtra apenas os numeros do campo dthVenda
                string data = String.Join("", System.Text.RegularExpressions.Regex.Split(venda.dthVenda, @"[^\d]"));

                vendas.Add(
                    new VendaViewModel() 
                    {   IdCliente = venda.idCliente,
                        IdProduto= venda.idProduto,
                        QuantidadeProduto = venda.qtdVenda,
                        ValorUnitario = venda.vlrUnitarioVenda, 
                        ValorVenda = venda.vlrTotalVenda,
                        DataVenda = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(data)).UtcDateTime
                    });
            }
            return vendas;
        }

    }
}

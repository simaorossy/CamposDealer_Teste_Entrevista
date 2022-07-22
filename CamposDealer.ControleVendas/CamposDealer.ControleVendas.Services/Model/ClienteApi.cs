using CamposDealer.ControleVendas.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Services.Model
{
    public class ClienteApi
    {
        public int idCliente { get; set; }
        public string nmCliente { get; set; } = default!;
        public string Cidade { get; set; } = default!;


        public List<Cliente> ConverterApiParaModel(IEnumerable<ClienteApi> api)
        {
            List<Cliente> clientes = new List<Cliente>();
            foreach (ClienteApi cliente in api)
            {
                clientes.Add(new Cliente() { Cidade = cliente.Cidade, Nome = cliente.nmCliente });
            }
            return clientes;
        }
    }
}

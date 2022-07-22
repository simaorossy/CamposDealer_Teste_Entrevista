using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Db.Repositories
{    
    public class ClienteRepository
    {
        private readonly CamposDealerContext _CamposDealerContext;

        public ClienteRepository(CamposDealerContext camposDealerContext)
        {
            _CamposDealerContext = camposDealerContext;
        }

        public IEnumerable<Cliente> ListarClientes() => 
            _CamposDealerContext.Clientes.ToList();

        public Cliente PesquisarCliente(int idCliente)
        {
            var cliente = _CamposDealerContext.Clientes.FirstOrDefault(x => x.Id == idCliente);

            if (cliente == null)
                throw new InvalidOperationException($"Cliente id '{idCliente}' não encontrado!");

            return cliente;
        }

        public void SalvarCliente(Cliente cliente)
        {
            _CamposDealerContext.Add(cliente);
            _CamposDealerContext.SaveChanges();
        }

        public  void AtualizarCliente(Cliente cliente)
        {
            var client = _CamposDealerContext.Clientes.FirstOrDefault(x => x.Id == cliente.Id);
            if(client != null)
            {
                client.Nome = cliente.Nome;
                client.Cidade = cliente.Cidade;
                _CamposDealerContext.SaveChanges();
            }           
        }

        public void ExcluirCliente(int idCliente)
        {
            try
            {
                var cliente = PesquisarCliente(idCliente);
                _CamposDealerContext.Remove(cliente);
                _CamposDealerContext.SaveChanges();
            }catch(DbUpdateException e)
            {
                throw new DbUpdateException($"O cliente não pode ser excluido, pois contem uma venda no nome dele!");
            }            
        }

        public void SalvarListaCliente(List<Cliente> clientes)
        {
            //zerar PK
            _CamposDealerContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT(Clientes, RESEED, 0)");

            _CamposDealerContext.AddRange(clientes);            
            _CamposDealerContext.SaveChanges();
        }
    }
}

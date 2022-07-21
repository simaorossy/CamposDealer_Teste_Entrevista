using CamposDealer.ControleVendas.Db;
using Microsoft.AspNetCore.Mvc;
namespace CamposDealer.ControleVendas.MVC.Models
{
    public class ClienteDto
    {
        public int Id { get; set; } //idCliente
        public string Nome { get; set; } = default!;//nmCliente
        public string Cidade { get; set; } = default!; //Cidade


    }
}

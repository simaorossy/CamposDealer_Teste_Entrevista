using CamposDealer.ControleVendas.Services.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Services.Service
{
    public class Service
    {
        const string _endPoint = "https://camposdealer.dev/Sites/TesteAPI";

        public static async Task<List<ClienteApi>> GetCliente()
        {
            var cliente = new List<ClienteApi>(); 
            try 
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync($"{_endPoint}/cliente");
                    var retornoJson = JsonConvert.DeserializeObject(response).ToString();
                    var retorno = JsonConvert.DeserializeObject<List<ClienteApi>>(retornoJson);
                    return retorno;
                }
            }
            catch (Exception ex){return cliente;}
            return cliente;
        }

        public static async Task<List<ProdutoApi>> GetProduto()
        {
            var produto = new List<ProdutoApi>();
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"{_endPoint}/produto").ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        //converter para json
                        var retornoJson = JsonConvert.DeserializeObject(result).ToString();
                        var retorno = JsonConvert.DeserializeObject<List<ProdutoApi>>(retornoJson);
                        return retorno;
                    }
                }
            }
            catch (Exception e){return produto;}
            return produto;
        }
        public static async Task<List<VendaApi>> GetVenda()
        {
            var venda = new List<VendaApi>();
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"{_endPoint}/venda").ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        //converter para json
                        var retornoJson = JsonConvert.DeserializeObject(result)!.ToString();
                        var retorno = JsonConvert.DeserializeObject<List<VendaApi>>(retornoJson);

                        return retorno;
                    }
                }
            }
            catch (Exception e){ return venda; }
            return venda;
        }       
    }
}

using CamposDealer.ControleVendas.Services.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamposDealer.ControleVendas.Services.Service
{
    public static class Service
    {
        const string _endPoint = "https://camposdealer.dev/Sites/TesteAPI";

        public static async Task<List<Cliente>> GetCliente()
        {            
            var cliente = new List<Cliente>();
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"{_endPoint}/cliente").ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {                        
                        var result = response.Content.ReadAsStringAsync().Result;                        
                        //converter para json
                        var retornoJson = JsonConvert.DeserializeObject(result).ToString();
                        var retorno = JsonConvert.DeserializeObject<List<Cliente>>(retornoJson);
                        return retorno;
                    }
                    else
                    {
                        return cliente;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return cliente;
        }

        public static async Task<List<Produto>> GetProduto()
        {
            var produto = new List<Produto>();
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
                        var retorno = JsonConvert.DeserializeObject<List<Produto>>(retornoJson);
                        return retorno;
                    }
                    else
                    {
                        return produto;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return produto;
        }
        public static async Task<List<Venda>> GetVenda()
        {
            var venda = new List<Venda>();
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"{_endPoint}/venda").ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        //converter para json
                        var retornoJson = JsonConvert.DeserializeObject(result).ToString();
                        var retorno = JsonConvert.DeserializeObject<List<Venda>>(retornoJson);
                        return retorno;
                    }
                    else
                    {
                        return venda;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return venda;
        }
    }
}

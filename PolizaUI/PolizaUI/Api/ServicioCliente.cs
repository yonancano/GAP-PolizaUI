using Newtonsoft.Json;
using PolizaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PolizaUI.Api
{
    static class ServicioCliente
    {
        private const string BaseUrl = "https://localhost:5001";

        public static async Task<Cliente> ObtengaCliente(int id)
        {

            Cliente Cliente = new Cliente();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("/ObtengaCliente?id="+id);

                if (res.IsSuccessStatusCode)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    Cliente = JsonConvert.DeserializeObject<Cliente>(response);
                }
            }

            return Cliente;
        }

    }
}
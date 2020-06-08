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
        //Hosted web API REST Service base url  
        private const string BaseUrl = "https://localhost:5001";

        public static async Task<Cliente> ObtengaCliente(int id)
        {

            Cliente Cliente = new Cliente();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("/ObtengaCliente/"+id);

                if (res.IsSuccessStatusCode)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    Cliente = JsonConvert.DeserializeObject<Cliente>(response);
                }
            }

            return Cliente;
        }

        public static async void AsociarPoliza(int idCliente, Poliza poliza)
        {
            //validacion alta => 50%
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                StringContent content = new StringContent(JsonConvert.SerializeObject(poliza), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/AsociarPoliza/"+idCliente, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public static async void CancelarPoliza(int idCliente, int idPoliza)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                using (var response = await client.DeleteAsync("/EliminePoliza/" + idCliente+"/"+idPoliza))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

    }
}

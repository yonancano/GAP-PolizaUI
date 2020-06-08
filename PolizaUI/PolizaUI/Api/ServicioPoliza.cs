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
    static class ServicioPoliza
    {
        private const string BaseUrl = "https://localhost:5001";

        public static async Task<List<Poliza>> ObtengaPolizas() 
        {
            
            List<Poliza> Polizas = new List<Poliza>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("/ObtengaPolizas/");

                if (res.IsSuccessStatusCode)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    Polizas = JsonConvert.DeserializeObject<List<Poliza>>(response);
                }
            }

            return Polizas;
        }

        public static async Task<Poliza> ObtengaPolizaPorId(int id)
        {

            Poliza Poliza = new Poliza();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("/ObtengaPoliza/"+ id);

                if (res.IsSuccessStatusCode)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    Poliza = JsonConvert.DeserializeObject<Poliza>(response);
                }
            }

            return Poliza;
        }

    }
}


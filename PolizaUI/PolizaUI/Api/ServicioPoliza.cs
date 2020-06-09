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

                var res = await client.GetAsync("/Obtener/");

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

                var res = await client.GetAsync("/ObtenerPorId?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    Poliza = JsonConvert.DeserializeObject<Poliza>(response);
                }
            }

            return Poliza;
        }

        public static async void AsignarPoliza(Poliza poliza)
        {
            //validacion alta => 50%
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                StringContent content = new StringContent(JsonConvert.SerializeObject(poliza), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/AsignePoliza", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public static async void CancelarPoliza(int id)
        {
            Poliza Poliza = new Poliza();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                //obtener poliza
                var res = await client.GetAsync("/ObtenerPorId?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    Poliza = JsonConvert.DeserializeObject<Poliza>(response);
                }

                //cancelar poliza
                StringContent content = new StringContent(JsonConvert.SerializeObject(Poliza), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/CancelePoliza", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public static async Task<List<Poliza>> ObtengaPolizasCliente(int id)
        {

            List<Poliza> Polizas = new List<Poliza>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await client.GetAsync("/ObtengaPolizasCliente/?id="+id);

                if (res.IsSuccessStatusCode)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    Polizas = JsonConvert.DeserializeObject<List<Poliza>>(response);
                }
            }

            return Polizas;
        }

        public static async void AgregarPoliza(Poliza poliza)
        {
            //validacion alta => 50%
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                StringContent content = new StringContent(JsonConvert.SerializeObject(poliza), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/AgreguePoliza", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public static async void EditarPoliza(Poliza poliza)
        {
            //validacion alta => 50%
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                StringContent content = new StringContent(JsonConvert.SerializeObject(poliza), Encoding.UTF8, "application/json");

                using (var response = await client.PutAsync("/EditePoliza", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public static async void EliminarPoliza(int id)
        {
            Poliza Poliza = new Poliza();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                //obtener poliza
                var res = await client.GetAsync("/ObtenerPorId?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var response = await res.Content.ReadAsStringAsync();
                    Poliza = JsonConvert.DeserializeObject<Poliza>(response);
                }

                //cancelar poliza
                StringContent content = new StringContent(JsonConvert.SerializeObject(Poliza), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/Eliminar", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}


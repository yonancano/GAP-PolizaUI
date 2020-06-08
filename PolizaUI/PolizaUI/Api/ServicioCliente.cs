using Newtonsoft.Json;
using PolizaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PolizaUI.Api
{
    static class ServicioCliente
    {
        //Hosted web API REST Service base url  
        private const string BaseUrl = "https://localhost:5001";

        public static async Task<List<Poliza>> ObtengaCliente() 
        {
            
            List<Poliza> Polizas = new List<Poliza>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource ObtengaPolizas using HttpClient  
                HttpResponseMessage Res =  await client.GetAsync("/ObtengaPolizas");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Polizas list  
                    Polizas = JsonConvert.DeserializeObject<List<Poliza>>(response);
                }
            }

            return Polizas;
        }

        public static void AsignarPoliza(Cliente cliente, Poliza poliza)
        {
        }

        public static async Task<bool> CancelarPoliza(Poliza poliza)
        {
            return true;
        }

    }
}

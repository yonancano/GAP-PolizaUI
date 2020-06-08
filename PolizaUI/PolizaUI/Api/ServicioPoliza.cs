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
    static class ServicioPoliza
    {
        //Hosted web API REST Service base url  
        private const string BaseUrl = "https://localhost:5001";

        public static async Task<List<Poliza>> ObtengaPolizas() 
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

        public static async Task<Poliza> ObtengaPolizaPorId(int id)
        {

            Poliza Poliza = new Poliza();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource ObtengaPolizas using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/ObtengaPoliza/"+ id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Polizas list  
                    Poliza = JsonConvert.DeserializeObject<Poliza>(response);
                }
            }

            return Poliza;
        }

        public static void AgreguePoliza(Poliza poliza)
        {
            //validacion alta => 50%
        }

        public static async Task<bool> EditePoliza(Poliza poliza)
        {
            //validacion alta => 50%
            return true;
        }

        public static async Task<bool> EliminePoliza(int id)
        {
            return true;
        }

    }
}

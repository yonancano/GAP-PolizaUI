using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PolizaUI.Api;
using PolizaUI.Models;

namespace PolizaUI.Controllers
{
    public class PolizasController : Controller
    {
        private readonly ILogger<PolizasController> _logger;
        
        private const string BaseUrl = "https://localhost:5001";

        public PolizasController(ILogger<PolizasController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            List<Poliza> Polizas = new List<Poliza>();

            try
            {
                Polizas = ServicioPoliza.ObtengaPolizas().Result;
            }
            catch (Exception)
            {
                throw new NotImplementedException("Ocurrió un problema al consultar las pólizas");
            }

            return View(Polizas);
        }

        public ActionResult Detalles(int id)
        {
            Poliza Poliza;

            try
            {
                Poliza = ServicioPoliza.ObtengaPolizaPorId(id).Result;
            }
            catch (Exception)
            {

                throw new NotImplementedException("No se completó la acción de carga.");
            }

            return View(Poliza);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Agregar(Poliza poliza)
        {
            try
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
            catch (Exception)
            {

                throw new NotImplementedException("No se completó la acción agregar.");
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Editar(int id)
        {
            Poliza Poliza = new Poliza();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await client.GetAsync("/ObtengaPoliza/" + id);

                    if (res.IsSuccessStatusCode)
                    {
                        var response = await res.Content.ReadAsStringAsync();
                        Poliza = JsonConvert.DeserializeObject<Poliza>(response);
                    }
                }
            }
            catch (Exception)
            {

                throw new NotImplementedException("No se completó la acción de carga.");
            }

            return View(Poliza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Poliza poliza)
        {
            try
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
            catch
            {
                throw new NotImplementedException("No se completó la acción editar.");
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Eliminar(int id)
        {
            Poliza Poliza = new Poliza();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await client.GetAsync("/ObtengaPoliza/" + id);

                    if (res.IsSuccessStatusCode)
                    {
                        var response = await res.Content.ReadAsStringAsync();
                        Poliza = JsonConvert.DeserializeObject<Poliza>(response);
                    }
                }
            }
            catch (Exception)
            {

                throw new NotImplementedException("No se completó la acción de carga.");
            }

            return View(Poliza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Elimine(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();

                    using (var response = await client.DeleteAsync("/EliminePoliza/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch
            {
                throw new NotImplementedException("No se completó la acción eliminar.");
            }

            return RedirectToAction("Index");
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

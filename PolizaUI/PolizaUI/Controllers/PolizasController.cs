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
            Poliza Poliza = new Poliza();

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
        public ActionResult Agregar(Poliza poliza)
        {
            try
            {
                ServicioPoliza.AgregarPoliza(poliza);
            }
            catch (Exception)
            {

                throw new NotImplementedException("No se completó la acción agregar.");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Poliza Poliza = new Poliza();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Poliza poliza)
        {
            try
            {
                ServicioPoliza.EditarPoliza(poliza);
            }
            catch
            {
                throw new NotImplementedException("No se completó la acción editar.");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Poliza Poliza = new Poliza();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Elimine(int id)
        {
            try
            {
                ServicioPoliza.EliminarPoliza(id);
            }
            catch
            {
                throw new NotImplementedException("No se completó la acción eliminar.");
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

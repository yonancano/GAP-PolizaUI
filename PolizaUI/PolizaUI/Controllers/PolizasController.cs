using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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


        // GET: PolizasController
        public ActionResult Index()
        {
            List<Poliza> Polizas = new List<Poliza>();

            try
            {
                Polizas = ServicioPoliza.ObtengaPolizas().Result;
            }
            catch (Exception)
            {
                //Error();
                throw new NotImplementedException("error en index");
            }

            return View(Polizas);
        }

        // GET: PolizasController/Details/5
        public ActionResult Detalles(int id)
        {
            Poliza Poliza;

            try
            {
                Poliza = ServicioPoliza.ObtengaPolizaPorId(id).Result;
            }
            catch (Exception)
            {

                throw new NotImplementedException("No se completo la acción [].");
            }

            return View(Poliza);
        }

        // GET: PolizasController/Create
        public ActionResult Agregar()
        {
            return View();
        }

        // POST: PolizasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgreguePoliza(Poliza poliza)
        {
            try
            {
                ServicioPoliza.AgreguePoliza(poliza);
            }
            catch (Exception)
            {

                throw new NotImplementedException("No se completo la acción [].");
            }

            return Index();
        }

        // GET: PolizasController/Edit/5
        public ActionResult Editar(int id)
        {
            Poliza Poliza;

            try
            {
                Poliza = ServicioPoliza.ObtengaPolizaPorId(id).Result;
            }
            catch (Exception)
            {

                throw new NotImplementedException("No se completo la acción [].");
            }

            return View(Poliza);
        }

        // POST: PolizasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Poliza poliza)
        {
            try
            {
                var resultado = ServicioPoliza.EditePoliza(poliza);
            }
            catch
            {
                throw new NotImplementedException("No se completo la acción [].");
            }
                return Index();
        }

        // GET: PolizasController/Delete/5
        public ActionResult Eliminar(int id)
        {
            Poliza Poliza;

            try
            {
                Poliza = ServicioPoliza.ObtengaPolizaPorId(id).Result;
            }
            catch (Exception)
            {

                throw new NotImplementedException("No se completo la acción [].");
            }

            return View(Poliza);
        }

        // POST: PolizasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var resultado = ServicioPoliza.EliminePoliza(id);
            }
            catch
            {
                throw new NotImplementedException("No se completo la acción [].");
            }
            return Index();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

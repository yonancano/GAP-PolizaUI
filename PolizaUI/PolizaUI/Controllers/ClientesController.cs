using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolizaUI.Api;
using PolizaUI.Models;

namespace PolizaUI.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(int IdCliente)
        {
            Cliente Cliente = new Cliente();
            try
            {
                Cliente = ServicioCliente.ObtengaCliente(IdCliente).Result;
                Cliente.MisPolizas = ServicioPoliza.ObtengaPolizasCliente(IdCliente).Result;
            }
            catch (Exception)
            {
                throw new NotImplementedException("Ocurrió un problema al consultar el cliente");
            }

            return View("MisPolizas", Cliente);
        }

        public ActionResult Asignar(int id)
        {
            var poliza = new Poliza() { IdCliente = id };
            return View(poliza);
        }


        [HttpPost]
        public ActionResult Asignar(Poliza poliza)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServicioPoliza.AsignarPoliza(poliza);
                }
                else
                {
                    return View(poliza);
                }
            }
            catch (Exception)
            {

                throw new NotImplementedException("No se completó la acción Asignar.");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Cancelar(int id)
        {
            try
            {
                ServicioPoliza.CancelarPoliza(id);
            }
            catch
            {
                throw new NotImplementedException("No se completó la acción Cancelar.");
            }

            return RedirectToAction("Index");
        }
    }
}
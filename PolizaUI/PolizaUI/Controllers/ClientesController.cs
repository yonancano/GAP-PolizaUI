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
            }
            catch (Exception)
            {
                throw new NotImplementedException("Ocurrió un problema al consultar el cliente");
            }

            return View("MisPolizas", Cliente);
        }

        public ActionResult Asociar(Cliente cliente)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Asociar(int idCliente, Poliza poliza)
        {
            try
            {
                ServicioCliente.AsociarPoliza(idCliente, poliza);
            }
            catch (Exception)
            {

                throw new NotImplementedException("No se completó la acción asociar.");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancelar(int idCliente, int idPoliza)
        {
            try
            {
                ServicioCliente.CancelarPoliza(idCliente, idPoliza);
            }
            catch
            {
                throw new NotImplementedException("No se completó la acción cancelación.");
            }

            return RedirectToAction("Index");
        }
    }
}
using Consultorio_de_seguros.DataAccess.Interfaces;
using Consultorio_de_seguros.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio_de_seguros.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IAsignacionService _asignacionService;

        public ConsultaController(IAsignacionService asignacionService)
        {
            _asignacionService = asignacionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResultadosAsegurados()
        {
            return View();
        }

        public IActionResult ResultadosSeguros()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarAsignaciones(string criterioBusqueda)
        {
            if (string.IsNullOrWhiteSpace(criterioBusqueda))
            {
                TempData["ErrorMessage"] = "Por favor ingrese un número de cédula o código de seguro.";
                return RedirectToAction(nameof(Index));
            }

            // Intentar obtener seguros por cédula
            var seguros = await _asignacionService.ObtenerSegurosPorCedulaAsync(criterioBusqueda);
            if (seguros.Any())
            {
                return View("ResultadosSeguros", seguros);
            }

            // Intentar obtener asegurados por código de seguro
            var asegurados = await _asignacionService.ObtenerAseguradosPorCodigoAsync(criterioBusqueda);
            if (asegurados.Any())
            {
                return View("ResultadosAsegurados", asegurados);
            }

            TempData["ErrorMessage"] = "No se encontraron resultados.";
            return RedirectToAction(nameof(Index));
        }
    }
}

using Consultorio_de_seguros.Models;
using Consultorio_de_seguros.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio_de_seguros.Controllers
{
    public class AseguradosController : Controller
    {
        private readonly IAseguradoService _aseguradoService;

        public AseguradosController(IAseguradoService aseguradoService)
        {
            _aseguradoService = aseguradoService;
        }

        public async Task<IActionResult> Index()
        {
            var asegurados = await _aseguradoService.ObtenerTodosAsync();
            return View(asegurados);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Asegurado asegurado)
        {
            if (ModelState.IsValid)
            {
                await _aseguradoService.CrearAsync(asegurado);
                return RedirectToAction(nameof(Index));
            }
            return View(asegurado);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var asegurado = await _aseguradoService.ObtenerPorIdAsync(id);
            if (asegurado == null) return NotFound();
            return View(asegurado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Asegurado asegurado)
        {
            if (ModelState.IsValid)
            {
                await _aseguradoService.ActualizarAsync(asegurado);
                return RedirectToAction(nameof(Index));
            }
            return View(asegurado);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            await _aseguradoService.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

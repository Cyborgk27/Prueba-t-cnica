using Consultorio_de_seguros.Models;
using Consultorio_de_seguros.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio_de_seguros.Controllers
{
    public class SegurosController : Controller
    {
        private readonly ISeguroService _seguroService;

        public SegurosController(ISeguroService seguroService)
        {
            _seguroService = seguroService;
        }

        public async Task<IActionResult> Index()
        {
            var seguros = await _seguroService.ObtenerTodosAsync();
            return View(seguros);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Seguro seguro)
        {
            if (ModelState.IsValid)
            {
                await _seguroService.CrearAsync(seguro);
                return RedirectToAction(nameof(Index));
            }
            return View(seguro);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var seguro = await _seguroService.ObtenerPorIdAsync(id);
            if (seguro == null) return NotFound();
            return View(seguro);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Seguro seguro)
        {
            if (ModelState.IsValid)
            {
                await _seguroService.ActualizarAsync(seguro);
                return RedirectToAction(nameof(Index));
            }
            return View(seguro);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var seguro = await _seguroService.ObtenerPorIdAsync(id);
            if (seguro == null) return NotFound();
            return View(seguro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmed(int id)
        {
            await _seguroService.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

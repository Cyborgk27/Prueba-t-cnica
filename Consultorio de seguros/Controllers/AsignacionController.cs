using Consultorio_de_seguros.Models;
using Consultorio_de_seguros.Services;
using Consultorio_de_seguros.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio_de_seguros.Controllers
{
    public class AsignacionController : Controller
    {
        private readonly IAsignacionService _asignacionService;
        private readonly IAseguradoService _aseguradoService;
        private readonly ISeguroService _seguroService;

        public AsignacionController(IAsignacionService asignacionService, IAseguradoService aseguradoService, ISeguroService seguroService)
        {
            _asignacionService = asignacionService;
            _aseguradoService = aseguradoService;
            _seguroService = seguroService;
        }

        public async Task<IActionResult> Index()
        {
            var asignaciones = await _asignacionService.ObtenerTodosAsync();
            return View(asignaciones);
        }

        public async Task<IActionResult> Create()
        {
            var asegurados = await _aseguradoService.ObtenerTodosAsync();
            var seguros = await _seguroService.ObtenerTodosAsync();

            ViewBag.Asegurados = asegurados;
            ViewBag.Seguros = seguros;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AsignacionSeguroAsegurado asignacion)
        {
            if (ModelState.IsValid)
            {
                await _asignacionService.CrearAsync(asignacion);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Asegurados = await _aseguradoService.ObtenerTodosAsync();
            ViewBag.Seguros = await _seguroService.ObtenerTodosAsync();

            return View(asignacion);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var asignacion = await _asignacionService.ObtenerPorIdAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            return View(asignacion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _asignacionService.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult MassiveLoad()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MassiveLoad(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["ErrorMessage"] = "Por favor, selecciona un archivo válido.";
                return RedirectToAction(nameof(MassiveLoad));
            }

            try
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        var datos = line!.Split(';');

                        // Suponiendo que el archivo tiene el formato: Cedula,Nombre,Telefono,Edad
                        var asegurado = new Asegurado
                        {
                            Cedula = datos[0],
                            Nombre = datos[1],
                            Telefono = datos[2],
                            Edad = int.Parse(datos[3])
                        };

                        await _aseguradoService.CrearAsync(asegurado);

                        Seguro? seguroAsignado = null!;

                        if (asegurado.Edad < 20)
                        {
                            seguroAsignado = await _seguroService.ObtenerPorIdAsync(1);
                        }
                        else if (asegurado.Edad >= 20 && asegurado.Edad < 30)
                        {
                            seguroAsignado = await _seguroService.ObtenerPorIdAsync(2);
                        }
                        else if (asegurado.Edad >= 31 && asegurado.Edad < 40)
                        {
                            seguroAsignado = await _seguroService.ObtenerPorIdAsync(3);
                        }
                        else if (asegurado.Edad >= 41)
                        {
                            seguroAsignado = await _seguroService.ObtenerPorIdAsync(4);
                        }

                        if (seguroAsignado != null)
                        {
                            var asignacion = new AsignacionSeguroAsegurado
                            {
                                AseguradoId = asegurado.AseguradoId,
                                SeguroId = seguroAsignado.SeguroId
                            };

                            await _asignacionService.CrearAsync(asignacion);
                        }
                    }
                }

                TempData["SuccessMessage"] = "Carga masiva completada con éxito.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Se produjo un error: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

    }
}

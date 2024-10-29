using Consultorio_de_seguros.DataAccess.Interfaces;
using Consultorio_de_seguros.Models;
using Consultorio_de_seguros.Services.Interfaces;

namespace Consultorio_de_seguros.Services
{
    public class AsignacionService : IAsignacionService
    {
        private readonly IAsignacionRepository _asignacionRepository;

        public AsignacionService(IAsignacionRepository asignacionRepository)
        {
            _asignacionRepository = asignacionRepository;
        }

        public async Task<AsignacionSeguroAsegurado?> ObtenerPorIdAsync(int id)
        {
            return await _asignacionRepository.ObtenerPorIdAsync(id);
        }

        public async Task<List<AsignacionSeguroAsegurado>> ObtenerTodosAsync()
        {
            return await _asignacionRepository.ObtenerTodasAsync();
        }

        public async Task CrearAsync(AsignacionSeguroAsegurado asignacion)
        {
            await _asignacionRepository.CrearAsync(asignacion);
        }

        public async Task ActualizarAsync(AsignacionSeguroAsegurado asignacion)
        {
            await _asignacionRepository.ActualizarAsync(asignacion);
        }

        public async Task EliminarAsync(int id)
        {
            await _asignacionRepository.EliminarAsync(id);
        }

        public async Task<List<Seguro>> ObtenerSegurosPorCedulaAsync(string cedula)
        {
            var asignaciones = await _asignacionRepository.ObtenerTodasAsync();
            return asignaciones
                .Where(a => a.Asegurado?.Cedula == cedula)
                .Select(a => a.Seguro!)
                .ToList();
        }

        public async Task<List<Asegurado>> ObtenerAseguradosPorCodigoAsync(string codigoSeguro)
        {
            var asignaciones = await _asignacionRepository.ObtenerTodasAsync();
            return asignaciones
                .Where(a => a.Seguro?.CodigoSeguro == codigoSeguro)
                .Select(a => a.Asegurado!)
                .ToList();
        }
    }

}

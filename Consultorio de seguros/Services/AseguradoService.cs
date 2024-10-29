using Consultorio_de_seguros.DataAccess.Interfaces;
using Consultorio_de_seguros.Models;
using Consultorio_de_seguros.Services.Interfaces;

namespace Consultorio_de_seguros.Services
{
    public class AseguradoService : IAseguradoService
    {
        private readonly IAseguradoRepository _aseguradoRepository;

        public AseguradoService(IAseguradoRepository aseguradoRepository)
        {
            _aseguradoRepository = aseguradoRepository;
        }

        public async Task<Asegurado?> ObtenerPorIdAsync(int id)
        {
            return await _aseguradoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<List<Asegurado>> ObtenerTodosAsync()
        {
            return await _aseguradoRepository.ObtenerTodosAsync();
        }

        public async Task CrearAsync(Asegurado asegurado)
        {
            await _aseguradoRepository.CrearAsync(asegurado);
        }

        public async Task ActualizarAsync(Asegurado asegurado)
        {
            await _aseguradoRepository.ActualizarAsync(asegurado);
        }

        public async Task EliminarAsync(int id)
        {
            await _aseguradoRepository.EliminarAsync(id);
        }
    }
}

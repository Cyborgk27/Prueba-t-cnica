using Consultorio_de_seguros.DataAccess.Interfaces;
using Consultorio_de_seguros.Models;
using Consultorio_de_seguros.Services.Interfaces;

namespace Consultorio_de_seguros.Services
{
    public class SeguroService : ISeguroService
    {
        private readonly ISeguroRepository _seguroRepository;

        public SeguroService(ISeguroRepository seguroRepository)
        {
            _seguroRepository = seguroRepository;
        }

        public async Task<Seguro?> ObtenerPorIdAsync(int id)
        {
            return await _seguroRepository.ObtenerPorIdAsync(id);
        }

        public async Task<List<Seguro>> ObtenerTodosAsync()
        {
            return await _seguroRepository.ObtenerTodosAsync();
        }

        public async Task CrearAsync(Seguro seguro)
        {
            await _seguroRepository.CrearAsync(seguro);
        }

        public async Task ActualizarAsync(Seguro seguro)
        {
            await _seguroRepository.ActualizarAsync(seguro);
        }

        public async Task EliminarAsync(int id)
        {
            await _seguroRepository.EliminarAsync(id);
        }
    }

}

using Consultorio_de_seguros.Models;

namespace Consultorio_de_seguros.Services.Interfaces
{
    public interface ISeguroService
    {
        Task<Seguro?> ObtenerPorIdAsync(int id);
        Task<List<Seguro>> ObtenerTodosAsync();
        Task CrearAsync(Seguro seguro);
        Task ActualizarAsync(Seguro seguro);
        Task EliminarAsync(int id);
    }
}

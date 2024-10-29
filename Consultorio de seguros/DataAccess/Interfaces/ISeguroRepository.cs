using Consultorio_de_seguros.Models;

namespace Consultorio_de_seguros.DataAccess.Interfaces
{
    public interface ISeguroRepository
    {
        Task<List<Seguro>> ObtenerTodosAsync();
        Task<Seguro?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Seguro seguro);
        Task ActualizarAsync(Seguro seguro);
        Task EliminarAsync(int id);
    }
}

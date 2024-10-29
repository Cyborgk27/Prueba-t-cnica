using Consultorio_de_seguros.Models;

namespace Consultorio_de_seguros.DataAccess.Interfaces
{
    public interface IAseguradoRepository
    {
        Task<List<Asegurado>> ObtenerTodosAsync();
        Task<Asegurado?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Asegurado asegurado);
        Task ActualizarAsync(Asegurado asegurado);
        Task EliminarAsync(int id);
    }
}
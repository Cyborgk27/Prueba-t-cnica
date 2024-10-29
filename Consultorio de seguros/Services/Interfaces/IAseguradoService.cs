using Consultorio_de_seguros.Models;

namespace Consultorio_de_seguros.Services.Interfaces
{
    public interface IAseguradoService
    {
        Task<Asegurado?> ObtenerPorIdAsync(int id);
        Task<List<Asegurado>> ObtenerTodosAsync();
        Task CrearAsync(Asegurado asegurado);
        Task ActualizarAsync(Asegurado asegurado);
        Task EliminarAsync(int id);
    }
}

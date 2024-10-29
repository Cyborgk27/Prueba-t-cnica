using Consultorio_de_seguros.Models;

namespace Consultorio_de_seguros.DataAccess.Interfaces
{
    public interface IAsignacionRepository
    {
        Task<AsignacionSeguroAsegurado?> ObtenerPorIdAsync(int id);
        Task<List<AsignacionSeguroAsegurado>> ObtenerTodasAsync();
        Task CrearAsync(AsignacionSeguroAsegurado asignacion);
        Task ActualizarAsync(AsignacionSeguroAsegurado asignacion);
        Task EliminarAsync(int id);
    }
}

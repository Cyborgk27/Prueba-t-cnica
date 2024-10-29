using Consultorio_de_seguros.Models;

namespace Consultorio_de_seguros.Services.Interfaces
{
    public interface IAsignacionService
    {
        Task<AsignacionSeguroAsegurado?> ObtenerPorIdAsync(int id);
        Task<List<AsignacionSeguroAsegurado>> ObtenerTodosAsync();
        Task CrearAsync(AsignacionSeguroAsegurado asignacion);
        Task ActualizarAsync(AsignacionSeguroAsegurado asignacion);
        Task EliminarAsync(int id);
        Task<List<Seguro>> ObtenerSegurosPorCedulaAsync(string cedula);
        Task<List<Asegurado>> ObtenerAseguradosPorCodigoAsync(string codigoSeguro);
    }
}

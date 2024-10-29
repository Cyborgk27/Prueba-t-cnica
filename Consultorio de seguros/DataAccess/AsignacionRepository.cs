using Consultorio_de_seguros.DataAccess.Interfaces;
using Consultorio_de_seguros.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio_de_seguros.DataAccess
{
    public class AsignacionRepository : IAsignacionRepository
    {
        private readonly ConsultorioSegurosContext _context;

        public AsignacionRepository(ConsultorioSegurosContext context)
        {
            _context = context;
        }

        public async Task<AsignacionSeguroAsegurado?> ObtenerPorIdAsync(int id)
        {
            return await _context.Asignaciones.FindAsync(id);
        }

        public async Task<List<AsignacionSeguroAsegurado>> ObtenerTodasAsync()
        {
            return await _context.Asignaciones.Include(a => a.Asegurado).Include(a => a.Seguro).ToListAsync();
        }

        public async Task CrearAsync(AsignacionSeguroAsegurado asignacion)
        {
            await _context.Asignaciones.AddAsync(asignacion);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(AsignacionSeguroAsegurado asignacion)
        {
            _context.Asignaciones.Update(asignacion);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var asignacion = await ObtenerPorIdAsync(id);
            if (asignacion != null)
            {
                _context.Asignaciones.Remove(asignacion);
                await _context.SaveChangesAsync();
            }
        }
    }

}

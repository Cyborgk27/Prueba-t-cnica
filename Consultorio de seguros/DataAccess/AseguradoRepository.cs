using Consultorio_de_seguros.DataAccess.Interfaces;
using Consultorio_de_seguros.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio_de_seguros.DataAccess
{
    public class AseguradoRepository : IAseguradoRepository
    {
        private readonly ConsultorioSegurosContext _context;

        public AseguradoRepository(ConsultorioSegurosContext context)
        {
            _context = context;
        }

        public async Task<List<Asegurado>> ObtenerTodosAsync()
        {
            return await _context.Asegurados.ToListAsync();
        }

        public async Task<Asegurado?> ObtenerPorIdAsync(int id)
        {
            return await _context.Asegurados.FindAsync(id);
        }

        public async Task CrearAsync(Asegurado asegurado)
        {
            await _context.Asegurados.AddAsync(asegurado);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Asegurado asegurado)
        {
            _context.Asegurados.Update(asegurado);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var asegurado = await _context.Asegurados.FindAsync(id);
            if (asegurado != null)
            {
                _context.Asegurados.Remove(asegurado);
                await _context.SaveChangesAsync();
            }
        }
    }
}

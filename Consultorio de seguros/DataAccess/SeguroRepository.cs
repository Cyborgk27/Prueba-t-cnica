using Consultorio_de_seguros.DataAccess.Interfaces;
using Consultorio_de_seguros.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio_de_seguros.DataAccess
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly ConsultorioSegurosContext _context;

        public SeguroRepository(ConsultorioSegurosContext context)
        {
            _context = context;
        }

        public async Task<List<Seguro>> ObtenerTodosAsync()
        {
            return await _context.Seguros.ToListAsync();
        }

        public async Task<Seguro?> ObtenerPorIdAsync(int id)
        {
            return await _context.Seguros.FindAsync(id);
        }

        public async Task CrearAsync(Seguro seguro)
        {
            await _context.Seguros.AddAsync(seguro);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Seguro seguro)
        {
            _context.Seguros.Update(seguro);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var seguro = await _context.Seguros.FindAsync(id);
            if (seguro != null)
            {
                _context.Seguros.Remove(seguro);
                await _context.SaveChangesAsync();
            }
        }
    }
}

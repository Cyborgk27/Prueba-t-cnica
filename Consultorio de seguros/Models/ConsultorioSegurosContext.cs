using Microsoft.EntityFrameworkCore;

namespace Consultorio_de_seguros.Models
{
    public class ConsultorioSegurosContext : DbContext
    {
        public ConsultorioSegurosContext() { }
        public ConsultorioSegurosContext(DbContextOptions<ConsultorioSegurosContext> options) : base(options) { }

        public DbSet<Seguro> Seguros { get; set; }
        public DbSet<Asegurado> Asegurados { get; set; }
        public DbSet<AsignacionSeguroAsegurado> Asignaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsignacionSeguroAsegurado>()
                .HasKey(a => a.AsignacionId);

            modelBuilder.Entity<AsignacionSeguroAsegurado>()
                .HasOne(a => a.Asegurado)
                .WithMany(b => b.Asignaciones)
                .HasForeignKey(a => a.AseguradoId);

            modelBuilder.Entity<AsignacionSeguroAsegurado>()
                .HasOne(a => a.Seguro)
                .WithMany(c => c.Asignaciones)
                .HasForeignKey(a => a.SeguroId);

            modelBuilder.Entity<Seguro>()
            .Property(s => s.Prima)
            .HasPrecision(18, 2);

            modelBuilder.Entity<Seguro>()
                .Property(s => s.SumaAsegurada)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}

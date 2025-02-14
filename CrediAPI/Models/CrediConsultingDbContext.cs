using CrediAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrediAPI.Models
{
    public class CrediConsultingDbContext : DbContext
    {
        public CrediConsultingDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EstadoCuentaTarjeta>().HasNoKey();
            modelBuilder.Entity<Transacciones>().HasNoKey();
        }

        public DbSet<Titular> Titulares { get; set; }
        public DbSet<TarjetaCredito> Tarjetas { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Movimientos> Compras { get; set; }
    }
}

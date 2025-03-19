using Microsoft.EntityFrameworkCore;

namespace InventarioPruebaBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; } // Agrega la entidad Producto
    }
}

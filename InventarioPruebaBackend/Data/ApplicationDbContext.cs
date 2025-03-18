using InventarioPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarioPrueba.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}

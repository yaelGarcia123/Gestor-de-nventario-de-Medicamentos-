using Apimedigroup.Models;
using Microsoft.EntityFrameworkCore;

namespace Apimedigroup.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Esta propiedad representa la tabla en la DB
        public DbSet<Medicamento> Medicamentos { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace leafletDemo.Models
{
    public class EstacionsContext : DbContext
    {

        public EstacionsContext(DbContextOptions<EstacionsContext> options)
            : base(options)
        {

        }
        public DbSet<leafletDemo.Models.Estacions> Estacio { get; set; }

    }
}
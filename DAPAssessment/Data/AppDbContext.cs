using DAPAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace DAPAssessment.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }

}

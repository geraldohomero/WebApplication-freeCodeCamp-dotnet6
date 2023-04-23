using Microsoft.EntityFrameworkCore;
using WebApplication1_dotnet6.Models;

namespace WebApplication1_dotnet6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}

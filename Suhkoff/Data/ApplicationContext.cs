using Microsoft.EntityFrameworkCore;
namespace Suhkoff.Data
{
    public class ApplicationContext:DbContext
    {
        public DbSet<users> Users { get; set; } 
        public DbSet<tasks> Tasks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
    }
}

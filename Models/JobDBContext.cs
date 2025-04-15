using Microsoft.EntityFrameworkCore;

namespace FastTracker.Models
{
    public class JobDBContext : DbContext
    {
        public DbSet<Job> userJob { get; set; }

        public JobDBContext(DbContextOptions options) : base(options)
        {
            
        }

    }
}

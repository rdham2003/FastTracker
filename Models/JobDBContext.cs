//this file is the main entry point for DB work. interacts with the models and the controllers
//when we get a input on the frontend, we use this to parse it and put it in the right table
using Microsoft.EntityFrameworkCore;

namespace FastTracker.Models
{
    public class JobDBContext : DbContext
    {
        //Database connection
        public JobDBContext(DbContextOptions<JobDBContext> options) : base(options) { }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  Mapping for Regular Transactions
            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("userJob");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Position).HasColumnName("position");
                entity.Property(e => e.PicId).HasColumnName("picId");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.DateUpdated).HasColumnName("dateupdated");
            });

        }
    }
}

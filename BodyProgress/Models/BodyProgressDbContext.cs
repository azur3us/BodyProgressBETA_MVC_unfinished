using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BodyProgress.Models
{
    public class BodyProgressDbContext : DbContext
    {
        public BodyProgressDbContext(DbContextOptions<BodyProgressDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().Property(e => e.Id).HasDefaultValueSql("NEWID()");
        }

        public DbSet<Exercise> Exercises { get; set; }
        //protected void OnConfiguration(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=LocalHost; Database=BodyProgressDataBase; Username=azureus;Password=bodyprogress");
    }
}

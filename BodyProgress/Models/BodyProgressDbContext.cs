using Microsoft.EntityFrameworkCore;

namespace BodyProgress.Models
{
    public class BodyProgressDbContext : DbContext
    {
        public BodyProgressDbContext(DbContextOptions<BodyProgressDbContext> options): base(options)
        {

        }
        public DbSet<Exercise> Exercises { get; set; }
        //protected void OnConfiguration(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=LocalHost; Database=BodyProgressDataBase; Username=azureus;Password=bodyprogress");
    }
}

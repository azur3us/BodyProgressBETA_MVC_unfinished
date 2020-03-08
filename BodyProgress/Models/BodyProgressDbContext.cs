using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BodyProgress.Models
{
    public class BodyProgressDbContext : IdentityDbContext<IdentityUser>
    {
        public BodyProgressDbContext(DbContextOptions<BodyProgressDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<BodyPartSize> BodyPartsSizes { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<UserBody> UserBodies { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<PlanItem> PlanItems { get; set; }
    }
}

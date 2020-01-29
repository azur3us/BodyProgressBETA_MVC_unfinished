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
            modelBuilder.Entity<Exercise>().Property(e => e.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PlanItemExercise>().HasKey(pe => new { pe.ExerciseId, pe.PlanItemId });
        }

        public DbSet<Exercise> Exercises { get; set; }  
        public DbSet<PartOfBody> PartOfBodies { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<PlanItem> PlanItems { get; set; }
        public DbSet<PlanItemExercise> PlanItemExercises { get; set; }
    }
}

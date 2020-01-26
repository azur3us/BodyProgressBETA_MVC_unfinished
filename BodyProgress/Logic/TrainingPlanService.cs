using BodyProgress.Models;

namespace BodyProgress.Logic
{
    public class TrainingPlanService : ITrainingPlanService
    {

        private readonly BodyProgressDbContext _context;

        public TrainingPlanService(BodyProgressDbContext context)
        {
            _context = context;
        }

        public void AddTrainingPlan(TrainingPlan traningPlan)
        {
            _context.TrainingPlans.Add(traningPlan);
            _context.SaveChanges();
        }
    }
}

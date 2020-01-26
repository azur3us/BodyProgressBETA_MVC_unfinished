using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BodyProgress.ViewModels
{
    public class CreateTrainingPlanViewModel
    {
        public Guid Id { get; set; }
        public DateTime CratedDate { get; set; }
        public string CreatorId { get; set; }
        public string UserName { get; set; }
    }
}

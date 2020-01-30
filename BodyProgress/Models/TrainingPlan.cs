using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Models
{
    public class TrainingPlan
    {
        public Guid Id { get; set; }
        public string TrainingPlanName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public List<PlanItem> PlanItems { get; set; }
    }
}

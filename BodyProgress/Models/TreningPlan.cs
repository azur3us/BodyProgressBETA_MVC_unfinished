using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Models
{
    public class TreningPlan
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public Guid CreatorId { get; set; }
        public UserManager<IdentityUser> Creator { get; set; }
    }
}

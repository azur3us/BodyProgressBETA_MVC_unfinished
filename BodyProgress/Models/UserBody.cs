using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BodyProgress.Models
{
    public class UserBody
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        
        public List<BodyPartSize> BodyPartSizes { get; set; }
    }
}
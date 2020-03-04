using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Models
{
    public class BodyPartsSize
    {     
        public int Id { get; set; }
        public decimal? CurrentSize { get; set; }
        public decimal? LastSize { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        
        public List<BodyPart> BodyParts { get; set; }
    }

}

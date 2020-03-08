using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Models
{
    public class BodyPartSize
    {     
        public int Id { get; set; }
        public decimal? CurrentSize { get; set; }
        public decimal? LastSize { get; set; }

        public int UserBodyId { get; set; }
        public UserBody UserBody { get; set; }

        public int BodyPartId { get; set; }    
        public BodyPart BodyPart { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.ViewModels
{
    public class ExerciseViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ExerciseId { get; set; }
        public string Name { get; set; }
    }
}

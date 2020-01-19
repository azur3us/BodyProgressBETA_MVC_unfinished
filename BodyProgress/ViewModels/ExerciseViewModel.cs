using BodyProgress.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public string Name { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<SelectListItem> PartOfBodies { get; set; }
        public Guid PartOfBodyId { get; set; }
    }
}

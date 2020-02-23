using BodyProgress.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Logic
{
    public interface IExerciseService
    {
        List<Exercise> ReturnAllExercises();
        Exercise TakeExerciseById(int Id);
        void CreateExercise(Exercise exercise);
        void DeleteExercise(Exercise exercise);
        void EditExercise(Exercise exercise);
        List<SelectListItem> ShowPartOfBodyToSelect();

    }
}

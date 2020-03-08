using BodyProgress.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Logic
{
    public interface IExerciseService : IBaseRepository<Exercise>
    {
        IQueryable<Exercise> ReturnAllExercises();
        Task<Exercise> TakeExerciseById(int id);
        Task CreateExercise(Exercise exercise);
        Task DeleteExercise(int id);
        Task EditExercise(Exercise exercise);
    }
}
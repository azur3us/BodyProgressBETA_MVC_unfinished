using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodyProgress.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BodyProgress.Logic
{
    public class ExerciseService : BaseRepository<Exercise>, IExerciseService
    {
        public ExerciseService(BodyProgressDbContext context)
            : base(context)
        {
        }

        public IQueryable<Exercise> ReturnAllExercises()
        {
            return GetAll();
        }

        public async Task<Exercise> TakeExerciseById(int id)
        {
            return await GetById(id);
        }

        public async Task CreateExercise(Exercise exercise)
        {
            await Create(exercise);
        }

        public async Task DeleteExercise(int id)
        {
            await Delete(id);
        }

        public async Task EditExercise(Exercise exercise)
        {
            await Update(exercise);
        }
    }
}
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
        // private readonly BodyProgressDbContext _context;

        public ExerciseService(BodyProgressDbContext context)
        :base(context)
        {
        }

        // public void CreateExercise(Exercise exercise)
        // {
        //     _context.Exercises.Add(exercise);
        //     _context.SaveChanges();
        // }
        //
        // public void DeleteExercise(Exercise exercise)
        // {
        //     _context.Exercises.Remove(exercise);
        //     _context.SaveChanges();
        // }
        //
        // public void EditExercise(Exercise exercise)
        // {
        //     _context.Attach(exercise);
        //     _context.Entry(exercise).Property("Name").IsModified = true;
        //     _context.SaveChanges();
        // }
        //
        // public Exercise TakeExerciseById(int Id)
        // {
        //     return _context.Exercises.FirstOrDefault(x => x.Id == Id);
        // }
        //
        // public List<Exercise> ReturnAllExercises()
        // {
        //     return _context.Exercises.ToList();
        // }

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

        public async Task EditExercise( Exercise exercise)
        {
            await Update(exercise);
        }
    }
}

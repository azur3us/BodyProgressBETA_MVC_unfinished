using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodyProgress.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BodyProgress.Logic
{
    public class ExerciseService : IExerciseService
    {
        private readonly BodyProgressDbContext _context;

        public ExerciseService(BodyProgressDbContext context)
        {
            _context = context;
        }

        public void CreateExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            _context.SaveChanges();
        }

        public void DeleteExercise(Exercise exercise)
        {
            _context.Exercises.Remove(exercise);
            _context.SaveChanges();
        }

        public Exercise TakeExerciseById(Guid Id)
        {
            return _context.Exercises.FirstOrDefault(x => x.Id == Id);
        }

        public List<Exercise> ReturnAllExercises()
        {
            return _context.Exercises.Include(x => x.PartOfBody).ToList();
        }

        public List<SelectListItem> ShowPartOfBodyToSelect()
        {
            return _context.PartOfBodies.Select(a => new SelectListItem() { Value = a.Id.ToString(), Text = a.Name }).ToList();
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodyProgress.Models;

namespace BodyProgress.Logic
{
    public class ExerciseService : IExerciseService
    {
        private readonly BodyProgressDbContext _context;

        public ExerciseService(BodyProgressDbContext context)
        {
            _context = context;
        }

        public List<Exercise> ReturnAllExercises()
        {
            return _context.Exercises.ToList();
        }
    }
}
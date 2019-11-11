using BodyProgress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Logic
{
    interface IExerciseService
    {
        List<Exercise> ReturnAllExercises();
    }
}

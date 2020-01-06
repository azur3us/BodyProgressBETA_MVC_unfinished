using BodyProgress.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Validators
{
    public class ExerciseValidator : AbstractValidator<Exercise>
    {
        public ExerciseValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Pole nie może być puste");
        }
    }
}

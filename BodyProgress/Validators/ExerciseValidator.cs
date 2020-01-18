
using BodyProgress.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodyProgress.Validators
{
    public class ExerciseValidator : AbstractValidator<ExerciseViewModel>
    {
        public ExerciseValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Pole nie może być puste");
        }
    }
}

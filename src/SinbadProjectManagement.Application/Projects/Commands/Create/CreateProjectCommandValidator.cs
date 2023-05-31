using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SinbadProjectManagement.Application.Projects.Commands.Create
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Project Amount must be greater than 0");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.DepartmentId).GreaterThan(0);
            RuleFor(x => x.FunderId).GreaterThan(0);
        }
    }
}
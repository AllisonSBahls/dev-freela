using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Maximum length is 255 characters");

            RuleFor(p => p.Title)
                .MaximumLength(100)
                .WithMessage("Maximum length is 100 characters");

        }
    }
}

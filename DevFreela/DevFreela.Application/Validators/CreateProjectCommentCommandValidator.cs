using DevFreela.Application.Commands.CreateComment;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateProjectCommentCommandValidator()
        {
            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("Content is required");

            RuleFor(p => p.IdProject)
                .NotEmpty()
                .NotNull()
                .WithMessage("Project is required");

            RuleFor(p => p.IdUser)
                .NotEmpty()
                .NotNull()
                .WithMessage("User is required");
        }
    }
}

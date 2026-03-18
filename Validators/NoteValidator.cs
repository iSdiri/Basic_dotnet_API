using Basic_dotnet_API.DTOs;
using FluentValidation;

namespace Basic_dotnet_API.Validators;

public class CreateNoteValidator : AbstractValidator<CreateNoteDto>
{
    public CreateNoteValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title can't exceed 100 characters.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId must be valid.");
    }
}

public class UpdateNoteValidator : AbstractValidator<UpdateNoteDto>
{
    public UpdateNoteValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title can't exceed 100 characters.");
    }
}

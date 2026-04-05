using Basic_dotnet_API.DTOs;
using FluentValidation;

namespace Basic_dotnet_API.Validators;

public class CreateFolderValidator : AbstractValidator<CreateFolderDto>
{
    public CreateFolderValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name can't exceed 50 characters.");

        RuleFor(x => x.AppUserId)
            .GreaterThan(0).WithMessage("AppUserId must be valid.");
    }
}

public class UpdateFolderValidator : AbstractValidator<UpdateFolderDto>
{
    public UpdateFolderValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name can't exceed 50 characters.");
    }
}

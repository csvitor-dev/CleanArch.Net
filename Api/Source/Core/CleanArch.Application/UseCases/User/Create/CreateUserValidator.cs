using FluentValidation;

namespace CleanArch.Application.UseCases.User.Create;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(user => user.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}
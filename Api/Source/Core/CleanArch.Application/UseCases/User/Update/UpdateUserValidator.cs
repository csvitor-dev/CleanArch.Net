using FluentValidation;

namespace CleanArch.Application.UseCases.User.Update;

public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(user => user.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(user => user.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}
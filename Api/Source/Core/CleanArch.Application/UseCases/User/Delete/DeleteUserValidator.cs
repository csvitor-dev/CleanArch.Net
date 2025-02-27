using FluentValidation;

namespace CleanArch.Application.UseCases.User.Delete;

public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(user => user.Id).NotEmpty();
    }
}
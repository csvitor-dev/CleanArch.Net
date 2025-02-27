using FluentValidation;

namespace CleanArch.Application.UseCases.User.GetAll;

public sealed class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
{
    public GetAllUserValidator() { }
}
using MediatR;

namespace CleanArch.Application.UseCases.User.Create;

public sealed record CreateUserRequest(string Email, string Name)
    : IRequest<CreateUserResponse>;
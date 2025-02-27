using MediatR;

namespace CleanArch.Application.UseCases.User.Update;

public sealed record UpdateUserRequest(Guid Id, string Email, string Name)
    : IRequest<UpdateUserResponse>;
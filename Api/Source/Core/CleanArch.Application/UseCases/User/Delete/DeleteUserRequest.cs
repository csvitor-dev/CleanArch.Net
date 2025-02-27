using MediatR;

namespace CleanArch.Application.UseCases.User.Delete;

public sealed record DeleteUserRequest(Guid Id) : IRequest<DeleteUserResponse>;
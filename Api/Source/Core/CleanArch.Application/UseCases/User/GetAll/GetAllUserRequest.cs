using MediatR;

namespace CleanArch.Application.UseCases.User.GetAll;

public sealed record GetAllUserRequest : IRequest<IEnumerable<GetAllUserResponse>>;
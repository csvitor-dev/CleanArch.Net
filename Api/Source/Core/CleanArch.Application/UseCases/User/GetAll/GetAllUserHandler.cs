using AutoMapper;
using CleanArch.Domain.Contracts.Data.Repositories;
using MediatR;

namespace CleanArch.Application.UseCases.User.GetAll;

public sealed class GetAllUserHandler
    (IMapper mapper, IUserRepository repository)
    : IRequestHandler<GetAllUserRequest, IEnumerable<GetAllUserResponse>>
{
    public async Task<IEnumerable<GetAllUserResponse>> 
        Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        var users = await repository.FindAllAsync(cancellationToken);

        return mapper.Map<List<GetAllUserResponse>>(users);
    }
}
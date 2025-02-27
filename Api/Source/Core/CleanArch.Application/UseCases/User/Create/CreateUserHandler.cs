using AutoMapper;
using CleanArch.Domain.Contracts.Data;
using CleanArch.Domain.Contracts.Data.Repositories;
using MediatR;

namespace CleanArch.Application.UseCases.User.Create;

public sealed class CreateUserHandler
    (IUnitOfWork unit, IUserRepository repository, IMapper mapper)
    : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    public async Task<CreateUserResponse> 
        Handle(CreateUserRequest request, CancellationToken token)
    {
        var user = mapper.Map<Domain.Entities.User>(request);
        
        await repository.CreateAsync(user);
        await unit.CommitAsync(token);

        return mapper.Map<CreateUserResponse>(user);
    }
}
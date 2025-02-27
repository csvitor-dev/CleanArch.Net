using AutoMapper;
using CleanArch.Domain.Contracts.Data;
using CleanArch.Domain.Contracts.Data.Repositories;
using MediatR;

namespace CleanArch.Application.UseCases.User.Update;

public class UpdateUserHandler
    (IUnitOfWork unit, IUserRepository repository, IMapper mapper)
    : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    public async Task<UpdateUserResponse> 
        Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await repository.FindByIdAsync(request.Id, cancellationToken)
            ?? throw new InvalidOperationException($"user not exists with id {request.Id}");

        var model = mapper.Map<Domain.Entities.User>(request);
        user.SetProperties(model);

        repository.Update(user);
        await unit.CommitAsync(cancellationToken);

        return mapper.Map<UpdateUserResponse>(user);
    }
}
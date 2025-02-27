using AutoMapper;
using CleanArch.Domain.Contracts.Data;
using CleanArch.Domain.Contracts.Data.Repositories;
using MediatR;

namespace CleanArch.Application.UseCases.User.Delete;

public sealed class DeleteUserHandler(IUnitOfWork unit, IUserRepository repository, IMapper mapper)
    : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    public async Task<DeleteUserResponse>
        Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await repository.FindByIdAsync(request.Id, cancellationToken) 
            ?? throw new InvalidOperationException($"user not exists with id {request.Id}");

        repository.Delete(user);
        await unit.CommitAsync(cancellationToken);

        return mapper.Map<DeleteUserResponse>(user);
    }
}
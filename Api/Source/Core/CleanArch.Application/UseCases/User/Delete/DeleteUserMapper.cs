using AutoMapper;

namespace CleanArch.Application.UseCases.User.Delete;

public sealed class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<DeleteUserRequest, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, DeleteUserResponse>();
    }
}
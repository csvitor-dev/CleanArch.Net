using AutoMapper;

namespace CleanArch.Application.UseCases.User.Update;

public sealed class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserRequest, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, UpdateUserResponse>();
    }
}
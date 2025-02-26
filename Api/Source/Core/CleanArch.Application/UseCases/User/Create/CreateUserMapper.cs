using AutoMapper;

namespace CleanArch.Application.UseCases.User.Create;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, CreateUserResponse>();
    }
}
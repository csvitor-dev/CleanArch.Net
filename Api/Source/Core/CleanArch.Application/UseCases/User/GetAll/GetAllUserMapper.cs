using AutoMapper;

namespace CleanArch.Application.UseCases.User.GetAll;

public sealed class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<Domain.Entities.User, GetAllUserResponse>();
    }
}
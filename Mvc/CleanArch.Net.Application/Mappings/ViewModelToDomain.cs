using AutoMapper;
using CleanArch.Net.Application.ViewModels;
using CleanArch.Net.Domain.Entities;

namespace CleanArch.Net.Application.Mappings;

public class ViewModelToDomain : Profile
{
    public ViewModelToDomain()
    {
        CreateMap<ProductViewModel, Product>();
    }
}
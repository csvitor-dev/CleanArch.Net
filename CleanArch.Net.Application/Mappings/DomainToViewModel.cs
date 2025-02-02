using AutoMapper;
using CleanArch.Net.Application.ViewModels;
using CleanArch.Net.Domain.Entities;

namespace CleanArch.Net.Application.Mappings;

public class DomainToViewModel : Profile
{
    public DomainToViewModel()
    {
        CreateMap<Product, ProductViewModel>();
    }
}
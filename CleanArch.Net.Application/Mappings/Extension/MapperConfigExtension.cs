using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Net.Application.Mappings.Extension;

public static class MapperConfigExtension
{
    public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services) 
        => services.AddAutoMapper(typeof(DomainToViewModel), typeof(ViewModelToDomain));
}
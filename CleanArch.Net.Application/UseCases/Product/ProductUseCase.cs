using AutoMapper;
using CleanArch.Net.Application.UseCases.Product.Contracts;
using CleanArch.Net.Application.ViewModels;
using CleanArch.Net.Domain.Contracts.Data;

namespace CleanArch.Net.Application.UseCases.Product;

public class ProductUseCase
    (IProductRepository repository, IMapper mapper) : IProductUseCase
{
    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        var result = await repository.GetAllAsync();
        
        return mapper.Map<IEnumerable<ProductViewModel>>(result);
    }

    public async Task<ProductViewModel> GetByIdAsync(int id)
    {
        var result = await repository.GetByIdAsync(id);
        
        return mapper.Map<ProductViewModel>(result);
    }

    public async Task AddAsync(ProductViewModel product)
    {
        var entity = mapper.Map<Domain.Entities.Product>(product);
        
        await repository.AddAsync(entity);
    }

    public async Task UpdateAsync(ProductViewModel product)
    {
        var entity = mapper.Map<Domain.Entities.Product>(product);
        
        await repository.UpdateAsync(entity);
    }

    public async Task RemoveAsync(int id)
        => await repository.RemoveAsync(id);
}
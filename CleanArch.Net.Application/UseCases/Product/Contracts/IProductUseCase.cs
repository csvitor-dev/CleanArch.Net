using CleanArch.Net.Application.ViewModels;

namespace CleanArch.Net.Application.UseCases.Product.Contracts;

public interface IProductUseCase
{
    public Task<IEnumerable<ProductViewModel>> GetAllAsync();
    public Task<ProductViewModel> GetByIdAsync(int id);
    public Task AddAsync(ProductViewModel product);
    public Task UpdateAsync(ProductViewModel product);
    public Task RemoveAsync(int id);
}
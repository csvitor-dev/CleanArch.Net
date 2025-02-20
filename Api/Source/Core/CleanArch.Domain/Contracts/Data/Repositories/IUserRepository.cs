using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Contracts.Data.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmailAsync(string email, CancellationToken token);
}
using CleanArch.DAO.Contexts;
using CleanArch.Domain.Contracts.Data.Repositories;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.DAO.Repositories;

public class UserRepository(AppDbContext context)
    : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email, CancellationToken token)
        => await Context.Users.FirstOrDefaultAsync(entity => entity.Email == email, token);
}
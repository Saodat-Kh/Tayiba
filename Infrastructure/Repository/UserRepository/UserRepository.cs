using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository.UserRepository;

public class UserRepository(ApplicationDataContext context) : IUserRepository 
{
    public async Task<AppUser> GetUserById(int userId)
    {
        return await context.Users.FindAsync(userId);
    }
}
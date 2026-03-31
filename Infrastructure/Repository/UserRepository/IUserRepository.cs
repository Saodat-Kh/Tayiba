using Domain.Entities;

namespace Infrastructure.Repository.UserRepository;

public interface IUserRepository
{
    Task<AppUser> GetUserById(int userId);
}
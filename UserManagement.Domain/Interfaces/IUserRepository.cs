
using UserManagement.Domain.DTOs;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(User user);
        Task<IEnumerable<UserResponseDto>> GetUsersAsync();
    }
}

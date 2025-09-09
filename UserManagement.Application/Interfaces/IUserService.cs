using UserManagement.Application.DTOs;
using UserManagement.Domain.DTOs;

namespace UserManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUser(UserRequestDto user);
        Task<IEnumerable<UserResponseDto>> GetAllUsers();
    }
}
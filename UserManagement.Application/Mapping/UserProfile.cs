using AutoMapper;
using UserManagement.Application.DTOs;
using UserManagement.Domain.DTOs;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Mapea UserRequestDto → User
            CreateMap<UserRequestDto, User>();

            // Mapea User → UserResponseDto
            CreateMap<User, UserResponseDto>();
        }
    }
}

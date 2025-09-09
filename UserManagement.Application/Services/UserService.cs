using AutoMapper;
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.DTOs;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<int> AddUser(UserRequestDto userDto)
    {
        if (userDto == null) throw new ArgumentNullException(nameof(userDto));

        var user = _mapper.Map<User>(userDto);  

        var userId = await _repository.AddUserAsync(user);
        return userId;
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllUsers()
    {
        var users = await _repository.GetUsersAsync();
        return _mapper.Map<IEnumerable<UserResponseDto>>(users);  
    }
}

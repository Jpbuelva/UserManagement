using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.DTOs;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="user">DTO con los datos del usuario</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequestDto user)
        {
            if (user == null)
                return BadRequest(new { message = "El usuario no puede ser nulo." });

            try
            {
                var userId = await _service.AddUser(user);
                return Ok(new { message = "Usuario creado correctamente", userId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error interno al crear el usuario." });
            }
        }



        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> Get()
        {
            try
            {
                var users = await _service.GetAllUsers();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Ocurrió un error al obtener los usuarios." });
            }
        }
    }
}

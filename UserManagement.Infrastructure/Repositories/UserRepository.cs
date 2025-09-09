using Dapper;
using Npgsql;
using UserManagement.Domain.DTOs;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> AddUserAsync(User user)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            var sql = "SELECT sp_insert_user(@Name, @Phone, @Address, @CountryId, @StateId, @CityId)";

            try
            {
                var userId = await conn.ExecuteScalarAsync<int>(sql, user);
                return userId;
            }
            catch (PostgresException ex) when (ex.SqlState == "P0001")
            {
                throw new ArgumentException(ex.MessageText);  
            }
        }


        public async Task<IEnumerable<UserResponseDto>> GetUsersAsync()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            var sql = "SELECT * FROM sp_get_users()";
            var users = await conn.QueryAsync<UserResponseDto>(sql);
            return users;
        }
    }
}

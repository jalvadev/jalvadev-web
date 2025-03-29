using Dapper;
using jalvadev_back.Models;
using jalvadev_back.Repositories.Database;
using jalvadev_back.Repositories.Interfaces;
using jalvadev_back.Resources;
using jalvadev_back.Utils;
using Npgsql;

namespace jalvadev_back.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NpgsqlConnection _connection;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(IConnectionProvider connectionProvider, ILogger<UserRepository> logger)
        {
            _connection = connectionProvider.GetConnection();
            _logger = logger;
        }

        public Result<User> GetUserById(int id)
        {
            try
            {
                string query = @"SELECT
                                    id,
                                    name,
                                    surname,
                                    about,
                                    email,
                                    password,
                                    user_role
                                FROM users
                                WHERE id = @Id;";

                var user = _connection.QueryFirstOrDefault<User>(query, new { Id = id });

                return user == null ?
                    Result<User>.Failure(Resource.ui_error_user_not_found) :
                    Result<User>.Success(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Resource.api_error_bd_connection} - {ex.Message}");
                return Result<User>.Failure(Resource.ui_error_getting_user);
            }
        }
    }
}

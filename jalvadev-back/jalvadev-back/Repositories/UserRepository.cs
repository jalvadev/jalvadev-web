using Dapper;
using jalvadev_back.Models;
using jalvadev_back.Repositories.Database;
using jalvadev_back.Repositories.Interfaces;
using jalvadev_back.Utils;
using Npgsql;

namespace jalvadev_back.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NpgsqlConnection _connection;
        public UserRepository(IConnectionProvider connectionProvider)
        {
            _connection = connectionProvider.GetConnection();
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
                    Result<User>.Failure("User not found.") :
                    Result<User>.Success(user);
            }
            catch (Exception ex)
            {
                return Result<User>.Failure("Error al conectar con la base de datos.");
            }
        }
    }
}

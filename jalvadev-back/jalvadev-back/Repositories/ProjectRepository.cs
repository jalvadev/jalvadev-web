using Dapper;
using jalvadev_back.Models;
using jalvadev_back.Repositories.Database;
using jalvadev_back.Repositories.Interfaces;
using jalvadev_back.Resources;
using jalvadev_back.Utils;
using Npgsql;

namespace jalvadev_back.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly NpgsqlConnection _connection;
        private readonly ILogger<ProjectRepository> _logger;
        public ProjectRepository(IConnectionProvider connectionProvider, ILogger<ProjectRepository> logger)
        {
            _connection = connectionProvider.GetConnection();
            _logger = logger;
        }


        public Result<Project> GetProjectById(int id)
        {
            try
            {
                string query = "SELECT id, user_id as UserId, name, image, link, creation_date as CreationDate, update_date as UpdateDate FROM projects;";

                Project project = _connection.QueryFirstOrDefault<Project>(query);

                return project == null ?
                    Result<Project>.Failure(Resource.ui_error_project_not_found) :
                    Result<Project>.Success(project);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Resource.api_error_bd_connection} - {ex.Message}");
                return Result<Project>.Failure(Resource.ui_error_getting_project);
            }
        }
    }
}

using Dapper;
using jalvadev_back.Models;
using jalvadev_back.Repositories.Database;
using jalvadev_back.Repositories.Interfaces;
using jalvadev_back.Resources;
using jalvadev_back.Utils;
using Npgsql;

namespace jalvadev_back.Repositories
{
    public class TagRepository : ITagRepository
    {

        private readonly NpgsqlConnection _connection;
        private readonly ILogger<TagRepository> _logger;
        public TagRepository(IConnectionProvider connectionProvider, ILogger<TagRepository> logger)
        {
            _connection = connectionProvider.GetConnection();
            _logger = logger;
        }


        public Result<List<Tag>> GetAllTags()
        {
            try
            {
                string query = "SELECT id, name, creation_date, update_date FROM tags;";

                List<Tag> tags = _connection.Query<Tag>(query).ToList();

                return Result<List<Tag>>.Success(tags);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Resource.api_error_bd_connection} - {ex.Message}");
                return Result<List<Tag>>.Failure(Resource.ui_error_getting_tags);
            }
        }

        public Result<Tag> GetTagById(int id)
        {
            try
            {
                string query = "SELECT id, name, creation_date, update_date FROM tags WHERE id = @Id;";

                Tag tag = _connection.QueryFirstOrDefault<Tag>(query, new { @Id = id });

                return tag == null ?
                    Result<Tag>.Failure(Resource.ui_error_tag_not_found) :
                    Result<Tag>.Success(tag);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Resource.api_error_bd_connection} - {ex.Message}");
                return Result<Tag>.Failure(Resource.ui_error_getting_tags);
            }
        }
    }
}

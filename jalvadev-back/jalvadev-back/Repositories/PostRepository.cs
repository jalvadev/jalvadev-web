using Dapper;
using jalvadev_back.Models;
using jalvadev_back.Repositories.Database;
using jalvadev_back.Repositories.Interfaces;
using jalvadev_back.Resources;
using jalvadev_back.Utils;
using Npgsql;

namespace jalvadev_back.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly NpgsqlConnection _connection;
        private readonly ILogger<PostRepository> _logger;
        public PostRepository(IConnectionProvider connectionProvider, ILogger<PostRepository> logger)
        {
            _connection = connectionProvider.GetConnection();
            _logger = logger;
        }

        public Result<Post> GetPostById(int postId)
        {
            try
            {
                string query = "SELECT id, user_id, title, content, is_draft, creation_date, update_date FROM public.posts WHERE id = @Id;";

                var post = _connection.QueryFirstOrDefault<Post>(query, new { Id = postId });

                return post == null ?
                    Result<Post>.Failure(Resource.ui_error_post_not_found) :
                    Result<Post>.Success(post);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Resource.api_error_bd_connection} - {ex.Message}");
                return Result<Post>.Failure(Resource.ui_error_getting_post);
            }
        }
    }
}

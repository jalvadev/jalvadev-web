﻿using Dapper;
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
                string query = "SELECT id, user_id as UserId, title, content, creation_date as CreationDate FROM posts WHERE id = @Id and is_draft = 'false';";

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

        public Result<List<Post>> GetPostByUser(int userId, int limit, int offset, List<int> categoryIds)
        {
            try
            {
                string query = @"SELECT
                                    P.id, title, creation_date as CreationDate 
                                FROM posts P ";

                if(categoryIds == null)
                {
                    query += @"WHERE 
                            user_id = @UserId 
                            AND is_draft = 'false'
                         LIMIT @Limit OFFSET @Offset;";
                }
                else
                {
                    query += @"INNER JOIN post_tags PT 
                                    ON P.id = PT.post_id
                               WHERE PT.tag_id IN (";

                    foreach (int categoryId in categoryIds)
                        query += $"{categoryId},";

                    query = query.Substring(0, query.Length - 1);

                    query += @") 
                               AND user_id = @UserId 
                               AND is_draft = 'false'
                         LIMIT @Limit OFFSET @Offset;";
                }

                

                var posts = _connection.Query<Post>(query, new { UserId = userId, Limit = limit, Offset = offset }).ToList();

                return posts == null || posts.Count() == 0 ?
                    Result<List<Post>>.Failure(Resource.ui_error_post_list_empty) :
                    Result<List<Post>>.Success(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ Resource.api_error_bd_connection} - {ex.Message}");
                return Result<List<Post>>.Failure(Resource.ui_error_getting_post_list);
            }
        }

        public Result<int> GetNumberOfPages(int user, int limit)
        {
            try
            {
                string query = "SELECT COUNT(id) FROM posts WHERE user_id = @UserId";

                var count = _connection.Query<int>(query, new { UserId = user }).First();

                int totalPages = count == 0 ? 0 : (count / limit);

                return Result<int>.Success(totalPages);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Resource.api_error_bd_connection} - {ex.Message}");
                return Result<int>.Failure(Resource.ui_error_getting_post_list);
            }
        }
    }
}

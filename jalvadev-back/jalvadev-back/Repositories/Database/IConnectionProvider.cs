using Npgsql;

namespace jalvadev_back.Repositories.Database
{
    public interface IConnectionProvider
    {
        NpgsqlConnection GetConnection();
    }
}

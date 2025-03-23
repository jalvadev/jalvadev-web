using Npgsql;

namespace jalvadev_back.Repositories.Database
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly IConfiguration _configuration;
        public ConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public NpgsqlConnection GetConnection()
        {
            string connectionString = GetConnectionString();

            return new NpgsqlConnection(connectionString);
        }

        private string GetConnectionString()
        {
            string filePath = _configuration["PasswordsFile"];
            if (!File.Exists(filePath))
                throw new Exception("");

            string password = File.ReadAllText(filePath);

            string connectionString = _configuration.GetConnectionString("jalvadev");
            connectionString = connectionString.Replace("#PASWWORD#", password);

            return connectionString;
        }
    }
}

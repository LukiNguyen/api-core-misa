using System.Data;
using MySqlConnector;

namespace Employee.Database
{
    public class DapperContext : DapperContextBase
    {
        public IConfiguration IConfiguration { get; }

        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration) {
            IConfiguration = configuration;
            _connectionString = configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection() {
            return new MySqlConnection(_connectionString);
        }
    }
}
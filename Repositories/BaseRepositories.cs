using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace Full_Stack_Mercury_Maps.Repositories
{
    public class BaseRepositories
    {
        private readonly string _connectionString;

        public BaseRepositories(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        protected SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}

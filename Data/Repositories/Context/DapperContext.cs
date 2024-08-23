using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Sampas_Mobil_Etkinlik.Data.Repositories.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection() => new OracleConnection(_connectionString);
    }
}

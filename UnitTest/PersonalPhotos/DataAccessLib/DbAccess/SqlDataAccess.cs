using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLib.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _cofig;
        public SqlDataAccess(IConfiguration config)
        {
            _cofig = config;
        }
        public async Task<IEnumerable<T>> LoadData<T, U>
            (
                string storedProcedure,
                U paramaters,
                string connectionId = "Default"
            )
        {
            using IDbConnection connection = new SqlConnection(_cofig.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(storedProcedure, paramaters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(
            string storedProcedures,
            T paramaters,
            string connectionId = "Default")
        {
            IDbConnection connection = new SqlConnection(_cofig.GetConnectionString(connectionId));
            await connection.ExecuteAsync(storedProcedures, paramaters,
                commandType: CommandType.StoredProcedure);
        }
    }
}

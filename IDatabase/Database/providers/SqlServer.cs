using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IDatabase.Database.providers
{
    public class SqlServer : DatabaseConnection
    {
        public SqlServer(string connectionString) =>
            base.DbConnection = new SqlConnection()
            {
                ConnectionString = connectionString
            };
    }
}

using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IDatabase.Database.providers
{
    public class MySqlServer : DatabaseConnection
    {
        public MySqlServer(string connectionString) =>
            base.DbConnection = new MySqlConnection()
            {
                ConnectionString = connectionString
            };
    }
}


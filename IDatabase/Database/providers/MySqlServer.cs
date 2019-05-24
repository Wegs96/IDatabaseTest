using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IDatabase.Database.providers
{
    public class MySqlServer : DatabaseConnection
    {
        /// <summary>
        /// initialize New MySqlServer Database Connection
        /// </summary>
        /// <param name="connectionString"></param>
        public MySqlServer(string connectionString) =>
            base.DbConnection = new MySqlConnection()
            {
                ConnectionString = connectionString
            };
    }
}


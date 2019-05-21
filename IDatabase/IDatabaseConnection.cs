using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace IDatabase
{
    public interface IDatabaseConnection
    {
        SqlConnection SqlConnection { get; set; }
        MySqlConnection MySqlConnection { get; set; }

        /// <summary>
        /// Get Connection String
        /// </summary>
        string _connectionString { get; }

        /// <summary>
        /// Get Database Provider
        /// </summary>
        Provider _provider { get; }

        /// <summary>
        /// Check Database Connection Status
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Connect to the database
        /// </summary>
        DatabaseConnectionResult Connect();

        /// <summary>
        /// Close the current Database connection
        /// </summary>
        void Disconnect();
    }
}
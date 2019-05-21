using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace IDatabase
{
    /// <summary>
    /// Database Provider 
    /// </summary>
    public enum Provider
    {
        /// <summary>
        /// Use MySql As Database Provider
        /// </summary>
        MySql,

        /// <summary>
        /// Use SqlServer As Database Provider
        /// </summary>
        SqlServer
    }

    /// <summary>
    /// The result of database connection establishment attempt.
    /// </summary>
    public enum DatabaseConnectionResult
    {
        /// <summary>
        /// The connection string is invalid.
        /// </summary>
        InvalidConnectionString,

        /// <summary>
        /// Could not authenticate. Invalid credentials or the connection is not trusted (MSSQL).
        /// </summary>
        AuthenticationFailure,

        /// <summary>
        /// Invalid username/password (MySql).
        /// </summary>
        InvalidLoginData,

        /// <summary>
        /// Failed due to connection timeout.
        /// </summary>
        ConnectionTimeout,

        /// <summary>
        /// An error has occurred while establishing a connection to the server
        /// Cannot connect to server
        /// </summary>
        ConnectionError,

        /// <summary>
        /// Unknown Sql Error...
        /// </summary>
        UnknownError,

        /// <summary>
        /// Connection successfully established.
        /// </summary>
        Success,

    }

    public interface IDatabaseConnection
    {
        SqlConnection _SqlConnection { get; set; }
        MySqlConnection _MySqlConnection { get; set; }

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
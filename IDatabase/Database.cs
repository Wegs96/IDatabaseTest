using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;

namespace IDatabase
{

    public class DatabaseConnection : IDatabaseConnection
    {
        public SqlConnection SqlConnection { get; set; }
        public MySqlConnection MySqlConnection { get; set; }

        /// <summary>
        /// Get Connection String
        /// </summary>
        public string _connectionString { get; }

        /// <summary>
        /// Get Database Provider
        /// </summary>
        public Provider _provider { get; }

        /// <summary>
        /// Check Database Connection Status
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// initialize a new connection
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="provider"></param>
        public DatabaseConnection(string connectionString, Provider provider)
        {
            this._connectionString = connectionString;
            this._provider = provider;
        }

        /// <summary>
        /// Connect to the database
        /// </summary>
        public DatabaseConnectionResult Connect()
        {
            switch (this._provider)
            {
                case Provider.SqlServer:
                    try
                    {
                        using (SqlConnection = new SqlConnection(this._connectionString))
                        {
                            SqlConnection.Open();

                            IsConnected = true;
                            return DatabaseConnectionResult.Success;

                        }
                    }
                    catch (SqlException e)
                    {
                        switch (e.ErrorCode)
                        {
                            case -2:
                                return DatabaseConnectionResult.ConnectionTimeout;
                            case -1:
                            case 2:
                            case 53:
                                return DatabaseConnectionResult.ConnectionError;
                            default:
                                return DatabaseConnectionResult.UnknownError;
                        }
                    }
                    catch (ArgumentException e)
                    {
                        return DatabaseConnectionResult.InvalidConnectionString;

                    }

                case Provider.MySql:

                    try
                    {
                        using (MySqlConnection = new MySqlConnection(this._connectionString))
                        {
                            MySqlConnection.Open();

                            IsConnected = true;
                            return DatabaseConnectionResult.Success;
                        }
                    }
                    catch (MySqlException e)
                    {
                        switch (e.ErrorCode)
                        {
                            case 0:
                                return DatabaseConnectionResult.ConnectionError;
                            case 1045:
                                return DatabaseConnectionResult.InvalidLoginData;

                        }
                        throw;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

            }

            return DatabaseConnectionResult.Success;
        }


        /// <summary>
        /// Close the current Database connection
        /// </summary>
        public void Disconnect()
        {
            if (IsConnected)
            {
                if(this._provider == Provider.SqlServer)
                     SqlConnection.Close();

                else if (this._provider == Provider.MySql)
                    MySqlConnection.Close();

            }
        }
    }
}

using System;
using System.Data.Common;
using System.Threading.Tasks;


namespace IDatabase.Database
{

    public abstract class DatabaseConnection
    {
        protected DbConnection DbConnection;
        /// <summary>
        /// Check the database connection status
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// Open a new database connection
        /// </summary>
        /// <returns></returns>
        public virtual async Task<bool> Open()
        {
            try
            {
                if (IsConnected) return false;

                await DbConnection.OpenAsync();
                IsConnected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Execute Query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual async Task<bool> Execute(string query)
        {
            using (var command = DbConnection.CreateCommand())
            {
                command.CommandText = query;
                try
                {
                    await command.ExecuteNonQueryAsync();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Change the current database
        /// </summary>
        /// <param name="databaseName"></param>
        public virtual void ChangeDatabase(string databaseName)
        {
            DbConnection.ChangeDatabase(databaseName);
        }

        /// <summary>
        /// Close the database connection
        /// </summary>
        public virtual void Close()
        {
            if(!IsConnected)
                return;

            try
            {
                DbConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }


}

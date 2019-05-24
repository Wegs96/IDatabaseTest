using System;
using System.Data.Common;
using System.Threading.Tasks;


namespace IDatabase.Database
{

    public abstract class DatabaseConnection
    {
        protected DbConnection DbConnection;
        public bool IsConnected { get; private set; }

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


        public virtual void ChangeDatabase(string databaseName)
        {
            DbConnection.ChangeDatabase(databaseName);
        }

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

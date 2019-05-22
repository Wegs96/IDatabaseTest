using System;
using System.Data.SqlClient;

namespace IDatabase.Database.providers
{
    public class SqlServerProvider : DatabaseConnection 
    {
        private SqlConnection SqlConnection { get; set; }

        public SqlServerProvider(string connectionString)
        {
            base.ConnectionString = connectionString;
            base.IsConnected = false;
        }

        public override void Connect()
        {
            if(base.IsConnected)
                return;

            try
            {
                using (SqlConnection = new SqlConnection(base.ConnectionString))
                {
                    SqlConnection.Open();
                    base.IsConnected = true;

                    base.OnConnect();
                }
            }
            catch (SqlException e)
            {
               base.OnConnect();
#if DEBUG
                Console.WriteLine(e);
                throw;
#endif
            }
            catch (Exception e)
            {
                base.OnConnect();
#if DEBUG
                Console.WriteLine(e);
                throw;
#endif

            }
        }

        public override void Disconnect()
        {
            if(!base.IsConnected)
                return;

            try
            {
                SqlConnection.Close();
                base.IsConnected = false;
                base.OnDisconnect();
            }
            catch (Exception e)
            {
                base.OnDisconnect();

#if DEBUG
                Console.WriteLine(e);
                throw;
#endif
            }
        }
    }
}

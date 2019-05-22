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
               Console.WriteLine(e);

            }
            catch (Exception e)
            {
                base.OnConnect();
                Console.WriteLine(e);

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
                Console.WriteLine(e);
            }
        }
    }
}

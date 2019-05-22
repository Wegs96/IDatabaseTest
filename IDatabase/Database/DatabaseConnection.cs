using System;

namespace IDatabase.Database
{
    
    public abstract class DatabaseConnection
    {
        public string ConnectionString { get; protected set; }
        public bool IsConnected { get; protected set; }


        public abstract void Connect();
        public abstract void Disconnect();

        protected void OnConnect()
        {
            Console.WriteLine(this.IsConnected ? "Database Connected Successfully !" : "Database Connection Failed !");
        }

        protected void OnDisconnect()
        {
            Console.WriteLine(this.IsConnected ? "Cannot disconnect from the database !" : "Database Disconnected Successfully !");
        }

  }
}

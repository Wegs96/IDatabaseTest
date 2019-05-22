using System;
using IDatabase.Database;
using IDatabase.Database.providers;

namespace IDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to database...");

            DatabaseConnection database = new SqlServerProvider("test");
            database.Connect();


            Console.Read();
        }


    }
}

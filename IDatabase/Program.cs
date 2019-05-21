using System;

namespace IDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to database...");

            DatabaseConnection database = new DatabaseConnection("test",Provider.SqlServer);
            database.Connect();


            Console.Read();
        }


    }
}

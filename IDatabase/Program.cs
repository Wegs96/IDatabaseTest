using System;
using System.Threading.Tasks;
using IDatabase.Database;
using IDatabase.Database.providers;

namespace IDatabase
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Connecting to database...");

            //DatabaseConnection database = new SqlServerProvider("test");
            //database.Connect();

            DatabaseConnection database = new SqlServer("test");
            await database.Open();

            database.ChangeDatabase("SRO_VT_ACCOUNT");
            await database.Execute("update TB_User set sec_primary = 5");
            Console.Read();
        }


    }
}

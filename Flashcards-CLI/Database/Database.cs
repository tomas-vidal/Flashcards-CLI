using System.Configuration;
using System.Data.SqlClient;

namespace Flashcards_CLI
{
    internal class Database
    {
        private static string dbName = ConfigurationManager.AppSettings.Get("dbName");
        internal static void CreateDatabase()
        {
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Integrated Security=true"))
            {
                db.Open();
                string queryCheckExistence = $"SELECT COUNT(*) FROM sys.databases WHERE name = 'DatabaseFlashcards'";
                SqlCommand command = new SqlCommand(queryCheckExistence, db);
                int count = Convert.ToInt32(command.ExecuteScalar());

                try
                {
                    if (count == 0)
                    {
                        string CreateDBcommand = "CREATE DATABASE DatabaseFlashcards";
                        SqlCommand CreateDBommandQuery = new SqlCommand(CreateDBcommand, db);
                        CreateDBommandQuery.ExecuteNonQuery();
                        Console.WriteLine("DB Created");
                    }
                    else
                    {
                        Console.WriteLine("DB is alredy created");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public static void InitializeTables()
        {
            using (SqlConnection db =
               new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {
                db.Open();
                try
                {
                    string queryCheckExistence = $"SELECT COUNT(*) FROM sys.tables WHERE name = 'Stacks'";

                    SqlCommand queryCheckExistenceQuery = new SqlCommand(queryCheckExistence, db);
                    int count = Convert.ToInt32(queryCheckExistenceQuery.ExecuteScalar());

                    if (count == 0)
                    {
                        string tableCommand = "CREATE TABLE Stacks (Id INTEGER IDENTITY(1,1) Primary Key, Name NVARCHAR(50))";
                        SqlCommand createTable = new SqlCommand(tableCommand, db);
                        createTable.ExecuteNonQuery();
                        Console.WriteLine("Table created");
                    }
                    else
                    {
                        Console.WriteLine("Table already exists");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                try
                {
                    string queryCheckExistence = $"SELECT COUNT(*) FROM sys.tables WHERE name = 'Flashcards'";

                    SqlCommand queryCheckExistenceQuery = new SqlCommand(queryCheckExistence, db);
                    int count = Convert.ToInt32(queryCheckExistenceQuery.ExecuteScalar());

                    if (count == 0)
                    {
                        string tableCommand = "CREATE TABLE Flashcards (Id INTEGER IDENTITY(1,1) Primary Key, Front TEXT, Back TEXT, Stack_Id INTEGER, FOREIGN KEY (Stack_Id) REFERENCES Stacks(Id))";
                        SqlCommand createTable = new SqlCommand(tableCommand, db);
                        createTable.ExecuteNonQuery();
                        Console.WriteLine("Table created");
                    }
                    else
                    {
                        Console.WriteLine("Table already exists");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                try
                {
                    string queryCheckExistence = $"SELECT COUNT(*) FROM sys.tables WHERE name = 'StudySessions'";

                    SqlCommand queryCheckExistenceQuery = new SqlCommand(queryCheckExistence, db);
                    int count = Convert.ToInt32(queryCheckExistenceQuery.ExecuteScalar());

                    if (count == 0)
                    {
                        string tableCommand = "CREATE TABLE StudySessions (Id INTEGER Primary Key, Score INTEGER, Date TEXT, Stack_Id INTEGER, FOREIGN KEY (Stack_Id) REFERENCES Stacks(Id))";
                        SqlCommand createTable = new SqlCommand(tableCommand, db);
                        createTable.ExecuteNonQuery();
                        Console.WriteLine("Table created");
                    }
                    else
                    {
                        Console.WriteLine("Table already exists");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }


        }
    }
}

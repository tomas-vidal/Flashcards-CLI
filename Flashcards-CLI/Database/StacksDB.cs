using System.Data.SqlClient;
using System.Configuration;
using Spectre.Console;


namespace Flashcards_CLI
{
    internal class StacksDB
    {
        private static string dbName = ConfigurationManager.AppSettings.Get("dbName");
        internal static void CreateStack(string name)
        {
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {

                try 
                {
                    db.Open();
                    var command = new SqlCommand("INSERT INTO Stacks (Name) VALUES (@Name)", db);
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                    AnsiConsole.Markup("[green]Stack created successfully[/]");
                } 
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
        }
    }
}

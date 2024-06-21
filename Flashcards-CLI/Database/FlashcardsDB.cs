using System.Data.SqlClient;
using Spectre.Console;
using System.Configuration;
using Flashcards_CLI.Helpers;

namespace Flashcards_CLI 
{
    internal class FlashcardsDB 
    {
        private static string dbName = ConfigurationManager.AppSettings.Get("dbName");
        internal static void CreateFlashcard(string front, string back, string stackName) 
        {
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {
                try 
                {
                    db.Open();
                    var command = new SqlCommand("INSERT INTO Flashcards (Front, Back, Stack_Id) VALUES (@Front, @Back, @StackId)", db);
                    command.Parameters.AddWithValue("@Front", front);
                    command.Parameters.AddWithValue("@Back", back);
                    command.Parameters.AddWithValue("@StackId", StacksHelpers.GetStackByName(stackName).Id);
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
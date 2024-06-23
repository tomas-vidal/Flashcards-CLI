using System.Configuration;
using System.Data.SqlClient;
using Spectre.Console;

namespace Flashcards_CLI
{
    internal class StudySessionsDB
    {
        private static string dbName = ConfigurationManager.AppSettings.Get("dbName");

        internal static void CreateSession(double score, int stack_Id)
        {
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {
                try 
                {
                    db.Open();
                    var command = new SqlCommand("INSERT INTO StudySessions (Score, Date, Stack_Id) VALUES (@Score, @Date, @StackId)", db);
                    command.Parameters.AddWithValue("@Score", score);
                    command.Parameters.AddWithValue("@Date", DateTime.Now);
                    command.Parameters.AddWithValue("@StackId", stack_Id);
                    command.ExecuteNonQuery();
                    AnsiConsole.MarkupLine("\n[green]Study session created successfully[/]");
                } 
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
        }
    }

}
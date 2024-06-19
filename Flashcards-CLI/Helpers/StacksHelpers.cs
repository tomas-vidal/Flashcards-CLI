using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Flashcards_CLI.Helpers
{
    internal class StacksHelpers
    {
        private static string dbName = ConfigurationManager.AppSettings.Get("dbName");
        internal static int CheckIfStackExists(string name)
        {
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {
                db.Open();
                try
                {
                    string command = $"SELECT COUNT(*) FROM Stacks WHERE Name = '{name}'";
                    SqlCommand query = new SqlCommand(command, db);
                    int count = Convert.ToInt32(query.ExecuteScalar());
                    return count;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return 0;
            }
        }
    }
}

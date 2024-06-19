using System.Configuration;
using System.Data.SqlClient;

namespace Flashcards_CLI.Helpers
{
    internal class StacksHelpers
    {
        private static string dbName = ConfigurationManager.AppSettings.Get("dbName");
        internal static bool CheckIfStackExists(string name)
        {
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {
                db.Open();
                try
                {
                    string command = $"SELECT COUNT(*) FROM Stacks WHERE name = '{name}'";
                    SqlCommand query = new SqlCommand(command, db);
                    bool count = Convert.ToBoolean(query.ExecuteScalar());
                    return count;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return false;
            }
        }
    }
}

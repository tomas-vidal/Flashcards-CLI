using System.Data.SqlClient;
using System.Configuration;


namespace Flashcards_CLI
{
    internal class StacksDB
    {
        private static string dbName = ConfigurationManager.AppSettings.Get("dbName");
        internal static void CreateStack(string name)
        {
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {
                string command = "CREATE";
            }
        }
    }
}

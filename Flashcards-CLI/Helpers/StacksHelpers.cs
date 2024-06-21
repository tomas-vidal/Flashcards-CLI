using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using Flashcards_CLI;

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
        internal static List<StackModel> GetStacks()
        {
            List<StackModel> AllStacks = [];
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {
                try
                {
                    db.Open();
                    string command = $"SELECT * FROM Stacks";
                    SqlCommand cmd = new SqlCommand(command, db);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0); 
                        string name = reader.GetString(1);    

                        AllStacks.Add(new StackModel{Id = id, Name = name });
                    }
                    return AllStacks;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return AllStacks;
            }
        }
        internal static StackModel GetStackByName(string stackName)
        {
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {
                try
                {
                    db.Open();
                    string command = $"SELECT * FROM Stacks WHERE Name = '{stackName}'";
                    SqlCommand cmd = new SqlCommand(command, db);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0); 
                        string name = reader.GetString(1);    

                        return new StackModel{Id = id, Name = name };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return new StackModel{Id = 0, Name = "INVALID"};
            }
        }
    }
}

using System.Configuration;
using System.Data.SqlClient;

namespace Flashcards_CLI.Helpers
{
    internal class FlashcardHelpers
    {
        private static string dbName = ConfigurationManager.AppSettings.Get("dbName");
        internal static List<FlashcardModel> GetCards(string stackName)
        {
            List<FlashcardModel> AllCards = [];
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {
                try
                {
                    db.Open();
                    int stackId = StacksHelpers.GetStackByName(stackName).Id;
                    string command = $"SELECT * FROM Flashcards WHERE Stack_Id = {stackId}";
                    SqlCommand cmd = new SqlCommand(command, db);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string front = reader.GetString(1);
                        string back = reader.GetString(2);

                        AllCards.Add(new FlashcardModel { Id = id, Front = front, Back = back, Stack_Id = stackId});
                    }
                    return AllCards;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return AllCards;
            }
        }
    }
}
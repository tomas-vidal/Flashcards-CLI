using System.Data.SqlClient;
using System.Configuration;

namespace Flashcards_CLI 
{
    internal class StudySessionsHelpers
    {
        private static string dbName = ConfigurationManager.AppSettings.Get("dbName");
        internal static List<StudySessionModel> GetSessions()
        {
            List<StudySessionModel> AllSessions = [];
            using (SqlConnection db = new SqlConnection($"Server=(LocalDb)\\{dbName};Database=DatabaseFlashcards;Integrated Security=true"))
            {
                try
                {
                    db.Open();
                    string command = $"SELECT * FROM StudySessions";
                    SqlCommand cmd = new SqlCommand(command, db);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0); 
                        double score = reader.GetDouble(1);
                        DateTime date = reader.GetDateTime(2);
                        int stackId = reader.GetInt32(3);    

                        AllSessions.Add(new StudySessionModel{Id = id, Score = score, Date = date, Stack_Id = stackId });
                    }
                    return AllSessions;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return AllSessions;
            }
        }
    }
}
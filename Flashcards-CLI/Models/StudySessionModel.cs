using System.Data.SqlClient;
using System.Configuration;

namespace Flashcards_CLI
{
    internal class StudySessionModel 
    {
        public int Id {get; set;}
        public DateTime Date {get; set;}
        public int Score {get; set;}
        public int Stack_Id {get; set;}
    }
}
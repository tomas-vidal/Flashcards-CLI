using System.Configuration;

namespace Flashcards_CLI 
{
    internal class FlashcardsManager
    {
        internal static void CreateCard(string stackName) {
            string front = Console.ReadLine();
            string back = Console.ReadLine();
            FlashcardsDB.CreateFlashcard(front, back, stackName);
        }
    }
}
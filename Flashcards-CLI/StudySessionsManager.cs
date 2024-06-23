using Spectre.Console;
using Flashcards_CLI.Helpers;

namespace Flashcards_CLI
{
    internal class StudySessionsManager
    {
        internal static void StudyMenu()
        {
            AnsiConsole.Write(new FigletText("Study Session").Color(Color.Green));
            AnsiConsole.Write(new FigletText("Stacks menu").Color(Color.Green));

            AnsiConsole.Markup("\t[red]0 - Type 0 to go back to main menu[/]\n");
            AnsiConsole.Markup("\tEnter the name of the stack you want to [lime]study[/]:");
            Console.WriteLine("\n");
            string userInput = StacksManager.UserInputStack();

            while (StacksHelpers.CheckIfStackExists(userInput) < 0)
            {
                userInput = StacksManager.UserInputStack();
            }

            int stackId = StacksHelpers.GetStackByName(userInput).Id;
            List<FlashcardModel> AllCards = FlashcardHelpers.GetCards(userInput);
            int score = 0;

            foreach (var card in AllCards)
            {
                Console.WriteLine($"Front: {card.Front}");
                Console.Write("Back: ");
                string back = Console.ReadLine();
                if (back == card.Back) {
                    score++;
                    AnsiConsole.Markup("[lime]Valid[/]\n");
                } else {
                    AnsiConsole.Markup("[red]Invalid[/]\n");
                }
            }

            Console.WriteLine($"Your score is {score}");

        }
    }
}
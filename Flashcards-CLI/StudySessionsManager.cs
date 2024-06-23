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

            var table = new Table();
            table.AddColumn("Current Stacks");
            List<StackModel> AllStacks = StacksHelpers.GetStacks();
            foreach(StackModel stack in AllStacks)
            {
                table.AddRow(stack.Name);
            }
            AnsiConsole.Write(table);
            AnsiConsole.Markup("\t[red]0 - Type 0 to go back to main menu[/]\n");
            AnsiConsole.Markup("\tEnter the name of the stack you want to [lime]study[/]:");
            Console.WriteLine("\n");
            string userInput = StacksManager.UserInputStack();

            if (userInput == "0")
            {
                return;
            }

            while (StacksHelpers.CheckIfStackExists(userInput) == 0)
            {
                AnsiConsole.Markup("[red]Please enter a valid stack name: [/]");
                userInput = StacksManager.UserInputStack();
            }

            int stackId = StacksHelpers.GetStackByName(userInput).Id;
            List<FlashcardModel> AllCards = FlashcardHelpers.GetCards(userInput);
            double score = 0;
            
            foreach (var card in AllCards)
            {
                Console.WriteLine($"\nFront: {card.Front}");
                Console.Write("Back: ");
                string back = Console.ReadLine();
                if (back == card.Back) {
                    score++;
                    AnsiConsole.MarkupLine("[lime]Valid[/]");
                } else {
                    AnsiConsole.MarkupLine("[red]Invalid[/]");
                }
            }
            score /= AllCards.Count;
            float scoreParsed = float.Parse(String.Format("{0:0.00}", score));
            StudySessionsDB.CreateSession(score, stackId);
            Console.WriteLine($"Your score is {scoreParsed}\n");
        }

        internal static void ShowHistory()
        {
            List<StudySessionModel> AllSessions = StudySessionsHelpers.GetSessions();
            var table = new Table();
            table.AddColumns("ID", "Date", "Stack Name", "Score");
            foreach(StudySessionModel session in AllSessions)
            {
                table.AddRow($"{session.Id}", $"{session.Date.ToString("dd-MM-yy")}", $"{StacksHelpers.GetStackById(session.Stack_Id).Name}", $"{String.Format("{0:0.00}", session.Score)}");
            }
            AnsiConsole.Write(table);
        }
    }
}
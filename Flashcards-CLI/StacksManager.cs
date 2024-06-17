using Spectre.Console;

namespace Flashcards_CLI
{
    internal class StacksManager
    {
        public static void StacksMenu()
        {
            AnsiConsole.Write(new FigletText("Stacks menu").Color(Color.Green));
            AnsiConsole.Markup("\t[red]0 - Type 0 to go back to main menu[/]\n");
            AnsiConsole.Markup("\tEnter the name of the stack you want to [lime]create[/], or the name of the one you want to [lime]edit[/]");
            Console.WriteLine("\n");

            Console.ReadLine();
        }
    }
}

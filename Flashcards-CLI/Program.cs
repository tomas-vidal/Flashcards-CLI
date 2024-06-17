using Spectre.Console;
using Spectre.Console.Cli;

namespace Flashcards_CLI
{
    public static class Program
    {
        public static bool closeApp = false;
        public static void Main(string[] args)
        {
            while (!closeApp)
            {
                AnsiConsole.Write(new FigletText("Main menu").Color(Color.Green));
                AnsiConsole.Markup("\t[red]0 - Type 0 to close the app[/]\n");
                AnsiConsole.Markup("\t[blue]1 - Type 1 to manage stacks[/]\n");
                AnsiConsole.Markup("\t[yellow]2 - Type 2 to start a study session[/]\n");
                AnsiConsole.Markup("\t[pink1]3 - Type 3 view all study sessions[/]");
                Console.WriteLine("\n");
                InputManager.GetInput();
            }
        }
    }
}
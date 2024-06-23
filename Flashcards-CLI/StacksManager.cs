using Flashcards_CLI.Helpers;
using Spectre.Console;

namespace Flashcards_CLI
{
    internal class StacksManager
    {
        internal static void StacksMenu()
        {
            var table = new Table();
            table.AddColumn("Current Stacks");
            List<StackModel> AllStacks = StacksHelpers.GetStacks();
            foreach(StackModel stack in AllStacks)
            {
                table.AddRow(stack.Name);
            }
            AnsiConsole.Write(new FigletText("Stacks menu").Color(Color.Green));
            AnsiConsole.Write(table);
            AnsiConsole.Markup("\t[red]0 - Type 0 to go back to main menu[/]\n");
            AnsiConsole.Markup("\tEnter the name of the stack you want to [lime]create[/], or the name of the one you want to [lime]edit[/]");
            Console.WriteLine("\n");

            string userInput = UserInputStack();

            if (userInput == "0") 
            {
                return;
            } 
            else 
            {
                if (StacksHelpers.CheckIfStackExists(userInput) > 0) 
                {
                    StackEditMenu();
                } 
                else 
                {
                    StacksDB.CreateStack(userInput);
                }
            }
        }

        internal static void StackEditMenu()
        {
            Console.WriteLine("EDIT MENU");
            Console.WriteLine("Youre on the table ....");
            while (true)
            {
                AnsiConsole.Markup("\t[blue]0 - Type 0 to go back[/]\n");
                AnsiConsole.Markup("\t[green]1 - Type 1 create a Flashcard in the stack[/]\n");
                AnsiConsole.Markup("\t[yellow]2 - Type 2 delete a Flashcard in the stack[/]\n");
                AnsiConsole.Markup("\t[pink1]3 - Type 3 edit a Flashcard in the stack[/]\n");
                AnsiConsole.Markup("\t[red]4 - Press 4 to delete all the stack[/]\n");
                Console.ReadLine();
            }
        }

        internal static string UserInputStack() {
            string input = Console.ReadLine();

            while (input == "") 
            {
                AnsiConsole.Markup("[red]Invalid input, please try again: [/]");
                input = Console.ReadLine();
            }

            return input;
        }
    }
}

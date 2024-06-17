using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards_CLI
{
    internal class InputManager
    {
        public static void GetInput()
        {
            AnsiConsole.Markup("Type the [lime]option[/] you want to choose: ");
            string userInput = Console.ReadLine();

            while (userInput == "")
            {
                AnsiConsole.Markup("[red]Invalid input, please try again...[/]\n");
                AnsiConsole.Markup("Type the [lime]option[/] you want to choose: ");
                userInput = Console.ReadLine();
            }

            switch (userInput)
            {
                case "0":
                    Program.closeApp = true;
                    break;
                case "1":
                    StacksManager.StacksMenu();
                    break;
                default:
                    break;
            }
        }
    }
}

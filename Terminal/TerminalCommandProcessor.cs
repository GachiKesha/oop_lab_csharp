using System;
using System.Collections.Generic;

namespace Lab4
{
    public class TerminalCommandProcessor
    {
        private readonly List<ICommand> commands = new();
        public TerminalCommandProcessor(IDataService dataService)
        {
            commands.Add(new AllGamesCommand(dataService));
            commands.Add(new AutoTestCommand(dataService));
            commands.Add(new ChangeNameCommand(dataService));
            commands.Add(new CreatePlayerCommand(dataService));
            commands.Add(new DeletePlayerCommand(dataService));
            commands.Add(new ListPlayersCommand(dataService));
            commands.Add(new PlayGameCommand(dataService));
        }

        public void ProcessCommands()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter a command: (type \"help\" for help)");
                Console.ResetColor();
                string command = Console.ReadLine();

                if (string.IsNullOrEmpty(command))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command. Please try again.");
                    continue;
                }

                string[] commandParts = command.Split(' ');

                string result = commandParts[0].ToLower();
                if (result == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nOK.");
                    return;
                }
                if (result == "help")
                {
                    HelpCommand(commandParts);
                    continue;
                }

                bool done = false;
                foreach(ICommand com in  commands)
                {
                    
                    if (com.Name == result)
                    {
                        com.Execute(commandParts);
                        done = true;
                        break;
                    }
                }

                if (!done)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command. Please try again.");
                    continue;
                }              
            }
        }
        private void HelpCommand(string[] commandParts)
        {
            int len = commandParts.Length;
            if (len == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("List of commands:");
                for (int i = 0; i < commands.Count; i++)
                {
                    commands[i].ShowInfo();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nhelp");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("#list of commands");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nexit");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("#exit app");
                Console.ResetColor();
                return;
            }
            if (len == 2)
            {
                bool done = false;
                foreach (ICommand com in commands)
                {
                    if (com.Name == commandParts[1])
                    {
                        com.ShowInfo();
                        done = true;
                        break;
                    }
                }
                if (!done)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command. Please try again.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unexpected arguments. Usage: help");
            }
        }
    }
}

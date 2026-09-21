using System;

namespace Lab4
{
    class PlayGameCommand : ICommand
    {
        private readonly IDataService _dataService;
        public string Name
        {
            get => "playgame";
        }
        public PlayGameCommand(IDataService dataService)
        {
            _dataService = dataService;
        }
        public void Execute(string[] commandParts)
        {
            int len = commandParts.Length;
            if (len < 2 || len > 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command. Usage: playgame <gametype> <player1> <player2> <rating> <win_of_first?(bool)>");
                return;
            }
            try
            {
                if (int.TryParse(commandParts[4], out int rating))
                {
                    if (bool.TryParse(commandParts[5], out bool result))
                    {
                        _dataService.CreateGame(commandParts[1],
                        commandParts[2], commandParts[3], rating, result);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nGame successfuly created.\n");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid result value. Input bool value");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid rating. Input integer value");
                }
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nplaygame <gametype> <player1> <player2> <rating> <win_of_first?(bool)>");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#create game with 2 players\n#Game types: standart, training, ai");
        }
    }
}

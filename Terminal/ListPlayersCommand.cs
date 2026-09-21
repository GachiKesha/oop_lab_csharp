using System;

namespace Lab4
{
    class ListPlayersCommand : ICommand
    {
        private readonly IDataService _dataService;
        public string Name
        {
            get => "players";
        }
        public ListPlayersCommand(IDataService dataService)
        {
            _dataService = dataService;
        }
        public void Execute(string[] commandParts)
        {
            var len = commandParts.Length;
            if (len == 1)
            {
                var players = _dataService.GetGameAccounts();

                if (players.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nList of Players:");
                    Console.ResetColor();
                    Console.WriteLine("|------------------------------------------|");
                    foreach (var player in players)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan; 
                        Console.Write(player.UserName);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\tRating: {player.CurrentRating}");
                        Console.WriteLine($"\t\tGames played: {player.GamesCount}");
                        Console.ResetColor();
                        Console.WriteLine("|------------------------------------------|");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("No players found.");
                }
            }
            else if (len > 1)
            {

                Console.ResetColor();
                Console.WriteLine("|------------------------------------------|");
                for (int i = 1; i < len; i++)
                {
                    try
                    {
                        var player = _dataService.GetGameAccount(commandParts[i]);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(player.UserName);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\tRating: {player.CurrentRating}");
                        Console.WriteLine($"\t\tGames played: {player.GamesCount}");
                        Console.ResetColor();
                        Console.WriteLine("|------------------------------------------|");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        Console.WriteLine("|------------------------------------------|");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command. Usage: players [<player1> <player2>...]");
            }
        }

        public void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nplayers [<player1> <player2>...]");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#list of players or stats of players if provided");
        }
    }
}
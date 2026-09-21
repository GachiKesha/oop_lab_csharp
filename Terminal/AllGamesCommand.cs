using System;

namespace Lab4
{
    class AllGamesCommand : ICommand
    {
        private readonly IDataService _dataService;
        public string Name
        {
            get => "games";
        }
        public AllGamesCommand(IDataService dataService)
        {
            _dataService = dataService;
        }
        public void Execute(string[] commandParts)
        {
            int len = commandParts.Length;
            if (len == 1)
            {
                _dataService.PrintGames();
            }
            else
            {
                for (int i = 1; i < len; i++)
                {
                    try
                    {
                        _dataService.PrintGames(commandParts[i]);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\ngames [<player1> <player2>...]");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#list of games played (all games if no player provided)");
        }
    }
}

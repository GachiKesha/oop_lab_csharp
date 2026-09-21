using System;

namespace Lab4
{
    class CreatePlayerCommand : ICommand
    {
        private readonly IDataService _dataService;
        public string Name
        {
            get => "createplayer";
        }
        public CreatePlayerCommand(IDataService dataService)
        {
            _dataService = dataService;
        }
        public void Execute(string[] commandParts)
        {
            var len = commandParts.Length;
            if (len != 3 && len != 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command. Usage: createplayer <accountType> <username> [<initialRating>]");
                return;
            }
            try
            {
                string accountType = commandParts[1];
                string username = commandParts[2];
                int? initialRating = len == 3 ? null : (int.TryParse(commandParts[3], out var rating) ? rating : null);
                if (initialRating != null)
                {
                    _dataService.CreateGameAccount(accountType, username, (int)initialRating);
                }
                else
                {
                    _dataService.CreateGameAccount(accountType, username);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nPlayer ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(username);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" created successfully.\n");
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
            Console.WriteLine("\ncreateplayer <accountType> <username> [<initialRating>]");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#create player\n#Account types: standart, noob, winstreak");
        }
    }
}

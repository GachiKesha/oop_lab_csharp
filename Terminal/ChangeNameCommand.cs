using System;

namespace Lab4
{
    class ChangeNameCommand : ICommand
    {
        private readonly IDataService _dataService;
        public string Name
        {
            get => "changename";
        }
        public ChangeNameCommand(IDataService dataService)
        {
            _dataService = dataService;
        }
        public void Execute(string[] commandParts)
        {
            var len = commandParts.Length;
            if (len != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command. Usage: changename <username> <new_username>");
                return;
            }
            try
            {
                var username = commandParts[1];
                var new_username = commandParts[2];
                _dataService.UpdateGameAccount(username, new_username);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\nChanged name of player ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(username);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(" to ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(new_username);
                Console.WriteLine();
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
            Console.WriteLine("\nchangename <username> <new_username>");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#change name of player");
        }
    }
}

using System;

namespace Lab4
{
    class DeletePlayerCommand : ICommand
    {
        private readonly IDataService _dataService;
        public string Name
        {
            get => "deleteplayer";
        }
        public DeletePlayerCommand(IDataService dataService)
        {
            _dataService = dataService;
        }
        public void Execute(string[] commandParts)
        {
            var len = commandParts.Length;
            if (len != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command. Usage: deleteplayer <username>");
                return;
            }
            try
            {
                string username = commandParts[1];
                _dataService.DeleteGameAccount(username);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\nPlayer ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(username);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(" deleted successfully.\n");
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
            Console.WriteLine("\ndeleteplayer <username>");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#delete player");
        }
    }
}

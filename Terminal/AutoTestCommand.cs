using System;

namespace Lab4
{
    class AutoTestCommand : ICommand
    {
        bool test_runned = false;
        private readonly IDataService _dataService;
        public string Name
        {
            get => "/test";
        }
        public AutoTestCommand(IDataService dataService)
        {
            _dataService = dataService;
        }
        public void Execute(string[] commandParts) //Lab3
        {
            if (commandParts.Length != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unexpected arguments. Usage: /test");
                Console.ResetColor();
                return;
            }
            if (!test_runned)
            {
                _dataService.CreateGameAccount("Standart", "Crico(test)", 1000);
                _dataService.CreateGameAccount("WinStreak", "Kawasaki(test)", 500);
                _dataService.CreateGameAccount("noob", "Cago(test)", 1000);
                _dataService.CreateGameAccount("Standart", "Elstripper(test)");
                _dataService.CreateGameAccount("WinStreak", "Jotaro(test)");
                Console.WriteLine("Accounts created.");
                _dataService.CreateGame("Cago(test)", 10, true);
                _dataService.CreateGame("Crico(test)", 100, false);
                _dataService.CreateGame("Kawasaki(test)", 50, true);
                _dataService.CreateGame("Cago(test)", 50, false);
                _dataService.CreateGame("ai", "Elstripper(test)", "Jotaro(test)", 25, true);

                _dataService.CreateGame("standart", "Cago(test)", "Crico(test)", 20, false);
                _dataService.CreateGame("standart", "Cago(test)", "Kawasaki(test)", 10, false);
                _dataService.CreateGame("standart", "Cago(test)", "Jotaro(test)", 34, false);

                _dataService.CreateGame("training", "Cago(test)", "Crico(test)", 100, true);
                _dataService.CreateGame("training", "Elstripper(test)", "Cago(test)", 10, false);
                _dataService.CreateGame("training", "Kawasaki(test)", "Jotaro(test)", 34, false);

                _dataService.CreateGame("standart", "Cago(test)", "Crico(test)", 20, false);
                _dataService.CreateGame("standart", "Cago(test)", "Kawasaki(test)", 10, false);
                _dataService.CreateGame("standart", "Cago(test)", "Jotaro(test)", 34, false);
                _dataService.CreateGame("standart", "Cago(test)", "Crico(test)", 20, false);
                _dataService.CreateGame("standart", "Cago(test)", "Kawasaki(test)", 10, false);
                _dataService.CreateGame("standart", "Cago(test)", "Jotaro(test)", 34, false);

                _dataService.CreateGame("standart", "Crico(test)", "Kawasaki(test)", 85, false);
                _dataService.CreateGame("standart", "Kawasaki(test)", "Cago(test)", 60, true);
                _dataService.CreateGame("standart", "Cago(test)", "Elstripper(test)", 45, false);
                _dataService.CreateGame("standart", "Elstripper(test)", "Jotaro(test)", 75, true);
                _dataService.CreateGame("standart", "Jotaro(test)", "Crico(test)", 50, false);

                _dataService.CreateGame("standart", "Crico(test)", "Cago(test)", 70, true);
                _dataService.CreateGame("standart", "Crico(test)", "Elstripper(test)", 35, false);
                _dataService.CreateGame("standart", "Crico(test)", "Jotaro(test)", 92, true);
                _dataService.CreateGame("standart", "Kawasaki(test)", "Cago(test)", 15, false);
                _dataService.CreateGame("standart", "Kawasaki(test)", "Elstripper(test)", 80, true);

                _dataService.CreateGame("standart", "Kawasaki(test)", "Jotaro(test)", 55, false);
                _dataService.CreateGame("standart", "Cago(test)", "Elstripper(test)", 88, true);
                _dataService.CreateGame("standart", "Cago(test)", "Jotaro(test)", 40, false);
                _dataService.CreateGame("standart", "Elstripper(test)", "Jotaro(test)", 70, true);
                _dataService.CreateGame("standart", "Kawasaki(test)", "Crico(test)", 25, false);

                _dataService.CreateGame("standart", "Cago(test)", "Crico(test)", 95, true);
                _dataService.CreateGame("standart", "Elstripper(test)", "Crico(test)", 50, false);
                _dataService.CreateGame("standart", "Jotaro(test)", "Crico(test)", 65, true);
                _dataService.CreateGame("standart", "Cago(test)", "Kawasaki(test)", 30, false);
                _dataService.CreateGame("standart", "Elstripper(test)", "Kawasaki(test)", 75, true);

                _dataService.CreateGame("standart", "Jotaro(test)", "Kawasaki(test)", 50, false);
                _dataService.CreateGame("standart", "Elstripper(test)", "Cago(test)", 65, true);
                _dataService.CreateGame("standart", "Jotaro(test)", "Cago(test)", 30, false);
                _dataService.CreateGame("standart", "Jotaro(test)", "Elstripper(test)", 75, true);
                Console.WriteLine("Games created.");
                //_dataService.PrintGames();
                //_dataService.PrintGames("Cago(test)");
                //_dataService.PrintGames("Crico(test)");
                //_dataService.PrintGames("Jotaro(test)");
                //_dataService.PrintGames("Kawasaki(test)");
                //_dataService.PrintGames("Elstripper(test)");
                test_runned = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Already generated test units.");
                Console.ResetColor();
            }
        }
        public void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n/test");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#generate test players and games, once per session");
        }
    }
}

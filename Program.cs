using System;
namespace Lab4
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(Console.InputEncoding);
            Console.WriteLine(Console.OutputEncoding);
            DbContext db_instance = new();
            GameRepository game_repos_instance = new(db_instance);
            GameAccountRepository gameacc_repos_instance = new(db_instance);
            DataService data_service_instance = new(game_repos_instance, gameacc_repos_instance);
            TerminalCommandProcessor program = new(data_service_instance);
            program.ProcessCommands();
        }
    }
}

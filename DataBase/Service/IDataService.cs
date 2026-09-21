using System.Collections.Generic;

namespace Lab4
{
    public interface IDataService
    {
        // Games
        void CreateGame(string gametype, string user, string opponent, int rating, bool result);
        void CreateGame(string user, int rating, bool result);
        List<Game> GetGames();
        void DeleteGame(Game game);
        void PrintGames();
        void PrintGames(string user);
        // Accounts
        void CreateGameAccount(string accountType, string username, int initialRating = 100);
        GameAccount GetGameAccount(string name);
        List<GameAccount> GetGameAccounts();
        void UpdateGameAccount(string user, string new_user);
        void DeleteGameAccount(string user);
    }

}

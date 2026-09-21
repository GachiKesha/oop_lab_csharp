using System.Collections.Generic;

namespace Lab4
{
    public interface IGameRepository
    {
        void CreateGame(string gametype, GameAccount player1, GameAccount player2, int rating, bool result);
        List<Game> ReadGames();
        Game ReadGameByID(int id);
        void UpdateGames(GameAccount gameAccount, string player, string new_player);
        void DeleteGame(Game game);
        void PrintGames();
        void PrintGames(GameAccount player);
    }

}

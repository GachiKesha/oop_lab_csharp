using System;
using System.Collections.Generic;

namespace Lab4
{
    public class GameRepository : IGameRepository
    {
        private readonly DbContext _dbContext;

        public GameRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateGame(string gametype, GameAccount player1, GameAccount player2, int rating, bool result)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating cannot be less than one.");
            }
            var player2_name = player2 == null ? "AI" : player2.UserName;
            var game = GameFactory.CreateGame(gametype, player1.UserName, player2_name, rating, result);
            _dbContext.Games.Add(game);
            if (player2 != null)
            {
                if (result)
                {
                    player1.WinGame(game);
                    player2.LoseGame(game);
                    
                }
                else
                {
                    player2.WinGame(game);
                    player1.LoseGame(game);
                }
                game.NewRating_player1 = player1.CurrentRating;
                game.NewRating_player2 = player2.CurrentRating;
            }
            else
            {
                if (result)
                {
                    player1.WinGame(game);
                }
                else
                {
                    player1.LoseGame(game);
                }
                game.NewRating_player1 = player1.CurrentRating;
            }
        }

        public List<Game> ReadGames()
        {
            return _dbContext.Games;
        }

        public Game ReadGameByID(int id)
        {
            return _dbContext.Games.Find(game => game.GameIndex == id);
        }
        private void UpdateGame(Game game, string player, string new_player)
        {
            if (game.Player1 == player)
            {
                game.Player1 = new_player;
            }
            else if (game.Player2 == player)
            {
                game.Player2 = new_player;
            }
        }

        public void UpdateGames(GameAccount gameAccount, string player, string new_player)
        {
            var games = gameAccount.gamesHistory;
            foreach (var game in games)
            {
                UpdateGame(ReadGameByID(game), player, new_player);
            }
        }

        public void DeleteGame(Game game)
        {
            _dbContext.Games.Remove(game);
        }
        public void PrintGames()
        {
            if (_dbContext.Games.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nAll games in database:");
                Console.ResetColor();
                Console.WriteLine("|------------------------------------------|");
                for (int i = 0; i < _dbContext.Games.Count; i++)
                {
                    Console.ResetColor();
                    Console.Write($"|#{_dbContext.Games[i].GameIndex}\t{_dbContext.Games[i].Player1} vs {_dbContext.Games[i].Player2}\n");
                    Console.Write($"|\tResult: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (_dbContext.Games[i].Result) Console.Write($"{_dbContext.Games[i].Player1} won");
                    else Console.Write($"{_dbContext.Games[i].Player2} won");
                    Console.Write($"\tRating: {_dbContext.Games[i].Rating}");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("|------------------------------------------|");
                }
                Console.ResetColor();
                Console.WriteLine("\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("No games found.");
            }
        }
        public void PrintGames(GameAccount player)
        {
            if (player.gamesHistory.Count > 0)
            {
                Console.ResetColor();
                Console.Write($"\nGames history for ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{player.UserName}\n");
                Console.WriteLine($"(Current rating: {player.CurrentRating})");
                Console.ResetColor();
                Console.WriteLine("|------------------------------------------|");
                foreach (int i in player.gamesHistory)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"|#{ReadGameByID(i).GameIndex} ");
                    Console.ResetColor();
                    if (ReadGameByID(i).Player1 == player.UserName)
                    {
                        Console.Write($"{ReadGameByID(i).Player1} vs {ReadGameByID(i).Player2}\n");
                        if (ReadGameByID(i).Result)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"|\tResult: won");
                            Console.Write($"\tRating: {ReadGameByID(i).Rating}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"|\tResult: lost");
                            Console.Write($"\tRating: {-ReadGameByID(i).Rating}");
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" =>{ReadGameByID(i).NewRating_player1}");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("|------------------------------------------|");
                    }
                    else
                    {
                        Console.Write($"{ReadGameByID(i).Player2} vs {ReadGameByID(i).Player1}\n");
                        if (ReadGameByID(i).Result)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"|\tResult: lost");
                            Console.Write($"\tRating: {-ReadGameByID(i).Rating}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"|\tResult: won");
                            Console.Write($"\tRating: {ReadGameByID(i).Rating}");
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" =>{ReadGameByID(i).NewRating_player2}");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("|------------------------------------------|");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("No games found.");
            }
        }
    }
}

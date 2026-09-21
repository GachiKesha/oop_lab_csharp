using System;

namespace Lab4
{
    class GameFactory
    {
        public static Game CreateGame(string gameType, string player1, string player2, int rating, bool result)
        {
            return gameType.ToLower() switch
            {
                "standart" => new StandartGame(player1, player2, rating, result),
                "training" => new TrainingGame(player1, player2, rating, result),
                "ai" => new AIGame(player1, rating, result),
                _ => throw new ArgumentException($"Invalid game type \"{gameType}\""),
            };
        }
    }
}

using System;

namespace Lab4
{
    class GameAccountFactory
    {
        public static GameAccount CreateGameAccount(string accountType, string username,int initialRating)
        {
            return accountType.ToLower() switch
            {
                "standart" => new StandartAccount(username, initialRating),
                "noob" => new NoobAccount(username, initialRating),
                "winstreak" => new WinStreakAccount(username, initialRating),
                _ => throw new ArgumentException($"Invalid account type \"{accountType}\""),
            };
        }
    }
}
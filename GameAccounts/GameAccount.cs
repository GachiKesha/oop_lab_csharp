using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public class GameAccount : IGameAccount
    {
        public string UserName { get; set; }
        private int _currentRating;
        public int CurrentRating 
        {
            get => _currentRating; 
            set
            {
                if (value > 1)
                {
                    _currentRating = value;
                }
                else 
                {
                    _currentRating = 1;
                }
            }
        }
        public int GamesCount 
        { 
            get => gamesHistory.Count;
        }
        public List<int> gamesHistory = new();
        public GameAccount(string userName, int initialRating)
        {
            UserName = userName;
            CurrentRating = initialRating;  
        }
        protected virtual void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating;
            }
            else
            {
                CurrentRating -= rating;
            }
        }
        public void WinGame(Game game)
        {
            GameRating(true, game.Rating);      
            gamesHistory.Add(game.GameIndex);
        }
        public void LoseGame(Game game)
        {
            GameRating(false, game.Rating);
            gamesHistory.Add(game.GameIndex);
        }
    }
}

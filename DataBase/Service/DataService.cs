using System;
using System.Collections.Generic;

namespace Lab4
{

    public class DataService : IDataService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGameAccountRepository _gameAccountRepository;

        public DataService(IGameRepository gameRepository, IGameAccountRepository gameAccountRepository)
        {
            _gameRepository = gameRepository;
            _gameAccountRepository = gameAccountRepository;
        }

        // Games

        public void CreateGame(string user, int rating, bool result)
        {
            var Player = _gameAccountRepository.ReadGameAccByName(user);
            _gameRepository.CreateGame("ai", Player, null, rating, result);
        }
        public void CreateGame(string gametype, string user, string opponent, int rating, bool result)
        {
            if (user == opponent) throw new ArgumentException("Can't play with yourself.");
            if (gametype != "ai")
            {        
                var Player1 = _gameAccountRepository.ReadGameAccByName(user);
                var Player2 = _gameAccountRepository.ReadGameAccByName(opponent);
                _gameRepository.CreateGame(gametype, Player1, Player2, rating, result);              
            }
            else
            {
                CreateGame(user, rating, result);
                CreateGame(opponent, rating, result);
            }
        }
        
        public List<Game> GetGames()
        {
            return _gameRepository.ReadGames();
        }

        public void DeleteGame(Game game)
        {
            _gameRepository.DeleteGame(game);
        }

        public void PrintGames()
        {
            _gameRepository.PrintGames();
        }
        public void PrintGames(string user)
        {
            var User = _gameAccountRepository.ReadGameAccByName(user);
            _gameRepository.PrintGames(User);
        }

        // Accounts

        public void CreateGameAccount(string accountType, string username, int initialRating = 100)
        {
            _gameAccountRepository.CreateGameAccount(accountType, username, initialRating);
        }

        public GameAccount GetGameAccount(string name)
        {
            return _gameAccountRepository.ReadGameAccByName(name);
        }
        public List<GameAccount> GetGameAccounts()
        {
            return _gameAccountRepository.ReadGameAccounts();
        }
        public void UpdateGameAccount(string user, string new_user)
        {
            var gameAccount = _gameAccountRepository.ReadGameAccByName(user);
            _gameAccountRepository.UpdateGameAccount(gameAccount, new_user);
            _gameRepository.UpdateGames(gameAccount, user, new_user);
        }

        public void DeleteGameAccount(string user)
        {
            var gameAccount = _gameAccountRepository.ReadGameAccByName(user);
            _gameAccountRepository.DeleteGameAccount(gameAccount);
        }
    }

}

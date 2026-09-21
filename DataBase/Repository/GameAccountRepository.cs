using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    public class GameAccountRepository : IGameAccountRepository
    {
        private readonly DbContext _dbContext;

        public GameAccountRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateGameAccount(string accountType, string username, int initialRating)
        {
            if (_dbContext.GameAccounts.Find(acc => acc.UserName == username) == null)
            {
                _dbContext.GameAccounts.Add(GameAccountFactory.CreateGameAccount(accountType, username, initialRating));
            }                    
            else throw new ArgumentException($"There is already player with name \"{username}\"");
        }

        public List<GameAccount> ReadGameAccounts()
        {
            return _dbContext.GameAccounts;
        }
        public GameAccount ReadGameAccByName(string name)
        {
            var Player = _dbContext.GameAccounts.Find(acc => acc.UserName == name);
            if (Player == null) throw new ArgumentException($"No such player \"{name}\"");
            return Player;
        }
        public void UpdateGameAccount(GameAccount gameAccount, string new_name)
        {
            if (_dbContext.GameAccounts.Find(acc => acc.UserName == new_name) == null)
            {
                gameAccount.UserName = new_name;
            }
            else throw new ArgumentException($"There is already player with name \"{new_name}\"");
        }

        public void DeleteGameAccount(GameAccount gameAccount)
        {
            _dbContext.GameAccounts.Remove(gameAccount);
        }
    }

}

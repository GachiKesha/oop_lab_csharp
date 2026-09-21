using System.Collections.Generic;

namespace Lab4
{
    public interface IGameAccountRepository
    {
        void CreateGameAccount(string accountType, string username, int initialRating = 100);
        List<GameAccount> ReadGameAccounts();
        GameAccount ReadGameAccByName(string name);
        void UpdateGameAccount(GameAccount gameAccount, string new_name);
        void DeleteGameAccount(GameAccount gameAccount);
    }

}

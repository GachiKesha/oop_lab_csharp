using System.Collections.Generic;

namespace Lab4
{
    public class DbContext
    {
        public List<GameAccount> GameAccounts { get; set; }
        public List<Game> Games { get; set; }

        public DbContext()
        {
            GameAccounts = new();
            Games = new();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class StandartGame : Game
    {
        public override int GameRating(int rating)
        {
            return rating;
        }
        public StandartGame(string player1, string player2, int rating, bool result)
            : base(player1, player2, rating, result)
        {
        }
    }
}

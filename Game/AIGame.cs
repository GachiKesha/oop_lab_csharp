namespace Lab4
{
    class AIGame : Game
    {
        public override int GameRating(int rating)
        {
            return rating / 2;
        }
        public AIGame(string user, int rating, bool result) 
            : base(user, "AI", rating, result)
        {
        }
    }
}

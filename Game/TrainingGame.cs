namespace Lab4
{
    class TrainingGame : Game
    {
        public override int GameRating(int rating)
        {
            return 0;
        }
        public TrainingGame(string player1, string player2, int rating, bool result)
            : base(player1, player2, rating, result)
        {
        }
    }
}

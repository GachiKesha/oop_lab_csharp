namespace Lab4
{
    public abstract class Game : IGame
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public int Rating { get; }
        public int NewRating_player1 { get; set; }
        public int NewRating_player2 { get; set; }
        public int GameIndex { get; set; }
        public bool Result { get; }
        private static int seed;
        public abstract int GameRating(int rating);
        public Game(string player1, string player2, int rating, bool result)
        {
            Player1 = player1;
            Player2 = player2;
            Rating = GameRating(rating);
            Result = result;
            GameIndex = ++seed;
        }
    }
}

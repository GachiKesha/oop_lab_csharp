namespace Lab4
{
    public interface IGame
    {
        string Player1 { get; }
        string Player2 { get; }
        int Rating { get; }
        int NewRating_player1 { get; set; }
        int NewRating_player2 { get; set; }
        int GameIndex { get; set; }
        bool Result { get; }

        int GameRating(int rating);
    }
}

namespace Lab4
{
    public interface IGameAccount
    {
        string UserName { get; set; }
        int CurrentRating { get; set; }
        int GamesCount { get; }
    }
}

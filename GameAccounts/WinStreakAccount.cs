namespace Lab4
{
    class WinStreakAccount : GameAccount
    {
        int streak = 0;
        protected override void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating + (rating / 10 * streak++);
            }
            else
            {
                streak = 0;
                CurrentRating -= rating;
            }
        }
        public WinStreakAccount(string userName, int initialRating = 100)
            : base(userName, initialRating)
        {
        }
    }
}

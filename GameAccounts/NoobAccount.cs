namespace Lab4
{
    class NoobAccount : GameAccount
    {
        protected override void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating;
            }
            else
            {
                CurrentRating -= rating / 2;
            }
        }
        public NoobAccount(string userName, int initialRating = 200)
            : base(userName, initialRating)
        {
        }
    }
}

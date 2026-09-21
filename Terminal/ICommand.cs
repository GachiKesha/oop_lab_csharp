namespace Lab4
{
    interface ICommand
    {
        void Execute(string[] comandParts);
        void ShowInfo();
        string Name { get; }
    }
}

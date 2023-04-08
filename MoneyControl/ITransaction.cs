namespace MoneyControl
{
    public interface ITransaction
    {
        string Name { get; }
        void AddTransactionValue(double value);
        void AddTransactionValue(float value);
        void AddTransactionValue(int value);
        void AddTransactionValue(string value);
    }
}

namespace MoneyControl
{
    public interface ITransaction
    {
        public static string FILE_PREFIX_NAMES_TRANSACTION = "Names";
        string Name { get; }
        void AddTransactionValue(double value);
        void AddTransactionValue(float value);
        void AddTransactionValue(int value);
        void AddTransactionValue(string value);
    }
}

namespace MoneyControl
{
    public abstract class TransactionBase : ITransaction
    {
        public const string FILE_NAMES_TRANSACTION = "Names.txt";
        public const string FOLDER_VALUES = "Values";
        public string Name { get; private set; }
        public List<double> values = new List<double>();

        public TransactionBase(string name)
        {
            if(name == null) throw new ArgumentNullException("name");
            this.Name = name;
        }
        public virtual void AddTransactionValue(double value)
        {
            if (value > 0)
            {
                values.Add(value);
            }
            else
            {
                throw new Exception("Value is not valid.");
            }
        }

        public abstract void AddTransactionValue(float value);
        public abstract void AddTransactionValue(int value);
        public abstract void AddTransactionValue(string value);
    }


}

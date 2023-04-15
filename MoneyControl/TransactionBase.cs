namespace MoneyControl
{
    public abstract class TransactionBase : ITransaction
    {
        public delegate void AddTransactionValueDel(Object value, EventArgs args);
        public event AddTransactionValueDel OnAddTransactionValue;
        public static string FILE_NAMES_TRANSACTION = "Names.txt";
        public static string FOLDER_VALUES = "Values";


        public string Name { get; private set; }
        public List<double> values = new List<double>();

        protected TransactionBase(string name)
        {
            if (name == "")
            {
                throw new ArgumentNullException("name");
            }
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
        public StatisticsBase getStatistic()
        {
            return new StatisticsBase(Name, values.ToArray());
        }
        public abstract void AddTransactionValue(float value);
        public abstract void AddTransactionValue(int value);
        public abstract void AddTransactionValue(string value);
    }


}

using System.Security.Cryptography.X509Certificates;

namespace MoneyControl
{
    public abstract class Transaction : ITransaction
    {
        public string Name { get; private set; }
        public List<double> values = new List<double>();

        public Transaction(string name)
        {
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

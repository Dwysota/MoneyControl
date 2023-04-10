namespace MoneyControl
{
    public class TransactionOutlay : TransactionBase
    {
        public const  int KIND_TRANSACTION = 2;
        public static  string FOLDER_TRANSACTION = "Outlays";
        
        public TransactionOutlay(string name) : base(name)
        {

        }

        public override void AddTransactionValue(double value)
        {
            base.AddTransactionValue(value);
            
        }
        public override void AddTransactionValue(string value)
        {
            if (double.TryParse(value, out double tmpValue))
            {
                this.AddTransactionValue(tmpValue);
            }
            else
            {
                throw new Exception("Value is not valid.");
            }
        }
        public override void AddTransactionValue(float value)
        {
            this.AddTransactionValue((double)value);
        }
        public override void AddTransactionValue(int value)
        {
            this.AddTransactionValue((double)value);
        }
    }
}

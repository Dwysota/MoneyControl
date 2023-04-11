namespace MoneyControl
{

    public abstract class ContainerBase : IContainerTransaction
    {
        public int PositionSelected { get;  protected set; }
        protected string FileName {  get; private set; }
        protected string Folder { get; private set; }
        protected ContainerBase(int kindTransaction)
        {
            if (!Directory.Exists(TransactionIncome.FOLDER_TRANSACTION)){
                Directory.CreateDirectory($"{TransactionIncome.FOLDER_TRANSACTION}/{TransactionBase.FOLDER_VALUES}");
            }
            if (!Directory.Exists(TransactionOutlay.FOLDER_TRANSACTION))
            {
                Directory.CreateDirectory($"{TransactionOutlay.FOLDER_TRANSACTION}/{ TransactionBase.FOLDER_VALUES}");
            }

            switch (kindTransaction)
            {
                case TransactionIncome.KIND_TRANSACTION:
                    FileName = TransactionIncome.FOLDER_TRANSACTION +"/"+ TransactionBase.FILE_NAMES_TRANSACTION;
                    Folder = TransactionIncome.FOLDER_TRANSACTION;
                    break;
                case TransactionOutlay.KIND_TRANSACTION:
                    FileName = TransactionOutlay.FOLDER_TRANSACTION +"/"+ TransactionBase.FILE_NAMES_TRANSACTION;
                    Folder = TransactionOutlay.FOLDER_TRANSACTION;
                    break;
                default:
                    throw new Exception("Invalid kind transaction");

            }
            PositionSelected = -1;
        }
        protected abstract void loadData();
        public abstract string ShowListValues();
        public abstract string ShowList();
        public virtual void AddNewName(string name)
        {
            using (var file = File.AppendText(FileName))
            {
                file.WriteLine(name);
            }
        }

        public virtual void AddValue(string value, string name)
        {
            using (var file = File.AppendText($"{Folder}/{TransactionBase.FOLDER_VALUES}/{name}.txt"))
            {
                file.WriteLine(value);
            }
        }
        public abstract void SetPosition(string position);
        public abstract string GetActiveName();
        public abstract StatisticsBase GetContainerStatistics();
    }
}

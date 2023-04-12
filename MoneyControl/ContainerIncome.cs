
namespace MoneyControl
{
    public class ContainerIncome : ContainerBase
    {
        List<TransactionIncome> incomes = new List<TransactionIncome>();
        public ContainerIncome() : base(TransactionIncome.KIND_TRANSACTION)
        {
            loadData();
        }
        protected override void loadData()
        {
            if (File.Exists(FileName))
            {
                using (var file = File.OpenText(FileName))
                {
                    var line = file.ReadLine();
                    while (line != null)
                    {
                        incomes.Add(new TransactionIncome(line));
                        string rrr = $"{Folder}/ {TransactionBase.FOLDER_VALUES} /{line}.txt";
                        if (File.Exists($"{Folder}/{TransactionBase.FOLDER_VALUES}/{line}.txt"))
                        {

                            using (var fileValues = File.OpenText($"{Folder}/{TransactionBase.FOLDER_VALUES}/{line}.txt"))
                            {
                                var lineValue = fileValues.ReadLine();
                                while (lineValue != null)
                                {
                                    incomes[incomes.Count - 1].AddTransactionValue(lineValue);
                                    lineValue = fileValues.ReadLine();
                                }

                            }

                        }
                        line = file.ReadLine();
                    }

                }
            }
        }
        public override void AddNewName(string name)
        {
            incomes.Add(new TransactionIncome(name));
            base.AddNewName(name);

        }

        public override void AddValue(string value, string name)
        {
            this.incomes[PositionSelected].AddTransactionValue(value);
            base.AddValue(value, name);


        }
        public override void SetPosition(string position)
        {
            if (int.TryParse(position, out int pos))
            {
                if (pos - 1 >= -1)
                {
                    this.PositionSelected = pos - 1;
                }

            }
            else
            {
                throw new Exception("Wrong value for name of income.");
            }
        }
        public override string ShowList()
        {
            string menuList = "------List of Incomes\n";
            int i = 0;
            foreach (var income in incomes)
            {
                i++;
                menuList += $"| {i}. {income.Name} (Summary: {income.getStatistic().Sum})\n";
            }
            return menuList;
        }
        public override string ShowListValues()
        {
            string valuesIncome = "------List of values\n";
            int i = 0;
            foreach (var value in incomes[PositionSelected].values)
            {
                i++;
                valuesIncome += $"| {i}. {value}\n";
            }
            return valuesIncome;
        }
        public override string GetActiveName()
        {
            return incomes[PositionSelected].Name;
        }
        public override StatisticsBase GetContainerStatistics()
        {
            ContainerStatistics containerStatistics = new ContainerStatistics(incomes);
            return containerStatistics.getContainerStatistics();
        }
    }
}


using System.Security.Cryptography.X509Certificates;

namespace MoneyControl
{
    public class ContainerIncome : ContainerBase
    {
        List<TransactionIncome> incomes = new List<TransactionIncome>();
        public int CountItems
        {
            get
            {
                return incomes.Count;
            }
        }
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
        public override bool AddNewName(string name)
        {
            foreach (var income in incomes)
            {
                if (income.Name == name) return false;
            }
            incomes.Add(new TransactionIncome(name));
            base.AddNewName(name);
            this.SetPosition(incomes.Count - 1);
            return true;
        }

        public override void AddValue(string value, string name)
        {
            if (this.PositionSelected > -1)
            {
                this.incomes[PositionSelected].AddTransactionValue(value);
                base.AddValue(value, name);
            }
            else
            {
                throw new Exception("Income is not selected.");
            }



        }
        public override void SetPosition(int position)
        {
            if (position >= -1)
            {
                this.PositionSelected = position;
            }
            else
            {
                throw new Exception("Wrong value for name of income.");
            }
        }
        public override void SetPosition(string position)
        {
            if (int.TryParse(position, out int pos))
            {
                this.SetPosition(pos - 1);
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
                menuList += $"| {i}. {income.Name} \t(Summary: {income.getStatistic().Sum}\tAverage: {income.getStatistic().Average}\tMin: {income.getStatistic().Min}\tMax: {income.getStatistic().Max}\n";
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

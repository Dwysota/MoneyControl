namespace MoneyControl
{
    public class ContainerOutlay : ContainerBase
    {

        List<TransactionOutlay> outlays = new List<TransactionOutlay>();

        public ContainerOutlay() : base(TransactionOutlay.KIND_TRANSACTION)
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
                        outlays.Add(new TransactionOutlay(line));
                        if (File.Exists($"{Folder}/{TransactionBase.FOLDER_VALUES}/{line}.txt"))
                        {
                            using (var fileValues = File.OpenText($"{Folder}/{TransactionBase.FOLDER_VALUES}/{line}.txt"))
                            {
                                var lineValue = fileValues.ReadLine();
                                while (lineValue != null)
                                {
                                    outlays[outlays.Count - 1].AddTransactionValue(lineValue);
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
            outlays.Add(new TransactionOutlay(name));
            base.AddNewName(name);
        }

        public override void AddValue(string value, string name)
        {
            this.outlays[PositionSelected].AddTransactionValue(value);
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
                throw new Exception("Wrong value for name of Outlay.");
            }
        }
        public override string ShowList()
        {
            string menuList = "------List of Outlays\n";
            int i = 0;
            foreach (var outlay in outlays)
            {
                i++;
                menuList += $"| {i}. {outlay.Name} (Summary: {outlay.getStatistic().Sum})\n";
            }
            return menuList;
        }
        public override string ShowListValues()
        {
            string valuesOutlay = "------List of values\n";
            int i = 0;
            foreach (var value in outlays[PositionSelected].values)
            {
                i++;
                valuesOutlay += $"| {i}. {value}\n";
            }
            return valuesOutlay;
        }
        public override string GetActiveName()
        {
            return outlays[PositionSelected].Name;
        }
        public override StatisticsBase GetContainerStatistics()
        {
            ContainerStatistics containerStatistics = new ContainerStatistics(outlays);
            return containerStatistics.getContainerStatistics();
        }
    }
}

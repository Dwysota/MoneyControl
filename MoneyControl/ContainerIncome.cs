
namespace MoneyControl
{
    public class ContainerIncome
    {
        private const string FileNamesIncomes = "NamesIncomes.txt";
        private const string FilePrefixValuesIncomes = "ValuesIncomes-";
        List<Income> incomes = new List<Income>();
        public int PositionSelected { get; set; }
        public ContainerIncome()
        {
            PositionSelected = -1;
            if (File.Exists(FileNamesIncomes))
            {
                using (var file = File.OpenText(FileNamesIncomes))
                {
                    var line = file.ReadLine();
                    while (line != null)
                    {
                        incomes.Add(new Income(line));
                        if (File.Exists($"{FilePrefixValuesIncomes}{line}.txt"))
                        {
                            using (var fileValues = File.OpenText($"{FilePrefixValuesIncomes}{line}.txt"))
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
        public void AddNewNameIncome(string name)
        {
            incomes.Add(new Income(name));
            using (var file = File.AppendText(FileNamesIncomes))
            {
                file.WriteLine(name);
            }
        }

        public void AddValueToIncome(string value)
        {
            this.incomes[PositionSelected].AddTransactionValue(value);
            using (var file = File.AppendText($"{FilePrefixValuesIncomes}{this.incomes[PositionSelected].Name}.txt"))
            {
                file.WriteLine(value);
            }
        }
        public void setPosition(string position)
        {
            if (int.TryParse(position, out int pos))
            {
                this.PositionSelected = pos;
            }
            else
            {
                throw new Exception("Wrong value for name of income.");
            }
        }
        public string ShowListIncomes()
        {
            string menuList = "";
            int i = 0;
            foreach (var income in incomes)
            {
                i++;
                menuList += $"{i}. {income.Name}\n";
            }
            return menuList;
        }
    }
}

namespace MoneyControl
{
    public class Display
    {
        public delegate void UpdateDisplay(Object value, EventArgs args);
        public event UpdateDisplay OnUpdateDisplay;
        public int position = 0;
        private const string HeaderProgram = "\t\t\tControl your money!!!\n" +
            "---------------------------------------------------------------------------\n" +
            "\t(b - back, q - quit (in main menu))\n";
        private ContainerIncome ContainerIncome { get; set; }
        private ContainerOutlay ContainerOutlay { get; set; }
        public GeneralStatistics GeneralStatistics { get; private set; }
        private bool Exists = false;
        public Display(ContainerIncome conIncome, ContainerOutlay conOutlay)
        {
            ContainerIncome = conIncome;
            ContainerOutlay = conOutlay;
            GeneralStatistics = new GeneralStatistics(ContainerIncome.GetContainerStatistics(), ContainerOutlay.GetContainerStatistics());
        }
        public void updateContainer(ContainerIncome conIncome)
        {
            ContainerIncome = conIncome;
            GeneralStatistics.Update(ContainerIncome.GetContainerStatistics(), ContainerOutlay.GetContainerStatistics());
            if (OnUpdateDisplay != null)
            {
                OnUpdateDisplay(this, new EventArgs());
            }
        }
        public void updateContainer(ContainerOutlay conOutlay)
        {
            ContainerOutlay = conOutlay;
            GeneralStatistics.Update(ContainerIncome.GetContainerStatistics(), ContainerOutlay.GetContainerStatistics());
            if (OnUpdateDisplay != null)
            {
                OnUpdateDisplay(this, new EventArgs());
            }
        }
        public void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine(HeaderProgram);
        }

        public void ShowMainMenu()
        {
            string MainMenuList = "\tMain menu:\n--------------------------\n" +
                                 $"1. Incomes (Summary: {ContainerIncome.GetContainerStatistics().Sum})\n" +
                                 $"2. Outlay (Summary: {ContainerOutlay.GetContainerStatistics().Sum})\n" +
                                 $"3. Show statistics (Balance: {GeneralStatistics.Balance})\n";
            
            Console.WriteLine(MainMenuList);
            Console.WriteLine("------Choose option:");
        }
        public void ShowException(string excepption)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t\t\t{excepption}!!!!!!!!!!!!");
            Console.ResetColor();
        }
        public void AlreadyExist(bool exist)
        {
            Exists = exist;
        }

        // Menage display for incomes
        public void ShowIncomesMenu()
        {
            Console.WriteLine(ContainerIncome.ShowList());
            Console.WriteLine("------Choose option:");
            Console.WriteLine("11. Add new income.\n12. Add value to income.\n");
        }
        public void ShowValueToIncomeP1()
        {
            Console.WriteLine(ContainerIncome.ShowList());
            Console.WriteLine("------Choose income:\n");

        }
        public void ShowValueToIncomeP2()
        {
            Console.WriteLine($"Incomes for {ContainerIncome.GetActiveName()}\n");
            Console.WriteLine(ContainerIncome.ShowListValues());
            Console.WriteLine($"Add value to {ContainerIncome.GetActiveName()}");
        }
        public void AddNewKindOfIncome()
        {
            Console.WriteLine(ContainerIncome.ShowList());
            Console.WriteLine("------New kind of income:");
        }
        // Menage display for outlay
        public void ShowOutlaysMenu()
        {
            Console.WriteLine(ContainerOutlay.ShowList());
            Console.WriteLine("------Choose option:");
            Console.WriteLine("21. Add new outlay.\n22. Add value to outlay.\n");
        }
        public void ShowValueToOutlayP1()
        {
            Console.WriteLine(ContainerOutlay.ShowList());
            Console.WriteLine("------Choose outlay:");

        }


        public void ShowValueToOutlayP2()
        {
            Console.WriteLine($"Outlays for {ContainerOutlay.GetActiveName()}\n");
            Console.WriteLine(ContainerOutlay.ShowListValues());
            Console.WriteLine($"Add value to {ContainerOutlay.GetActiveName()}");
        }
        public void AddNewKindOfOutlay()
        {
            Console.WriteLine(ContainerOutlay.ShowList());
            Console.WriteLine("New kind of outlay:");
        }
        public void SetPosition(string position)
        {

            if (int.TryParse(position, out int pos))
            {
                this.position = pos;
                if (OnUpdateDisplay != null)
                {
                    OnUpdateDisplay(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid value.");
            }

        }
        private string DrawProcent(int procent)
        {
            int i = 0;
            string line = "\t";
            while (i < procent)
            {
                line += "|";
                i++;
            }
            return line;
        }
        private void ShowStatistics()
        {

            Console.WriteLine("------Statistics------");
            if (GeneralStatistics.ProcentIncome > GeneralStatistics.ProcentOutlay)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (GeneralStatistics.ProcentOutlay > GeneralStatistics.ProcentIncome)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"|\tBalance: {GeneralStatistics.Balance}{DrawProcent(100)}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"|\tIncomes: {GeneralStatistics.Income.Sum}{DrawProcent(GeneralStatistics.ProcentIncome)}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|\tOutlays: {GeneralStatistics.Outlay.Sum}{DrawProcent(GeneralStatistics.ProcentOutlay)}\n");
            Console.ResetColor();
            Console.WriteLine("------Incomes");
            Console.WriteLine($"|\tMax Incomes: {GeneralStatistics.Income.Max}");
            Console.WriteLine($"|\tMin Incomes: {GeneralStatistics.Income.Min}");
            Console.WriteLine($"|\tAverage Incomes: {GeneralStatistics.Income.Average}\n");
            Console.WriteLine("------Outlays");
            Console.WriteLine($"|\tMax Outlays: {GeneralStatistics.Outlay.Max}");
            Console.WriteLine($"|\tMin Outlays: {GeneralStatistics.Outlay.Min}");
            Console.WriteLine($"|\tAverage Outlays: {GeneralStatistics.Outlay.Average}");

        }
        public void Show()
        {
            this.ShowHeader();
            switch (position)
            {
                case 0:
                    this.ShowMainMenu();
                    break;
                case 1:
                    this.ShowIncomesMenu();
                    break;
                case 11:
                    this.AddNewKindOfIncome();
                    break;
                case 12:
                    if (ContainerIncome.PositionSelected != -1)
                    {
                        this.ShowValueToIncomeP2();
                    }
                    else
                    {
                        this.ShowValueToIncomeP1();
                    }
                    break;
                case 2:
                    this.ShowOutlaysMenu();
                    break;
                case 21:
                    this.AddNewKindOfOutlay();
                    break;
                case 22:
                    if (ContainerOutlay.PositionSelected != -1)
                    {
                        ShowValueToOutlayP2();
                    }
                    else
                    {
                        this.ShowValueToOutlayP1();
                    }
                    break;
                case 3:
                    this.ShowStatistics();
                    break;
                default:
                    break;
            }
            if (Exists)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t\tAlready exists!!!!!!!!!!!!");
                Console.ResetColor();
                Exists = false;
            }
        }
    }
}

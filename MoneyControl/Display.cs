namespace MoneyControl
{
    public class Display
    {
        public int position = 0;
        private const string HeaderProgram = "\t\t\tControl your money!!!\n---------------------------------------------------------------------------\n\t(b - back, q - quit (in main menu))\n";

        private const string MainMenuList = "\tMain menu:\n--------------------------\n" +
                                            "1. Incomes\n" +
                                            "2. Outlay\n" +
                                            "3. Show statistics\n";
        public ContainerIncome ContainerIncome { private get; set; }
        public ContainerOutlay ContainerOutlay { private get; set; }


        public void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine(HeaderProgram);
        }

        public void ShowMainMenu()
        {
            Console.WriteLine(MainMenuList);
        }
        public void ShowException(string excepption)
        {
            Console.WriteLine($"\t\t\t{excepption}!!!!!!!!!!!!");
        }


        // Menage display for incomes
        public void ShowIncomesMenu()
        {
            Console.WriteLine(ContainerIncome.ShowListIncomes());
            Console.WriteLine("11. Add new income.\n12. Add value to income.\n");
        }
        public void ShowValueToIncomeP1()
        {
            Console.WriteLine(ContainerIncome.ShowListIncomes());
            Console.WriteLine("Choose income:");

        }
        public void ShowValueToIncomeP2()
        {
            Console.WriteLine($"Incomes for {ContainerIncome.getActiveIncome().Name}\n");
            Console.WriteLine(ContainerIncome.ShowListValuesForIncomes());
            Console.WriteLine($"Add value to {ContainerIncome.getActiveIncome().Name}");
        }
        public void AddNewKindOfIncome()
        {
            Console.WriteLine(ContainerIncome.ShowListIncomes());
            Console.WriteLine("New name income:");
        }
        // Menage display for outlay
        public void ShowOutlaysMenu()
        {
            Console.WriteLine(ContainerOutlay.ShowListOutlays());
            Console.WriteLine("21. Add new outlay.\n22. Add value to outlay.\n");
        }
        public void ShowValueToOutlayP1()
        {
            Console.WriteLine(ContainerOutlay.ShowListOutlays());
            Console.WriteLine("Choose outlay:");

        }


        public void ShowValueToOutlayP2()
        {
            Console.WriteLine($"Outlays for {ContainerOutlay.getActiveOutlay().Name}\n");
            Console.WriteLine(ContainerOutlay.ShowListValuesForOutlays());
            Console.WriteLine($"Add value to {ContainerOutlay.getActiveOutlay().Name}");
        }
        public void AddNewKindOfOutlay()
        {
            Console.WriteLine(ContainerOutlay.ShowListOutlays());
            Console.WriteLine("New name outlay:");
        }
        public void SetPosition(string position)
        {

            if (int.TryParse(position, out int pos))
            {
                this.position = pos;
            }
            else
            {
                throw new Exception("Invalid value.");
            }

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
                        ShowValueToIncomeP2();
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
                default:
                    break;
            }
        }
    }
}

namespace MoneyControl
{
    public class Display
    {
        public int position = 0;
        private const string HeaderProgram = "\t\t\tControl your money!!!\n---------------------------------------------------------------------------\n";

        private const string MainMenuList = "\tMain menu:\n--------------------------\n" +
                                            "1. Incomes\n" +
                                            "2. Outlay\n" +
                                            "3. Show statistics\n";
        public ContainerIncome ContainerIncome { private get; set; }


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
                    this.ShowValueToIncomeP1();
                    if(ContainerIncome.PositionSelected != -1)
                    {
                        ShowValueToIncomeP2 ();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

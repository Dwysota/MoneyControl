using MoneyControl;

Display display = new Display();
ContainerIncome containerIncome = new ContainerIncome();
display.ContainerIncome = containerIncome;
while (true)
{
    try
    {

        display.Show();

        var menu = Console.ReadLine();
        display.setPosition(menu);

        switch (display.position)
        {
            case 11:
                while (true)
                {
                    display.Show();
                    var input = Console.ReadLine();
                    if (input == "q")
                    {
                        break;
                    }
                    containerIncome.AddNewNameIncome(input);
                    display.ContainerIncome = containerIncome;
                }
                break;
            case 2:
                while (true)
                {
                    display.Show();
                    var input = Console.ReadLine();
                }
                break;
        }
    }
    catch (Exception e)
    {
        display.ShowException(e.Message);
    }
}



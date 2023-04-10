using MoneyControl;

Display display = new Display();
ContainerIncome containerIncome = new ContainerIncome();
display.ContainerIncome = containerIncome;
ContainerOutlay containerOutlay = new ContainerOutlay();
display.ContainerOutlay = containerOutlay;
while (true)
{
    try
    {

        display.Show();

        var menu = Console.ReadLine();
        if (menu == "b")
        {
            display.SetPosition("0");
        }
        if (menu == "q") {
            break;
        }
        display.SetPosition(menu);
        menu = "";
        switch (display.position)
        {
            case 11:
                while (true)
                {
                    display.Show();
                    var input = Console.ReadLine();
                    if (input == "b")
                    {
                        display.SetPosition("1");
                        break;
                    }
                    containerIncome.AddNewNameIncome(input);
                    display.ContainerIncome = containerIncome;
                }
                break;
            case 12:
                while (true)
                {
                    display.Show();
                    var input = Console.ReadLine();
                    if (input == "b")
                    {
                        display.SetPosition("1");
                        break;
                    }
                    containerIncome.SetPosition(input);
                    display.ContainerIncome = containerIncome;
                    while (true)
                    {
                        display.Show();
                        var value = Console.ReadLine();
                        if (value == "b")
                        {
                            display.SetPosition("12");
                            containerIncome.SetPosition("0");
                            display.ContainerIncome = containerIncome;
                            break;
                        }
                        containerIncome.AddValueToIncome(value);
                    }
                }
                break;
            case 21:
                while (true)
                {
                    display.Show();
                    var input = Console.ReadLine();
                    if (input == "b")
                    {
                        display.SetPosition("2");
                        break;
                    }
                    containerOutlay.AddNewNameOutlay(input);
                    display.ContainerOutlay = containerOutlay;
                }
                break;
            case 22:
                while (true)
                {
                    display.Show();
                    var input = Console.ReadLine();
                    if (input == "b")
                    {
                        display.SetPosition("2");
                        break;
                    }
                    containerOutlay.SetPosition(input);
                    display.ContainerOutlay = containerOutlay;
                    while (true)
                    {
                        display.Show();
                        var value = Console.ReadLine();
                        if (value == "b")
                        {
                            display.SetPosition("22");
                            containerOutlay.SetPosition("0");
                            display.ContainerOutlay = containerOutlay;
                            break;
                        }
                        containerOutlay.AddValueToOutlay(value);
                    }
                }
                break;
        }
    }
    catch (Exception e)
    {
        display.ShowException(e.Message);
    }
}



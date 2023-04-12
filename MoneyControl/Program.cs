using MoneyControl;


ContainerOutlay containerOutlay = new ContainerOutlay();
ContainerIncome containerIncome = new ContainerIncome();
Display display = new Display(containerIncome, containerOutlay);

display.OnUpdateDisplay += updateDisplay;
containerIncome.OnAddTransaction += updateDisplay;
containerOutlay.OnAddTransaction += updateDisplay;

display.updateContainer(containerOutlay);
display.updateContainer(containerIncome);
void updateDisplay(Object sender, EventArgs args)
{
    display.Show();
}

while (true)
{
    try
    {

        var menu = Console.ReadLine();
        if (menu == "b")
        {
            display.SetPosition("0");
        }
        if (menu == "q")
        {
            break;
        }
        display.SetPosition(menu);
        menu = "";
        switch (display.position)
        {
            case 11:
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "b")
                    {
                        display.SetPosition("1");
                        break;
                    }
                    containerIncome.AddNewName(input);
                    display.updateContainer(containerIncome);
                }
                break;
            case 12:
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "b")
                    {
                        display.SetPosition("1");
                        break;
                    }
                    containerIncome.SetPosition(input);
                    display.updateContainer(containerIncome);
                    
                    
                    while (true)
                    {
                        var value = Console.ReadLine();
                        if (value == "b")
                        {
                            display.SetPosition("12");
                            containerIncome.SetPosition("0");
                            display.updateContainer(containerIncome);
                            break;
                        }
                        containerIncome.AddValue(value, containerIncome.GetActiveName());
                    }
                }
                break;
            case 21:
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "b")
                    {
                        display.SetPosition("2");
                        break;
                    }
                    containerOutlay.AddNewName(input);
                    display.updateContainer(containerOutlay);
                }
                break;
            case 22:
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "b")
                    {
                        display.SetPosition("2");
                        break;
                    }
                    containerOutlay.SetPosition(input);
                    display.updateContainer(containerOutlay);
                    while (true)
                    {
                        var value = Console.ReadLine();
                        if (value == "b")
                        {
                            display.SetPosition("22");
                            containerOutlay.SetPosition("0");
                            display.updateContainer(containerOutlay);
                            break;
                        }
                        containerOutlay.AddValue(value, containerOutlay.GetActiveName());
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



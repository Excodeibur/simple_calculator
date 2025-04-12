static double Num(string input)
{
    if(string.IsNullOrWhiteSpace(input))
    {
        return 0D;
    }
    else
    {
        return Convert.ToDouble(input);
    }
}

static string getInput()
{
    Console.WriteLine("Enter a number and press enter: ");
    return Console.ReadLine() ?? "";
}
// add a catch for if any character other than numbers and 'q' are entered before the choice.

while(true)
{
    Console.WriteLine("This is a simple calculator -- you will be asked for two numbers");
    Console.WriteLine("Press 'q' at anytime to Quit");

    string input1 = getInput();
    if (input1.ToLower()=="q") break;

    string input2 = getInput();
    if (input2.ToLower()== "q") break;

    double num = Num(input1);
    double num2 = Num(input2);

    Console.WriteLine("Choose and option from the list");
    Console.WriteLine("\ta - addition");
    Console.WriteLine("\ts - subtract");
    Console.WriteLine("\tm - multiply");
    Console.WriteLine("\td - divide");
    
    string choice = Console.ReadLine()?.ToLower() ?? "";
    if (choice == "q") break;

    switch(choice)
    {
        case "a":
            Console.WriteLine($"your result is {num + num2}");
            break;

        case "s":
            Console.WriteLine($"Your result is {num - num2}");
            break;

        case "m":
            Console.WriteLine($"Your result is {num * num2}");
            break;

        case "d":
            if (num2 == 0)
            {
                Console.WriteLine("Cannot divide by 0, Please enter a different number");
            }
            else
            {
                Console.WriteLine($"Your result is {num / num2}");
            }
            break;
          
        default:
            Console.WriteLine("Please enter a valid choice");
            break;

    }
   
}

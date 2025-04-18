static double Num(string input)
{
    if (string.IsNullOrWhiteSpace(input)) //input field must be filled
    {
        return 0D;
    }
    else
    {
        return Convert.ToDouble(input);
    }
}

static string GetInput()
{
    while (true)
    {
        Console.WriteLine("Enter a number and press enter: ");
        string input = Console.ReadLine()?.Trim().ToLower() ?? ""; //if null return empty
            if (input == "q")
                return "quit";
            
            if (double.TryParse(input, out _)) //if not a digit  
                return input;
            
            Console.WriteLine("Please enter a number or 'q' to quit");
    }
}

static bool ContinueCalculation()
{
    Console.WriteLine("Would you like to do another calculation with this result? Yes or No: ");
    string Continue = Console.ReadLine()?.ToLower() ?? "";
        if (Continue == "yes") 
        {
            return true;
        }

    return false;
}

static void DisplayMenu()
{
    Console.WriteLine("Choose and option from the list");
    Console.WriteLine("\ta - addition");
    Console.WriteLine("\ts - subtract");
    Console.WriteLine("\tm - multiply");
    Console.WriteLine("\td - divide");
}

static double Calculate(double num, double num2, string choice)
{
    switch(choice) 
    {
        case "a":
            return  num + num2;
        case "s":
            return num - num2;
        case "m":
            return num * num2;
        case "d":
            if (num2 == 0)
            {
                Console.WriteLine("Cannot divide by 0, Please enter a different number");
                return double.NaN;
            }
            return num / num2;
        default:
            Console.WriteLine("invalid choice");
            return double.NaN;
    }

}

Console.WriteLine("This is a simple calculator -- you will be asked for two numbers");
Console.WriteLine("Press 'q' at anytime to Quit");

  


string input1 = GetInput();
    if (input1 == "quit") return;
string input2 = GetInput();
    if (input2 == "quit") return;
double num = Num(input1);
double num2 = Num(input2);

while(true)
{
    DisplayMenu();

    string choice = Console.ReadLine()?.ToLower() ?? "";

    if (choice == "q") break;

    double result = Calculate(num, num2, choice);
 
    if (!double.IsNaN(result))
    {
        Console.WriteLine($"Your result is {result}");
    }

    if (ContinueCalculation())
    {
        num = result;
        string input = GetInput();
        if (input == "quit") return;
        num2 = Num(input); 
    }
    else
    {   
        input1 = GetInput();
        if (input1 == "quit") return;
        input2 = GetInput();
        if (input2 == "quit") return;

        num = Num(input1);
        num2 = Num(input2);
    }
    
}
// Add unit tests to core logic, such as Num() and the calculator itself
// Allow for multiple calculations

// "q" only quits on the choice section, not on the number inptus. returns string "quit" which breaks at Num()
// inputs are not in while loop so i cant break out if q is entered



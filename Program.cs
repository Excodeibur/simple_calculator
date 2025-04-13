using System.Net.Http.Headers;

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

static string getInput()
{
    Console.WriteLine("Enter a number and press enter: ");
    string input = Console.ReadLine() ?? ""; //if null return empty
        if (input.ToLower()=="q") 
        {
            return input = "quit";
        }
        else if (input.All(char.IsDigit)==false ^ input == "")//if not a digit, or input is empty
        {
            Console.WriteLine("Please enter a number or 'q' to quit");
            return getInput();
        }
        else
        {
            return input;
        }
}

while(true)
{
    Console.WriteLine("This is a simple calculator -- you will be asked for two numbers");
    Console.WriteLine("Press 'q' at anytime to Quit");

    //inputs
    string input1 = getInput();
    if (input1 == "quit") break;
    
    string input2 = getInput();
    if (input2 == "quit") break;
  
    //convert input to double
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
// Added test to see if a string/char other than 'q' was entered. 
// if a char is entered the program continues until a num is accepted
// added notes, cleaned up some code

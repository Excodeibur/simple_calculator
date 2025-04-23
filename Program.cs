using System.Collections;
public class Calculator
{
    public static Queue<string> ToPostfix(string expression)
    {
        Stack operatorStack = new Stack();
        Queue<string> outputQueue = new Queue<string>();
        string currentNumber = "";

        foreach(char i in expression)
        {
            if (char.IsDigit(i) || i == '.')
            {
                currentNumber += i;
            }

            else
            {
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    outputQueue.Enqueue(currentNumber);
                    currentNumber = "";
                }
            }

            if (i == '(')
            {
                operatorStack.Push(i);
            }

            if (i == ')')
            {
                while (operatorStack.Peek().ToString() != "(")
                {
                    outputQueue.Enqueue(operatorStack.Pop().ToString());
                }
                operatorStack.Pop();
            }

            if (i == ')' || i == '+' || i == '-'|| i == '*' || i == '/' || i == '^')
            {

                HandleOperator(i.ToString(), operatorStack, outputQueue);
            }
        }
        
        if (!string.IsNullOrEmpty(currentNumber))
        {
            outputQueue.Enqueue(currentNumber);
        }
        
        while (operatorStack.Count > 0)
        {
            outputQueue.Enqueue(operatorStack.Pop().ToString());
        }

        return outputQueue;
    }

    
    public static void HandleOperator(string currentOp, Stack operatorStack, Queue<string> outputQueue)
    {
        if (string.IsNullOrEmpty(currentOp))
        {
            return;
        }

        if (currentOp == "(")
        {
            operatorStack.Push(currentOp);
            return;
        }
            
        if (currentOp == ")")
        {
            while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
            {
                outputQueue.Enqueue(operatorStack.Pop().ToString());
            }

            if (operatorStack.Peek() == "(")
            {
                operatorStack.Pop();
            }

            return;
        }
        
        while(operatorStack.Count > 0)
        {
            string topOp = operatorStack.Peek().ToString();
            int topPrecedence = GetPrecendence(topOp);
            int currentPrecedence = GetPrecendence(currentOp);
            
            if (topPrecedence > currentPrecedence||
                (topPrecedence == currentPrecedence && currentOp != "^"))
            {
                outputQueue.Enqueue(operatorStack.Pop().ToString());
            }
            
            else
            {
                break;
            }  
        }
        operatorStack.Push(currentOp);
    }

    
    public static int GetPrecendence(string op)
    {
        switch(op)
        {
            case "+": case "-": return 1;
            case "*": case "/": return 2;
            case "^": return 3;
            default: return 0;
        }
    }

    public static bool IsLeftAssociative(string op)
    {
        return op != "^";
    }

    public static void EvaluatePostfix(Queue<string> outputQueue)
    {
        Stack<double> numbers= new();

        foreach (string i in outputQueue)
        {
            if (double.TryParse(i, out var result)==true)
            {
                numbers.Push(result);
            }
            
            else if (i == "+")
            {
                double a = numbers.Pop();
                double b = numbers.Pop();
                numbers.Push(b + a);
            }

            else if (i == "-")
            {
                double a = numbers.Pop();
                double b = numbers.Pop();
                numbers.Push(b - a);   
            }

            else if (i == "*")
            {
                double a = numbers.Pop();
                double b = numbers.Pop();
                numbers.Push(b * a);
            }

            else if (i == "/")
            {
                double a = numbers.Pop();
                double b = numbers.Pop();
                numbers.Push(b / a);
            }

            else if (i == "^")
            {
                double a = numbers.Pop();
                double b = numbers.Pop();
                numbers.Push(Math.Pow(b, a));
            } 
        }
       
        if (numbers.Count == 1)
        {
            Console.WriteLine($"Result: {numbers.Pop()}");
        }
        else
        {
            Console.WriteLine("Invalid expression.");
        }
    }
    

    public static void Main()
    {
        Console.WriteLine("enter an expression");

        string expression = Console.ReadLine() ?? "";
        
        EvaluatePostfix(ToPostfix(expression));
    }        
}

using System.Text.RegularExpressions;
using CalculatorLibrary;

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;

        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        Calculator calculator = new Calculator();

        while (!endApp)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            Console.WriteLine("Type a number, and then press Enter");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            Console.WriteLine("Type another number, and then press Enter");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }

            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("Your option? ");

            string? op = Console.ReadLine();

            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else
                    {
                        Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }
            Console.WriteLine("------------------------\n");

            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n")
                endApp = true;

            Console.WriteLine("\n");
        }

        calculator.Finish();
        return;
    }
}
/*
타입과 관련한 예외처리 이전 코드

double num1 = 0;
double num2 = 0;

Console.WriteLine("Console Calculator in C#\r");
Console.WriteLine("------------------------\n");

Console.WriteLine("Type a number, and then press Enter");
num1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Type another number, and then press Enter");
num2 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Choose an option from the following list:");
Console.WriteLine("\ta - Add");
Console.WriteLine("\ts - Subtract");
Console.WriteLine("\tm - Multiply");
Console.WriteLine("\td - Divide");
Console.WriteLine("Your option? ");

switch (Console.ReadLine())
{
    case "a":
        Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
        break;
    case "s":
        Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
        break;
    case "m":
        Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
        break;
    case "d":
        while(num2 == 0)
        {
            Console.WriteLine("It cannot be divided by zero\n Type a number, and then press Enter");
            num2 = Convert.ToDouble(Console.ReadLine());
        }
        Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
        break;
}

Console.Write("Press any key to close the Calculator console app...");
Console.ReadKey();
*/
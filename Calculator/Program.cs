using System;

namespace taska1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunCalculator();
        }

        static void RunCalculator()
        {
            bool continueCalculations = true;

            while (continueCalculations)
            {
                DisplayWelcomeMessage();

                double number1 = GetValidNumber("Enter first number: ");
                char operation = GetValidOperation();
                double number2 = GetValidNumber("Enter second number: ");

                if (IsDivisionByZero(operation, number2))
                {
                    DisplayError("Cannot divide by zero!");
                    continue;
                }

                double result = Calculate(number1, number2, operation);
                DisplayResult(number1, number2, operation, result);

                continueCalculations = AskToContinue();
            }

            DisplayFarewellMessage();
        }

        static double Calculate(double a, double b, char operation)
        {
            switch (operation)
            {
                case '+':
                    return Add(a, b);
                case '-':
                    return Subtract(a, b);
                case '*':
                    return Multiply(a, b);
                case '/':
                    return Divide(a, b);
                default:
                    throw new ArgumentException("Invalid operation");
            }
        }

        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b) => a / b;

        static double GetValidNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    return number;
                }
                DisplayError("Please enter a valid number!");
            }
        }

        static char GetValidOperation()
        {
            char[] allowedOperations = { '+', '-', '*', '/' };

            while (true)
            {
                Console.Write($"Enter operation ({string.Join(", ", allowedOperations)}): ");
                if (char.TryParse(Console.ReadLine(), out char operation) &&
                    Array.Exists(allowedOperations, op => op == operation))
                {
                    return operation;
                }

                DisplayError($"Invalid operation! Allowed: {string.Join(", ", allowedOperations)}");
            }
        }

        static bool IsDivisionByZero(char operation, double number)
        {
            return operation == '/' && number == 0;
        }

        static bool AskToContinue()
        {
            Console.Write("\nDo you want another calculation? (y/n): ");
            string response = Console.ReadLine()?.ToLower().Trim();
            return response == "y" || response == "yes";
        }

        static void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("=== CALCULATOR ===");
            Console.WriteLine();
        }

        static void DisplayResult(double a, double b, char operation, double result)
        {
            Console.WriteLine($"\nResult: {a} {operation} {b} = {result}");
        }

        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }

        static void DisplayFarewellMessage()
        {
            Console.WriteLine("\nGoodbye!");
        }
    }
}

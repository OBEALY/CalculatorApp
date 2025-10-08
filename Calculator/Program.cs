using System;

namespace taska1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunCalculator();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Unhandled error: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        static void RunCalculator()
        {
            bool continueCalculations = true;

            while (continueCalculations)
            {
                DisplayWelcomeMessage();

                double number1 = InputHandler.GetValidNumber("Enter first number: ");
                char operation = InputHandler.GetValidOperation(new[] { '+', '-', '*', '/' });
                double number2 = InputHandler.GetValidNumber("Enter second number: ");

                try
                {
                    double result = Calculator.Calculate(number1, number2, operation);
                    DisplayResult(number1, number2, operation, result);
                }
                catch (DivideByZeroException dbz)
                {
                    DisplayError(dbz.Message);
                }
                catch (ArgumentException aex)
                {
                    DisplayError(aex.Message);
                }

                continueCalculations = AskToContinue();

                if (continueCalculations)
                    Console.Clear();
            }

            DisplayFarewellMessage();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Strict validation: loop until Y/Yes or N/No
        static bool AskToContinue()
        {
            while (true)
            {
                Console.Write("\nDo you want another calculation? (Y/N): ");
                string? response = Console.ReadLine();
                response = response?.Trim().ToLowerInvariant();

                if (response is "y" or "yes")
                    return true;

                if (response is "n" or "no")
                    return false;

                DisplayError("Please enter Y or N.");
            }
        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("=== CALCULATOR ===");
            Console.WriteLine();
        }

        static void DisplayResult(double a, double b, char operation, double result)
        {
            Console.WriteLine($"\nResult: {a} {operation} {b} = {result}");
        }

        internal static void DisplayError(string message)
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
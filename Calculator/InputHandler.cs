using System;
using System.Globalization;

namespace taska1
{
    public static class InputHandler
    {
        private static readonly CultureInfo[] AcceptedCultures = new[]
        {
            CultureInfo.CurrentCulture,
            CultureInfo.InvariantCulture,
            new CultureInfo("ru-RU"),
            new CultureInfo("en-US")
        };

        public static double GetValidNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (input is null)
                {
                    Program.DisplayError("Empty input. Try again.");
                    continue;
                }

                if (TryParseFlexibleDouble(input, out double number))
                    return number;

                Program.DisplayError("Please enter a valid number.");
            }
        }

        public static char GetValidOperation(char[] allowedOperations)
        {
            while (true)
            {
                Console.Write($"Enter operation ({string.Join(", ", allowedOperations)}): ");
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    char op = input.Trim()[0];
                    if (Array.Exists(allowedOperations, a => a == op))
                        return op;
                }

                Program.DisplayError($"Invalid operation! Allowed: {string.Join(", ", allowedOperations)}");
            }
        }

        private static bool TryParseFlexibleDouble(string input, out double value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string normalized = input.Trim();


            foreach (var culture in AcceptedCultures)
            {
                if (double.TryParse(normalized, NumberStyles.Float | NumberStyles.AllowThousands, culture, out value))
                    return true;
            }

            string[] variations = {
                normalized.Replace(',', '.'),  
                normalized.Replace('.', ',')  
            };

            CultureInfo[] parseCultures = {
                CultureInfo.InvariantCulture,
                new CultureInfo("ru-RU")
            };

            foreach (var variation in variations)
            {
                foreach (var culture in parseCultures)
                {
                    if (double.TryParse(variation, NumberStyles.Float, culture, out value))
                        return true;
                }
            }

            return false;
        }
    }
}
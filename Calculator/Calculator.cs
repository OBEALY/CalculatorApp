using System;

namespace taska1
{
    public static class Calculator
    {
        public static double Calculate(double a, double b, char operation)
        {
            return operation switch
            {
                '+' => Add(a, b),
                '-' => Subtract(a, b),
                '*' => Multiply(a, b),
                '/' => Divide(a, b),
                _ => throw new ArgumentException("Invalid operation")
            };
        }

        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;

        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Division by zero is not allowed.");
            return a / b;
        }
    }
}
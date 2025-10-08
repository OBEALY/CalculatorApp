using System;
using Xunit;

namespace taska1.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(-1, 1, 0)]
        [InlineData(0, 0, 0)]
        public void Add_Works(double a, double b, double expected)
        {
            Assert.Equal(expected, taska1.Calculator.Add(a, b));
        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(-1, -1, 0)]
        [InlineData(0, 5, -5)]
        public void Subtract_Works(double a, double b, double expected)
        {
            Assert.Equal(expected, taska1.Calculator.Subtract(a, b));
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-2, 3, -6)]
        [InlineData(0, 10, 0)]
        public void Multiply_Works(double a, double b, double expected)
        {
            Assert.Equal(expected, taska1.Calculator.Multiply(a, b));
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(-6, 3, -2)]
        public void Divide_Works(double a, double b, double expected)
        {
            Assert.Equal(expected, taska1.Calculator.Divide(a, b));
        }

        [Fact]
        public void Divide_Throws_OnZero()
        {
            Assert.Throws<DivideByZeroException>(() => taska1.Calculator.Divide(5, 0));
        }

        [Theory]
        [InlineData(2, 3, '+', 5)]
        [InlineData(3, 2, '-', 1)]
        [InlineData(2, 3, '*', 6)]
        [InlineData(6, 3, '/', 2)]
        public void Calculate_Works(double a, double b, char op, double expected)
        {
            Assert.Equal(expected, taska1.Calculator.Calculate(a, b, op));
        }

        [Fact]
        public void Calculate_InvalidOperation_Throws()
        {
            Assert.Throws<ArgumentException>(() => taska1.Calculator.Calculate(1, 2, '^'));
        }
    }
}
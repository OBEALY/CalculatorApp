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
        [InlineData(2.5, 3.1, 5.6)]
        public void Add_Works(double a, double b, double expected)
        {


            // Act
            double actual = Calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(-1, -1, 0)]
        [InlineData(0, 5, -5)]
        [InlineData(5.5, 2.2, 3.3)]
        public void Subtract_Works(double a, double b, double expected)
        {

            // Act
            double actual = Calculator.Subtract(a, b);

            // Assert
            Assert.Equal(expected, actual, 10); // precision для double
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-2, 3, -6)]
        [InlineData(0, 10, 0)]
        [InlineData(2.5, 4, 10)]
        public void Multiply_Works(double a, double b, double expected)
        {


            // Act
            double actual = Calculator.Multiply(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(-6, 3, -2)]
        [InlineData(5, 2, 2.5)]
        public void Divide_Works(double a, double b, double expected)
        {


            // Act
            double actual = Calculator.Divide(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            double a = 5;
            double b = 0;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(a, b));
        }

        [Theory]
        [InlineData(2, 3, '+', 5)]
        [InlineData(3, 2, '-', 1)]
        [InlineData(2, 3, '*', 6)]
        [InlineData(6, 3, '/', 2)]
        public void Calculate_ValidOperations_ReturnsCorrectResult(double a, double b, char op, double expected)
        {


            // Act
            double actual = Calculator.Calculate(a, b, op);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculate_InvalidOperation_ThrowsArgumentException()
        {
            // Arrange
            double a = 1;
            double b = 2;
            char invalidOp = '^';

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Calculator.Calculate(a, b, invalidOp));
            Assert.Contains("Invalid operation", exception.Message);
        }
    }
}
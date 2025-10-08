using System;
using System.IO;
using Xunit;

namespace taska1.Tests
{
    public class InputHandlerTests
    {
        [Theory]
        [InlineData("5", 5)]
        [InlineData("3.14", 3.14)]
        [InlineData("-2.5", -2.5)]
        [InlineData("1,5", 1.5)] 
        public void GetValidNumber_ValidInputs_ReturnsParsedNumber(string input, double expected)
        {
            // Arrange
            var inputReader = new StringReader(input + "\n");
            Console.SetIn(inputReader);

            // Act
            double result = InputHandler.GetValidNumber("");

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetValidOperation_ValidInput_ReturnsOperation()
        {
            // Arrange
            var input = new StringReader("+\n");
            Console.SetIn(input);
            char[] allowedOperations = { '+', '-', '*', '/' };

            // Act
            char result = InputHandler.GetValidOperation(allowedOperations);

            // Assert
            Assert.Equal('+', result);
        }

        [Fact]
        public void GetValidOperation_InvalidThenValidInput_ReturnsValidOperation()
        {
            // Arrange
            var input = new StringReader("x\n+\n");
            Console.SetIn(input);
            char[] allowedOperations = { '+', '-', '*', '/' };

            // Act
            char result = InputHandler.GetValidOperation(allowedOperations);

            // Assert
            Assert.Equal('+', result);
        }
    }
}
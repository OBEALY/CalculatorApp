using System;
using System.IO;
using Xunit;

namespace taska1.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void DisplayResult_WritesCorrectFormat()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            Program.DisplayResult(5, 3, '+', 8);

            // Assert
            string outputText = output.ToString();
            Assert.Contains("5 + 3 = 8", outputText);
        }

        [Fact]
        public void DisplayError_WritesRedMessage()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            Program.DisplayError("Test error");

            // Assert
            string outputText = output.ToString();
            Assert.Contains("Error: Test error", outputText);
        }

        [Theory]
        [InlineData("y", true)]
        [InlineData("Y", true)]
        [InlineData("yes", true)]
        [InlineData("n", false)]
        [InlineData("N", false)]
        [InlineData("no", false)]
        public void AskToContinue_ValidResponses_ReturnsExpected(string input, bool expected)
        {
            // Arrange
            var inputReader = new StringReader(input + "\n");
            Console.SetIn(inputReader);

            // Act
            bool result = Program.AskToContinue();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AskToContinue_InvalidThenValidResponse_ReturnsExpected()
        {
            // Arrange
            var inputReader = new StringReader("maybe\ny\n");
            Console.SetIn(inputReader);

            // Act
            bool result = Program.AskToContinue();

            // Assert
            Assert.True(result);
        }
    }
}
using System;
using System.Reflection;
using Xunit;

namespace taska1.Tests
{
    public class ProgramTests
    {
        private static Type GetProgramType() =>
            Type.GetType("taska1.Program, Calculator");

        private static double Calculate(double a, double b, char op)
        {
            var type = GetProgramType();
            var method = type.GetMethod(
                "Calculate",
                BindingFlags.Static | BindingFlags.NonPublic
            );
            return (double)method.Invoke(null, new object[] { a, b, op });
        }

        [Fact]
        public void Add_Works()
        {
            Assert.Equal(5, Calculate(2, 3, '+'));
        }

        [Fact]
        public void Subtract_Works()
        {
            Assert.Equal(1, Calculate(3, 2, '-'));
        }

        [Fact]
        public void Multiply_Works()
        {
            Assert.Equal(6, Calculate(2, 3, '*'));
        }

        [Fact]
        public void Divide_Works()
        {
            Assert.Equal(2, Calculate(6, 3, '/'));
        }

        [Fact]
        public void DivideByZero_ReturnsPositiveInfinity()
        {
            double result = Calculate(5, 0, '/');
            Assert.Equal(double.PositiveInfinity, result);
        }
    }
}
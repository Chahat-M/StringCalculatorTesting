using StringCalculatorLib;

namespace StringCalculatorLib.Tests
{
    public class StringCalculatorAddTestSuite
    {
        [Fact]
        public void GivenEmptyStringZeroIsExpected()
        {
            // Arrange
            string input = "";
            int expectedResult = 0;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenSingleNumberReturnsNumber()
        {
            // Arrange
            string input = "1";
            int expectedResult = 1;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenNumbersWithNewLineReturnsSum()
        {
            // Arrange
            string input = "1\n2";
            int expectedResult = 3;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenNumbersWithCommaReturnsSum()
        {
            // Arrange
            string input = "1,2";
            int expectedResult = 3;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenNumbersWithTwoDelimetersReturnsSum()
        {
            // Arrange
            string input = "1\n2,3";
            int expectedResult = 6;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenCustomDelimetersReturnsSum()
        {
            // Arrange
            string input = "//;\n1;2";
            int expectedResult = 3;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenGreaterThanFourDigitIgnoreLargerValue()
        {
            // Arrange
            string input = "2,1001";
            int expectedResult = 2;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenNegativeThrowsException()
        {
            // Arrange
            string input = "-1";

            // Act
            var exception = Assert.Throws<Exception>(() => StringCalculator.Add(input));

            // Assert
            Assert.Equal($"Negatives not allowed - {input}", exception.Message);
        }

        [Fact]
        public void GivenNumberAndDelimiterThrowsException()
        {
            // Arrange
            string input = "1,\n";

            // Act
            var exception = Assert.Throws<FormatException>(() => StringCalculator.Add(input));

            // Assert
            Assert.Equal("The input string '' was not in a correct format.", exception.Message);
        }

    }
}
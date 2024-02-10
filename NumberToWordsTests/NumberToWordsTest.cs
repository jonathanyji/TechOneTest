using Microsoft.AspNetCore.Mvc;
using TechOneTest.Controllers;

namespace TechOneTest.Tests
{
    public  class NumberToWordsTest
    {

        private readonly NumberToWordsController numToWords;

        public NumberToWordsTest()
        {
            // Setup
            numToWords = new NumberToWordsController();
        }

        [Fact]
        public void NumberToWords_ConvertNumbersToWords_ReturnCorrectResult()
        {
            // Arrange
            double? num = 123.45;
            String expected = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS";

            // Act
            IActionResult actionResult = numToWords.ConvertNumbersToWords(num);

            // Assert
            var okResult = actionResult as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);

            string actual = okResult.Value.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NumberToWords_ConvertNumbersToWords_ReturnBadRequest_InvalidInput()
        {
            // Arrange
            double? num = null;

            // Act
            IActionResult actionResult = numToWords.ConvertNumbersToWords(num);

            // Assert
            var badRequestResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badRequestResult);
            string errorMessage = (string)badRequestResult.Value;
            Assert.Equal("Invalid input", errorMessage);
        }

        [Fact]
        public void NumberToWords_ConvertNumbersToWords_ReturnNumberOutOfRange()
        {
            // Arrange
            double? num = 9999999999999.99;
            String expected = "Number out of range";

            // Act
            IActionResult actionResult = numToWords.ConvertNumbersToWords(num);

            // Assert
            var okResult = actionResult as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);

            string actual = okResult.Value.ToString();
            Assert.Equal(expected, actual);
        }
    }
}

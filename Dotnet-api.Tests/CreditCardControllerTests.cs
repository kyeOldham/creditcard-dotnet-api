using Dotnet_api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Dotnet_api.Tests
{
    public class CreditCardControllerTests
    {
        private readonly CreditCardController _controller;

        public CreditCardControllerTests()
        {
            _controller = new CreditCardController();
        }

        [Theory]
        [InlineData("4539578763621486", true)] // Valid
        [InlineData("8539577313621426", false)] // Invalid
        public void LuhnValidateCard_ReturnsExpectedResult(string cardNumber, bool expectedResult)
        {
            // Arrange
            var cardDto = new CreditcardDto { CardNumber = cardNumber };

            // Act
            var result = _controller.LuhnValidateCard(cardDto) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public void LuhnValidateCard_ReturnsBadRequestForInvalidCardNumber()
        {
            // Arrange
            var cardDto = new CreditcardDto { CardNumber = "123asad1234" };

            // Act
            var result = _controller.LuhnValidateCard(cardDto) as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Card number is invalid", result.Value);
        }

        [Fact]
        public void LuhnValidateCard_ReturnsBadRequestForEmptyCardNumber()
        {
            // Arrange
            var cardDto = new CreditcardDto { CardNumber = "" };

            // Act
            var result = _controller.LuhnValidateCard(cardDto) as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Card number is invalid", result.Value);
        }

        [Fact]
        public void LuhnValidateCard_ReturnsBadRequestForNullCardNumber()
        {
            // Arrange
            var cardDto = new CreditcardDto { CardNumber = null };

            // Act
            var result = _controller.LuhnValidateCard(cardDto) as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Card number is invalid", result.Value);
        }
    }
}

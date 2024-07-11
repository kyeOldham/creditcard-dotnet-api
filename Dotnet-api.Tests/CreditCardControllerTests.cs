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

        // Check that API returns 200 and succesfully performs luhn validation.
        [Theory]
        [InlineData("4539578763621486", true)] // Valid
        [InlineData("8539577313621426", false)] // Invalid
        public void LuhnValidateCard_ReturnsExpectedResult(string cardNumber, bool expectedResult)
        {
            // Init Dto class
            var cardDto = new CreditcardDto { CardNumber = cardNumber };

            // Run test number through validation method
            var result = _controller.LuhnValidateCard(cardDto) as OkObjectResult;

            // Compare test figure to expected output
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
        }

        // Check that API returns 400 if Card Number contains characters
        [Fact]
        public void LuhnValidateCard_ReturnsBadRequestForInvalidCardNumber()
        {
            // Init Dto class
            var cardDto = new CreditcardDto { CardNumber = "123asad1234" };

            // Run test number through validation method
            var result = _controller.LuhnValidateCard(cardDto) as BadRequestObjectResult;

            // Compare test figure to expected output
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Card number is invalid", result.Value);
        }

        // Check that API returns 400 if Card Number is an empty string
        [Fact]
        public void LuhnValidateCard_ReturnsBadRequestForEmptyCardNumber()
        {
            // Init Dto class
            var cardDto = new CreditcardDto { CardNumber = "" };

            // Run test number through validation method
            var result = _controller.LuhnValidateCard(cardDto) as BadRequestObjectResult;

            // Compare test figure to expected output
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Card number is invalid", result.Value);
        }

        // Check that API returns 400 if Card Number is Null
        [Fact]
        public void LuhnValidateCard_ReturnsBadRequestForNullCardNumber()
        {
            // Init Dto class
            var cardDto = new CreditcardDto { CardNumber = null };

           // Run test number through validation method
            var result = _controller.LuhnValidateCard(cardDto) as BadRequestObjectResult;

            // Compare test figure to expected output
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Card number is invalid", result.Value);
        }
    }
}

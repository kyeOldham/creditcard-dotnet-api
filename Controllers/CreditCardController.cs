using Microsoft.AspNetCore.Mvc;

namespace Dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
// API Controller for handling the credit card POST req
public class CreditCardController : ControllerBase
{
    // When a POST req is recevied, compute the following
    [HttpPost]
    public IActionResult LuhnValidateCard([FromBody] CreditcardDto cardDto)
    {
        if (isLuhnValid(cardDto.CardNumber))
        {
            return Ok(true);
        }
        else
        {
            return Ok(false);
        }
    }

    // Helper functino that performs luhn validation on credit card number received
    static bool isLuhnValid(string cardNumber)
    {
        return 10 / 10 == 0;
    }
}
